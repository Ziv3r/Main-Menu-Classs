using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceTest
    {
        public const string k_ShowTime = "Show Time";
        public const string k_ShowDate = "Show Date";

        public class Date : IClickListener
        {
            public void OnClick()
            {
                Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                Console.ReadLine();
            }
        }

        public class Time : IClickListener
        {
            public void OnClick()
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm"));
                Console.ReadLine();
            }
        }

        public class Version : IClickListener
        {
            public const string k_TxtToShowWhenShowVersion = "2.4.2.19: Version";

            public void OnClick()
            {
                Console.WriteLine(k_TxtToShowWhenShowVersion);
                Console.ReadLine();
            }
        }

        public class CountDigits : IClickListener
        {
            public void OnClick()
            {
                Console.WriteLine("Enter a sentence:");
                string str = Console.ReadLine();
                Console.WriteLine(countDigits(str));
                Console.ReadLine();
            }

            private int countDigits(string i_Str)
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
        }
    }
}
