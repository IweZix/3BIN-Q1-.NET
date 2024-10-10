namespace Semaine_1.domaine
{
    internal class Person
    {
        public static readonly long serialVersionUID = 1L;

        private readonly string _name;
        private readonly string _firstname;
        private readonly DateTime _birthDate;

        public Person(string name, string firstname, DateTime birthDate)
        {
            _name = name;
            _firstname = firstname;
            _birthDate = birthDate;
        }

        public string Name
        {
            get => _name;
        }

        public string Firstname
        {
            get => _firstname;
        }

        public string BirthDate
        {
            get => _birthDate.ToString("dd-mm-yyyy");
        }

        public override string ToString()
        {
            return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate = " + BirthDate + "]";
        }
    }
}
