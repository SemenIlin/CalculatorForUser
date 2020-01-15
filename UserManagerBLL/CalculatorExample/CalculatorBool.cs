namespace UserManagerBLL.CalculatorExample
{
    public class CalculatorBool : ICalculator<bool>
    {
        private readonly bool isValue1;
        private readonly bool isValue2;

        public CalculatorBool(bool isValue1, bool isValue2)
        {
            this.isValue1 = isValue1;
            this.isValue2 = isValue2;
        
        }
        public bool Addition()
        {
            if (!isValue1 && !isValue2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Division()
        {
            if (isValue1 == isValue2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Multiplication()
        {
            if (isValue1 == isValue2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Subtraction()
        {
            if (isValue1 == isValue2)
            {
                return false;
            }
            else if (!isValue1)
            {
                return false;
            }
            else
            {
                return true;            
            }
        }
    }
}
