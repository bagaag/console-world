namespace ConsoleWorld
{
    public class Direction
    {
        private Config.Direction _config;
        public Direction(Config.Direction config)
        {
            _config = config;
        }
        public string Key
        {
            get
            {
                return _config.Key;
            }
        }
        public string Location { get { return _config.Location; } }
        public string Description { get { return _config.Description; } }
    }
}