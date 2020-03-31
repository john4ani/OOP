using System;

namespace Oop._8_Null
{
    class VoidWarranty : IWarranty
    {
        [ThreadStatic]
        private static VoidWarranty instance;
        private VoidWarranty() { }

        public static VoidWarranty Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {            
        }

        private bool IsValidOn(DateTime date) => false;
    }
}
