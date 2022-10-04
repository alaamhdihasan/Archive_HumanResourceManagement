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
    public partial class User_Num : UserControl
    {
        TextBox txt;
        ComboBox cmbo;
        public User_Num()
        {
            InitializeComponent();
        }
        
        public void text(TextBox txt)
        {
            this.txt = txt;
            cmbo = null;
        }
        public void cmb(ComboBox cmbo)
        {
            this.cmbo = cmbo;
            txt = null;
        }
        private void circleButtons2_Click(object sender, EventArgs e)
        {
            if(txt!=null)
            txt.Text += "1";
            else
            cmbo.Text += "1";
        }

        private void circleButtons3_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "2";
            else
            cmbo.Text += "2";
        }

        private void circleButtons1_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "3";
            else
            cmbo.Text += "3";
        }

        private void circleButtons4_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "4";
            else
            cmbo.Text += "4";
        }

        private void circleButtons5_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "5";
            else
            cmbo.Text += "5";
        }

        private void circleButtons6_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "6";
            else
            cmbo.Text += "6";
        }

        private void circleButtons7_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "7";
            else
            cmbo.Text += "7";
        }

        private void circleButtons8_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "8";
            else
            cmbo.Text += "8";
        }

        private void circleButtons9_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "9";
            else
            cmbo.Text += "9";
        }

        private void circleButtons11_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += "0";
            else
            cmbo.Text += "0";
        }

        private void circleButtons10_Click(object sender, EventArgs e)
        {
            if (txt != null)
                txt.Text += ".";
        }

        private void circleButtons12_Click(object sender, EventArgs e)
        {
            if (txt != null && txt.Text.Length > 0)
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
            if (cmbo!=null && cmbo.Text.Length > 0)
                cmbo.Text = cmbo.Text.Substring(0, cmbo.Text.Length - 1);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
