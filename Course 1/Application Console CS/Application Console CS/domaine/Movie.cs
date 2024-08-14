namespace Application_Console_CS.domaine;

public class Movie
{
    private string _title;
    private int _releaseYear;
    private readonly IList<Actor> _actors;
    private Director? _director;

    public Movie(string title, int releaseYear)
    {
        _actors = new List<Actor>();
        _title = title;
        _releaseYear = releaseYear;
    }

    public Director? Director
    {
        get => _director;
        set
        {
            if (value == null)
            {
                return;
            }

            _director = value;
            _director.AddMovie(this);
        }
    }

    public string Title
    {
        get => _title;
        set => _title = value;
    }
    
    public int ReleaseYear
    {
        get => _releaseYear;
        set => _releaseYear = value;
    }

    public bool AddActor(Actor actor)
    {
        if (_actors.Contains(actor))
        {
            return false;
        }
        
        _actors.Add(actor);
        if (!actor.ContainsMovie(this))
        {
            actor.AddMovie(this);
        }

        return true;
    }

    public bool ContainsActor(Actor actor)
    {
        return _actors.Contains(actor);
    }

    public override string ToString()
    {
        return "Movie [title=" + _title + ", releaseYear=" + _releaseYear + "]";
    }
}