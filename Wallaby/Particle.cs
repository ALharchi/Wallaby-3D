using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.ApplicationSettings;
using Rhino.Geometry;

namespace Wallaby
{
    [Serializable]
    public class Particle
    {
        public Point3d Position;
        public List<Vector3d> Velocities;
        public List<double> Strengths;
        //public Vector3d Acceleration;

        public Particle(Point3d position)//, Vector3d acceleration) 
        {
            this.Position = position;
            this.Velocities = new List<Vector3d>();
            this.Strengths = new List<double>();
            //this.Acceleration = acceleration;
        }
    }
}
