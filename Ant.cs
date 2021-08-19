using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Ant
    {
        private Graph g;
        
        private int size;
        private int antCount;

        private int startNode = 0;
        private double startFeromone = 1;

        private double alfa;
        private double beta;
        private double p;
        private double ferCoef = 2.5;

        Random rand = new Random();

        public (List<int>, double) bestWay;

        public Ant(Graph g, double alfa = 1, double beta = 1, double p = 0.3, int antCount = 10)
        {
            this.g = g;
            this.size = g.size;

            this.alfa = alfa;
            this.beta = beta;
            this.p = p;
            this.antCount = antCount;

           
            bestWay = (null, Double.MaxValue);

            g.SetFeromones(startFeromone);
        }

        private void Init(List<int> visitedNodes, List<int>avalibalNodes)
        {
            int startNode = rand.Next(size);
            visitedNodes.Add(startNode);

            for (int i = 0; i < size; i++)
            {
                if (i != startNode)
                {
                    avalibalNodes.Add(i);
                }
            }
        }
       
        private void RefreshFeromones()
        {
            for(int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    g.edges[i,j].feromone *= (1 - p);
                    g.edges[i, j].feromone += g.edges[i, j].dFeromone;
                    g.edges[i, j].dFeromone = 0;

                    g.edges[j, i].feromone *= (1 - p);
                    g.edges[j, i].feromone += g.edges[j, i].dFeromone;
                    g.edges[j, i].dFeromone = 0;
                }
            }
        }

        private (List<int>, double) Move()
        {
            double totalWeight = 0;
            List<int> visitedNodes = new List<int>();
            List<int> avalibalNodes = new List<int>();

            Init(visitedNodes, avalibalNodes);

            while (avalibalNodes.Count != 0)
            {
                int curNode = visitedNodes[visitedNodes.Count - 1];

                double total = 0;
                foreach (var node in avalibalNodes)
                {
                    var edge = g.FindEdge(curNode, node);
                    total += Math.Pow(edge.feromone, alfa) / Math.Pow(edge.weight, beta);
                }

                double stopValue = rand.NextDouble();
                double curValue = 0;
                foreach (var node in avalibalNodes)
                {
                    var edge = g.FindEdge(curNode, node);
                    curValue += Math.Pow(edge.feromone, alfa) / Math.Pow(edge.weight, beta) / total;

                    if (stopValue <= curValue)
                    {
                        totalWeight += edge.weight;
                        curNode = node;
                        break;
                    }
                }

                visitedNodes.Add(curNode);
                avalibalNodes.Remove(curNode);
            }

            var lastEdge = g.FindEdge(visitedNodes[0], visitedNodes[size - 1]);
            visitedNodes.Add(visitedNodes[0]);
            totalWeight += lastEdge.weight;

            for (int i = 1; i < visitedNodes.Count; i++)
            {
                g.FindEdge(visitedNodes[i - 1], visitedNodes[i]).dFeromone += ferCoef / totalWeight;
            }

            if (totalWeight < bestWay.Item2)
            {
                bestWay.Item2 = totalWeight;
                bestWay.Item1 = visitedNodes;
            }

            return (visitedNodes, totalWeight);
        }
        public void Train(int times = 0)
        {
            for (int t = 0; t < times; t++)
            {
                for (int ant = 0; ant < antCount; ant++)
                {
                    Move();
                }
                RefreshFeromones();
            }
            RebuiltWay();
        }

        public void RebuiltWay()
        {
            if (bestWay.Item1[0] != startNode)
            {
                bestWay.Item1.Remove(bestWay.Item1[0]);
                while (bestWay.Item1[0] != startNode)
                {
                    var t = bestWay.Item1[0];
                    bestWay.Item1.Remove(t);
                    bestWay.Item1.Add(t);
                }
                bestWay.Item1.Add(startNode);
            }
            
        }
        public void PrintBest()
        {
            foreach (var node in bestWay.Item1)
            {
                Console.Write("{0}  ",node);
            }
            Console.WriteLine("[{0}]", bestWay.Item2);
        }
    }
}
