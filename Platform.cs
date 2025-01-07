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
    public class Platform :GameObject
    {
        public Platform(Rectangle rec) : base(rec)
        {
            this.texture = AssetManager.platformTex;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, Color.SteelBlue);
        }
    }
}
