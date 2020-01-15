using UserManagerBLL.CalculatorExample.Structures;

namespace UserManagerBLL.CalculatorExample
{
    public class CalculatorStructString : ICalculator<Word>
    {
        private readonly Word word1;
        private readonly Word word2;

        public CalculatorStructString(Word word1, Word word2)
        {
            this.word1 = word1;
            this.word2 = word2;
        }
        public Word Addition()
        {
            return new Word { Words = word1.Words + word2.Words };
        }

        public Word Division()
        {
            return new Word { Words = CreateNewWord(word1.Words, word2.Words, false)};
        }

        public Word Multiplication()
        {
            return new Word { Words = CreateNewWord(word1.Words, word2.Words) };
        }

        public Word Subtraction()
        {
            return new Word { Words = CreateNewWord(word1.Words, word2.Words, true) };
        }

        private string CreateNewWord(string array1, string array2, bool substraction)
        {
            string tempArray;
            char newSymbol;
            char[] result;
            char[] temp;

            if (array1.Length < array2.Length)
            {
                tempArray = array1;
                array1 = array2;
                array2 = tempArray;
            }

            int length = array1.Length;            
            result = new char[length];

            temp = array1.ToCharArray(0, array1.Length - array2.Length);
            for(int i = 0; i < temp.Length; ++i)
            {
                result[i] = temp[i];
            }

            for(int i1 = array1.Length - 1, i2 = array2.Length - 1; i1 >= 0 && i2 >= 0; --i1, --i2)
            {
                if(array1[i1] == array2[i2])
                {
                    newSymbol = ' ';
                }
                else if((int)array1[i1] > (int)array2[i2])
                {
                    newSymbol = (char)((int)array1[i1] - (int)array2[i2]);
                }
                else
                {
                    newSymbol = (char)165;
                }

                result[i1] = newSymbol;
            }

            if (substraction)
            {
                return new string(result);
            }
            else
            {
                return new string(result).Replace(" ", "");
            }
        }

        private string CreateNewWord(string array1, string array2)
        {
            string result = "";

            for (int i = 0; i < array2.Length ; ++i)
            {
                for (int j = 0; j < array1.Length ; ++j)
                {
                    result += array1[j];
                    result += array2[i];
                }
            }

            return result;        
        }
    }
}
