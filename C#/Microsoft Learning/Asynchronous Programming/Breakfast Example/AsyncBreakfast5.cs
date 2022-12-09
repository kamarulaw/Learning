using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    /* Up to this point, we've implictly assumed that all these tasks complete successfully.  Asynchronous methods throw exceptions, just like their 
     * synchronous counterparts.  Asynchronous support for exceptions and error handling strives for the same goals as asynchronous support in 
     * general.  You should write code that reads like a series of synchronous support in general.  You should write code that reads like a series 
     * of synchronous statements.  Takss throw exceptions when they can't complete successfully.  The client code can catch those exceptions when 
     * a started task is awaited.  For example, let's assume that the toaster catches fire while making the toast.  You can simulate that by modifying 
     * the ToastBreadAsync method to match the following code
     */
    public class AsyncBreakfast5
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
        }

        private static async Task<Toast> MakeToastWIthButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            /* WHen code running asynchronously throws an exception, that exception is stored in the Task.  The Task.Exception property is an
             * System.AggregateException because more than one exception may be thrown during asynchronous work.  Any exception thrown is added
             * to the AggregateException.InnerExceptions collection.  If that Exception property is null, a new AggregateException is created
             * and the thrown exception is the first item in the collection
             * 
             * THe most common scenario for a faulted task is that the Exception property contains exactly one exception.  WHen code awaits a 
             * faulted task, the first exception in the AggregateException.InnerExceptions collection is rethrown.  That's why the output from
             * this example shows an InvalidOperationException instead of an AggregateException.  Extracting the first inner exception makes working 
             * with asynchronous methods as similar as possible to working with their synchronous counterparts.  You can example the Exception property 
             * in your code when your scenario may generate multiple exceptions.  
             */
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            Console.WriteLine("Fire! toast is runied");
            throw new InvalidOperationException("The toaster is on fire");
            await Task.Delay(1000);
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
