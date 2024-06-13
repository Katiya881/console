using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк матрицы (N): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов матрицы (M): ");
        int m = int.Parse(Console.ReadLine());

        if (n != m)
        {
            Console.WriteLine("Определитель можно найти только для квадратной матрицы (N должно быть равно M).");
            return;
        }

        double[,] matrix = new double[n, m];

        Console.WriteLine("Введите элементы матрицы:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }

        double determinant = CalculateDeterminant(matrix);

        Console.WriteLine($"Определитель матрицы: {determinant}");
    }

    static double CalculateDeterminant(double[,] matrix)
    {
        int n = matrix.GetLength(0);
        if (n == 1)
        {
            return matrix[0, 0];
        }
        else if (n == 2)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }
        else
        {
            double determinant = 0;
            for (int p = 0; p < n; p++)
            {
                double[,] subMatrix = CreateSubMatrix(matrix, 0, p);
                determinant += matrix[0, p] * CalculateDeterminant(subMatrix) * (p % 2 == 0 ? 1 : -1);
            }
            return determinant;
        }
    }

    static double[,] CreateSubMatrix(double[,] matrix, int excludeRow, int excludeCol)
    {
        int n = matrix.GetLength(0);
        double[,] subMatrix = new double[n - 1, n - 1];
        int r = -1;
        for (int i = 0; i < n; i++)
        {
            if (i == excludeRow)
                continue;
            r++;
            int c = -1;
            for (int j = 0; j < n; j++)
            {
                if (j == excludeCol)
                    continue;
                subMatrix[r, ++c] = matrix[i, j];
            }
        }
        return subMatrix;
    }
}
