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
        public List<Point3d> Positions { get; set; }
        public List<Vector3d> Moves { get; set; }

        public double Strength;

        public abstract void Calculate(List<Particle> p);
    }
}
