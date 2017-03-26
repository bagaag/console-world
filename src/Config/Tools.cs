using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleWorld.Config
{

    public class ValidationException: Exception 
    {
        public ValidationException(string msg) : base(msg){}
    }

    /// <summary>
    /// Performs validation on config input
    /// </summary>
    public class Tools
    {
        /// <summary>
        /// Validates a game and associated data structure, throws Exception on validation error
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public static List<string> ValidateGame(Game game)
        {
            //TODO: migrate json attribute validation to ValidateGame so that errors can be reported together
            List<string> errors = new List<string>();

            // validate Spawn
            if (game.Locations.Find(loc => loc.Name == game.Spawn) == null)
            {
                errors.Add($"Spawn location of {game.Spawn} does not exist");
            }

            // validate Locations
            foreach (Location location in game.Locations) 
            {
                foreach (Direction direction in location.Directions) 
                {
                    if (direction.Location != null)
                    {
                        Location dirloc = game.Locations.Find(loc => loc.Name == direction.Location);
                        if (dirloc == null) 
                        {
                            errors.Add($"Referenced location '{direction.Location}' does not resolve");
                        }
                    }
                }
            }
            return errors;
        }

        /// <summary>
        /// Creates a Config.Game structure from a JSON game configuration file.
        /// </summary>
        /// <param name="file">Name of file to parse</param>
        /// <returns></returns>
        public static Game DeserializeGame(string file)
        {
            if (!FileExists(file)) throw new Exception($"File {file} not found");

            Game gameconf;
            string json = File.ReadAllText(file);
            gameconf = JsonConvert.DeserializeObject<Game>(json);

            ValidateGame(gameconf);
            return gameconf;
        }        

        public static bool FileExists(string file) {
            return System.IO.File.Exists(file);
        }
    }
}