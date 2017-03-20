using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Console World");
            var config = DeserializeGame("game-config.json");
            Game game = new Game(config);
            var ui = new ConsoleUI(game);
            ui.Start();

        }

        /// <summary>
        /// Creates a Config.Game structure from a JSON game configuration file.
        /// </summary>
        /// <param name="file">Name of file to parse</param>
        /// <returns></returns>
        static Config.Game DeserializeGame(string file)
        {
            string json = File.ReadAllText(file);
            var gameconf = JsonConvert.DeserializeObject<Config.Game>(json);
            return gameconf;
        }
    }

}
