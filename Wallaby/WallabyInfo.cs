using Grasshopper;
using Grasshopper.Kernel;
using System;
using System.Drawing;

namespace Wallaby
{
    public class WallabyInfo : GH_AssemblyInfo
    {
        public override string Name => "Wallaby 3D";
        public override Bitmap Icon => null;
        public override string Description => "Wallaby 3D is a simple geometric constraint solver. This project is a teaching material for a Grasshopper plugin developement course.";
        public override Guid Id => new Guid("c1f07018-68c1-4429-9f97-cdb651923132");
        public override string AuthorName => "Ayoub Lharchi";
        public override string AuthorContact => "alha@kglakademi.dk";
    }
}