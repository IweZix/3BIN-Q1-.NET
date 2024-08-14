namespace Application_Console_CS.domaine;

public class Person
{
    private static readonly long serialVersionUID = 1L;
    
    private readonly string _name;
    private readonly string _firstname;
    private readonly DateTime _birthDate;

    protected Person(string name, string firstname, DateTime birthDate)
    {
        _name = name;
        _firstname = firstname;
        _birthDate = birthDate;
    }

    public string Name => _name;
    
    protected string Firstname => _firstname;

    protected string BirthDate
    {
        get => _birthDate.ToString("dd-MM-yyyy");
    }

    public override string ToString()
    {
        return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate = " + BirthDate + "]";
    }
}