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
        private bool isFalling;
        private float gravity;

        public Player(Rectangle rec, int velocity, float gravity) : base(rec)
        {
            this.texture = AssetManager.playerSpriteSheet;
            this.velocity = velocity;
            this.gravity = gravity;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (isFalling)
                size.Y += (int)gravity;
            if (state.IsKeyDown(Keys.A))
            {
                size.X -= velocity;
            }
            else if (state.IsKeyDown(Keys.D))
            {
                size.X += velocity;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, Color.White);
        }
    }
}
