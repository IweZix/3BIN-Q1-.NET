using Semaine_1.domaine;

namespace Application_Console_CS.client
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            Actor[] myActors = {
                new Actor( "Assange", "Julian", new DateTime(1961, 6, 3), 187),
                new Actor( "Paul", "Newmann", new DateTime(1925, 1, 26), 187),
                new Actor( "Becker", "Norma Jean", new DateTime(1926, 5, 1), 187)
            };

            Director[] myDirectors = {
                new Director("Spielberg", "Steven", new DateTime(1946, 11, 18)),
                new Director("Coen", "Ettan", new DateTime(1957, 8, 21)),
                new Director("Coppolla", "Francis Ford", new DateTime(1939, 3, 7))
            };

            Movie bigLebow = new Movie("The Big Lebowski", 1996);
            Movie eT = new Movie("E.T.", 1982);

            eT.AddActor(myActors[0]);
            eT.AddActor(myActors[2]);
            eT.Director = myDirectors[0];

            bigLebow.AddActor(myActors[1]);
            bigLebow.AddActor(myActors[2]);
            bigLebow.Director = myDirectors[1];

            PersonList myPersons = PersonList.GetInstance();

            foreach (var act in myActors)
            {
                myPersons.AddPerson(act);
            }

            foreach (var dir in myDirectors)
            {
                myPersons.AddPerson(dir);
            }

            IEnumerator<Person> actorIt = myPersons.PersonEnumerator();
            while (actorIt.MoveNext())
            {
                Person person = actorIt.Current;
                Console.WriteLine(person);

                IEnumerator<Movie> moviesIt;
                if (person is Actor)
                {
                    Console.WriteLine("  a joué dans les films suivants :");
                    moviesIt = ((Actor)person).MovieEnumerator();
                }
                else
                {
                    if (person is Director)
                    {
                        Console.WriteLine("  a dirigé les films suivants :");
                        moviesIt = ((Director)person).Movies();
                    }
                    else
                    {
                        Console.WriteLine("  est inconnu et n'a rien à faire ici !!!");
                        continue;
                    }
                }

                while (moviesIt.MoveNext())
                {
                    Movie movie = moviesIt.Current;
                    Console.WriteLine("    " + movie);
                }
            }
        }
    }
}
