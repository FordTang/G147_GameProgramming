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

namespace MidReview
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite bananaSprite, happySprite, pineappleSprite, bgOne, bgTwo, bgThree, bgFour, bgFive;
        SpriteFont name;
        SoundEffect gorilla;
        Song music;

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
            bananaSprite = new Sprite();

            happySprite = new Sprite();

            pineappleSprite = new Sprite();

            bgOne = new Sprite();
            bgOne.Scale = 2.0f;

            bgTwo = new Sprite();
            bgTwo.Scale = 2.0f;

            bgThree = new Sprite();
            bgThree.Scale = 2.0f;

            bgFour = new Sprite();
            bgFour.Scale = 2.0f;

            bgFive = new Sprite();
            bgFive.Scale = 2.0f;

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
            bananaSprite.LoadContent(this.Content, "banana_256");
            bananaSprite.Position = new Vector2(10, 10);

            happySprite.LoadContent(this.Content, "happy_128");
            happySprite.Position = new Vector2(350, 100);

            pineappleSprite.LoadContent(this.Content, "pineapple_256");
            pineappleSprite.Position = new Vector2(500, 10);

            bgOne.LoadContent(this.Content, "Background01");
            bgOne.Position = new Vector2(0, 0);

            bgTwo.LoadContent(this.Content, "Background02");
            bgTwo.Position = new Vector2(bgOne.Position.X + bgOne.Size.Width, 0);

            bgThree.LoadContent(this.Content, "Background03");
            bgThree.Position = new Vector2(bgTwo.Position.X + bgTwo.Size.Width, 0);

            bgFour.LoadContent(this.Content, "Background04");
            bgFour.Position = new Vector2(bgThree.Position.X + bgThree.Size.Width, 0);

            bgFive.LoadContent(this.Content, "Background05");
            bgFive.Position = new Vector2(bgFour.Position.X + bgFour.Size.Width, 0);

            name = Content.Load<SpriteFont>("SpriteFont1");

            gorilla = Content.Load<SoundEffect>("gorilla");

            music = Content.Load<Song>("callmemaybe");
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
                        
            if (bgOne.Position.X < -bgOne.Size.Width)
            {
                bgOne.Position.X = bgFive.Position.X + bgFive.Size.Width;
            }

            if (bgTwo.Position.X < -bgTwo.Size.Width)
            {
                bgTwo.Position.X = bgOne.Position.X + bgOne.Size.Width;
            }

            if (bgThree.Position.X < -bgThree.Size.Width)
            {
                bgThree.Position.X = bgTwo.Position.X + bgTwo.Size.Width;
            }

            if (bgFour.Position.X < -bgFour.Size.Width)
            {
                bgFour.Position.X = bgThree.Position.X + bgThree.Size.Width;
            }

            if (bgFive.Position.X < -bgFive.Size.Width)
            {
                bgFive.Position.X = bgFour.Position.X + bgFour.Size.Width;
            }

            Vector2 aDirection = new Vector2(-1, 0);
            Vector2 aSpeed = new Vector2(160, 0);

            bgOne.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bgTwo.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bgThree.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bgFour.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bgFive.Position += aDirection * aSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Space))
            {
                gorilla.Play();
            }

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 textVector = new Vector2(10, 10);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            bgOne.Draw(this.spriteBatch);
            bgTwo.Draw(this.spriteBatch);
            bgThree.Draw(this.spriteBatch);
            bgFour.Draw(this.spriteBatch);
            bgFive.Draw(this.spriteBatch);

            bananaSprite.Draw(this.spriteBatch);

            happySprite.Draw(this.spriteBatch);

            pineappleSprite.Draw(this.spriteBatch);

            spriteBatch.DrawString(name, "Ford Tang", textVector, Color.Black);

            textVector = new Vector2(10, 30);

            spriteBatch.DrawString(name, "Ford Tang", textVector, Color.AliceBlue);

            textVector = new Vector2(10, 50);

            spriteBatch.DrawString(name, "Ford Tang", textVector, Color.AntiqueWhite);
            textVector = new Vector2(10, 70);

            spriteBatch.DrawString(name, "Ford Tang", textVector, Color.Aqua);

            textVector = new Vector2(10, 90);

            spriteBatch.DrawString(name, "Ford Tang", textVector, Color.Aquamarine);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
