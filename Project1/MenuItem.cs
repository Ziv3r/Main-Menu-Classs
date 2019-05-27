using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private readonly int r_Level;
        private readonly string r_Title;
        private readonly MenuItem r_Parent;

        public MenuItem(string i_Title, int i_Level, MenuItem i_Parent)
        {
            r_Title = i_Title;
            r_Level = i_Level;
            r_Parent = i_Parent;
        }
        public string Title
        {
            get { return r_Title; }
        }

        public int Level
        {
            get { return r_Level; }
        }
        public MenuItem Parent
        {
            get { return r_Parent; }
        }
    }
}
