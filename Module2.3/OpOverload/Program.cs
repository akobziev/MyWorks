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
            {// скобки для читабельности кода - после if, for, foreach etc.
                Console.WriteLine("Ok");                
            }
            //Slide 3:Convert money to double, string and vice versa (IMPLICIT and EXPLICIT)
            //т.е. нужно было обявить операторы приведения
            //хорошо что Вы усвоили Convert и ToString(). Convert это вообще швецарский нож в котором есть все, так что в реальной ситуации если оператора приведения нет, не объявлен в классе, Convert подойдет
           // var doubleMoney = Convert.ToDouble(money1.Amount);
           // var strintMoney = money1.Amount.ToString();
            var strMoney = (string)money1; 
            var money3 = (Money)strMoney;

            Console.Read();
        }
    }
}
