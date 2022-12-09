using System;
using System.Threading.Tasks; 

namespace AsyncProgramming
{ 
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }
    public class SyncBreakfast
    {
        /*
         * The Task asynchronous programming model, TAP, provides an abstraction over asynchronous code.  You write code as a sequence
         * of statements, just like always.  You can read that code as through each statement completes before the next begins.  The compiler
         * performs many transofmraitons because some of those statements may start work and return a Tak that represents the ongoing work
         * 
         * That's the goal of this syntax: enable code that reads like a sequence of statements, but executes in a much more complicated order
         * based on external resource allocation and when tasks are complete.  It's analagous to hwo people give instructions for processes 
         * that include asynchrnous tasks.  Throughout this article you'll use an example of instructions for making breakfast to see how the async
         * and await keywords make it easier to reason about code that includes a seris of asynchrnous instructions.  You'd write the instructions
         * something like the following list to explain how to make a breakfast: 
         * 
         * 1. Pour a cup of coffee
         * 2. Heat a pan, then fry two eggs
         * 3. Fry three slices of bacon
         * 4. Toast two pieces of bread
         * 5. Add buttter and jam to the toast
         * 6. Pour a glass of orange juice
         * 
         * These tasks can be executed asynchrnoously.  You'd start warming the pan for eggs, then start the bacon.  You'd put the bread in the 
         * toaster, then start the eggs.  At each step of the process, you'd start a task, then turn your attention to tasks that are ready for 
         * your attention.  
         * 
         * Cooking breakfast is a good example of asynchronous work that isn't parallel.  Oen person (or thread) can handle all these tasks.  
         * Continuing this brekfast analogy, one person can make breakfast asynchronously by starting the next task before the first task 
         * completes.  The cooking processes whether or not someone is watching it.  As soon as you start warming the pan for the eggs, you can 
         * begin frying the bacon.  Once the bacon starts you can put the bread into the toaster.  
         * 
         * For a parallel algorithm, you'd need multiple cooks (or threads).  One would make the eggs, one the bacon, and so on.  Each one would be
         * focused on just that one task.  Each cook (or thread) would be blocked synchrnously waiting for the back to be ready to flip, or the 
         * toast to pop.  
         */

        public static void Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice(); 
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread on the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast(); 
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of back in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait(); 
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon(); 
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg(); 
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee(); 
        }
    }
}