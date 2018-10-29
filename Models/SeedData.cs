using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using xysim_moviedb.Models;

namespace xysim_moviedb
{
    public class SeedData
    {
        public async void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                /*
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                 */
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                themoviedbResponse data = await GetDataTaskAsync();

                foreach(Movie movie in data.results)
                {
                    Console.Write(movie.title);
                    if(context.Movie.Any(db => db.id == movie.id))
                    {
                        continue;
                    }
                    context.Movie.AddRange(movie);
                }

                // context.Movie.AddRange(
                //      new Movie
                //      {
                //          Title = "When Harry Met Sally",
                //          ReleaseDate = DateTime.Parse("1989-1-11"),
                //          Genre = "Romantic Comedy",
                //          Price = 7.99M
                //      },

                //      new Movie
                //      {
                //          Title = "Ghostbusters ",
                //          ReleaseDate = DateTime.Parse("1984-3-13"),
                //          Genre = "Comedy",
                //          Price = 8.99M
                //      },

                //      new Movie
                //      {
                //          Title = "Ghostbusters 2",
                //          ReleaseDate = DateTime.Parse("1986-2-23"),
                //          Genre = "Comedy",
                //          Price = 9.99M
                //      },

                //    new Movie
                //    {
                //        Title = "Rio Bravo",
                //        ReleaseDate = DateTime.Parse("1959-4-15"),
                //        Genre = "Western",
                //        Price = 3.99M
                //    }
                // );
                context.SaveChanges();
            }
        }

        static async Task<themoviedbResponse> GetDataTaskAsync()
        {
            string api_key = "5ae7fe637e5f6fd654a373598bc43785";
            string language = "en-MY";
            int page = 1;
            string api_link = "https://api.themoviedb.org/3/movie/top_rated?api_key={0}&language={1}&page={2}";
            string req = string.Format(api_link, api_key, language, page.ToString());
            string now_playing = "https://api.themoviedb.org/3/movie/now_playing?api_key={0}&language={1}&page={2}";
            themoviedbResponse themoviedb = new themoviedbResponse(); 

            Start:
            string reqnp = string.Format(now_playing, api_key, language, page.ToString());

            using (HttpClient client = new HttpClient()){  
                using (HttpResponseMessage res = await client.GetAsync(reqnp)){
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            //Console.WriteLine(data);
                            //themoviedbResponse JsonRtn = JsonConvert.DeserializeObject<themoviedbResponse>(data);
                            themoviedbResponse deserializedUser = new themoviedbResponse();  
                            
                            /* LOOP HERE UNTIL GET ALL DATA */
                            /* ADD ALL DATA AS ONE THEMOVIEDBRESPONSE */
                            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(data));  
                            DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedUser.GetType());  
                            deserializedUser = ser.ReadObject(ms) as themoviedbResponse;  
                            ms.Close();  
                                if(page == 1)
                                    themoviedb = deserializedUser;

                                if(page <= deserializedUser.total_pages && page != 1)
                                {
                                    themoviedb.page = deserializedUser.page;
                                    //themoviedb.total_pages = deserializedUser.total_pages;
                                    //themoviedb.total_results = deserializedUser.total_results;
                                    //deserializedUser.results.CopyTo(mdata, mdata.Length-1);
                                        // foreach(Movie movie in deserializedUser.results)
                                        // {
                                        //     Console.WriteLine(movie);
                                        //     themoviedb.results. 
                                        // }
                                        themoviedb.results = themoviedb.results.Concat(deserializedUser.results).ToArray();   
                                }

                                if(page == deserializedUser.total_pages)
                                    goto End;
                                else{
                                    page +=1; 
                                    goto Start;
                                } 
                        }
                    }
                }

            }
            End:
            return themoviedb;
        }
    }
}