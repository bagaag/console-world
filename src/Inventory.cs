using System.Collections.Generic;

namespace ConsoleWorld
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();

        public Inventory(List<Config.Item> configItems)
        {
            foreach (Config.Item ci in configItems) 
            {
                items.Add(new Item(ci));
            }
        }
        public Inventory(Config.Item configItem)
        {
            items.Add(new Item(configItem));
        }
        public Inventory(){ }

        public void Add(Item item) {
            items.Add(item);
        }

        public Item this[int ix]
        {
            get 
            {
                return items[ix];
            }
        }

        public int Count { get { return items.Count; } }

        public void Remove(int ix) 
        {
            items.RemoveAt(ix);
        }
        public void Remove (Item item) 
        {
            items.Remove(item);
        }
    }
}