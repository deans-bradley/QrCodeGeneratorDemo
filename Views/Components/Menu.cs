namespace QrCodeGeneratorDemo.Views.Components
{
    public static class Menu
    {
        public static int Show(string menuTitle, string[] options)
        {
            Console.WriteLine("****************************************\n" +
                              $"{menuTitle}\n" +
                              "****************************************");

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.WriteLine("Select an option:");
            string? result = Console.ReadLine();

            if (int.TryParse(result, out int option))
            {
                return option;
            }
            else
            {
                return 0;
            }
        }
    }
}
