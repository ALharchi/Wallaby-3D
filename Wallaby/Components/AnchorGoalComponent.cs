using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class AnchorGoalComponent : GH_Component
    {

        public AnchorGoalComponent() : base("Anchor", "Anchor", "Description", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return Properties.Resources.AnchorIcon; } }
        public override Guid ComponentGuid { get { return new Guid("F3293DD5-E72A-4DFD-A87A-74BC9B410B0B"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to anchor.", GH_ParamAccess.item);
            pManager.AddPointParameter("Target", "T", "Location to pull the anchor to. If empty, the same location will be used.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 10000);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "Anchor goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d inputPoint = new Point3d();
            Point3d targetPoint = new Point3d();
            double strength = 0;

            DA.GetData(0, ref inputPoint);
            DA.GetData(1, ref targetPoint);
            DA.GetData(2, ref strength);

            //if (targetPoint == null)
            targetPoint = inputPoint;

            AnchorGoal myGoal = new AnchorGoal(inputPoint, targetPoint, strength);

            DA.SetData(0, myGoal);
        }


    }
}