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
            this.WindowState = FormWindowState.Maximized;
            this.tabControl1.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
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
            if (string.IsNullOrEmpty(txt_Insert.Text))
            {
                MessageBox.Show("You didn't add any number", "Warning");
                return;
            }
            if (!int.TryParse(txt_Insert.Text, out int value))
            {
                MessageBox.Show("You can only add numbers to the tree", "Error");
                return;
            }
            _nodeManager.Record(Convert.ToDouble(txt_Insert.Text));
            RedBlackBox.Print();
            txt_Insert.Text = "";
        }

        private void txt_Insert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_Insert.Text))
                {
                    MessageBox.Show("You didn't add any number","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!int.TryParse(txt_Insert.Text, out int check))
                {
                    MessageBox.Show("You can only add numbers to the tree", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _nodeManager.Record(Convert.ToDouble(txt_Insert.Text));
                RedBlackBox.Print();
                txt_Insert.Text = "";
            }

        }
    }
}
