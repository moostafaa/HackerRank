using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class Solution
{
    static void Main(String[] args)
    {
        int n = Int16.Parse(Console.ReadLine());
        byte[][] numbers = new byte[n][];
        StringBuilder console = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            numbers[i] = new byte[n];
            char[] rownums = Console.ReadLine().ToCharArray();

            for (int j = 0; j < n; j++)
            {
                numbers[i][j] = byte.Parse(rownums[j].ToString());
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == 0 || i == n - 1 || j == 0 || j == n - 1)
                    console.Append(numbers[i][j]);
                else
                {
                    int current = numbers[i][j];
                    if (current > numbers[i - 1][j] && current > numbers[i + 1][j]
                        && current > numbers[i][j - 1] && current > numbers[i][j + 1])
                        console.Append("X");
                    else
                        console.Append(numbers[i][j]);
                }
            }
            console.AppendLine();
        }

        Console.WriteLine(console.ToString());
    }
}