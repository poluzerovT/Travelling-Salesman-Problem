using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Graph
    {
        public List<Node> nodes;
        public List<Edge> edges;

        public int size;

        public Graph(int[,] m)
        {
            nodes = new List<Node>();
            edges = new List<Edge>();

            size = (int)Math.Sqrt(m.Length);
            for (int i = 0; i < size; i++)
            {
               nodes.Add(new Node(i));
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    Edge edge = new Edge(nodes[i], nodes[j], m[i, j]);
                    nodes[i].AddEdge(edge);
                    nodes[j].AddEdge(edge);
                    edges.Add(edge);
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
