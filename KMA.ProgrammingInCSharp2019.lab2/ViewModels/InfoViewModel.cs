using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using KMA.ProgrammingInCSharp2019.lab2.Annotations;
using KMA.ProgrammingInCSharp2019.lab2.Managers;
using KMA.ProgrammingInCSharp2019.lab2.Models;
using KMA.ProgrammingInCSharp2019.lab2.Tools;

namespace KMA.ProgrammingInCSharp2019.lab2.ViewModels
{
    class InfoViewModel:INotifyPropertyChanged
    {

        private Person  _person;
        #region Fields

        #region Commands
        private ICommand _backCommand;
        #endregion
        #endregion
        
        #region Commands
        public ICommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<KeyEventArgs>(BackExecute));
            }
        }
        #endregion

        public InfoViewModel()
        {
            _person = StationManager.CurrentPerson;
        }

        private async void BackExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                StationManager.CurrentPerson = null;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ModesEnum.Main);
        }

        public string FirstName
        {
            get { return _person.Name; }
        }

        public string LastName
        {
            get { return _person.Surname; }
        }

        public string Email
        {
            get { return _person.Email; }
        }

        public string BirthDate
        {
            get { return _person.BirthDate.ToShortDateString(); }
        }
        public bool IsBirthday
        {
            get { return _person.IsBirthday; }
        }
        public bool IsAdult
        {
            get { return _person.IsAdult; }
            
        }

        public string ESign
        {
            get { return _person.ChineseSign; }
        }
        public string WSign
        {
            get { return _person.SunSign; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
