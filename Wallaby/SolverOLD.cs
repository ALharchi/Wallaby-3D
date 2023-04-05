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
    public class SolverOLD
    {
        public List<GoalObject> Goals { get; set; }
        public List<Particle> Particles { get; set; }

        //public double Tolerance;
        public double Threshold;
        public int Interations;



        public SolverOLD(List<GoalObject> goals)
        {
            this.Goals = goals;
            CreateParticles();
        }

        public void CreateParticles()
        {
            foreach (GoalObject goal in Goals)
            {
                foreach (Point3d p in goal.Positions)
                {
                    Particle particle = new Particle(p);
                    this.Particles.Add(particle);
                }
            }
        }

        public void Update(int iterationsCount)
        {
            /*
            // Apply all the goals
            foreach (GoalObject goal in Goals)
            {
                goal.Calculate(this.Particles);

                // get velocities and add to particles

                // first find the particles in questions

                List<Particle> affectedParticles = new List<Particle>();

                for (int i = 0; i < goal.Positions.Count; i++)
                { 
                  //  int particleIndex = this.Particles.IndexOf(goal.Positions[i]);
                }

            }
            */
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

    }
}
