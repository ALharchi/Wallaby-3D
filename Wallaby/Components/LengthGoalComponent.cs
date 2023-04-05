using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class LengthGoalComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the LengthGoalComponent class.
        /// </summary>
        public LengthGoalComponent()
          : base("Length", "Length",
              "Description",
              "Wallaby", "Goals")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddLineParameter("Line", "Ln", "Line.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Length", "L", "Length. If nothing is provided, starting length will be used.", GH_ParamAccess.item);
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 10);
            pManager[1].Optional = true;
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "Length goal.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
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

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("7A76F961-F341-4382-99FF-DA0EBA4C68E7"); }
        }
    }
}