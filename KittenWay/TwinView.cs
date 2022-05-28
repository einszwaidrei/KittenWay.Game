using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KittenWay.model;

namespace KittenWay
{
    public class TwinView
    {
        private readonly Twin twin;
        public Image Sprite;

        public TwinView(Twin twin)
        {
            this.twin = twin;
            Sprite = Properties.Resources.playerr;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, twin.Physics.Transform.X, twin.Physics.Transform.Y, twin.Physics.Transform.Width, twin.Physics.Transform.Height);
        }
    }
}
