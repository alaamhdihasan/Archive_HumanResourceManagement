using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class SummaryType : DevExpress.XtraReports.UI.XtraReport
    {
        public SummaryType()
        {
            InitializeComponent();
        }

        private void DivisionCount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }
    }
}
