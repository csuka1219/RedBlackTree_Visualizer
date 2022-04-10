using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red_Black_Tree_Visualizer
{
    public enum NodeColor { red, black };

    public class NodeModel
    {
        public double Value { get; set; }
        public int Level { get; set; }
        public NodeColor NodeColor { get; set; }
        public Position Position { get; set; }
        public NodeModel NodeParent { get; set; }
        public NodeModel NodeLeftChild { get; set; }
        public NodeModel NodeRightChild { get; set; }
    }
}
