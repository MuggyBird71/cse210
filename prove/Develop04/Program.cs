class Program
{
    static void Main(string[] args)
    {
        MenuSystem menu = new MenuSystem();
        bool exit = false;

        while (!exit)
        {
            menu.DisplayMenu();
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 4)
            {
                exit = true;
                Console.WriteLine("Exiting program...");
                continue;
            }

            menu.SelectActivity(choice);
        }
    }
}
