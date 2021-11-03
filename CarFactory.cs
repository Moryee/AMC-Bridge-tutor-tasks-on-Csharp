using System;
using System.Linq;

namespace CarFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //test numbers 1 2 1 1 2 2 1 5 2 5 3 1 3 6 2 4 3 3 5 1 -1
            // 9 1 5 2 7 3 8 1 9 1 2 1 1 1 1 2 1 3 -1
            // 9 1 8 2 9 1 8 2 -1
            // 5 1 4 1 3 1 2 1 1 1 -1
            // 1 2 1 1 2 2 1 5 2 5 3 1 3 6 2 4 3 3 5 1 1 2 3 4 5 6 7 6 1 2 3 4 5 6 7 6 8 5 8 4 6 5 4 5 6 5 1 2 3 4 5 6 7 2 9 1 -1

            //prices for cars
            int[] price = { 150, 50, 125, 25, 20, 30 };

            //input numbers
            int[] input = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            /*
            Random random = new Random();
            int size = random.Next(1, 50);
            int[] input = new int[size + 1];
            input[size] = -1;
            for (int i = 0; i < length; i++)
            {

            }
            */

            //define number of cars
            string temp = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == -1)
                {
                    break;
                }
                if ((((i + 1) % 2) != 0) && (!temp.Contains(input[i].ToString())))
                {
                    temp += input[i];
                }
            }

            //initializing array
            int[,] output = new int[temp.Length, 2];
            for (int i = 0; i < temp.Length; i++)
            {
                output[i, 0] = int.Parse(temp[i].ToString());//id
                output[i, 1] = 1000;//price for basic configuration
            }

            //descripting parts in numbers
            //string outputString = "";
            for (int i = 0; i < output.GetLength(0); i++)
            {
                temp = "";

                for (int j = 0; j < input.Length - 1; j++)
                {
                    if (input[j] == -1)
                    {
                        break;
                    }
                    if (output[i, 0] == input[j] && ((j + 1) % 2) != 0 && !temp.Contains(input[j + 1].ToString()))
                    {
                        output[i, 1] += price[input[j + 1] - 1];
                        temp += input[j + 1];
                    }
                }
                //outputString += output[i, 1] + " ";
            }

            //sorting
            for (int i = 0; i < output.GetLength(0); i++)
            {
                for (int j = 0; j < output.GetLength(0) - 1; j++)
                {
                    if (output[j, 0] > output[j + 1, 0])
                    {
                        var lowerValue = output[j + 1, 0];
                        output[j + 1, 0] = output[j, 0];
                        output[j, 0] = lowerValue;

                        lowerValue = output[j + 1, 1];
                        output[j + 1, 1] = output[j, 1];
                        output[j, 1] = lowerValue;
                    }
                }
            }

            for (int i = 0; i < output.GetLength(0); i++)
            {
                Console.Write(output[i, 1] + " ");
            }

            Console.Write("-1");//termination code(not integer)

            //outputString += "-1";
            //Console.Write(outputString);
        }
    }
}
