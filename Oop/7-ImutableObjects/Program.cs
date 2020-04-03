
using System;

namespace Oop._7_ImutableObjects
{
    class Program
    {
        static bool IsHappyHour { get; set; }
        //static void Reserve(MoneyAmount cost)
        //{
        //    if (IsHappyHour)
        //        cost.Amount *= .5M;
        //    Console.WriteLine("\nReserving an item that costs {0}.",cost);
        //}

        //static MoneyAmount Reserve(MoneyAmount cost)
        //{
        //    MoneyAmount newCost = cost;
        //    if (IsHappyHour)
        //    {
        //        newCost = new MoneyAmount
        //        {
        //            Amount = cost.Amount * .5M,
        //            CurrencySymbol = cost.CurrencySymbol
        //        };

        //    }
        //    Console.WriteLine("\nReserving an item that costs {0}.", cost);
        //    return newCost;
        //}        

        //static MoneyAmount Reserve(MoneyAmount cost)
        //{
        //    MoneyAmount newCost = cost;
        //    if (IsHappyHour)
        //    {
        //        newCost = new MoneyAmount(cost.Amount * .5M, cost.CurrencySymbol);
        //    }
        //    Console.WriteLine("\nReserving an item that costs {0}.", cost);
        //    return newCost;
        //}

        //static MoneyAmount Scale(MoneyAmount amount, decimal factor) =>
        //    new MoneyAmount(amount.Amount * factor, amount.CurrencySymbol);

        //static MoneyAmount Reserve(MoneyAmount cost)
        //{
        //    MoneyAmount newCost = cost;
        //    if (IsHappyHour)
        //    {
        //        newCost = Scale(cost, .5M);
        //    }
        //    Console.WriteLine("\nReserving an item that costs {0}.", cost);
        //    return newCost;
        //}

        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            if (IsHappyHour)
            {
                factor = .5M;
            }
            Console.WriteLine("\nReserving an item that costs {0}.", cost);
            return cost.Scale(factor);
        }

        //static MoneyAmount Reserve(MoneyAmount cost)
        //{
        //    decimal factor = 1;
        //    if (IsHappyHour)
        //    {
        //        factor = .5M;
        //    }
        //    Console.WriteLine("\nReserving an item that costs {0}.", cost);
        //    return cost * factor;
        //}

        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount >= cost.Amount;
            var finalCost = Reserve(cost);

            bool finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughMoney && finalEnough)
                Console.WriteLine("You will pay {0} with your {1}.",cost,wallet);
            else if(finalEnough)
                Console.WriteLine("This time, {0} will be enough to pay {1}.", wallet, finalCost);
            else
                Console.WriteLine("You cannot pay {0} with your {1}.", cost, wallet);
        }

        //static void Main(string[] args)
        //{
        //    Buy(new MoneyAmount { Amount = 12, CurrencySymbol = "USD" },
        //        new MoneyAmount { Amount = 10, CurrencySymbol = "USD" });

        //    Buy(new MoneyAmount { Amount = 7, CurrencySymbol = "USD" },
        //       new MoneyAmount { Amount = 10, CurrencySymbol = "USD" });

        //    IsHappyHour = true;
        //    Buy(new MoneyAmount { Amount = 7, CurrencySymbol = "USD" },
        //       new MoneyAmount { Amount = 10, CurrencySymbol = "USD" });

        //    Console.ReadKey();
        //}

        static void MainX(string[] args)
        {
            Buy(new MoneyAmount(12,"USD"),
                new MoneyAmount(10,"USD"));

            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));

            IsHappyHour = true;
            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));

            var x = new MoneyAmount(2, "USD");
            var y = new MoneyAmount(4, "USD");

            if (x.Equals(y))
                Console.WriteLine("Equal");
            if ((x*2).Equals(y))
                Console.WriteLine("Equal after scaling");

            Console.ReadKey();
        }
    }
}
