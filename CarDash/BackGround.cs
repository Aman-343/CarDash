using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDash
{
    /// <summary>
    /// This class is used to show the race track in action scene.
    /// </summary>
    public class BackGround : DrawableGameComponent
    {
        public static Vector2 stage;  // init in Game1;
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Rectangle srcRect;
        private Vector2 pos1, pos2;
        public Vector2 speed;


        public BackGround(Game game, SpriteBatch spriteBatch,Texture2D tex, Rectangle srcRect, Vector2 position,Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.srcRect = srcRect;
            this.pos1 = position;
            this.pos2 = new Vector2(pos1.X, pos1.Y + srcRect.Height);

            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            pos1 += speed;
            pos2 += speed;
            if (pos1.Y > srcRect.Height)
            {
                pos1.Y = pos2.Y - srcRect.Height;
            }

            if (pos2.Y > -srcRect.Height)
            {
                pos2.Y = pos1.Y -srcRect.Height;
            }

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //v4
            spriteBatch.Draw(tex, pos1, srcRect, Color.White);
            spriteBatch.Draw(tex, pos2, srcRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
