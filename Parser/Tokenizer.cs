using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse
{
    public class Tokenizer
    {
        char[] stream;
        public int index;
        int end;
        Token previousToken;
        Boolean inRevert = false;
        public Tokenizer(String expression)
        {
            this.stream = expression.ToArray();
            index = 0;
            end = stream.Length - 1;
        }

        public Token getNextToken() {


            Token token;
            if (inRevert) {
                token = previousToken;
                inRevert = false;
            }else if (index > end)
            {
                token = new Token(Type.End);
            }else if (stream[index] >= '0' && stream[index] <= '9')
            {
                string cache = "";
                while(index <= end && (stream[index] >= '0' && stream[index] <= '9' || stream[index] == '.'))
                {
                    cache += stream[index];
                    index += 1;
                }
                token = new Token(Double.Parse(cache));
            }else if (isOperator(stream[index]))
            {
                switch (stream[index])
                {
                    case '(':
                        token = new Token(Type.LeftBracket);
                        break;
                    case ')':
                        token = new Token(Type.RightBracket);
                        break;
                    case '^':
                        token = new Token(Type.Exponent);
                        break;
                    case '+':
                        token = new Token(Type.Add);
                        break;
                    case '-':
                        token = new Token(Type.Subtract);
                        break;
                    case '*':
                        token = new Token(Type.Multipy);
                        break;
                    case '/':
                        token = new Token(Type.Divide);
                        break;
                    default:
                        token = new Token(Type.End);
                        break;
                }
                index += 1;
            }
            else
            {
                token = new Token(Type.End);
            }

            previousToken = token;
            return token;
        }

        public void revert() {
            inRevert = true;
        }
        private Boolean isOperator(char character)
        {
            char[] operators = {'(', ')', '^', '+', '-', '*', '/' };
            if (operators.Contains(character))
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
