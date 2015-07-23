using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Background
{

    class Sprite
    {
        //Position of Sprite
        public Vector2 Position = new Vector2(0, 0);

        //Texture for sprite
        private Texture2D spriteTexture;

        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            spriteTexture = theContentManager.Load<Texture2D>(theAssetName);
            Size = new Rectangle(0, 0, (int)(spriteTexture.Width * Scale), (int)(spriteTexture.Height * Scale));
        }

        //Drawing the sprite on the screen
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(spriteTexture, Position, new Rectangle(0,0,spriteTexture.Width, spriteTexture.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        //The size of the sprite
        public Rectangle Size;

        //Rescales the sprite up or down
        public float Scale = 1.0f;
    }
}
