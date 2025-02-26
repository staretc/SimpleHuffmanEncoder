using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary_Forms
{
    /// <summary>
    /// Class of methods to make Huffman Encoding from input text, encode and decode text.
    /// </summary>
    public class HuffmanAlgorithm
    {
        #region Properties
        /// <summary>
        /// Encoding Dictionary for input string
        /// </summary>
        public Dictionary<char, string> EncodingDictionary;
        /// <summary>
        /// Decoding Dictionary for encoded string
        /// </summary>
        public Dictionary<string, char> DecodingDictionary;
        /// <summary>
        /// Compression Ratio for encoded text
        /// </summary>
        public float CompressionRatio;
        #endregion

        #region Constructors
        public HuffmanAlgorithm()
        {
            EncodingDictionary = new Dictionary<char, string>();
            DecodingDictionary = new Dictionary<string, char>();
            CompressionRatio = 0;
        }
        #endregion

        #region Huffman Dictionary
        /// <summary>
        /// Creating a Huffman Encoding Dictionary from input text.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public void CreateHuffmanEncodingDictionary(string fileName)
        {
            string inputText = File.ReadAllText(fileName).ToLower();
            List<Tuple<int, char>> priorityChars = MakePriorities(inputText);
            Node root = CreateBinaryTree(priorityChars);
            EncodeChars(root, "");
            DecodingDictionary = EncodingDictionary.ToDictionary(x => x.Value, x => x.Key);
        }
        /// <summary>
        /// Making Huffman codes from binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="HuffmanCodes"></param>
        /// <param name="code"></param>
        private void EncodeChars(Node root, string code)
        {
            if (root == null)
                return;
            if (root.NextLeft == null && root.NextRight == null)
            {
                EncodingDictionary[root.Value] = code;
            }

            EncodeChars(root.NextLeft, code + "0");
            EncodeChars(root.NextRight, code + "1");
        }
        /// <summary>
        /// Making binary tree of frequencies of chars
        /// </summary>
        /// <param name="priorityChars"></param>
        /// <returns></returns>
        private Node CreateBinaryTree(List<Tuple<int, char>> priorityChars)
        {
            List<Tuple<int, Node>> nodesQueue = new List<Tuple<int, Node>>();
            foreach (var prCh in priorityChars)
            {
                nodesQueue.Add(new Tuple<int, Node>(prCh.Item1, new Node(prCh.Item2, prCh.Item1)));
            }
            while (nodesQueue.Count > 1)
            {
                nodesQueue = nodesQueue.OrderBy(x => x.Item1).ToList();
                Node left = nodesQueue.First().Item2;
                nodesQueue.Remove(nodesQueue.First());
                Node right = nodesQueue.First().Item2;
                nodesQueue.Remove(nodesQueue.First());
                int sum = left.Priority + right.Priority;
                nodesQueue.Add(new Tuple<int, Node>(sum, new Node('\0', sum, left, right)));
            }
            return nodesQueue.First().Item2;
        }
        /// <summary>
        /// Converting text into Dictionary with priorities of letters from input text.
        /// Less frequency - more priority.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private List<Tuple<int, char>> MakePriorities(string inputText)
        {
            Dictionary<char, int> counter = FrequencyCounter(inputText);
            List<Tuple<int, char>> priorityChars = new List<Tuple<int, char>>();
            foreach (var prCh in counter)
            {
                priorityChars.Add(new Tuple<int, char>(prCh.Value, prCh.Key));
            }
            priorityChars = priorityChars.OrderBy(x => x.Item1).ToList();
            return priorityChars;
        }
        /// <summary>
        /// Making Frequency Dictionary of letters from input text.
        /// </summary>
        /// <param name="inputText"></param>
        /// <returns></returns>
        private Dictionary<char, int> FrequencyCounter(string inputText)
        {
            Dictionary<char, int> counter = new Dictionary<char, int>();
            for (int i = 0; i < inputText.Length; i++)
            {
                if (counter.ContainsKey(inputText[i]))
                {
                    counter[inputText[i]]++;
                }
                else
                {
                    counter[inputText[i]] = 1;
                }
            }
            return counter;
        }
        #endregion

        #region Encoding-Decoding Methods
        public string EncodeString(string filePath)
        {
            string inputText = File.ReadAllText(filePath).ToLower();
            StringBuilder sb = new StringBuilder();
            var inputTextBitsCount = inputText.Length * 16;
            int outputTextBitsCount = 0;

            foreach (var chr in inputText)
            {
                if (EncodingDictionary.ContainsKey(chr))
                {
                    sb.Append(EncodingDictionary[chr]);
                    outputTextBitsCount += EncodingDictionary[chr].Length;
                }
                else
                {
                    throw new ArgumentNullException("Dictionary and input text are not compatible!");
                }
            }
            CompressionRatio = (float) inputTextBitsCount / outputTextBitsCount;
            return sb.ToString();
        }
        public string DecodeString(string filePath)
        {
            string inputText = File.ReadAllText(filePath);
            StringBuilder sb = new StringBuilder();
            string temp = "";
            foreach (var chr in inputText)
            {
                if(chr == '1' || chr == '0')
                {
                    temp += chr;
                    if (DecodingDictionary.ContainsKey(temp))
                    {
                        sb.Append(DecodingDictionary[temp]);
                        temp = "";
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid File!");
                }
            }
            if (temp != "")
            {
                throw new ArgumentException("Dictionary and input text are not compatible!");
            }
            return sb.ToString();
        }
        #endregion
    }
}
