﻿using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.lab2.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
