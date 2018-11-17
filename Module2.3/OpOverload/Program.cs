using System;

namespace OpOverload
{
    class Program
    {
        static void Main(string[] args)
        {
            var money1 = new Money(10, CurrencyTypes.UAH);
            var money2 = new Money(20, CurrencyTypes.USD);

            money2--;
            money1.Amount*=3;
            var boolResult = money1 > money2;
            if (money1)
                Console.WriteLine("Ok");
            var doubleMoney = Convert.ToDouble(money1.Amount);
            var strintMoney = money1.Amount.ToString();
        }
    }
}
