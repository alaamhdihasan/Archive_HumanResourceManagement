using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class Purchases_Print : DevExpress.XtraReports.UI.XtraReport
    {
        public Purchases_Print()
        {
            InitializeComponent();
        }

        private void xrTableCell1_TextChanged(object sender, EventArgs e)
        {
            if (xrTableCell1.Text == null || xrTableCell1.Text == "")
            {
                xrTableCell1.Visible = false;
                xrLabel18.Visible = false;
            }
        }
    }
}
