using Leetcode.Common_Objects;
using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0653 : ISolution
    {
        public string Name => "Two Sum IV - Input is a BST";
        public string Description => "Given the root of a Binary Search Tree and a target number k, return true if there exist two elements in the BST such that their sum is equal to the given target.";
        public Difficulty Difficulty => Difficulty.Easy;

        public void Solve()
        {
            this.PrintProblemStatement();

            TreeNode root = new(5,
                new(3,
                    new(2, null, null),
                    new(4, null, null)),
                new(6, null,
                    new(7, null, null)));

            var target = 9;
            var result = FindTarget(root, target);

            // Prettify
            root.PrintBinaryTree();
            Console.WriteLine($"Input: target = {target}");
            Console.WriteLine($"Output: {result}");
        }

        public bool FindTarget(TreeNode root, int k)
        {
            List<int> nums = new();
            Queue<TreeNode> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == null) continue;

                nums.Add(node.val);
                
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return TwoSum(nums.ToArray(), k) != null;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> values = new();
            for (int i = 0; i < nums.Length; i++)
            {
                int lookingFor = target - nums[i];
                if (values.TryGetValue(lookingFor, out var answer))
                    return new int[] { answer, i};
                else
                    if (!values.ContainsKey(nums[i])) values.Add(nums[i], i);
            }
            return null;
        }
    }
}
