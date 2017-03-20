using System.Collections.Generic;

namespace ConsoleWorld
{
    public class NPC
    {
        private Config.NPC _config;
        private Dictionary<string, Interaction> _interactions;

        public NPC(Config.NPC npcConfig)
        {
            _config = npcConfig;

            _interactions = new Dictionary<string, Interaction>();
            foreach (Config.Interaction interaction in _config.Interactions)
            {
                _interactions.Add(interaction.ItemName, new Interaction(interaction));
            }
        }

        public string Name { get { return _config.Name; } }

        public IReadOnlyDictionary<string, Interaction> Interactions { get { return _interactions; } }
    }
}