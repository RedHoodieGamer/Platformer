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
            for (int i = 0; i < platformsList.Count; i++)
            {
                if (player.Size.Intersects(platformsList[i].Size))
                {
                    player.isPlayerFalling = true;
                }
                else player.isPlayerFalling = false;
            }
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
                    }
                }
            }
        }
        

        //public bool IsEnemyFalling(List<Enemy> enemies)
        //{
        //    for (int i = 0; i < enemies.Count; i++)
        //    {
        //        enemies[i].isEnemyFalling = true;
        //    }
        //}
    }
}
