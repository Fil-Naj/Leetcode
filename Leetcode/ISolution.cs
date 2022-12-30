namespace Leetcode
{
    public interface ISolution
    {
        string Name { get; }
        string Description { get; }
        Difficulty Difficulty { get; }
        void Solve();
    }

    public enum Difficulty
    {
        None = 0,
        Easy,
        Medium,
        Hard
    }
}
