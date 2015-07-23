using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Background
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite bg1;
        Sprite bg2;
        Sprite bg3;
        Sprite bg4;
        Sprite bg5;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bg1 = new Sprite();
            bg1.Scale = 0.75f;

            bg2 = new Sprite();
            bg2.Scale = 0.75f;

            bg3 = new Sprite();
            bg3.Scale = 0.75f;

            bg4 = new Sprite();
            bg4.Scale = 0.75f;

            bg5 = new Sprite();
            bg5.Scale = 0.75f;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bg1.LoadContent(this.Content, "bg1");
            bg1.Position = new Vector2(0, 0);

            bg2.LoadContent(this.Content, "bg2");
            bg2.Position = new Vector2(bg1.Position.X + bg1.Size.Width, 0);

            bg3.LoadContent(this.Content, "bg3");
            bg3.Position = new Vector2(bg2.Position.X + bg2.Size.Width, 0);

            bg4.LoadContent(this.Content, "bg4");
            bg4.Position = new Vector2(bg3.Position.X + bg3.Size.Width, 0);

            bg5.LoadContent(this.Content, "bg5");
            bg5.Position = new Vector2(bg4.Position.X + bg4.Size.Width, 0);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (bg1.Position.X < -bg1.Size.Width)
            {
                bg1.Position.X = bg5.Position.X + bg5.Size.Width;
            }

            if (bg2.Position.X < -bg2.Size.Width)
            {
                bg2.Position.X = bg1.Position.X + bg1.Size.Width;
            }

            if (bg3.Position.X < -bg3.Size.Width)
            {
                bg3.Position.X = bg2.Position.X + bg2.Size.Width;
            }

            if (bg4.Position.X < -bg4.Size.Width)
            {
                bg4.Position.X = bg3.Position.X + bg3.Size.Width;
            }

            if (bg5.Position.X < -bg5.Size.Width)
            {
                bg5.Position.X = bg4.Position.X + bg4.Size.Width;
            }

            Vector2 direction = new Vector2(-1, 0);
            Vector2 speed = new Vector2(160, 0);

            bg1.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bg2.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bg3.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bg4.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bg5.Position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            bg1.Draw(this.spriteBatch);
            bg2.Draw(this.spriteBatch);
            bg3.Draw(this.spriteBatch);
            bg4.Draw(this.spriteBatch);
            bg5.Draw(this.spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
