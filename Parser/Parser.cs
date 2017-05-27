using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse {
    public class Parser {
        Tokenizer tokenizer;
        public Parser(String statement) {
            this.tokenizer = new Tokenizer(statement);
        }

        public double expression() {
            double number = this.term();
            Token t = tokenizer.getNextToken();

            while (t.type == Type.Add || t.type == Type.Subtract) {
                if (t.type == Type.Add) {
                    number += this.term();
                } else {
                    number -= this.term();
                }
                t = tokenizer.getNextToken();
            }
            tokenizer.revert();
            return number;
        }

        public double term() {
            double number = this.exponent();
            Token t = tokenizer.getNextToken();

            while (t.type == Type.Multipy || t.type == Type.Divide) {
                if (t.type == Type.Multipy) {
                    number *= this.exponent();
                } else {
                    number /= this.exponent();
                }
                t = tokenizer.getNextToken();
            }
            tokenizer.revert();
            return number;
        }

        public double exponent() {
            double number = this.factor();
            Token token = tokenizer.getNextToken();
            if(token.type == Type.Exponent) {
                number = Math.Pow(number, this.factor());
            } else {
                tokenizer.revert();
            }
            return number;
        }

        public double factor() {
            double number = 0;
            Token token = tokenizer.getNextToken();

            if(token.type == Type.LeftBracket) {
                number = this.expression();
                Token rightBracket = tokenizer.getNextToken();
                if(rightBracket.type != Type.RightBracket) {
                    string error = "Missing right bracket at index " + tokenizer.index;
                    throw new System.ArgumentException(error);
                }
            }else if(token.type == Type.Number) {
                number = token.number;
            } else {
                throw new System.ArgumentException("Syntax Error detected");
            }

            return number;
        }
    }
}
