﻿using System;
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
        public int velocity;
        //public bool isEnemyFalling;
        private float gravity;


        public Enemy(Rectangle rec, int velocity, float gravity) : base(rec)
        {
            this.texture = AssetManager.spriteSheet;
            this.velocity = velocity;
            this.gravity = gravity;
        }

        public void Update()
        {
            //if (isEnemyFalling)
            //    size.Y += (int)gravity;

            size.X += velocity;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, size, Color.White);
        }
    }
}
