using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menues.Interfaces
{
    public class LeafItem : MenuItem 
    {
        IClickListener m_ClickListener;

        public LeafItem(string i_Title, MenuItem i_Parent,IClickListener i_ClickListener) : base(i_Title, i_Parent.Level + 1, i_Parent )
        {
            m_ClickListener = i_ClickListener;
        }

        public IClickListener Listener
        {
            get { return m_ClickListener; }
            set { m_ClickListener = value;  }

        }
        
    }
}
