//met Using kan je een XNA codebibliotheer gebruiken in je class
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class PyramidPanic : Microsoft.Xna.Framework.Game
    {
        //fields
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private KeyboardState ks, oks;

        //Maak een variable aan van het type StartScene
        private StartScene startScene;

        //Maak een variable aan van het type PlayScene
        private PlayScene playScene;

        //Maak een variable aan van het type HelpScene
        private HelpScene helpScene;

        //Maak een variable aan van het type GameOverScene
        private GameOverScene gameOverScene;

        //Maak een variable aan van het type GameOverScene
        private LoadScene loadScene;

        //Maak een variable aan van het type ScoreScene
        private ScoresScene scoreScene;

        //Maak een variable aan van het type QuitScene
        private QuitScene quitScene;

        //Maak een variable van het type interface IState
        private IState iState;

        #region Properties
        // Properties
        //Maak de interface variabele iState beschikbaar buiten de class d.m.v
        //een property IState
        public IState IState
        {
            get { return this.iState; }
            set { this.iState = value; }
        }

        public QuitScene QuitScene
        {
            get { return this.quitScene; }
        }

        public ScoresScene ScoreScene
        {
            get { return this.scoreScene; }
        }

        //Maak het field this.LoadScene beschikbaar buiten de class d.m.v een
        //property LoadScene
        public LoadScene LoadScene
        {
            get { return this.loadScene; }
        }

        //Maak het field this.StartScene beschikbaar buiten de class d.m.v een
        //property StartScene
        public StartScene StartScene
        {
            get { return this.startScene; }
        }

        //Maak het field this.StartScene beschikbaar buiten de class d.m.v een
        //property PlayScene
        public PlayScene PlayScene
        {
            get { return this.playScene; }
        }

        //Maak het field this.StartScene beschikbaar buiten de class d.m.v een
        //property HelpScene
        public HelpScene HelpScene
        {
            get { return this.helpScene; }
        }

        //Maak het field this.StartScene beschikbaar buiten de class d.m.v een
        //property GameOverScene
        public GameOverScene GameOverScene
        {
            get { return this.gameOverScene; }
        }

        //maakt spritebatch beschikbaar buiten de spritebatch
        public SpriteBatch spritebatch
        {
            get { return this.spriteBatch; }
        }
        #endregion

        //Dit is de constructor. Heeft altijd dezelfde naam als de class
        public PyramidPanic()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //Veranderd de titel vam het canvas
            Window.Title = "Pyramid Panic beta 00.00.00.01";
            //Maakt de muis zichtbaar
            IsMouseVisible = true;
            //Verandert de breedte van het canvas
            this.graphics.PreferredBackBufferWidth = 640;
            //veranderd de hoogte van het canvas
            this.graphics.PreferredBackBufferHeight = 480;
            //past de nieuwe hoogte en breedte aan
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //een spritebatch is nodig voor het tekenen van textures op het canvas
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //We maken nu het object/instantie aan van het type startScene. Dit doe je door
            //de constructor aan te roepen van StartScene class.
            this.startScene = new StartScene(this);

            //We maken nu het object/instantie aan van het type startScene. Dit doe je door
            //de constructor aan te roepen van PlayScene class.
            this.playScene = new PlayScene(this);

            //We maken nu het object/instantie aan van het type helpScene. Dit doe je door
            //de constructor aan te roepen van HelpScene class.
            this.helpScene = new HelpScene(this);

            //We maken nu het object/instantie aan van het type gameOverScene. Dit doe je door
            //de constructor aan te roepen van GameOverScene class.
            this.gameOverScene = new GameOverScene(this);

            //We maken nu het object/instantie aan van het type loadScene. Dit doe je door
            //de constructor aan te roepen van loadScene class.
            this.loadScene = new LoadScene(this);

            //We maken nu het object/instantie aan van het type scoreScene. Dit doe je door
            //de constructor aan te roepen van scoreScene class.
            this.scoreScene = new ScoresScene(this);

            //We maken nu het object/instantie aan van het type quitScene. Dit doe je door
            //de constructor aan te roepen van quitScene class.
            this.quitScene = new QuitScene(this);

            this.iState = this.startScene;

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            this.ks = Keyboard.GetState();

            //zorgt dat je stopt als je de back butten op de gamepad indrukt
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (this.ks.IsKeyDown(Keys.Escape))
                this.Exit();

            this.ks = this.oks;
            Input.Update();
            //De Update methode van het object dat toegewezen is aan het interface object
            //this.IState wordt aangeroepen.
            this.iState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Geeft de achtergrond een kleur
            GraphicsDevice.Clear(Color.DarkRed);
            //Voor een spriteBatch instantie iets kan tekenen moet de Begin() methode
            //aangeroepen worden van de SpriteBatch class.
            this.spriteBatch.Begin();

            //De Draw methode van het object dat toegewezen is aan het interface object
            //this.IState wordt aangeroepen.
            this.iState.Draw(gameTime);

            //Nadat de spriteBatch.Draw() is aangeroepen moet de End() methode van de
            //SpriteBatch class worden aangeroepen
            this.spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
