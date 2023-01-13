using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace CarDash
{
    /// <summary>
    /// This class is use to work on functionality of collision of car with other object in action scene.
    /// </summary>
    public class CollisionManager : GameComponent
    {
        private SpriteBatch spriteBatch;
        private Game1 g;
        private Car car;
        private ObstacelCar obstacelCar0;
        private ObstacelCar obstacelCar1;
        private ObstacelCar obstacelCar2;
        private BackGround background1;
        private BackGround background2;
        private Animation explosion;
        private Texture2D explosive;
        public bool PowerUp = false;
        public SoundEffect breakingSound, powerHitSound;
        public Song bgMusic;
        public Powers power;
        public int counter = 0;
        public List<float> highScore = new List<float>();
        public static string fileName = "highScore.Text";
        string path = Path.Combine(Environment.CurrentDirectory,fileName);


        Random r = new Random();
        public CollisionManager(Game game, Car car, ObstacelCar obstacelCar0, ObstacelCar obstacelCar1, ObstacelCar obstacelCar2, BackGround background1, BackGround background2, Song backgroundMusic, Powers power ) : base(game)
        {
            
            this.explosive = game.Content.Load<Texture2D>("images/explosion");
            g = (Game1)game;
            this.spriteBatch = g._spriteBatch;
            this.car = car;
            this.obstacelCar0 = obstacelCar0;
            this.obstacelCar1 = obstacelCar1;
            this.background1 = background1;
            this.background2 = background2;
            this.obstacelCar2 = obstacelCar2;
            this.breakingSound = game.Content.Load<SoundEffect>("sounds/breaking");
            this.powerHitSound = game.Content.Load<SoundEffect>("sounds/powerHit");
            this.bgMusic = backgroundMusic;
            this.power = power;
            
        }

        public override void Update(GameTime gameTime)
        {
            Rectangle carRect = car.getBounds();
            Rectangle obstacelRect0 = obstacelCar0.getBounds();
            Rectangle obstacelRect1 = obstacelCar1.getBounds();
            Rectangle obstacelRect2 = obstacelCar2.getBounds();
            Rectangle powerRect = power.getBounds();


            if ((carRect.Intersects(obstacelRect1) || carRect.Intersects(obstacelRect0) || carRect.Intersects(obstacelRect2)) && PowerUp == false)
            {
                MediaPlayer.Stop();
                breakingSound.Play();
                car.speed = Vector2.Zero;
                obstacelCar0.speed = Vector2.Zero;
                obstacelCar1.speed = Vector2.Zero;
                obstacelCar2.speed = Vector2.Zero;
                background1.speed = Vector2.Zero;
                background2.speed = Vector2.Zero;
                power.speed = Vector2.Zero;
                this.explosion = new Animation(g, spriteBatch, explosive, new Vector2(car.position.X + car.tex.Width/4, car.position.Y +car.tex.Height/4), 3);
                car.position = new Vector2(-100, -100);
                car.Enabled = false;
                g.Components.Add(explosion);
                explosion.restart();
                car.SCORE_FACTOR = 0;
                highScore.Add(car.score);
            }

            if (carRect.Intersects(obstacelRect0) && PowerUp == true)
            {
                powerHitSound.Play();
                obstacelCar0.position = new Vector2(r.Next(150, 300), -car.tex.Height);
                car.score = car.score + 10;
            }

            if (carRect.Intersects(obstacelRect1) && PowerUp == true)
            {
                powerHitSound.Play();
                obstacelCar1.position = new Vector2(r.Next((int)obstacelCar0.position.X, 450), -car.tex.Height);
                car.score = car.score + 10;
            }

            if (carRect.Intersects(obstacelRect2) && PowerUp == true)
            {
                powerHitSound.Play();
                obstacelCar2.position = new Vector2(r.Next((int)obstacelCar1.position.X, 550), -car.tex.Height);
                car.score = car.score + 10;
            }

            if (carRect.Intersects(powerRect) && PowerUp == true)
            {
                power.position = new Vector2(r.Next(200, 550), -1500);
                power.Visible = false;
                PowerUp = true;
                counter = 0;
            }

            if (carRect.Intersects(powerRect) && PowerUp == false)
            {
                power.position = new Vector2(r.Next(200, 550), -1500);
                power.Visible = false;
                PowerUp = true;
                counter = 0;
            }

            counter ++;

            if(counter == 300 && PowerUp == true)
            {
                PowerUp = false;
                power.Visible = true;
                power.position = new Vector2(r.Next(200, 550), -1500);
                
            }

            base.Update(gameTime);
        }
    }
}
