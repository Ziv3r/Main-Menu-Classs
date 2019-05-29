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
            InterfaceTest.Date date = new InterfaceTest.Date();
            InterfaceTest.Time time = new InterfaceTest.Time();
            InterfaceTest.Version version = new InterfaceTest.Version();
            InterfaceTest.CountDigits countDigits = new InterfaceTest.CountDigits();
            int showDateAndTimeHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Show Date/Time");
            int showVersionAndDigitsHash = mainMenu.AddNewMenuItemUnder(mainMenu.RootHashCode, "Version and Digits");

            mainMenu.AddNewOperationItemUnder(showDateAndTimeHash, "Show Date", date);
            mainMenu.AddNewOperationItemUnder(showDateAndTimeHash, "Show Time", time);

            mainMenu.AddNewOperationItemUnder(showVersionAndDigitsHash, "Count Digits", countDigits);
            mainMenu.AddNewOperationItemUnder(showVersionAndDigitsHash, "Show Version", version);

            mainMenu.Show();

            Console.WriteLine("second part");
            Console.ReadLine();

            // delegate Part:
            Delegates.MainMenu mainMenuDelegates = new Delegates.MainMenu("Main Menu");
            DelegatesTest dateAndTimeDelegates = new DelegatesTest();
            int showDateTimeHashCode = mainMenuDelegates.AddNewMenuItemUnder(mainMenuDelegates.RootHashCode, "Show Date/Time");
            int showVersionAndDigits = mainMenuDelegates.AddNewMenuItemUnder(mainMenuDelegates.RootHashCode, "Version and Digits");

            mainMenuDelegates.AddNewOperationItemUnder(showDateTimeHashCode, "Show Date", dateAndTimeDelegates.ShowDate);
            mainMenuDelegates.AddNewOperationItemUnder(showDateTimeHashCode, "Show Time", dateAndTimeDelegates.ShowTime);

            mainMenuDelegates.AddNewOperationItemUnder(showVersionAndDigits, "Count Digits", dateAndTimeDelegates.CountDigits);
            mainMenuDelegates.AddNewOperationItemUnder(showVersionAndDigits, "Show Version", dateAndTimeDelegates.ShowVersion);

            mainMenuDelegates.Show();
        } 
    }
}
