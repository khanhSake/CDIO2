using CeoMemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CeoMemo.Models.Human;
using CeoMemo.Models.Payroll;
using CeoMemo.DTOs;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IntegrationController : ControllerBase
    {
        private readonly HumanDbContext _humanDb;
        private readonly PayrollDbContext _payrollDb;

        public IntegrationController(HumanDbContext humanDb, PayrollDbContext payrollDb)
        {
            _humanDb = humanDb;
            _payrollDb = payrollDb;
        }
        // 1. GET /employees
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _humanDb.Employees.ToListAsync();
            return Ok(employees);
        }

        // 2. GET /payroll
        [HttpGet("payroll")]
        public async Task<IActionResult> GetPayroll()
        {
            var salaries = await _payrollDb.Salaries.ToListAsync();
            var employees = await _humanDb.Employees.ToListAsync();

            var result = from s in salaries
                         join e in employees on s.EmployeeId equals e.EmployeeId
                         select new SalaryDto
                         {
                             SalaryId = s.SalaryId,
                             SalaryMonth = s.SalaryMonth,
                             BaseSalary = s.BaseSalary,
                             Bonus = s.Bonus,
                             Deductions = s.Deductions,
                             NetSalary = s.NetSalary,
                             EmployeeID = e.EmployeeId,
                             FullName = e.FullName,
                             DepartmentID = e.DepartmentId,
                             PositionID = e.PositionId
                         };

            return Ok(result);
        }

        // 3. GET /attendance
        [HttpGet("attendance")]
        public async Task<IActionResult> GetAttendance()
        {
            var attendance = await _payrollDb.Attendances.ToListAsync();
            return Ok(attendance);
        }

        [HttpPost("add-employee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName) ||
                string.IsNullOrWhiteSpace(dto.Gender) || string.IsNullOrWhiteSpace(dto.PhoneNumber) ||
                string.IsNullOrWhiteSpace(dto.Email) || dto.DateOfBirth == default ||
                dto.DepartmentID <= 0 || dto.PositionID <= 0)
            {
                return BadRequest("Thiếu dữ liệu bắt buộc");
            }

            using var trans1 = await _humanDb.Database.BeginTransactionAsync();
            using var trans2 = await _payrollDb.Database.BeginTransactionAsync();

            try
            {
                var now = DateTime.UtcNow;

                // Thêm vào HumanDb (ID tự động tăng)
                var humanEmp = new CeoMemo.Models.Human.Employee
                {
                    FullName = dto.FullName,
                    DateOfBirth = DateOnly.FromDateTime(dto.DateOfBirth),
                    Gender = dto.Gender,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    HireDate = DateOnly.FromDateTime(now),
                    DepartmentId = dto.DepartmentID,
                    PositionId = dto.PositionID,
                    Status = "Active",
                    CreatedAt = now
                };
                _humanDb.Employees.Add(humanEmp);
                await _humanDb.SaveChangesAsync();

                int newEmployeeId = humanEmp.EmployeeId;

                // Thêm vào PayrollDb
                var payrollEmp = new CeoMemo.Models.Payroll.Employee
                {
                    EmployeeId = newEmployeeId,
                    FullName = dto.FullName,
                    DepartmentId = dto.DepartmentID,
                    PositionId = dto.PositionID,
                    Status = "Active"
                };
                _payrollDb.Employees.Add(payrollEmp);
                await _payrollDb.SaveChangesAsync();

                await trans1.CommitAsync();
                await trans2.CommitAsync();

                return Ok($"Thêm nhân viên thành công với ID: {newEmployeeId}");
            }
            catch
            {
                await trans1.RollbackAsync();
                await trans2.RollbackAsync();
                return StatusCode(500, "Thêm thất bại. Đã rollback");
            }
        }

        // PUT /update-employee/123
        [HttpPut("update-employee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeDto dto)
        {
            var emp1 = await _humanDb.Employees.FindAsync(employeeId);
            var emp2 = await _payrollDb.Employees.FindAsync(employeeId);

            if (emp1 == null || emp2 == null)
                return NotFound("Nhân viên không tồn tại");

            emp1.FullName = dto.FullName;
            emp1.DepartmentId = dto.DepartmentID;
            emp1.PositionId = dto.PositionID;
            emp1.UpdatedAt = DateTime.UtcNow;

            emp2.FullName = dto.FullName;
            emp2.DepartmentId = dto.DepartmentID;
            emp2.PositionId = dto.PositionID;

            await _humanDb.SaveChangesAsync();
            await _payrollDb.SaveChangesAsync();

            return Ok("Cập nhật thành công");
        }

        // 6. DELETE /delete-employee
        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            int employeeId = int.Parse(id);
            var emp1 = await _humanDb.Employees.FindAsync(employeeId);
            var emp2 = await _payrollDb.Employees.FindAsync(employeeId);

            if (emp1 == null || emp2 == null)
                return NotFound("Không tìm thấy nhân viên");

            bool hasSalary = await _payrollDb.Salaries.AnyAsync(s => s.EmployeeId == employeeId);
            bool hasDividend = await _humanDb.Dividends.AnyAsync(d => d.EmployeeId == employeeId);

            if (hasSalary || hasDividend)
                return BadRequest("Không thể xóa nhân viên có dữ liệu lương hoặc cổ tức");

            _humanDb.Employees.Remove(emp1);
            _payrollDb.Employees.Remove(emp2);

            await _humanDb.SaveChangesAsync();
            await _payrollDb.SaveChangesAsync();

            return Ok("Xóa thành công");
        }

        // 7. GET /reports
        [HttpGet("reports")]
        public async Task<IActionResult> GetReports()
        {

            var employees = await _humanDb.Employees.ToListAsync();
            var dividends = await _humanDb.Dividends.ToListAsync();
            var salaries = await _payrollDb.Salaries.ToListAsync();

            var report = from emp in employees
                         join dividend in dividends on emp.EmployeeId equals dividend.EmployeeId into divs
                         from div in divs.DefaultIfEmpty()
                         join salary in salaries on emp.EmployeeId equals salary.EmployeeId into sals
                         from sal in sals.DefaultIfEmpty()
                         select new
                         {
                             emp.EmployeeId,
                             emp.FullName,
                             emp.DepartmentId,
                             emp.PositionId,
                             DividendAmount = div?.DividendAmount ?? 0,
                             NetSalary = sal?.NetSalary ?? 0
                         };

            return Ok(report);
        }

        // 8. POST /alerts
        [HttpPost("alerts")]
        public IActionResult PostAlert([FromBody] AlertDto dto)
        {
            // Log the alert (integration with email/slack could be added later)
            Console.WriteLine($"ALERT [{dto.Type}] - {dto.Message}");
            return Ok("Đã ghi nhận cảnh báo");
        }
        // GET /employees/search?id=1001&name=An&departmentId=2&positionId=3
        [HttpGet("employees/search")]
        public async Task<IActionResult> SearchEmployees([FromQuery] string? id, [FromQuery] string? name, [FromQuery] int? departmentId, [FromQuery] int? positionId)
        {
            var query = _humanDb.Employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .AsQueryable();
            if (!string.IsNullOrEmpty(id))
            {
                if (int.TryParse(id, out int empId))
                    query = query.Where(e => e.EmployeeId == empId);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FullName.Contains(name));
            }

            if (departmentId.HasValue)
            {
                query = query.Where(e => e.DepartmentId == departmentId);
            }

            if (positionId.HasValue)
            {
                query = query.Where(e => e.PositionId == positionId);
            }

            var result = await query.ToListAsync();
            return Ok(result);
        }
        // GET /payroll/by-month?month=2025-04
        [HttpGet("payroll/by-month")]
        public async Task<IActionResult> GetPayrollByMonth([FromQuery] string month)
        {
            if (!DateOnly.TryParse($"{month}-01", out var salaryMonth))
                return BadRequest("Tháng không hợp lệ, định dạng đúng là YYYY-MM");

            var salaries = await _payrollDb.Salaries
                .Where(s => s.SalaryMonth.Year == salaryMonth.Year && s.SalaryMonth.Month == salaryMonth.Month)
                .ToListAsync();

            var employees = await _humanDb.Employees.ToListAsync();

            var result = from s in salaries
                         join e in employees on s.EmployeeId equals e.EmployeeId
                         select new SalaryDto
                         {
                             SalaryId = s.SalaryId,
                             SalaryMonth = s.SalaryMonth,
                             BaseSalary = s.BaseSalary,
                             Bonus = s.Bonus,
                             Deductions = s.Deductions,
                             NetSalary = s.NetSalary,
                             EmployeeID = e.EmployeeId,
                             FullName = e.FullName,
                             DepartmentID = e.DepartmentId,
                             PositionID = e.PositionId
                         };

            return Ok(result);
        }
        // PUT /update-salary
        [HttpPut("update-salary")]
        public async Task<IActionResult> UpdateSalary([FromBody] SalaryDto dto)
        {
            var salary = await _payrollDb.Salaries.FindAsync(dto.SalaryId);
            if (salary == null)
                return NotFound("Không tìm thấy bản ghi lương");

            salary.BaseSalary = dto.BaseSalary;
            salary.Bonus = dto.Bonus;
            salary.Deductions = dto.Deductions;
            salary.NetSalary = (decimal)(dto.BaseSalary + dto.Bonus - dto.Deductions);

            await _payrollDb.SaveChangesAsync();

            return Ok("Cập nhật lương thành công");
        }
        // GET /salary-history/{employeeId}
        [HttpGet("salary-history/{employeeId}")]
        public async Task<IActionResult> GetSalaryHistory(int employeeId)
        {
            var salaryHistory = await _payrollDb.Salaries
                .Where(s => s.EmployeeId == employeeId)
                .OrderByDescending(s => s.SalaryMonth)
                .ToListAsync();

            return Ok(salaryHistory);
        }
        // GET /salary/chart?year=2025
        [HttpGet("salary/chart")]
        public async Task<IActionResult> GetSalaryChart([FromQuery] int year)
        {
            var data = await _payrollDb.Salaries
                .Where(s => s.SalaryMonth.Year == year)
                .GroupBy(s => s.SalaryMonth.Month)
                .Select(g => new {
                    Month = g.Key,
                    TotalNetSalary = g.Sum(s => s.NetSalary)
                })
                .OrderBy(r => r.Month)
                .ToListAsync();

            return Ok(data);
        }
        // GET /alerts/leave?threshold=5
        [HttpGet("alerts/leave")]
        public async Task<IActionResult> GetLeaveAlerts([FromQuery] int threshold = 5)
        {
            var data = await _payrollDb.Attendances
                .GroupBy(a => a.EmployeeId)
                .Select(g => new {
                    EmployeeId = g.Key,
                    LeaveDays = g.Sum(a => a.LeaveDays)
                })
                .Where(r => r.LeaveDays > threshold)
                .ToListAsync();

            return Ok(data);
        }
        // POST /send-payroll-emails
        [HttpPost("send-payroll-emails")]
        public async Task<IActionResult> SendPayrollEmails()
        {
            var employees = await _humanDb.Employees.ToListAsync();
            var salaries = await _payrollDb.Salaries
                .Where(s => s.SalaryMonth.Month == DateTime.UtcNow.Month &&
                            s.SalaryMonth.Year == DateTime.UtcNow.Year)
                .ToListAsync();

            foreach (var emp in employees)
            {
                var salary = salaries.FirstOrDefault(s => s.EmployeeId == emp.EmployeeId);
                if (salary == null) continue;

                // Giả lập gửi email (bạn cần tích hợp SMTP thật)
                Console.WriteLine($"Gửi email cho {emp.FullName} - Lương tháng: {salary.NetSalary} VND");
            }

            return Ok("Đã gửi email bảng lương");
        }
    }
}
