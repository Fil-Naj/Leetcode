using Leetcode.Extensions;
using System.Text;

namespace Leetcode.Solutions
{
    // This is the question where I found out the power of StringBuilder and the lacking += for string concatenation
    public class Leetcode0838 : ISolution
    {
        public string Name => "Push Dominoes";
        public string Description => "Return a string representing the final state.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var dominoes = ".L.R...LR..L..";
            var result = PushDominoes(dominoes);

            // Prettify
            Console.WriteLine($"Input: dominoes = {dominoes}");
            Console.WriteLine($"Output: {result}");
        }

        //public int[] MagR;
        //public int[] MagL;

        public string PushDominoes(string dominoes)
        {
            int N = dominoes.Length;
            int[] forces = new int[N];

            int force = 0;
            for (int i = 0; i < N; ++i)
            {
                if (dominoes[i] == 'R') force = N;
                else if (dominoes[i] == 'L') force = 0;
                else force = Math.Max(force - 1, 0);

                forces[i] += force;
            }

            force = 0;
            for (int i = N - 1; i >= 0; --i)
            {
                if (dominoes[i] == 'L') force = N;
                else if (dominoes[i] == 'R') force = 0;
                else force = Math.Max(force - 1, 0);

                forces[i] -= force;
            }

            StringBuilder sb = new();
            foreach (int f in forces)
                sb.Append(f > 0 ? 'R' : f < 0 ? 'L' : '.');
            return sb.ToString();
        }

        //public string PushDominoesSemiAsync(string dominoes)
        //{
        //    int N = dominoes.Length;
        //    MagR = new int[N];
        //    MagL = new int[N];

        //    Task.WaitAll(GetMagR(dominoes, N), GetMagL(dominoes, N));
        //    StringBuilder result = new();
        //    for (int i = 0; i < dominoes.Length; i++)
        //        result.Append(DominoFate(MagL[i], MagR[i]));

        //    return result.ToString();
        //}

        //public string PushDominoesSynchronous(string dominoes)
        //{
        //    int N = dominoes.Length;
        //    int[] magR = new int[N];
        //    int[] magL = new int[N];

        //    int? prevR = null;
        //    int? prevL = null;
        //    for (int i = 0; i < dominoes.Length; i++)
        //    {
        //        int leftIndex = dominoes.Length - 1 - i;

        //        if (dominoes[i] == 'L')
        //        {
        //            magR[i] = N;
        //        }
        //        else if (dominoes[i] == 'R')
        //        {
        //            magR[i] = 0;
        //        }
        //        else
        //        {
        //            if (i == 0)
        //                magR[i] = N;
        //            else
        //                magR[i] = magR[i - 1] == N ? N : magR[i - 1] + 1;
        //        }

        //        if (dominoes[leftIndex] == 'R')
        //        {
        //            magL[leftIndex] = N;
        //        }
        //        else if (dominoes[leftIndex] == 'L')
        //        {
        //            magL[leftIndex] = 0;
        //        }
        //        else
        //        {
        //            if (leftIndex == dominoes.Length - 1)
        //                magL[leftIndex] = N;
        //            else
        //                magL[leftIndex] = magL[leftIndex + 1] == N ? N : magL[leftIndex + 1] + 1;
        //        }
        //    }
        //    StringBuilder result = new();
        //    for (int i = 0; i < dominoes.Length; i++)
        //        result.Append(DominoFate(magL[i], magR[i]));

        //    return result.ToString();
        //}

        //private static string DominoFate(int leftPower, int rightPower)
        //{
        //    if (leftPower == rightPower)
        //        return ".";
        //    else if (leftPower > rightPower)
        //        return "R";
        //    else
        //        return "L";
        //}

        //private async Task GetMagR(string dominoes, int N)
        //{
        //    await Task.Run(() =>
        //    {
        //        for (int i = 0; i < N; i++)
        //        {
        //            if (dominoes[i] == 'L')
        //            {
        //                MagR[i] = N;
        //            }
        //            else if (dominoes[i] == 'R')
        //            {
        //                MagR[i] = 0;
        //            }
        //            else
        //            {
        //                if (i == 0)
        //                    MagR[i] = N;
        //                else
        //                    MagR[i] = MagR[i - 1] == N ? N : MagR[i - 1] + 1;
        //            }
        //        }
        //        return MagR;
        //    });
        //}

        //private async Task GetMagL(string dominoes, int n)
        //{
        //    await Task.Run(() =>
        //    {
        //        for (int leftIndex = n - 1; leftIndex >= 0; leftIndex--)
        //        {
        //            if (dominoes[leftIndex] == 'R')
        //            {
        //                MagL[leftIndex] = n;
        //            }
        //            else if (dominoes[leftIndex] == 'L')
        //            {
        //                MagL[leftIndex] = 0;
        //            }
        //            else
        //            {
        //                if (leftIndex == dominoes.Length - 1)
        //                    MagL[leftIndex] = n;
        //                else
        //                    MagL[leftIndex] = MagL[leftIndex + 1] == n ? n : MagL[leftIndex + 1] + 1;
        //            }
        //        }
        //        return MagL;
        //    });
        //}
    }
}
