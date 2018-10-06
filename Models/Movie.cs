
namespace xysim_moviedb.Models
{
    public class Movie
    {
        public string Name  { get; set;}
        public string Overview   { get; set;}
        public string OriginalTitle   { get; set;}
        public string OriginalLanguage   { get; set;}
        public string ReleaseDate   { get; set;}
        public string PosterPath   { get; set;}
        public string BackdropPath   { get; set;}
        public int Id   { get; set;}
        public int VoteCount { get; set;}
        public float Popularity { get; set;}
        public float VoteAverage  { get; set;}
    }
}