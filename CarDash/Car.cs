using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CarDash
{
    /// <summary>
    /// This class is use to show car and its functionality in action scene.
    /// </summary>
    public class Car : DrawableGameComponent
    {
        public SpriteBatch spriteBatch { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 position { get; set; }
        public Vector2 speed { get; set; }

        public Vector2 speed2 { get; set; }

        public float SCORE_FACTOR = 0.05F;
        public float score { get; set; }

        public SoundEffect horn;
        private KeyboardState oldState;


        public Car(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed, Vector2 speed2) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
            this.speed2 = speed2;
            this.horn = game.Content.Load<SoundEffect>("sounds/finalHorn");
        }



        public override void Update(GameTime gameTime)
        {
            score += SCORE_FACTOR;
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Left))
            {
                position -= speed;
                if (position.X < BackGround.stage.X/2 - 260)
                {
                    position = new Vector2(BackGround.stage.X / 2 - 260, position.Y);
                }

            }
            if (ks.IsKeyDown(Keys.Right))
            {
                position += speed;
                if (position.X > BackGround.stage.X / 2 + 180)
                {
                    position = new Vector2(BackGround.stage.X / 2 + 180,position.Y);
                }
            }
            if(ks.IsKeyDown(Keys.Up))
            {
                position -= speed2;
                if (position.Y < 0 )
                {
                    position = new Vector2(position.X, 0);
                }
            }
            if(ks.IsKeyDown(Keys.Down))
            {
                position +=speed2;
                if (position.Y > BackGround.stage.Y - tex.Height)
                {
                    position = new Vector2(position.X, BackGround.stage.Y - tex.Height);
                }
            }
            if(ks.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                horn.Play();
            }



            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// This method to get boundary with current car position.
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width-2, tex.Height-2);
        }
    }
}
