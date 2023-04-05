using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Wallaby
{
    public abstract class GoalObject
    {
        public List<Particle> Particles = new List<Particle>();
        public List<Point3d> Positions { get; set; }

        public double Strength;

        public virtual void Calculate() 
        { 
        
        }
    }
}
