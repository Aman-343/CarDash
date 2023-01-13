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
    /// This class is use to display help scene.
    /// </summary>
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex, tex1;
        private Game1 g;
        public HelpScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;
            tex = game.Content.Load<Texture2D>("images/help1");
            tex1 = game.Content.Load<Texture2D>("images/help2");

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Vector2(BackGround.stage.X/2 -tex.Width/2 + 30, 0),new Rectangle(0, 0, tex.Width-40, tex.Height) ,Color.White);
            spriteBatch.Draw(tex1, new Vector2(BackGround.stage.X / 2 - tex.Width /2 + 30, tex.Height - 83), new Rectangle(0,0,tex1.Width-40, tex1.Height), Color.White);
            spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
