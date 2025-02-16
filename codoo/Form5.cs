using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private int currentYPosition = 10; // Y position for displaying steps
        private Panel stepsPanel; // Panel for displaying steps
        private bool stepsDisplayed = false; // Prevent re-displaying steps

        public Form5()
        {
            InitializeComponent();

            // Set up panel to display steps
            stepsPanel = new Panel
            {
                AutoScroll = true,
                Location = new Point(15, 30),
                Size = new Size(1870, 930),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(stepsPanel);

            currentYPosition = button1.Location.Y + button1.Height + 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (stepsDisplayed)
            {
                MessageBox.Show("The steps have already been displayed!");
                return;
            }

           
            try
            {
                double[,] inverseMatrix = InverseMatrix(Form2.cofficientMatrix);
                DisplayStep("Final Inverse Matrix:");
                DisplayMatrixStep(inverseMatrix);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            stepsDisplayed = true; // Mark steps as displayed
        }

        public double[,] InverseMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] augmented = new double[n, 2 * n];

            // Step 1: Create the augmented matrix [A | I]
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    augmented[i, j] = matrix[i, j];
                    augmented[i, j + n] = (i == j) ? 1 : 0;
                }
            }

            DisplayStep("Initial Augmented Matrix [A | I]:");
            DisplayMatrixStep(augmented);

            // Step 2: Perform Gaussian Elimination
            for (int i = 0; i < n; i++)
            {
                // Ensure pivot is not zero
                if (Math.Abs(augmented[i, i]) < 1e-10)
                {
                    bool swapped = false;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (Math.Abs(augmented[k, i]) > 1e-10)
                        {
                            SwapRows(augmented, i, k);
                            DisplayStep($"Swapped row {i + 1} with row {k + 1}");
                            DisplayMatrixStep(augmented);
                            swapped = true;
                            break;
                        }
                    }

                    if (!swapped)
                        throw new Exception("Matrix is not invertible.");
                }

                // Normalize the pivot row
                double pivot = augmented[i, i];
                for (int j = 0; j < 2 * n; j++)
                {
                    augmented[i, j] /= pivot;
                }

                DisplayStep($"Normalized row {i + 1}");
                DisplayMatrixStep(augmented);

                // Eliminate all other elements in the current column
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = augmented[k, i];
                        for (int j = 0; j < 2 * n; j++)
                        {
                            augmented[k, j] -= factor * augmented[i, j];
                        }

                        DisplayStep($"Row {k + 1} -> Row {k + 1} - ({factor:F2}) * Row {i + 1}");
                        DisplayMatrixStep(augmented);
                    }
                }
            }

            // Step 3: Extract the inverse matrix from the augmented matrix
            double[,] inverse = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = augmented[i, j + n];
                }
            }

            return inverse;
        }

        private static void SwapRows(double[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }

        private void DisplayStep(string stepDescription)
        {
            Label stepLabel = new Label
            {
                Text = stepDescription,
                Location = new Point(10, currentYPosition),
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };
            stepsPanel.Controls.Add(stepLabel);
            currentYPosition += 40;
        }

        private void DisplayMatrixStep(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int offsetX = 10;
            int offsetY = currentYPosition;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
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

            currentYPosition += rows * 40 + 20;
        }
    }
}
