namespace ConsoleWorld
{
    public class Inventory
    {
        private Config.Inventory _config;

        public Inventory(Config.Inventory inventory)
        {
            _config = inventory;
        }

        public string Name { get { return _config.Name; } }
        public string Description { get { return _config.Description; } }
    }
}