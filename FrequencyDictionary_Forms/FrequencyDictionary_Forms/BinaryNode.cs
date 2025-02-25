using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyDictionary_Forms
{
    public class Node
    {
        public char Value { get; }
        public int Priority { get; }
        public Node NextLeft { get; set; }
        public Node NextRight { get; set; }
        public Node(char value, int frequency)
        {
            Value = value;
            Priority = frequency;
        }
        public Node(char value, int frequency, Node left, Node right)
        {
            Value = value;
            Priority = frequency;
            NextLeft = left;
            NextRight = right;
        }
    }
}
