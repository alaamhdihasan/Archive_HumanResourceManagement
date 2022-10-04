using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTSCAR
{
    public partial class DivBook : DevExpress.XtraReports.UI.XtraReport
    {
        public DivBook()
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
