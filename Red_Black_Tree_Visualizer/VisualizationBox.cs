using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_Black_Tree_Visualizer
{
    public class VisualizationBox : PictureBox
    {
        public NodeModel _root = new NodeModel();
        public NodeManager _nodeManager = new NodeManager();
        private static NodeModel _defaultNode = new NodeModel();
        public VisualizationBox()
        {

        }
        public void Print()
        {
            _root= _nodeManager.Get();
            _defaultNode = _nodeManager.GetDefault();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_root.Position == null)
            {
                return;
            }

            pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            base.OnPaint(pe);
            int _offset = Width / 2 - 45 / 2 - _root.Position.X;
            GetNodeFromTree(_root, _offset, pe);
        }
        public void GetNodeFromTree(NodeModel _node, int _offset, PaintEventArgs pe)
        {
            
            DrawNode(_node, _offset, pe.Graphics);

            if (_node.NodeLeftChild != _defaultNode)
            {
                DrawLine(_node.Position, _node.NodeLeftChild.Position, _offset, pe.Graphics,_node.Level);
                GetNodeFromTree(_node.NodeLeftChild, _offset, pe);
            }
            if (_node.NodeRightChild!= _defaultNode)
            {
                DrawLine(_node.Position, _node.NodeRightChild.Position, _offset, pe.Graphics,_node.Level);
                GetNodeFromTree(_node.NodeRightChild, _offset, pe);
            }
        }
        private void DrawLine(Position fromNodePosition, Position toNodePosition, int offset, Graphics grapics,int a)
        {
            Pen linePen = new Pen(Color.Black, 1);
            Point _startPoint;
            Point _endPoint;
            if (fromNodePosition.X < toNodePosition.X)
            {
                _startPoint = new Point
                {
                    X = fromNodePosition.X + 45 / 2 + offset+23-a,
                    Y = fromNodePosition.Y + 45 / 2 +(fromNodePosition.Y/10)
                };
                _endPoint = new Point
                {
                    X = toNodePosition.X + 45 / 2 + offset,
                    Y = toNodePosition.Y + 45 / 2
                };

            }
            else
            {
                _startPoint = new Point
                {
                    X = fromNodePosition.X + 45 / 2 + offset - 23 + a,
                    Y = fromNodePosition.Y + 45 / 2 + (fromNodePosition.Y / 10)
                };
                _endPoint = new Point
                {
                    X = toNodePosition.X + 45 / 2 + offset,
                    Y = toNodePosition.Y + 45 / 2
                };
            }
            grapics.DrawLine(
                linePen,
                _startPoint,
                CalculatePoint(_startPoint, _endPoint, GetDistance(_startPoint, _endPoint))
            );
        }
        public Point CalculatePoint(Point _startPoint, Point _endPoint, double distance)
        {
            double vector_X = _endPoint.X - _startPoint.X;
            double vector_Y = _endPoint.Y - _startPoint.Y;

            double factor = distance / Math.Sqrt(vector_X * vector_X + vector_Y * vector_Y);

            vector_X *= factor;
            vector_Y *= factor;

            return new Point((int)(_startPoint.X + vector_X), (int)(_startPoint.Y + vector_Y));
        }
        public double GetDistance(Point _startPoint, Point _endPoint)
        {
            return Math.Sqrt(Math.Pow(_endPoint.X - _startPoint.X, 2) + Math.Pow(_endPoint.Y - _startPoint.Y, 2));
        }
        public void DrawNode(NodeModel node, int offset, Graphics grapics)
        {
            grapics.FillEllipse(
                new SolidBrush(Color.White),
                node.Position.X + offset,
                node.Position.Y,
                45,
                45
                );
            Color _color=Color.Black;
            if (node.NodeColor == NodeColor.red) { _color = Color.Red; }
            grapics.DrawEllipse(
                new Pen(_color, 1),
                node.Position.X + offset,
                node.Position.Y,
                45,
                45
                );

            SizeF ValueFontSize = grapics.MeasureString(node.Value.ToString(), DefaultFont);

            grapics.DrawString(
                node.Value.ToString(),
                DefaultFont,
                new SolidBrush(Color.Black),
                node.Position.X + (45 / 2) - (ValueFontSize.Width / 2) + 1 + offset,
                node.Position.Y + (45 / 2) - (ValueFontSize.Height / 2) + 1
                );
        }

    }
}
