using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestConsumer.Model;

namespace RestConsumer
{
    class Program
    {
        // Azure or localhost
        // private static readonly string Uri = "";
        private static readonly string Uri = "http://localhost:5000/api/Kast/";

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Vælg en handling, 1: Hent alle, 2: Hent for en person, 3: Lav en ny, 4: Exit");
            var handling = Console.ReadLine();

            if (handling == "1")
            {
                Console.Clear();
                // Get list of Kast
                foreach (var kast in GetKastAsync().Result)
                {
                    Console.WriteLine(kast);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[] { });
            }
            else if (handling == "2")
            {
                Console.Clear();
                System.Console.WriteLine("Indtast et navn");

                var navn = Console.ReadLine();
                foreach (var kast in GetAKastAsync(navn).Result)
                {
                    Console.WriteLine(kast);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[] { });
            }
            else if (handling == "3")
            {
                var terning = new TerningLibrary.Terning();
                Console.Clear();
                System.Console.WriteLine("Indtast dit navn");
                var name = Console.ReadLine();

                System.Console.WriteLine("Indtast antal terninger");
                var count = Console.ReadLine();

                System.Console.WriteLine("Indtast dit gaet");
                var guess = Console.ReadLine();

                var result = terning.result(int.Parse(count));
                System.Console.WriteLine("Du rullede: " + result);

                // TODO: Use library to generate result data!
                PostKastAsync(new Kast(name, int.Parse(count), int.Parse(guess), result));

                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Main(new string[] { });
            }
            else if (handling == "4")
            {
                Environment.Exit(1);
            }
        }

        public static async Task<IList<Kast>> GetKastAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(Uri);
                IList<Kast> KastList = JsonConvert.DeserializeObject<IList<Kast>>(content);
                return KastList;
            }
        }

        public static async Task<IList<Kast>> GetAKastAsync(string navn)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(Uri + "Navn/" + navn);
                IList<Kast> KastList = JsonConvert.DeserializeObject<IList<Kast>>(content);
                return KastList;
            }
        }

        public static void PostKastAsync(Kast Kast)
        {
            using (HttpClient client = new HttpClient())
            {
                var jsonString = JsonConvert.SerializeObject(Kast);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = client.PostAsync(Uri, content).Result;
                Console.WriteLine(response.StatusCode.ToString());
            }
        }
    }
}
