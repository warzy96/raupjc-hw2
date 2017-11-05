using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_6
{
    public class FactorialCalculator
    {
        public static async Task<int> FactorialDigitSumAsync(int a)
        {
            long factorial = 1;
            for (int i = 2; i <= a; i++)
            {
                factorial *= i;
            }

            int sum = 0;
            while (factorial > 0)
            {
                sum += (int)(factorial % 10);
                factorial /= 10;
            }
            return sum;
        }
    }
}
