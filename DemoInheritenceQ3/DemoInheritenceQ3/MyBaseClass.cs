using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritenceQ3
{
    public abstract class MyBaseClass
    {

        public abstract string MyAbstractMethod();
        public  virtual string MyBaseClassMethod()
        {
            return "In class MyBaseClass";
        }

        public override string ToString()
        {
            return MyBaseClassMethod();
        }
    }
}
