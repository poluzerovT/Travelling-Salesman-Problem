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

        public Node FindNode(int index)
        {
            foreach (var node in nodes)
            {
                if (node.index == index)
                {
                    return node;
                }
            }

            return null;
        }

        public Edge FindEdge(int ind1, int ind2)
        {
            return FindNode(ind1).FindEdge(ind2);
        }

        public void Print()
        {
            foreach (var node in nodes)
            {
                node.Print();
                Console.WriteLine();
            }
        }
    }
}
