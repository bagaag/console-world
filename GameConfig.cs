using System.Collections.Generic;

namespace ConsoleWorld.Config {

    public class Interaction {
        public string ItemName { get; set; }
        public string Description { get; set; }
    }

    public class NPC {
        public NPC() { 
            Interactions = new List<Interaction>(); 
        }
        public string Name { get; set; }
        public List<Interaction> Interactions { get; set; }
    }

    public class Inventory {
        public string Name { get; set; }
        public string Description  { get; set; }
    }

    public class Direction {
        public string Key { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }

    public class Location {
        public Location() {
            Directions = new List<Direction>();
            Inventory = new List<Inventory>();
            NPCs = new List<NPC>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Direction> Directions { get; set; }
        public List<Inventory> Inventory { get; set; }
        public List<NPC> NPCs { get; set; }

    }

    public class Game {
        public Game() {
            Locations = new List<Location>();
        }
        public string[] Help { get; set; }
        public List<Location> Locations { get; set; }
        public string Spawn { get; set; } //TODO: Validate Spawn required and exists post-deserialization

    }

}