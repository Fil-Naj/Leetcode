namespace Leetcode.Common_Objects
{
    // Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        // Wrapper over print2DUtil()
        public void PrintBinaryTree()
        {
            // Pass initial space count as 0
            Print2DUtil(this, 0);
        }

        private static readonly int COUNT = 10;
        // Function to print binary tree in 2D
        // It does reverse inorder traversal
        // Source: https://www.geeksforgeeks.org/print-binary-tree-2-dimensions/
        private static void Print2DUtil(TreeNode root, int space)
        {
            // Base case
            if (root == null)
                return;

            // Increase distance between levels
            space += COUNT;

            // Process right child first
            Print2DUtil(root.right, space);

            // Print current node after space
            // count
            Console.Write("\n");
            for (int i = COUNT; i < space; i++)
                Console.Write(" ");
            Console.Write(root.val + "\n");

            // Process left child
            Print2DUtil(root.left, space);
        }

        public override string ToString()
        {
            return val.ToString();
        }
    }
}
