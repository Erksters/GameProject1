using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject1
{
    public class SkelletonGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Skeleton skeleton;
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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            skeleton.LoadContent();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            skeleton.Position += inputManager.Direction;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            SpriteEffects spriteEffects = (inputManager.flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            _spriteBatch.Begin();
            skeleton.Draw(_spriteBatch, spriteEffects);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
