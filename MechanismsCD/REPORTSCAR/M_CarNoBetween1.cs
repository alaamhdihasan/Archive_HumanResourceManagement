using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class M_CarNoBetween1 : DevExpress.XtraReports.UI.XtraReport
    {
        public M_CarNoBetween1()
        {
            InitializeComponent();
        }

        private void M_CarNoBetween_DesignerLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e)
        {

        }

        private void xrTableCell13_TextChanged(object sender, EventArgs e)
        {
            if(xrTableCell13.Text=="ايفاد")
            {
                xrTableCell13.BackColor = Color.Green;
                xrTableCell13.ForeColor = Color.White;
            }
            else if(xrTableCell13.Text=="بطال")
            {
                xrTableCell13.BackColor = Color.IndianRed;
                xrTableCell13.ForeColor = Color.White;
            }
            else
            {
                xrTableCell13.BackColor = Color.Transparent;
                xrTableCell13.ForeColor = Color.Black;
            }

        }
    }
}
