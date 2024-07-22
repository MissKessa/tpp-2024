using System;
using System.IO;

namespace TPP.Laboratory.Concurrency.Lab09 {

    class Program {

        static void Main(string[] args) {
            const int maxNumberOfThreads = 50;
            short[] vector = VectorModulusProgram.CreateRandomVector(100000, -10, 10);
            ShowLine(Console.Out, "Number of threads", "Ticks", "Result");
            for (int numberOfThreads = 1; numberOfThreads <= maxNumberOfThreads; numberOfThreads++) {
                //Better if we execute this 30 times, and do the average for each
                Master master = new Master(vector, numberOfThreads);
                DateTime before = DateTime.Now;
                double result = master.ComputeModulus();
                DateTime after = DateTime.Now;
                ShowLine(Console.Out, numberOfThreads, (after - before).Ticks, result);

                //Explicity call the garbage collector, to make the time measured more precise:
                GC.Collect(); // Garbage collection
                GC.WaitForFullGCComplete();
            }
        }

        /*
         * Number of threads;Ticks;Result;
1;47.979;1.910,79;
2;5.242;1.910,79;
3;6.443;1.910,79;
4;8.658;1.910,79;
5;9.986;1.910,79;
6;16.214;1.910,79;
7;13.391;1.910,79;
8;17.593;1.910,79;
9;17.388;1.910,79;
10;25.865;1.910,79;
11;24.612;1.910,79;
12;20.687;1.910,79;
13;18.497;1.910,79;
14;13.215;1.910,79;
15;15.899;1.910,79;
16;22.298;1.910,79;
17;18.911;1.910,79;
18;33.680;1.910,79;
19;21.747;1.910,79;
20;24.297;1.910,79;
21;15.893;1.910,79;
22;17.594;1.910,79;
23;33.030;1.910,79;
24;25.093;1.910,79;
25;18.712;1.910,79;
26;24.375;1.910,79;
27;18.533;1.910,79;
28;21.185;1.910,79;
29;21.090;1.910,79;
30;38.682;1.910,79;
31;31.945;1.910,79;
32;31.467;1.910,79;
33;28.935;1.910,79;
34;31.915;1.910,79;
35;37.375;1.910,79;
36;36.520;1.910,79;
37;35.532;1.910,79;
38;35.914;1.910,79;
39;47.866;1.910,79;
40;32.857;1.910,79;
41;30.158;1.910,79;
42;30.663;1.910,79;
43;53.619;1.910,79;
44;40.717;1.910,79;
45;31.930;1.910,79;
46;33.621;1.910,79;
47;46.325;1.910,79;
48;42.740;1.910,79;
49;42.223;1.910,79;
50;39.212;1.910,79;
        */

        private const string CSV_SEPARATOR = ";";

        static void ShowLine(TextWriter stream, string numberOfThreadsTitle, string ticksTitle, string resultTitle) {
            stream.WriteLine("{0}{3}{1}{3}{2}{3}", numberOfThreadsTitle, ticksTitle, resultTitle, CSV_SEPARATOR);
        }

        static void ShowLine(TextWriter stream, int numberOfThreads, long ticks, double result) {
            stream.WriteLine("{0}{3}{1:N0}{3}{2:N2}{3}", numberOfThreads, ticks, result, CSV_SEPARATOR);
        }
    }

}
