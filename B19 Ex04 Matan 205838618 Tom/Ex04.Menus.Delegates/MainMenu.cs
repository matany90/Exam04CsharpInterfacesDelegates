using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private List<MenuItem> m_FirstLevelMenu = null;
        private MenuProperties m_MenuProperties = new MenuProperties();
        const bool k_IsFirstLevel = true;
        public event Notifier<string> InformChoose;

        public MainMenu()
        {
        }

        public void InitMenuHierarchy(List<MenuItem> i_MenuHierarchy)
        {
            m_FirstLevelMenu = i_MenuHierarchy;
        }

        public void Show()
        {
            if (m_FirstLevelMenu != null)
            {
                int choice = m_MenuProperties.ShowMenuAndGetChoiceFromUser(m_FirstLevelMenu, k_IsFirstLevel);
                if (choice != 0) //User NOT press Exit
                {
                    m_FirstLevelMenu[choice - 1].Show();
                }
            }
            else
            {
                Console.WriteLine("Error. The menu not initialized with menu hierarchy");
            }
        }

        //Invoke implemented method in AppTest class
        public void InformItemSelected(string i_ItemName)
        {
            InformChoose.Invoke(i_ItemName);
        }
    }
}
