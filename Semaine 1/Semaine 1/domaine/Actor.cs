namespace Semaine_1.domaine
{
    [Serializable]
    internal class Actor : Person
    {
        private static readonly long _serialVersionUID = 1L;
        private readonly int _sizeInCentimeter;
        private List<Movie> _movies;

        public Actor(string name, string firstname, DateTime birthDate, int sizeInCentimeter) 
            : base(name, firstname, birthDate)
        {
            _sizeInCentimeter = sizeInCentimeter;
            _movies = new List<Movie> ();
        }

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

        public bool ContainsMovie(Movie movie)
        {
            return _movies.Contains(movie);
        }

        public IEnumerator<Movie> MovieEnumerator()
        {
            return _movies.GetEnumerator();
        }

        public override string ToString()
        {
            return "Actor [name = " + Name + ", firstname = " + Firstname + ", sizeInCentimeter = " +
                   _sizeInCentimeter + ", birthdate = " + BirthDate + "]";
        }
    }
}
