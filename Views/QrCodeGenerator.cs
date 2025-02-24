using QrCodeGeneratorDemo.Models;
using QrCodeGeneratorDemo.Services.Interfaces;
using SendGrid.Helpers.Mail;
using System.Drawing;
using System.Drawing.Imaging;

namespace QrCodeGeneratorDemo.Views
{
    public class QrCodeGenerator
    {
        private readonly IQrCodeService _qrCodeService;
        private readonly IEmailService _emailService;

        public QrCodeGenerator(IQrCodeService qrCodeService, IEmailService emailService)
        {
            _qrCodeService = qrCodeService;
            _emailService = emailService;
        }

        public async Task SendQrCodeByEmail()
        {
            EmailResponse response = await _emailService.SendEmail(CreateEmail());
            
            if (response.IsSuccess)
            {
                Console.WriteLine(response.Message);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Status code: " + response.StatusCode);
                Console.WriteLine(response.ErrorMessage);
            }
        }

        private Email CreateEmail()
        {
            string user = "Bradley Deans"; 
            EmailAddress from = new EmailAddress("developer@deansbrad.com", "Brad Deans");
            EmailAddress to = new EmailAddress("bradley.deans@firsttech.digital", user);

            string subject = "QR Code";
            string html = File.ReadAllText($"C:/Users/{Environment.UserName}/Documents/code/QRCodeGeneratorDemo/EmailTemplates/QrCodeTemplate.html");
            html = html.Replace("{{User}}", user);

            Attachment attatchment = new Attachment
            {
                ContentId = "QrCode",
                Content = ConvertBitmapToBase64(GenerateQrCode()),
                Filename = "qrcode.png",
                Type = "image/png",
                Disposition = "inline"
            };

            return new Email(from, to, subject, html, attatchment);
        }

        private Bitmap GenerateQrCode()
        {
            return _qrCodeService.GenerateQrCode("Hello, World!", "qrcode.png");
        }

        private string ConvertBitmapToBase64(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}