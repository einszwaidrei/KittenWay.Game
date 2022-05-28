using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Bonus
    {
        public Physics Physics;
        public int Type;

        public Bonus(float x, float y, int type)
        {
            Type = type;
            switch (type)
            {
                case 1:
                    Physics = new Physics(x,y,15,15);
                    break;
                case 2:
                    Physics = new Physics(x,y, 40,40);
                    break;
            }
        }
    }
}
