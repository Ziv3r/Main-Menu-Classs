using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class VersionAndDigitsTest : IClickListener
    {
        public const string k_CountDigits = "Count Digits";
        public const string k_TxtToShowWhenShowVersion = "2.4.2.19: Version";
        public void OnClick(string i_InvokerUniqueKey)
        {
            if(i_InvokerUniqueKey.Equals(k_CountDigits))
            {
                Console.WriteLine("Enter a sentence:");
                string str = Console.ReadLine();
                Console.WriteLine(countDigits(str));
            }
            else
            {
                Console.WriteLine(k_TxtToShowWhenShowVersion);
            }
        }

        private int countDigits(string i_Str)
        {
            int count = 0;
            foreach (char c in i_Str)
            {
                if(int.TryParse(c.ToString(), out int number))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
