using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CollisionExample.Collisions;

namespace GameProject1
{
    public class SkeletonInputManager
    {
        public bool Exit { get; private set; } = false;

        private KeyboardState currentKeyboardState;
        private KeyboardState priorKeyboardState;

        /// <summary>
        /// Vector2 Direction for sprite velocity
        /// </summary>
        public Vector2 Direction { get; private set; }

        /// <summary>
        /// Detection box with the environment
        /// </summary>
        public BoundingRectangle Bounds = new BoundingRectangle(new Vector2(200 - 16, 200 - 16), 32, 32); ///FOR RECTANGLE COLLISIONS

        /// <summary>
        /// Which way is the player facing
        /// </summary>
        public bool flipped = false;

        public void Update(GameTime gameTime)
        {
            priorKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Direction = new Vector2(0, 0);

            ///Get Postion from Keyboard
            //Left
            if (currentKeyboardState.IsKeyDown(Keys.Left) || currentKeyboardState.IsKeyDown(Keys.A))
            {
                flipped = true;
                Direction += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            //Right
            if (currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.D))
            {
                flipped = false;
                Direction += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            //Up
            if (currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.W))
            {
                Direction += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            //Down
            if (currentKeyboardState.IsKeyDown(Keys.Down) || currentKeyboardState.IsKeyDown(Keys.S))
            {
                Direction += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }

            ///FOR SQUARE COLLISIONS
            Bounds.X += Direction.X;
            Bounds.Y += Direction.Y;
        }

    }
}

