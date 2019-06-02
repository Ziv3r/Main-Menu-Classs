using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    public class MainMenu
    {
        private const int k_ExitBackSerialNumber = 0;
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";
        private readonly int r_RootHashCode;
        private MenuItem m_CurrentItem;
        private bool m_ExitProgram = false;
        private Dictionary<int, MenuItem> m_MenuItems = new Dictionary<int, MenuItem>();

        public MainMenu(string i_Header)
        {
            m_CurrentItem = new InnerItem(i_Header, 0, null);
            r_RootHashCode = m_CurrentItem.GetHashCode();
            m_MenuItems[r_RootHashCode] = m_CurrentItem;
        }

        public int RootHashCode
        {
            get { return r_RootHashCode; }
        }

        // the following 2 methods return a unique key for the added item.
        // that key is for the user to know that the current item was chosen at a given time.
        public int AddNewMenuItemUnder(int i_ParentHashCode, string i_TitleOfNewNode)
        {
            return addItem(i_ParentHashCode, i_TitleOfNewNode); 
        }

        private int addItem(int i_ParentHashCode, string i_TitleOfNewNode, Action i_ToInvoke = null)
        {
            int newNodeHashCode = -1;
            if (m_MenuItems.ContainsKey(i_ParentHashCode))
            {
                try
                {
                    MenuItem newNode = null;
                    if (i_ToInvoke == null)
                    {
                        newNode = new InnerItem(i_TitleOfNewNode, m_MenuItems[i_ParentHashCode]);
                    }
                    else
                    {
                        newNode = new LeafItem(i_TitleOfNewNode, m_MenuItems[i_ParentHashCode], i_ToInvoke);
                    }

                    newNodeHashCode = newNode.GetHashCode();
                    (m_MenuItems[i_ParentHashCode] as InnerItem).Add(newNode);
                    m_MenuItems[newNodeHashCode] = newNode;
                }
                catch
                {
                    throw new ArgumentException(string.Format("Error:Could not add new menu under {0} ", i_ParentHashCode));
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Error:Could not found {0} ", i_ParentHashCode));
            }

            return newNodeHashCode;
        }

        public int AddNewOperationItemUnder(int i_ParentHashCode, string i_TitleOfNewNode, Action i_ToInvoke)
        {
            return addItem(i_ParentHashCode, i_TitleOfNewNode, i_ToInvoke);
        }

        public void Show()
        {
            while (!m_ExitProgram)
            {
                printCurrentMenu();
                int choice = getKeyInRangeFromUser((m_CurrentItem as InnerItem).Children.Count);
                handleChoice(choice);
            }
        }

        private void printCurrentMenu()
        {
            Console.Clear();

            Console.Write("{0} {1}{2}{3}", m_CurrentItem.Level, m_CurrentItem.Title, Environment.NewLine, Environment.NewLine);

            Console.WriteLine(
                    "{0}. {1}",
                    k_ExitBackSerialNumber,
                    m_CurrentItem.Level == 0 ? k_Exit : k_Back);
            Console.Write(m_CurrentItem.ToString());
        }

        private int getKeyInRangeFromUser(int i_Range)
        {
            int choosenNumber;
            Console.WriteLine("please enter your choice:");
            string choice = Console.ReadLine();

            while (!int.TryParse(choice, out choosenNumber) || !isInRange(choosenNumber, i_Range))
            {
                Console.WriteLine("please enter a number in range {0} to {1}:", 0, i_Range);
                choice = Console.ReadLine();
            }

            return choosenNumber;
        }

        private bool isInRange(int i_Choice, int i_Max)
        {
            return i_Choice >= k_ExitBackSerialNumber && i_Choice <= i_Max;
        }

        private void handleChoice(int i_Choice)
        {
            Console.Clear();
            InnerItem currInnerItem = m_CurrentItem as InnerItem;
            if (i_Choice == k_ExitBackSerialNumber)
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
                if (currInnerItem.Children[i_Choice] is InnerItem)
                {
                    m_CurrentItem = currInnerItem.Children[i_Choice];
                }
                else
                {
                    (currInnerItem.Children[i_Choice] as LeafItem).Clicked();
                }
            }
        }
    }
}
