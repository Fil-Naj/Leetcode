namespace Leetcode.Extensions
{
    public static class SolutionExtension
    {
        public static void PrintProblemStatement(this ISolution solution)
        {
            Console.WriteLine($"{solution.Name} - {solution.Difficulty}");
            Console.WriteLine(solution.Description);
            Console.WriteLine();
        }

        public static string GetUrlString(this ISolution solution)
        {
            return string.Format("https://leetcode.com/problems/{0}/", string.Join("-", solution.Name.Split(" ")));
        }
    }
}
