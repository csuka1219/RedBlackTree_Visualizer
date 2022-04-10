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
            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.DoubleBuffer,
                true);
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
                DrawConnectionArrow(_node.Position, _node.NodeLeftChild.Position, _offset, pe.Graphics);
                GetNodeFromTree(_node.NodeLeftChild, _offset, pe);
            }
            if (_node.NodeRightChild!= _defaultNode)
            {
                DrawConnectionArrow(_node.Position, _node.NodeRightChild.Position, _offset, pe.Graphics);
                GetNodeFromTree(_node.NodeRightChild, _offset, pe);
            }
        }
        private void DrawConnectionArrow(Position fromNodePosition, Position toNodePosition, int offset, Graphics grapics)
        {
            Pen linePen = new Pen(Color.Black, 1);
            //{
            //    CustomEndCap = new CustomLineCap(null, capPath, LineCap.ArrowAnchor)
            //};
            var startPoint = new Point
            {
                X = fromNodePosition.X + 45 / 2 + offset,
                Y = fromNodePosition.Y + 45 / 2
            };
            var endPoint = new Point
            {
                X = toNodePosition.X + 45 / 2 + offset,
                Y = toNodePosition.Y + 45 / 2
            };
            grapics.DrawLine(
                linePen,
                startPoint,
                CalculatePoint(startPoint, endPoint, GetDistance(startPoint, endPoint))
            );
        }
        public Point CalculatePoint(Point a, Point b, double distance)
        {
            // a. calculate the vector from o to g:
            double vectorX = b.X - a.X;
            double vectorY = b.Y - a.Y;

            // b. calculate the proportion of hypotenuse
            double factor = distance / Math.Sqrt(vectorX * vectorX + vectorY * vectorY);

            // c. factor the lengths
            vectorX *= factor;
            vectorY *= factor;

            // d. calculate and Draw the new vector,
            return new Point((int)(a.X + vectorX), (int)(a.Y + vectorY));
        }
        public double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
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

            var stringSize = grapics.MeasureString(node.Value.ToString(), DefaultFont);

            grapics.DrawString(
                node.Value.ToString(),
                DefaultFont,
                new SolidBrush(Color.Black),
                node.Position.X + (45 / 2) - (stringSize.Width / 2) + 1 + offset,
                node.Position.Y + (45 / 2) - (stringSize.Height / 2) + 1
                );

            //if (node.IsAvlNode)
            //{
            //    grapics.DrawString(
            //        node.Height.ToString(),
            //        new Font(DefaultFont.FontFamily, 7f),
            //        PensAndStuff.TextBrush,
            //        node.IsLeftChild ? node.Position.X - 8f + offset : node.Position.X + _configuration.CircleDiameter + offset,
            //        node.Position.Y
            //        );
            //}
        }

    }
}
