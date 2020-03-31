namespace Oop._7_ImutableObjects
{
    internal class MoneyAmount0
    {
        public decimal Amount { get; set; }
        public string CurrencySymbol { get; set; }

        public override string ToString() => $"{Amount} {CurrencySymbol}";
    }
}