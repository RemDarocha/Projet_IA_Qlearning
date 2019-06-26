using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    class Map
    {
        List<string> map = new List<string>();
        Player player = new Player();
        public void Start()
        {
            Initialisation();
        }
        public void Initialisation()
        {
            map.Add("xxxxxx");
            map.Add("x----x");
            map.Add("x----x");
            map.Add("x----x");
            map.Add("x----x");
            map.Add("x----x");
            map.Add("x----x");
            map.Add("xxxxxx");
        }

        public void Display()
        {
            Console.Clear();
            foreach (string line in map)
            {
                Console.WriteLine(line);
            }
        }

        public enum Movement
        {
            Right = 0,
            Up = 1,
            Left = 2,
            Down = 3
        }

        public Tuple<string, int> Move(Movement movement)
        {
            int x = player.position.x;
            int y = player.position.y;



        }

    }
}
