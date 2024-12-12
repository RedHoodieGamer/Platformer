using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
