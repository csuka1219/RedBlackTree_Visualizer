
namespace Red_Black_Tree_Visualizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Tbp_RedBlack = new System.Windows.Forms.TabPage();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Btn_Insert = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.txt_Insert = new System.Windows.Forms.TextBox();
            this.Tbp_RedBlack.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbp_RedBlack
            // 
            this.Tbp_RedBlack.Controls.Add(this.printPreviewControl1);
            this.Tbp_RedBlack.Location = new System.Drawing.Point(4, 25);
            this.Tbp_RedBlack.Name = "Tbp_RedBlack";
            this.Tbp_RedBlack.Padding = new System.Windows.Forms.Padding(3);
            this.Tbp_RedBlack.Size = new System.Drawing.Size(1275, 577);
            this.Tbp_RedBlack.TabIndex = 0;
            this.Tbp_RedBlack.Text = "Red_Black_Tree";
            this.Tbp_RedBlack.UseVisualStyleBackColor = true;
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(828, 270);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(10, 8);
            this.printPreviewControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Tbp_RedBlack);
            this.tabControl1.Location = new System.Drawing.Point(2, 98);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1283, 606);
            this.tabControl1.TabIndex = 0;
            // 
            // Btn_Insert
            // 
            this.Btn_Insert.Location = new System.Drawing.Point(202, 37);
            this.Btn_Insert.Name = "Btn_Insert";
            this.Btn_Insert.Size = new System.Drawing.Size(126, 30);
            this.Btn_Insert.TabIndex = 2;
            this.Btn_Insert.Text = "Insert";
            this.Btn_Insert.UseVisualStyleBackColor = true;
            this.Btn_Insert.Click += new System.EventHandler(this.Btn_Insert_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(362, 37);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(126, 30);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // txt_Insert
            // 
            this.txt_Insert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Insert.Location = new System.Drawing.Point(12, 37);
            this.txt_Insert.Name = "txt_Insert";
            this.txt_Insert.Size = new System.Drawing.Size(160, 30);
            this.txt_Insert.TabIndex = 4;
            this.txt_Insert.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 703);
            this.Controls.Add(this.txt_Insert);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.Btn_Insert);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Tbp_RedBlack.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage Tbp_RedBlack;
        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button Btn_Insert;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TextBox txt_Insert;
    }
}

