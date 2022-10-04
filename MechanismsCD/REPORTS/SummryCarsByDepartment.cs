using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace MechanismsCD.REPORTS
{
    public partial class SummryCarsByDepartment : DevExpress.XtraReports.UI.XtraReport
    {
        public SummryCarsByDepartment()
        {
            InitializeComponent();
        }
       
        private void xrLabel1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void xrLabel1_SummaryRowChanged(object sender, EventArgs e)
        {
          
        }
        string dept = "0";
        int count = 0;
        private void xrLabel2_TextChanged(object sender, EventArgs e)
        {
          if(dept!= xrLabel2.Text)
            {
                count++;
                dept = xrLabel2.Text;
                xrLabel1.Text = count.ToString();
            }
        }
    }
}
