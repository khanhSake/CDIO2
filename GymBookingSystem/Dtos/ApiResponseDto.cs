namespace GymBookingSystem.Dtos
{
    public class ApiResponseDto
    {
        /// <summary>
        /// True nếu thành công, false nếu có lỗi
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Thông báo chung (ví dụ: "Đăng ký thành công!" hoặc mô tả lỗi)
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Nếu có lỗi validation, chứa danh sách lỗi
        /// </summary>
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
