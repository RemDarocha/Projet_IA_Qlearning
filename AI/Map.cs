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
            map.Add("x---Rx");
            map.Add("x-x--x");
            map.Add("x---xx");
            map.Add("xxx--x");
            map.Add("x----x");
            map.Add("x0---x");
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
            Tuple<string, int> ret = new Tuple();
            int x = player.position.x - 2;
            int y = player.position.y;

            
            switch (movement)
            {
                case Movement.Right:
                    player.position.x++;
                    break;
                case Movement.Up:
                    player.position.y++;
                    break;
                case Movement.Left:
                    player.position.x--;
                    break;
                case Movement.Down:
                    player.position.y--;
                    break;
            }
        }
        private void modifyMap(int x, int y, char c)
        {

        }

    }
}
