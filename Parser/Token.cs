using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse
{
    public class Token
    {
        public Type type;
        public Double number;

        public Token(Type type)
        {
            this.type = type;
            Console.WriteLine("Token: {0}", this.type);
        }

        public Token(Double number)
        {
            this.type = Type.Number;
            this.number = number;
            Console.WriteLine("Token: {0}, Data: {1}", this.type, this.number);
        }
    }

    public enum Type
    {
        LeftBracket, RightBracket, Exponent, Add, Subtract, Multipy, Divide, Number, End
    } 
}
