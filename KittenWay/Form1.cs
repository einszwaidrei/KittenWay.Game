using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KittenWay.model;

namespace KittenWay
{
    public partial class Form1 : Form
    {
        PlayerView playerOnStage;
        Player player;
        Timer timer1;
        public Form1()
        {
            InitializeComponent();
            Init();
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyBoardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyBoardUp);
            this.BackgroundImage = Properties.Resources.fon;  //new Bitmap("C:\\Users\\vange\\Downloads.back.png");
            this.Height = 600;
            this.Width = 330;
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        public void Init()
        {
            PlatformController.platforms = new List<Platform>();
            PlatformController.AddPlatform(100,400);
            PlatformController.StartPlatformPositionY = 400;
            PlatformController.Score = 0;
            PlatformController.GenerateStartSequences();
            PlatformController.Bullets.Clear();
            PlatformController.Enemies.Clear();
            PlatformController.Bonuses.Clear();
            PlatformController.Meteoryts.Clear();
            PlatformController.Hearts.Clear();
            PlatformController.Twins.Clear();
            player = new Player(100,350);
            playerOnStage = new PlayerView(player);
        }

        private void OnKeyBoardUp(object sender, KeyEventArgs e)
        {
            playerOnStage.player.physics.dx = 0;
            playerOnStage.Sprite = Properties.Resources.playerr;

            switch (e.KeyCode.ToString())
            {
                case "Space":
                    PlatformController.CreateBullet(playerOnStage.player.physics.Transform.X + playerOnStage.player.physics.Transform.Width / 2, playerOnStage.player.physics.Transform.Y);
                    break;
                case "ShiftKey":
                    if (playerOnStage.player.physics.Health>0 && playerOnStage.player.physics.FindPlayerOnPlatform()!=null)
                    {
                        var platform = playerOnStage.player.physics.FindPlayerOnPlatform();
                        PlatformController.CreateTwin(platform);
                        playerOnStage.player.physics.Health--;
                    }
                    break;
            }
        }

