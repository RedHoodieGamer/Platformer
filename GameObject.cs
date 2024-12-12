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
    public abstract class GameObject
    {
        protected Texture2D texture;
        protected Rectangle size;

        public Rectangle Size
        {
            get { return size; }
        }
        public GameObject(Rectangle rec)
        {
            this.size = rec;
        }

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
