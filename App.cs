using QrCodeGeneratorDemo.Services.Interfaces;
using QrCodeGeneratorDemo.Views;

namespace QrCodeGeneratorDemo 
{
    public class App 
    {
        private readonly IQrCodeService _qrCodeService;
        private readonly IEmailService _emailService;

        public App(IQrCodeService qrCodeService, IEmailService emailService)
        {
            _qrCodeService = qrCodeService;
            _emailService = emailService;
        }

        public void Run()
        {
            Home home = new Home(_qrCodeService, _emailService);
            home.Show();
        }
    }
}