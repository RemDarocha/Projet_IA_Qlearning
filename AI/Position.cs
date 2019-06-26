using System;
using System.Collections.Generic;
using System.Text;

namespace AI
{
    public class Position
    {
        public int x = 0;
        public int y = 0;

        public override string ToString()
        {
            return x.ToString() + "," + y.ToString();
        }
    }
}
