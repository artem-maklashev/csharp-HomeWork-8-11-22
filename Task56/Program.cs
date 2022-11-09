/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:

1 4 7 2

5 9 2 3

8 4 2 4

5 2 6 7 */

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
    int[,] matrix = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            matrix[i, j] = rnd.Next(1, 10);
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

int FindMinSum(int[,] matrix)
{
    int sum = 0;
    int minIndex = 0;

    int SumOfRow(int row)
    {
        sum = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            sum += matrix[row, i];
        }
        return sum;
    }

    int minimum = SumOfRow(0);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        sum = SumOfRow(i);
        if (sum < minimum)
        {
            minimum = sum;
            minIndex = i;
        }
    }
    return minIndex;
}

int row = GetNumber("Введите число строк ");
int column = GetNumber("Введите число столбцов ");
int[,] matrix = IntitMatrix(row, column);
PrintArray(matrix);
Console.WriteLine($"\nМинимальная сумма в {FindMinSum(matrix) + 1} строке");
