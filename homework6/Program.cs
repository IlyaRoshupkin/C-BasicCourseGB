using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    class Program
    {
        delegate int Function(int x);
        static void Main(string[] args)
        {
        }
        static int MyFunc(int g)
        {
            return g * g * g;
        }
    }
}
