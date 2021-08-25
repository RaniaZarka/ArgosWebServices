using System;
using System.Collections.Generic;
using System.Text;

namespace DemoInheritenceQ3
{ 
    public class MySpecialisedClass : MyBaseClass, IMyInterface
    {
        public override string MyAbstractMethod()
        {
            return " in MyAbstractMethod";
        }

        public override string MyBaseClassMethod()
        {
          
            //return "In the specialized class override my base class"; in this line it will show this message 
            return base.MyBaseClassMethod() + "In the specialized class override my base class"; // in this line it will show the method from base  + our message 
        }

        public string MyInterfaceMethod()
        {
            return "in specialized class MyInterfaceMethod";
        }

        public string MySpecializedMethod()
        {
            return "MySpecializedMethod";
        }
        public override string ToString()
        {
            return base.ToString() + MyInterfaceMethod();
        }
    }

    
}
