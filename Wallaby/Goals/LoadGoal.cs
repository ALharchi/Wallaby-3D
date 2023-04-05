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

        public LoadGoal(Point3d p, Vector3d vector, double strength) 
        {
            this.Positions = new List<Point3d>() { p };
            this.Force = vector;
            this.Strength = strength;
        }

        public override void Calculate()
        {
            this.Particles[0].Velocities.Add(Force);
            this.Particles[0].Strengths.Add(Strength);
        }

    }
}
