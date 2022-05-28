using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenWay.model
{
    public class Physics
    {
        public Transform Transform;
        float gravity;
        float a;
        public int Health=0;

        public float dx;
        public bool usedBonus = false;
        public Physics(float x, float y, int width, int height)
        { 
            Transform = new Transform(x,y,width,height);
            gravity = 0;
            a = 0.4f;
            dx = 0;
        }

        public Platform FindPlayerOnPlatform()
        {
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                float deltaX = (Transform.X + Transform.Width / 2) - (platform.transform.X + platform.transform.Width / 2);
                float deltaY = (Transform.Y + Transform.Height / 2) - (platform.transform.Y + platform.transform.Height / 2);
                if (Math.Abs(deltaX) <= Transform.Width / 2 + platform.transform.Width / 2)
                {
                    if (Math.Abs(deltaY) <= Transform.Height / 2 + platform.transform.Height / 2 +25)
                        return platform;
                }
            }
            return null;
        }

        public void CalculatePhysics()
        {
            if (dx != 0)
                Transform.X += dx;
            if (Transform.Y < 700)
            {
                Transform.Y += gravity;
                gravity += a;

                if (gravity > -20 && usedBonus)
                {
                    PlatformController.GenerateRandomPlatform();
                    PlatformController.StartPlatformPositionY = 0;
                    PlatformController.GenerateStartSequences();
                    PlatformController.StartPlatformPositionY = 50;
                    usedBonus = false;
                }
            }
            Collide();
        }

        public void ApplyPhysics()
        {
            CalculatePhysics();
        }

        public void AddForce(int force = -10)
        {
            gravity = force;
        }

        public bool StandartCollide()
        {
            for (int i = 0; i < PlatformController.Bullets.Count; i++)
            {
                var bullet = PlatformController.Bullets[i];
                float deltaX = (Transform.X + Transform.Width / 2) - (bullet.Physics.Transform.X + bullet.Physics.Transform.Width / 2);
                float deltaY = (Transform.Y + Transform.Height / 2) - (bullet.Physics.Transform.Y + bullet.Physics.Transform.Height / 2);
                if (Math.Abs(deltaX) <= Transform.Width / 2 + bullet.Physics.Transform.Width / 2)
                {
                    if (Math.Abs(deltaY) <= Transform.Height / 2 + bullet.Physics.Transform.Height / 2)
                    {
                        PlatformController.RemoveBullet(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool StandartCollideMeteoryts()
        {
            for (int i = 0; i < PlatformController.Meteoryts.Count; i++)
            {
                var meteoryt = PlatformController.Meteoryts[i];
                float deltaX = (Transform.X + Transform.Width / 2) - (meteoryt.Physics.Transform.X + meteoryt.Physics.Transform.Width / 2);
                float deltaY = (Transform.Y + Transform.Height / 2) - (meteoryt.Physics.Transform.Y + meteoryt.Physics.Transform.Height / 2);
                if (Math.Abs(deltaX) <= Transform.Width / 2 + meteoryt.Physics.Transform.Width / 2)
                {
                    if (Math.Abs(deltaY) <= Transform.Height / 2 + meteoryt.Physics.Transform.Height / 2 && usedBonus == false)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool StandartCollideHearts()
        {
            bool result = false;
            for (int i = 0; i < PlatformController.Hearts.Count; i++)
            {
                var heart = PlatformController.Hearts[i];
                float deltaX = (Transform.X + Transform.Width / 2) - (heart.Physics.Transform.X + heart.Physics.Transform.Width / 2);
                float deltaY = (Transform.Y + Transform.Height / 2) - (heart.Physics.Transform.Y + heart.Physics.Transform.Height / 2);
                if (Math.Abs(deltaX) <= Transform.Width / 2 + heart.Physics.Transform.Width / 2)
                {
                    if (Math.Abs(deltaY) <= Transform.Height / 2 + heart.Physics.Transform.Height / 2 && usedBonus == false)
                    {
                        Health++;
                        PlatformController.RemoveHeart(i);
                        result = true;
                    }
                }
            }
            return result;
        }
        public bool StandartCollidePlayerWithObjects(bool forMonsters, bool forBonuses)
        {
            if (forMonsters)
            {
                for (int i = 0; i < PlatformController.Enemies.Count; i++)
                {
                    var enemy = PlatformController.Enemies[i];
                    float deltaX = (Transform.X + Transform.Width / 2) - (enemy.physics.Transform.X + enemy.physics.Transform.Width / 2);
                    float deltaY = (Transform.Y + Transform.Height / 2) - (enemy.physics.Transform.Y + enemy.physics.Transform.Height / 2);
                    if (Math.Abs(deltaX) <= Transform.Width / 2 + enemy.physics.Transform.Width / 2)
                    {
                        if (Math.Abs(deltaY) <= Transform.Height / 2 + enemy.physics.Transform.Height / 2 && usedBonus == false)
                        {
                            return true;
                        }
                    }
                }
            }
            if (forBonuses)
            {
                for (int i = 0; i < PlatformController.Bonuses.Count; i++)
                {
                    var bonus = PlatformController.Bonuses[i];
                    float deltaX = (Transform.X + Transform.Width / 2) - (bonus.Physics.Transform.X + bonus.Physics.Transform.Width / 2);
                    float deltaY = (Transform.Y + Transform.Height / 2) - (bonus.Physics.Transform.Y + bonus.Physics.Transform.Height / 2);
                    if (Math.Abs(deltaX) <= Transform.Width / 2 + bonus.Physics.Transform.Width / 2)
                    {
                        if (Math.Abs(deltaY) <= Transform.Height / 2 + bonus.Physics.Transform.Height / 2)
                        {
                            if (bonus.Type == 1 && !usedBonus)
                            {
                                usedBonus = true;
                                PlatformController.Score += 200;
                                AddForce(-30);
                            }

                            if (bonus.Type == 2 && !usedBonus)
                            {
                                usedBonus = true;
                                PlatformController.Score += 400;
                                AddForce(-50);
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Collide()
        {
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                if (Transform.X + Transform.Width / 2 >= platform.transform.X && Transform.X + Transform.Width / 2 <= platform.transform.X + platform.transform.Width)
                    if (Transform.Y + Transform.Height >= platform.transform.Y
                        && Transform.Y + Transform.Height <= platform.transform.Y + platform.transform.Height)
                        if (gravity > 0)
                        {
                            AddForce();
                            if (!platform.IsTouchedByPlayer)
                            {
                                PlatformController.Score += 20;
                                PlatformController.GenerateRandomPlatform();
                                platform.IsTouchedByPlayer = true;

                            }
                        }
            }
        }
    }
}
