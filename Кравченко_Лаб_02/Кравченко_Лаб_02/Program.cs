using System;

namespace LABA02
{
    class Program
    {
        delegate double F2Delegate(double x1, double x2);

        private static double Func(double x1, double x2)
        {

            return 45 * x1 * Math.Sin(x2) + Math.Sqrt(9 * x2 * Math.Pow(x1, 3));

        }

        private static double Acc(double multiplication, double y)
        {
            if (multiplication == 0)
            {
                return y;
            }
            return multiplication * y;
        }


        private static void EnterData(out double x1Min, out double x1Max, out double x2Min, out double x2Max, out double dx1, out double dx2)
        {
            Console.Write("Enter x1 min: ");
            x1Min = double.Parse(Console.ReadLine());

            Console.Write("Enter x2 min: ");
            x2Min = double.Parse(Console.ReadLine());

            Console.Write("Enter x1 max: ");
            x1Max = double.Parse(Console.ReadLine());

            Console.Write("Enter x2 max: ");
            x2Max = double.Parse(Console.ReadLine());

            Console.Write("Enter dx1: ");
            dx1 = double.Parse(Console.ReadLine());

            Console.Write("Enter dx2: ");
            dx2 = double.Parse(Console.ReadLine());

        }

        private static void Tabulate(double x1Min, double x1Max, double x2Min, double x2Max, double dx1, double dx2, double multiplication, F2Delegate func, F2Delegate acc)
        {
            double x1 = x1Min;
            Console.WriteLine("Tabulate function");
            Console.Write("x1/x2\t\t");

            for (double i = x2Min; i <= x2Max; i += dx2)
            {
                Console.Write("\t{0:f5}", i);
                Console.Write("\t");
            }
            Console.WriteLine();
            while (x1 <= x1Max)
            {
                double x2 = x2Min;

                while (x2 <= x2Max)
                {

                    double y = func(x1, x2);
                    Console.Write("{0:f3}\t", x1);
                    for (double i = x2Min; i <= x2Max; i += dx2)
                    {
                        Console.Write("\t{0}", y);
                    }
                    Console.WriteLine();
                    if (x1 > x1Min && x1 < x1Max && Math.Sin(y) > 0)
                    {
                        multiplication = acc(multiplication, y);
                    }
                    x2 += dx2;
                }
                x1 += dx1;

            }
            Console.WriteLine("===================");
            if (acc != null)
            {
                Console.WriteLine("The sum of all negative values is:");
                Console.WriteLine(multiplication);
                Console.WriteLine("================");
            }

        }

        static void Main(string[] args)
        {
            EnterData(out double x1Min, out double x1Max, out double x2Min, out double x2Max, out double dx1, out double dx2);
            Tabulate(x1Min, x1Max, x2Min, x2Max, dx1, dx2, 0, Func, Acc);
            Console.ReadKey();
        }
    }
}