using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Solution
    {
        //public void Show()
        //{
        //   bool Visible = true;
        //}
        //public void PrintAugmentedMatrix(double[,] matrix)
        //{
        //    int rows = matrix.GetLength(0);
        //    int cols = matrix.GetLength(1);

        //    for (int i = 0; i < rows; i++)
        //    {
        //        for (int j = 0; j < cols; j++)
        //        {
        //            MessageBox.Show($"{matrix[i, j]:0.##}\t");
        //        }
        //        Console.WriteLine();
        //    }

        //    MessageBox.Show("\n------------------------------\n");  // Horizontal line for readability
        //}
        //// Function: Row Echelon Form إلى Augmented Matrixلتحويل الـ
        //public void RowEchelonForm(double[,] matrix)
        //{
        //    int rows = matrix.GetLength(0);
        //    int cols = matrix.GetLength(1);

        //    for (int i = 0; i < rows; i++) //2 times/ تشتغل بعدد الصفوف
        //    {
        //        if (matrix[i, i] != 1)
        //        {
        //            // فـ حالة ان في صف تاني أوله 1
        //            //Swaping
        //            bool swapped = false;
        //            for (int k = i + 1; k < rows; k++) // leadingعشان يعدي ع مكان الـ
        //            {
        //                if (matrix[k, i] == 1)
        //                {
        //                    // Swap rows
        //                    Console.WriteLine($"R{i + 1} <-> R{k + 1}");
        //                    for (int j = 0; j < cols; j++) // تشتغل بعدد الأعمدة /k= i+1 / عشان يعدي ع كل عدد ف الصف ويعدل ع مكانه
        //                    {
        //                        double temp = matrix[i, j];
        //                        matrix[i, j] = matrix[k, j];
        //                        matrix[k, j] = temp;
        //                    }
        //                    PrintAugmentedMatrix(matrix);
        //                    swapped = true;
        //                    break;
        //                }
        //            }
        //            // فـ حالة ان مفيش صف تاني أوله 1 
        //            // بنقسم ع العدد ع نفسه لتحويله إلى 1
        //            // ونفس الكلام ع الصف كله 
        //            if (!swapped && matrix[i, i] != 0)
        //            {
        //                double leadingEntry = matrix[i, i];

        //                Console.WriteLine($"R{i + 1} = (1/{leadingEntry})R{i + 1}");
        //                for (int j = i; j < cols; j++) // j = i
        //                {
        //                    matrix[i, j] /= leadingEntry; //i = 0/ leadingEntryعشان نقسم الصف كله ع الـ
        //                }
        //                PrintAugmentedMatrix(matrix);
        //            }
        //        }

        //        //---------------------------------------------------------------//

        //        // يساوي 0 leadingعشان نخلي كل اللي تحت الـ
        //        for (int k = i + 1; k < rows; k++)
        //        {
        //            double factor = matrix[k, i];
        //            if (factor != 0)
        //            {
        //                if (factor == -1)
        //                {
        //                    Console.WriteLine($"R{k + 1} = -R{k + 1}");
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"R{k + 1} = R{k + 1} - ({factor})R{i + 1}");
        //                }

        //                for (int j = i; j < cols; j++)
        //                {
        //                    matrix[k, j] -= factor * matrix[i, j];
        //                }
        //                PrintAugmentedMatrix(matrix);
        //            }
        //        }
        //    }
        //}


  
   
        private RichTextBox outputBox;

        public object Controls { get; private set; }

        public Solution()
        {
            //InitializeComponent();
            SetupUI();
        }

        

        private void SetupUI()
        {
            // إعداد واجهة المستخدم
            outputBox = new RichTextBox()
            {
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(500, 400),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };
            //object value = this.Controls.(outputBox);
        }

        public void RowEchelonForm(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, i] != 1)
                {
                    bool swapped = false;
                    for (int k = i + 1; k < rows; k++)
                    {
                        if (matrix[k, i] == 1)
                        {
                            outputBox.AppendText($"R{i + 1} <-> R{k + 1}\n");
                            for (int j = 0; j < cols; j++)
                            {
                                double temp = matrix[i, j];
                                matrix[i, j] = matrix[k, j];
                                matrix[k, j] = temp;
                            }
                            PrintAugmentedMatrix(matrix);
                            swapped = true;
                            break;
                        }
                    }

                    if (!swapped && matrix[i, i] != 0)
                    {
                        double leadingEntry = matrix[i, i];
                        outputBox.AppendText($"R{i + 1} = (1/{leadingEntry})R{i + 1}\n");
                        for (int j = i; j < cols; j++)
                        {
                            matrix[i, j] /= leadingEntry;
                        }
                        PrintAugmentedMatrix(matrix);
                    }
                }

                for (int k = i + 1; k < rows; k++)
                {
                    double factor = matrix[k, i];
                    if (factor != 0)
                    {
                        if (factor == -1)
                        {
                            outputBox.AppendText($"R{k + 1} = -R{k + 1}\n");
                        }
                        else
                        {
                            outputBox.AppendText($"R{k + 1} = R{k + 1} - ({factor})R{i + 1}\n");
                        }

                        for (int j = i; j < cols; j++)
                        {
                            matrix[k, j] -= factor * matrix[i, j];
                        }
                        PrintAugmentedMatrix(matrix);
                    }
                }
            }
        }

        private void PrintAugmentedMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            outputBox.AppendText("Matrix:\n");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    outputBox.AppendText(matrix[i, j].ToString("F2") + "\t");
                }
                outputBox.AppendText("\n");
            }
            outputBox.AppendText("\n");
        }
    }



}

