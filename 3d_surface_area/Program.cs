using System;
class Program
{
    static void Main(string[] args)
    {
        string[] dimensions = Console.ReadLine().Split();
        int row = int.Parse(dimensions[0]);
        int column = int.Parse(dimensions[1]);

        int[,] grid = new int[row, column]; 

        for (int i = 0; i < row; i++)
        {
            string[] rowLine = Console.ReadLine().Split();
            for (int j = 0; j < column; j++)
                grid[i, j] = int.Parse(rowLine[j]);
        }

        Console.WriteLine(CalculateSurfaceArea(row, column, grid));
    }

    static int CalculateSurfaceArea(int row, int column, int[,] grid)
    {
        int totalSurfaceArea = 2 * row * column; // tüm grid'in alt ve üst yüzey alanı.

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                // Kuzey yönü alanı
                if (i == 0)
                    totalSurfaceArea += grid[i,j];
                else
                    totalSurfaceArea += Math.Max(0, grid[i,j] - grid[i - 1,j]);

                // Güney yönü alanı
                if (i == row - 1)
                    totalSurfaceArea += grid[i,j];
                else
                    totalSurfaceArea += Math.Max(grid[i, j] - grid[i + 1, j], 0);

                // Batı yönü alanı
                if (j == 0)
                    totalSurfaceArea += grid[i, j];
                else
                    totalSurfaceArea += Math.Max(grid[i, j] - grid[i, j - 1], 0);

                // Doğu yönü alanı
                if (j == column - 1)
                    totalSurfaceArea += grid[i, j];
                else
                    totalSurfaceArea += Math.Max(grid[i, j] - grid[i, j + 1], 0);
            }
        }

        return totalSurfaceArea;
    }
}