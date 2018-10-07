namespace xysim_moviedb.Models
{
    public class themoviedbResponse
    {
        public int page { get; set; }
        public int total_results  { get; set; }
        public int total_pages  { get; set; }
        public Movie[] results  { get; set; } 
    }
}