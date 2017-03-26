using System;
using System.Collections.Generic;
//TODO: Setup SCC for backup
namespace ConsoleWorld
{
    public class ConsoleUI
    {
        private Config.Game gameConfig;
        private Game game;
        private delegate void WriteLine(string msg);
        private WriteLine WL = Console.WriteLine;
        private WriteLine W = Console.Write;
        private enum State : int { ReadLoop, Exit, North, South, East, West, Above, Below };
        private int state;
        private char lastChar;
        private Dictionary<string,string> directionLabels;
        public List<string> Errors { get; private set; }

        //TODO: Refactor into player class
        private Location location;

        public ConsoleUI()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Loads game from config file and returns validation errors
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public void LoadGame(string configFile) 
        {
            try {
                // parse config
                gameConfig = ConsoleWorld.Config.Tools.DeserializeGame(configFile);
            }
            catch (Exception e) 
            {
                Errors.Add(e.Message);
            }            
            // validate config
            Errors.AddRange(ConsoleWorld.Config.Tools.ValidateGame(gameConfig));
            Errors.ForEach(s => WL(s));
        }

        private void Init() {
            // create game
            Game game = new Game(gameConfig);
            this.game = game;
            location = game.Spawn;
            state = (int)State.ReadLoop;
            directionLabels = new Dictionary<string, string>(){
                {"N", "North"}, {"S", "South"}, {"E", "East"}, {"W", "West"}, {"A", "Above"}, {"B", "Below"}
            };            
        }

        public void Start()
        {
            if (Errors.Count>0) { WL("Errors need to be resolved"); return; }
            Init();
            WL("Welcome to Console World");//TODO: Move string to config
            WL(location.Description);
            Loop();
        }

        private void Loop()
        {
            while (state != (int)State.Exit)
            {
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '?':
                        Help();
                        break;
                    case 'x':
                        Exit();
                        break;
                    case 'n':
                    case 's':
                    case 'e':
                    case 'w':
                    case 'a':
                    case 'b':
                        Look(key.KeyChar.ToString().ToUpper());
                        break;
                }
                lastChar = key.KeyChar;
            }
        }

        private void Help()
        {
            WL(game.Help);
        }

        private void Exit()
        {
            WL("Goodbye."); //TODO: Move string to game config
            state = (int)State.Exit;
        }

        private void Look(string input)
        {
            Direction dir = location.Directions[input];
            if (dir == null) 
            {
                WL(directionLabels[input] + ": Nothing to see here."); //TODO: Move string to game config
            }
            else if (lastChar == input.ToLower()[0]) 
            {
                // second press - go instead of Look
                Go(input, dir);
            }
            else 
            {
                WL(directionLabels[input] + ": " + dir.Description);
            }
        }

        private void Go(string input, Direction dir) {
            if (dir.Location==null)
            {
                WL(directionLabels[input] + ": You can't go that way."); //TODO: Move string to game config
            }
            else 
            {
                location = game.Locations[dir.Location]; //TODO: Validate direction-location mappings on startup
                WL("Going " + directionLabels[input] + "...");
                WL(location.Description); //TODO: Require descriptions on deserialization 
            }
        }
    }
}