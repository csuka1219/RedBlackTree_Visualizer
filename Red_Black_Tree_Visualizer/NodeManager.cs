using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_Black_Tree_Visualizer
{
    public class NodeManager
    {
        static NodeModel _root;
        private static NodeModel _defaultNode;

        public NodeManager()
        {
            _defaultNode = new NodeModel() { Value = 0, NodeColor = NodeColor.black, Level = 0 };
        }
        public void Record(double value)
        {
            if (_root == null)
            {
                _root = _defaultNode;
                _root.NodeParent = _defaultNode;
                _root.NodeLeftChild = _defaultNode;
                _root.NodeRightChild = _defaultNode;
                _root.Position = new Position() { X = 0, Y = 0 };
                _root.NodeColor = NodeColor.black;
            }
            NodeModel _newNode = new NodeModel() { Value = value, NodeColor = NodeColor.red, Level = 0 };
            NodeModel _nodeHelper = _defaultNode;
            NodeModel _rootHelper = _root;

            while (_rootHelper != _defaultNode)
            {
                _nodeHelper = _rootHelper;
                if (_newNode.Value < _rootHelper.Value)
                {
                    _rootHelper = _rootHelper.NodeLeftChild;
                }
                else
                {
                    if (_newNode.Value > _rootHelper.Value)
                    {
                        _rootHelper = _rootHelper.NodeRightChild;
                    }
                    else return;
                }
            }
            _newNode.NodeParent = _nodeHelper;

            if (_nodeHelper == _defaultNode)
            {
                _root = _newNode;
            }
            else
            {
                if (_newNode.Value < _nodeHelper.Value)
                {
                    _nodeHelper.NodeLeftChild = _newNode;
                }
                else
                {
                    _nodeHelper.NodeRightChild = _newNode;
                }
            }

            _newNode.NodeLeftChild = _defaultNode;
            _newNode.NodeRightChild = _defaultNode;
            _newNode.NodeColor = NodeColor.red;

            if (_newNode.NodeParent != _defaultNode)
            {
                _newNode.Level = _newNode.NodeParent.Level + 1;
            }
            ReDrawTree(_newNode);
            SetPosition(_root);
        }
        private void ReDrawTree(NodeModel _newNode)
        {
            NodeModel nodeHelper = _defaultNode;
            while (_newNode.NodeParent.NodeColor == NodeColor.red)
            {
                if (_newNode.NodeParent == _newNode.NodeParent.NodeParent.NodeLeftChild)
                {
                    nodeHelper = _newNode.NodeParent.NodeParent.NodeRightChild;
                    if (nodeHelper.NodeColor == NodeColor.red)
                    {
                        _newNode.NodeParent.NodeColor = NodeColor.black;
                        nodeHelper.NodeColor = NodeColor.black;
                        _newNode.NodeParent.NodeParent.NodeColor = NodeColor.red;
                        _newNode = _newNode.NodeParent.NodeParent;
                    }
                    else
                    {
                        if (_newNode == _newNode.NodeParent.NodeRightChild)
                        {
                            _newNode = _newNode.NodeParent;
                            RotateLeft(_newNode);
                        }
                        _newNode.NodeParent.NodeColor = NodeColor.black;
                        _newNode.NodeParent.NodeParent.NodeColor = NodeColor.red;
                        RotateRight(_newNode.NodeParent.NodeParent);
                    }
                }
                else
                {
                    nodeHelper = _newNode.NodeParent.NodeParent.NodeLeftChild;
                    if (nodeHelper.NodeColor == NodeColor.red)
                    {
                        _newNode.NodeParent.NodeColor = NodeColor.black;
                        nodeHelper.NodeColor = NodeColor.black;
                        _newNode.NodeParent.NodeParent.NodeColor = NodeColor.red;
                        _newNode = _newNode.NodeParent.NodeParent;
                    }
                    else
                    {
                        if (_newNode == _newNode.NodeParent.NodeLeftChild)
                        {
                            _newNode = _newNode.NodeParent;
                            RotateRight(_newNode);
                        }
                        _newNode.NodeParent.NodeColor = NodeColor.black;
                        _newNode.NodeParent.NodeParent.NodeColor = NodeColor.red;
                        RotateLeft(_newNode.NodeParent.NodeParent);
                    }
                }
            }
            _root.NodeColor = NodeColor.black;
            _root.Position = new Position() { X = 0, Y = 0 };
        }
        private void RotateLeft(NodeModel _node)
        {
            NodeModel _nodeHelper = _node.NodeRightChild;
            _node.NodeRightChild = _nodeHelper.NodeLeftChild;
            if (_nodeHelper.NodeLeftChild != _defaultNode)
            {
                _nodeHelper.NodeLeftChild.NodeParent = _node;
            }

            _nodeHelper.NodeParent = _node.NodeParent;
            if (_node.NodeParent == _defaultNode)
            {
                _root = _nodeHelper;
            }
            else
            {
                if (_node == _node.NodeParent.NodeLeftChild)
                {
                    _node.NodeParent.NodeLeftChild = _nodeHelper;
                }
                else
                {
                    _node.NodeParent.NodeRightChild = _nodeHelper;
                }
            }
            _nodeHelper.NodeLeftChild = _node;

            _node.NodeParent = _nodeHelper;

            _node.Level += 1;
            _nodeHelper.Level -= 1;
            DecreaseLevel(_nodeHelper.NodeRightChild);
            IncreaseLevel(_node.NodeLeftChild);
        }
        private void RotateRight(NodeModel _node)
        {
            NodeModel _nodeHelper = _node.NodeLeftChild;
            _node.NodeLeftChild = _nodeHelper.NodeRightChild;
            if (_nodeHelper.NodeRightChild != _defaultNode)
            {
                _nodeHelper.NodeRightChild.NodeParent = _node;
            }

            _nodeHelper.NodeParent = _node.NodeParent;
            if (_node.NodeParent == _defaultNode)
            {
                _root = _nodeHelper;
            }
            else
            {
                if (_node == _node.NodeParent.NodeRightChild)
                {
                    _node.NodeParent.NodeRightChild = _nodeHelper;
                }
                else
                {
                    _node.NodeParent.NodeLeftChild = _nodeHelper;
                }
            }
            _nodeHelper.NodeRightChild = _node;
            _node.NodeParent = _nodeHelper;

            _nodeHelper.Level -= 1;
            _node.Level += 1;
            DecreaseLevel(_nodeHelper.NodeLeftChild);
            IncreaseLevel(_node.NodeRightChild);
        }

        private void IncreaseLevel(NodeModel _node)
        {
            if (_node != _defaultNode && _node != _root)
            {
                _node.Level += 1;
                IncreaseLevel(_node.NodeLeftChild);
                IncreaseLevel(_node.NodeRightChild);
            }
        }
        private void DecreaseLevel(NodeModel _node)
        {
            if (_node != _defaultNode)
            {
                _node.Level -= 1;
                DecreaseLevel(_node.NodeLeftChild);
                DecreaseLevel(_node.NodeRightChild);
            }
        }
        public void SetPosition(NodeModel _node)
        {
            if (_root.NodeLeftChild != _defaultNode) { _root.NodeLeftChild.Position = new Position() { X = -300, Y = 50 }; }
            if (_root.NodeRightChild != _defaultNode) { _root.NodeRightChild.Position = new Position() { X = 300, Y = 50 }; }

            if (_node != _root && _node != _root.NodeLeftChild && _node != _root.NodeRightChild)
            {
                if (_node.Value < _node.NodeParent.Value)
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X - _root.NodeRightChild.Position.X / (_node.Level * 2 - _node.Level), Y = _node.NodeParent.Position.Y + 50 };
                }
                else
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X + _root.NodeRightChild.Position.X / (_node.Level * 2 - _node.Level), Y = _node.NodeParent.Position.Y + 50 };
                }
            }
            if (_node.NodeLeftChild != _defaultNode)
            {
                SetPosition(_node.NodeLeftChild);
            }
            if (_node.NodeRightChild != _defaultNode)
            {
                SetPosition(_node.NodeRightChild);
            }
        }
        //TODO Delete from tree
        public NodeModel GetDeletableNode(double value, NodeModel _node)
        {
            NodeModel _defaultReturnValue = _defaultNode;
            if (value == _node.Value) return _node;
            if (_node != _defaultNode)
            {
                if (value < _node.Value)
                {
                    _defaultReturnValue = GetDeletableNode(value, _node.NodeLeftChild);
                }
                else
                {
                    _defaultReturnValue = GetDeletableNode(value, _node.NodeRightChild);
                }
            }
            else
            {
                MessageBox.Show("The tree does not included this number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return _defaultReturnValue;
        }
        private void DeleteNode(double value)
        {
            NodeModel _deletableNode = GetDeletableNode(value, _root);
            if (_deletableNode == _defaultNode) return;
            bool is_Root = false;
            if (_deletableNode == _root)
            {
                is_Root = true;
            }
            NodeModel _nodehelper = _deletableNode.NodeLeftChild;
            if (_nodehelper.NodeRightChild == _defaultNode)
            {
                _nodehelper.Level -= 1;
                _nodehelper.NodeParent = _deletableNode.NodeParent;
                _nodehelper.NodeRightChild = _deletableNode.NodeRightChild;
                _nodehelper.NodeLeftChild = _defaultNode;
                _nodehelper.NodeParent.NodeRightChild = _nodehelper;

                RotateLeft(_nodehelper);
            }
            else
            {
                while (_nodehelper.NodeRightChild != _defaultNode)
                {
                    _nodehelper = _nodehelper.NodeRightChild;
                }

                _deletableNode.Value = _nodehelper.Value;
                _nodehelper.NodeParent.NodeRightChild = _defaultNode;
                if (is_Root)
                {
                    RotateRight(_deletableNode.NodeLeftChild);
                    _deletableNode.NodeLeftChild.NodeRightChild.NodeColor = NodeColor.black;
                    _deletableNode.NodeLeftChild.NodeColor = NodeColor.red;
                    _deletableNode.NodeLeftChild.NodeLeftChild.NodeColor = NodeColor.black;
                    if (_deletableNode.NodeLeftChild.NodeLeftChild.NodeLeftChild != _defaultNode || _deletableNode.NodeLeftChild.NodeLeftChild.NodeRightChild != _defaultNode)
                    {
                        _deletableNode.NodeLeftChild.NodeColor = NodeColor.black;
                    }
                    if (_deletableNode.NodeLeftChild.NodeRightChild.NodeLeftChild.NodeRightChild != _defaultNode && _deletableNode.NodeLeftChild.NodeRightChild.NodeLeftChild.NodeLeftChild == _defaultNode)
                    {
                        RotateLeft(_deletableNode.NodeLeftChild.NodeRightChild.NodeLeftChild);
                        RotateRight(_deletableNode.NodeLeftChild.NodeRightChild);
                    }
                }
            }
            _root.Position = new Position() { X = 0, Y = 0 };
            SetPosition(_root);
        }
        public NodeModel Get()
        {
            return _root;
        }
        public NodeModel GetDefault()
        {
            return _defaultNode;
        }
    }
}
