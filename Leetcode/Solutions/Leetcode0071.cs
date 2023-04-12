using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0071 : ISolution
    {
        public string Name => "Simplify Path";
        public string Description => "Given a string path, which is an absolute path (starting with a slash '/') to a file or directory in a Unix-style file system, convert it to the simplified canonical path.\r\n\r\nIn a Unix-style file system, a period '.' refers to the current directory, a double period '..' refers to the directory up a level, and any multiple consecutive slashes (i.e. '//') are treated as a single slash '/'. For this problem, any other format of periods such as '...' are treated as file/directory names.\r\n\r\nThe canonical path should have the following format:\r\n\r\n    The path starts with a single slash '/'.\r\n    Any two directories are separated by a single slash '/'.\r\n    The path does not end with a trailing '/'.\r\n    The path only contains the directories on the path from the root directory to the target file or directory (i.e., no period '.' or double period '..')\r\n\r\nReturn the simplified canonical path.";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            var path = "/a/./b/../../c/";
            var result = SimplifyPath(path);

            Console.WriteLine($"Input: path = {path}");
            Console.WriteLine($"Output: {result}");
        }

        public string SimplifyPath(string path)
        {
            var actions = path.Split('/');
            Stack<string> stack = new();
            foreach (var action in actions)
            {
                if (action == string.Empty || action == ".") continue;

                if (action == "..")
                    stack.TryPop(out var _);
                else
                    stack.Push(action);
            }

            return $"/{string.Join('/', stack.Reverse())}";
        }
    }
}
