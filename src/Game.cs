using System;
using System.Collections.Generic;

namespace ConsoleWorld
{
    public class Game
    {
        private Config.Game _config;
        private Dictionary<string, Location> _locations;
        public Game(Config.Game gameConfig)
        {
            _locations = new Dictionary<string, Location>();
            _config = gameConfig;
            foreach (ConsoleWorld.Config.Location loc in _config.Locations)
            {
                _locations.Add(loc.Name, new Location(loc));
            }
        }

        public IReadOnlyDictionary<string, Location> Locations { get { return _locations; } }

        public string Help { get { return String.Join(Environment.NewLine, _config.Help); } }

        public Location Spawn { get { return _locations[_config.Spawn]; } }
    }
}