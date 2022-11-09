/* Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

int GetNumber(string message)
{
    Console.WriteLine(message);
    bool isCorrect = false;
    int result = 0;
    while (!isCorrect)
        if (int.TryParse(Console.ReadLine(), out result))
            isCorrect = true;
        else
            Console.WriteLine("Введено не число. Повторите ввод.");

    return result;
}

int[,] IntitMatrix(int m, int n)
{
    Random rnd = new();
    int[,] matrix = new int[m,n]; 
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i,j]= rnd.Next(1,10);
        }
    }
    return matrix;
}


void PrintArray(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]:d2} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] MultipyMatrix(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] resultMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
    int sum = 0;
    for (int i = 0; i < firstMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < secondMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                sum += firstMatrix[i,k]*secondMatrix[k,j];
            }
            resultMatrix[i,j] = sum;
            sum = 0;
        }
    }
    return resultMatrix;
}
 int rowFirst = GetNumber("Введите чистло строк первой матрицы ");
 int colFirst = GetNumber("введите число столбцов первой матрицы ");
 int colsSecond = GetNumber("введите число столбцов во второй матрице");
 int[,] firstMatrix = IntitMatrix(rowFirst, colFirst);
 int[,] secondMatrix = IntitMatrix(colFirst,colsSecond);
 int[,] resultMatrix = MultipyMatrix(firstMatrix, secondMatrix);
 PrintArray(firstMatrix);
 PrintArray(secondMatrix);
 PrintArray(resultMatrix);
