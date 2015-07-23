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

namespace Tutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        DateTime nowDateTime = DateTime.Now;
        //Sprite nesTex;
        //Sprite snesTex;
        //Sprite xboxTex;
        Avatar xboxSprite;

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

            string nowString = nowDateTime.ToLongTimeString();

            //nesTex = new Sprite();
            //snesTex = new Sprite();
            //xboxTex = new Sprite();
            xboxSprite = new Avatar();

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

            font = Content.Load<SpriteFont>("SpriteFont1");
            DateTime nowDateTime = DateTime.Now;

            /*
            nesTex.loadContent(this.Content, "nes");
            nesTex.position = new Vector2(10, 10);

            snesTex.loadContent(this.Content, "snes");
            snesTex.position = new Vector2(250, 10);

            xboxTex.loadContent(this.Content, "xbox");
            xboxTex.position = new Vector2(500, 10);
             */

            xboxSprite.loadContent(this.Content);
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
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape)) 
                this.Exit();


            // TODO: Add your update logic here
            xboxSprite.update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            string nowString = nowDateTime.ToLongTimeString();
            Vector2 nowVector = new Vector2(20, 400);
            Vector2 nameVector = new Vector2(10, 10);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.DrawString(font, nowString, nowVector, Color.Red);
            spriteBatch.DrawString(font, "Ford Tang - C02122472", nameVector, Color.Orange);
            //nesTex.Draw(this.spriteBatch);
            //snesTex.Draw(this.spriteBatch);
            //xboxTex.Draw(this.spriteBatch);

            xboxSprite.Draw(this.spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
