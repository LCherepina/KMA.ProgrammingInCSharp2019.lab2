

using KMA.ProgrammingInCSharp2019.lab2.ViewModels;

namespace KMA.ProgrammingInCSharp2019.lab2.Views
{
    /// <summary>
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView 
    {
        public InfoView()
        {

            InitializeComponent();
            var infoViewModel = new InfoViewModel();
            DataContext = infoViewModel;
        }
    }
}
