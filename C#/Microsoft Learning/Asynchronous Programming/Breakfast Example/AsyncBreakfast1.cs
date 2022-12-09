using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks; 

namespace AsyncProgramming
{
    /* 
     * The synchronously prepared breakfast took roughly 30 minutes because the total is the sum of each task.  The computer will block 
     * on each statement until the work is complete before movign on to the next statement.  That creates an unsatisfying breakfast.  The later
     * tasks wouldn't be started until the earlier tasks had been completed.  It would take much longer to create the breakfast, and some items 
     * woudl have gotten cold before being served.  If you want the computer to execute the above insturctions asynchronously, you must 
     * write asynchronous code.  These concerns are important for the programs you write today.  When you write client programs you want the
     * UI to be responsive to user input.  Your application shouldn't make a phone appear frozen while it's downloading data from the web.  When
     * you write server programs, you don't want threads blocked.  Those threads could be serving other requests.  Using synchronous code when
     * asynchronous alternatives exist hurts your ability to scale out less expensively.  You pay for those blocked threads.  Successful modern 
     * applications require asynchronous code required callbacks, completion events, or other means that obscured the original intent of the code.
     * The advantage of the synchronous code is that its step-by-step actions make it easy to scan and understand.  Traditional asynchronous models 
     * forces you to focus on the asynchronous nature of the code, not on the fundamental actions of the code.  Let's start by updating this code so 
     * that the thread doesn't block while tasks are running.  The await keyword provides a non-blocking way to start a task, then continue execution
     * when that task completes.  A simple asynchronous version of the make a breakfast could would look like the following snippet
     */
    public class AsyncBreakfast1
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Egg eggs = await FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = await FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOj();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready");

            /* This code doesn't block while the eggs or the bacon are cooking.  This code won't start any other tasks though.  You'd still put 
             * the toast in the toaster and stare at it until it pops.  But at least you'd respond to anyone that wanted your attention.  In a 
             * restaurant where multiple orders are placed, the cook could start another breakfast while the first is cooking.  Now, the thread
             * working on the breakfast isn't blocked while awaiting any started task that hasn't yet finished.  For some applications, this change
             * is all that's needed.  A GUI application still responds to the user with just this change.  However, for this scenario, you want more.
             * You don't want each of the component tasks to be executed sequentially.  It's better to start each of the component tasks to be 
             * executed sequentially.  It's better to start each of the component tasks before awaiting the previous tasks's completion
             * 
             * In many scnearios, you want to start several independent tasks immediatley.  THen, as each task finishes you can continue other work 
             * that's ready.  In the breakfast analogy, that's how you get breakfast done more quickly.  You also get everything done close to the 
             * same time.  You'll get a hot breakfast.  The System.Threading.Tasks.Task and related types are classes you can use to reason about 
             * tasks that are in progress.  That enables you to write code that more closely resembles the way you'd create breakfast.  You'd start
             * cooking the eggs, bacon, and toast at the same time.  As each requires action, you'd turn your attention to that task, take care of 
             * the next action, then wait for something else that requires your attention.  
             */

        }

        private static Juice PourOj()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice(); 
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast(); 
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on a plate");

            return new Bacon(); 
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs...");
            await Task.Delay(3000);
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
