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
    public class Player : GameObject
    {
        private int velocity;
        public bool isPlayerFalling;
        private float gravity;
        private int frame;
        private double frameTimer, frameInterval;
        private int texTileSize = 64;
        private Rectangle srcRec;
        private SpriteEffects spriteEffects;


        public Player(Rectangle rec, int velocity, float gravity) : base(rec)
        {
            this.texture = AssetManager.playerSpriteSheet;
            this.velocity = velocity;
            this.gravity = gravity;

            isPlayerFalling = false;
            srcRec = new Rectangle(0, 0, texTileSize, texTileSize);
            frameTimer = 100;
            frameInterval = 100;
            spriteEffects = SpriteEffects.None;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            KeyMouseReader.Update();

            if (isPlayerFalling)
                size.Y += (int)gravity;
            
            if (state.IsKeyDown(Keys.A))
            {
                size.X -= velocity;
                spriteEffects = SpriteEffects.None;
            }
            else if (state.IsKeyDown(Keys.D))
            {
                size.X += velocity;
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if (KeyMouseReader.KeyPressed(Keys.W) && !isPlayerFalling)
            {
                size.Y -= velocity * 10;
            }

            frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameTimer <= 0)
            {
                frameTimer = frameInterval; frame++;
                srcRec.X = (frame % 10) * texTileSize;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, srcRec, Color.White, 0, new Vector2(), spriteEffects, 1);
        }
    }
}
