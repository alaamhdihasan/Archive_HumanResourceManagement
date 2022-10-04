using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MechanismsCD.FRMS
{
    public partial class FRMRPATTENDENCE : DevExpress.XtraEditors.XtraForm
    {
        public FRMRPATTENDENCE()
        {
            InitializeComponent();
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMRPATTENDENCE_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Properties.Settings.Default.UserNameLogin;
            string[] s = { "وجبة بين تاريخين" , "حسب اسم المنتسب" , "زمنيات حسب الوجبة بين تاريخين" , "حسب فئة العمل بين تاريخين" };
            for (int i = 0; i < s.Length; i++)
            {
                cmbRpType.Items.Add(s[i]);
            }
        }

        private void cmbRpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbRpType.Text)
            {
                case "وجبة بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الوجبة";
                    cb1.Items.Clear();
                    string[] s = { "الوجبة الصباحية", "الوجبة المسائية", "الوجبة الليلية" };
                    for (int i = 0; i < s.Length; i++)
                    {
                        cb1.Items.Add(s[i]);
                    }
                    cb2.Enabled = true;
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل اليوم";
                    cb2.Items.Clear();
                    string[] sday = { "السبت", "الاحد", "الاثنين", "الثلاثاء", "الاربعاء", "الخميس", "الجمعة" };
                    for (int i = 0; i < sday.Length; i++)
                    {
                        cb2.Items.Add(sday[i]);
                    }

                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب اسم المنتسب":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم المنتسب";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCONSTENTRY GetNames2 = new CLS_FRMS.CLSCONSTENTRY();
                    DataTable Dt2 = GetNames2.GetnameEmployees();
                    for (int i = 0; i < Dt2.Rows.Count; i++) { cb1.Items.Add(Dt2.Rows[i][0].ToString()); }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "زمنيات حسب الوجبة بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الوجبة";
                    cb1.Items.Clear();
                    string[] s1 = { "الوجبة الصباحية", "الوجبة المسائية", "الوجبة الليلية" };
                    for (int i = 0; i < s1.Length; i++)
                    {
                        cb1.Items.Add(s1[i]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                    
                case "حسب فئة العمل بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل قئة العمل";
                    cb1.Items.Clear();
                    string[] s2 = { "7", "14", "24" , "حر"};
                    for (int i = 0; i < s2.Length; i++)
                    {
                        cb1.Items.Add(s2[i]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
            }
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            Dgv.DataSource = null;
            if (bgwork.IsBusy) { label1.Visible = true; }
            else { bgwork.RunWorkerAsync(); label1.Visible = false; }
            if (prog.Visible == false) { prog.Visible = true; }
            if (lb1.Visible == false) { lb1.Visible = true; }
        }

        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            string name = "";
            if (cmbRpType.InvokeRequired)
            {
                cmbRpType.Invoke(new MethodInvoker(delegate { name = cmbRpType.Text; }));
            }
            string name1 = "";
            if (cb1.InvokeRequired)
            {
                cb1.Invoke(new MethodInvoker(delegate { name1 = cb1.Text; }));
            }
            string name2 = "";
            if (cb1.InvokeRequired)
            {
                cb2.Invoke(new MethodInvoker(delegate { name2 = cb2.Text; }));
            }
            string Datetime1 = "";
            if (dt1.InvokeRequired)
            {
                dt1.Invoke(new MethodInvoker(delegate { Datetime1 = dt1.Text; }));
            }
            string Datetime2 = "";
            if (dt2.InvokeRequired)
            {
                dt2.Invoke(new MethodInvoker(delegate { Datetime2 = dt2.Text; }));
            }
            switch (name)
                {
                    case "وجبة بين تاريخين":
                        CLS_FRMS.CLS_RPATTENDENCE rp = new CLS_FRMS.CLS_RPATTENDENCE();
                        DataTable Dt = new DataTable();
                        Dt = rp.SelectShiftByDate(name1,name2, Datetime1, Datetime2);
                        DataTable Cons = Dt.Copy();
                        Cons.Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            int sum = 0;
                            for (int j = 0; j < 1000; j++)
                            {
                                sum = sum + j;
                            }
                            lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                            bgwork.ReportProgress(i);
                            Dgv.Invoke((MethodInvoker)delegate
                            {
                                Cons.ImportRow(Dt.Rows[i]);
                                CLS_FRMS.CLS_RPATTENDENCE dgv = new CLS_FRMS.CLS_RPATTENDENCE();
                                dgv.Dgvdesign(Dgv, Cons, cmbRpType);
                            });
                        }
                        break;
                case "حسب اسم المنتسب":
                    CLS_FRMS.CLS_RPATTENDENCE rp1 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt1 = new DataTable();
                    Dt1 = rp1.SelectEmpByEmpNameAndDate(name1, Datetime1, Datetime2);
                    DataTable Cons1 = Dt1.Copy();
                    Cons1.Clear();
                    for (int i = 0; i < Dt1.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 1000; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons1.ImportRow(Dt1.Rows[i]);
                            CLS_FRMS.CLS_RPATTENDENCE dgv = new CLS_FRMS.CLS_RPATTENDENCE();
                            dgv.Dgvdesign(Dgv, Cons1, cmbRpType);
                        });
                    }
                    break;
                case "زمنيات حسب الوجبة بين تاريخين":
                    CLS_FRMS.CLS_RPATTENDENCE rp2 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt2 = new DataTable();
                    Dt2 = rp2.SelectEmpByDaleytAndDate(name1, Datetime1, Datetime2);
                    DataTable Cons2 = Dt2.Copy();
                    Cons2.Clear();
                    for (int i = 0; i < Dt2.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 1000; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons2.ImportRow(Dt2.Rows[i]);
                            CLS_FRMS.CLS_RPATTENDENCE dgv = new CLS_FRMS.CLS_RPATTENDENCE();
                            dgv.Dgvdesign(Dgv, Cons2, cmbRpType);
                        });
                    }
                    break;
                case "حسب فئة العمل بين تاريخين":
                    CLS_FRMS.CLS_RPATTENDENCE rp3 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt3 = new DataTable();
                    Dt3 = rp3.SelectEmpByWorkTypeAndDate(name1, Datetime1, Datetime2);
                    DataTable Cons3 = Dt3.Copy();
                    Cons3.Clear();
                    for (int i = 0; i < Dt3.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 1000; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons3.ImportRow(Dt3.Rows[i]);
                            CLS_FRMS.CLS_RPATTENDENCE dgv = new CLS_FRMS.CLS_RPATTENDENCE();
                            dgv.Dgvdesign(Dgv, Cons3, cmbRpType);
                        });
                    }
                    break;
                }
            
        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (cmbRpType.Text)
            {
                case "وجبة بين تاريخين":
                    CLS_FRMS.CLS_RPATTENDENCE rp = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt = new DataTable();
                    Dt = rp.SelectShiftByDate(cb1.Text,cb2.Text, dt1.Text, dt2.Text);
                    prog.Maximum = Dt.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب اسم المنتسب":
                    CLS_FRMS.CLS_RPATTENDENCE rp1 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt1 = new DataTable();
                    Dt1 = rp1.SelectEmpByEmpNameAndDate(cb1.Text, dt1.Text, dt2.Text);
                    prog.Maximum = Dt1.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "زمنيات حسب الوجبة بين تاريخين":
                    CLS_FRMS.CLS_RPATTENDENCE rp2 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt2 = new DataTable();
                    Dt2 = rp2.SelectEmpByDaleytAndDate(cb1.Text, dt1.Text, dt2.Text);
                    prog.Maximum = Dt2.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب فئة العمل بين تاريخين":
                    CLS_FRMS.CLS_RPATTENDENCE rp3 = new CLS_FRMS.CLS_RPATTENDENCE();
                    DataTable Dt3 = new DataTable();
                    Dt3 = rp3.SelectEmpByWorkTypeAndDate(cb1.Text, dt1.Text, dt2.Text);
                    prog.Maximum = Dt3.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLS_RPATTENDENCE rp = new CLS_FRMS.CLS_RPATTENDENCE();
            DataTable Dt = new DataTable();
            DS.DataSetMechanisms dss = new DS.DataSetMechanisms();
            REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                      
            switch (cmbRpType.Text)
            {
                case "وجبة بين تاريخين":
                    REPORTS.Attendence rpt = new REPORTS.Attendence();
                    Dt = rp.SelectShiftByDate(cb1.Text,cb2.Text, dt1.Text, dt2.Text);
                    dss.Tables["EmpAttenBySheft"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["EmpAttenBySheft"].Rows.Add(i+1,Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7]);
                    }
                   
                    rpt.Parameters["RpType"].Value = "تقرير الحضور والانصراف حسب " + cmbRpType.Text + "\r\nالوجبة: " + cb1.Text + "\r\nاليوم: " + cb2.Text + "\r\nالتاريخ الاول: " + dt1.Text + " \r\nالتاريخ الثاني: " + dt2.Text ;
                    rpt.Parameters["EmpCount"].Value = Dt.Rows.Count;
                    rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt.DataSource = dss;
                    rpt.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt;
                    break;
                case "حسب اسم المنتسب":                                     
                    Dt = rp.SelectEmpByEmpNameAndDate(cb1.Text, dt1.Text, dt2.Text);
                    REPORTS.AttenByEmpName rpt1 = new REPORTS.AttenByEmpName();
                    dss.Tables["EmpAttenByEmpName"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["EmpAttenByEmpName"].Rows.Add(i + 1, Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7]);
                    }
                    
                    rpt1.Parameters["RpType"].Value = "تقرير الحضور والانصراف " + cmbRpType.Text + "\r\nالاسم: " + cb1.Text + "\r\nالتاريخ الاول: " + dt1.Text + "\r\nالتاريخ الثاني: " + dt2.Text;
                    
                    rpt1.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt1.DataSource = dss;
                    rpt1.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt1;
                    break;
                case "زمنيات حسب الوجبة بين تاريخين":
                    Dt = rp.SelectEmpByDaleytAndDate(cb1.Text, dt1.Text, dt2.Text);
                    REPORTS.AttenByDaley rpt2 = new REPORTS.AttenByDaley();
                    dss.Tables["EmpAttenByDaley"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["EmpAttenByDaley"].Rows.Add(i + 1, Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11]);
                    }
                   
                    rpt2.Parameters["RpType"].Value = "تقرير الحضور والانصراف " + cmbRpType.Text + "\r\nالوجبة: " + cb1.Text + "\r\nالتاريخ الاول: " + dt1.Text + "\r\nالتاريخ الثاني: " + dt2.Text;
                    
                    rpt2.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt2.DataSource = dss;
                    rpt2.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt2;
                    break;
                case "حسب فئة العمل بين تاريخين":                    
                    Dt = rp.SelectEmpByWorkTypeAndDate(cb1.Text, dt1.Text, dt2.Text);
                    REPORTS.AttenByWorkType rpt3 = new REPORTS.AttenByWorkType();
                    dss.Tables["EmpAttenByWorkType"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["EmpAttenByWorkType"].Rows.Add(i + 1, Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8]);
                    }
                  
                    rpt3.Parameters["RpType"].Value = "تقرير الحضور والانصراف " + cmbRpType.Text + "\r\nفئة العامل: " + cb1.Text + "\r\nالتاريخ الاول: " + dt1.Text + "\r\nالتاريخ الثاني: " + dt2.Text;
                    
                    rpt3.Parameters["EmpCount"].Value = Dt.Rows.Count;
                    rpt3.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt3.DataSource = dss;
                    rpt3.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt3;
                    break;
            }


            
            frm.ShowDialog();
        }
    }
}