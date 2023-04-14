using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Geometry;

namespace Wallaby
{
    public class GeometryObject
    {

        public GeometryObjectType Type { get; set; }
        public GeometryObject(GeometryObjectType type)
        {
            this.Type = type;
        }

        public Particle[] LineObject = new Particle[2];
        public void AddLine(Particle from, Particle to)
        {
            this.LineObject[0] = from;
            this.LineObject[1] = to;
        }

        public void AddMesh()
        {

        }
    }

    public enum GeometryObjectType
    { 
        Line = 0,
        Mesh = 1
    }
}
