using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSimulation.Model
{
    class ParticleModel
    {
        public Level Level { get; private set; }

        //Modellen skapar bara en ny Level. Eftersom particklarna inte påverkar modellen 
        //så sker det inte så mycket här
        internal ParticleModel()
        {
            Level = new Level();
        }
    }
}
