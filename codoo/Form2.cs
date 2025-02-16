using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private const string Text = "";
        public static int rows;
        public static int columns;
        int counter = 0;
        public static double[,] Matrix; // Augmented matrix
        public static double[,] cofficientMatrix;
        public static System.Windows.Forms.TextBox[,] textboxes;
        private object textBox;

        // Define the size of the TextBoxes as per your requirement
        int textBoxWidth = 70;  // TextBox width
        int textBoxHeight = 30; // TextBox height (greater than width)
        int horizontalSpacing = 10; // Horizontal spacing between TextBoxes
        int verticalSpacing = 10;   // Vertical spacing between TextBoxes
        private int _checkedValue; // Field to store the passed integer value
        public Form2(int r, int c, int checkedValue)
        {
            _checkedValue = checkedValue;
            rows = r;
            columns = c;
            InitializeComponent();

            // Call the function after initialization to avoid control errors
            TextBox_Matrix();

            // Bind Resize event
            this.Resize += Form2_Resize;
            // Bind FormClosing event to Form2_FormClosing
            this.FormClosing += new FormClosingEventHandler(this.Form2_FormClosing);
        }

        private void TextBox_Matrix()
        {
            if (panel1 == null)
            {
                MessageBox.Show("Panel is not initialized.");
                return;
            }

            // Textbox array
            textboxes = new System.Windows.Forms.TextBox[rows, columns];

            // Create TextBoxes
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox
                    {
                        Size = new Size(textBoxWidth, textBoxHeight),  // Set TextBox size
                        TabIndex = i * columns + j  // Set navigation order between TextBoxes
                    };

                    // Bind KeyDown event to each TextBox
                    textBox.KeyDown += TextBox_KeyDown;

                    panel1.Controls.Add(textBox);  // Add TextBox to the Panel
                    textboxes[i, j] = textBox;
                }
            }

            RepositionTextBoxes(); // Arrange TextBoxes initially
        }

        // Function to reposition TextBoxes within the Panel
        private void RepositionTextBoxes()
        {
            if (textboxes == null || panel1 == null) return;

            int panelWidth = panel1.ClientSize.Width;
            int panelHeight = panel1.ClientSize.Height;

            // Calculate the matrix width and height
            int matrixWidth = columns * textBoxWidth + (columns - 1) * horizontalSpacing;
            int matrixHeight = rows * textBoxHeight + (rows - 1) * verticalSpacing;

            // Calculate the position to center the matrix within the Panel
            int startX = Math.Max((panelWidth - matrixWidth) / 2, 0) - 5;
            int startY = Math.Max((panelHeight - matrixHeight) / 2, 0) - 60;

            // Set the TextBox positions based on calculations
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    System.Windows.Forms.TextBox textBox = textboxes[i, j];
                    if (textBox != null)
                    {
                        textBox.Location = new Point(
                            startX + j * (textBoxWidth + horizontalSpacing),
                            startY + i * (textBoxHeight + verticalSpacing)
                        );
                    }
                }
            }
        }

        // Bind the KeyDown event to enable navigation between TextBoxes using arrow keys
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox currentTextBox = sender as System.Windows.Forms.TextBox;
            if (currentTextBox == null) return;

            int currentIndex = currentTextBox.TabIndex;

            // Handle navigation based on arrow keys
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveFocus(currentIndex - columns); // Move up
                    break;
                case Keys.Down:
                    MoveFocus(currentIndex + columns); // Move down
                    break;
                case Keys.Left:
                    MoveFocus(currentIndex - 1); // Move left
                    break;
                case Keys.Right:
                    MoveFocus(currentIndex + 1); // Move right
                    break;
            }
            if (e.KeyCode == Keys.Enter)
            {
                // Check if TextBox is not empty
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    // Trigger button if TextBox is filled
                    button1.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please enter text in the TextBox.");
                }
            }
            e.Handled = true; // Prevent default behavior
        }

        // Function to change focus to the appropriate TextBox
        private void MoveFocus(int newIndex)
        {
            if (newIndex >= 0 && newIndex < textboxes.Length)
            {
                foreach (System.Windows.Forms.TextBox tb in textboxes)
                {
                    if (tb.TabIndex == newIndex)
                    {
                        tb.Focus();  // Change focus to the TextBox
                        break;
                    }
                }
            }
        }

        // Reposition TextBoxes when the form is resized
        private void Form2_Resize(object sender, EventArgs e)
        {
            RepositionTextBoxes();  // Rearrange TextBoxes when resizing the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (double.TryParse(textboxes[i, j].Text, out double value))
                    {
                        Matrix[i, j] = value;
                    }
                    else
                    {
                        // Handle invalid input
                        MessageBox.Show("Please enter a valid number in TextBox " + (i + 1));
                    }
                }
            }
            if (_checkedValue == 0)
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
                form3.Hide();
            }
            else if (_checkedValue == 1)
            {
                Form000 gaussJordan=new Form000();
                gaussJordan.ShowDialog();
                gaussJordan.Hide();
            }
            else if (_checkedValue == 2)
            {
                int rowCofficient = Form2.Matrix.GetLength(0);
                int colCofficient = Form2.Matrix.GetLength(1) ;
                cofficientMatrix = new double[rowCofficient, colCofficient];

                // هنشوف هنا عدد الصفوف بيساوي عدد الاعمده ولا لا

                if (rowCofficient != colCofficient)
                {
                    MessageBox.Show("Matrix not square therefore not invertable.");
                    return; // لو طلعت مش مربعه هنوقف البرنامج خلاص
                }
                for (int i = 0; i < rowCofficient; i++)
                {
                    for (int j = 0; j < colCofficient; j++)
                    {
                        if (double.TryParse(Form2.textboxes[i, j].Text, out double value))
                        {
                            cofficientMatrix[i, j] = Form2.Matrix[i, j];
                        }
                        else
                        {
                            // Handle invalid input
                            MessageBox.Show("Please enter a valid number in TextBox " + (i + 1));
                        }
                    }
                }
                Form5 form5 = new Form5();
                form5.ShowDialog();
                form5.Hide();

            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // This code executes when the user tries to close the form
            e.Cancel = true;  // Prevent the form from closing

            // Display a confirmation message for closing
            var result = MessageBox.Show("Are you sure you want to close this window?", "Close Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;  // Allow the form to close
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.BringToFront();
            this.KeyPreview = true;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)sender;

            // Find the index of the TextBox in the textBoxes array
            int index = Array.IndexOf(textboxes, textBox);

            // Calculate row and column from the index
            int row = index / 3;
            int col = index % 3;

            if (int.TryParse(textBox.Text, out int value))
            {
                Matrix[row, col] = value;
            }
        }

        // Function to move to the next TextBox when Enter is pressed
        private void MoveToNextTextBox(System.Windows.Forms.TextBox currentTextBox)
        {
            int row = GetRowIndex(currentTextBox); // Get current row
            int col = GetColumnIndex(currentTextBox); // Get current column

            // Navigate to the next TextBox when Enter is pressed
            if (col + 1 < columns)
            {
                textboxes[row, col + 1].Focus();
            }
            else if (row + 1 < rows)
            {
                textboxes[row + 1, 0].Focus();
            }
        }

        // Function to get the row index of a TextBox
        private int GetRowIndex(System.Windows.Forms.TextBox textBox)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (textboxes[i, j] == textBox)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        // Function to get the column index of a TextBox
        private int GetColumnIndex(System.Windows.Forms.TextBox textBox)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (textboxes[i, j] == textBox)
                    {
                        return j;
                    }
                }
            }
            return -1;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    button2.PerformClick();
                }
                else
                {
                    MessageBox.Show("Please enter text in the TextBox.");
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            CenterPanel(); // Center the Panel when resizing the window
        }

        private void CenterPanel()
        {
            int formWidth = this.ClientSize.Width;   // Form width without borders
            int formHeight = this.ClientSize.Height; // Form height without borders

            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            int newX = (formWidth - panelWidth) / 2;
            int newY = (formHeight - panelHeight) / 2;

            panel1.Location = new Point(newX, newY);
        }
    }
}
