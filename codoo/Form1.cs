using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string text;
        private Point location;
        public FlatStyle FlatStyle { get; private set; }

        private void MakePanelRounded(Panel panel)
        {
            // Set the size and corners of the rectangle
            int radius = 20; // Corner radius
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90); // Top-right corner
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90); // Bottom-left corner
            path.CloseAllFigures();

            // Apply the new shape
            panel.Region = new Region(path);
        }
        private int _checkedValue; // Field to store the passed integer value
        public Form1(int checkedValue)
        {
            _checkedValue = checkedValue; // Assign the parameter value to the field
            this.KeyPreview = true;       // Ensure the form receives key presses
            InitializeComponent();

            // Optionally, you can use _checkedValue in your initialization logic
            // Example: Display it in the form title or set default values
            this.Text = $"Form with Checked Value: {_checkedValue}";

            // Bind the Resize event
            this.Resize += Form1_Resize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterPanel(); // Center the panel when the form loads
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check arrow key presses
            if (e.KeyCode == Keys.Right)  // Right arrow key
            {
                // Move focus to the second TextBox
                textBox2.Focus();
            }
            else if (e.KeyCode == Keys.Left)  // Left arrow key
            {
                // Move focus to the first TextBox
                textBox1.Focus();
            }

            if (e.KeyCode == Keys.Enter)
            {
                // Check if the TextBox is not empty
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    // Trigger the button if the TextBox is filled
                    button1.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please enter text in the TextBox.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(textBox1.Text);
            int cols = Convert.ToInt32(textBox2.Text);
            if (_checkedValue == 0||_checkedValue==1)
            {
                cols += 1;
            }
            
            Form2 form2 = new Form2(rows, cols, _checkedValue);
            form2.Show();
            Form2.Matrix = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!int.TryParse(Form2.textboxes[i, j].Text, out int value))
                    {
                        Form2.Matrix[i, j] = value;
                    }
                    else
                    {
                        // Handle invalid input case
                        MessageBox.Show("Please enter a valid numeric value.");
                    }
                }
            }
            this.Hide();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPanel(); // Center the panel when resizing the form
        }

        private void CenterPanel()
        {
            // Calculate the width and height of the form
            int formWidth = this.ClientSize.Width;   // Form width without borders
            int formHeight = this.ClientSize.Height; // Form height without borders

            // Calculate the width and height of the panel
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            // Calculate the new location of the panel
            int newX = (formWidth - panelWidth) / 2;
            int newY = (formHeight - panelHeight) / 2;

            // Set the new location
            panel1.Location = new Point(newX, newY);
        }

        #region Check Enter Only Number and Define Minimum Number in TextBox = 2
        // KeyPress event to allow only numbers
        // Use TextChanged or Leave event to ensure the value is within the defined range
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox1.Text, out value))
            {
                // Ensure the value is within the required range
                if (value < 2)
                {
                    textBox1.Text = "2"; // Set the value to the minimum
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers and backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(textBox2.Text, out value))
            {
                // Ensure the value is within the required range
                if (value < 2)
                {
                    textBox2.Text = "2"; // Set the value to the minimum
                }
            }
        }
        #endregion

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


