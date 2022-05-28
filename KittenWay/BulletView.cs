using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KittenWay.model;
using System.Drawing;

namespace KittenWay
{
    public class BulletView
    {
        private readonly Bullet bullet;
        public Image Sprite;

        public BulletView(Bullet bullet)
        {
            this.bullet = bullet;
            Sprite = Properties.Resources.fire;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite,bullet.Physics.Transform.X, bullet.Physics.Transform.Y, bullet.Physics.Transform.Width, bullet.Physics.Transform.Height);
        }
    }
}
