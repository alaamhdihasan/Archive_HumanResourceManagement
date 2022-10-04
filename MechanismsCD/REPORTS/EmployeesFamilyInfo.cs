using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class EmployeesFamilyInfo : DevExpress.XtraReports.UI.XtraReport
    {
        public EmployeesFamilyInfo()
        {
            InitializeComponent();
        }

        private void ChidName_TextChanged(object sender, EventArgs e)
        {

        }

        private void OldChild_TextChanged(object sender, EventArgs e)
        {

        }

        private void OldChild_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            

        }

        private void EmployeesChildren_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void WifeJobCell_TextChanged(object sender, EventArgs e)
        {
            if(WifeJobCell.Text=="موظفة")
            {
                WifeJobCell.BackColor = Color.IndianRed;
                WifeJobCell.ForeColor = Color.White;
            }
            else
            {
                WifeJobCell.BackColor = Color.Transparent;
                WifeJobCell.ForeColor = Color.Black;
            }
        }
    }
}
