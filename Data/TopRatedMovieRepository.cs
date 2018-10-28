using xysim_moviedb.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System;

namespace xysim_moviedb.Data
{
    public class TopRatedMovieRepository
    {
        private static Movie[] _movies = new Movie[]
        {
            new Movie()
            {
                id = 1,
                title = "The Amazing Spider-Man",
                overview = "<p>Final issue! Witness the final hours of Doctor Octopus' life and his one, last, great act of revenge! Even if Spider-Man survives...<strong>will Peter Parker?</strong></p>",
            },
            new Movie()
            {
                id = 1,
                title = "The Avengers",
                overview = "<p>Spider-Man survives...<strong>will Peter Parker?</strong></p>",
            },
            new Movie()
            {
                id = 1,
                title = "Inceptions",
                overview = "<p>Cobbs survives...<strong>will John Parker?</strong></p>",
            }
        };

        public Movie[] GetMovies()
        {

            //GetData();

            return _movies;
        }
        public Movie GetMovie(int id)
        {
            Movie movieToReturn = null;

            foreach(var movie in _movies)
            {
                if(movie.id == id)
                {
                    movieToReturn = movie;
                }        
            }

            return movieToReturn;
        }
/* 
        static async void GetData()
        {
            string api_key = "5ae7fe637e5f6fd654a373598bc43785";
            string language = "en-US";
            string page = "1";
            string api_link = "https://api.themoviedb.org/3/movie/top_rated?api_key={0}&language={1}&page={2}";
            string req = string.Format(api_link, api_key, language, page);

            using (HttpClient client = new HttpClient()){
                using (HttpResponseMessage res = await client.GetAsync(req)){
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                        //Console.WriteLine(data);
                        //themoviedbResponse JsonRtn = JsonConvert.DeserializeObject<themoviedbResponse>(data);
                        themoviedbResponse deserializedUser = new themoviedbResponse();  
                        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));  
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());  
                        deserializedUser = ser.ReadObject(ms) as themoviedbResponse;  
                        ms.Close();  
                        }
                    }
                }

            }
        }
*/    
    }
}