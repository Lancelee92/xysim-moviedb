
namespace xysim_moviedb.Models
{
    public class Movie
    {
        public string title  { get; set;}
        public string overview   { get; set;}
        public string original_title   { get; set;}
        public string original_language   { get; set;}
        public string release_date   { get; set;}
        public string poster_path   { get; set;}
        public string backdrop_path   { get; set;}
        public int id   { get; set;}
        public int vote_count { get; set;}
        public float popularity { get; set;}
        public float vote_average  { get; set;}
    }
}