using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ParticleSimulation.Model
{
    class Level
    {
        public Vector2 StartPossition { get; private set; }

        //Initierar startpossitionen
        internal Level()
        {
            StartPossition = new Vector2(XNAController.boardLogicWidth / 2, XNAController.boardLogicHeight / 2);
        }
    }
}
