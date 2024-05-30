using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

public class GaussianMethod
{
    public List<double> Gauss(double[][] A)
    {
        int n = A.Length;
        var matrix = DenseMatrix.OfArray(new double[n, n]);
        var vector = new double[n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = A[i][j];
            }
            vector[i] = A[i][n];
        }

        var solution = matrix.Solve(DenseVector.OfArray(vector));
        return solution.Storage.AsArray().ToList();
    }


}
