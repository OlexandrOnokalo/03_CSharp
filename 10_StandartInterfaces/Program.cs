using System.Collections;

namespace _10_StandartInterfaces
{
    public enum Genre
    {
        Comedy,
        Horror,
        Adventure,
        Drama,
        SciFi,
        Action
    }

    public class Director : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Director(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public object Clone()
        {
            return new Director(FirstName, LastName);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class Movie : IComparable<Movie>, ICloneable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Director Director { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public int Year { get; set; }
        public short Rating { get; set; }

        public Movie(string title, string description, Director director, string country, Genre genre, int year, short rating)
        {
            Title = title;
            Description = description;
            Director = director;
            Country = country;
            Genre = genre;
            Year = year;
            Rating = rating;
        }

        public int CompareTo(Movie? other)
        {
            if (other == null) return 1;
            return Title.CompareTo(other.Title);
        }

        public object Clone()
        {
            return new Movie(Title, Description, (Director)Director.Clone(), Country, Genre, Year, Rating);
        }

        public override string ToString()
        {
            return $"{Title} ({Year}), {Genre}, Rating: {Rating}/10, Directed by {Director}";
        }
    }

    public class CompareByRating : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x!.Rating.CompareTo(y!.Rating);
        }
    }

    public class CompareByYear : IComparer<Movie>
    {
        public int Compare(Movie? x, Movie? y)
        {
            return x!.Year.CompareTo(y!.Year);
        }
    }

    public class Cinema : IEnumerable<Movie>   
    {
        private Movie[] movies;
        public string Address { get; set; }

        public Cinema(string address, Movie[] movies)
        {
            Address = address;
            this.movies = movies;
        }

        public void Sort()
        {
            Array.Sort(movies);
        }

        public void Sort(IComparer<Movie> comparer)
        {
            Array.Sort(movies, comparer);
        }

        public IEnumerator<Movie> GetEnumerator()
        {
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string result = $"Cinema at {Address}:\n";
            foreach (var movie in movies)
            {
                result += movie + "\n";
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dir1 = new Director("Christopher", "Nolan");
            var dir2 = new Director("James", "Cameron");
            var dir3 = new Director("Steven", "Spielberg");

            var movies = new Movie[]
            {
                new Movie("Inception", "Dream world heist", dir1, "USA", Genre.SciFi, 2010, 9),
                new Movie("Avatar", "Alien world and humans", dir2, "USA", Genre.Adventure, 2009, 8),
                new Movie("E.T.", "Alien befriends kid", dir3, "USA", Genre.Drama, 1982, 7),
                new Movie("Interstellar", "Space and time", dir1, "USA", Genre.SciFi, 2014, 10),
            };

            var cinema = new Cinema("123 Main St", movies);

            Console.WriteLine("Original:");
            Console.WriteLine(cinema);

            Console.WriteLine("Sorted by Title (Default):");
            cinema.Sort();
            Console.WriteLine(cinema);

            Console.WriteLine("Sorted by Rating:");
            cinema.Sort(new CompareByRating());
            Console.WriteLine(cinema);

            Console.WriteLine("Sorted by Year:");
            cinema.Sort(new CompareByYear());
            Console.WriteLine(cinema);
        }
    }
}
