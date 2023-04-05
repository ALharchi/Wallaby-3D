using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using Wallaby.Goals;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wallaby.Components
{

    public static class DeepCloneHelper
    {
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }

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
            pManager.AddGenericParameter("Goals", "G", "Goal Objects", GH_ParamAccess.list) ;
            pManager.AddNumberParameter("Threshold", "Th", "Stop when average movement is less that this value.", GH_ParamAccess.item, 0.000001);
            pManager.AddIntegerParameter("MaxIterations", "I", "Maximum number of iterations.", GH_ParamAccess.item, 5);
            //pManager.AddNumberParameter("Tolerance", "T", "Points closer than this distance will be combined into a single particle.", GH_ParamAccess.item, 0.0001);
            //pManager.AddBooleanParameter("Reset", "Reset", "Reset the computation", GH_ParamAccess.item, false);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Debug", "D", "Debugging", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Iterations", "I", "Iterations count", GH_ParamAccess.item);
            pManager.AddPointParameter("Points", "P", "Points", GH_ParamAccess.list);
            pManager.AddGenericParameter("Objects", "O", "Goals tree output", GH_ParamAccess.list);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<GoalObject> myGoals = new List<GoalObject>();
            double threshold = 0;
            int maxIterations = 0;

            DA.GetDataList(0, myGoals);
            DA.GetData(1, ref threshold);
            DA.GetData(2, ref maxIterations);

            List<GoalObject> myGoalsCopy = new List<GoalObject>();

            for (int i = 0; i < myGoals.Count; i++)
            {
                myGoalsCopy.Add(DeepCloneHelper.DeepClone(myGoals[i]));
            }

            Solver solver = new Solver(myGoalsCopy);

            solver.Update(maxIterations);

            DA.SetData(0, solver);

            List<Point3d> particlesAsPoints = solver.Particles.Select(p => p.Position).ToList();
            DA.SetDataList(2, particlesAsPoints);

            DA.SetDataList(3, solver.GetGeometryObjects());
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