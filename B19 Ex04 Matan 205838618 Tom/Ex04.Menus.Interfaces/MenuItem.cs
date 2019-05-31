using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem
    {
        private string m_ItemName;
        private List<MenuItem> m_Items = null;
        const bool k_IsFirstLevel = true;
        private MenuProperties m_MenuProperties = new MenuProperties();
        private MainMenu m_RefBack;

        public MenuItem(string i_ItemName, List<MenuItem> i_Items, MainMenu i_RefBack)
        {
            m_ItemName = i_ItemName;
            m_Items = i_Items;
            m_RefBack = i_RefBack;
        }

        public void Show()
        {
            if (m_Items != null) //Current MenuItem is NOT a leaf
            {
                int choice = m_MenuProperties.ShowMenuAndGetChoiceFromUser(m_Items, !k_IsFirstLevel);
                if (choice != 0) //User NOT press Back
                {
                    m_Items[choice - 1].Show();
                }
                else 
                {
                    m_RefBack.Show(); //User press Back
                }
            }
            else //Current MenuItem is a leaf 
            {
                m_RefBack.InformItemSelected(m_ItemName); //Call implemented method from interface in MainMenu class
            }
        }

        public string ItemName
        {
            get { return m_ItemName; }
        }

        public List<MenuItem> Items
        {
            get { return m_Items; }
        }

    }
}
