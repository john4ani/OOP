
using System;

namespace Oop._8_Null
{
    class SoldArticle
    {
        public IWarranty MoneyBackGuatrantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        public IWarranty NotOperationalWarranty { get;}

        public SoldArticle(IWarranty moneyBackGuatrantee, IWarranty expressWarranty)
        {
            if (moneyBackGuatrantee == null)
                throw new ArgumentNullException(nameof(moneyBackGuatrantee));
            if (expressWarranty == null)
                throw new ArgumentNullException(nameof(expressWarranty));

            MoneyBackGuatrantee = moneyBackGuatrantee;
            ExpressWarranty = VoidWarranty.Instance;
            NotOperationalWarranty = expressWarranty;
        }

        public void VisibleDamaged()
        {
            MoneyBackGuatrantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGuatrantee = VoidWarranty.Instance;
            ExpressWarranty = NotOperationalWarranty;
        }
    }
}
