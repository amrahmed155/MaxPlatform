

internal class Program
{
  
    static Tuple<long, int, int> sumRecursiveFn(int[,] matrix, int row = 0, long bestSum = long.MinValue, int bestRow = 0, int bestCol = 0)
    {
        if (row < matrix.GetLength(0) - 2)
        {
            for (int col = 0; col < matrix.GetLength(1) - 2; col++)

            {
                //the summation row and column here will be the center of the matrix 

               
                    long sum = matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row, col + 2];


                    sum += matrix[row + 1, col ];
                    sum += matrix[row + 1, col + 1];
                    sum += matrix[row + 1, col + 2];

                    sum += matrix[row + 2, col];
                    sum += matrix[row + 2, col + 1];
                    sum += matrix[row + 2, col + 2];
                


                if (sum > bestSum)

                {

                    bestSum = sum;

                    bestRow = row;

                    bestCol = col;

                }

            }
            Console.WriteLine(bestSum);
            return sumRecursiveFn(matrix, row + 1, bestSum, bestRow, bestCol);
        }
        else
        {
            return Tuple.Create(bestSum, bestRow, bestCol);
        }


    }

  
    static void Main()

    {
        int test = Convert.ToInt32(Console.ReadLine());//number of rows
        Console.WriteLine(test);

        int m, n;

        // Declare and initialize the matrix
        Console.WriteLine("please enter the number of rows needed?");
        m = Convert.ToInt32(Console.ReadLine());//number of rows
        Console.WriteLine("please enter the number of columns needed?");
        n = Convert.ToInt32(Console.ReadLine());//number of columns
        int[,] matrix = new int[m, n];
        for (int i = 0; i < m; i++) {//loop to read the values which will be stored in the array 

            for (int j = 0; j < n; j++) {
                Console.WriteLine("please enter the value needed fo row:" + i + ", column j:" + j + " ?");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());

            }
        }

        for (int i = 0; i < m; i++)
        {//loop to PRINT MATRIX
            Console.Write("[");

            for (int j = 0; j < n; j++)
            { if (j == n - 1)
                { Console.Write(matrix[i, j]); }
                else
                { Console.Write(matrix[i, j] + ","); }


            }
            Console.Write("]\n");

        }




        // Find the maximal sum platform of size 2 x 2





        Tuple<long, int, int> getvalues = sumRecursiveFn(matrix);


  
        // Print the result

        Console.WriteLine("The best sumation is:"+ getvalues.Item1);
        Console.WriteLine("The best row is:"+ getvalues.Item2+ "row is:"+ getvalues.Item3);

        for (int i = getvalues.Item2; i < getvalues.Item2 + 3; i++)
        {//loop to read the values which will be stored in the array 

            for (int j = getvalues.Item3; j < getvalues.Item3+3; j++)
            {
                Console.WriteLine("please enter the value needed fo row:" + i + ", column j:" + j + " ?");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());

            }
        }


    }
}