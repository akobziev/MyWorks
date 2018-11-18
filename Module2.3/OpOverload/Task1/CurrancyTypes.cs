namespace OpOverload
{
    enum CurrencyTypes
    {

        // энумка на практике всегда дожна содеражть нулевым элемнтом какой нибудь Unknown или Unspecified или None
        // потому что энумку можно парсить со строки
        // и если не распарсили - 0, т.е. Unknown

        //Unknown
        UAH,
        USD,
        EU
    }
}
