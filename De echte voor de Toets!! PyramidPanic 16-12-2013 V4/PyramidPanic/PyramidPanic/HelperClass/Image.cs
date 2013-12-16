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
    public class Image
    {
        //fields
        //Maak een variable aan van het type Texture2D met de naam texture
        private Texture2D texture;
        //Maak een rectangle voor het detecteren van collisions
        private Rectangle rectangle;
        //Maak een variable aan om de game in op te slaan.
        private PyramidPanic game;
        //Maak een variable aan van het type Color met de naam color
        private Color color = Color.White;

        //Propperties
        public Color Color
        { 
            get { return this.color; }
            set { this.color = value; }
        }

        //Maak een property voor het rectangle field.
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }
        //constructor
        public Image(PyramidPanic game, String pathNameAsset,Vector2 position)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(pathNameAsset);
            this.rectangle = new Rectangle((int) position.X,
                                           (int) position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
            
        }

        //Update

        //draw
        public void Draw(GameTime gametime){
            this.game.spritebatch.Draw(this.texture, this.rectangle, this.color);
        }

        //Helper Methodes

    }
}
