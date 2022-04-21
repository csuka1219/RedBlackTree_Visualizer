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
    public partial class MainForm : Form
    {
        private VisualizationBox RedBlackBox;
        public NodeManager _nodeManager = new NodeManager();
        private int Counter;
        private List<double> ValueList = new List<double>();
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.tabControl1.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Counter = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RedBlackBox = new VisualizationBox
            {
                Dock = DockStyle.Fill
            };

            Tbp_RedBlack.Controls.Add(RedBlackBox);
        }
        private void Btn_Insert_Click(object sender, EventArgs e)
        {
            if (Counter > 15)
            {
                MessageBox.Show("At this point the supported number of value is 16!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(Txt_Value.Text))
            {
                MessageBox.Show("You didn't add any number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(Txt_Value.Text, out int value))
            {
                MessageBox.Show("You can only add numbers to the tree!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _nodeManager.Record(Convert.ToDouble(Txt_Value.Text));
            RedBlackBox.Print();
            Counter++;
            Txt_Value.Text = "";
        }

        private void Txt_Insert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Counter > 15)
                {
                    MessageBox.Show("At this point the supported number of value is 16!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(Txt_Value.Text))
                {
                    MessageBox.Show("You didn't add any number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!double.TryParse(Txt_Value.Text, out double check))
                {
                    MessageBox.Show("You can only add numbers to the tree!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ValueList.Contains(Convert.ToDouble(Txt_Value.Text)))
                {
                    MessageBox.Show("The tree already contains this value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _nodeManager.Record(Convert.ToDouble(Txt_Value.Text));
                RedBlackBox.Print();
                Counter++;
                ValueList.Add(Convert.ToDouble(Txt_Value.Text));
                Txt_Value.Text = "";
            }

        }
        //TODO
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("This function is not available yet!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //return;
            if (string.IsNullOrEmpty(Txt_Value.Text))
            {
                MessageBox.Show("You didn't add any number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(Txt_Value.Text, out int check))
            {
                MessageBox.Show("You can only remove numbers from the tree!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _nodeManager.DeleteNode(Convert.ToDouble(Txt_Value.Text));
            RedBlackBox.Print();
            if (Counter > 0)
            {
                Counter--;
            }
        }
    }
}
