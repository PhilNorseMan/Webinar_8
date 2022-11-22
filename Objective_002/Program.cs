//Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. 
//В случае, если это невозможно, программа должна вывести сообщение для пользователя.

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

int[,] ChangeColumnsStrings(int[,] matr)
{
    int[,] result = new int[matr.GetLength(1), matr.GetLength(0)];

    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
           result[j,i] = matr[i,j];
        }
    }
    
    return result;
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

int[,] matrixChange = ChangeColumnsStrings(matrix); // Инициализация матрицы

Console.WriteLine("Changed matrix is:");

PrintMatrix(matrixChange); // Вывод матрицы
Console.WriteLine();