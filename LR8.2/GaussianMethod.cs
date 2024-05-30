using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

public class GaussianMethod
{
    // Метод Гаусса для решения системы уравнений
    public List<double> Solve(List<List<List<double>>> listSqurel)
    {
        int n = listSqurel.Count;
        var matrix = DenseMatrix.OfArray(new double[n, n]);
        var vector = new double[n];

        // Формирование матрицы коэффициентов и вектора правых частей
        for (int i = 0; i < n; i++)
        {
            int m = listSqurel[i].Count;
            for (int j = 0; j < m - 1; j++) // последний элемент не учитываем, это правая часть
            {
                matrix[i, j] = listSqurel[i][j][0]; // коэффициенты
            }
            vector[i] = listSqurel[i][m - 1][0]; // правая часть
        }

        // Решение системы методом Гаусса
        var solution = matrix.Solve(DenseVector.OfArray(vector));

        // Преобразование в List<double>
        List<double> root = solution.ToList();

        return root;
    }
}
