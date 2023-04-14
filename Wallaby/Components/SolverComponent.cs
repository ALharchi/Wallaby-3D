using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wallaby.Components
{

    public class SolverComponent : GH_Component
    {
        public SolverComponent() : base("Wallaby Solver", "Wallaby Solver", "The main component where goals are applied.", "Wallaby", "Solver") { }
        protected override System.Drawing.Bitmap Icon { get { return Wallaby.Properties.Resources.SolverIcon; } }
        public override Guid ComponentGuid { get { return new Guid("DD26BFE2-0A22-4287-BE15-93AA397D7787"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Goals", "G", "Goal Objects", GH_ParamAccess.list) ;
            pManager.AddNumberParameter("Threshold", "Th", "Stop when average movement is less that this value.", GH_ParamAccess.item, 0.000001);
            pManager.AddIntegerParameter("MaxIterations", "I", "Maximum number of iterations.", GH_ParamAccess.item, 5);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Debug", "D", "Debugging", GH_ParamAccess.item);
            pManager.AddPointParameter("Points", "P", "Points", GH_ParamAccess.list);
            pManager.AddGeometryParameter("Objects", "O", "Goals tree output", GH_ParamAccess.list);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<GoalObject> myGoals = new List<GoalObject>();
            double threshold = 0;
            int maxIterations = 0;

            DA.GetDataList(0, myGoals);
            DA.GetData(1, ref threshold);
            DA.GetData(2, ref maxIterations);

            Solver solver = new Solver(myGoals);

            solver.Update(maxIterations);

            List<Point3d> particlesAsPoints = solver.Particles.Select(p => p.Position).ToList();
            
            DA.SetData(0, solver);
            DA.SetDataList(1, particlesAsPoints);
            DA.SetDataList(2, solver.GetGeometryObjects());
        }

        
    }
}