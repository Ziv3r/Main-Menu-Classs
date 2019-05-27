using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    internal class LeafItem : MenuItem
    {
        public event Action<string> OnClick;

        public LeafItem(string i_Title, MenuItem i_Parent, Action<string> i_ToInvoke)
            : base(i_Title, i_Parent.Level + 1, i_Parent)
        {
            OnClick += i_ToInvoke;
        }

        public void Clicked()
        {
            if (OnClick != null)
            {
                OnClick.Invoke(Title);
            }
        }
    }
}
