using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject1
{
    public class Skeleton
    {
        public Game game;

        /// <summary>
        /// A color to help distinguish when the skeleton is touching a bat from another
        /// </summary>
        public Color Color;

        /// <summary>
        /// The texture to apply to a skeleton
        /// </summary>
        public Texture2D texture;
        public Texture2D WalkingTexture;

        /// <summary>
        /// The position of the skeleton in the game world
        /// </summary>
        public Vector2 Position;

        private double animationTimer;


        private short animationFrame;

        public bool Moving;

        public Skeleton(Game game, Vector2 position)
        {
            this.game = game;
            Position = position;
            Color = Color.White;
        }

        /// <summary>
        /// Loads the skeleton's texture
        /// </summary>
        public void LoadContent()
        {
            texture = game.Content.Load<Texture2D>("SkeletonIdle");
            WalkingTexture = game.Content.Load<Texture2D>("Skeleton Walk");
        }

        /// <summary>
        /// Draws the skeleton at its current position and with 
        /// its assigned color
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteEffects spriteEffect)
        {
            //Update animation timer
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            //Update animation frame
            if (animationTimer > 0.1)
            {
                animationTimer -= 0.1;
                animationFrame++;
                if(Moving && animationFrame > 12)
                {
                    animationFrame = 0;
                }
                if (!Moving && animationFrame > 10)
                {
                    animationFrame = 0;
                }
            }
            //13 frames of walking
            //11 frames of idle
            var source = new Rectangle(animationFrame * ((Moving) ? 22:24), 0, ((Moving) ? 22 : 24), 32);

            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            spriteBatch.Draw(
                Moving ? WalkingTexture: texture,
                new Rectangle((int)Position.X, (int)Position.Y, 24,32),
                source,
                Color,
                0f,
                new Vector2(0,0),
                spriteEffect,0);
        }

    }
}
