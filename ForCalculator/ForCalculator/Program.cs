using Calculator;
using System;

namespace ForCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculation c = new Calculation();

           int result= c.SumMethod(2, 5);
            
            Console.WriteLine(result);
        }
    }
}
