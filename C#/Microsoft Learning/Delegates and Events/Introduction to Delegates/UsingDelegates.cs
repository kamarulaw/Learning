using System;

namespace Delegates
{
    public class UsingDelegates
    {
        /* A delegate is a type that safely encapsulates a method, similar to a function pointer in C and C++.  Unlike C function pointers, 
         * delegates are object-oriented, type safe, and secure.  The type of a delegate is defined by the name of the delegate.  The following 
         * example declares a delegate method named Del that can encapsulate a method that takes a string as an argument and returns void 
         */

        public delegate void Del(string message);

        /*A delegate object is normally constructed by providing the name of the method the delegate will wrap, or with a lambda expression.
         * Once a delegate is instantiated a method call made to the delegate will be passed by the delegate to that method.  The parameters passed
         * delegate by the caller are passed by eht method, and the return value, if any, from the method is returned to the caller by the delgate.
         * This is known as invoking the delegate.  An instantiated delegate can be invoked as if it were the wrapped method itself.  For example:
         */
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        // Create a method for the delegate 
        Del handler_ = DelegateMethod;
        // Call the delegate
        handler_("Hello World");

        /* Delegate types are derived from the Delegate class in .NET. Delegate types are sealed - they cannot be derived from - and it is not 
         * posible to derive custom classes from Delegate.  Because the instantiated delegate is an object, it can be passed as an argument, or 
         * assigned to a property.  This allows a method to accept a delegate as a parameter, and call the delegate at some later time.  This 
         * is known as an asynchronous callback, and is a common method of notifying a caller when a long process has completed.  When a delegate
         * is used in this fashion, the code using the delegate does not need any knowledge of the implementation of the method being used.  
         * The functionality is similar to the encapsulation interfaces provide.
         * 
         * Another common use of callbacks is defining a custom comparision method and passing that delegate to a sort method.  It allows the 
         * caller's code to become part of the sort algorithm.  The following example method uses the Del type as a parameter.
         */
        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            callback("The number is: " + (param1 + param2).ToString());
        }

        // You can then pass the delegate created above to that method
        MethodWithCallBack(1, 2, handler_);


        public static void Main(string[] args)
        {
            /* Along with the static DelegateMethod shown previously, we now have three methods that can be wrapped by a Del instance.  
             * 
             * A delegate can call more than mone method when invoked.  This is referred to as multicasting.  To add an extra method 
             * to the delegate's list of methods - the invocation list - simply requires adding two delegates using the addition or addition 
             * assignment operators ('+' or '+=')
             */

            var obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            Del allMethodsDelegate = d1;
            allMethodsDelegate += d2;
            allMethodsDelegate += d3;

            /* At this point allMethodsDelegate contains three methods in its invocation list - Method1, Method2, and DelegateMethod.  The original
             * three delegates, d1, d2, and d3, remain unchanged.  When allMethodsDelegate is invoked, all three methods are called in order.  
             * If the delegate uses reference parameters, the reference is passed sequentially to each of the three methods in turn, and any changes
             * by one method are visible to the next method.  When any of the methods throws an exception that is not caught within the method, that
             * exception is passed to the caller of the delegate and no subsequent methods in the invocation list are called.  If the delegate and 
             * no subsequent methods in the invocation list are called.  If the delegate has a return value and/or out parameters, it returns the 
             * return value and parameters of the last method invoked.  To remove a method from the invocation list, use the subtraction or 
             * subtraction assignment operators ('-' or '-='). EG
             */

            allMethodsDelegate -= d1; // remove Method1

            Del oneMethodDelegate = allMethodsDelegate - d2; // copy allMethodsDelegate while removing d2

            /* Because delegate types are derived from System.Delegate, the methods and properties defined by the class can be called on the 
             * delegate.  For example, to find the number of methods in a delegate's invocation list, you may write:
             */
            int invocationCount = d1.GetInvocationList().GetLength(0);

            /* Delegates with more than one method in their invocation list derive from MulticastDelegate, which is a subclass of System.Delegate
             * The above code works in either case becuase both classes support GetInvocationList.
             */
        }

        public delegate void Delegate1();
        public delegate void Delegate2(); 
        public static void meth(Delegate1 d, Delegate2 e, System.Delegate f)
        {
            /* Multicast delegares are used extensively in event handling.Event source objects send event notifications to recipient objects that
            * have registered to receive that event.  To register for an event, the recipient creates a method designed to handle the event, the 
            * recipient creates a method designed to handle the event, then creates a delegate for that method and passes the delegate to the
            * event source.The source calls the delegate when the event occurs.The delegate then calls the event handling method on the recipient, 
            * delivering the event data.The delegate type for a given event is defined by the event source.For more, see Events.
            *
            * Comparing delegates of two different types assigned at complie-tuime will result in a compilation error.If the delegate instacnes are
            * statically of the type System.Delegate, then the comparison is allowed, but will return false at run time.For example: 
            */

            // compile-time error
            // Console.WriteLine(d == e); 

            // OK at at compile-time.  False if the run-time type of f is not the same as that of d. 
            Console.WriteLine(d == f);
        }
    }

    /* Using the delegate as an abstraction.  MethodWithCallback does not need to call the console directly - it does not have to be designed 
     * with a console in mind.  What MethodWithCallback does is simply prepare a string and pass the string to another method.  This is 
     * especially powerful since a delegated method can use any number of parameters.  
     * 
     * When a delegate is constructed to wrap an instance method, the delegate references both the instance and the method.  A delegate has no
     * knowledge of the instance type aside from the method it wraps, so a delegate can refer to any type of object as long as there is a 
     * method on that object that matches the delegate signature.  When a delegate is constructed to wrap a static method it only references
     * the method.  Consider the following declarations.  
     */
    public class MethodClass
    {
        public void Method1(string message) { }
        public void Method2(string message) { }
    }
}