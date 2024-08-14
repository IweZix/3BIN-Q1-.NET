namespace Application_Console_CS.domaine;

public class PersonList
{
    private static PersonList? _instance;
    private readonly IDictionary<string, Person> _persons;

    private PersonList()
    {
        _persons = new Dictionary<string, Person>();
    }

    public static PersonList GetInstance()
    {
        _instance ??= new PersonList();

        return _instance;
    }

    public void AddPerson(Person person)
    {
        if (person.Name == null)
        {
            throw new ArgumentException("Person can't be null");
        }
        
        _persons.Add(person.Name, person);
    }
    
    public IEnumerator<Person> PersonEnumerator()
    {
        return _persons.Values.GetEnumerator();
    }
}