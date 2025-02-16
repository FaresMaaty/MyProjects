using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        int _checked = 0;


        private void rbGauss_CheckedChanged(object sender, EventArgs e)
        {
            _checked = 0;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _checked = 1;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _checked = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_checked == 0)
            {
                Form1 form1 = new Form1(0);
                this.Hide();
                form1.ShowDialog();
            }
            else if (_checked == 1)
            {
                Form1 form1 = new Form1(1);
                this.Hide();
                form1.ShowDialog();
            }
            else if(_checked == 2)
            {
                Form1 form1 = new Form1(2);
                this.Hide();
                form1.ShowDialog();
            }
        }
    }
}
