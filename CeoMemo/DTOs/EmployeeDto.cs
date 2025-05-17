namespace CeoMemo.DTOs
{
    public class EmployeeDto
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
    }

}
