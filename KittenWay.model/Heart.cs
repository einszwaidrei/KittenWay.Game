using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Heart
    {
        public Physics Physics;

        public Heart(float x,float y)
        {
            Physics = new Physics(x, y, 30, 30);
        }
    }
}
