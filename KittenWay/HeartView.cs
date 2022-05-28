using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KittenWay.model;

namespace KittenWay
{
    public class HeartView
    {
        private readonly Heart heart;
        public Image Sprite;

        public HeartView(Heart heart)
        {
            this.heart = heart;
            Sprite = Properties.Resources.Heart;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, heart.Physics.Transform.X, heart.Physics.Transform.Y, heart.Physics.Transform.Width, heart.Physics.Transform.Height);
        }

        public void DrawMenuSprite(Graphics g, int number)
        {
            g.DrawImage(Sprite, number*20, 20, heart.Physics.Transform.Width, heart.Physics.Transform.Height);
        }
    }
}
