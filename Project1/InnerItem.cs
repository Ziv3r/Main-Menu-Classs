using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class InnerItem : MenuItem
    {
        private Dictionary<int, MenuItem> m_Children ;

        public InnerItem(string i_Title, MenuItem i_Parent) : base(i_Title, i_Parent.Level + 1, i_Parent)
        {
            m_Children = new Dictionary<int, MenuItem>();
        }

        public Dictionary<int, MenuItem> Children
        {
            get { return m_Children; }
        }
        public void Add(InnerItem i_NewChild)
        {
            m_Children[m_Children.Count] = i_NewChild;
        }
    }
}
