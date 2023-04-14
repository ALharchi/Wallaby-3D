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

        public AnchorGoal(Point3d point, Point3d target, double strength)
        {
            this.Positions = new List<Point3d>() { point };
            this.Target = target;
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
