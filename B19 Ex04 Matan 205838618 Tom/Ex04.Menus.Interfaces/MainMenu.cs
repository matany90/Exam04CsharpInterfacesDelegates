using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private List<MenuItem> m_FirstLevelMenu = null;
        private MenuProperties m_MenuProperties = new MenuProperties();
        const bool k_IsFirstLevel = true;
        ISelectedItemListener m_ChooseItemListener;

        public MainMenu()
        {
        }

        public void InitMenuHierarchy(List<MenuItem> i_MenuHierarchy)
        {
            m_FirstLevelMenu = i_MenuHierarchy;
        }

        public void Show()
        {
            int choice = m_MenuProperties.ShowMenuAndGetChoiceFromUser(m_FirstLevelMenu, k_IsFirstLevel);
            if (choice != 0) //User NOT press Exit
            {
                m_FirstLevelMenu[choice - 1].Show();
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

        //Invoke implemented method in AppTest class
        public void InformItemSelected(string i_ItemName)
        {
            if (m_ChooseItemListener != null)
            {
                m_ChooseItemListener.InformItemSelected(i_ItemName);
            }
        }
    }
}
