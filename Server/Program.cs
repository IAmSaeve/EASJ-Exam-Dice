using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using TerningLibrary;

namespace Server
{
    class Program
    {
        private static TcpClient ConnectionSocket { get; set; }
        static void Main(string[] args)
        {
            // prepares the server to accept client on localhost at port 6789.
            var ip = IPAddress.Parse("127.0.0.1");
            var serverSocket = new TcpListener(ip, 6789);

            // Starts the server
            serverSocket.Start();
            Console.WriteLine("Server started\n");

            // Infinite loop to wait for clients and running the echo service.
            while (true)
            {
                Console.WriteLine("Waiting for a client to connect...");
                ConnectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Server activated\n");

                Task.Factory.StartNew(Run);
            }
        }

        public static string Guesser(int number, string brugernavn, int guess)
        {
            var t = new Terning();
            var result = t.result(number);
            return $"Bruger: {brugernavn}, Gaet: {guess}, Result: {result}";
        }

        public static void Run()
        {
            while (true)
            {
                // Detects a lost or closed connection and restarts the server.
                if (!ConnectionSocket.Connected)
                {
                    Console.WriteLine("No connection to client, restarting server.");
                    Thread.Sleep(2300);
                    Console.Clear();
                    break;
                }

                /*
                 * Sets variables for use later.
                 * Enforces message flushing with, (AutoFlush = true), needed to push messages instantly.
                 */
                Stream ns = new NetworkStream(ConnectionSocket.Client);
                var sr = new StreamReader(ns);
                var sw = new StreamWriter(ns) { AutoFlush = true };
                var message = sr.ReadLine();
                var answer = "";

                /*
                 * This method stops the server if an empty string is detected.
                 * This is done because a lost connection to a client usually sends empty strings.
                 * The second reason is prevent recourse waste since the server always expects a not null or empty
                 * string object to read and answer.
                 */
                if (message == string.Empty)
                {
                    Console.WriteLine("Empty string detected!");
                    Console.WriteLine(
                        "Either the client sent an empty string or the connection is lost.\nRestarting server");
                    Thread.Sleep(2300);
                    Console.Clear();
                    ns.Close();
                    ConnectionSocket.Close();
                    break;
                }

                while (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine("Client: " + message);

                    // Responds to client.
                    var num = int.Parse(message.Split(" ")[0]);
                    var name = message.Split(" ")[1];
                    var guess = int.Parse(message.Split(" ")[2]);
                    answer = Guesser(num, name, guess);
                    Console.WriteLine(answer);
                    sw.WriteLine(answer);
                    message = sr.ReadLine();
                }

                // Closes connection after client disconnect.
                ns.Close();
                ConnectionSocket.Close();
            }
        }
    }
}
