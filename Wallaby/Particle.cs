using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.ApplicationSettings;
using Rhino.Geometry;

namespace Wallaby
{
    public struct Particle
    {
        public Point3d Position;
        public Vector3d Velocity;
        //public Vector3d Acceleration;

        public Particle(Point3d position, Vector3d velocity)//, Vector3d acceleration) 
        {
            this.Position = position;
            this.Velocity = velocity; 
            //this.Acceleration = acceleration;
        }
    }
}
