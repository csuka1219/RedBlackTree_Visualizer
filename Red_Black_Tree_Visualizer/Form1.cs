using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Red_Black_Tree_Visualizer
{
    public partial class Form1 : Form
    {
        private VisualizationBox RedBlackBox;
        public NodeManager _nodeManager = new NodeManager();

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RedBlackBox = new VisualizationBox
            {
                Dock = DockStyle.Fill
            };

            //_avlTree = new AVLTree<int>(new TreeConfiguration(circleDiameter: 45, arrowAnchorSize: 5));

            Tbp_RedBlack.Controls.Add(RedBlackBox);
        }
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            //NodeModel newNode = new NodeModel { Value = Convert.ToDouble(txt_Insert.Text), Is_Red = true, Level = 1,Index=1 };
            //NodeManager qwe = new NodeManager();
            //NodeManager.Record(Convert.ToDouble(txt_Insert.Text));
            _nodeManager.Record(Convert.ToDouble(txt_Insert.Text));
            var asd = _nodeManager.Get();
            RedBlackBox.Print();
        }
    }
}