        private void OnKeyBoardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    playerOnStage.player.physics.dx = 6;
                    break;
                case "Left":
                    playerOnStage.player.physics.dx = -6;
                    break;
                case "Space":
                    playerOnStage.Sprite = Properties.Resources.playerFire;
                    //PlatformController.CreateBullet(new PointF(player.Physics.Transform.Position.X + player.Physics.Transform.Size.Width/2,player.Physics.Transform.Position.Y));
                    break;
            }
        }

        public void FollowPlayer()
        {
            int offset = 400 - (int)playerOnStage.player.physics.Transform.Y;
            playerOnStage.player.physics.Transform.Y += offset;
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Bullets.Count; i++)
            {
                var bullet = PlatformController.Bullets[i];
                bullet.Physics.Transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Enemies.Count; i++)
            {
                var enemy = PlatformController.Enemies[i];
                enemy.physics.Transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Bonuses.Count; i++)
            {
                var bullet = PlatformController.Bonuses[i];
                bullet.Physics.Transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Meteoryts.Count; i++)
            {
                var meteoryt = PlatformController.Meteoryts[i];
                meteoryt.Physics.Transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Hearts.Count; i++)
            {
                var heart = PlatformController.Hearts[i];
                heart.Physics.Transform.Y += offset;
            }
            for (int i = 0; i < PlatformController.Twins.Count; i++)
            {
                var twin = PlatformController.Twins[i];
                twin.Physics.Transform.Y += offset;
            }
        }

        public static void DrawMenuSprite(Graphics g, int number, Image sprite)
        {
            g.DrawImage(sprite, number * 20, 20, 30, 30);
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (PlatformController.platforms.Count > 0)
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    var platformPic = new PlatformView(PlatformController.platforms[i]);
                    platformPic.DrawSprite(g);
                }
            if (PlatformController.Bullets.Count > 0)
                for (int i = 0; i < PlatformController.Bullets.Count; i++)
                {
                    var bulletPic = new BulletView(PlatformController.Bullets[i]);
                    bulletPic.DrawSprite(g);
                }
            if (PlatformController.Enemies.Count > 0)
                for (int i = 0; i < PlatformController.Enemies.Count; i++)
                {
                    var enemyPic = new EnemyView(PlatformController.Enemies[i]);
                    enemyPic.DrawSprite(g);
                }
            if (PlatformController.Bonuses.Count > 0)
                for (int i = 0; i < PlatformController.Bonuses.Count; i++)
                {
                    var bonusPic = new BonusView(PlatformController.Bonuses[i]);
                    bonusPic.DrawSprite(g);
                }
            if (PlatformController.Meteoryts.Count > 0)
                for (int i = 0; i < PlatformController.Meteoryts.Count; i++)
                {
                    var meteorytPic = new MeteorytView(PlatformController.Meteoryts[i]);
                    meteorytPic.DrawSprite(g);
                }
            if (PlatformController.Hearts.Count > 0)
                for (int i = 0; i < PlatformController.Hearts.Count; i++)
                {
                    var heartView = new HeartView(PlatformController.Hearts[i]);
                    heartView.DrawSprite(g);
                }
            if (PlatformController.Twins.Count > 0)
                for (int i = 0; i < PlatformController.Twins.Count; i++)
                {
                    var twinView = new TwinView(PlatformController.Twins[i]);
                    twinView.DrawSprite(g);
                }
            if (playerOnStage.player.physics.Health > 0)
                for (int i = 0; i < playerOnStage.player.physics.Health; i++)
                {
                    DrawMenuSprite(g, i, Properties.Resources.Heart);
                }

            playerOnStage.DrawSprite(g);
        }
        //static justBecameAlive = false;
        private void Update(object sender, EventArgs e)
        {
            this.Text = "Doodle Jump: Score - " + PlatformController.Score;
            if (playerOnStage.player.physics.Transform.Y >= PlatformController.platforms[0].transform.Y + 200
                || (playerOnStage.player.physics.StandartCollidePlayerWithObjects(true, false)
                || playerOnStage.player.physics.StandartCollideMeteoryts()))
                if (PlatformController.Twins.Count > 0)
                {
                    var tv = PlatformController.Twins[PlatformController.Twins.Count - 1];
                    var health= playerOnStage.player.physics.Health;
                    playerOnStage.player = new Player(tv.Physics.Transform.X, tv.Physics.Transform.Y);
                    playerOnStage.player.physics.Health = health;
                    PlatformController.RemoveTwin(PlatformController.Twins.Count - 1);
                }
                else
                    Init();
            if (PlatformController.Score > 600 && playerOnStage.player.physics.Transform.Y >= PlatformController.platforms[PlatformController.CountPlatforms() - 25].transform.Y)
                if (PlatformController.Twins.Count > 0)
                {
                    var tv = PlatformController.Twins[PlatformController.Twins.Count - 1];
                    var health = playerOnStage.player.physics.Health;
                    playerOnStage.player = new Player(tv.Physics.Transform.X, tv.Physics.Transform.Y);
                    playerOnStage.player.physics.Health = health;
                    PlatformController.RemoveTwin(PlatformController.Twins.Count - 1);
                }
                else
                    Init();
            playerOnStage.player.physics.StandartCollidePlayerWithObjects(false, true);
            playerOnStage.player.physics.StandartCollideHearts();

            if (PlatformController.Bullets.Count > 0)
                for (int i = 0; i < PlatformController.Bullets.Count; i++)
                {
                    if (Math.Abs(PlatformController.Bullets[i].Physics.Transform.Y - playerOnStage.player.physics.Transform.Y) > 500)
                    {
                        PlatformController.RemoveBullet(i);
                        continue;
                    }
                    PlatformController.Bullets[i].MoveUp();
                }

            if (PlatformController.Meteoryts.Count > 0)
            {
                for (int i = 0; i < PlatformController.Meteoryts.Count; i++)
                {
                    if (PlatformController.Meteoryts[i].Physics.Transform.Y - playerOnStage.player.physics.Transform.Y > 500)
                    {
                        PlatformController.RemoveMeteoryt(i);
                        continue;
                    }
                    PlatformController.Meteoryts[i].MoveUp();
                }
            }
            if (PlatformController.Enemies.Count > 0)
                for (int i = 0; i < PlatformController.Enemies.Count; i++)
                    if (PlatformController.Enemies[i].physics.StandartCollide())
                    {
                        PlatformController.RemoveEnemy(i);
                        break;
                    }


            playerOnStage.player.physics.ApplyPhysics();
            FollowPlayer();
            Invalidate();
        }
    }
}
