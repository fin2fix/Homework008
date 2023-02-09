/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/

int[,,] InitRandom3DMatrix()
{
  Random rnd = new Random();
  int[,,] matrix = new int[rnd.Next(2, 3), rnd.Next(2, 3), rnd.Next(2, 3)];
  //        ключ  значение
  Dictionary<int, int> Unique = new Dictionary<int, int>();   //создаем словарь

  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
      for (int k = 0; k < matrix.GetLength(2); k++)
      {
        while (true)
        {
          matrix[i, j, k] = rnd.Next(10, 100);
          if (Unique.ContainsKey(matrix[i, j, k])) Unique[matrix[i, j, k]]++; //возвращает true / false, есть ли такой ключ? Плюсует счетчик если есть
          else Unique.Add(matrix[i, j, k], 1); // если у нас такого ключа нет, мы должны добавить такой ключ
          if (Unique[matrix[i, j, k]] <= 1) break;  // сравниваем: сколько у нас уже есть таких значений
        }
      }
    }
  }
  return matrix;
}


void Print3DMatrix(int[,,] matrix, string text)
{
  Console.WriteLine();
  Console.WriteLine(text);
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
      for (int k = 0; k < matrix.GetLength(2); k++)
      { Console.Write($"{matrix[i, j, k]} ({i},{j},{k})  "); }
      Console.WriteLine();
    }
  }
}

int[,,] matrix = InitRandom3DMatrix();
Print3DMatrix(matrix, "Сгенерированная случайная 3D матрица из неповторяющихся двузначных чисел.");
