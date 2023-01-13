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
    /// This class is use to show ObstacelCar and its functionality in action scene.
    /// </summary>
    public class ObstacelCar : DrawableGameComponent
    {
        public SpriteBatch spriteBatch { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 position, position1;
        public Vector2 speed { get; set; }

        Random r = new Random();
        public ObstacelCar(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position, Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.position1 = position;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;
            if(position.Y > BackGround.stage.Y)
            {
                if(position1.Y == -tex.Height)
                {
                    position = new Vector2(r.Next(150, 300), -tex.Height);
                }
                else if(position1.Y == -2*tex.Height- 20)
                {
                    position = new Vector2(r.Next(300, 450), -2*tex.Height);
                }
                else if(position1.Y == -3*tex.Height- 20)
                {
                    position = new Vector2(r.Next(450, 600), -3*tex.Height);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, Color.Green);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// This method to get boundary with current Obstacel Car position.
        /// </summary>
        /// <returns></returns>
        public Rectangle getBounds()
        {
            return new Rectangle((int)position.X, (int)position.Y, tex.Width-2, tex.Height-2);
        }
    }
}
