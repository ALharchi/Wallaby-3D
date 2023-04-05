using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby.Goals
{
    public class LoadGoal : GoalObject
    {

        public Vector3d Force;

        public LoadGoal(Point3d point, Vector3d vector, double strength) 
        { 
            this.Force = vector;
            this.Strength = strength;
        }

        public override void Calculate(List<Particle> p)
        {
           
        }

    }
}
