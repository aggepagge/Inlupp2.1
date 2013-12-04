using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParticleSimulation.Model;
using ParticleSimulation.View;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace ParticleSimulation.View
{
    class ParticleView
    {
        internal ParticleModel m_particleModel;
        internal Camera camera;
        internal GraphicsDevice graphicsDevice;
        internal SplitterSystem splitterSystem;
        internal SpriteBatch spriteBatch;
        internal Texture2D splitterTexture;

        //Konstruktor som initsierar variabler och SplitterSystem-objektet
        internal ParticleView(GraphicsDevice graphDevice, ParticleModel particleModel, 
            ContentManager contentManager, Camera camera, SpriteBatch spriteBatch)
        {
            this.graphicsDevice = graphDevice;
            this.m_particleModel = particleModel;
            this.camera = camera;
            this.spriteBatch = spriteBatch;
            this.splitterSystem = new SplitterSystem(m_particleModel.Level.StartPossition, camera.GetScale());
            LoadContent(contentManager);
        }

        //Funktion för att initsiera om SplitterSystem-objektet med nya kordinater
        //(Om man klickat med musen i fönstret)
        internal void restart(float possX, float possY)
        {
            int scale = camera.GetScale();
            this.splitterSystem = new SplitterSystem(new Vector2(possX / scale, possY / scale), scale);
        }

        //Laddar texturen för splittret
        internal void LoadContent(ContentManager contentManager)
        {
            splitterTexture = contentManager.Load<Texture2D>("ball3");
        }

        //Uppdaterar splittersytem
        internal void UpdateView(float elapsedGameTime)
        {
            splitterSystem.Update(elapsedGameTime);
        }

        //anropar splittersystem's draw-funktion
        internal void Draw(float elapsedGameTime)
        {
            graphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            splitterSystem.Draw(spriteBatch, camera, splitterTexture);

            spriteBatch.End();
        }
    }
}
