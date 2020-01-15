namespace UserManagerBLL.CalculatorExample
{
    public interface ICalculator<T> where T : struct
    {
        //Сложение
        T Addition();

        //Вычитание
        T Subtraction();

        //Умножение
        T Multiplication();

        //Деление
        T Division();
    }
}
