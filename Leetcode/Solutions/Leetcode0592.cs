using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0592 : ISolution
    {
        public string Name => "Fraction Addition and Subtraction";
        public string Description => "Given a string expression representing an expression of fraction addition and subtraction, return the calculation result in string format.\r\n\r\nThe final result should be an irreducible fraction. If your final result is an integer, change it to the format of a fraction that has a denominator 1. So in this case, 2 should be converted to 2/1.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var expression = "-1/2+1/2+1/3";
            var result = FractionAddition(expression);

            // Prettify
            Console.WriteLine($"Input: expression = {expression}");
            Console.WriteLine($"Output: {result}");
        }

        public string FractionAddition(string expression)
        {
            List<(int num, int den)> fractions = [];

            var currentNum = $"{expression[0]}";
            var currentDenom = string.Empty;

            var isNumerator = true;
            for (var i = 1; i < expression.Length; i++)
            {
                if (expression[i] == '-' || expression[i] == '+')
                {
                    fractions.Add((int.Parse(currentNum), int.Parse(currentDenom)));
                    currentNum = $"{expression[i]}";
                    currentDenom = string.Empty;
                    isNumerator = true;
                }
                else if (expression[i] == '/')
                {
                    isNumerator = false;
                }
                else
                {
                    if (isNumerator)
                    {
                        currentNum += expression[i];
                    }
                    else
                    {
                        currentDenom += expression[i];
                    }
                }
            }

            fractions.Add((int.Parse(currentNum), int.Parse(currentDenom)));

            var denomLcd = fractions.Select(f => f.den).Aggregate(Lcd);
            var sum = 0;
            foreach (var f in fractions)
            {
                sum += f.num * (denomLcd / f.den);
            }

            var gcf = Math.Abs(Gcd(sum, denomLcd));
            return $"{sum / gcf}/{denomLcd / gcf}";

        }

        int Gcd(int a, int b)
        {
            while (b != 0)
            {
                (b, a) = (a % b, b);
            }
            return a;
        }

        int Lcd(int a, int b)
        {
            return a / Gcd(a, b) * b;
        }
    }
}
