using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Meteoryt
    {
        public Physics Physics;

        public Meteoryt(float x, float y)
        {
            Physics = new Physics(x,y,20,20);
        }

        public void MoveUp()
        {
            Physics.Transform.Y += 4;
        }
    }
}
