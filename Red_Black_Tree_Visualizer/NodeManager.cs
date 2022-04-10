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
                        _rootHelper = _rootHelper.NodeRightChild;
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
                //if ((_newNode.NodeParent.NodeLeftChild != _defaultNode || _newNode.NodeParent.NodeRightChild != _defaultNode) && _newNode.NodeParent.Value < _newNode.NodeParent.NodeParent.Value)
                //{
                //    _newNode.NodeParent.Position.X -= 50;
                //    _newNode.NodeParent.NodeLeftChild.Position = new Position() { X = _newNode.NodeParent.Position.X - 30, Y = _newNode.NodeParent.Position.Y + 50 };
                //    _newNode.NodeParent.NodeRightChild.Position = new Position() { X = _newNode.NodeParent.Position.X + 30, Y = _newNode.NodeParent.Position.Y + 50 };
                //}
                //else if((_newNode.NodeParent.NodeLeftChild != _defaultNode || _newNode.NodeParent.NodeRightChild != _defaultNode)&& _newNode.NodeParent != _root)
                //{
                //    _newNode.NodeParent.Position.X += 50;
                //    _newNode.NodeParent.NodeLeftChild.Position = new Position() { X = _newNode.NodeParent.Position.X - 30, Y = _newNode.NodeParent.Position.Y + 50 };
                //    _newNode.NodeParent.NodeRightChild.Position = new Position() { X = _newNode.NodeParent.Position.X + 30, Y = _newNode.NodeParent.Position.Y + 50 };
                //}
                if (_newNode.Value < _nodeHelper.Value)
                {
                    _newNode.Position = new Position() { X = _newNode.NodeParent.Position.X - 30, Y = _newNode.NodeParent.Position.Y + 50 };
                }
                else
                {
                    _newNode.Position = new Position() { X = _newNode.NodeParent.Position.X + 30, Y = _newNode.NodeParent.Position.Y + 50 };
                }
            }
            ReDrawTree(_newNode);
            asd(_newNode);
            test(_root);
        }
        public void test(NodeModel _node)
        {
            if (_node != _root && (_node.NodeLeftChild != _defaultNode || _node.NodeRightChild != _defaultNode))
            {
                if (_node.Value < _root.Value)
                {
                    _node.Position.X -= 50;
                }
                else
                {
                    _node.Position.X += 50;
                }
            }
            if (_node.NodeLeftChild != _defaultNode)
            {
                if (_node != _root)
                {
                    _node.NodeLeftChild.Position = new Position() { X = _node.Position.X - 30, Y = _node.Position.Y + 50 };
                    _node.NodeRightChild.Position = new Position() { X = _node.Position.X + 30, Y = _node.Position.Y + 50 };
                }
                test(_node.NodeLeftChild);
            }
            if (_node.NodeRightChild != _defaultNode)
            {
                if (_node != _root)
                {
                    _node.NodeLeftChild.Position = new Position() { X = _node.Position.X - 30, Y = _node.Position.Y + 50 };
                    _node.NodeRightChild.Position = new Position() { X = _node.Position.X + 30, Y = _node.Position.Y + 50 };
                }
                test(_node.NodeRightChild);
            }
        }
        public void asd(NodeModel _newNode)
        {
            if ((_newNode.NodeParent.NodeLeftChild != _defaultNode || _newNode.NodeParent.NodeRightChild != _defaultNode) && _newNode.NodeParent.Value < _newNode.NodeParent.NodeParent.Value)
            {
                _newNode.NodeParent.Position.X -= 50;
                _newNode.NodeParent.NodeLeftChild.Position = new Position() { X = _newNode.NodeParent.Position.X - 30, Y = _newNode.NodeParent.Position.Y + 50 };
                _newNode.NodeParent.NodeRightChild.Position = new Position() { X = _newNode.NodeParent.Position.X + 30, Y = _newNode.NodeParent.Position.Y + 50 };
            }
            else if ((_newNode.NodeParent.NodeLeftChild != _defaultNode || _newNode.NodeParent.NodeRightChild != _defaultNode) && _newNode.NodeParent != _root)
            {
                _newNode.NodeParent.Position.X += 50;
                _newNode.NodeParent.NodeLeftChild.Position = new Position() { X = _newNode.NodeParent.Position.X - 30, Y = _newNode.NodeParent.Position.Y + 50 };
                _newNode.NodeParent.NodeRightChild.Position = new Position() { X = _newNode.NodeParent.Position.X + 30, Y = _newNode.NodeParent.Position.Y + 50 };
            }
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
            bool qwe = false;
            NodeModel _nodeHelper = _node.NodeRightChild;
            _node.NodeRightChild = _nodeHelper.NodeLeftChild;
            if (_nodeHelper.NodeLeftChild != _defaultNode)
            {
                _nodeHelper.NodeLeftChild.NodeParent = _node;
            }

            _nodeHelper.NodeParent = _node.NodeParent;
            if (_node.NodeParent == _defaultNode)
            {
                _nodeHelper.Position = new Position() { X = 0, Y = 0 };
                _root = _nodeHelper;
                qwe=true;
            }
            else
            {
                if (_node == _node.NodeParent.NodeLeftChild)
                {
                    _nodeHelper.Position = new Position() { X = _nodeHelper.NodeParent.Position.X - 30, Y = _nodeHelper.NodeParent.Position.Y + 50 };
                    _node.NodeParent.NodeLeftChild = _nodeHelper;
                }
                else
                {
                    _nodeHelper.Position = new Position() { X = _nodeHelper.NodeParent.Position.X + 30, Y = _nodeHelper.NodeParent.Position.Y + 50 };
                    _node.NodeParent.NodeRightChild = _nodeHelper;
                }
            }
            _nodeHelper.NodeLeftChild = _node;

            _nodeHelper.NodeLeftChild.Position = new Position() { X = _nodeHelper.Position.X - 30, Y = _nodeHelper.Position.Y + 50 };
            _node.NodeParent = _nodeHelper;

            _node.Level += 1;
            _nodeHelper.Level -= 1;
            DecreaseLevel(_nodeHelper.NodeRightChild);
            IncreaseLevel(_node.NodeLeftChild);
            asd(_nodeHelper.NodeRightChild);
            asd(_nodeHelper.NodeLeftChild);
            if(qwe)
            {
                _root.NodeLeftChild.Position.X -= 80;
                _root.NodeRightChild.Position.X += 80;
            }
                asd2(_root.NodeLeftChild);
                asd2(_root.NodeRightChild);

        }
        public void asd2(NodeModel _node)
        {

            if (_node.NodeLeftChild != _defaultNode)
            {
                _node.NodeLeftChild.Position = new Position() { X = _node.Position.X - 30, Y = _node.Position.Y + 50 };
                _node.NodeRightChild.Position = new Position() { X = _node.Position.X + 30, Y = _node.Position.Y + 50 };
                asd2(_node.NodeLeftChild);
            }
            if (_node.NodeRightChild != _defaultNode)
            {
                _node.NodeLeftChild.Position = new Position() { X = _node.Position.X - 30, Y = _node.Position.Y + 50 };
                _node.NodeRightChild.Position = new Position() { X = _node.Position.X + 30, Y = _node.Position.Y + 50 };
                asd2(_node.NodeRightChild);
            }
        }
        private void RotateRight(NodeModel _node)
        {
            bool qwe = false;
            NodeModel _nodeHelper = _node.NodeLeftChild;
            _node.NodeLeftChild = _nodeHelper.NodeRightChild;
            if (_nodeHelper.NodeRightChild != _defaultNode)
            {
                _nodeHelper.NodeRightChild.NodeParent = _node;
            }

            _nodeHelper.NodeParent = _node.NodeParent;
            if (_node.NodeParent == _defaultNode)
            {
                _nodeHelper.Position = new Position() { X = 0, Y = 0 };
                _root = _nodeHelper;
                qwe = true;
            }
            else
            {
                if (_node == _node.NodeParent.NodeRightChild)
                {
                    _nodeHelper.Position = new Position() { X = _nodeHelper.NodeParent.Position.X + 30, Y = _nodeHelper.NodeParent.Position.Y + 50 };
                    _node.NodeParent.NodeRightChild = _nodeHelper;
                }
                else
                {
                    _nodeHelper.Position = new Position() { X = _nodeHelper.NodeParent.Position.X - 30, Y = _nodeHelper.NodeParent.Position.Y + 50 };
                    _node.NodeParent.NodeLeftChild = _nodeHelper;
                }
            }
            _nodeHelper.NodeRightChild = _node;
            _nodeHelper.NodeRightChild.Position = new Position() { X = _nodeHelper.Position.X + 30, Y = _nodeHelper.Position.Y + 50 };
            _node.NodeParent = _nodeHelper;

            _nodeHelper.Level -= 1;
            _node.Level += 1;
            DecreaseLevel(_nodeHelper.NodeLeftChild);
            IncreaseLevel(_node.NodeRightChild);
            asd(_node);
            if (qwe)
            {
                _root.NodeLeftChild.Position.X -= 50;
                _root.NodeRightChild.Position.X += 50;
            }
            asd2(_root.NodeLeftChild);
            asd2(_root.NodeRightChild);

        }

        private void IncreaseLevel(NodeModel _node)
        {
            if (_node != _defaultNode && _node != _root)
            {
                _node.Level += 1;
                if (_node.NodeParent.NodeLeftChild == _node)
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X - 30, Y = _node.NodeParent.Position.Y + 50 };
                }
                else
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X + 30, Y = _node.NodeParent.Position.Y + 50 };
                }
                IncreaseLevel(_node.NodeLeftChild);
                IncreaseLevel(_node.NodeRightChild);
            }
        }
        private void DecreaseLevel(NodeModel _node)
        {
            if (_node != _defaultNode)
            {
                _node.Level -= 1;
                if (_node.NodeParent.NodeLeftChild == _node)
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X - 30, Y = _node.NodeParent.Position.Y + 50 };
                }
                else
                {
                    _node.Position = new Position() { X = _node.NodeParent.Position.X + 30, Y = _node.NodeParent.Position.Y + 50 };
                }
                DecreaseLevel(_node.NodeLeftChild);
                DecreaseLevel(_node.NodeRightChild);
            }
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
