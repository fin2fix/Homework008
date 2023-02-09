/*
Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/

int[,] InitRandomMatrix()
{
  Console.WriteLine();
  Console.WriteLine("Сгенерированная случайная матрица");
  Random rnd = new Random();
  int[,] matrix = new int[rnd.Next(3, 7), rnd.Next(3, 7)];
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
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


int[,] SortItemInRowsArray(int[,] array)
{
  // GetLength(0) — возвращает количество строк в двумерном массиве. числа. GetLength(1) — выдает количество элементов в строке.
  int tempNumber = 0;
  for (int i = 0; i < array.GetLength(0); i++)
  {
    for (int m = 0; m < array.GetLength(1); m++)
    {
      for (int j = 0; j < array.GetLength(1) - 1 - m; j++)
      {
        if (array[i, j] < array[i, j + 1])
        {
          tempNumber = array[i, j];
          array[i, j] = array[i, j + 1];
          array[i, j + 1] = tempNumber;
        }
      }
    }
  }
  return array;
}


int[,] matrix = InitRandomMatrix();
PrintMatrix(matrix);
Console.WriteLine();
Console.WriteLine("Новая матрица с отсортированными строками по убыванию значений");
int[,] newMatrix = SortItemInRowsArray(matrix);
PrintMatrix(newMatrix);