using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class MainMenu
    {
        private MenuItem m_RootItem;
        public MenuItem m_CurrentItem;
        private bool m_ExitProgram = false;
        private Dictionary<string, MenuItem> m_MenuItems = new Dictionary<string, MenuItem>();


        public void AddNewInnerItemUnder(string i_ParentTitle,string i_TitleOfNewNodde)
        {
            if (m_MenuItems.ContainsKey(i_ParentTitle))
            {
                try
                {
                (m_MenuItems[i_ParentTitle] as InnerItem).Add(new InnerItem(i_TitleOfNewNodde, m_MenuItems[i_ParentTitle]));
                }
                catch
                {
                    throw new ArgumentException(string.Format("Error:Could not add new menu under {0} ", i_ParentTitle));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Error:Could not found {0} ", i_ParentTitle));
            }
        }
        public void AddNewOperationItemUnder(string i_ParentTitle, string i_TitleOfNewNodde)
        {
            if (m_MenuItems.ContainsKey(i_ParentTitle))
            {
                (m_MenuItems[i_ParentTitle] as InnerItem).Add(new LeafItem(i_TitleOfNewNodde , m_MenuItems[i_ParentTitle]))
            }
            else
            {
                throw new ArgumentException(string.Format("Error:Could not found {0} ", i_ParentTitle));
            }


        }
        public void Show()
        {
            while (!m_ExitProgram)
            {
                Console.Clear();
                m_CurrentItem.ToString();
                int choice = getKeyInRangeFromUser((m_CurrentItem as InnerItem).Children.Count);
                handleChoice(choice);
            }
        }
        private int getKeyInRangeFromUser(int i_Range)
        {
            int choosenNumber;
            Console.WriteLine("please enter your choice:");
            string choice = Console.ReadLine();

            while (!int.TryParse(choice, out choosenNumber) || !isInRange(choosenNumber, i_Range))
            {
                Console.WriteLine("please enter a number in range {0} to {1}:" ,1,i_Range);
                choice = Console.ReadLine();
            }

            return choosenNumber;
        }

        private bool isInRange(int i_Choice, int i_Max)
        {
            return i_Choice > 0 && i_Choice <= i_Max;
        }

        private void handleChoice(int i_Choice)
        {
            Console.Clear();
            if (m_CurrentItem is InnerItem)
            {
                m_CurrentItem = (m_CurrentItem as InnerItem).Children[i_Choice];
            }
            else
            {
                (m_CurrentItem as LeafItem).Listener.OnClick(m_CurrentItem.Title);
            }
        }
    }
}
