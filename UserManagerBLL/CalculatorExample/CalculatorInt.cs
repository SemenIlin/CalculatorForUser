namespace UserManagerBLL.CalculatorExample
{
    public class CalculatorInt : ICalculator<int>
    {
        private readonly int value1;
        private readonly int value2;

        public CalculatorInt(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        public int Addition()
        {
            return value1 + value2;
        }

        public int Division()
        {
            if(value2 == 0)
            {
                throw new System.DivideByZeroException();
            }

            return value1 / value2;
        }

        public int Multiplication()
        {
            return value1 * value2;
        }

        public int Subtraction()
        {
            return value1 - value2;
        }
    }
}
