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
    public static class AssetManager
    {
        public static Texture2D playerSpriteSheet;
        public static Texture2D backgroundTex;
        public static Texture2D platformTex;
        public static Texture2D spriteSheet;

        public static void LoadTextures(ContentManager content)
        {
            playerSpriteSheet = content.Load<Texture2D>("IndianaJones");
            backgroundTex = content.Load<Texture2D>("Ground");
            platformTex = content.Load<Texture2D>("plattform");
            spriteSheet = content.Load<Texture2D>("Sheet_BubbleBobble");
        }
    }
}
