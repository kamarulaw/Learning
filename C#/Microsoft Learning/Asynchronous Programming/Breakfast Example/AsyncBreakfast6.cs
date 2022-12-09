using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class AsyncBreakfast6
    {
        static async Task Main(string[] args)
        {
            /* Ther series of await statements at the end of the preceding code can be imporved by using methodds of the Task class.  One of those
             * APIs is WhenAll, which returns a Task that completes when all the tasks in its argument list have completed, as shown in the following
             * code
             */
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Juice oj = PourOj();
            Console.WriteLine("oj is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = MakeToastWIthButterAndJamAsync(2);

            await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("Eggs are ready");
            Console.WriteLine("Bacon is ready");
            Console.WriteLine("Toast is ready");
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
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(2000);
            Console.WriteLine("Fire! toast is runied");
            throw new InvalidOperationException("The toaster is on fire");

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
