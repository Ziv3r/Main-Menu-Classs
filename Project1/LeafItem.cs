using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class LeafItem : MenuItem 
    {
        IClickListener m_ClickListener;

        public IClickListener Listener
        {
            get { return m_ClickListener; }
            set { m_ClickListener = value;  }

        }
        
    }
}
