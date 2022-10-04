using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class ConstractsBetweenTowDate : DevExpress.XtraReports.UI.XtraReport
    {
        public ConstractsBetweenTowDate()
        {
            InitializeComponent();
        }

        private void ConstractsBetweenTowDate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void TheTypeCell_TextChanged(object sender, EventArgs e)
        {
            if(TheTypeCell.Text=="اجور يومية")
            {
                TheTypeCell.BackColor = Color.Red;
            }
        }
    }
}
