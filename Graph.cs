using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Graph
    {
        public int[,] weights; 
        public Edge[,] edges;
        public int size;

        public Graph(int[,] m)
        {
            size = (int)Math.Sqrt(m.Length);

            weights = m;
            edges = new Edge[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    edges[i, j] = new Edge(null, null, m[i, j], 0);
                    edges[j, i] = new Edge(null, null, m[i, j], 0);
                }
            }
        }

        public void SetFeromones(double startFeromone)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    edges[i, j].feromone = startFeromone;
                    edges[j, i].feromone = startFeromone;
                }
            }
        }
        public Edge FindEdge(int ind1, int ind2)
        {
            return edges[ind1, ind2];
        }
    }
}
