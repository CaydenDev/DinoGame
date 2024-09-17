using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FunnyDinoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D dinoTexture;
        private Rectangle dinoRect;
        private bool isJumping;
        private float jumpSpeed;
        private float gravity;
        private bool gameStarted;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            dinoRect = new Rectangle(50, 250, 50, 50);
            jumpSpeed = 0;
            gravity = 0.5f;
            isJumping = false;
            this.IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dinoTexture = Content.Load<Texture2D>("dino"); // Add your dino image name
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Space) && !isJumping)
            {
                isJumping = true;
                jumpSpeed = -10f; // Jump strength
            }

            if (isJumping)
            {
                dinoRect.Y += (int)jumpSpeed;
                jumpSpeed += gravity; // Apply gravity

                if (dinoRect.Y >= 250) // Reset position when landing
                {
                    dinoRect.Y = 250;
                    isJumping = false;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Cyan);

            _spriteBatch.Begin();
            _spriteBatch.Draw(dinoTexture, dinoRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}