using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SOLID_Principles.Open_Closed_Principle
{
    //The "O" in SOLID stands for the Open/Closed Principle(OCP). 
    //    This principle states that software entities(classes, modules, functions, etc.) 
    //    should be open for extension but closed for modification.In other words, 
    //    you should be able to add new functionality without changing existing code.
    public class AreaCalculator
    {
        public interface IShape
        {
            double CalculateArea();
        }

        public class Rectangle : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public double CalculateArea()
            {
                return Width * Height;
            }
        }
        public class Circle : IShape
        {
            public double Radius { get; set; }
            public double CalculateArea()
            {
                return Math.PI * Radius * Radius;
            }
        }
    }

    //A good example can be IDiscount interface as well with Gold Customer, Premium Customers

}
