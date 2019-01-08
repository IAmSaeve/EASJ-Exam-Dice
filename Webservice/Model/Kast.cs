using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webservice.Model
{
    public class Kast
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public int Antal { get; set; }
        public int Guess { get; set; }
        public int Result { get; set; }

        public Kast(int id, string navn, int antal, int guess, int result)
        {
            Id = id;
            Navn = navn;
            Antal = antal;
            Guess = guess;
            Result = result;
        }
    }
}
