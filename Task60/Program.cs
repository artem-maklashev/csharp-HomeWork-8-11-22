/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */


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

void PrintArray(int[,,] matrix)
{
    Console.WriteLine($"\nЗначения элементов массива размерностью {matrix.GetLength(0)}x{matrix.GetLength(1)}x{matrix.GetLength(2)}\n");
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k]}({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,,] InitArray(int row, int col, int depth)
{
    int countOfNumbers = row * col * depth;

    Dictionary<int, int> RndmNumbers(int countOfNumbers)
    {
        int count = 0;
        Random rnd = new();
        int number = 0;
        Dictionary<int, int> dictOfNumbers = new();
        dictOfNumbers.Add(0,rnd.Next(10, 100));
        while (count <= countOfNumbers)
        {
            number = rnd.Next(10, 100);
            if (dictOfNumbers.ContainsValue(number)) continue;
            else
            {
                 count++;
                dictOfNumbers.Add(count, number);
            }
        }
        return dictOfNumbers;
    }
    Dictionary<int, int> dictNumbers = RndmNumbers(countOfNumbers);
    int[,,] matrix = new int[row, col, depth];
    int count = 0;
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            for (int k = 0; k < depth; k++)
            {
                matrix[i, j, k] = dictNumbers[count];
                count++;
            }
        }
    }
    return matrix;
}

int row = GetNumber("Введите число строк массива ");
int col = GetNumber("Введите число столбцов массива ");
int depth =GetNumber("Введите глубину массива ");
if (col * row * depth > 89)
{
    Console.WriteLine("При такой размерности массив невозможно заполнить уникальными двузначными значениями");
}
else
{
    int[,,] matrix = InitArray(row, col, depth);
    PrintArray(matrix);
}