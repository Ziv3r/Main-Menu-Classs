using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public interface IEventListener
    {
        void onClick(string i_InvokerUniqueKey);
    }
    public class DateAndTime : IEventListener
    {
        public const string k_ShowTime = "Show Time";
        public const string k_ShowDate = "Show Date";
        public void onClick(string i_InvokerUniqueKey)
        {
            if(i_InvokerUniqueKey == k_ShowDate)
            {
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm"));
            }
        }
    }
}
