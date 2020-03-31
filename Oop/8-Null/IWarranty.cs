using System;

namespace Oop._8_Null
{
    interface IWarranty
    {
        //bool IsValidOn(DateTime date);
        void Claim(DateTime onDate, Action onValidClaim);
    }
}