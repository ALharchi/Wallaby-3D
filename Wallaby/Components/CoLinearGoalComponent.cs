using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class CoLinearGoalComponent : GH_Component
    {
        public CoLinearGoalComponent() : base("CoLinear", "CoLinear", "Keep a set of points colinear.", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("BD4E4947-8804-45D9-88CE-995E368896F6"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Points", "P", "P", GH_ParamAccess.list);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 10);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "CoLinear goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            List<Point3d> inputPoints = new List<Point3d>();
            double strength = 0;

            DA.GetDataList(0, inputPoints);
            DA.GetData(1, ref strength);

            CoLinearGoal myGoal = new CoLinearGoal(inputPoints, strength);

            DA.SetData(0, myGoal);
        }

        
    }
}