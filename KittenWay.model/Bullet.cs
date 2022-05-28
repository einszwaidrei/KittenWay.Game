using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Bullet
    {
        public Physics Physics;

        public Bullet(float x, float y)
        {
            Physics = new Physics(x,y,15,15);
        }

        public void MoveUp()
        {
            Physics.Transform.Y -= 15;
        }
    }
}
