using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Tutorial
{
    class Avatar : Sprite
    {
        const string AVATAR_ASSETNAME = "xbox";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int AVATAR_SPEED = 160;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;

        //This saves the states of the avatar
        enum state
        {
            walking,
            jumping
        }

        state currentState = state.walking;

        Vector2 direction = Vector2.Zero;
        Vector2 speed = Vector2.Zero;
        Vector2 startingPosition = Vector2.Zero;

        KeyboardState previousKeyboardState;

        //This sets an image texture for the avatar
        public void loadContent(ContentManager contentManager)
        {
            position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.loadContent(contentManager, AVATAR_ASSETNAME);
        }

        //This is the update code for when the avatar moves.
        public void update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState();

            updateMovement(currentKeyboardState);
            updateJump(currentKeyboardState);

            previousKeyboardState = currentKeyboardState;

            base.update(gameTime, speed, direction);
        }

        //This controls the movement of the avatar.
        private void updateMovement(KeyboardState currentKeyboardState)
        {
            if (currentState == state.walking)
            {
                speed = Vector2.Zero;
                direction = Vector2.Zero;

                if (currentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    speed.X = AVATAR_SPEED;
                    direction.X = MOVE_LEFT;
                }

                else if (currentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    speed.X = AVATAR_SPEED;
                    direction.X = MOVE_RIGHT;
                }

                if (currentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    speed.Y = AVATAR_SPEED;
                    direction.Y = MOVE_UP;
                }

                else if (currentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    speed.Y = AVATAR_SPEED;
                    direction.Y = MOVE_DOWN;
                }
            }
        }

        //This updates when the avatar jumps.
        private void updateJump(KeyboardState currentKeyboardState)
        {
            if (currentState == state.walking)
            {
                if (currentKeyboardState.IsKeyDown(Keys.Space) == true && previousKeyboardState.IsKeyDown(Keys.Space) == false)
                {
                    jump();
                }
            }

            if (currentState == state.jumping)
            {
                if (startingPosition.Y - position.Y > 150)
                {
                    direction.Y = MOVE_DOWN;
                }

                if (position.Y > startingPosition.Y)
                {
                    position.Y = startingPosition.Y;
                    currentState = state.walking;
                    direction = Vector2.Zero;
                }
            }
        }
        
        //This is for the jumping controls
        private void jump()
        {
            if (currentState != state.jumping)
            startingPosition = position;
            direction.Y = MOVE_UP;
            speed = new Vector2(AVATAR_SPEED, AVATAR_SPEED);
        }
    }
}
