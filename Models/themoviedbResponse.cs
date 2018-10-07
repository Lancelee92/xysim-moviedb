namespace xysim_moviedb.Models
{
    public class themoviedbResponse
    {
        public int page { get; set; }
        public int totalResult  { get; set; }
        public int totalPages  { get; set; }
        public Movie[] movies  { get; set; } 
    }
}