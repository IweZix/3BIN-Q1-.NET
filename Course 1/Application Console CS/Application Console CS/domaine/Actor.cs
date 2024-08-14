namespace Application_Console_CS.domaine;

[Serializable]
public class Actor : Person
{
    
    private static readonly long _serialVersionUID = 1L;
    private int _sizeInCentimeter;
    private IList<Movie> _movies;
    
    public Actor(string name, string firstname, DateTime birthDate, int sizeIntCentimeter)
        : base(name, firstname, birthDate)
    {
        _movies = new List<Movie>();
        _sizeInCentimeter = sizeIntCentimeter;
    }

    public int SizeInCentimeter => _sizeInCentimeter;

    public string Name => base.Name;

    public bool ContainsMovie(Movie movie) => _movies.Contains(movie);

    public bool AddMovie(Movie? movie)
    {
        if (movie == null || _movies.Contains(movie))
        {
            return false;
        }

        if (!movie.ContainsActor(this))
        {
            movie.AddActor(this);
        }

        _movies.Add(movie);

        return true;
    }
    
    public IEnumerator<Movie> GetEnumerator()
    {
        return _movies.GetEnumerator();
    }

    public override string ToString()
    {
        return "Actor [name = " + Name + ", firstname = " + Firstname + ", sizeInCentimeter = " + 
               SizeInCentimeter + ", birthdate = " + BirthDate + "]";
    }

    
}