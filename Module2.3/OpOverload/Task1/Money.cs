namespace OpOverload
{
    class Money
    {
        public int Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }

        public Money()
        {

        }

        public Money(int amount, CurrencyTypes currency)
        {
            Amount = amount;
            CurrencyType = currency;
        }

        public static Money operator --(Money money)
        {
            return new Money
            {
                Amount = money.Amount - 1
            };
        }

        public static Money operator *(Money money, int value)
        {
            return new Money
            {
                Amount = money.Amount * value
            };
        }

        public static bool operator >(Money money1, Money money2)
        {
            return money1.Amount > money2.Amount;
        }

        public static bool operator <(Money money1, Money money2)
        {
            return money1.Amount < money2.Amount;
        }

        public static bool operator true(Money money)
        {
            return money.CurrencyType == CurrencyTypes.EU || money.CurrencyType == CurrencyTypes.UAH || money.CurrencyType == CurrencyTypes.USD;
        }

        public static bool operator false(Money money)
        {
            return money.CurrencyType == CurrencyTypes.EU || money.CurrencyType == CurrencyTypes.UAH || money.CurrencyType == CurrencyTypes.USD;
        }
    }
}
