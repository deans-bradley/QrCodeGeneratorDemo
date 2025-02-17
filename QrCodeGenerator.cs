using System.Drawing;
using System.Drawing.Imaging;
using QRCoder;

namespace QrCodeGeneratorDemo
{
    public class QrCodeGenerator
    {
        public void GenerateQrCode(string text, string filePath, string fileName)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            if (!Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                Directory.CreateDirectory(filePath);
            }
            
            filePath = Path.Combine(filePath, fileName + ".png");
            qrCodeImage.Save(filePath, ImageFormat.Png);
        }
    }
}
