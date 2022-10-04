using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class PrintDocumentTest : DevExpress.XtraReports.UI.XtraReport
    {
        public PrintDocumentTest()
        {
            InitializeComponent();
        }

        private void xrTableCell1_TextChanged(object sender, EventArgs e)
        {
            if(xrTableCell1.Text==null || xrTableCell1.Text == "")
            {
                xrTableCell1.Visible = false;
                xrLabel18.Visible = false;
            }
        }
    }
}
