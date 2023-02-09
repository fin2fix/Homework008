/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки (для человека) с наименьшей суммой элементов: 1 строка
*/


int[,] InitRandomRectangleMatrix()
{
  Console.WriteLine();
  Console.WriteLine("Сгенерированная прямоугольная случайная матрица");
  Random rnd = new Random();
  int rows = 0;
  int columns = 0;

  while (true)
  {
    rows = rnd.Next(3, 7);
    columns = rnd.Next(3, 7);
    if (rows != columns) break;
  }

  int[,] matrix = new int[rows, columns];
  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    { matrix[i, j] = rnd.Next(0, 10); }
  }
  return matrix;
}


void PrintMatrix(int[,] matrix)
{
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
    { Console.Write($"{matrix[i, j]} "); }

    Console.WriteLine();
  }
}

int[] CountSumItemsInRows(int[,] array)
{
  int[] sumItemsInRowsArray = new int[array.GetLength(0)];
  int sumInRow = 0;

  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int j = 0; j < array.GetLength(1); j++)
    {
      sumInRow = sumInRow + array[i, j];
    }
    sumItemsInRowsArray[i] = sumInRow;
    sumInRow = 0;
  }
  return sumItemsInRowsArray;
}

(int, int) FindAddressMinItemArray(int[] anyArray)
{
  int valueMinItem = anyArray[0];
  int addressMinItem = 0;
  for (int i = 1; i < anyArray.Length; i++)
  {
    if (anyArray[i] < valueMinItem)
    {
      valueMinItem = anyArray[i];
      addressMinItem = i;
    }
  }
  return (addressMinItem, valueMinItem);
}



int[,] matrix = InitRandomRectangleMatrix();
PrintMatrix(matrix);
Console.WriteLine();
int[] sumItemsInRowsArray = CountSumItemsInRows(matrix);
(int addressMinItem, int sumItemsArray) = FindAddressMinItemArray(sumItemsInRowsArray);
Console.WriteLine($"Cтрока с наименьшей суммой элементов - это строка {addressMinItem + 1} (для человека) с суммой элементов = {sumItemsArray}");
