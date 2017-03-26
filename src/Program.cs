using System;
using System.Collections.Generic;

namespace ConsoleWorld
{

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI ui = new ConsoleUI();
            ui.LoadGame("game-config.json");
            if (ui.Errors.Count == 0) {
                ui.Start();
            }
        }

    }

}
