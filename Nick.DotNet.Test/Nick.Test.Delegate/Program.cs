using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.Delegate
{
    /// <summary>
    /// P362
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            myDelegate = new CalculateDelegate(Add);
            myDelegate(100, 200);

            myDelegate = new CalculateDelegate(Subtract);
            myDelegate(100, 200);
        }


        public delegate void CalculateDelegate(Int32 x, Int32 y);

        public static void Add(Int32 x, Int32 y)
        {
            Console.WriteLine(x + y);
        }

        public static void  Subtract(Int32 x, Int32 y)
        {
            Console.WriteLine(x - y);
        }
        private static CalculateDelegate myDelegate;


    }
}
