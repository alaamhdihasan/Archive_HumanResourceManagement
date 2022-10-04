using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_TheTypeAndDriverName : DevExpress.XtraReports.UI.XtraReport
    {
        public M_TheTypeAndDriverName()
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
           
        }

        private void CarTypetxt_TextChanged(object sender, EventArgs e)
        {
            if (CarTypetxt.Text == "تنكر استرا" || CarTypetxt.Text == "تنكر مان" || CarTypetxt.Text == "ساحبة مان" || CarTypetxt.Text == "ساحبة استرا" || CarTypetxt.Text == "تنكر هونداي"
                         || CarTypetxt.Text == "ساحبة هونداي" || CarTypetxt.Text == "تنكر هينو")
            {
               
                CountsTranstxt.Visible = true;
               WaterTypetxt.Visible = true;
                CountsTranstxt.BackColor = Color.Orange;
                CountsTranstxt.ForeColor = Color.Black;
                WaterTypetxt.BackColor = Color.Orange;
                WaterTypetxt.ForeColor = Color.Black;
                CarTypetxt.BackColor = Color.Orange;

            }
            else
            {
                CarTypetxt.BackColor = Color.Transparent;
               
                CountsTranstxt.Visible = false;
              
                WaterTypetxt.Visible = false;
                CountsTranstxt.BackColor = Color.Transparent;
                CountsTranstxt.ForeColor = Color.Black;
                WaterTypetxt.BackColor = Color.Transparent;
                WaterTypetxt.ForeColor = Color.Black;

            }
        }

        private void TheTypetxt_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
