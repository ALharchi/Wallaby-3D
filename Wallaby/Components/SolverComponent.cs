using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;

namespace Wallaby.Components
{
    public class SolverComponent : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the SolverComponent class.
        /// </summary>
        public SolverComponent()
          : base("Solver", "Solver",
              "The main component where goals are applied.",
              "Wallaby", "Solver")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Goals", "Goals", "Goal Objects", GH_ParamAccess.tree) ;
            pManager.AddNumberParameter("Threshold", "Threshold", "", GH_ParamAccess.item);
            pManager.AddNumberParameter("Tolerance", "Tolerance", "", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Reset", "Reset", "Reset the computation", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Iteration", "Iteration", "Iterations count", GH_ParamAccess.item);
            pManager.AddPointParameter("Points", "Points", "Points", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            Wallaby.Solver solver = new Solver();

            CoPlanarGoal myGoal = new CoPlanarGoal(new List<Point3d>(), 10);

            solver.Goals.Add(myGoal);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("DD26BFE2-0A22-4287-BE15-93AA397D7787"); }
        }
    }
}