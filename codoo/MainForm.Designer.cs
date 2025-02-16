namespace WinFormsApp1
{
    partial class MainForm
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
            radioButton2 = new RadioButton();
            button1 = new Button();
            rbGauss = new RadioButton();
            label1 = new Label();
            radioButton1 = new RadioButton();
            SuspendLayout();
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton2.Location = new Point(108, 260);
            radioButton2.Name = "radioButton2";
            radioButton2.RightToLeft = RightToLeft.No;
            radioButton2.Size = new Size(189, 35);
            radioButton2.TabIndex = 11;
            radioButton2.TabStop = true;
            radioButton2.Text = "Inverse Matrix";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Simplified Arabic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkOliveGreen;
            button1.Location = new Point(312, 333);
            button1.Name = "button1";
            button1.Size = new Size(168, 59);
            button1.TabIndex = 9;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // rbGauss
            // 
            rbGauss.AutoSize = true;
            rbGauss.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rbGauss.Location = new Point(108, 140);
            rbGauss.Name = "rbGauss";
            rbGauss.RightToLeft = RightToLeft.No;
            rbGauss.Size = new Size(260, 35);
            rbGauss.TabIndex = 7;
            rbGauss.TabStop = true;
            rbGauss.Text = "Gaussian Elimination";
            rbGauss.UseVisualStyleBackColor = true;
            rbGauss.CheckedChanged += rbGauss_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 19.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.SaddleBrown;
            label1.Location = new Point(72, 58);
            label1.Name = "label1";
            label1.Size = new Size(656, 45);
            label1.TabIndex = 6;
            label1.Text = "Choose the way you wanna to solve with";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButton1.Location = new Point(108, 202);
            radioButton1.Name = "radioButton1";
            radioButton1.RightToLeft = RightToLeft.No;
            radioButton1.Size = new Size(309, 35);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Gauss-Jordan Elimination";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(radioButton1);
            Controls.Add(radioButton2);
            Controls.Add(button1);
            Controls.Add(rbGauss);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton radioButton2;
        private Button button1;
        private RadioButton rbGauss;
        private Label label1;
        private RadioButton radioButton1;
    }
}