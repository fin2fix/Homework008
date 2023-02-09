/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/


int[,] InitMatrix()
{
  int size = 4;
  int[,] matrix = new int[size, size];
  int number = 1;
  int i = 0;
  int j = 0;

  while (number <= matrix.GetLength(0) * matrix.GetLength(1)) // пока число меньше или равно площади (произведения сторон)
  {
    matrix[i, j] = number;
    number++;
    if (i <= j + 1 && i + j < matrix.GetLength(1) - 1)
      j++;
    else if (i < j && i + j >= matrix.GetLength(0) - 1)
      i++;
    else if (i >= j && i + j > matrix.GetLength(1) - 1)
      j--;
    else
      i--;
  }
  return matrix;
}


void PrintMatrix(int[,] matrix, string text)
{
  Console.WriteLine(text);
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
      if (matrix[i, j] < 10) Console.Write($"0{matrix[i, j]} ");
      else Console.Write($"{matrix[i, j]} ");
    Console.WriteLine();
  }
  Console.WriteLine();
}

Console.WriteLine();
int[,] matrix = InitMatrix();
PrintMatrix(matrix, $"Спиральная матрица размером {matrix.GetLength(0)} x {matrix.GetLength(1)}");