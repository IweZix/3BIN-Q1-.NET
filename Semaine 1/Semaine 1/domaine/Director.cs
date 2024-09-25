using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_1.domaine
{
    internal class Director : Person
    {
        private static readonly long _serialVersionUID = 5952964360274024205L;
        private IList<Movie> _directedMovies;

        public Director(string name, string firstname, DateTime birtDate)
            : base(name, firstname, birtDate)
        {
            _directedMovies = new List<Movie>();
        }

        public bool AddMovie(Movie movie)
        {
            if (_directedMovies.Contains(movie))
            {
                return false;
            }

            movie.Director ??= this;

            _directedMovies.Add((movie));

            return true;
        }

        public IEnumerator<Movie> Movies()
        {
            return _directedMovies.GetEnumerator();
        }
    }
}
