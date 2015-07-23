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

namespace ch5hw
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fontTime;
        SpriteFont fontDate;
        SpriteFont fontName;
        DateTime nowDateTime;
        String nowTime;
        String nowDate;
        String name;
        Vector2 nowVectorTime;
        Vector2 nowVectorDate;
        Vector2 nowVectorName;
        int layer;
        Color nowColor;
        Color nowColorBackground;
        //Vector2 nowVelocity;

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
            fontTime = Content.Load<SpriteFont>("SpriteFont1");
            fontDate = Content.Load<SpriteFont>("SpriteFont2");
            fontName = Content.Load<SpriteFont>("Fancy");
            //nowDateTime = DateTime.Now;
            //nowString = nowDateTime.ToLongTimeString();
            //nowVector = new Vector2(30, 10);
            //nowVelocity = new Vector2(1, 1);

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
            name = "Ford   Tang";
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
            nowDateTime = DateTime.Now;
            nowTime = nowDateTime.ToLongTimeString();
            nowDate = nowDateTime.ToLongDateString();
            //nowVector += nowVelocity;
           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            nowVectorName = new Vector2(30, 10);
            nowVectorTime = new Vector2(30, 40);
            nowVectorDate = new Vector2(30, 180);
            

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            nowColor = new Color(0, 0, 0, 20);
            for (layer = 0; layer < 10; layer++)
            {
                spriteBatch.DrawString(fontTime, nowTime, nowVectorTime, nowColor);
                nowVectorTime.X--;
                nowVectorTime.Y--;

                spriteBatch.DrawString(fontDate, nowDate, nowVectorDate, nowColor);
                nowVectorDate.X--;
                nowVectorDate.Y--;

                spriteBatch.DrawString(fontName, name, nowVectorName, nowColor);
                nowVectorName.X--;
                nowVectorName.Y--;
            }

            nowColor = new Color(0,0,0,0);
            for (layer = 0; layer < 3; layer++)
            {
                spriteBatch.DrawString(fontTime, nowTime, nowVectorTime, nowColor);
                nowVectorTime.X++;
                nowVectorTime.Y++;

                spriteBatch.DrawString(fontDate, nowDate, nowVectorDate, nowColor);
                nowVectorDate.X++;
                nowVectorDate.Y++;

                spriteBatch.DrawString(fontName, name, nowVectorName, nowColor);
                nowVectorName.X++;
                nowVectorName.Y++;
            }
            

            spriteBatch.DrawString(fontTime, nowTime, nowVectorTime, Color.Red);
            spriteBatch.DrawString(fontDate, nowDate, nowVectorDate, Color.Red);
            spriteBatch.DrawString(fontName, name, nowVectorName, Color.Red);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
