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

        public Point3d OriginalPoint;
        bool MoveX;
        bool MoveY;
        bool MoveZ;

        public AnchorXYZGoal(Point3d point, bool x, bool y, bool z, double strength) 
        {
            this.Positions = new List<Point3d>() { point };
            this.OriginalPoint = point;
            this.MoveX = x;
            this.MoveY = y;
            this.MoveZ = z;
            this.Strength = strength;
        }

        public override void Calculate()
        {
            Vector3d velocity = OriginalPoint - this.Particles[0].Position;

            if (!MoveX)
                velocity.X = 0;
            if (!MoveY)
                velocity.Y = 0;
            if (!MoveZ)
                velocity.Z = 0;

            this.Particles[0].Velocities.Add(velocity);
            this.Particles[0].Strengths.Add(Strength);
        }

    }
}
