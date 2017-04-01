namespace ConsoleWorld
{
    public class Player
    {
        private Inventory _inventory = new Inventory();

        public Inventory Inventory { get { return _inventory; } }

        public Location Location { get; set; }
        
    }
}