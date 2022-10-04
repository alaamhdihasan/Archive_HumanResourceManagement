using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.User_Control
{
    public partial class NumClick : UserControl
    {

        TextBox Result;
        public NumClick()
        {
            
            InitializeComponent();
        }
        public void txt(TextBox result)
        {
            this.Result = result;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            
           Result.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {

           Result.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Result.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Result.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
           Result.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
           Result.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Result.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Result.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Result.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Result.Text += "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (Result.Text.Length > 0)
               Result.Text = Result.Text.Substring(0,Result.Text.Length-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void pnlNum_Paint(object sender, PaintEventArgs e)
        {

        }

        private void circleButtons1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void circleButtons2_Click(object sender, EventArgs e)
        {
            if (Result.Text.Length > 0)
                Result.Text = Result.Text.Substring(0, Result.Text.Length - 1);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btncommingbarcodesys_Click(object sender, EventArgs e)
        {
            if (Result.Text.Length > 0)
                Result.Text = Result.Text.Substring(0, Result.Text.Length - 1);
        }
    }
}
