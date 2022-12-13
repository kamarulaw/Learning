using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void Del(); 
    class DelegatesWIthNamedVsAnonymousMethods3_DelegateMappedToBothStaticAndInstanceMethods
    {

        public void InstanceMethod()
        {
            Console.WriteLine("A message from the instance method");
        }

        public static void StaticMethod()
        {
            Console.WriteLine("A message from the static method");
        }
    }

    class TestDelegatesWIthNamedVsAnonymousMethods3_DelegateMappedToBothStaticAndInstanceMethodsClass
    {
        static void Main()
        {
            var sc = new DelegatesWIthNamedVsAnonymousMethods3_DelegateMappedToBothStaticAndInstanceMethods();

            // map the delegate to the instance method: 
            Del d = sc.InstanceMethod;
            d();

            // map the delgate to the static method
            d = DelegatesWIthNamedVsAnonymousMethods3_DelegateMappedToBothStaticAndInstanceMethods.StaticMethod;
            d(); 

            /* OUTPUT:
             *  A message from the instance method.
             *  A message from the static method. 
             */
        }
    }
}
