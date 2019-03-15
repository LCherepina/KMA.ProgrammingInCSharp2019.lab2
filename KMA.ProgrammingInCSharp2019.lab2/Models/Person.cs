

using System;

namespace KMA.ProgrammingInCSharp2019.lab2.Models
{
    class Person
    {
        #region Field

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDateTime = DateTime.Now;
        private string _wSign;
        private string _eSign;
        private bool _isBirthday;
        private bool _isAdult;

        #endregion
        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate
        {
            get { return _birthDateTime; }
            set { _birthDateTime = value; }
        }


        public string WSign
        {
            get { return _wSign; }
            set { _wSign = value; }
        }

        public string ESign
        {
            get { return _eSign; }
            set { _eSign = value; }
        }

        public Boolean IsAdult { get; set; }

        public Boolean IsBirthday { get; set; }


        #endregion
        #region Constructors

        internal Person(string name, string surname, string email, DateTime dateBirth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthDateTime = dateBirth;
        }

        internal Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        internal Person(string name, string surname, DateTime dateBirth)
        {
            _name = name;
            _surname = surname;
            _birthDateTime = dateBirth;
        }

        #endregion

    }
}
