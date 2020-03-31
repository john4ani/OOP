using System;

namespace Oop._8_Null
{
    class Program2
    {
        static void ClaimWarranty(SoldArticle article)
        {
            var now = DateTime.Now;
            //if (article.MoneyBackGuatrantee.IsValidOn(now))
            //{
            //    Console.WriteLine("Offer money back.");
            //}

            //if (article.ExpressWarranty.IsValidOn(now))
            //{
            //    Console.WriteLine("Offer repair");
            //}
            article.MoneyBackGuatrantee.Claim(now, () => Console.WriteLine("Offer money back."));
            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair"));
        }

        static void Main2()
        {
            var sellingDate = new DateTime(2016, 8, 9);
            var moneyBackSpan = TimeSpan.FromDays(30);
            var warrantySpan = TimeSpan.FromDays(365);

            var moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            var warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            // var noMoneyBack = new VoidWarranty();

            //var goods = new SoldArticle(noMoneyBack, warranty);

            var goods = new SoldArticle(VoidWarranty.Instance, warranty);

            ClaimWarranty(goods);
            Console.ReadLine();
        }
    }
}
