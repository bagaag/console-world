using System.Collections.Generic;

namespace ConsoleWorld
{
    public class Location
    {
        private Config.Location _config;
        private Dictionary<string, Direction> _directions;
        private Dictionary<string, Inventory> _inventory;
        private Dictionary<string, NPC> _npcs;

        public Location(Config.Location loc)
        {
            _config = loc;

            _directions = new Dictionary<string, Direction>();
            foreach (Config.Direction dir in _config.Directions)
            {
                _directions.Add(dir.Key, new Direction(dir));
            }

            _inventory = new Dictionary<string, Inventory>();
            foreach (Config.Inventory inv in _config.Inventory)
            {
                _inventory.Add(inv.Name, new Inventory(inv));
            }

            _npcs = new Dictionary<string, NPC>();
            foreach (Config.NPC npc in _config.NPCs)
            {
                _npcs.Add(npc.Name, new NPC(npc));
            }
        }

        public string Name { get { return _config.Name; } }
        public string Description { get { return _config.Description; } }

        public IReadOnlyDictionary<string, Direction> Directions { get { return _directions; } }

        public IReadOnlyDictionary<string, Inventory> Inventory { get { return _inventory; } }

        public IReadOnlyDictionary<string, NPC> NPCs { get { return _npcs; } }
    }
}
