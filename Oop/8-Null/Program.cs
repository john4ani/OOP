using System;

namespace Oop._8_Null
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article, bool inGoodCondition, bool isBroken)
        {
            //#Bad code, highlighting the probelem

            //var now = DateTime.Now;
            //if (inGoodCondition && !isBroken &&
            //    article.MoneyBackGuatrantee != null &&
            //    article.MoneyBackGuatrantee.IsValidOn(now))
            //{
            //    Console.WriteLine("Offer money back.");
            //}

            //if (isBroken && article.ExpressWarranty != null &&
            //    article.ExpressWarranty.IsValidOn(now))
            //{
            //    Console.WriteLine("Offer repair");
            //}
        }
    }
}
