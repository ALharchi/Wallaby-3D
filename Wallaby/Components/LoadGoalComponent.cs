using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class LoadGoalComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the LoadGoalComponent class.
        /// </summary>
        public LoadGoalComponent()
          : base("Load", "Load",
              "Description",
              "Wallaby", "Goals")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddPointParameter("Point", "P", "Point to anchor.", GH_ParamAccess.item);
            pManager.AddVectorParameter("Force", "F", "Force to be applied on this point.", GH_ParamAccess.item, new Vector3d(0,0,1));
            pManager.AddNumberParameter("Strength", "S", "Goal strength.", GH_ParamAccess.item, 1);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Goal", "G", "Load goal.", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            Point3d inputPoint = new Point3d();
            Vector3d force = new Vector3d();
            double strength = 0;

            DA.GetData(0, ref inputPoint);
            DA.GetData(1, ref force);
            DA.GetData(2, ref strength);

            LoadGoal myGoal = new LoadGoal(inputPoint, force, strength);

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
            get { return new Guid("BC46C02C-5C8E-49C8-AF38-8F300445B4CF"); }
        }
    }
}