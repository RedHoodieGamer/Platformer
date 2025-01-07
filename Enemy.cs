using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace Platformer
{
    public class Enemy : GameObject
    {
        public int velocity;
        //public bool isEnemyFalling;
        private float gravity;
        private int frame;
        private double frameTimer, frameInterval;
        private int texTileSize = 38;
        private Rectangle srcRec;
        private SpriteEffects spriteEffects;
        public enum Moving { Left = 1, Right = 2 };
        public Moving moving = Moving.Left;

        public Enemy(Rectangle rec, int velocity, float gravity) : base(rec)
        {
            this.texture = AssetManager.spriteSheet;
            this.velocity = velocity;
            this.gravity = gravity;

            srcRec = new Rectangle(0, 4 * texTileSize, texTileSize, texTileSize);
            frameTimer = 100;
            frameInterval = 100;
            spriteEffects = SpriteEffects.None;
        }

        public void Update(GameTime gameTime)
        {
            //if (isEnemyFalling)
            //    size.Y += (int)gravity;

            if(moving == Moving.Left)
            {
                //size.X -= velocity;
                spriteEffects = SpriteEffects.None;
            }
            else if(moving == Moving.Right)
            {
                //size.X += velocity;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval; frame++;
                srcRec.X = (frame % 4) * texTileSize;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, srcRec, Color.White, 0, new Vector2(), spriteEffects, 1);
        }
    }
}
