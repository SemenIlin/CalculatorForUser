namespace UserManagerBLL.CalculatorExample
{
    public class CalculatorChar : ICalculator<char>
    {
        private readonly char symbol1;
        private readonly char symbol2;

        public CalculatorChar(char symbol1, char symbol2)
        {
            this.symbol1 = symbol1;
            this.symbol2 = symbol2;                       
        }

        public char Addition()
        {
            return (char)((int)symbol1 + (int)symbol2);
        }

        public char Division()
        {
            return (char)((int)symbol1 / (int)symbol2);
        }

        public char Multiplication()
        {
            return (char)((int)symbol1 * (int)symbol2);
        }

        public char Subtraction()
        {
            int result = (int)symbol1 - (int)symbol2;
            return result > 0 ? (char)result : '.';
        }
    }
}
