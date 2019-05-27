using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    internal class LeafItem : MenuItem
    {
        private readonly IClickListener r_ClickListener;

        public LeafItem(string i_Title, MenuItem i_Parent, IClickListener i_ClickListener)
            : base(i_Title, i_Parent.Level + 1, i_Parent)
        {
            r_ClickListener = i_ClickListener;
        }

        public IClickListener Listener
        {
            get { return r_ClickListener; }
        }
    }
}
