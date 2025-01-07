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
        public bool isFalling;
        public CollisionManager(List<Platform> platforms)
        {
            platformsList = new List<Platform>();
            platformsList = platforms;
        }

        public bool IsPlayerFalling(Player player)
        {
            if (isFalling == false)
                return true;
            else return false;
        }

        public bool IsEnemyFalling(List<Enemy> enemies)
        {
            if (isFalling == false)
                return true;
            else return false;
        }
    }
}
