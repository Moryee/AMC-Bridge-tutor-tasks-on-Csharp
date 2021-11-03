using System;
using System.Linq;

namespace DistanceBetweenPointAndPlaneIn3D
{
    class Program
    {
        static void Main(string[] args)//public or no?
        {
            //0.0 0.0 0.0 2.0 1.0 3.0 0.0 0.0 10.0
            //-123.0 0.0 -555.0 -2.0 1.0 3.0 -1.0 0.0 -10.0
            //-3.0 // point + point on plane + normal vector
            double[] input = Console.ReadLine().Split(' ').Select(n => Convert.ToDouble(n)).ToArray();

            //formulas plane equation
            //and
            //distance between point and plane
            double output = Math.Abs((input[0] * (input[6])) + (input[1] * (input[7])) + (input[2] * (input[8])) + ((input[6] * (-input[3])) + (input[7] * (-input[4])) + (input[8] * (-input[5])))) /
                Math.Sqrt(Math.Pow(input[6], 2) + Math.Pow(input[7], 2) + Math.Pow(input[8], 2));

            //Console.WriteLine(output);

            //if distance between point and normal vector > disttance point and reverse vector
            //formula between two points

            if (Math.Sqrt(Math.Pow((input[3] + input[6]) - input[0], 2) + Math.Pow((input[4] + input[7]) - input[1], 2) + Math.Pow((input[5] + input[8]) - input[2], 2)) > Math.Sqrt(Math.Pow((input[3] + (-input[6])) - input[0], 2) + Math.Pow((input[4] + (-input[7])) - input[1], 2) + Math.Pow((input[5] + (-input[8])) - input[2], 2)))
            {
                output *= -1;
            }

            Console.Write(output.ToString("F8"));

        }
    }
}
