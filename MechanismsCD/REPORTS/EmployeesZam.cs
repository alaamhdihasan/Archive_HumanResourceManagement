﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

using System.Drawing.Drawing2D;

namespace MechanismsCD.REPORTS
{
    public partial class EmployeesZam : DevExpress.XtraReports.UI.XtraReport
    {
        public EmployeesZam()
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

        private void Sex_TextChanged(object sender, EventArgs e)
        {
            
            //if(int.Parse(ZamCount.Text) >= 4)
            //{
            //    ZamCount.BackColor = Color.IndianRed;
            //    ZamCount.ForeColor = Color.White;
            // }
            //else
            //{
            //    ZamCount.BackColor = Color.White;
            //    ZamCount.ForeColor = Color.Black;
            //}
        }
    }
}
