using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDash
{
    /// <summary>
    /// This class is use to display Start scene.
    /// </summary>
    public class StartScene : GameScene
    {
        //menu component needs to be created.
        public MenuComponent menu { get; set; }
        Game1 g;
        SpriteBatch spriteBatch;
        string[] menuItems = { "Start Game", "Help", "About", "Quit" };
        public StartScene(Game game) : base(game)
        {
            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;
            SpriteFont regular = game.Content.Load<SpriteFont>("fonts/regularFont");
            SpriteFont hilight = g.Content.Load<SpriteFont>("fonts/hilightFont");
            menu = new MenuComponent(g, spriteBatch, regular, hilight, menuItems);
            this.components.Add(menu);
        }
    }
}
