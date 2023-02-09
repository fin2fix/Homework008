/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18

Определение. Произведением двух матриц А и В называется матрица С, элемент которой, находящийся на пересечении i-й строки и j-го столбца, 
равен сумме произведений элементов i-й строки матрицы А на соответствующие (по порядку) элементы j-го столбца матрицы В.
*/

int[,] InitRandomMatrix()
{
  Random rnd = new Random();
  int[,] matrix = new int[rnd.Next(2, 4), rnd.Next(2, 4)];
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
    { matrix[i, j] = rnd.Next(0, 10); }
  }
  return matrix;
}


void PrintMatrix(int[,] matrix, string text)
{
  Console.WriteLine(text);
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
    { Console.Write($"{matrix[i, j]} "); }

    Console.WriteLine();
  }
  Console.WriteLine();
}

(int[,], bool) TwoMatrixMultiple(int[,] matrixOne, int[,] matrixTwo)
{
  bool ifMultiplePosible = true;
  var matrixResult = new int[matrixOne.GetLength(0), matrixTwo.GetLength(1)];
  if (matrixOne.GetLength(1) != matrixTwo.GetLength(0))
  { ifMultiplePosible = false;
    return (matrixResult, ifMultiplePosible); }
  else
  {
    for (int i = 0; i < matrixOne.GetLength(0); i++)
    {
      for (int j = 0; j < matrixTwo.GetLength(1); j++)
      {
        matrixResult[i, j] = 0;

        for (int k = 0; k < matrixOne.GetLength(1); k++)
        {
          matrixResult[i, j] += matrixOne[i, k] * matrixTwo[k, j];
        }}}}
  return (matrixResult, ifMultiplePosible);
}

Console.WriteLine();
int[,] matrixOne = InitRandomMatrix();
PrintMatrix(matrixOne, "Первая матрица");
int[,] matrixTwo = InitRandomMatrix();
PrintMatrix(matrixTwo, "Вторая матрица");
(int[,] resultArray, bool ifMultiplePosible) = TwoMatrixMultiple(matrixOne, matrixTwo);
if (ifMultiplePosible) PrintMatrix(resultArray, "Результирующая матрица после умножения двух первых матриц");
else Console.WriteLine("Умножение матриц не возможно! Количество столбцов одной матрицы не равно количеству строк второй матрицы.");