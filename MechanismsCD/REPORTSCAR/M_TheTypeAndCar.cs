using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_TheTypeAndCar : DevExpress.XtraReports.UI.XtraReport
    {
        public M_TheTypeAndCar()
        {
            InitializeComponent();
        }

        private void M_CarNoBetween_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {

        }

        private void xrTableCell13_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void xrLabel21_TextChanged(object sender, EventArgs e)
        {
            if(Cartypetxt.Text == "تنكر استرا" || Cartypetxt.Text == "تنكر مان" || Cartypetxt.Text == "ساحبة مان" || Cartypetxt.Text == "ساحبة استرا" || Cartypetxt.Text == "تنكر هونداي"
                         || Cartypetxt.Text == "ساحبة هونداي" || Cartypetxt.Text == "تنكر هينو")
            {
                TransCounttxt.Visible = true;
                WaterTypetxt.Visible = true;
                LbTotal.Visible = true;
                totaltxt.Visible = true;
                lbtrans.Visible = true;
                Lbwater.Visible = true;

            }
            else
            {
                lbtrans.Visible = false;
                Lbwater.Visible = false;
                TransCounttxt.Visible = false;
                WaterTypetxt.Visible = false;
                LbTotal.Visible = false;
                totaltxt.Visible = false;

            }
        }

        private void xrLabel20_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
