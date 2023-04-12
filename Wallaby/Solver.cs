using Eto.Forms;
using Grasshopper.Kernel.Components;
using Rhino.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallaby
{
    public class Solver
    {
        public List<GoalObject> Goals { get; set; }
        public List<Particle> Particles { get; set; }
        public List<GeometryObject> GeometryObjects { get; set; }


        public double Tolerance;
        public double Threshold;
        public int Interations;

        public Solver(List<GoalObject> goals)
        {
            this.Goals = goals;
            this.Particles = new List<Particle>();
            this.GeometryObjects = new List<GeometryObject>();
            CreateParticles();
            CreateGeometryObjects();
        }

        public void CreateParticles()
        {
            foreach (GoalObject goal in Goals)
            {
                foreach (Point3d p in goal.Positions)
                {
                    // first we check if the point is not already there
                    bool existAlready = Particles.Any(pt => pt.Position.ToString() == p.ToString());

                    // if it doesn't exist, we create it and add it to our particles list and assign the particle to the goal
                    if (!existAlready)
                    {
                        Particle myParticle = new Particle(p);
                        this.Particles.Add(myParticle);
                        goal.Particles.Add(myParticle);
                    }
                    // if exist, we retrieve it, and assign it to the goal
                    else
                    {
                        Particle myParticle = Particles.FirstOrDefault(pt => pt.Position.ToString() == p.ToString());
                        goal.Particles.Add(myParticle);
                    }
                }
            }
        }

        public void CreateGeometryObjects()
        {
            foreach (GoalObject goal in Goals)
            {
                goal.AddGeometryObjects(this.GeometryObjects);
            }
        }

        public List<dynamic> GetGeometryObjects()
        {
            List<dynamic> returnGeometryObjects = new List<dynamic>();

            foreach (GeometryObject geoObj in this.GeometryObjects)
            {
                switch (geoObj.Type)
                {
                    case GeometryObjectType.Line:
                        returnGeometryObjects.Add(new Line(geoObj.LineObject[0].Position, geoObj.LineObject[1].Position));
                        break;
                    case GeometryObjectType.Mesh:
                        // implement Mesh
                        break;
                }
            }

            return returnGeometryObjects;
        }


        public void Update(int iterationsCount)
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                //double averageMove = 0;
                foreach (GoalObject goal in Goals)
                {
                    goal.Calculate();
                }

                for (int j = 0; j < Particles.Count; j++)
                {
                    Vector3d targetVelocity = new Vector3d(0, 0, 0);
                    double divider = 0;
                    for (int k = 0; k < Particles[j].Velocities.Count; k++)
                    {
                        targetVelocity += (Particles[j].Velocities[k] * Particles[j].Strengths[k]);
                        divider += Particles[j].Strengths[k];
                    }

                    targetVelocity /= divider;

                    Particles[j].Position += targetVelocity;

                    //averageMove += targetVelocity.Length;
                }
            }
        }

        /*
        public void Update(int iterationsCount)
        {
            // Apply all the goals
            foreach (GoalObject goal in Goals)
            {
                goal.Calculate();

                // get velocities and add to particles

                // first find the particles in questions

                List<Particle> affectedParticles = new List<Particle>();

                for (int i = 0; i < goal.Positions.Count; i++)
                { 
                  //  int particleIndex = this.Particles.IndexOf(goal.Positions[i]);
                }

            }

            


        }

        /// <summary>
        /// Update the position and velocity of all the particules using Verlet integration.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void IntegrateParticles(double deltaTime)
        {

            foreach (Particle particle in Particles)
            {
            
                //var currentPosition = particle.Position;
                //var currentVelocity = particle.Velocity;
                //var currentAcceleration = CalculateAcceleration(particle);
                
                // Predict position at next time step
                //var predictedPosition = currentPosition + currentVelocity * deltaTime + 0.5f * currentAcceleration * deltaTime * deltaTime;

                // Calculate acceleration at predicted position
                //var predictedAcceleration = CalculateAcceleration(new Particle { Position = predictedPosition });

                // Update velocity and position
                //particle.Velocity = currentVelocity + 0.5f * (currentAcceleration + predictedAcceleration) * deltaTime;
                //particle.Position = currentPosition + particle.Velocity * deltaTime + 0.5f * predictedAcceleration * deltaTime * deltaTime;
            
            }

        }
        */
    }
}
