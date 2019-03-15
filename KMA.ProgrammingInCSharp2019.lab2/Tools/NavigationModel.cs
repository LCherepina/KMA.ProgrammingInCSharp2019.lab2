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

    private MainView _mainView;
    private InfoView _infoView;

    

        internal NavigationModel(IContentWindow contentWindow)
    {
        _contentWindow = contentWindow;
    }

    internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                //  _contentWindow.ContentControl.Content = (_mainView = new MainView());
                case ModesEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    break;
                case ModesEnum.Info:
                    _contentWindow.ContentControl.Content = _infoView ?? (_infoView = new InfoView());
                    //_contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
}
} 

