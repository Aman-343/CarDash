using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDash
{
    /// <summary>
    /// This class is parent class for all other scene class.
    /// </summary>
    public class GameScene : DrawableGameComponent
    {
        public List<GameComponent> components { get; set; }

        /// <summary>
        ///  this method is use to show Game scene
        /// </summary>
        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        /// <summary>
        /// this method is use to hide Game scene
        /// </summary>
        public virtual void hide()
        {
            this.Visible = false;
            this.Enabled = false;
        }

        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }

            base.Draw(gameTime);
        }
    }
}
