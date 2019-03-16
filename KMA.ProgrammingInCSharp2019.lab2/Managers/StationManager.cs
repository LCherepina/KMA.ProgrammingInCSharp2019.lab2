using System;
using System.Windows;
using KMA.ProgrammingInCSharp2019.lab2.Models;


namespace KMA.ProgrammingInCSharp2019.lab2.Managers
{
    public static class StationManager
    {
        public static Person CurrentPerson { get; set; }
        
        public static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
