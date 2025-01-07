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

        public bool IsPlayerFalling(Player player)
        {
            for (int i = 0; i < platformsList.Count; i++)
            {
                if (player.Size.Intersects(platformsList[i].Size))
                {
                    return player.isPlayerFalling = true;
                }
                else return player.isPlayerFalling = false;
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
