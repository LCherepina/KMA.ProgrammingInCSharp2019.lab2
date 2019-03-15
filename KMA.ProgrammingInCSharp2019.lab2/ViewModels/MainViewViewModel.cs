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
        private int _age;
       

        private readonly string[] _westSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        #region Commands
        private ICommand _calculateCommand;
        #endregion

        #endregion

        #region Properties

        private Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get { return _person.BirthDate; }

            set
            {
                _person.BirthDate = value;
                
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value; 
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _person.Surname;
            }
            set
            {
                _person.Surname = value; 
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _person.Email;}
            set
            {
                _person.Email = value;
                OnPropertyChanged();
            }
        }

        private string WAstrology
        {
            get { return _person.WSign; }
            set
            {
                _person.WSign = value; 
            }
        }

        private string ChAstrology
        {
            get { return _person.ESign; }
            set
            {
                _person.ESign = value;
                OnPropertyChanged();
            }
        }

        private bool IsAdult
        {
            get { return _person.IsAdult; }
            set { _person.IsAdult = value; }
        }

        private bool IsBirthday
        {
            get { return _person.IsBirthday; }
            set { _person.IsBirthday = value; }
        }
        private int Age
        {
            get
            {
                return _age;
            }
            set { _age = value; }
        }



        #region Commands
        public ICommand CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<KeyEventArgs>(Calculate));
            }
        }
        #endregion
       
        #endregion

        public MainViewViewModel()
        {
            _person = new Person("","","",DateTime.Now);
        }

        private string Info()
        {
            return  "First Name: "+FirstName+
                   "\nLast Name: "+LastName+
                   "\nEmail: "+Email+
                   "\nBirth Date: "+BirthDate+
                   "\nWest Astrology: "+WAstrology+
                   "\nEast Astrology: "+ChAstrology+
                   "\nIs Birthday: "+IsBirthday+
                   "\nIs Adult: " + IsAdult;
        }

        private void ShowInfo()
        {
            MessageBox.Show(Info(),"Info", MessageBoxButton.OK);
        }

        private void CalculateAge()
        {
            if (BirthDate.Day == DateTime.Now.Day && BirthDate.Month == DateTime.Now.Month && (BirthDate >= DateTime.Today.AddYears(-135) || BirthDate >= DateTime.Now))
            {
                _person.IsBirthday=true;
                MessageBox.Show("!!!!!!!!Happy Birthday!!!!!!!!!", "Greeting!", MessageBoxButton.OK);
            }
            if (BirthDate < DateTime.Today.AddYears(-135) || BirthDate > DateTime.Now)
            {

                MessageBox.Show("Invalid date birth!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                BirthDate = DateTime.Now;
            }

            if (BirthDate.Month > DateTime.Now.Month ||
                (BirthDate.Month == DateTime.Now.Month && BirthDate.Day > DateTime.Now.Day))
            {
                Age = DateTime.Now.Year - BirthDate.Year - 1;

            }
            else if (BirthDate.Month < DateTime.Now.Month ||
                     (BirthDate.Month == DateTime.Now.Month && BirthDate.Day <= DateTime.Now.Day))
            {
                Age = DateTime.Now.Year - BirthDate.Year;

            }

            if (Age >= 18)
            {
                IsAdult = true;
            }


        }

        private void CalculateWestSign()
        {
            switch (BirthDate.Month)
            {
                case 1:
                    WAstrology = BirthDate.Day >= 20 ? _westSigns[1] : _westSigns[0];
                    break;
                case 2:
                    WAstrology = BirthDate.Day >= 19 ? _westSigns[2] : _westSigns[1];
                    break;
                case 3:
                    WAstrology = BirthDate.Day >= 21 ? _westSigns[3] : _westSigns[2];
                    break;
                case 4:
                    WAstrology = BirthDate.Day >= 20 ? _westSigns[4] : _westSigns[3];
                    break;
                case 5:
                    WAstrology = BirthDate.Day >= 21 ? _westSigns[5] : _westSigns[4];
                    break;
                case 6:
                    WAstrology = BirthDate.Day >= 21 ? _westSigns[6] : _westSigns[5];
                    break;
                case 7:
                    WAstrology = BirthDate.Day >= 23 ? _westSigns[7] : _westSigns[6];
                    break;
                case 8:
                    WAstrology = BirthDate.Day >= 23 ? _westSigns[8] : _westSigns[7];
                    break;
                case 9:
                    WAstrology = BirthDate.Day >= 23 ? _westSigns[9] : _westSigns[8];
                    break;
                case 10:
                    WAstrology = BirthDate.Day >= 23 ? _westSigns[10] : _westSigns[9];
                    break;
                case 11:
                    WAstrology = BirthDate.Day >= 22 ? _westSigns[11] : _westSigns[10];
                    break;
                case 12:
                    WAstrology = BirthDate.Day >= 22 ? _westSigns[0] : _westSigns[11];
                    break;

            }


        }

        private void CalculateChineseSign()
        {
            switch ((BirthDate.Year - 4) % 12)
            {
                case 0:
                    ChAstrology = _chineseSigns[0];
                    break;
                case 1:
                    ChAstrology = _chineseSigns[1];
                    break;
                case 2:
                    ChAstrology = _chineseSigns[2];
                    break;
                case 3:
                    ChAstrology = _chineseSigns[3];
                    break;
                case 4:
                    ChAstrology = _chineseSigns[4];
                    break;
                case 5:
                    ChAstrology = _chineseSigns[5];
                    break;
                case 6:
                    ChAstrology = _chineseSigns[6];
                    break;
                case 7:
                    ChAstrology = _chineseSigns[7];
                    break;
                case 8:
                    ChAstrology = _chineseSigns[8];
                    break;
                case 9:
                    ChAstrology = _chineseSigns[9];
                    break;
                case 10:
                    ChAstrology = _chineseSigns[10];
                    break;
                case 11:
                    ChAstrology = _chineseSigns[11];
                    break;
                case 12:
                    ChAstrology = _chineseSigns[12];
                    break;
            }
        }

        private async void Calculate(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                CalculateAge();
                CalculateWestSign();
                CalculateChineseSign();
                
                ShowInfo();
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
                NavigationManager.Instance.Navigate(ModesEnum.Info);
        }

        private void CanCalculate(object obj)
        {
         /*   return !String.IsNullOrEmpty(FirstName) &&
                   !String.IsNullOrEmpty(LastName) &&
                   !String.IsNullOrEmpty(Email);
        */    
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
