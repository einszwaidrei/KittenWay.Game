using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Platform
    {
        public Transform transform;
        public int SizeX;
        public int SizeY;
        public bool IsTouchedByPlayer;

        public Platform(float x,float y)
        {
            SizeX = 60;
            SizeY = 12;
            IsTouchedByPlayer = false;
            transform = new Transform(x, y, SizeX, SizeY);
        }
    }
}
