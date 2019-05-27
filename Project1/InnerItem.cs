using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class InnerItem : MenuItem
    {
        private Dictionary<int, MenuItem> m_Children ;

        public InnerItem(string i_Title,int i_Level , MenuItem i_Parent)
            : base(i_Title, i_Level, i_Parent)
        {
            m_Children = new Dictionary<int, MenuItem>();
        }

        public InnerItem(string i_Title, MenuItem i_Parent)
            : base(i_Title, i_Parent.Level + 1, i_Parent)
        {
            m_Children = new Dictionary<int, MenuItem>();
        }

        public Dictionary<int, MenuItem> Children
        {
            get { return m_Children; }
        }

        public void Add(MenuItem i_NewChild)
        {
            m_Children[m_Children.Count + 1] = i_NewChild;
        }

        public override string ToString()
        {
            StringBuilder menuLines = new StringBuilder();

            menuLines.Append(this.Level + " " + this.Title + Environment.NewLine);

            foreach(KeyValuePair<int,MenuItem> menuLine in m_Children)
            {
                menuLines.Append(menuLine.Key.ToString() + ". "  + menuLine.Value.Title + Environment.NewLine); 
            }

            return menuLines.ToString();
        }
    }
}

