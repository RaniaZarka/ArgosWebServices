using System;

namespace DemoInheritenceQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

           // MyBaseClass mbc = new MyBaseClass(); when the base class is abstract we cannot create an instance of the class anymore 

            //Console.WriteLine(mbc);

            MySpecialisedClass sc = new MySpecialisedClass();
            Console.WriteLine(sc);

            if (sc is IMyInterface)
            {
                (sc as IMyInterface).MyInterfaceMethod(); // if we use the sc as IMyInterface we can only see the method for the interface 
            }

            if (sc is MyBaseClass)
            {
                (sc as MyBaseClass).MyBaseClassMethod();
            }

           // sc. // if we use the object sc by itself we can see all the methods 

            Console.ReadLine();
        }
    }
}
