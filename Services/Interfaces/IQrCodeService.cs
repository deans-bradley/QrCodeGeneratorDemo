using System.Drawing;

namespace QrCodeGeneratorDemo.Services.Interfaces
{
    public interface IQrCodeService
    {
        Bitmap GenerateQrCode(string text, string fileName);
    }
}