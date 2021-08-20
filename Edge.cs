using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    /// <summary>
    /// Graph edge
    /// </summary>
    class Edge
    {
        public double Feromone { get; set; }

        public double Weight { get; }
        /// <summary>
        /// Storage of additional feromone
        /// </summary>
        public double DFeromone { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="weight">Edge weight</param>
        /// <param name="feromone">Edge feromone (default = 0)</param>
        public Edge(double weight, double feromone=0)
        {
            this.Weight = weight;
            this.Feromone = feromone;
            this.DFeromone = 0;
        }
    }
}
