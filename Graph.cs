using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingSalesmanProblem_AntAlgorithm
{
    /// <summary>
    /// Graph
    /// </summary>
    class Graph
    {
        private readonly Edge[,] _edges;
        private readonly int _size;

        public Edge[,] Edges => _edges;
        public int Size => _size;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="m">Distance matrix</param>
        public Graph(int[,] m)
        {
            _size = (int)Math.Sqrt(m.Length);
            _edges = new Edge[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    _edges[i, j] = new Edge(m[i, j], 0);
                    _edges[j, i] = new Edge( m[i, j], 0);
                }
            }
        }

        /// <summary>
        /// Set feromone for each edge
        /// </summary>
        /// <param name="startFeromone">Start amount of feromone</param>
        public void SetFeromones(double startFeromone)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    _edges[i, j].Feromone = startFeromone;
                    _edges[j, i].Feromone = startFeromone;
                }
            }
        }
    }
}
