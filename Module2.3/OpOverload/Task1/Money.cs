using System;

namespace OpOverload
{
    class Money
    {
        public decimal Amount { get; set; }
        public CurrencyTypes CurrencyType { get; set; }

        public Money()
        {

        }
        //деньги всегда decimal, никогда инт либо дабл
        public Money(decimal amount, CurrencyTypes currency)
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

        public static Money operator *(Money money, decimal value)
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

        public static implicit operator Money(string value) 
        {
            //мы это не рассматривали, но в задании оно есть
            // Enum.Parse - механизм приведения строки к енумке: в метод передали тип и строку, на выходе получили object который привели к нужному типу
            //string.Split() - получения массива стрингов по разделителю (пробел, запятая и т.п.)
            //value.Split()[0] вернет нам значение до пробела
            //value.Split()[1] вернет нам значение после пробела
            string strCur = value.Split()[0];
            CurrencyTypes currency = (CurrencyTypes)Enum.Parse(typeof(CurrencyTypes),strCur);
            string strAmount = value.Split()[1];
            decimal amount = decimal.Parse(strAmount);
            return new Money(amount,currency);
        }

          public static implicit operator string( Money value) 
        {
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            //такой формат создания строки  - знак доллара и фигурные скобки - интерполяция
            return $"{value.CurrencyType.ToString()} {value.Amount}"; 
        }
    }
}
