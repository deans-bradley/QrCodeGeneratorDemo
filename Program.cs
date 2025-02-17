namespace QrCodeGeneratorDemo 
{
    public class Program 
    {
        public static void Main(string[] args) 
        {
            string filePath = $@"C:\\Users\\{Environment.UserName}\\Pictures\\QrCodeTest";
            QrCodeGenerator qrCodeGenerator = new QrCodeGenerator();

            Console.WriteLine("Enter QR code name: ");
            string qrCodeName = Console.ReadLine() ?? "qrcode.png";

            Console.WriteLine("Enter QR code text: ");
            string qrCodeText = Console.ReadLine() ?? "Hello, World!";

            qrCodeGenerator.GenerateQrCode(qrCodeText, filePath, qrCodeName);
            Console.WriteLine($"QR code saved to {filePath}\\{qrCodeName}");
        }
    }
}