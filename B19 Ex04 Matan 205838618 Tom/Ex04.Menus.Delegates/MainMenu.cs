using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const bool k_IsFirstLevel = true;
        private List<MenuItem> m_FirstLevelMenu = null;
        private MenuProperties m_MenuProperties = new MenuProperties();

        public event MenuItemSelectedDelegate<string> InformChoose;

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
                ////User NOT press Exit
                if (choice != 0) 
                {
                    m_FirstLevelMenu[choice - 1].Show();
                }
            }
            else
            {
                Console.WriteLine("Error. The menu not initialized with menu hierarchy");
            }
        }

        ////Invoke implemented method in AppTestDelegate class
        public virtual void OnInformItemSelected(string i_ItemName)
        {
            if (InformChoose != null)
            {
                InformChoose.Invoke(i_ItemName);
            }
        }
    }
}
