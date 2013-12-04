using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ParticleSimulation;

namespace ParticleSimulation.View
{
    class Camera
    {
        private int screenWidth;
        private int screenHeight;

        private float scaleX;
        private float scaleY;
        private float widthMargin = 0;
        private float heightMargin = 0;

        internal Camera(Viewport viewPort)
        {
            //Sätter bredd och höjd i pixlar
            this.screenWidth = viewPort.Width;
            this.screenHeight = viewPort.Height;

            //Räknar ut skalan bassserat på pixel-bredd och höjd multiplicerat med
            //logisk bredd och höjd
            this.scaleX = (float)screenWidth / XNAController.boardLogicWidth;
            this.scaleY = (float)screenHeight / XNAController.boardLogicHeight;

            //Sätter bredd och höjd till samma storlek basserat på den minsta av de två
            if (scaleY < scaleX)
            {
                widthMargin = (screenWidth - screenHeight) / 2;
                scaleX = scaleY;
            }
            else if (scaleY > scaleX)
            {
                heightMargin = (screenHeight - screenWidth) / 2;
                scaleY = scaleX;
            }
        }

        //Returnerar en Rektangel med visuella kordinater
        internal Rectangle getSplitterCoordinates(float modelX, float modelY, float modelDimention)
        {
            return new Rectangle(
                                    (int)((modelX * scaleX) - (modelDimention * scaleX / 2)) + (int)(widthMargin),
                                    (int)((modelY * scaleY) - (modelDimention * scaleY / 2)) + (int)(heightMargin),
                                    (int)(modelX + (modelDimention * scaleX)),
                                    (int)(modelY + (modelDimention * scaleY))
                                );
        }

        //Reurnerar skalan i X-led, men eftersom X och Y är lika stora så spelar det ingen roll
        internal int GetScale()
        {
            return (int)scaleX;
        }
    }
}
