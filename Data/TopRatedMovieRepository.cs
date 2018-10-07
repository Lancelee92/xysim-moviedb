using xysim_moviedb.Models;

namespace xysim_moviedb.Data
{
    public class TopRatedMovieRepository
    {
        private static Movie[] _movies = new Movie[]
        {
            new Movie()
            {
                Id = 1,
                Name = "The Amazing Spider-Man",
                Overview = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives...<strong>will Peter Parker?</strong></p>",
                OriginalTitle = "",
                OriginalLanguage = "false",
                ReleaseDate = "",
                PosterPath = "",
                VoteCount = 0, 
                Popularity = (float)0.00,
                VoteAverage = (float)0.00
            },
            new Movie()
            {
                Id = 1,
                Name = "The Avengers",
                Overview = "<p>Spider-Man survives...<strong>will Peter Parker?</strong></p>",
                OriginalTitle = "",
                OriginalLanguage = "false",
                ReleaseDate = "",
                PosterPath = "",
                VoteCount = 0, 
                Popularity = (float)0.00,
                VoteAverage = (float)0.00
            },
            new Movie()
            {
                Id = 1,
                Name = "Inceptions",
                Overview = "<p>Cobbs survives...<strong>will John Parker?</strong></p>",
                OriginalTitle = "",
                OriginalLanguage = "false",
                ReleaseDate = "",
                PosterPath = "",
                VoteCount = 0, 
                Popularity = (float)0.00,
                VoteAverage = (float)0.00
            }
        };

        public Movie[] GetMovies()
        {
            return _movies;
        }
        public Movie GetMovie(int id)
        {
            Movie movieToReturn = null;

            foreach(var movie in _movies)
            {
                if(movie.Id == id)
                {
                    movieToReturn = movie;
                }        
            }

            return movieToReturn;
        }
    }
}