using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    /* 
     * You start a task and hold on to the Task object that represents the work.  You'll await each task before working with its result. Lets make
     * these changes to the breakfast code.  The first step is to store the tasks for operations when they start, rather than awaiting them.  
     */
    public class AsyncBreakfast2
    {
        static async Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            // (v1)
            //Egg eggs = await FryEggsAsync(2);
            //Console.WriteLine("eggs are ready");
            // (v2)
            Task<Egg> eggsTask = FryEggsAsync(2);
            Egg eggs = await eggsTask;
            Console.WriteLine("Eggs are ready");

            // (v1)
            //Bacon bacon = await FryBaconAsync(3);
            //Console.WriteLine("bacon is ready");
            // (v2)
            Task<Bacon> baconTask = FryBaconAsync(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("Bacon is ready");

            // (v1)
            //Toast toast = await ToastBreadAsync(2);
            //ApplyButter(toast);
            //ApplyJam(toast);
            //Console.WriteLine("toast is ready");
            // (v2)
            Task<Toast> toastTask = ToastBreadAsync(2);
            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toast is ready");

            Juice oj = PourOj();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready");

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
