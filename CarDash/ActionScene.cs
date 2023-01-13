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
using System.Windows.Forms;

namespace CarDash
{
    /// <summary>
    /// This class is used to display the main game and work on functionality of game.
    /// </summary>
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Game1 g;
        private Car car;
        private BackGround sb, sb2;
        private ObstacelCar obstacelCar1, obstacelCar0;
        private ObstacelCar obstacelCar2 = null;
        private CollisionManager cm;
        private ToString scorestring, PowerString;
        private Texture2D carTex, backGround, level1Tex, level2Tex, powerTex;
        private Vector2 horizontalSpeed, verticalSpeed, speed, speed2;
        private Vector2 position, position2, carPos, powerPos;
        private Powers power;
        private Rectangle srcRect;
        private Levels level1, level2;
        private Song backgroundMusic;
        private SpriteFont hilight, scoreFont;

        Random r = new Random();    

        public ActionScene(Game game) : base(game)
        {


            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;


            hilight = g.Content.Load<SpriteFont>("fonts/hilightFont");
            scoreFont = g.Content.Load<SpriteFont>("fonts/scoreFont");
            level1Tex = g.Content.Load<Texture2D>("images/level1");
            level2Tex = g.Content.Load<Texture2D>("images/level2");
            powerTex = g.Content.Load<Texture2D>("images/star");
            backGround = game.Content.Load<Texture2D>("images/RaceTrack");
            carTex = game.Content.Load<Texture2D>("images/car");


            srcRect = new Rectangle(0, 0, 610, 630);
            position = new Vector2(BackGround.stage.X/ 2 - backGround.Width / 2, 0);
            speed = new Vector2(0, 2);
            sb = new BackGround(game, spriteBatch, backGround, srcRect, position, speed);
            position2 = new Vector2(BackGround.stage.X / 2 - backGround.Width / 2, -BackGround.stage.Y);
            speed2 = new Vector2(0, 2);
            sb2 = new BackGround(game, spriteBatch, backGround, srcRect, position2, speed2);
            carPos = new Vector2(BackGround.stage.X / 2 - carTex.Width / 2, BackGround.stage.Y - carTex.Height);
            powerPos = new Vector2(BackGround.stage.X / 2 - carTex.Width / 2, BackGround.stage.Y - carTex.Height);
            horizontalSpeed = new Vector2(4, 0);
            verticalSpeed = new Vector2(0, 4);
            car = new Car(game, spriteBatch, carTex, carPos, horizontalSpeed, verticalSpeed);
            obstacelCar0 = new ObstacelCar(game, spriteBatch, carTex, new Vector2(r.Next(200, 390), -carTex.Height), verticalSpeed);
            obstacelCar1 = new ObstacelCar(game, spriteBatch, carTex, new Vector2(r.Next(400, 560), -2 * carTex.Height - 20), verticalSpeed);
            obstacelCar2 = new ObstacelCar(game, spriteBatch, carTex, new Vector2(r.Next(400, 560), -3 * carTex.Height - 30), verticalSpeed);
            power = new Powers(game, spriteBatch, powerTex, new Vector2(r.Next(250, 450), -powerTex.Height), verticalSpeed);
            cm = new CollisionManager(game, car, obstacelCar0, obstacelCar1, obstacelCar2, sb, sb2, backgroundMusic, power);
            scorestring = new ToString(game, spriteBatch, scoreFont, "Score: ", Vector2.Zero, Color.Black);
            level1 = new Levels(game, spriteBatch, level1Tex, new Vector2(BackGround.stage.X / 2, BackGround.stage.Y / 2));
            level2 = new Levels(game, spriteBatch, level2Tex, new Vector2(BackGround.stage.X / 2, BackGround.stage.Y / 2));
            PowerString = new ToString(g, spriteBatch, hilight, "Power On ", new Vector2(BackGround.stage.X / 2 + backGround.Width / 4, 0), Color.Black);


            this.components.Add(sb2);
            this.components.Add(sb);
            this.components.Add(obstacelCar0);
            this.components.Add(car);
            this.components.Add(obstacelCar1);
            this.components.Add(power);
            this.components.Add(cm);
            this.components.Add(scorestring);
            this.components.Add(level1);
            this.components.Add(level2);
            this.components.Add(PowerString);

            PowerString.Visible = false;
            power.Visible = false;
            power.Enabled = false;
            level2.Enabled = false;
            level2.Visible = false;

        }
        /// <summary>
        /// This method is used to restart the game 
        /// </summary>
        public void restart()
        {
            this.components.Remove(cm);
            this.components.Remove(sb);
            this.components.Remove(sb2);
            this.components.Remove(obstacelCar0);
            this.components.Remove(obstacelCar1);
            this.components.Remove(obstacelCar2);
            this.components.Remove(car);

            speed = new Vector2(0, 2);
            speed2 = new Vector2(0, 2);
            horizontalSpeed = new Vector2(4, 0);
            verticalSpeed = new Vector2(0, 4);
            car = new Car(g, spriteBatch, carTex, carPos, horizontalSpeed, verticalSpeed);
            sb = new BackGround(g, spriteBatch, backGround, srcRect, position, speed);
            sb2 = new BackGround(g, spriteBatch, backGround, srcRect, position2, speed2);
            obstacelCar0 = new ObstacelCar(g, spriteBatch, carTex, new Vector2(r.Next(200, 390), -carTex.Height), verticalSpeed);
            obstacelCar1 = new ObstacelCar(g, spriteBatch, carTex, new Vector2(r.Next(400, 560), -2 * carTex.Height - 20), verticalSpeed);
            obstacelCar2 = new ObstacelCar(g, spriteBatch, carTex, new Vector2(r.Next(200, 560), -3 * carTex.Height - 20), verticalSpeed);
            backgroundMusic = g.Content.Load<Song>("sounds/BackGroundMusic");
            power = new Powers(g, spriteBatch, powerTex, new Vector2(r.Next(250, 450), -powerTex.Height), verticalSpeed);
            cm = new CollisionManager(g, car, obstacelCar0, obstacelCar1, obstacelCar2, sb, sb2, backgroundMusic, power);
            level1 = new Levels(g, spriteBatch, level1Tex, new Vector2(BackGround.stage.X / 2, BackGround.stage.Y / 2));
            level2 = new Levels(g, spriteBatch, level2Tex, new Vector2(BackGround.stage.X / 2, BackGround.stage.Y / 2));
            PowerString = new ToString(g, spriteBatch, hilight, "Power On ", new Vector2(BackGround.stage.X / 2 + backGround.Width / 4, 0), Color.Black);


            this.components.Add(sb2);
            this.components.Add(sb);

            this.components.Add(obstacelCar0);
            this.components.Add(obstacelCar1);
            this.components.Add(obstacelCar2);
            obstacelCar2.Enabled = false;
            this.components.Add(car);
            this.components.Add(power);
            power.Visible = false;
            power.Enabled = false;

            this.components.Add(cm);
            this.components.Add(level1);
            this.components.Add(level2);
            level2.Enabled = false;
            level2.Visible = false;

            this.components.Add(PowerString);
            PowerString.Visible = false;


            MediaPlayer.Play(backgroundMusic);

            return;
        }

        public override void Update(GameTime gameTime)
        {
            float score = car.score;
            scorestring.message = "Score: " + car.score.ToString("N0");

            if (car.score > 50.05)
            {
                obstacelCar2.Enabled = true;
                level2.Enabled=true;
                level2.Visible=true;
                power.Enabled = true;
                power.Visible = true;

            }

            if(cm.PowerUp == true)
            {
                PowerString.Visible = true;
                
            }
            else
            {
                PowerString.Visible = false;
            }
            base.Update(gameTime);
        }
    }
}
