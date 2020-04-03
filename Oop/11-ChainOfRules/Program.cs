using Oop._11_ChainOfRules.Rules;
using Oop._8_Null;
using Oop._9_OptionalObjects;
using System;

namespace Oop._11_ChainOfRules
{
    class Program
    {
        static void MainX(string[] args)
        {
            var moneyBackGuaraantee = new TimeLimitedWarranty(DateTime.Today, TimeSpan.FromDays(7));
            var expressWarranty = new TimeLimitedWarranty(DateTime.Today, TimeSpan.FromDays(365));
            var circuitryWarranty = new LifetimeWarranty(DateTime.Today);

            var article = new SoldArticle(moneyBackGuaraantee, expressWarranty, new DefaultRules());
            article.InstallCircuitry(new Part(DateTime.Now), circuitryWarranty);

            Console.ReadLine();
        }
    }
}
