using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4(double[] results)
        {
            InitializeComponent();

            // Form settings
            this.Text = "Final Results";
            this.Size = new Size(400, 300);

            Label titleLabel = new Label
            {
                Text = "Final Variable Values",
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            // Display final results
            for (int i = 0; i < results.Length; i++)
            {
                Label resultLabel = new Label
                {
                    Text = $"X{i + 1} = {results[i]:F2}",
                    Font = new Font("Arial", 12, FontStyle.Regular),
                    Location = new Point(10, 50 + i * 30),
                    AutoSize = true
                };
                this.Controls.Add(resultLabel);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Additional setup on form load if needed
        }
    }
}
