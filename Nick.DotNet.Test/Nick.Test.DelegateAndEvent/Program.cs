using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.DelegateAndEvent
{
    /// <summary>
    /// P366
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            CalculatorManager cm = new CalculatorManager();

            calculator.MyCalculate += cm.Add;
            calculator.Calculate(500,200);
            calculator.MyCalculate += cm.Subtract;
            calculator.Calculate(100,200);

            //calculator.MyCalculate -= cm.Add;
            //calculator.Calculate(100, 200);

        }
    }

    public class Calculator
    {
        public class CalculateEventArgs : EventArgs
        {
            public readonly Int32 x, y;

            public CalculateEventArgs(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public delegate void CalculateEventHandler(object sender, CalculateEventArgs e);

        public event CalculateEventHandler MyCalculate;

        protected virtual void OnCalculate(CalculateEventArgs e)
        {
            if (MyCalculate != null)
            {
                MyCalculate(this, e);
            }
        }

        public void Calculate(Int32 x, Int32 y)
        {
            CalculateEventArgs e = new CalculateEventArgs(x, y);
            OnCalculate(e);
        }
    }

    public class CalculatorManager
    {
        public void Add(object sender, Calculator.CalculateEventArgs e)
        {
            Console.WriteLine(e.x + e.y);
        }
        public void Subtract(object sender, Calculator.CalculateEventArgs e)
        {
            Console.WriteLine(e.x - e.y);
        }
    }
}
