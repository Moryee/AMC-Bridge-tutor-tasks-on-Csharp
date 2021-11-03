using System;

namespace CircleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            //test number 3.1415926
            double circumference = Convert.ToDouble(Console.ReadLine());
            double area = Math.Pow(circumference, 2) / (4 * Math.PI);
            
            Console.Write(area.ToString("F9"));
        }
    }
}
