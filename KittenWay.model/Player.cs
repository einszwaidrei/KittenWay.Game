using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Player
    {
        public Physics physics;

        public Player(float x, float y)
        {
            physics = new Physics(x, y, 40, 40);
        }
    }
}
