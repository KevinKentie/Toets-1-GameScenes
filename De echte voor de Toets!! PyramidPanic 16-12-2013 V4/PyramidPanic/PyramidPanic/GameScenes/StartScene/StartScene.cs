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
    public class StartScene : IState //De class StartScene implementeerd de interface IState
    {
        //Fields van de class StartScene
        private PyramidPanic game;

        //Maak een variabele aan de image class genaamd background
        private Image background, title;

        //Maak een variable aan van de Menu class genaamd menu
        private Menu menu;

        //Constructor van de StartScene-class krijgt een object mee van het type PyramidPanic 
        public StartScene(PyramidPanic game)
        {
            this.game = game;
            //Roep de Initialize methode aan
            this.Initialize();
        }

        //Initialize methode. deze methode initialiseert (geeft startwaarden aan variabelen)
        //Void wil zeggen dat er niets terug gegeven word
        public void Initialize()
        {
            //Roep de LoadContent methode aan
            this.LoadContent();
        }

        //LoadContent methode. Deze methode maakt nieuwe objecten aan van verschillende
        //classes
        public void LoadContent()
        {
            //Nu maken we TWEE object aan(instantie) van de class Image
            this.background = new Image(this.game, @"StartScene\background", new Vector2(0f,0f));
            this.title = new Image(this.game, @"StartScene\title", new Vector2(100f,30f));
            this.menu = new Menu(this.game);
        }
        
        // Update methode. Deze methode wordt normaal 60 maal per seconde aangeroepen
        // en update alle variabelen, methods enz.......
        public void Update(GameTime gameTime)
        {
            this.menu.Update();
        }

        // Draw methode. Deze methode wordt normaal 60 maal per seconde aangeroepen en
        // tekent de textures p[ het canvas
        public void Draw(GameTime gameTime)
        {
            
            this.game.GraphicsDevice.Clear(Color.Yellow);
            this.background.Draw(gameTime);
            this.title.Draw(gameTime);
            this.menu.Draw(gameTime);
            
        }
    }
}
