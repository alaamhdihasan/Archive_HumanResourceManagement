using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class EmployeesAdministrations : DevExpress.XtraReports.UI.XtraReport
    {
        public EmployeesAdministrations()
        {
            InitializeComponent();
        }

        private void EmployeesAdministrations_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void BookTitileCell_TextChanged(object sender, EventArgs e)
        {
          if(BookTitileCell.Text=="عقوبة")
            {
                BookTitileCell.ForeColor = Color.Red;
                BookNoCell.ForeColor = Color.Red;
                BookDateCell.ForeColor = Color.Red;
                ReleaseByCell.ForeColor = Color.Red;
                NoticeCell.ForeColor = Color.Red;
            }
            else
            {
                BookTitileCell.ForeColor = Color.Black;
                BookNoCell.ForeColor = Color.Black;
                BookDateCell.ForeColor = Color.Black;
                ReleaseByCell.ForeColor = Color.Black;
                NoticeCell.ForeColor = Color.Black;
            }
        }
    }
}
