using System;

// var Author = "NemoNology - Банковский А.С.";

namespace WPF
{
    class Professor
    {
        private int _id;
        private string _firstName;
        private string _secondName;
        private short _age;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException(nameof(ID));

                _id = value;
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(FirstName));

                _firstName = value;
            }
        }
        public string SecondName
        {
            get { return _secondName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(SecondName));

                _secondName = value;
            }
        }
        public short Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                    throw new ArgumentNullException(nameof(Age));

                _age = value;
            }
        }
        public bool Sex { get; set; }

        public Professor(int iD, string firstName,
            string secondtName, short age,
            bool sex)
        {
            ID = iD;
            FirstName = firstName;
            SecondName = secondtName;
            Age = age;
            Sex = sex;
        }
    }
}
