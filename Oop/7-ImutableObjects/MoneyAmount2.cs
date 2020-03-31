namespace Oop._7_ImutableObjects
{
    sealed internal class MoneyAmount
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            Amount = amount;
            CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(Amount * factor, CurrencySymbol);

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        //correct 
        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
            (!ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) =>
            (ReferenceEquals(a, null) && ReferenceEquals(b, null)) ||
            (!ReferenceEquals(a, null) && !a.Equals(b));

        public override bool Equals(object obj) => Equals(obj as MoneyAmount);

        //this does not work with derived classes, as such this class needs sealed
        private bool Equals(MoneyAmount other) =>
            other != null &&
            Amount == other.Amount &&
            CurrencySymbol == other.CurrencySymbol;

        //this is needed with HasSet
        public override int GetHashCode() => Amount.GetHashCode() ^ CurrencySymbol.GetHashCode();

        public override string ToString() => $"{Amount} {CurrencySymbol}";
    }
}