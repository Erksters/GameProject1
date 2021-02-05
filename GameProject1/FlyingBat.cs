using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace GameProject1
{
    public enum Direction
    {
        Right, Left
    }

    /// <summary>
    /// One eyed flying bat monster
    /// </summary>
    class FlyingBat
    {
        /// <summary>
        /// The direction of the bat.
        /// </summary>
        public Direction Direction;

        /// <summary>
        /// The position of the bat
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// Edit the direction change of the bat
        /// </summary>
        public double DirectionTimer;

        private double animationTimer;

        private Random rand;

        private short animationFrame;

        private Texture2D texture;

        /// <summary>
        /// Loads the bat sprite texture
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Flight");
        }

        public FlyingBat(Vector2 position, double directionTimer)
        {
            rand = new Random();
            Position = position;
            animationFrame = (short)new Random().Next(0, 7);
            DirectionTimer = directionTimer;
        }
        /// <summary>
        /// Updated bat sprite to face in a direction
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //Update Direction timer
            DirectionTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update direction every 2 seconds
            if (DirectionTimer > 2.0)
            {
                switch (Direction)
                {
                    case Direction.Right:
                        Direction = Direction.Left;
                        break;
                    case Direction.Left:
                        Direction = Direction.Right;
                        break;
                }
                //to prevent turn every frame
                DirectionTimer -= 2;
            }

            switch (Direction)
            {
                case Direction.Left:
                    Position += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
                case Direction.Right:
                    Position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    break;
            }
        }

        /// <summary>
        /// Draws the animated bat sprite
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update animation frame
            if (animationTimer > 0.3)
            {
                animationTimer -= 0.3;
                animationFrame++;
                if (animationFrame > 7)
                {
                    animationFrame = 0;
                }
            }

            var source = new Rectangle(animationFrame * 150,  0, 150, 150);
            SpriteEffects spriteEffects = (Direction == Direction.Left) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            //spriteBatch.Draw(texture, Position, source, Color.White);
            spriteBatch.Draw(texture, Position, source, Color.White, 0f, new Vector2(150, 150), 1, spriteEffects, 0);

        }

    }
}
