using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// класс с методами расширения
static class MatrixExt
{
    // метод расширения для получения количества строк матрицы
    public static int RowsCount(this int[,] matrix)
    {
        return matrix.GetUpperBound(0) + 1;
    }
    // метод расширения для получения количества столбцов матрицы
    public static int ColumnsCount(this int[,] matrix)
    {
        return matrix.GetUpperBound(1) + 1;
    }
}
namespace HomeworkTM_16_10
{
    class Program
    {
        static int GetCount(char[] array, char[] ar)
        {
            int Count = 0;

            foreach (char ch in array)
                foreach (char cha in ar)
                    if (ch == cha)
                        Count++;
            return Count;
        }
        // метод для получения матрицы из консоли
        static int[,] GetMatrixFromConsole(string name)
        {
            Console.Write("Количество строк матрицы {0}:    ", name);
            int n = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы {0}: ", name);
            int m = int.Parse(Console.ReadLine());

            var matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return matrix;
        }
        // метод для печати матрицы в консоль
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.RowsCount(); i++)
            {
                for (int j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }
                Console.WriteLine();
            }
        }
        // метод для умножения матриц
        static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];
            for (int i = 0; i < matrixA.RowsCount(); i++)
            {
                for (int j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    for (int k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Упражнение 6.1");
            char[] vowels = "АЕЁИОУЫЭЮЯ".ToLower().ToCharArray(); //Гласные
            char[] consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩЬЪ".ToLower().ToCharArray(); //Согласные

            string str = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ"; //Строка
            char[] array = str.ToLower().ToCharArray(); //Разбиваем строку на массив символов

            int vowelsCount = GetCount(array, vowels); //Количество гласных
            int consonantsCount = GetCount(array, consonants); //Количество согласных

            Console.WriteLine("Гласных в массиве: " + vowelsCount);
            Console.WriteLine("Согласных в массиве: " + consonantsCount);
            Console.ReadKey();



            Console.WriteLine("Упражнение 6.2");
            Console.WriteLine("Программа для умножения матриц");

            var a = GetMatrixFromConsole("A");
            var b = GetMatrixFromConsole("B");

            Console.WriteLine("Матрица A:");
            PrintMatrix(a);

            Console.WriteLine("Матрица B:");
            PrintMatrix(b);

            var result = MatrixMultiplication(a, b);
            Console.WriteLine("Произведение матриц:");
            PrintMatrix(result);



            Console.WriteLine("Упражнение 6.3");
            int months = 12, days = 30;
            int[,] temperature = new int[months, days];
            for (int i = 0; i < months; i++)
            {
                for (int j = 0; j < days; j++)
                {
                    temperature[i, j] = rnd.Next(-20, 25);
                }
            }
            float[] avgTemp = AverageTemps(temperature);
            avgTemp.OrderBy(x => x);
            foreach (var item in avgTemp)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("Домашнее задание");
            LinkedList<int[]> matrix4 = new LinkedList<int[]>();
            matrix4.AddLast(new int[] { 1, 2, 3 });
            matrix4.AddLast(new int[] { 4, 5, 6 });
            matrix4.AddLast(new int[] { 7, 8, 9 });
            LinkedList<int[]> matrix5 = new LinkedList<int[]>();
            matrix5.AddLast(new int[] { 3, 2, 1 });
            matrix5.AddLast(new int[] { 6, 5, 4 });
            matrix5.AddLast(new int[] { 9, 8, 7 });
            var matrix6 = MultiplicateMatrix(matrix4, matrix5);
            PrintMatrix(matrix6);

        }
        static void PrintMatrix(LinkedList<int[]> matrix)
        {
            foreach (var i in matrix)
            {
                foreach (var j in i)
                {
                    Console.Write(j.ToString() + ' ');
                }
                Console.Write('\n');
            }
        }
        static int[,] MultiplicateMatrix(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.Length / (matrix1.GetUpperBound(1) + 1) != (matrix2.GetUpperBound(1) + 1))
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            int amountLines1 = matrix1.GetUpperBound(1) + 1;
            int amountColumn2 = matrix2.Length / (matrix2.GetUpperBound(1) + 1);
            int amountColumn1 = matrix1.Length / (matrix1.GetUpperBound(1) + 1);
            int[,] matrixC = new int[amountLines1, amountColumn2];

            for (int i = 0; i < amountLines1; i++)
            {
                for (int j = 0; j < amountColumn2; j++)
                {
                    matrixC[i, j] = 0;

                    for (int k = 0; k < amountColumn1; k++)
                    {
                        matrixC[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return matrixC;
        }
        static LinkedList<int[]> MultiplicateMatrix(LinkedList<int[]> matrix1, LinkedList<int[]> matrix2)
        {
            if (matrix2.First().Length != matrix1.Count)
            {
                throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }
            int amountLines1 = matrix1.First().Length;
            int amountColumn2 = matrix2.Count;
            int amountLines2 = matrix2.First().Length;
            var matrixC = new LinkedList<int[]>();

            for (int i = 0; i < amountColumn2; i++)
            {
                int[] mat = new int[amountLines1];
                for (int j = 0; j < amountLines1; j++)
                {
                    int sum = 0;
                    LinkedList<int[]> matrixEnd = new LinkedList<int[]>(matrix2);
                    for (int k = 0; k < amountColumn2; k++)
                    {
                        sum += matrix1.First()[k] * matrixEnd.First()[j];
                        matrixEnd.RemoveFirst();
                    }
                    mat[j] = sum;
                }
                matrix1.RemoveFirst();
                matrixC.AddLast(mat);
            }
            return matrixC;
        }
        static float[] AverageTemps(int[,] temperature)
        {
            float[] avgTemps = new float[temperature.GetUpperBound(0) + 1];
            for (int i = 0; i < temperature.GetUpperBound(0) + 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < temperature.Length / (temperature.GetUpperBound(0) + 1); j++)
                {
                    sum += temperature[i, j];
                }
                avgTemps[i] = (float)sum / (temperature.Length / (temperature.GetUpperBound(0) + 1));
            }
            return avgTemps;
        }
        static float[] AverageTemps(Dictionary<int, int[]> temperature)
        {
            float[] avgTemps = new float[temperature.Count];
            for (int i = 0; i < temperature.Count; i++)
            {
                int sum = 0;
                foreach (var item in temperature[i])
                {
                    sum += item;
                }
                avgTemps[i] = (float)sum / temperature[i].Length;
            }
            return avgTemps;
        }
    }
}