using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class CoPlanarGoalComponent : GH_Component
    {
        public CoPlanarGoalComponent() : base("CoPlanar", "CoPlanar", "Description", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("D6044D6D-2241-4FC0-B287-E1CC638E6362"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "P", GH_ParamAccess.list);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 10);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "CoPlanar goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Point3d> inputPoints = new List<Point3d>();
            double strength = 0;

            DA.GetDataList(0, inputPoints);
            DA.GetData(1, ref strength);

            CoPlanarGoal myGoal = new CoPlanarGoal(inputPoints, strength);

            DA.SetData(0, myGoal);
        }

        
    }
}