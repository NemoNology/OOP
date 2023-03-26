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
            get => _id;

            set
            {
                if (value < 0)
                    throw new ArgumentNullException(nameof(ID));

                _id = value;
            }
        }
        public string FirstName
        {
            get => _firstName;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(FirstName));

                _firstName = value;
            }
        }
        public string SecondName
        {
            get => _secondName;

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(SecondName));

                _secondName = value;
            }
        }
        public short Age
        {
            get => _age;

            set
            {
                if (value < 0)
                    throw new ArgumentNullException(nameof(Age));

                _age = value;
            }
        }
        public bool Sex { get; set; }

        public Professor(int iD, string firstName,
            string secondName, short age,
            bool sex)
        {
            ID = iD;
            FirstName = firstName;
            SecondName = secondName;
            Age = age;
            Sex = sex;
        }
    }
}
