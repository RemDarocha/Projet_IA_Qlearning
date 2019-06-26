using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AI
{
    class Map
    {
        List<string> map = new List<string>();
        Player player = new Player();
        public string Start()
        {
            Initialisation();
            return player.ToString();
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
            Display();
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
            int x = 1 + player.position.x;
            int y = map.Count - 2 - player.position.y;
            char lastChar = map[y][x];
            ModifyMap(x, y, '-');

            Thread.Sleep(10);
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
            x = 1 + player.position.x;
            y = map.Count - 2 - player.position.y;
            char newChar = map[y][x];
            ModifyMap(x, y, '0');
            int reward = -1;
            
            switch (newChar)
            {
                case 'R':
                    reward = 100;
                    break;
                case 'x':
                    reward = -100;
                    break;
            }
            
            Display();
            return new Tuple<string, int>(player.ToString(), reward);
            
        }
        private void ModifyMap(int x, int y, char c)
        {
            string line = map[y];
            string newLine = "";
            for (int i = 0; i < line.Length; i++)
            {
                char toAdd = line[i];
                if (i == x)
                {
                    toAdd = c;
                }
                newLine += toAdd;
            }
            map[y] = newLine;
        }
    }
}
