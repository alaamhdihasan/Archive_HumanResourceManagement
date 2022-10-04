using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_CarType2 : DevExpress.XtraReports.UI.XtraReport
    {
        public M_CarType2()
        {
            InitializeComponent();
        }

        private void M_CarNoBetween_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {

        }

        private void xrTableCell13_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void typetxt_TextChanged(object sender, EventArgs e)
        {
            if (typetxt.Text == "ايفاد")
            {
                typetxt.BackColor = Color.Green;
                typetxt.ForeColor = Color.White;
            }
            else if (typetxt.Text == "بطال")
            {
                typetxt.BackColor = Color.IndianRed;
                typetxt.ForeColor = Color.White;
            }
            else
            {
                typetxt.BackColor = Color.Transparent;
                typetxt.ForeColor = Color.Black;
            }
        }
    }
}
