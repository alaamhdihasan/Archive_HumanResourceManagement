using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MechanismsCD.FRMS
{
    public partial class keyboard : DevExpress.XtraEditors.XtraForm
    {
        TextBox text;
        System.Windows.Forms.ComboBox cmb;
        public keyboard(TextBox text, System.Windows.Forms.ComboBox cmb)
        {
            InitializeComponent();
            this.text = text;
            this.cmb = cmb;
        }

        private void key(string txt)
        {
            if(cmb==null)
                text.Text += txt;
            if (text == null)
                cmb.Text += txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            key(button1.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            key(button12.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            key(button11.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            key(button10.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            key(button9.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            key(button8.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            key(button7.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            key(button6.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            key(button5.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            key(button4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            key(button3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            key(button2.Text);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            key(button24.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            key(button23.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            key(button22.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            key(button21.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            key(button20.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            key(button19.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            key(button18.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            key(button17.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            key(button16.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            key(button15.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            key(button14.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            key(button13.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            key(button25.Text);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            key(button34.Text);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            key(button33.Text);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            key(button32.Text);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            key(button31.Text);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            key(button30.Text);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            key(button29.Text);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            key(button28.Text);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            key(button27.Text);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            key(button26.Text);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            if(cmb==null)
                text.Text += " ";
            if (text == null)
                cmb.Text += " ";
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (cmb == null)
            {
                if (text.Text.Length > 0)
                    text.Text = text.Text.Substring(0, text.Text.Length - 1);
            }
            if (text == null)
            {
                if (cmb.Text.Length > 0)
                    cmb.Text = cmb.Text.Substring(0, cmb.Text.Length - 1);
            }
        }
    }
}