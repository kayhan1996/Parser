using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser p = new Parser("2+2*3+2");
            Console.WriteLine(p.expression());

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
