using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KittenWay.model;
using System.Drawing;

namespace KittenWay
{
    public class MeteorytView
    {
        private readonly Meteoryt meteoryt;
        public Image Sprite;

        public MeteorytView(Meteoryt meteoryt)
        {
            this.meteoryt = meteoryt;
            Sprite = Properties.Resources.meteoryt;
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, meteoryt.Physics.Transform.X, meteoryt.Physics.Transform.Y, meteoryt.Physics.Transform.Width, meteoryt.Physics.Transform.Height);
        }
    }
}
