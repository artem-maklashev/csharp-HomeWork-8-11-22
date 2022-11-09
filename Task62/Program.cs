/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

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


int[,] GetSpiralMatrix(int row, int column)
{
    int[,] matrix = new int[row, column];
    int leftPoint = 0;
    int upPoint = 0;
    int rightPoint = matrix.GetLength(1) - 1;
    int downPoint = matrix.GetLength(0) - 1;
    int number = 1;
    int direction = 0;

    while (number <= row * column)
    {
        if (direction == 0) //вправо
        {
            for (int i = leftPoint; i <= rightPoint; i++)
            {
                matrix[upPoint, i] = number;
                number++;

            }
            direction++;
            upPoint++;
        }
        else if (direction == 1) //вниз
        {
            for (int i = upPoint; i <= downPoint; i++)
            {
                matrix[i, rightPoint] = number;
                number++;

            }
            rightPoint--;
            direction++;
        }
        else if (direction == 2)//влево
        {
            for (int i = rightPoint; i >= leftPoint; i--)
            {
                matrix[downPoint, i] = number;
                number++;

            }
            downPoint--;
            direction++;
        }
        else if (direction == 3) //вверх
        {
            for (int i = downPoint; i >= upPoint; i--)
            {
                matrix[i, leftPoint] = number;
                number++;
            }
            leftPoint++;
            direction = 0;
        }
    }
    return matrix;
}

int m = GetNumber("Введите число строк массива ");
int n = GetNumber("Введите число столбцов массива ");
int[,] matrix = GetSpiralMatrix(m, n);
PrintArray(matrix);
