using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;


namespace Platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;
        private List<Platform> platformList;
        private List<Enemy> enemyList;
        private List<GameObject> gameObjectList;
        public CollisionManager collisionManager;
        public EnemyManager enemyManager;
        public enum GameSate { Gameplay = 1, GameOver = 2 }
        public GameSate gameSate = GameSate.Gameplay;
        public bool gameOver;
        private Rectangle finalRec;

        public float gravity = 9.82f / 4;
        public int playerVel = 5;
        public int enemyVel = 1;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            AssetManager.LoadTextures(Content);
            gameObjectList = new List<GameObject>();
            platformList = new List<Platform>();
            enemyList = new List<Enemy>();
            ReadFromFile("level1.json");
            collisionManager = new CollisionManager(platformList);
            enemyManager = new EnemyManager(enemyList);
            gameOver = false;
            finalRec = new Rectangle();
            


            // TODO: use this.Content to load your game content here
        }

        private void ReadFromFile(string fileName)
        {
            Rectangle playerRec = JsonParser.GetRectangle(fileName, "player");
            player = new Player(playerRec, playerVel, gravity);
            gameObjectList.Add(player);

            Rectangle winRec = JsonParser.GetRectangle(fileName, "win");
            finalRec = winRec;

            List<Rectangle> platformRecList = JsonParser.GetRecangleList(fileName, "platforms");
            foreach (Rectangle rec in platformRecList)
            {
                Platform platform = new Platform(rec);
                gameObjectList.Add(platform);
                platformList.Add(platform);
            }
            List<Rectangle> enemyRecList = JsonParser.GetRecangleList(fileName, "enemies");
            foreach (Rectangle rec in enemyRecList)
            {
                Enemy enemy = new Enemy(rec, enemyVel);
                gameObjectList.Add(enemy);
                enemyList.Add(enemy);
            }
        }

        public void PlayerDeath()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if (player.Size.Intersects(enemyList[i].Size))
                {
                    gameSate = GameSate.GameOver;
                }
            }
        }

        public void Win()
        {
            if (player.Size.Intersects(finalRec))
            {
                gameSate = GameSate.GameOver;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (gameSate == GameSate.Gameplay)
            {
                collisionManager.IsPlayerFalling(player);
                collisionManager.EnemySafety(enemyList);
                //collisionManager.PlayerDeath(enemyList, player);
                enemyManager.Update(gameTime);
                player.Update(gameTime);
                PlayerDeath();
                Win();
                
            }
            else if (gameSate == GameSate.GameOver)
            {
                gameObjectList.Clear();
                platformList.Clear();
                enemyList.Clear();
                ReadFromFile("level1.json");
                gameSate = GameSate.Gameplay;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            spriteBatch.Begin();

            foreach (GameObject gameObject in gameObjectList)
            {
                gameObject.Draw(spriteBatch);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
