namespace ConsoleWorld
{
    public class Interaction
    {
        private Config.Interaction _config;

        public Interaction(Config.Interaction interactionConfig)
        {
            _config = interactionConfig;

        }

        public string ItemName { get { return _config.ItemName; } }

        public string Description { get { return _config.Description; } }
    }
}