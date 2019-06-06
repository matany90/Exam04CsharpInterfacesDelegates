using System;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            Ex04.Menus.Interfaces.MainMenu menuInterface = new Ex04.Menus.Interfaces.MainMenu();
            AppTestInterface appInterface = new AppTestInterface(menuInterface);

            Console.WriteLine("You'll be taken to the second menu in a few seconds ...");
            System.Threading.Thread.Sleep(3000);

            Ex04.Menus.Delegates.MainMenu menuDelegate = new Ex04.Menus.Delegates.MainMenu();
            AppTestDelegate appDelegates = new AppTestDelegate(menuDelegate);

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}