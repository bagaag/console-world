using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConsoleWorld.Config
{

    public class Interaction
    {
        [JsonProperty(Required = Required.Always)]
        public string ItemName { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
    }

    public class NPC
    {
        public NPC()
        {
            Interactions = new List<Interaction>();
        }
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        public List<Interaction> Interactions { get; set; }
    }

    public class Item
    {
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
    }

    public class Direction
    {
        [JsonProperty(Required = Required.Always)]
        public string Key { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
        public string Location { get; set; }
    }

    public class Location
    {
        public Location()
        {
            Directions = new List<Direction>();
            Inventory = new List<Item>();
            NPCs = new List<NPC>();
        }
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Description { get; set; }
        public List<Direction> Directions { get; set; }
        public List<Item> Inventory { get; set; }
        public List<NPC> NPCs { get; set; }

    }

    public class Game
    {
        public Game()
        {
            Locations = new List<Location>();
        }
        public string[] Help { get; set; }
        public List<Location> Locations { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Spawn { get; set; } //TODO: Validate Spawn required and exists post-deserialization

    }

}