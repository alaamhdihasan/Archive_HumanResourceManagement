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
    public partial class FRMRPFUEL : DevExpress.XtraEditors.XtraForm
    {
        string RPNAME;
        public FRMRPFUEL(string RPNAME)
        {
            InitializeComponent();
            this.RPNAME = RPNAME;
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            Dgv.DataSource=null;
            if (bgwork.IsBusy) { label1.Visible = true; }
            else { bgwork.RunWorkerAsync(); label1.Visible = false; }
            if (prog.Visible == false) { prog.Visible = true; }
            if (lb1.Visible == false) { lb1.Visible = true; }
        }

        private void bgwork_DoWork(object sender, DoWorkEventArgs e)
        {
            string name = "";
            if (cmbRPType.InvokeRequired)
            {
                cmbRPType.Invoke(new MethodInvoker(delegate { name = cmbRPType.Text; }));
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
            if (RPNAME == "تقارير اخراج وقود")
            {
                switch (name)
                {
                    case "فواتير بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt = new DataTable();
                        Dt = rp.FUEL_BillExitBetweenTowDate(dt1, dt2, name1);
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
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons, cmbRPType, "اخراج");
                            });
                        }
                        break;
                    case "فواتير قسم بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp1 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt1 = new DataTable();


                        Dt1 = rp1.FUEL_BillEXitDeptBetweenTowDate(name1, name2, dt1, dt2);
                        DataTable Cons2 = Dt1.Copy();
                        Cons2.Clear();
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
                                Cons2.ImportRow(Dt1.Rows[i]);
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons2, cmbRPType, "اخراج");
                            });
                        }
                        break;
                    case "خلاصة صرفيات الاقسام بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp2 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt2 = new DataTable();
                        Dt2 = rp2.FUEL_BillEXitDeptsSummaryBetweenTowDate(name1, dt1, dt2);
                        DataTable Cons3 = Dt2.Copy();
                        Cons3.Clear();
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
                                Cons3.ImportRow(Dt2.Rows[i]);
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons3, cmbRPType, "اخراج");
                            });
                        }
                        break;
                    case "صرفيات عجلة بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp3 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt3 = new DataTable();
                        Dt3 = rp3.FUEL_BillEXitCarBetweenTowDate(name1, dt1, dt2);
                        DataTable Cons4 = Dt3.Copy();
                        Cons4.Clear();
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
                                Cons4.ImportRow(Dt3.Rows[i]);
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons4, cmbRPType, "اخراج");
                            });
                        }
                        break;
                    case "خلاصة عجلات بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp4 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt4 = new DataTable();
                        Dt4 = rp4.FUEL_BillEXitCarsSummaryBetweenTowDate(name1, dt1, dt2);
                        DataTable Cons5 = Dt4.Copy();
                        Cons5.Clear();
                        for (int i = 0; i < Dt4.Rows.Count; i++)
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
                                Cons5.ImportRow(Dt4.Rows[i]);
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons5, cmbRPType, "اخراج");
                            });
                        }
                        break;
                }
            }
            else if(RPNAME == "تقارير ادخال وقود")
            {
                switch (name)
                {
                    case "فواتير بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt = new DataTable();
                        Dt = rp.FUEL_BillEntrayBetweenTowDate(name1,dt1, dt2);
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
                                CLS_FRMS.CLS_RPFUEL dgv = new CLS_FRMS.CLS_RPFUEL();
                                dgv.Dgvdesign(Dgv, Cons, cmbRPType,"ادخال");
                            });
                        }
                        break;
                }   
                }
        
        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (RPNAME == "تقارير ادخال وقود")
            {
                switch (cmbRPType.Text)
                {
                    case "فواتير بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt = new DataTable();
                        Dt = rp.FUEL_BillEntrayBetweenTowDate(cb1.Text, dt1, dt2);
                        prog.Maximum = Dt.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                }
            }
            if (RPNAME == "تقارير اخراج وقود")
            {
                switch (cmbRPType.Text)
                {
                    case "فواتير بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt = new DataTable();
                        Dt = rp.FUEL_BillExitBetweenTowDate(dt1,dt2,cb1.Text);
                        prog.Maximum = Dt.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "فواتير قسم بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp1 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt1 = new DataTable();
                        Dt1 = rp1.FUEL_BillEXitDeptBetweenTowDate(cb1.Text, cb2.Text, dt1, dt2);
                        prog.Maximum = Dt1.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة صرفيات الاقسام بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp2 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt2 = new DataTable();
                        Dt2 = rp2.FUEL_BillEXitDeptsSummaryBetweenTowDate(cb1.Text, dt1, dt2);
                        prog.Maximum = Dt2.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "صرفيات عجلة بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp3 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt3 = new DataTable();
                        Dt3 = rp3.FUEL_BillEXitCarBetweenTowDate(cb1.Text, dt1, dt2);
                        prog.Maximum = Dt3.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                    case "خلاصة عجلات بين تاريخين":
                        CLS_FRMS.CLS_RPFUEL rp4 = new CLS_FRMS.CLS_RPFUEL();
                        DataTable Dt4 = new DataTable();
                        Dt4 = rp4.FUEL_BillEXitCarsSummaryBetweenTowDate(cb1.Text, dt1, dt2);
                        prog.Maximum = Dt4.Rows.Count;
                        prog.Value = e.ProgressPercentage;
                        if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                        break;
                }
            }
        }

        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cmbRPType.Text)
            {               
                case "فواتير قسم بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم القسم";                   
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCONSTENTRY Getdata = new CLS_FRMS.CLSCONSTENTRY();
                    DataTable dt = Getdata.GetDataDepartment();
                    for (int i = 0; i < dt.Rows.Count; i++) { cb1.Items.Add(dt.Rows[i][1].ToString()); }
                    cb2.Enabled = true;
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "اسم المخزن";                    
                    cb2.Items.Clear();
                    CLS_FRMS.CLS_FUEL Getdata1 = new CLS_FRMS.CLS_FUEL();
                    DataTable dt1 = Getdata1.SelectStores();
                    for (int i = 0; i < dt1.Rows.Count; i++) { cb2.Items.Add(dt1.Rows[i][1].ToString()); }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "فواتير بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "اسم المخزن";                   
                    cb1.Items.Clear();
                    CLS_FRMS.CLS_FUEL Getdata2 = new CLS_FRMS.CLS_FUEL();
                    DataTable dt2 = Getdata2.SelectStores();
                    for (int i = 0; i < dt2.Rows.Count; i++) { cb1.Items.Add(dt2.Rows[i][1].ToString()); }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "خلاصة صرفيات الاقسام بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "اسم المخزن";                   
                    cb1.Items.Clear();
                    CLS_FRMS.CLS_FUEL Getdata3 = new CLS_FRMS.CLS_FUEL();
                    DataTable dt3 = Getdata3.SelectStores();
                    for (int i = 0; i < dt3.Rows.Count; i++) { cb1.Items.Add(dt3.Rows[i][1].ToString()); }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "صرفيات عجلة بين تاريخين":
                    cb1.DataSource = null;
                    cb2.DataSource = null;                                      
                    cb1.Items.Clear();
                    cb2.BackColor = Color.Red; cb1.Text = "نوع العجلة";                    
                    cb2.Items.Clear();
                    CLS_FRMS.CLS_FUEL Getdata4 = new CLS_FRMS.CLS_FUEL();
                    Getdata4.caarInfo(cb1,cb2);
                    cb1.BackColor = Color.Red; cb1.Text = "رقم العجلة";
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "خلاصة عجلات بين تاريخين":
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "اسم المخزن";                    
                    cb1.Items.Clear();                  
                    CLS_FRMS.CLS_FUEL Getdata5 = new CLS_FRMS.CLS_FUEL();
                    DataTable dt5 = Getdata5.SelectStores();
                    for (int i = 0; i < dt5.Rows.Count; i++) { cb1.Items.Add(dt5.Rows[i][1].ToString()); }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
            }
        }

        private void FRMRPFUEL_Load(object sender, EventArgs e)
        {
            if(RPNAME=="تقارير اخراج وقود")
            {
                string[] s = { "فواتير بين تاريخين", "فواتير قسم بين تاريخين", "خلاصة صرفيات الاقسام بين تاريخين", "صرفيات عجلة بين تاريخين", "خلاصة عجلات بين تاريخين" };
                for(int i = 0 ; i < s.Length; i++)
                {
                    cmbRPType.Items.Add(s[i]);
                }
            }
            if (RPNAME == "تقارير ادخال وقود")
            {
                string[] s = { "فواتير بين تاريخين" };
                for (int i = 0; i < s.Length; i++)
                {
                    cmbRPType.Items.Add(s[i]);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
    }
}