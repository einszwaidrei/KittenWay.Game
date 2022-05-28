using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class PlatformController
    {
        public static List<Platform> platforms;
        public static int StartPlatformPositionY = 400;
        public static int Score = 0;
        public static List<Bullet> Bullets = new List<Bullet>();
        public static List<Enemy> Enemies = new List<Enemy>();
        public static List<Bonus> Bonuses = new List<Bonus>();
        public static List<Meteoryt> Meteoryts = new List<Meteoryt>();
        public static List<Heart> Hearts = new List<Heart>();
        public static List<Twin> Twins = new List<Twin>();

        public static void AddPlatform(float x,float y)
        {
            platforms.Add(new Platform(x,y));
        }

        public static int CountPlatforms()
        {
            return platforms.Count();
        }

        public static void CreateBullet(float x,float y)
        {
            var bullet = new Bullet(x,y);
            Bullets.Add(bullet);
        }

        public static void CreateTwin(Platform platform)
        {
            var twin = new Twin(platform.transform.X + (platform.SizeX / 2) - 25, platform.transform.Y - 37);
            Twins.Add(twin);
        }

        public static void CreateHealth(Platform platform)
        {
            var health = new Heart(platform.transform.X + (platform.SizeX / 2)-15, platform.transform.Y-30);
            Hearts.Add(health);
        }

        public static void CreateMeteoryt()
        {
            var r = new Random();
            var X = r.Next(0, 270);
            var meteoryt = new Meteoryt(X,-250);
            Meteoryts.Add(meteoryt);
        }

        public static void CreateEnemy(Platform platform)
        {
            var r = new Random();
            var enemyType = r.Next(1, 3);
            switch (enemyType)
            {
                case 1:
                    var enemy = new Enemy(platform.transform.X + (platform.SizeX / 2) - 20, platform.transform.Y - 40, enemyType);
                    Enemies.Add(enemy);
                    break;
                case 2:
                    enemy = new Enemy(platform.transform.X + (platform.SizeX / 2) - 35, platform.transform.Y - 50, enemyType);
                    Enemies.Add(enemy);
                    break;
            }
        }
        public static void CreateBonus(Platform platform)
        {
            Random r = new Random();
            var bonusType = r.Next(1, 3);
            switch (bonusType)
            {
                case 1:
                    var bonus = new Bonus(platform.transform.X + (platform.SizeX / 2) - 7, platform.transform.Y - 15, bonusType);
                    Bonuses.Add(bonus);
                    break;
                case 2:
                    bonus = new Bonus(platform.transform.X + (platform.SizeX / 2) - 21, platform.transform.Y - 40, bonusType);
                    Bonuses.Add(bonus);
                    break;
            }
        }
        public static void GenerateStartSequences()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(0, 270);
                int y = r.Next(30, 40);
                StartPlatformPositionY -= y;
                AddPlatform(x, StartPlatformPositionY);
            }
        }

        public static void GenerateRandomPlatform()
        {
            Random r = new Random();
            int x = r.Next(0, 270);
            var platform = new Platform(x, StartPlatformPositionY);
            AddPlatform(x, StartPlatformPositionY);
            var creatingItem = r.Next(1, 4);
            switch (creatingItem)
            {
                case 1:
                    var creatingEnemy = r.Next(1, 8);
                    if (creatingEnemy == 1)
                        CreateEnemy(platform);
                    break;
                case 2:
                    var creatingBonus = r.Next(1, 15);
                    if (creatingBonus == 1)
                        CreateBonus(platform);
                    break;
                case 3:
                    var creatingHeart = r.Next(1, 8);
                    if (creatingHeart == 1)
                        CreateHealth(platform);
                    break;
            }
            var creatingMeteoryt = r.Next(1, 5);
            if (creatingMeteoryt == 1)
                CreateMeteoryt();
        }

        public static void CleanPlatforms()
        {
            for (int i = 0; i < platforms.Count; i++)
                if (platforms[i].transform.Y >= 700)
                    platforms.RemoveAt(i);
            for (int i = 0; i < Enemies.Count; i++)
                if (Enemies[i].physics.Transform.Y >= 700)
                {
                    Enemies.RemoveAt(i);
                    break;
                }
            for (int i = 0; i < Bonuses.Count; i++)
                if (Bonuses[i].Physics.Transform.Y >= 700)
                    Bonuses.RemoveAt(i);
            for (int i = 0; i < Hearts.Count; i++)
                if (Hearts[i].Physics.Transform.Y >= 700)
                    Hearts.RemoveAt(i);
            for (int i = 0; i < Twins.Count; i++)
                if (Twins[i].Physics.Transform.Y >= 700);
                    
        }

        public static void RemoveEnemy(int i)
        {
            Enemies.RemoveAt(i);
        }

        public static void RemoveBullet(int i)
        {
            Bullets.RemoveAt(i);
        }

        public static void RemoveMeteoryt(int i)
        {
            Meteoryts.RemoveAt(i);
        }

        public static void RemoveHeart(int i)
        {
            Hearts.RemoveAt(i);
        }

        public static void RemoveTwin(int i)
        {
            Twins.RemoveAt(i);
        }
    }
}
