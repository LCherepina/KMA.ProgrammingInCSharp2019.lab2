using System.Windows;
using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.lab2.ViewModels;

namespace KMA.ProgrammingInCSharp2019.lab2.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainViewViewModel _mainViewViewModel;
        public MainView()
        {
            InitializeComponent();
            Initialize();

        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainViewViewModel = new MainViewViewModel();
            DataContext = _mainViewViewModel;
        }
    }
}
