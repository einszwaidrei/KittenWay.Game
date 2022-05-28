using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KittenWay.model;
using System.Drawing;
namespace KittenWay
{
    class EnemyView
    {
        private readonly Enemy Enemy;
        public Image Sprite;

        public EnemyView(Enemy enemy)
        {
            Enemy = enemy;
            if (Enemy.Type == 1)
                Sprite = Properties.Resources.monster1;
            else
                Sprite = Properties.Resources.monster2;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Sprite, Enemy.physics.Transform.X, Enemy.physics.Transform.Y, Enemy.physics.Transform.Width, Enemy.physics.Transform.Height);
        }
    }
}
