using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_DriverName : DevExpress.XtraReports.UI.XtraReport
    {
        public M_DriverName()
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

        private void CarTypetxt_TextChanged(object sender, EventArgs e)
        {
            if (CarTypetxt.Text == "تنكر استرا" || CarTypetxt.Text == "تنكر مان" || CarTypetxt.Text == "ساحبة مان" || CarTypetxt.Text == "ساحبة استرا" || CarTypetxt.Text == "تنكر هونداي"
                         || CarTypetxt.Text == "ساحبة هونداي" || CarTypetxt.Text == "تنكر هينو")
            {

                CarTypetxt.BackColor = Color.Orange;
                //CarTypetxt.ForeColor = Color.White;
                TransCounttxt.Visible = true;
                TransCounttxt.BackColor = Color.Orange;
                // TransCounttxt.ForeColor = Color.White;
                WaterTypetxt.Visible = true;
                WaterTypetxt.BackColor = Color.Orange;
              //  WaterTypetxt.ForeColor = Color.White;

            }
            else
            {
                CarTypetxt.BackColor = Color.Transparent;
                CarTypetxt.ForeColor = Color.Black;
                TransCounttxt.Visible = false;
                TransCounttxt.BackColor = Color.Transparent;
                TransCounttxt.ForeColor = Color.Black;
                WaterTypetxt.Visible = false;
                WaterTypetxt.BackColor = Color.Transparent;
                WaterTypetxt.ForeColor = Color.Black;

            }
        }
    }
}
