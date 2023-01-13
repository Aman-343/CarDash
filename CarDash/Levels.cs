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
    /// This class is use to show Levels and its functionality in action scene.
    /// </summary>
    public class Levels : DrawableGameComponent
    {
        public SpriteBatch spriteBatch { get; set; }
        public Texture2D tex { get; set; }
        public Vector2 position { get; set; }
        public float scale { get; set; } = 1;
        public float rotation { get; set; }

        private const float ROTATION_FACTOR = 0.05F;

        public Vector2 origin { get; set; }
        private Rectangle srcRect;

        private float SCALE_FACTOR = 0.04F;
        private const float MAX_SCALE = 2.0F;
        private const float MIN_SCALE = 0.01F;

        public Levels(Game game, SpriteBatch spriteBatch, Texture2D tex, Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.position = position;
            this.srcRect = new Rectangle(0, 0, tex.Width, tex.Height);
            this.origin = new Vector2(tex.Width/2, tex.Height/2);
        }

        public override void Update(GameTime gameTime)
        {
            //rotation += ROTATION_FACTOR;
            scale += SCALE_FACTOR;

            if (scale > MAX_SCALE )
            {
                SCALE_FACTOR = -SCALE_FACTOR;
            }
            else if(scale < MIN_SCALE)
            {
                SCALE_FACTOR = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, position, srcRect, Color.White, rotation, origin, scale, SpriteEffects.None, 1);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
