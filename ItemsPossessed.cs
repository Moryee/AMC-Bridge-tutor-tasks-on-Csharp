using System;
using System.Linq;

namespace ItemsProssessed
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 2 4 3 6 5 -1 1 6 3 7 8 -1
            //1 2 4 3 6 5 -1 1 6 3 7 8 1 -1
            //1 2 4 3 6 5 -1 1 6 3 7 8 2 3 4 -1
            //1 2 4 3 1 2 3 6 5 -1 1 6 3 7 8 2 3 2 3 4 5 4 -1
            int[] input = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int temp = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    if (i == 0)
                    {
                        if (input[j] == -1)
                        {
                            break;
                        }
                        temp++;
                    }
                    else
                    {
                        if (input[j + temp + 1] == -1)
                        {
                            if (j > temp)
                            {
                                //temp = j;
                            }
                            break;
                        }
                    }
                }
            }

            int[] A = new int[temp];
            int[] B = new int[input.Length - 2 - temp];
            //for (int i = 0; i < 2; i++)

            byte part = 1;
            for (int j = 0; j < input.Length; j++)
            {
                if (part == 1)
                {
                    if (input[j] == -1)
                    {
                        for (int k = j; k < A.Length; k++)
                        {
                            A[k] = -1;
                        }
                        part = 2;
                        continue;
                    }
                    A[j] = input[j];
                }
                else if (part == 2)
                {
                    if (input[j] == -1)
                    {
                        for (int k = j; k < B.Length; k++)
                        {
                            B[k] = -1;
                        }
                        break;
                    }
                    B[j - temp - 1] = input[j];
                }
            }


            int[] C = new int[temp];

            for (int i = 0; i < C.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i] == B[j])
                    {
                        C[i] = 1;
                    }
                }
                Console.Write(C[i] + " ");
            }

            Console.Write("-1");
        }
    }
}
