using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        List<int> numTable = new List<int>();
        while (numTable.Count < 10)
        {
            int num = rand.Next(100);
            numTable.Add(num);
            Console.Write(num + ", ");
        }

        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < numTable.Count; i++)
        {
            for (int j = 0; j + 1 < numTable.Count - i; j++)
            {
                if (numTable[j] > numTable[j + 1])
                {
                    Swap(numTable, j, j + 1);
                }
            }
        }

        foreach (var item in numTable)
            Console.Write(item + ", ");

        void Swap(List<int> list, int idx1, int idx2)
        {
            int temp = list[idx1];
            list[idx1] = list[idx2];
            list[idx2] = temp;
        }
    }
}
