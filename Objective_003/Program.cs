/*Решение в группах задач:
Задача 57: Составить частотный словарь элементов двумерного массива. 
Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.*/

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

void FrequencyDictionary(int[,] original) //Сортировщик
{
    int originalCount_x = original.GetLength(0); // Размеры матрицы
    int originalCount_y = original.GetLength(1);

    int[] tempArray = new int[originalCount_x * originalCount_y]; // Ввод временного одномерного массива для складывания туда всех эл-тов матрицы (размер х*у)
    int tempIndex = 0;

    for (int i = 0; i < originalCount_x; i++)  // Заполняем временный одномерный массив пошагово
    {
        for (int j = 0; j < originalCount_y; j++)
        {
            tempArray[tempIndex] = original[i, j];
            tempIndex++;
        }
    }

    Array.Sort(tempArray); // Сортируем одномерный массив по возрастанию

    int find = 0;
    int index = 0;
    int count = 0;
    int temp = 0;

    while (index < tempArray.Length) //Пробежка по всему массиву
    {
        find = tempArray[index];

        for (int i = 0; i < tempArray.Length; i++)
        {
            if (tempArray[i] == find)
            {
                temp = i;
                count++;
            }
        }
        Console.WriteLine($"{find} occurs in matrix {count} times.");

        index = temp+1;

        count = 0;
    }
}

Console.WriteLine();
Console.WriteLine("First program will generate random matrix, using your information."); //Стартовое сообщение
Console.WriteLine();

InputNumber1: // Ввод кол-ва строк матрицы

Console.WriteLine("Please, set mumber of strings for matrix:");
int firstDimension = int.Parse(Console.ReadLine()!);

if (firstDimension < 1)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: Incorrect input! (The dimension size of matrix cannot be less than 1)");
    Console.ResetColor();
    goto InputNumber1;
}

InputNumber2: // Ввод кол-ва столбцов матрицы

Console.WriteLine("Please, set number of columns for matrix:");
int secondDimension = int.Parse(Console.ReadLine()!);

if (secondDimension < 1)
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

Console.WriteLine("Frequency Dictionary for matrix is:");

FrequencyDictionary(matrix);