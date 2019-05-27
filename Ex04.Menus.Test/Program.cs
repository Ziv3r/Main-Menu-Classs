using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            // interfaces Part :
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu("Main Menu");
            DateAndTime dateAndTime = new DateAndTime();
            VersionAndDigitsTest versionAndDigits = new VersionAndDigitsTest();
            mainMenu.AddNewMenuItemUnder("Main Menu", "Show Date/Time");
            mainMenu.AddNewMenuItemUnder("Main Menu", "Version and Digits");

            mainMenu.AddNewOperationItemUnder("Show Date/Time", "Show Date", dateAndTime);
            mainMenu.AddNewOperationItemUnder("Show Date/Time", "Show Time", dateAndTime);

            mainMenu.AddNewOperationItemUnder("Version and Digits", "Count Digits", versionAndDigits);
            mainMenu.AddNewOperationItemUnder("Version and Digits", "Show Version", versionAndDigits);

            mainMenu.Show();

            Console.WriteLine("second part");
            Console.ReadLine();

            // delegate Part:
            Delegates.MainMenu mainMenuDelegates = new Delegates.MainMenu("Main Menu");
            DelegatesTest dateAndTimeDelegates = new DelegatesTest();
            VersionAndDigitsTest versionAndDigitsDelegates = new VersionAndDigitsTest();
            mainMenuDelegates.AddNewMenuItemUnder("Main Menu", "Show Date/Time");
            mainMenuDelegates.AddNewMenuItemUnder("Main Menu", "Version and Digits");

            mainMenuDelegates.AddNewOperationItemUnder("Show Date/Time", "Show Date", dateAndTimeDelegates.ShowDate);
            mainMenuDelegates.AddNewOperationItemUnder("Show Date/Time", "Show Time", dateAndTimeDelegates.ShowTime);

            mainMenuDelegates.AddNewOperationItemUnder("Version and Digits", "Count Digits", dateAndTimeDelegates.CountDigits);
            mainMenuDelegates.AddNewOperationItemUnder("Version and Digits", "Show Version", dateAndTimeDelegates.ShowVersion);

            mainMenuDelegates.Show();
        } 
    }
}
