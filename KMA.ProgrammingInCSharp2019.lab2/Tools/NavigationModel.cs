using System;
using KMA.ProgrammingInCSharp2019.lab2.Views;

namespace KMA.ProgrammingInCSharp2019.lab2.Tools
{
    internal enum ModesEnum
    {
        Main,
        Info
    }
    internal class NavigationModel
    {
        private readonly IContentWindow _contentWindow;

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = new MainView();
                    break;
                case ModesEnum.Info:
                    _contentWindow.ContentControl.Content = new InfoView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
} 

