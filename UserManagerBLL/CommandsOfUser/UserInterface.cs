using UserAccount.BLL.Users;
using UserManagerBLL.CalculatorExample;
using UserManagerBLL.CalculatorExample.Structures;

namespace UserManagerBLL.CommandsOfUser
{
    public class UserInterface
    {
        private readonly int num1;
        private readonly int num2;

        private readonly bool isVal1;
        private readonly bool isVal2;

        private readonly char symbol1;
        private readonly char symbol2;

        private readonly Word word1;
        private readonly Word word2;

        private readonly CalculatorInt calculatorInt;
        private readonly CalculatorBool calculatorBool;
        private readonly CalculatorChar calculatorChar;
        private readonly CalculatorStructString calculatorWord;

        public UserInterface(int val1, int val2)
        {
            num1 = val1;
            num2 = val2;

            calculatorInt = new CalculatorInt(val1, val2);
        }

        public UserInterface(bool isVal1, bool isVal2)
        {
            this.isVal1 = isVal1;
            this.isVal2 = isVal2;

            calculatorBool = new CalculatorBool(isVal1, isVal2);
        }

        public UserInterface(char symbol1, char symbol2)
        {
            this.symbol1 = symbol1;
            this.symbol2 = symbol2;

            calculatorChar = new CalculatorChar(symbol1, symbol2);
        }

        public UserInterface(Word word1, Word word2)
        {
            this.word1 = word1;
            this.word2 = word2;

            calculatorWord = new CalculatorStructString(word1, word2);
        }

        public OperationsOfUser<int> CreateIntAddition()
        {
            return new OperationsOfUser<int> { Value1 = num1, Value2 = num2, Result = calculatorInt.Addition() };
        }

        public OperationsOfUser<int> CreateIntSubstraction()
        {
            return new OperationsOfUser<int> { Value1 = num1, Value2 = num2, Result = calculatorInt.Subtraction() };
        }

        public OperationsOfUser<int> CreateIntMultiplication()
        {
            return new OperationsOfUser<int> { Value1 = num1, Value2 = num2, Result = calculatorInt.Multiplication() };
        }

        public OperationsOfUser<int> CreateIntDivision()
        {
            return new OperationsOfUser<int> { Value1 = num1, Value2 = num2, Result = calculatorInt.Division() };
        }

        public OperationsOfUser<bool> CreateBoolAddition()
        {
            return new OperationsOfUser<bool> { Value1 = isVal1, Value2 = isVal2, Result = calculatorBool.Addition() };
        }

        public OperationsOfUser<bool> CreateBoolSubstraction()
        {
            return new OperationsOfUser<bool> { Value1 = isVal1, Value2 = isVal2, Result = calculatorBool.Subtraction() };
        }

        public OperationsOfUser<bool> CreateBoolMultiplication()
        {
            return new OperationsOfUser<bool> { Value1 = isVal1, Value2 = isVal2, Result = calculatorBool.Multiplication() };
        }

        public OperationsOfUser<bool> CreateBoolDivision()
        {
            return new OperationsOfUser<bool> { Value1 = isVal1, Value2 = isVal2, Result = calculatorBool.Division() };
        }


        public OperationsOfUser<char> CreateCharAddition()
        {
            return new OperationsOfUser<char> { Value1 = symbol1, Value2 = symbol2, Result = calculatorChar.Addition() };
        }

        public OperationsOfUser<char> CreateCharSubstraction()
        {
            return new OperationsOfUser<char> { Value1 = symbol1, Value2 = symbol2, Result = calculatorChar.Subtraction() };
        }

        public OperationsOfUser<char> CreateCharMultiplication()
        {
            return new OperationsOfUser<char> { Value1 = symbol1, Value2 = symbol2, Result = calculatorChar.Multiplication() };
        }

        public OperationsOfUser<char> CreateCharDivision()
        {
            return new OperationsOfUser<char> { Value1 = symbol1, Value2 = symbol2, Result = calculatorChar.Division() };
        }

        public OperationsOfUser<Word> CreateWordAddition()
        {
            return new OperationsOfUser<Word> { Value1 = word1, Value2 = word2, Result = calculatorWord.Addition() };
        }

        public OperationsOfUser<Word> CreateWordSubstraction()
        {
            return new OperationsOfUser<Word> { Value1 = word1, Value2 = word2, Result = calculatorWord.Subtraction() };
        }

        public OperationsOfUser<Word> CreateWordMultiplication()
        {
            return new OperationsOfUser<Word> { Value1 = word1, Value2 = word2, Result = calculatorWord.Multiplication() };
        }

        public OperationsOfUser<Word> CreateWordDivision()
        {
            return new OperationsOfUser<Word> { Value1 = word1, Value2 = word2, Result = calculatorWord.Division() };        
        }
    }
}
