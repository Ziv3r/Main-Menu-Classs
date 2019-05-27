using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menues.Interfaces
{
    public abstract class MenuItem
    {
        private int m_Level;
        private string m_Title;
        MenuItem m_Parent;

        public MenuItem(string i_Title,int i_Level,MenuItem i_Parent)
        {
            m_Title = i_Title;
            m_Level = i_Level;
            m_Parent = i_Parent;
        }
        public string Title
        {
            get { return m_Title; }
        }

        public int Level
        {
            get { return m_Level; }
        }
        public MenuItem Parent
        {
            get { return m_Parent; }
        }
    }
}
