using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.ProgrammingInCSharp2019.lab2.Annotations;
using KMA.ProgrammingInCSharp2019.lab2.Managers;
using KMA.ProgrammingInCSharp2019.lab2.Models;
using KMA.ProgrammingInCSharp2019.lab2.Tools;

namespace KMA.ProgrammingInCSharp2019.lab2.ViewModels
{
    class MainViewViewModel:INotifyPropertyChanged
    {

        #region Fields

        private Person _person;

        private string _firstname;
        private string _lastname;
        private string _email;
        private DateTime _birthdate = DateTime.Now.Date;
       

   
        #region Commands
        private ICommand _calculateCommand;
        #endregion

        #endregion

        #region Properties


        public DateTime BirthDate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value; 
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value; 
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #region Commands
        public ICommand CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<KeyEventArgs>(Calculate, CanCalculate));
            }
        }
        #endregion
       
        #endregion

        private async void Calculate(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    _person = new Person(_firstname, _lastname, _email, _birthdate);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);

                    return false;
                }
                if(_person.IsBirthday)
                    MessageBox.Show("!!!!!!!!Happy Birthday!!!!!!!!!", "Greeting!", MessageBoxButton.OK);
                return true;
            });
            LoaderManager.Instance.HideLoader();
            StationManager.CurrentPerson = _person;
            _firstname = "";
            _lastname = "";
            _email = "";
            _birthdate = DateTime.Now.Date;
            OnPropertyChanged(FirstName);
            OnPropertyChanged(LastName);
            OnPropertyChanged(Email);
            OnPropertyChanged(nameof(BirthDate));
            if (result)
                NavigationManager.Instance.Navigate(ModesEnum.Info);
            
        }

        private bool CanCalculate(object obj)
        {
            return !String.IsNullOrEmpty(_firstname) &&
                   !String.IsNullOrEmpty(_lastname) &&
                   !String.IsNullOrEmpty(_email);
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
