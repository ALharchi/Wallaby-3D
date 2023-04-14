using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class AnchorXYZGoalComponent : GH_Component
    {
        public AnchorXYZGoalComponent(): base("AnchorXYZ", "AnchorXYZ", "Description", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return null; } }
        public override Guid ComponentGuid { get { return new Guid("D8F77B70-64B8-4BC0-9889-827A08F4F032"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to anchor.", GH_ParamAccess.item);
            pManager.AddBooleanParameter("X", "X", "True to prevent moving X direction.", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Y", "Y", "True to prevent moving X direction.", GH_ParamAccess.item, false);
            pManager.AddBooleanParameter("Z", "Z", "True to prevent moving X direction.", GH_ParamAccess.item, false);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 1000);
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "AnchorXYZ goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d inputPoint = new Point3d();
            bool x = false;
            bool y = false;
            bool z = false;
            double strength = 0;

            DA.GetData(0, ref inputPoint);
            DA.GetData(1, ref x);
            DA.GetData(2, ref y);
            DA.GetData(3, ref z);
            DA.GetData(4, ref strength);

            AnchorXYZGoal myGoal = new AnchorXYZGoal(inputPoint, x, y, z, strength);

            DA.SetData(0, myGoal);
        }

    }
}