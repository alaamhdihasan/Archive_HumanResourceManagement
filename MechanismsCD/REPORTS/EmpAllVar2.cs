using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class EmpAllVar2 : DevExpress.XtraReports.UI.XtraReport
    {
        public EmpAllVar2()
        {
            InitializeComponent();
        }

        private void ChidName_TextChanged(object sender, EventArgs e)
        {
            if(EmpNameCell.Text=="مرضية")
            {
                EmpNameCell.BackColor = Color.IndianRed;
                EmpNameCell.ForeColor = Color.White;
            }
            else
            {
                EmpNameCell.BackColor = Color.Transparent;
                EmpNameCell.ForeColor = Color.Black;
            }
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
    }
}
