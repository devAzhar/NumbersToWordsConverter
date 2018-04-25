namespace NumbersToWordsConverter.Web.Models
{
    public sealed class CurrencyToWordsInputModel
    {
        public double Amount { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCentsName { get; set; }
    }
}