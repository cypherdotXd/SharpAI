using System;

namespace SharpAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix a = new (3, 3);
            a.FillMatrix(4);

            Matrix b = new(3, 3);
            b.FillMatrix(3);

            Matrix c = a + b;
            Matrix.PrintMat(c);

            c = a - b;
            Matrix.PrintMat(c);

            c = Matrix.DotProduct(a, b);
            Matrix.PrintMat(c);
        }
    }
}
