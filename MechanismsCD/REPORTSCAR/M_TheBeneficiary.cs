using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_TheBeneficiary : DevExpress.XtraReports.UI.XtraReport
    {
        public M_TheBeneficiary()
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
            if(CarTypetxt.Text == "تنكر استرا" || CarTypetxt.Text == "تنكر مان" || CarTypetxt.Text == "ساحبة مان" || CarTypetxt.Text == "ساحبة استرا" || CarTypetxt.Text == "تنكر هونداي"
                         || CarTypetxt.Text == "ساحبة هونداي" || CarTypetxt.Text == "تنكر هينو")
            {
                CountsTrans.Visible = true;
                CountsTranstxt.Visible = true;
                WaterType.Visible = true;
                WaterTypetxt.Visible = true;
                CarTypetxt.BackColor = Color.Orange;
                CountsTranstxt.BackColor = Color.Orange;
                CountsTranstxt.ForeColor = Color.Black;
                WaterTypetxt.BackColor = Color.Orange;
                WaterTypetxt.ForeColor = Color.Black;

            }
            else
            {
                CountsTrans.Visible = false;
                CountsTranstxt.Visible = false;
                WaterType.Visible = false;
                WaterTypetxt.Visible = false;
                CarTypetxt.BackColor = Color.Transparent;
                CountsTranstxt.BackColor = Color.Transparent;
                CountsTranstxt.ForeColor = Color.Black;
                WaterTypetxt.BackColor = Color.Transparent;
                WaterTypetxt.ForeColor = Color.Black;

            }
        }
    }
}
