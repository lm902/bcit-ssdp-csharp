using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            while (listener.IsListening)
            {
                var context = listener.GetContext();
                _ = HandleRequestAsync(context);
            }
        }

        static async Task HandleRequestAsync(HttpListenerContext context)
        {
            try
            {
                if (context.Request.RawUrl == "/favicon.ico")
                {
                    context.Response.StatusCode = 204;
                    context.Response.Close();
                    return;
                }
                var writer = new StreamWriter(context.Response.OutputStream);
                writer.Write("<html><head><title>Planets</title><meta charset=\"utf-8\" /></head><body><table>");
                writer.Write("<thead><tr><td>Name</td><td>Films</td></tr></thead>");
                writer.Write("<tbody>");
                foreach (var planet in await GetPlanetsAsync())
                {
                    writer.Write($"<tr><td>{planet.name}</td><td><ul>");
                    if (planet.films.Length == 0)
                    {
                        writer.Write("No film");
                    }
                    foreach (var filmUrl in planet.films)
                    {
                        var film = await DownloadJsonAsync<Film>(filmUrl);
                        writer.Write($"<li>{film.title}</li>");
                    }
                    writer.Write("</ul></tr>");
                }
                writer.Write("</tbody></table>");
                writer.Write("</body></html>");
                writer.Close();
                context.Response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured. Could not get planets:\n" + e.Message);
            }
        }

        static async Task<T> DownloadJsonAsync<T>(string uri)
        {
            Console.WriteLine("Download: " + uri);
            var t = await new WebClient().DownloadStringTaskAsync(uri);
            return JsonConvert.DeserializeObject<T>(t);
        }

        static async Task<List<Result>> GetPlanetsAsync(int page = 1)
        {
            string baseUrl = "https://swapi.co/api/";
            string planets = "planets/";
            var planetsObject = await DownloadJsonAsync<Planets>(baseUrl + planets + "?page=" + page);
            var results = new List<Result>();
            results.AddRange(planetsObject.results);
            if (planetsObject.next != null)
            {
                results.AddRange(await GetPlanetsAsync(page + 1));
            }
            return results;
        }

        struct Planets
        {
            public Result[] results;
            public string next;
            public string previous;
        }

        struct Result
        {
            public string name;
            public string[] films;
        }

        struct Film
        {
            public string title;
        }
    }
}
