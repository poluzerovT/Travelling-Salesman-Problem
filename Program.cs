﻿using System;

namespace TravellingSalesmanProblem_AntAlgorithm
{
    class Program
    {
        private static int[,] exc = new int[,]
        {
            {0, 612, 301, 866, 563, 327, 245, 443, 327, 248},
            {612, 0, 522, 439, 749, 491, 334, 350, 352, 303},
            {301, 522, 0, 282, 506, 823, 619, 282, 368, 420},
            {866, 439, 282, 0, 623, 347, 261, 844, 431, 286},
            {563, 749, 506, 623, 0, 755, 428, 601, 651, 441},
            {327, 491, 823, 347, 755, 0, 976, 391, 658, 758},
            {245, 344, 619, 261, 428, 976, 0, 302, 501, 1010},
            {327, 352, 368, 431, 651, 658, 501, 0, 699, 368},
            {248, 303, 420, 286, 441, 758, 1010, 368, 0, 775}
        };

        private static int[,] m = new int[,]
        {
            {0, 1, 5, 2, 3, 2, 8},
            {1, 0, 1, 1, 2, 1, 3},
            {5, 1, 0, 2, 3, 5, 6},
            {2, 1, 2, 0, 1, 2, 3},
            {3, 2, 3, 1, 0, 1, 2},
            {2, 1, 5, 2, 1, 0, 1},
            {8, 3, 6, 3, 2, 1, 0}
        };

        private static int[,] simple = new int[,]
        {
            {0, 58, 86, 79, 9, 17, 99, 73, 84, 88},
            {58, 0, 62, 58, 25, 43, 4, 75, 10, 29},
            {86, 62, 0, 1, 85, 25, 62, 26, 22, 51},
            {79, 58, 1, 0, 28, 59, 72, 55, 35, 86},
            {9, 25, 85, 28, 0, 65, 36, 30, 74, 75},
            {17, 43, 25, 59, 65, 0, 13, 79, 89, 25},
            {99, 4, 62, 72, 36, 13, 0, 45, 31, 31},
            {73, 75, 26, 55, 30, 79, 45, 0, 70, 21},
            {84, 10, 22, 35, 74, 89, 31, 70, 0, 66},
            {88, 29, 51, 86, 75, 25, 31, 21, 66, 0}
        };

        public static int[,] s20 = new int[,]
        {
            {0, 2, 17, 52, 97, 55, 93, 41, 82, 60, 18, 42, 60, 68, 94, 86, 18, 82, 68, 3},
            {2, 0, 73, 66, 41, 1, 46, 51, 31, 43, 58, 71, 41, 42, 12, 38, 8, 30, 96, 14},
            {17, 73, 0, 8, 19, 50, 73, 75, 75, 13, 82, 18, 40, 10, 81, 37, 61, 60, 81, 3},
            {52, 66, 8, 0, 83, 61, 15, 5, 45, 23, 49, 82, 10, 18, 76, 30, 22, 60, 63, 90},
            {97, 41, 19, 83, 0, 3, 74, 49, 53, 99, 90, 65, 88, 64, 32, 91, 33, 77, 34, 80},
            {55, 1, 50, 61, 3, 0, 82, 30, 34, 25, 68, 80, 8, 62, 95, 0, 90, 65, 56, 37},
            {93, 46, 73, 15, 74, 82, 0, 52, 95, 79, 46, 91, 33, 87, 10, 28, 4, 93, 95, 26},
            {41, 51, 75, 5, 49, 30, 52, 0, 41, 12, 32, 15, 5, 75, 38, 93, 0, 88, 35, 94},
            {82, 31, 75, 45, 53, 34, 95, 41, 0, 9, 94, 11, 53, 52, 9, 24, 9, 51, 12, 36},
            {60, 43, 13, 23, 99, 25, 79, 12, 9, 0, 11, 87, 85, 0, 92, 71, 2, 30, 32, 73},
            {18, 58, 82, 49, 90, 68, 46, 32, 94, 11, 0, 53, 67, 50, 63, 85, 85, 90, 18, 43},
            {42, 71, 18, 82, 65, 80, 91, 15, 11, 87, 53, 0, 52, 7, 44, 51, 82, 38, 76, 56},
            {60, 41, 40, 10, 88, 8, 33, 5, 53, 85, 67, 52, 0, 76, 94, 68, 86, 75, 29, 75},
            {68, 42, 10, 18, 64, 62, 87, 75, 52, 0, 50, 7, 76, 0, 20, 27, 19, 74, 46, 22},
            {94, 12, 81, 76, 32, 95, 10, 38, 9, 92, 63, 44, 94, 20, 0, 97, 58, 3, 21, 55},
            {86, 38, 37, 30, 91, 0, 28, 93, 24, 71, 85, 51, 68, 27, 97, 0, 27, 61, 90, 66},
            {18, 8, 61, 22, 33, 90, 4, 0, 9, 2, 85, 82, 86, 19, 58, 27, 0, 24, 34, 91},
            {82, 30, 60, 60, 77, 65, 93, 88, 51, 30, 90, 38, 75, 74, 3, 61, 24, 0, 8, 59},
            {68, 96, 81, 63, 34, 56, 95, 35, 12, 32, 18, 76, 29, 46, 21, 90, 34, 8, 0, 29},
            {3, 14, 3, 90, 80, 37, 26, 94, 36, 73, 43, 56, 75, 22, 55, 66, 91, 59, 29, 0}
        };


        static void Main(string[] args)
        {
            int good = 0;
            double total = 1000;

            for (int i = 0; i < total; i++)
            {
                Ant a = new Ant(new Graph(m), 1, 4, 0.5, 10);
                a.Train(15);
                if (a.bestWay.Item2.CompareTo(10) == 0)
                {
                    good++;
                }

                a.PrintBest();
            }
            Console.WriteLine("Accur: {0}", good / total);

        }
    }
}
