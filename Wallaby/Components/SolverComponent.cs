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
          : base("Wallaby Solver", "Wallaby Solver",
              "The main component where goals are applied.",
              "Wallaby", "Solver")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddGenericParameter("Goals", "G", "Goal Objects", GH_ParamAccess.tree) ;
            pManager.AddNumberParameter("Threshold", "Th", "Stop when average movement is less that this value.", GH_ParamAccess.item, 0.000001);
            //pManager.AddNumberParameter("Tolerance", "T", "Points closer than this distance will be combined into a single particle.", GH_ParamAccess.item, 0.0001);
            pManager.AddNumberParameter("MaxIterations", "I", "Maximum number of iterations.", GH_ParamAccess.item);
            //pManager.AddBooleanParameter("Reset", "Reset", "Reset the computation", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddIntegerParameter("Iterations", "I", "Iterations count", GH_ParamAccess.item);
            pManager.AddPointParameter("Points", "P", "Points", GH_ParamAccess.list);
            pManager.AddGenericParameter("Objects", "O", "Goals tree output", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {

            //Solver solver = new Solver();




            //this.ExpireSolution(true);

            //CoPlanarGoal myGoal = new CoPlanarGoal(new List<Point3d>(), 10);

            //solver.Goals.Add(myGoal);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                return Wallaby.Properties.Resources.SolverIcon;
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