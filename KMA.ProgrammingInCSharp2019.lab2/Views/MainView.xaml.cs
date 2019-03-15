using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KMA.ProgrammingInCSharp2019.lab2.ViewModels;

namespace KMA.ProgrammingInCSharp2019.lab2
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
