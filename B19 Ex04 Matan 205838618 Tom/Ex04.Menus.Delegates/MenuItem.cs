using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MenuItem
    {
        private const bool k_IsFirstLevel = true;
        private string m_ItemName;
        private List<MenuItem> m_Items = null;
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
            ////Current MenuItem is NOT a leaf
            if (m_Items != null) 
            {
                int choice = m_MenuProperties.ShowMenuAndGetChoiceFromUser(m_Items, !k_IsFirstLevel);
                ////User NOT press Back
                if (choice != 0) 
                {
                    m_Items[choice - 1].Show();
                }
                else 
                {
                    ////User press Back
                    m_RefBack.Show(); 
                }
            }
            else
            {
                ////Call method in MainMenu - this method invoke Delegate's Invoke Method
                m_RefBack.OnInformItemSelected(m_ItemName); 
                if (m_MenuProperties.IsChooseAgain())
                {
                    m_RefBack.Show();
                }
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
