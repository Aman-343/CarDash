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
    /// This class is display the about scene with my name and student id.
    /// </summary>
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private ToString AboutMe;
        private Game1 g;
        private SpriteFont bigFont;
        public AboutScene(Game game) : base(game)
        {

            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;

            bigFont = g.Content.Load<SpriteFont>("fonts/bigFont");

            AboutMe = new ToString(game, spriteBatch, bigFont, " \n Name : Aman Saklecha \n Id: 8772244", new Vector2(BackGround.stage.X/2-200, BackGround.stage.Y/2-90), Color.Black);
            this.components.Add(AboutMe);
        }
    }
}
