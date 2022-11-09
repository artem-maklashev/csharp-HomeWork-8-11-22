/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
 */

void SortMatrix(int[,] matrix)
{
    void SortRow(int[,] matrix, int rowNumber)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[rowNumber, j] < matrix[rowNumber, k])
                {
                    (matrix[rowNumber, j], matrix[rowNumber, k]) = (matrix[rowNumber, k], matrix[rowNumber, j]);
                }
            }
        }
    }
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        SortRow(matrix, i);
    }
}

int GetNumber(string message)
{
    Console.Write(message);
    bool isCorrect = false;
    int result = 0;
    while (!isCorrect)
        if (int.TryParse(Console.ReadLine(), out result))
            isCorrect = true;
        else
            Console.WriteLine("Введено не число. Повторите ввод.");

    return result;
}

int[,] InitArray(int m, int n)
{
    int[,] newArray = new int[m, n];
    Random rnd = new Random();
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            newArray[i, j] = rnd.Next(0, 10);
        }
    }
    return newArray;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}  ");
        }
        Console.WriteLine();
    }
}

int m = GetNumber("Введите количество строк ");
int n = GetNumber("Введите количество столбцов ");
int[,] matrix = InitArray(m, n);
PrintMatrix(matrix);
SortMatrix(matrix);
Console.WriteLine();
PrintMatrix(matrix);