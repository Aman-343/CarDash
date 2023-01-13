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
    /// This class is used to show message on screen.
    /// </summary>
    public class ToString: DrawableGameComponent
    {
        protected SpriteBatch spriteBatch;
        protected SpriteFont font;
        public string message;
        public Vector2 position;
        protected Color color;

        public ToString(Game game, SpriteBatch spriteBatch, SpriteFont font, string message, Vector2 position, Color color) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.message = message;
            this.position = position;
            this.color = color;
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, message, position, color);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
