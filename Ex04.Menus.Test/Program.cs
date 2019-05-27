using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            DateAndTime dateAndTime = new DateAndTime();
            VersionAndDigitsTest versionAndDigits = new VersionAndDigitsTest();
            MainMenu mainMenu = new MainMenu("Main Menu");
            mainMenu.AddNewMenuItemUnder("Main Menu", "Show Date/Time");
            mainMenu.AddNewMenuItemUnder("Main Menu", "Version and Digits");

            mainMenu.AddNewOperationItemUnder("Show Date/Time", "Show Date", dateAndTime);
            mainMenu.AddNewOperationItemUnder("Show Date/Time", "Show Time", dateAndTime);

            mainMenu.AddNewOperationItemUnder("Version and Digits", "Count Digits", versionAndDigits);
            mainMenu.AddNewOperationItemUnder("Version and Digits", "Show Version", versionAndDigits);

            mainMenu.Show();
        }
    }
}
