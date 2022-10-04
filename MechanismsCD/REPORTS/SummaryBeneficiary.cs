using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class SummaryBeneficiary : DevExpress.XtraReports.UI.XtraReport
    {
        public SummaryBeneficiary()
        {
            InitializeComponent();
        }

        private void DivisionCount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }
    }
}
