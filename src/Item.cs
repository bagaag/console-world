namespace ConsoleWorld
{
    public class Item
    {
        private Config.Item _config;

        public Item(Config.Item item)
        {
            _config = item;
        }

        public string Name { get { return _config.Name; } }
        public string Description { get { return _config.Description; } }
    }
}