using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Edge
    {
        public double feromone;
        public double weight;
        public Node node1;
        public Node node2;

        public double dFeromone;

        public Edge(Node node1, Node node2, double weight, double feromone=0)
        {
            this.node1 = node1;
            this.node2 = node2;
            this.weight = weight;
            this.feromone = feromone;
            this.dFeromone = 0;
        }

        public void Print()
        {
            Console.WriteLine("[{0}, {1}] w:{2}  f:{3}", node1.index, node2.index, weight, feromone);
        }
    }
}
