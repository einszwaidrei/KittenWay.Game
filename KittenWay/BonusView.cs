using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KittenWay.model;

namespace KittenWay
{
    public class BonusView
    {
        private readonly Bonus bonus;
        public Image Sprite;

        public BonusView(Bonus bonus)
        {
            this.bonus = bonus;
            if (bonus.Type == 1)
                Sprite = Properties.Resources.spring;
            else
                Sprite = Properties.Resources.rocket;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, bonus.Physics.Transform.X,bonus.Physics.Transform.Y, bonus.Physics.Transform.Width, bonus.Physics.Transform.Height);
        }
    }
}
