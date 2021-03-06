using System;
using System.Runtime.InteropServices;

namespace TravelingSalesmanProblem_AntAlgorithm
{
    class Program
    {
        private static int[,] example = new int[,] // 10
        {
            {0, 1, 5, 2, 3, 2, 8},
            {1, 0, 1, 1, 2, 1, 3},
            {5, 1, 0, 2, 3, 5, 6},
            {2, 1, 2, 0, 1, 2, 3},
            {3, 2, 3, 1, 0, 1, 2},
            {2, 1, 5, 2, 1, 0, 1},
            {8, 3, 6, 3, 2, 1, 0}
        };

        private static int[,] s20 = new int[,] //357
        {
            {0, 28, 56, 53, 65, 12, 81, 69, 37, 13, 65, 20, 61, 67, 35, 28, 45, 38, 56, 41},
            {28, 0, 81, 52, 69, 32, 74, 17, 80, 59, 64, 19, 88, 94, 56, 50, 90, 84, 38, 76},
            {56, 81, 0, 70, 39, 61, 15, 69, 13, 40, 90, 64, 93, 25, 85, 61, 79, 72, 14, 29},
            {53, 52, 70, 0, 38, 58, 34, 78, 57, 32, 32, 14, 27, 25, 70, 63, 20, 76, 50, 89},
            {65, 69, 39, 38, 0, 69, 68, 26, 80, 75, 82, 66, 92, 84, 53, 87, 43, 79, 57, 19},
            {12, 32, 61, 58, 69, 0, 32, 52, 31, 62, 35, 14, 97, 22, 17, 39, 10, 51, 88, 69},
            {81, 74, 15, 34, 68, 32, 0, 36, 54, 26, 74, 95, 92, 21, 55, 33, 53, 56, 92, 41},
            {69, 17, 69, 78, 26, 52, 36, 0, 94, 14, 44, 88, 35, 70, 15, 48, 20, 88, 24, 25},
            {37, 80, 13, 57, 80, 31, 54, 94, 0, 85, 72, 55, 19, 51, 75, 40, 78, 32, 57, 99},
            {13, 59, 40, 32, 75, 62, 26, 14, 85, 0, 70, 69, 83, 65, 98, 76, 28, 77, 16, 42},
            {65, 64, 90, 32, 82, 35, 74, 44, 72, 70, 0, 72, 13, 17, 73, 51, 74, 81, 82, 31},
            {20, 19, 64, 14, 66, 14, 95, 88, 55, 69, 72, 0, 26, 65, 11, 59, 20, 30, 65, 46},
            {61, 88, 93, 27, 92, 97, 92, 35, 19, 83, 13, 26, 0, 82, 78, 25, 24, 19, 46, 15},
            {67, 94, 25, 25, 84, 22, 21, 70, 51, 65, 17, 65, 82, 0, 74, 29, 52, 14, 17, 71},
            {35, 56, 85, 70, 53, 17, 55, 15, 75, 98, 73, 11, 78, 74, 0, 92, 21, 18, 82, 22},
            {28, 50, 61, 63, 87, 39, 33, 48, 40, 76, 51, 59, 25, 29, 92, 0, 69, 48, 45, 99},
            {45, 90, 79, 20, 43, 10, 53, 20, 78, 28, 74, 20, 24, 52, 21, 69, 0, 10, 58, 96},
            {38, 84, 72, 76, 79, 51, 56, 88, 32, 77, 81, 30, 19, 14, 18, 48, 10, 0, 11, 41},
            {56, 38, 14, 50, 57, 88, 92, 24, 57, 16, 82, 65, 46, 17, 82, 45, 58, 11, 0, 44},
            {41, 76, 29, 89, 19, 69, 41, 25, 99, 42, 31, 46, 15, 71, 22, 99, 96, 41, 44, 0}
        };

        // read more about algorithm: https://ru.wikipedia.org/wiki/%D0%9C%D1%83%D1%80%D0%B0%D0%B2%D1%8C%D0%B8%D0%BD%D1%8B%D0%B9_%D0%B0%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC

        // Main runs method for 'total' times with counting:
        // 1) the shortest route 
        // 2) method accuracy (if known the shortest), 
        // 3) avg route length,
        // 
        // control value - the shortest known route to calculate accuracy
        // train times - number of iterations in method
        // 

        static void Main(string[] args)
        {
            int good = 0;
            double avg = 0;
            double total = 1000;
            double min = Int32.MaxValue;

            double eps = 1;
            double controlValue = 10;
            int trainTimes = 25;

            for (int i = 0; i < total; i++)
            {
                Ant a = new Ant(new Graph(example), 0, 1, 4, 0.3);
                a.Train(trainTimes);
                if (Math.Abs(a.BestWay.Item2 - controlValue) < eps)
                {
                    good++;
                }

                avg += a.BestWay.Item2;

                if (min > a.BestWay.Item2)
                {
                    min = a.BestWay.Item2;
                }
                a.PrintBest();
            }
            Console.WriteLine("\nMin: {2} \nAccur: {0} \nAvg:{1}", good / total, avg / total, min);

        }
    }
}
