namespace QrCodeGeneratorDemo.Views.Components
{
    public static class Common
    {
        public static void Loader()
        {
            Console.Write("Loading");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
