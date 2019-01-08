using System;

namespace TerningLibrary
{
    /// <summary>
    /// Generic dice class.
    /// </summary>
    public class Terning
    {
        private Random rnd { get; set; }

        /// <summary>
        /// Takes a number 1 or 2 which is the number of die.
        /// </summary>
        /// <param name="number">Either 1 or 2</param>
        /// <returns>Returns a random number multiplied by the input. Returns -1 if invalid input</returns>
        public int result(int number)
        {
            if (number == 1 || number == 2)
            {
                // TODO: Maybe make this return an int array instead.
                rnd = new Random();
                return rnd.Next(1, 6) * number;
            }

            return -1;
        }

    }
}
