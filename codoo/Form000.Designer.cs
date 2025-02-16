namespace WinFormsApp1
{
    partial class Form000
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
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button1.ForeColor = Color.Yellow;
            button1.Location = new Point(12, 28);
            button1.Name = "button1";
            button1.Size = new Size(179, 64);
            button1.TabIndex = 3;
            button1.Text = "Solve Matrix";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            button2.ForeColor = Color.Yellow;
            button2.Location = new Point(1732, 900);
            button2.Name = "button2";
            button2.Size = new Size(155, 62);
            button2.TabIndex = 4;
            button2.Text = "Result";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // Form000
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1839, 788);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form000";
            Text = "Form000";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
    }
}