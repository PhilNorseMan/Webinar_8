//Задача 53: Задайте двумерный массив. Напишите программу, которая поменяет местами первую и последнюю строку массива.

void PrintMatrix(int[,] matr) // Принтер матрицы
{
    int count_x = matr.GetLength(0);
    int count_y = matr.GetLength(1);
    
    for (int i = 0; i < count_x; i++)
    {
        for (int j = 0; j < count_y; j++)
            Console.Write(matr[i, j] + "    ");
        Console.WriteLine();
    }
}

void FillMatrix(int[,] matr) // Рандомайзер
{
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            matr[i, j] = new Random().Next(1, 10);
        }
    }
}

int[,] ChangeFirstLastStrings(int[,] matr)
{
    int temp = 0;
    for (int j = 0; j < matr.GetLength(1); j++)
    {
        temp = matr[0,j];
        matr[0,j] = matr[matr.GetLength(0) - 1, j];
        matr[matr.GetLength(0)-1, j] = temp;
    }

    return matr;
}

Console.WriteLine();
Console.WriteLine("First program will generate random matrix, using your information."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод кол-ва строк матрицы

Console.WriteLine("Please, set mumber of strings for matrix:");
int firstDimension = int.Parse(Console.ReadLine()!);

if(firstDimension < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber1;
    }

InputNumber2: // Ввод кол-ва столбцов матрицы

Console.WriteLine("Please, set number of columns for matrix:");
int secondDimension = int.Parse(Console.ReadLine()!);

if(secondDimension < 1) 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
        Console.ResetColor();
        goto InputNumber2;
    }

Console.WriteLine();

int[,] matrix = new int[firstDimension, secondDimension]; // Инициализация матрицы

Console.WriteLine("Generated matrix is:");

FillMatrix(matrix); // Заполнение матрицы рандомом
PrintMatrix(matrix); // Вывод матрицы
Console.WriteLine();

int[,] matrixChange = ChangeFirstLastStrings(matrix); // Инициализация матрицы

Console.WriteLine("Changed matrix is:");

PrintMatrix(matrixChange); // Вывод матрицы
Console.WriteLine();