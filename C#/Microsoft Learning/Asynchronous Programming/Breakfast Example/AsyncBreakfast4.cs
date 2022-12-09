using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    /* You have everything ready for breakfast at the same time except the toast.  Making the toast is the composition of an asynchronous operation
     * (toasting) the bread, and synchronous operations (adding the butter and the jam).  Updating the code illustrates an important concept.  The 
     * preceding code showed you that you can use Task or Task<TResult> objects to hold running tasks.  You await each task before using its result.
     * THe next step is to create methods that represent the combination of other work.  Before serving breakfast, you want to await the task that
     * represents toasing the bread before adding butter and jam.  You can represent that work with the following code. 
     */
    public class AsyncBreakfast4
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWIthButterAndJamAsync(2);

            var eggs = await eggsTask;
            Console.WriteLine("Eggs are ready");

            var bacon = await baconTask;
            Console.WriteLine("Bacon is ready");

            var toast = await toastTask;
            Console.WriteLine("Toast is ready");
            
            var oj = PourOj();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready");

            /* The previous change illustrated an important tehcnique for working with asynchronous code.  You compse tasks by separating the operations
             * into a new method that returns a task.  You can choose when to await that task.  You can start other tasks concurrently.  
             */
        }

        private static async Task<Toast> MakeToastWIthButterAndJamAsync(int number)
        {
            /* Note this method has the async modifier in its signature.  This signals to the compiler that this method contains an await statement, 
             * it contains asynchronous operations.  This method represents the task that toasts the bread, then adds butter and jam.  This method 
             * returns a Task<TResult> that represents the composition of the three operations
             */
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast; 
        }
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

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");


        private static Juice PourOj()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
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
