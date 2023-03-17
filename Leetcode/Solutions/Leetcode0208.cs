using Leetcode.Extensions;

namespace Leetcode.Solutions
{
    public class Leetcode0208 : ISolution
    {
        public string Name => "Implement Trie (Prefix Tree)";
        public string Description => "A trie (pronounced as \"try\") or prefix tree is a tree data structure used to efficiently store and retrieve keys in a dataset of strings. There are various applications of this data structure, such as autocomplete and spellchecker.\r\n\r\nImplement the Trie class:\r\n\r\n    Trie() Initializes the trie object.\r\n    void insert(String word) Inserts the string word into the trie.\r\n    boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.\r\n    boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.\r\n";
        public Difficulty Difficulty => Difficulty.Medium;

        public void Solve()
        {
            this.PrintProblemStatement();

            Trie trie = new();
            trie.Insert("apple");
            Console.WriteLine($"trie.Search(\"apple\"). Expected: True, Actual {trie.Search("apple")}");
            Console.WriteLine($"trie.Search(\"app\"). Expected: False, Actual {trie.Search("app")}");
            Console.WriteLine($"trie.StartsWith(\"app\"). Expected: True, Actual {trie.StartsWith("app")}");
            trie.Insert("app");
            Console.WriteLine($"trie.Search(\"app\"). Expected: True, Actual {trie.Search("app")}");
        }

        // Was nice to learn something new that is also practical
        public class Trie
        {
            private TrieNode _root;

            public Trie()
            {
                _root = new();
            }

            public void Insert(string word)
            {
                var node = _root;
                for (int i = 0; i < word.Length; i++)
                {
                    var currentChar = word[i];
                    if (!node.ContainsKey(currentChar))
                        node.Add(currentChar, new TrieNode());

                    node = node.GetNode(currentChar);
                }

                node.IsEnd = true;
            }

            private TrieNode SearchPrefix(string word)
            {
                TrieNode node = _root;
                for (int i = 0; i < word.Length; i++)
                {
                    var currentLetter = word[i];
                    if (node.ContainsKey(currentLetter))
                        node = node.GetNode(currentLetter);
                    else
                        return null;
                }

                return node;
            }

            public bool Search(string word)
            {
                var node = SearchPrefix(word);
                return node != null && node.IsEnd;
            }

            public bool StartsWith(string prefix)
            {
                var node = SearchPrefix(prefix);
                return node != null;
            }
        }

        public class TrieNode
        {
            public bool IsEnd;
            public TrieNode[] Links;

            public TrieNode(bool isEnd = false)
            {
                Links = new TrieNode[26];
                IsEnd = isEnd;
            }

            public void Add(char c, TrieNode node) =>
                Links[c - 'a'] = node;

            public bool ContainsKey(char  c) =>
                Links[c - 'a'] != null;

            public TrieNode GetNode(char c) =>
                Links[c - 'a'];
        }
    }
}
