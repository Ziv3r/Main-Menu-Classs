using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menues.Interfaces
{
    public class MainMenu
    {
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        public MenuItem m_CurrentItem;
        private bool m_ExitProgram = false;
        private Dictionary<string, MenuItem> m_MenuItems = new Dictionary<string, MenuItem>();

        public MainMenu(string i_Header)
        {
            m_CurrentItem = new InnerItem(i_Header,0,null);
            m_MenuItems[i_Header] = m_CurrentItem;
        }
        public void AddNewMenuItemUnder(string i_ParentTitle, string i_TitleOfNewNode)
        {
            if (m_MenuItems.ContainsKey(i_ParentTitle))
            {
                try
                {
                    MenuItem newNode = new InnerItem(i_TitleOfNewNode, m_MenuItems[i_ParentTitle]);
                    (m_MenuItems[i_ParentTitle] as InnerItem).Add(newNode);
                     m_MenuItems[i_TitleOfNewNode] = newNode;
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

        public void AddNewOperationItemUnder(string i_ParentTitle, string i_TitleOfNewNode, IClickListener i_ClickListener)
        {
            if (m_MenuItems.ContainsKey(i_ParentTitle))
            {
                try
                {
                    MenuItem newNode = new LeafItem(i_TitleOfNewNode, m_MenuItems[i_ParentTitle], i_ClickListener);
                    (m_MenuItems[i_ParentTitle] as InnerItem).Add(newNode);
                    m_MenuItems[i_TitleOfNewNode] = newNode;
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

        public void Show()
        {
            while (!m_ExitProgram)
            {
                Console.Clear();
                printCurrentMenu();
                int choice = getKeyInRangeFromUser((m_CurrentItem as InnerItem).Children.Count);
                handleChoice(choice);
            }
        }
        private void printCurrentMenu()
        {
            Console.WriteLine(m_CurrentItem.ToString());
            Console.WriteLine(String.Format("{0}. {1}", (m_CurrentItem as InnerItem).Children.Count + 1, m_CurrentItem.Level == 0 ? k_Exit : k_Back));
        }
        private int getKeyInRangeFromUser(int i_Range)
        {
            int choosenNumber;
            Console.WriteLine("please enter your choice:");
            string choice = Console.ReadLine();

            while (!int.TryParse(choice, out choosenNumber) || !isInRange(choosenNumber, i_Range))
            {
                Console.WriteLine("please enter a number in range {0} to {1}:", 1, i_Range);
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
            if (i_Choice == (m_CurrentItem as InnerItem).Children.Count + 1)
            {
                if (m_CurrentItem.Level == 0)
                {
                    m_ExitProgram = true;
                }
                else
                {
                    m_CurrentItem = m_CurrentItem.Parent;
                }
            }
            else
            {
                if ((m_CurrentItem as InnerItem).Children[i_Choice] is InnerItem )
                {
                    m_CurrentItem = (m_CurrentItem as InnerItem).Children[i_Choice];
                }
                else
                {
                    ((m_CurrentItem as InnerItem).Children[i_Choice] as LeafItem).Listener.OnClick(m_CurrentItem.Title);
                }
            }
        }
    }
}
