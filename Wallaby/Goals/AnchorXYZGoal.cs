using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class AnchorXYZGoal : GoalObject
    {
        public Point3d Particule { get; set; }

        public AnchorXYZGoal() 
        { 
        
        }

        public override void Calculate(List<Particle> p)
        {

        }

    }
}
