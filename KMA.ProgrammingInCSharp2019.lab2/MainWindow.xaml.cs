using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.lab2.Managers;
using KMA.ProgrammingInCSharp2019.lab2.Tools;
using KMA.ProgrammingInCSharp2019.lab2.ViewModels;

namespace KMA.ProgrammingInCSharp2019.lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();

        }


        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
