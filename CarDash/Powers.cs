using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;



namespace CarDash
{
    /// <summary>
    /// This class is use to show Powers and its functionality in action scene.
    /// </summary>
    public class Powers : DrawableGameComponent
    {
        public SpriteBatch spriteBatch { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 position { get; set; }

        public Vector2 speed { get; set; }

        Random r = new Random();

        public Powers(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.speed = speed;
        }



        public override void Update(GameTime gameTime)
        {
            position += speed;
            if (position.Y > BackGround.stage.Y + 100) 
            {
                position = new Vector2(r.Next(200, 450), -1000);
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(tex, position, new Rectangle(0,0, tex.Width/8-50, tex.Height/8-30),Color.Yellow);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// This method to get boundary with current Powers position.
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width/8 -50, tex.Height/8-30);
        }

    }
}
