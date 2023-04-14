using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class AngleGoalComponent : GH_Component
    {
 
        public AngleGoalComponent() : base("Angle", "Angle", "Description", "Wallaby", "Goals") { }
        protected override System.Drawing.Bitmap Icon { get { return Properties.Resources.LengthIcon; } }
        public override Guid ComponentGuid { get { return new Guid("11aba32b-f2a3-4a1a-b3a7-fd5981b82553"); } }

        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("LineA", "LnA", "Line.", GH_ParamAccess.item);
            pManager.AddLineParameter("LineB", "LnB", "Line.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Rest Angle", "RA", "Resting angle in radian. If empty, the existing angle will used.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 1);
            pManager[2].Optional = true;
        }

        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "Angle goal.", GH_ParamAccess.item);
        }

        protected override void SolveInstance(IGH_DataAccess DA)
        {

            Line inputLineA = new Line();
            Line inputLineB = new Line();
            double restAngle = double.NaN;
            double strength = 0;

            DA.GetData(0, ref inputLineA);
            DA.GetData(1, ref inputLineB);
            DA.GetData(2, ref restAngle);
            DA.GetData(3, ref strength);


            if (double.IsNaN(restAngle))
            {
                Vector3d vecA = inputLineA.To - inputLineA.From;
                Vector3d vecB = inputLineB.To - inputLineB.From;
                restAngle = Vector3d.VectorAngle(vecA, vecB);
            }
            
            AngleGoal myGoal = new AngleGoal(inputLineA, inputLineB, restAngle, strength);

            DA.SetData(0, myGoal);

        }

    }
}