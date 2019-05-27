using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test
{
    public class Program
    {
        static public void Main()
        {
            IEventListener listener = new DateAndTime();
            listener.onClick("Show Date");
            listener.onClick("Show Time");

            IEventListener listener2 = new VersionAndDigitsTest();
            listener2.onClick("Count Digits");
            listener2.onClick("Show Version");


        }
    }
}
