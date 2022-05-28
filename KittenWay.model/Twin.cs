using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Twin
    {
        public Physics Physics;

        public Twin(float x, float y)
        {
            Physics = new Physics(x, y, 40, 40);
        }
    }
}
