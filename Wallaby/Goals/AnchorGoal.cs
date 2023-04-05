using Rhino.ApplicationSettings;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class AnchorGoal : GoalObject
    {
        public Point3d Particule { get; set; }


        public AnchorGoal(Point3d p, double strength)
        { 

        }
        public override void Calculate(List<Particle> p)
        {

        }

    }
}
