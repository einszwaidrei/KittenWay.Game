using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KittenWay.model;
using System.Drawing;

namespace KittenWay
{
    public class PlatformView
    {
        private readonly Platform platform;
        public Image sprite;

        public PlatformView(Platform platform)
        {
            this.platform = platform;
            sprite = Properties.Resources.platformm;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, platform.transform.X, platform.transform.Y, platform.transform.Width, platform.transform.Height);
        }
    }
}
