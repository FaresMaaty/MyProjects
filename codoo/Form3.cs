using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    //Row Echlon Form
    public partial class Form3 : Form
    {
        private int stepCounter = 1; // Step counter
        static double[,] matrix;
        private int currentYPosition = 10; // To determine the position for displaying steps and matrices
        private Panel stepsPanel; // Panel to display steps and matrices
        private bool stepsDisplayed = false; // Variable to check if steps are already displayed

        public Form3()
        {
            InitializeComponent();

            // Set up Panel to display steps
            stepsPanel = new Panel
            {
                AutoScroll = true,
                Location = new Point(15, 30), // Below the "Solve Matrix" button
                Size = new Size(1870, 930), // Suitable size
                BorderStyle = BorderStyle.FixedSingle // To add a clear border
            };
            this.Controls.Add(stepsPanel);
            // Set the starting position for steps to be below the button
            currentYPosition = button1.Location.Y + button1.Height + 10;
        }

        // Event triggered when the button to solve the matrix is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            if (stepsDisplayed)
            {
                MessageBox.Show("The steps have already been displayed!");
                return;
            }

            int rows = Form2.Matrix.GetLength(0);
            int columns = Form2.Matrix.GetLength(1);
            matrix = new double[rows, columns];

            // Read values from the matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (double.TryParse(Form2.textboxes[i, j].Text, out double value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid numbers.");
                        return;
                    }
                }
            }

            // Call to convert the matrix and display steps
            if (matrix != null && matrix.Length > 0)
            {
                matrix = ConvertToRowEchelonForm(matrix);
                DisplayMatrix(matrix);
                stepsDisplayed = true; // Mark steps as displayed
            }
        }

        // Function to convert the matrix to Row Echelon Form
        private double[,] ConvertToRowEchelonForm(double[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            for (int i = 0; i < rowCount; i++)
            {
                // Select the largest element in the column as the pivot
                int maxRow = i;
                for (int k = i + 1; k < rowCount; k++)
                {
                    if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[maxRow, i]))
                    {
                        maxRow = k;
                    }
                }

                // Swap rows if necessary
                if (maxRow != i)
                {
                    SwapRows(matrix, i, maxRow);
                    DisplayStep($"Step {stepCounter++}: (Pivot) R{i + 1} <-> R{maxRow + 1}");
                }

                // Ensure the pivot element is not zero
                double pivot = matrix[i, i];
                if (pivot != 0)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        matrix[i, j] /= pivot;
                    }
                    DisplayStep($"Step {stepCounter++}: Normalize row {i + 1} by dividing by {pivot}");
                }

                // Zero out elements below the pivot
                for (int k = i + 1; k < rowCount; k++)
                {
                    double factor = matrix[k, i];
                    for (int j = 0; j < colCount; j++)
                    {
                        matrix[k, j] -= factor * matrix[i, j];
                    }
                    DisplayStep($"Step {stepCounter++}: Zero out element under leading one at ({k + 1}, {i + 1}) using row {i + 1}");
                }

                // Display the matrix after modification
                DisplayMatrixStep(matrix);
            }

            return matrix;
        }

        // Function to swap rows
        private void SwapRows(double[,] matrix, int row1, int row2)
        {
            int colCount = matrix.GetLength(1);
            for (int i = 0; i < colCount; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        // Function to display steps
        private void DisplayStep(string stepDescription)
        {
            // Display the step in a Label inside the Panel
            Label stepLabel = new Label
            {
                Text = stepDescription,
                Location = new Point(10, currentYPosition),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };
            stepsPanel.Controls.Add(stepLabel);

            // Update the position for the next step
            currentYPosition += 40; // Increase the space between steps
        }

        // Function to display the matrix after each step
        private void DisplayMatrix(double[,] matrix)
        {
            // Update the position to display the matrix after steps
            currentYPosition += 20;

            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            // Add text boxes to display the matrix inside the Panel
            int offsetX = 10;
            int offsetY = currentYPosition;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TextBox textBox = new TextBox
                    {
                        Text = matrix[i, j].ToString("F2"),
                        Size = new Size(70, 30),
                        Location = new Point(j * 80 + offsetX, i * 40 + offsetY),
                        ReadOnly = true
                    };
                    stepsPanel.Controls.Add(textBox);
                }
            }

            // Update the position after displaying the matrix
            currentYPosition += rows * 40 + 20; // Leave space between matrices and the next explanation
        }

        // Function to display the matrix after step modifications
        private void DisplayMatrixStep(double[,] matrix)
        {
            DisplayMatrix(matrix); // Simply re-display the matrix after modification
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (columns != rows + 1)
            {
                MessageBox.Show("The matrix is not in augmented form. Unable to calculate results.");
                return;
            }

            // Extract final values using Back Substitution
            double[] results = SolveForResults(matrix);

            // Open Form4 and display results
            Form4 resultsForm = new Form4(results);
            resultsForm.Show();
        }

        // Function to solve the system using Back Substitution
        private double[] SolveForResults(double[,] matrix)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);
            double[] results = new double[rowCount];

            for (int i = rowCount - 1; i >= 0; i--)
            {
                results[i] = matrix[i, colCount - 1];
                for (int j = i + 1; j < rowCount; j++)
                {
                    results[i] -= matrix[i, j] * results[j];
                }
            }

            return results;
        }
    }
}
