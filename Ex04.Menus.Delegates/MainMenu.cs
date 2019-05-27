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
        private MenuItem m_CurrentItem;
        private bool m_ExitProgram = false;
        private Dictionary<string, MenuItem> m_MenuItems = new Dictionary<string, MenuItem>();

        public MainMenu(string i_Header)
        {
            m_CurrentItem = new InnerItem(i_Header, 0, null);
            m_MenuItems[i_Header] = m_CurrentItem;
        }

        public void AddNewMenuItemUnder(string i_ParentTitle, string i_TitleOfNewNode)
        {
            addItem(i_ParentTitle, i_TitleOfNewNode); 
        }

        private void addItem(string i_ParentTitle, string i_TitleOfNewNode, Action<string> i_ToInvoke = null)
        {
            if (m_MenuItems.ContainsKey(i_ParentTitle))
            {
                try
                {
                    MenuItem newNode = null;
                    if (i_ToInvoke == null)
                    {
                        newNode = new InnerItem(i_TitleOfNewNode, m_MenuItems[i_ParentTitle]);
                    }
                    else
                    {
                        newNode = new LeafItem(i_TitleOfNewNode, m_MenuItems[i_ParentTitle], i_ToInvoke);
                    }

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

        public void AddNewOperationItemUnder(string i_ParentTitle, string i_TitleOfNewNode, Action<string> i_ToInvoke)
        {
            addItem(i_ParentTitle, i_TitleOfNewNode, i_ToInvoke);
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
