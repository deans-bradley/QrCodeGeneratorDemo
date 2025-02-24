namespace QrCodeGeneratorDemo.Models
{
    public class EmailResponse
    {
        public string Message { get; set; } = String.Empty;
        public string ErrorMessage { get; set; } = String.Empty;
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}