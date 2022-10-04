using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class EmployeesChildren : DevExpress.XtraReports.UI.XtraReport
    {
        public EmployeesChildren()
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
            if(double.Parse(OldChild.Text)>=18)
            {
                OldChild.ForeColor = Color.White;
                OldChild.BackColor = Color.IndianRed;
            }
            else
            {
                OldChild.ForeColor = Color.Black;
                OldChild.BackColor = Color.Transparent;
            }



        }

        private void EmployeesChildren_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
