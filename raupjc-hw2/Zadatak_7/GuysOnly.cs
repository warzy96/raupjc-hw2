using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_6;
namespace Zadatak_7
{
    public class GuysOnly
    {
        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy();
        }
        private static int IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return FactorialCalculator.FactorialDigitSumAsync(n).Result;
        }
    }
}
