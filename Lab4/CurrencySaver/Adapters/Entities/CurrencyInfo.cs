namespace CurrencySaver.Adapters.Entities
{
    public class CurrencyInfo
    {
        public int Nominal { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return $"{Nominal} {CurrencyCode} по курсу {Value} руб.";
        }
    }
}
