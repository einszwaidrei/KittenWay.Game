using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KittenWay.model;
using System.Drawing;

namespace KittenWay
{
    public class PlayerView
    {
        public Player player;
        public Image Sprite;

        public PlayerView(Player player)
        {
            this.player = player;
            Sprite = Properties.Resources.playerr;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, player.physics.Transform.X, player.physics.Transform.Y, player.physics.Transform.Width, player.physics.Transform.Height);
        }
    }
}
