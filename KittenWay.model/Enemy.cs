using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Enemy
    {
        public int Type;
        public Physics physics;

        public Enemy(float x, float y, int type)
        {
            Type = type;
            switch (type)
            {
                case 1:
                    physics = new Physics(x, y, 40, 40);
                    break;
                case 2:
                    physics = new Physics(x, y, 70, 50);
                    break;
            }
        }
    }
}
