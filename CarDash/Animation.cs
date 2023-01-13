using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CarDash
{
    /// <summary>
    /// This class works on functionality of animation 
    /// </summary>
    public class Animation : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 position;
        private Vector2 dimension;
        private List<Rectangle> Images;
        private int imageIndex = -1;
        private int delay;
        private int delayCounter;
        private const int ROWS = 5;
        private const int COLS = 5;
        public Animation(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, int delay) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.delay = delay;

            this.dimension = new Vector2(tex.Width / COLS, tex.Height / ROWS);

            createFrames();
            hide();

        }
        /// <summary>
        /// this method is to hides the animation
        /// </summary>
        private void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }

        /// <summary>
        /// this method is use to restart the animation from start.
        /// </summary>
        public void restart()
        {
            imageIndex = -1;
            delayCounter = 0;
            show();
        }

        /// <summary>
        /// this method is use to show the animation 
        /// </summary>
        private void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        /// <summary>
        /// this method is used to create frames for animation.
        /// </summary>
        private void createFrames()
        {
            Images = new List<Rectangle>();
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y, (int)dimension.X, (int)dimension.Y);
                    Images.Add(r);
                }
            }

        }

        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                imageIndex++;
                if (imageIndex > ROWS * COLS - 1)
                {
                    imageIndex = -1;
                    hide();
                }

                delayCounter = 0;
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {

            if (imageIndex >= 0)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(tex, position, Images[imageIndex], Color.White);
                spriteBatch.End();
            }


            base.Draw(gameTime);
        }
    }
}
