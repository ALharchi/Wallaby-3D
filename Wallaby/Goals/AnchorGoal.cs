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
        public Point3d Target { get; set; }

        public AnchorGoal(Point3d p, Point3d t, double strength)
        {
            this.Positions = new List<Point3d>() { p };
            this.Target = t;
            this.Strength = strength;
        }
        public override void Calculate()
        {
            Vector3d velocity = Target - this.Particles[0].Position;
            this.Particles[0].Velocities.Add(velocity);
            this.Particles[0].Strengths.Add(Strength);
        }
    }
}
