using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Node
    {
        private List<Edge> edges;
        public int index;

        public Node(int index)
        {
            edges = new List<Edge>();
            this.index = index;
        }

        public void AddEdge(Edge edge)
        {
            edges.Add(edge);
        }

        public Edge FindEdge(int ind)
        {
            foreach (var edge in edges)
            {
                if ((edge.node1.index == this.index && edge.node2.index == ind) ||
                    (edge.node1.index == ind && edge.node2.index == this.index)
                )
                {
                    return edge;
                }
            }

            return null;
        }

        public void Print()
        {
            Console.WriteLine("[{0}] : ", index);
            foreach (var edge in edges)
            {
                edge.Print();
            }
        }
    }
}
