using System;
using System.Text.RegularExpressions;

class Matrix
{
    private int[,] matrix;

    public Matrix(int[,] matrix)
    {
        this.matrix = matrix;
    }

    public int this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }

    public class Production
    {
        public int ID { get; set; }
        public string OrgName { get; set; }

        public Production(int id, string orgName)
        {
            ID = id;
            OrgName = orgName;
        }
    }

    public class Developer
    {
        public string FullName { get; set; }
        public int ID { get; set; }
        public string Department { get; set; }

        public Developer(string fullName, int id, string department)
        {
            FullName = fullName;
            ID = id;
            Department = department;
        }
    }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        int rows = a.matrix.GetLength(0);
        int columns = a.matrix.GetLength(1);
        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = a.matrix[i, j] + b.matrix[i, j];
            }
        }

        return new Matrix(result);
    }

    public static Matrix operator -(Matrix a, int numOfRemovedRow)
    {
        int rows = a.matrix.GetLength(0);
        int columns = a.matrix.GetLength(1);
        int[,] result = new int[rows - 1, columns];

        for (int i = 0, r = 0; i < rows; i++)
        {
            if (i == numOfRemovedRow)
            {
                continue;
            }

            for (int j = 0; j < columns; j++)
            {
                result[r, j] = a.matrix[i, j];
            }
            r++;
        }

        return new Matrix(result);
    }

    public static bool operator >(Matrix a, Matrix b)
    {
        return a.GetMatrixSum() > b.GetMatrixSum();
    }

    public static bool operator <(Matrix a, Matrix b)
    {
        return a.GetMatrixSum() < b.GetMatrixSum();
    }

    public static Matrix operator *(Matrix a, int b = 0)
    {
        int rows = a.matrix.GetLength(0);
        int columns = a.matrix.GetLength(1);
        int[,] result = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = a.matrix[i, j];
            }
        }
       
        return new Matrix(result);
    }

    public int GetRows()
    {
        return matrix.GetLength(0);
    }

    public int GetColumns()
    {
        return matrix.GetLength(1);
    }

    public int GetValue(int i, int j)
    {
        return matrix[i, j];
    }
    private int GetMatrixSum()
    {
        int sum = 0;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sum += matrix[i, j];
            }
        }

        return sum;
    }

    public void Print()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

}

class StringMatrix
{

    private string[,] matrix;
    public StringMatrix(string[,] matrix)
    {
        this.matrix = matrix;
    }

    public string this[int i, int j]
    {
        get { return matrix[i, j]; }
        set { matrix[i, j] = value; }
    }

    public int GetRows()
    {
        return matrix.GetLength(0);
    }

    public int GetColumns()
    {
        return matrix.GetLength(1);
    }

    public void Print()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

static class StatisticOperation
{
    public static int Sum(Matrix matrix)
    {
        int sum = 0;

        for (int i = 0; i < matrix.GetRows(); i++)
        {
            for (int j = 0; j < matrix.GetColumns(); j++)
            {
                sum += matrix.GetValue(i, j);
            }
        }
        return sum;
    }

    public static int DifferenceBetweenMaxAndMin(Matrix matrix)
    {
        int max = matrix.GetValue(0, 0);
        int min = matrix.GetValue(0, 0);

        for (int i = 0; i < matrix.GetRows(); i++)
        {
            for (int j = 0; j < matrix.GetColumns(); j++)
            {
                if (matrix.GetValue(i, j) > max)
                {
                    max = matrix.GetValue(i, j);
                }

                if (matrix.GetValue(i, j) < min)
                {
                    min = matrix.GetValue(i, j);
                }
            }
        }

        return max - min;
    }

    public static int ElementCount(Matrix matrix)
    {
        return matrix.GetRows() * matrix.GetColumns();
    }

    public static string FindBelCarNumber(StringMatrix matrix)
    {
        string pattern = @"\b\d{4} [A-Z]{2}-\d\b";
        int rows = matrix.GetRows();
        int columns = matrix.GetColumns();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Match match = Regex.Match(matrix[i, j], pattern);

                if (match.Success)
                {
                    return match.Value;
                }
            }
        }

        return "Белорусский номер не найден";
    }

    public static int SumOfMainDiagonal(Matrix matrix)
    {
        int sum = 0;

        for (int i = 0; i < matrix.GetRows(); i++)
        {
            sum += matrix[i, i];
        }

        return sum;
    }

    public static string ExtendedMethod(this string str)
    {
        str += "?";

        return str;
    }
}




namespace OOP3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] mat1 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 6, 7, 8 },
            };

            int[,] mat2 =
            {
                { 7, 8, 9 },
                { 10, 11, 12 },
                { 11, 12, 13 },
            };

            string[,] matrixWithNumbers =
            {
                {"1321", "321231" },
                {"321321", "3213 AB-6" }
            };

            Matrix matrix1 = new Matrix(mat1);
            Matrix matrix2 = new Matrix(mat2);
            StringMatrix matrix3 = new StringMatrix(matrixWithNumbers);

            Console.WriteLine("Matrix 1:");
            matrix1.Print();

            Console.WriteLine("Matrix 2:");
            matrix2.Print();

            Matrix sumMatrix = matrix1 + matrix2;
            Console.WriteLine("Сложение матриц:");
            sumMatrix.Print();

            Matrix modifiedMatrix = matrix1 - 1;
            Console.WriteLine("После удаления строки:");
            modifiedMatrix.Print();

            Console.WriteLine(matrix1 > matrix2 ? "Matrix 1 больше Matrix 2" : "Matrix 1 меньше или равна Matrix 2");

            string carNumber = StatisticOperation.FindBelCarNumber(matrix3);
            Console.WriteLine(carNumber);

            int diagonalSum = StatisticOperation.SumOfMainDiagonal(matrix2);
            Console.WriteLine($"Сумма главной диагонали Matrix 1: {diagonalSum}");


            string str = "oop";


            Console.WriteLine(str.ExtendedMethod());
        }
    }
}
