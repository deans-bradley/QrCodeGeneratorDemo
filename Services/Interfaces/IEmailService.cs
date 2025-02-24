using QrCodeGeneratorDemo.Models;

namespace QrCodeGeneratorDemo.Services.Interfaces
{
    public interface IEmailService
    {
        Task<EmailResponse> SendEmail(Email email);
    }
}