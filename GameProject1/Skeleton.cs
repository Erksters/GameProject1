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

        /// <summary>
        /// The position of the skeleton in the game world
        /// </summary>
        public Vector2 Position;

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
        }

        /// <summary>
        /// Draws the skeleton at its current position and with 
        /// its assigned color
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to render with</param>
        public void Draw(SpriteBatch spriteBatch, SpriteEffects spriteEffect)
        {
            var source = new Rectangle(0, 0, 24,32);

            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            spriteBatch.Draw(
                texture,
                new Rectangle((int)Position.X, (int)Position.Y, 24,32),
                source,
                Color,
                0f,
                new Vector2(0,0),
                spriteEffect,0);
        }

    }
}
