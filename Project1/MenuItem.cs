using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public abstract class MenuItem
    {
        private const string k_Exit = "Exit";
        private const string k_Back = "Back";

        private int m_Level;
        private string m_Title;
        MenuItem m_Parent;
        private string m_BackOrExitItem;

        public MenuItem(string i_Title,int i_Level,MenuItem i_Parent)
        {
            m_Title = i_Title;
            m_Level = i_Level;
            m_Parent = i_Parent;
            m_BackOrExitItem = i_Level == 0 ? k_Exit : k_Back;
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

        public void ReturnBack()
        {
            if(m_Level == 0)
            {
                return;             //how to the loop !? 
            }
            else
            {
                
            }
        }
         //HandelChoice


    }
}
