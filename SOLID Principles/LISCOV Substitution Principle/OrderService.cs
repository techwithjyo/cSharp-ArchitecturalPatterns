using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.LISCOV_Substitution_Principle
{
    //------------------Old Code---------------
    public class OrderService
    {
        public virtual void ProcessOrder()
        {
            Console.WriteLine("Processing standard order");
        }
    }
    public class StandardOrder : OrderService
    {
        public override void ProcessOrder()
        {
            Console.WriteLine("Processing standard order");
        }
    }
    public class ExpressOrder : OrderService
    {
        public override void ProcessOrder()
        {
            throw new NotImplementedException("Express order processing not implemented");
        }
    }

    //The Liskov Substitution Principle states that objects of a superclass should be replaceable with 
    //        objects of a subclass without affecting the correctness of the program.In other words, 
    //    subclasses should be able to stand in for their base classes without causing errors or unexpected behavior.

    //In the above example, substituting an ExpressOrder object for an Order object will cause an exception 
    //        when the ProcessOrder method is called, violating the Liskov Substitution Principle.

    //-----------------------New Code---------------------
    public interface IOrder
    {
        void ProcessOrder();
    }
    public class StandardOrderNew : IOrder
    {
        public void ProcessOrder()
        {
            Console.WriteLine("Processing standard order");
        }
    }

    public class ExpressOrderNew : IOrder
    {
        public void ProcessOrder()
        {
            Console.WriteLine("Processing express order");
        }
    }

    //Refactoring of code is required at the real time scenario


}
