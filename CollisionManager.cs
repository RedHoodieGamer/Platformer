using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer
{
    public class CollisionManager
    {
        private List<Platform> platformsList;
        
        public CollisionManager(List<Platform> platforms)
        {
            platformsList = new List<Platform>();
            platformsList = platforms;
        }

        public void IsPlayerFalling(Player player)
        {
            bool isOnPlatform = false;

            for (int i = 0; i < platformsList.Count; i++)
            {
                if (platformsList[i].Size.Intersects(player.Size))
                {
                    isOnPlatform = true;
                    break;
                }
            }
            player.isPlayerFalling = !isOnPlatform;
        }

        public void EnemySafety(List<Enemy> enemies)
        {
            for(int i = 0;i < enemies.Count; i++)
            {
                for(int j = 0; j < platformsList.Count; j++)
                {
                    if (enemies[i].Size.Intersects(platformsList[j].Size))
                    {
                        if (enemies[i].Size.X <= platformsList[j].Size.X)
                        {
                            enemies[i].moving = Enemy.Moving.Right;
                        }
                        else if(enemies[i].Size.X + enemies[i].Size.Width >= platformsList[j].Size.X + platformsList[j].Size.Width)
                        {
                            enemies[i].moving = Enemy.Moving.Left;
                        }
                    }
                }
            }
        }

        //public void PlayerDeath(List<Enemy> enemies, Player player)
        //{
        //    for (int i = 0; i < enemies.Count; i++)
        //    {
        //        if (player.Size.Intersects(enemies[i].Size))
        //        {
                    
        //        }
        //    }
        //}
    }
}
