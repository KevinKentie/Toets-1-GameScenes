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
    public class Menu
    {
        //fields
        //Maak een enumaration voor de mogelijke buttons
        private enum Buttons { Start, Load, Scores, Help, Quit };
        //                       1      2      3     4      5
        //Maak een variabele van het type Buttons en geef hem de waarde Buttons.Start
        private Buttons buttonActive = Buttons.Start;

        private Image start;
        private Image load;
        private Image scores;
        private Image help;
        private Image quit;

        //Maak een variable van het type Pyramid panic
        private PyramidPanic game;

        private Color activeColor = Color.SandyBrown;

        //Maak een variabele buttenlist van het type List<Image>
        private List<Image> buttenList;

        private KeyboardState ks;

        //constructor
        public Menu(PyramidPanic game)
        {
            this.ks = Keyboard.GetState();
            this.game = game;
            this.Initialize();
        }


        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        public void LoadContent()
        {
            this.buttenList = new List<Image>();
            this.buttenList.Add(this.start = new Image(game, @"StartScene\Button_start", new Vector2(10f, 410)));
            this.buttenList.Add(this.load = new Image(game, @"StartScene\Button_load", new Vector2(140f, 410)));
            this.buttenList.Add(this.scores = new Image(game, @"StartScene\Button_scores", new Vector2(270f, 410)));
            this.buttenList.Add(this.help = new Image(game, @"StartScene\Button_help", new Vector2(400f, 410)));
            this.buttenList.Add(this.quit = new Image(game, @"StartScene\Button_quit", new Vector2(530f, 410)));
            
            
            
            
        }

        //Update
        public void Update()
        {

            //Maak een switch case constructie voor de variable buttonActive
            //Deze if - instructie checkt of er op de rechter rechterpijltoets wordt gedrukt.
            //De actie die daarop volgt is het ophogen van de variabele buttenActive
            if (Input.EdgeDetectKeyDown(Keys.Right))
            {
                this.buttonActive++;
                this.ChangeButtonColorToNormal();
            }
            if (Input.EdgeDetectKeyDown(Keys.Left))
            {
                this.buttonActive--;
                this.ChangeButtonColorToNormal();
            }


            switch (this.buttonActive)
            {
                case Buttons.Start:
                    this.start.Color = Color.Violet;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.PlayScene;
                    }
                    break;
                case Buttons.Load:
                    this.load.Color = Color.Yellow;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.LoadScene;
                    }
                    break;
                case Buttons.Scores:
                    this.scores.Color = Color.Aquamarine;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.ScoreScene;
                    }
                    break;
                case Buttons.Help:
                    this.help.Color = Color.IndianRed;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.HelpScene;
                    }
                    break;
                case Buttons.Quit:
                    this.quit.Color = this.activeColor;
                    if (Input.EdgeDetectKeyDown(Keys.Enter))
                    {
                        this.game.IState = this.game.QuitScene;
                    }
                    break;
            }
            if (this.start.Rectangle.Intersects(Input.MouseRect()))
            {
                if (Input.EdgeDetectMousePressLeft())
                {
                    this.game.IState = this.game.PlayScene;
                }
                this.ChangeButtonColorToNormal();
                this.buttonActive = Buttons.Start;
                this.start.Color = Color.Violet;
                
            }
            else
                if (this.load.Rectangle.Intersects(Input.MouseRect()))
                {
                    if (Input.EdgeDetectMousePressLeft())
                    {
                        this.game.IState = this.game.LoadScene;
                    }
                    this.ChangeButtonColorToNormal();
                    this.buttonActive = Buttons.Load;
                    this.load.Color = Color.Yellow;
                }
                else
                    if (this.scores.Rectangle.Intersects(Input.MouseRect()))
                    {
                        if (Input.EdgeDetectMousePressLeft())
                        {
                            this.game.IState = this.game.ScoreScene;
                        }
                        this.ChangeButtonColorToNormal();
                        this.buttonActive = Buttons.Scores;
                        this.scores.Color = Color.YellowGreen;
                    }
                    else
                        if (this.help.Rectangle.Intersects(Input.MouseRect()))
                        {
                            if (Input.EdgeDetectMousePressLeft())
                            {
                                this.game.IState = this.game.HelpScene;
                            }
                            this.ChangeButtonColorToNormal();
                            this.buttonActive = Buttons.Help;
                            this.help.Color = Color.Red;
                        }
                        else
                            if (this.quit.Rectangle.Intersects(Input.MouseRect()))
                            {
                                if (Input.EdgeDetectMousePressLeft())
                                {
                                    this.game.IState = this.game.QuitScene;
                                }
                                this.ChangeButtonColorToNormal();
                                this.buttonActive = Buttons.Quit;
                                this.quit.Color = Color.SandyBrown;
                            }
        }
        

        //draw
        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.buttenList)
            {
                image.Draw(gameTime);
            }
        }

        //Helper method voor het met wit licht beschijnen van de buttons.
        private void ChangeButtonColorToNormal()
        {
            //We doorlopen het this.buttonList object (List<Image> ) met een foreach instructie
            //En we roepen ieder image-opject de propertie Color op en geven deze de waarde Color.White
            foreach (Image image in this.buttenList)
            {
                image.Color = Color.White;
            }
        }
    }
}
