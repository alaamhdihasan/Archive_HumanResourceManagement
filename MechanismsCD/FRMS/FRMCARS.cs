using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.FRMS
{
    public partial class FRMCARS : Form
    {
        public FRMCARS()
        {
            InitializeComponent();


        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void circleButtons9_MouseHover(object sender, EventArgs e)
        {
            circleButtons9.BackColor = Color.Green;
            circleButtons9.ForeColor = Color.Black;

        }

        private void circleButtons9_MouseLeave(object sender, EventArgs e)
        {
            circleButtons9.BackColor = Color.Black;
            circleButtons9.ForeColor = Color.White;
        }

        private void circleButtons10_MouseHover(object sender, EventArgs e)
        {
            circleButtons10.BackColor = Color.Red;
            circleButtons10.ForeColor = Color.Black;
        }

        private void circleButtons10_MouseLeave(object sender, EventArgs e)
        {
            circleButtons10.BackColor = Color.Black;
            circleButtons10.ForeColor = Color.White;
        }

        private void circleButtons4_Click(object sender, EventArgs e)
        {
            tbsearching.Focus();

        }
    }
}
