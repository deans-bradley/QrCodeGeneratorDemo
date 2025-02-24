using QrCodeGeneratorDemo.Services.Interfaces;
using QrCodeGeneratorDemo.Views.Components;

namespace QrCodeGeneratorDemo.Views
{
    public class Home
    {
        private readonly IQrCodeService _qrCodeService;
        private readonly IEmailService _emailService;

        public Home(IQrCodeService qrCodeService, IEmailService emailService)
        {
            _qrCodeService = qrCodeService;
            _emailService = emailService;
        }

        public void Show()
        {
            QrCodeGenerator qrCodeGenerator = new QrCodeGenerator(_qrCodeService, _emailService);
            string[] meunOptions = { "Generate QR Code", "Exit" };
            int option = Menu.Show("Home", meunOptions);

            switch (option)
            {
                case 1:
                    qrCodeGenerator.SendQrCodeByEmail().Wait();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}