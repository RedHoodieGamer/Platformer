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
    public class Enemy : GameObject
    {
        public Vector2 velocity;

        public Enemy(Rectangle rec, Vector2 velocity) : base(rec)
        {
            this.texture = AssetManager.spriteSheet;
            this.velocity = velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, Color.White);
        }
    }
}
