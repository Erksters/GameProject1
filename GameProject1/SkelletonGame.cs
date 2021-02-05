﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject1
{
    public class SkelletonGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Skeleton skeleton;
        private FlyingBat[] bats;
        private SkeletonInputManager inputManager;

        public SkelletonGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            inputManager = new SkeletonInputManager();
            skeleton = new Skeleton(this, new Vector2(200, 200));
            bats = new FlyingBat[]
            {
                new FlyingBat(new Vector2(600, 300), 1),
                new FlyingBat(new Vector2(600, 350), 0.5),
                new FlyingBat(new Vector2(600, 400), 0),
            };
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            skeleton.LoadContent();
            foreach (var bat in bats)
            {
                bat.LoadContent(Content);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);
            if (inputManager.Exit)   Exit();

            // TODO: Add your update logic here
            skeleton.Position += inputManager.Direction;
            foreach (var bat in bats) bat.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            SpriteEffects spriteEffects = (inputManager.flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            _spriteBatch.Begin();
            skeleton.Draw(_spriteBatch, spriteEffects);
            foreach (var bat in bats) bat.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
