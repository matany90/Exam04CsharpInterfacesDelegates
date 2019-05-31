using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class AppTestInterface : ISelectedItemListener
    {
        private MainMenu m_Menu;

        public AppTestInterface(MainMenu i_Menu)
        {
            m_Menu = i_Menu;
            m_Menu.AttachMenuToApp(this as ISelectedItemListener);
            m_Menu.InitMenuHierarchy(GetMenuHierarchyForAppTest());
            m_Menu.Show();
        }

        //ISelectedItemObserver Interface override
        public void InformItemSelected(string i_ItemSelectedName)
        {
            switch (i_ItemSelectedName)
            {
                case "Show Date":
                    ShowDate();
                    break;
                case "Show Time":
                    ShowTime();
                    break;
                case "Count Digits":
                    CountDigits();
                    break;
                case "Show Version":
                    ShowVersion();
                    break;
                default:
                    Console.WriteLine("Error. There is no method for your selection");
                    break;
            }
        }

        public void ShowDate()
        {
            Console.WriteLine(DateTime.Today);
        }

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay);
        }

        public void CountDigits()
        {
            Console.WriteLine("Please enter a sentence:");
            string userSentence = Console.ReadLine();
            int countDigits = 0;
            foreach (char ch in userSentence)
            {
                if (ch >= '0' && ch <= '9')
                {
                    countDigits++;
                }
            }
            Console.WriteLine("Numebr of digits in sentence " + countDigits);
        }

        public void ShowVersion()
        {
            Console.WriteLine("Version: 19.2.4.32");
        }

        public List<MenuItem> GetMenuHierarchyForAppTest()
        {
            string firstItemFirstLevelName = "Show Date/Time";
            string secondItemFirstLevelName = "Version and Digits";

            List<MenuItem> MenuHierarchy = new List<MenuItem>
            {
                new MenuItem(firstItemFirstLevelName, getSecondLevelMenu(firstItemFirstLevelName, m_Menu), m_Menu),
                new MenuItem(secondItemFirstLevelName, getSecondLevelMenu(secondItemFirstLevelName, m_Menu), m_Menu)

            };

            return MenuHierarchy;
        }

        private List<MenuItem> getSecondLevelMenu(string i_ItemName, MainMenu i_Menu)
        {
            List<MenuItem> SecondLevel = new List<MenuItem>();

            if (i_ItemName.Equals("Show Date/Time"))
            {
                SecondLevel.Add(new MenuItem("Show Date", null, i_Menu));
                SecondLevel.Add(new MenuItem("Show Time", null, i_Menu));
            }
            else
            {
                SecondLevel.Add(new MenuItem("Count Digits", null, i_Menu));
                SecondLevel.Add(new MenuItem("Show Version", null, i_Menu));
            }

            return SecondLevel;
        }
    }
}
