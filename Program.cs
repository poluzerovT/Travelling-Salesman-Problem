﻿using System;
using System.Runtime.InteropServices;

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

        public static int[,] s20 = new int[,] //357
        {
            {0, 28, 56, 53, 65, 12, 81, 69, 37, 13, 65, 20, 61, 67, 35, 28, 45, 38, 56, 41 },
            {28, 0, 81, 52, 69, 32, 74, 17, 80, 59, 64, 19, 88, 94, 56, 50, 90, 84, 38, 76 },
            {56, 81, 0, 70, 39, 61, 15, 69, 13, 40, 90, 64, 93, 25, 85, 61, 79, 72, 14, 29 },
            {53, 52, 70, 0, 38, 58, 34, 78, 57, 32, 32, 14, 27, 25, 70, 63, 20, 76, 50, 89 },
            {65, 69, 39, 38, 0, 69, 68, 26, 80, 75, 82, 66, 92, 84, 53, 87, 43, 79, 57, 19 },
            {12, 32, 61, 58, 69, 0, 32, 52, 31, 62, 35, 14, 97, 22, 17, 39, 10, 51, 88, 69 },
            {81, 74, 15, 34, 68, 32, 0, 36, 54, 26, 74, 95, 92, 21, 55, 33, 53, 56, 92, 41 },
            {69, 17, 69, 78, 26, 52, 36, 0, 94, 14, 44, 88, 35, 70, 15, 48, 20, 88, 24, 25 },
            {37, 80, 13, 57, 80, 31, 54, 94, 0, 85, 72, 55, 19, 51, 75, 40, 78, 32, 57, 99 },
            {13, 59, 40, 32, 75, 62, 26, 14, 85, 0, 70, 69, 83, 65, 98, 76, 28, 77, 16, 42 },
            {65, 64, 90, 32, 82, 35, 74, 44, 72, 70, 0, 72, 13, 17, 73, 51, 74, 81, 82, 31 },
            {20, 19, 64, 14, 66, 14, 95, 88, 55, 69, 72, 0, 26, 65, 11, 59, 20, 30, 65, 46 },
            {61, 88, 93, 27, 92, 97, 92, 35, 19, 83, 13, 26, 0, 82, 78, 25, 24, 19, 46, 15 },
            {67, 94, 25, 25, 84, 22, 21, 70, 51, 65, 17, 65, 82, 0, 74, 29, 52, 14, 17, 71 },
            {35, 56, 85, 70, 53, 17, 55, 15, 75, 98, 73, 11, 78, 74, 0, 92, 21, 18, 82, 22 },
            {28, 50, 61, 63, 87, 39, 33, 48, 40, 76, 51, 59, 25, 29, 92, 0, 69, 48, 45, 99 },
            {45, 90, 79, 20, 43, 10, 53, 20, 78, 28, 74, 20, 24, 52, 21, 69, 0, 10, 58, 96 },
            {38, 84, 72, 76, 79, 51, 56, 88, 32, 77, 81, 30, 19, 14, 18, 48, 10, 0, 11, 41 },
            {56, 38, 14, 50, 57, 88, 92, 24, 57, 16, 82, 65, 46, 17, 82, 45, 58, 11, 0, 44 },
            {41, 76, 29, 89, 19, 69, 41, 25, 99, 42, 31, 46, 15, 71, 22, 99, 96, 41, 44, 0 }
        };

        public static int[,] s30 = new int[,] //418
        {
            {0, 12, 92, 23, 46, 48, 80, 98, 72, 78, 21, 93, 49, 50, 68, 46, 81, 57, 29, 50, 51, 22, 50, 38, 96, 57, 79, 72, 42, 34 },
            {12, 0, 30, 92, 19, 70, 44, 19, 22, 14, 16, 49, 48, 54, 67, 71, 28, 31, 72, 19, 87, 30, 97, 90, 20, 17, 88, 62, 62, 63 },
            {92, 30, 0, 26, 88, 69, 18, 65, 47, 57, 29, 84, 79, 16, 58, 33, 76, 51, 80, 12, 96, 55, 78, 20, 74, 84, 70, 84, 22, 37 },
            {23, 92, 26, 0, 40, 81, 11, 81, 81, 57, 59, 88, 27, 79, 40, 88, 29, 24, 99, 47, 93, 13, 38, 96, 31, 49, 39, 15, 91, 16 },
            {46, 19, 88, 40, 0, 83, 52, 51, 14, 99, 33, 52, 20, 27, 47, 82, 97, 34, 11, 74, 87, 33, 10, 72, 18, 36, 64, 21, 37, 91 },
            {48, 70, 69, 81, 83, 0, 67, 55, 26, 15, 90, 52, 96, 89, 75, 73, 16, 46, 23, 80, 16, 45, 18, 97, 61, 65, 95, 79, 37, 31 },
            {80, 44, 18, 11, 52, 67, 0, 44, 26, 38, 43, 83, 80, 29, 41, 24, 23, 41, 77, 36, 14, 36, 95, 86, 18, 59, 37, 68, 50, 20 },
            {98, 19, 65, 81, 51, 55, 44, 0, 29, 65, 72, 28, 67, 59, 71, 95, 88, 28, 94, 71, 74, 23, 62, 16, 94, 54, 74, 32, 99, 48 },
            {72, 22, 47, 81, 14, 26, 26, 29, 0, 39, 18, 13, 70, 66, 78, 87, 30, 10, 62, 93, 15, 18, 77, 20, 62, 61, 81, 52, 27, 53 },
            {78, 14, 57, 57, 99, 15, 38, 65, 39, 0, 59, 42, 43, 61, 82, 33, 12, 64, 82, 93, 28, 20, 81, 36, 63, 24, 96, 93, 93, 18 },
            {21, 16, 29, 59, 33, 90, 43, 72, 18, 59, 0, 68, 28, 41, 78, 69, 14, 85, 95, 42, 93, 93, 79, 82, 95, 79, 76, 70, 19, 84 },
            {93, 49, 84, 88, 52, 52, 83, 28, 13, 42, 68, 0, 55, 85, 65, 27, 69, 75, 95, 37, 51, 57, 47, 64, 87, 59, 18, 85, 41, 10 },
            {49, 48, 79, 27, 20, 96, 80, 67, 70, 43, 28, 55, 0, 64, 92, 77, 48, 17, 31, 89, 10, 48, 38, 86, 56, 87, 53, 87, 18, 47 },
            {50, 54, 16, 79, 27, 89, 29, 59, 66, 61, 41, 85, 64, 0, 33, 12, 10, 72, 12, 73, 76, 43, 48, 94, 38, 15, 30, 73, 19, 48 },
            {68, 67, 58, 40, 47, 75, 41, 71, 78, 82, 78, 65, 92, 33, 0, 76, 15, 27, 16, 17, 77, 44, 37, 68, 37, 67, 51, 95, 69, 94 },
            {46, 71, 33, 88, 82, 73, 24, 95, 87, 33, 69, 27, 77, 12, 76, 0, 77, 79, 21, 84, 83, 40, 37, 62, 28, 11, 15, 68, 36, 61 },
            {81, 28, 76, 29, 97, 16, 23, 88, 30, 12, 14, 69, 48, 10, 15, 77, 0, 94, 27, 64, 76, 18, 21, 47, 70, 11, 40, 55, 68, 73 },
            {57, 31, 51, 24, 34, 46, 41, 28, 10, 64, 85, 75, 17, 72, 27, 79, 94, 0, 13, 75, 16, 34, 47, 78, 10, 61, 36, 18, 88, 35 },
            {29, 72, 80, 99, 11, 23, 77, 94, 62, 82, 95, 95, 31, 12, 16, 21, 27, 13, 0, 17, 48, 53, 98, 15, 12, 19, 17, 76, 74, 19 },
            {50, 19, 12, 47, 74, 80, 36, 71, 93, 93, 42, 37, 89, 73, 17, 84, 64, 75, 17, 0, 12, 74, 87, 58, 56, 17, 77, 81, 39, 25 },
            {51, 87, 96, 93, 87, 16, 14, 74, 15, 28, 93, 51, 10, 76, 77, 83, 76, 16, 48, 12, 0, 67, 33, 87, 21, 76, 67, 90, 36, 99 },
            {22, 30, 55, 13, 33, 45, 36, 23, 18, 20, 93, 57, 48, 43, 44, 40, 18, 34, 53, 74, 67, 0, 67, 19, 76, 51, 10, 72, 94, 71 },
            {50, 97, 78, 38, 10, 18, 95, 62, 77, 81, 79, 47, 38, 48, 37, 37, 21, 47, 98, 87, 33, 67, 0, 96, 38, 46, 60, 97, 39, 65 },
            {38, 90, 20, 96, 72, 97, 86, 16, 20, 36, 82, 64, 86, 94, 68, 62, 47, 78, 15, 58, 87, 19, 96, 0, 14, 59, 60, 29, 54, 54 },
            {96, 20, 74, 31, 18, 61, 18, 94, 62, 63, 95, 87, 56, 38, 37, 28, 70, 10, 12, 56, 21, 76, 38, 14, 0, 59, 37, 59, 20, 50 },
            {57, 17, 84, 49, 36, 65, 59, 54, 61, 24, 79, 59, 87, 15, 67, 11, 11, 61, 19, 17, 76, 51, 46, 59, 59, 0, 24, 65, 86, 38 },
            {79, 88, 70, 39, 64, 95, 37, 74, 81, 96, 76, 18, 53, 30, 51, 15, 40, 36, 17, 77, 67, 10, 60, 60, 37, 24, 0, 45, 28, 80 },
            {72, 62, 84, 15, 21, 79, 68, 32, 52, 93, 70, 85, 87, 73, 95, 68, 55, 18, 76, 81, 90, 72, 97, 29, 59, 65, 45, 0, 76, 16 },
            {42, 62, 22, 91, 37, 37, 50, 99, 27, 93, 19, 41, 18, 19, 69, 36, 68, 88, 74, 39, 36, 94, 39, 54, 20, 86, 28, 76, 0, 10 },
            {34, 63, 37, 16, 91, 31, 20, 48, 53, 18, 84, 10, 47, 48, 94, 61, 73, 35, 19, 25, 99, 71, 65, 54, 50, 38, 80, 16, 10, 0 }
        };


        static void Main(string[] args)
        {
            int good = 0;
            double avg = 0;
            double total = 1000;
            double min = Int32.MaxValue;

            double controlValue = 10;
            int trainTimes = 5;

            for (int i = 0; i < total; i++)
            {
                Ant a = new Ant(new Graph(m), 1, 4, 0.5, 7);
                a.Train(trainTimes);
                if (a.bestWay.Item2.CompareTo(controlValue) == 0)
                {
                    good++;
                }

                avg += a.bestWay.Item2;
                if (min > a.bestWay.Item2)
                {
                    min = a.bestWay.Item2;
                }
                a.PrintBest();
            }
            Console.WriteLine(min);
            Console.WriteLine("Accur: {0} \nAvg:{1}", good / total, avg/total);

        }
    }
}
