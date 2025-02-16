using System.ComponentModel;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Olive;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.ForeColor = Color.Bisque;
            button1.Location = new Point(291, 440);
            button1.Name = "button1";
            button1.Padding = new Padding(10);
            button1.Size = new Size(105, 64);
            button1.TabIndex = 3;
            button1.Text = "Next";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.Location = new Point(325, 267);
            label1.MaximumSize = new Size(60, 100);
            label1.Name = "label1";
            label1.Size = new Size(39, 41);
            label1.TabIndex = 10;
            label1.Text = "×";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            textBox2.Location = new Point(385, 267);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "colums";
            textBox2.Size = new Size(58, 47);
            textBox2.TabIndex = 9;
            textBox2.KeyPress += textBox2_KeyPress;
            textBox2.Leave += textBox2_Leave;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            textBox1.Location = new Point(239, 267);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "rows";
            textBox1.Size = new Size(60, 47);
            textBox1.TabIndex = 5;
            textBox1.KeyPress += textBox1_KeyPress;
            textBox1.Leave += textBox1_Leave;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.Orange;
            textBox3.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            textBox3.Location = new Point(-26, 0);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(727, 62);
            textBox3.TabIndex = 11;
            textBox3.Text = "Solving By Gaussian Elimination";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.Orange;
            textBox4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            textBox4.Location = new Point(135, 132);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(418, 52);
            textBox4.TabIndex = 12;
            textBox4.Text = "Enter Size of Matrix";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Teal;
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(576, 59);
            panel1.Margin = new Padding(50);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(660, 724);
            panel1.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1838, 842);
            Controls.Add(panel1);
            ForeColor = Color.White;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            KeyDown += Form1_KeyDown;
            Resize += Form1_Resize;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox textBox4;
        private TextBox textBox3;

        public Form1(IContainer components, Button button1, TextBox textBox1, TextBox textBox2, Label label1, GroupBox groupBox2, TextBox textBox4, TextBox textBox3, BindingSource bindingSource1)
        {
            this.components = components;
            this.button1 = button1;
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
            this.label1 = label1;
            this.groupBox2 = groupBox2;
            this.textBox4 = textBox4;
            this.textBox3 = textBox3;
        }
        private Panel panel1;
    }
}
