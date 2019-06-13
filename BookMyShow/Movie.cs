using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShow
{
    /// <summary>
    /// 
    /// ==================================================================
    ///                             CREATED BY
    /// ------------------------------------------------------------------
    ///                             GAURAV BABBAR,
    ///                             JUNAID PATEL,
    ///                             PRIYANKA MONDAL,
    ///                             RUTAV KOTHARI.
    /// ==================================================================
    /// ==================================================================
    /// Description:
    ///     Class used in master binding for genre and movie.
    /// 
    /// </summary>
    public class Movie
    {
        private string name;

        public Movie()
        {
        }

        public Movie(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
    }

    public class Genre
    {
        private string name;
        private List<Movie> movies;

        public Genre()
        {
        }

        public Genre(string name, List<Movie> movies)
        {
            this.name = name;
            this.movies = movies;
        }

        public string Name { get => name; set => name = value; }
        public List<Movie> Movies { get => movies; set => movies = value; }
    }

    public class Group
    {
        private string name;
        private List<Genre> genres;

        public Group() { }

        public Group(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }
        public List<Genre> Genres { get => genres; set => genres = value; }
    }
}
