using System;
using System.Collections.Generic;

namespace SharpAI
{
    class Matrix
    {
        public int rows; //number of rows in matrix
        public int columns; //number of columns in matrix
        public float[,] matrix; //matrix decleration using multi-demensional array

        private readonly Random rand = new(); //to make random numbers
        
        public Matrix(int numOfRows, int numOfCols) //constructor for variables initialization
        {
            rows = numOfRows;
            columns = numOfCols;
            matrix = new float[rows, columns];
            matrix.Initialize();
        }
        public void FillMatrix(float value) //Fill the input Matrix with the given value
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = value;
                }
            }
        }


        public void Randomize(float min, float max) //function to randomize a pre-existing matrix
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = (float)rand.NextDouble()*(max-min) + min;
                }
            }
        }
        public static void PrintMat(Matrix inMat) //prints the matrix in a tabular form
        {
            for(int i = 0; i < inMat.rows; i++)
            {
                for (int j = 0; j < inMat.columns; j++)
                {
                    Console.Write(" " + inMat.matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static Matrix CopyFrom(Matrix inMatrix) //takes matrix input and copies it to another
        {
            Matrix outMat = new (inMatrix.rows, inMatrix.columns)
            {
                matrix = inMatrix.matrix
            };
            return outMat;
        }
        public static Matrix operator +(Matrix a, Matrix b) //function for matrix addition
        {
            Matrix outMat = new(a.rows, b.columns);
            if (a.rows == b.rows & a.columns == b.rows)
            {
                for (int i = 0; i < outMat.rows; i++)
                {
                    for (int j = 0; j < outMat.columns; j++)
                    {
                        outMat.matrix[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }

            }
            else { Console.WriteLine("the dimensions of the matrices must be same! STUPID!"); }
            return outMat;
        }
        public static Matrix operator -(Matrix a, Matrix b) //function for matrix subtraction
        {
            Matrix outMat = new(a.rows, b.columns);
            if (a.rows == b.rows & a.columns == b.rows)
            {
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        outMat.matrix[i, j] = a.matrix[i, j] - b.matrix[i, j];
                    }
                }

            }
            else { Console.WriteLine("the dimensions of the matrices must be same! STUPID!"); }
            return outMat;
        }
        public static Matrix operator *(Matrix a, Matrix b) //function for matrix multiplication
        {
            Matrix outMat = new (a.rows, b.columns);
            if (a.columns == b.rows)
            {
                Console.WriteLine("product dimension: " + outMat.rows + "x" + outMat.columns);
                float temp = 0;
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        for(int k = 0; k < b.rows; k++)
                        {
                            temp += a.matrix[i, k] * b.matrix[k, j];
                        }
                        outMat.matrix[i, j] = temp;
                        temp = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("number of rows are not equal to the number of columns");
            }
            return outMat;
        }
        public static Matrix DotProduct(Matrix a, Matrix b) //function for matrix addition
        {
            Matrix outMat = new (a.rows, b.columns);
            if(a.rows == b.rows & a.columns == b.rows)
            {
                for (int i = 0; i < a.rows; i++)
                {
                    for (int j = 0; j < b.columns; j++)
                    {
                        outMat.matrix[i, j] = a.matrix[i, j] * b.matrix[i, j];
                    }
                }
            }
            else { Console.WriteLine("the dimensions of the matrices must be same! STUPID!"); }
            return outMat;
        }
        public static Matrix TransposeOf(Matrix a) //returns a transpose of input matrix
        {
            Matrix outMat = new(a.columns, a.rows);
            for (int i = 0; i < a.rows; i++)
            {
                for (int j = 0; j < a.columns; j++)
                {
                    outMat.matrix[j, i] = a.matrix[i, j];
                }
            }
            return outMat;
        }

    }
}