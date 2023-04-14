using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class LengthGoalComponent : GH_Component
    {
 
        public LengthGoalComponent() : base("Length", "Length", "Description", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return Properties.Resources.LengthIcon; } }
        public override Guid ComponentGuid { get { return new Guid("7A76F961-F341-4382-99FF-DA0EBA4C68E7"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("Line", "Ln", "Line.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "L", "Length. If nothing is provided, starting length will be used.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 10);
            pManager[1].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "Length goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            Line inputLine = new Line();
            double length = 0;
            double strength = 0;

            DA.GetData(0, ref inputLine);
            DA.GetData(1, ref length);
            DA.GetData(2, ref strength);

            //if (targetPoint == null)
            length = inputLine.Length;

            LengthGoal myGoal = new LengthGoal(inputLine, length, strength);

            DA.SetData(0, myGoal);

        }

    }
}