using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tutorial
{
    class Sprite
    {
        //Sets the position of the sprite.
        public Vector2 position = new Vector2(0, 0);

        //The texture object used for the sprite.
        private Texture2D spriteTexture;

        //This loads texture from the Content Pipeline
        public void loadContent(ContentManager contentManager, string contentName)
        {
            spriteTexture = contentManager.Load<Texture2D>(contentName);
            assetName = contentName;
            size = new Rectangle(0,0,(int)(spriteTexture.Width * scale), (int)(spriteTexture.Height * scale));
        }

        //This draws the sprite onto the Screen.
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(spriteTexture, position, new Rectangle(0,0, spriteTexture.Width, spriteTexture.Height), Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0);
        }

        //The asset name for the Sprite's Texture.
        public string assetName;

        //The size of the sprite (scaling).
        public Rectangle size;

        //The scaling of the sprite.
        private float spriteScale = 1.0f;

        //This is to recalculate the sprite after a scale is applied.
        public float scale
        {
            get { return spriteScale; }
            set
            {
                spriteScale = value;

                //This recalculates the size of the sprite when the new scale is applied
                size = new Rectangle(0, 0, (int)(spriteTexture.Width * scale), (int)(spriteTexture.Height * scale));
            }
        }

        //This updates the sprite and changes it's position based on speed, direction and time
        public void update(GameTime gameTime, Vector2 speed, Vector2 direction)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}
