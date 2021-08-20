using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingSalesmanProblem_AntAlgorithm
{/// <summary>
/// Represent Ant Algorithm for Traveling Salesman Problem
/// </summary>
    class Ant
    {
        private Graph g;
        
        private readonly int _size;
        private readonly int _antCount;
        private readonly double _startFeromone;
        private readonly int _startNode;

        private readonly double _alfa;
        private readonly double _beta;
        private readonly double _p;
        private readonly double _feromoneCoef;

        readonly Random rand;

        public (List<int>, double) BestWay;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="g">Graph</param>
        /// <param name="startNode">Start node for building a route</param>
        /// <param name="alfa">Feromone sensetivity coef</param>
        /// <param name="beta">Edge weight sensetivity coef</param>
        /// <param name="p">Evaporation coef</param>
        /// <param name="antCount">Number of ants</param>
        /// <param name="startFeromone">Start amount of feromone on the edges</param>
        /// <param name="feromoneCoef">Additional feromone multiplier</param>
        public Ant(Graph g, int startNode, double alfa = 1, double beta = 1, double p = 0.3, int antCount = 10, double startFeromone = 1, double feromoneCoef = 2.5)
        {
            this.g = g;
            this._startNode = startNode;
            this._size = g.Size;
            this._alfa = alfa;
            this._beta = beta;
            this._p = p;
            this._antCount = antCount;
            this._startFeromone = startFeromone;
            this._feromoneCoef = feromoneCoef;

            BestWay = (null, Double.MaxValue);

            rand = new Random();
            g.SetFeromones(startFeromone);
        }
        
        /// <summary>
       /// Refresh all edge's feromones after iteration
       /// </summary>
        private void RefreshFeromones()
        {
            for(int i = 0; i < _size; i++)
            {
                for (int j = i + 1; j < _size; j++)
                {
                    g.Edges[i,j].Feromone *= (1 - _p);
                    g.Edges[i, j].Feromone += g.Edges[i, j].DFeromone;
                    g.Edges[i, j].DFeromone = 0;

                    g.Edges[j, i].Feromone *= (1 - _p);
                    g.Edges[j, i].Feromone += g.Edges[j, i].DFeromone;
                    g.Edges[j, i].DFeromone = 0;
                }
            }
        }

        /// <summary>
        /// Simulate one ant's route from random node. Calculate feromone additive for each edge
        /// </summary>
        /// <returns>(Ant's route node sequence, route weight)</returns>
        private (List<int>, double) Move()
        {
            double totalWeight = 0;
            List<int> visitedNodes = new List<int>();
            List<int> avalibalNodes = new List<int>();

            int startNode = rand.Next(_size);
            visitedNodes.Add(startNode);

            for (int i = 0; i < _size; i++)
            {
                if (i != startNode)
                {
                    avalibalNodes.Add(i);
                }
            }

            while (avalibalNodes.Count != 0)
            {
                int curNode = visitedNodes[visitedNodes.Count - 1];

                double total = 0;
                foreach (var node in avalibalNodes)
                {
                    var edge = g.Edges[curNode, node];
                    total += Math.Pow(edge.Feromone, _alfa) / Math.Pow(edge.Weight, _beta);
                }

                double stopValue = rand.NextDouble();
                double curValue = 0;
                foreach (var node in avalibalNodes)
                {
                    var edge = g.Edges[curNode, node];
                    curValue += Math.Pow(edge.Feromone, _alfa) / Math.Pow(edge.Weight, _beta) / total;

                    if (stopValue <= curValue)
                    {
                        totalWeight += edge.Weight;
                        curNode = node;
                        break;
                    }
                }

                visitedNodes.Add(curNode);
                avalibalNodes.Remove(curNode);
            }

            var lastEdge = g.Edges[ visitedNodes[0], visitedNodes[_size - 1] ];
            visitedNodes.Add(visitedNodes[0]);
            totalWeight += lastEdge.Weight;

            for (int i = 1; i < visitedNodes.Count; i++)
            {
                g.Edges[visitedNodes[i - 1], visitedNodes[i]].DFeromone += _feromoneCoef / totalWeight;
                g.Edges[visitedNodes[i], visitedNodes[i-1]].DFeromone += _feromoneCoef / totalWeight;
            }

            if (totalWeight < BestWay.Item2)
            {
                BestWay.Item2 = totalWeight;
                BestWay.Item1 = visitedNodes;
            }

            return (visitedNodes, totalWeight);
        }

        /// <summary>
        /// Start simulation
        /// </summary>
        /// <param name="times">Number of iterations</param>
        public void Train(int times = 10)
        {
            for (int t = 0; t < times; t++)
            {
                for (int ant = 0; ant < _antCount; ant++)
                {
                    Move();
                }
                RefreshFeromones();
            }
            RebuiltWay();
        }

        /// <summary>
        /// Rebuild route to start from startNode
        /// </summary>
        public void RebuiltWay()
        {
            if (BestWay.Item1[0] != _startNode)
            {
                BestWay.Item1.Remove(BestWay.Item1[0]);
                while (BestWay.Item1[0] != _startNode)
                {
                    var t = BestWay.Item1[0];
                    BestWay.Item1.Remove(t);
                    BestWay.Item1.Add(t);
                }
                BestWay.Item1.Add(_startNode);
            }
            
        }
        /// <summary>
        /// Print best route: "node_sequence [route weight]"
        /// </summary>
        public void PrintBest()
        {
            foreach (var node in BestWay.Item1)
            {
                Console.Write("{0}  ",node);
            }
            Console.WriteLine("[{0}]", BestWay.Item2);
        }
    }
}
