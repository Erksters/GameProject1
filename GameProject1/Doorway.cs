using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using CollisionExample.Collisions;

namespace GameProject1
{
    class Doorway
    {
        private Vector2 position;

        private Texture2D texture;

        public bool Nearby { get; set; } = false;

        private BoundingRectangle rectangleBounds;

        /// <summary>
        /// Bounding Volume of the coin 
        ///FOR RECTANGLE COLLISIONS
        /// </summary>        
        public BoundingRectangle RectangleBounds => rectangleBounds;

        public Doorway(Vector2 position)
        {
            this.position = position;
            this.rectangleBounds = new BoundingRectangle(position, 64, 71);
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Doorways-small");
        }

        /// <summary>
        /// Draws the animated sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture must be loaded to render");
            
            var source = new Rectangle(0, 0, 64, 71 );
            
            spriteBatch.Draw(texture,position, source, Color.White);
        }
    }
}
