using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
                for (int j = 0; j < T; j++)
                {

                    char[] str = Console.ReadLine().ToCharArray();
                    int removeCount = 0;
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        if (str[i] == str[i + 1])
                            removeCount++;
                    }
                    Console.WriteLine(removeCount.ToString());
                }
    }
}