using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ch4hw
{
    class Sprite
    {
        //position of Sprite
        public Vector2 position = new Vector2(0, 0);

        //texture of Sprite
        private Texture2D spriteTexture;

        //loading the texture from the content pipeline
        public void LoadContent(ContentManager theContentManager, string theAssetName)
        {
            spriteTexture = theContentManager.Load<Texture2D>(theAssetName);
        }

        //drawing the sprite
        public void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(spriteTexture,position, Color.White);
        }

    }
}
