using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;
using QrCodeGeneratorDemo.Services.Interfaces;

namespace QrCodeGeneratorDemo.Services
{
    public class QrCodeService : IQrCodeService
    {
        public Bitmap GenerateQrCode(string text, string fileName)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            
            return qrCode.GetGraphic(20);
        }
    }
}
