using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class RPDisputches : DevExpress.XtraReports.UI.XtraReport
    {
        public RPDisputches()
        {
            InitializeComponent();
        }

        private void xrTable3_Draw(object sender, DrawEventArgs e)
        {
            
        }

        private void xrNotice_Draw(object sender, DrawEventArgs e)
        {
            
        }

        private void xrNotice_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void xrNotice_TextChanged(object sender, EventArgs e)
        {
            if (xrNotice.Text == null || xrNotice.Text == "")
            {
                xrTableRow3.Borders = 0; ;
            }
        }

        private void RPDisputches_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void xrTable3_AfterPrint(object sender, EventArgs e)
        {
           
        }
    }
}
