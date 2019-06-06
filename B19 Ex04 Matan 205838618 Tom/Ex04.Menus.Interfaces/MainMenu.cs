using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const bool k_IsFirstLevel = true;
        private List<MenuItem> m_FirstLevelMenu = null;
        private MenuProperties m_MenuProperties = new MenuProperties();
        private ISelectedItemListener m_ChooseItemListener;

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
                //// User NOT press Exit
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

        public void AttachMenuToApp(ISelectedItemListener i_ChooseItemListener)
        {
            m_ChooseItemListener = i_ChooseItemListener;
        }

        public void RemoveMenuFromApp()
        {
            m_ChooseItemListener = null;
        }

        ////Invoke implemented method in AppTestInterface class
        public virtual void InformItemSelected(string i_ItemName)
        {
            if (m_ChooseItemListener != null)
            {
                m_ChooseItemListener.InformItemSelected(i_ItemName);
            }
        }
    }
}
