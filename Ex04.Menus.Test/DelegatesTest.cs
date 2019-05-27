﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class DelegatesTest
    {
        public const string k_TxtToShowWhenShowVersion = "2.4.2.19: Version";

        public void ShowDate(string i_InvokerUniqueKey)
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            Console.ReadLine();
        }

        public void ShowTime(string i_InvokerUniqueKey)
        {
            Console.WriteLine(DateTime.Now.ToString("HH:mm"));
            Console.ReadLine();
        }

        public void CountDigits(string i_Clicked)
        {
            Console.WriteLine("Enter a sentence:");
            string str = Console.ReadLine();
            Console.WriteLine(countDigitsHelper(str));
            Console.ReadLine();
        }

        private int countDigitsHelper(string i_Str)
        {
            int count = 0;
            foreach (char c in i_Str)
            {
                if (int.TryParse(c.ToString(), out int number))
                {
                    count++;
                }
            }

            return count;
        }

        public void ShowVersion(string i_Clicked)
        {
            Console.WriteLine(k_TxtToShowWhenShowVersion);
            Console.ReadLine();
        }
    }
}