using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class DateAndTime : IClickListener
    {
        public const string k_ShowTime = "Show Time";
        public const string k_ShowDate = "Show Date";

        public void OnClick(string i_InvokerUniqueKey)
        {
            if(i_InvokerUniqueKey == k_ShowDate)
            {
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm"));
            }

                Console.ReadLine();
        }
    }
}
