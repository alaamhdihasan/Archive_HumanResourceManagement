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
    public partial class FRMRPCAR : DevExpress.XtraEditors.XtraForm
    {
        public FRMRPCAR()
        {
            InitializeComponent();
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMRPCAR_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Properties.Settings.Default.UserNameLogin;
            string[] s = { "حسب نوع العجلة", "حسب الشركة المصنعة", "حسب الحالة", "حسب عائدية العجلة", "حسب نوع الوقود", "حسب الموديل", "حسب قياس الاطار", "حسب نوع العجلة والموديل", "حسب الشركة المصنعة و الموديل", "حسب الحالة والموديل", "حسب نوع العجلة والعائدية", "حسب الحالة والعائدية" , "حسب القسم والشعبة" , "خلاصة حسب نوع العجلة", "خلاصة حسب الشعبة ", "خلاصة حسب العائدية" };
            for (int i = 0; i < s.Length; i++)
            {
                cbRPType.Items.Add(s[i]);
            }
        }

        private void cbRPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbRPType.Text)
            {
                case "حسب نوع العجلة":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل نوع العجلة";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carType = new CLS_FRMS.CLSCARS();
                    DataTable DtCar = carType.CarDivisionGetDate();
                    for (int i = 0; i < DtCar.Rows.Count; i++)
                    {
                        
                        int j = 0;
                        while (j < cb1.Items.Count && DtCar.Rows[i][2].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCar.Rows[i][2] != null && DtCar.Rows[i][2].ToString() != "")
                            cb1.Items.Add(DtCar.Rows[i][2]);
                        
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب الشركة المصنعة":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل اسم الشركة";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carCo = new CLS_FRMS.CLSCARS();
                    DataTable DtCarCo = carCo.CarDivisionGetDate();
                    for (int i = 0; i < DtCarCo.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtCarCo.Rows[i][3].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCarCo.Rows[i][3] != null && DtCarCo.Rows[i][3].ToString() != "")
                            cb1.Items.Add(DtCarCo.Rows[i][3]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب الحالة":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الحالة";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carState = new CLS_FRMS.CLSCARS();
                    DataTable DtCarState = carState.CarDivisionGetDate();
                    for (int i = 0; i < DtCarState.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtCarState.Rows[i][8].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCarState.Rows[i][8] != null && DtCarState.Rows[i][8].ToString() != "")
                            cb1.Items.Add(DtCarState.Rows[i][8]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;

                case "حسب عائدية العجلة":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل القسم";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carDep = new CLS_FRMS.CLSCARS();
                    DataTable DtCarDep = carDep.CarDivisionGetDate();
                    for (int i = 0; i < DtCarDep.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtCarDep.Rows[i][7].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCarDep.Rows[i][7] != null && DtCarDep.Rows[i][7].ToString() != "")
                            cb1.Items.Add(DtCarDep.Rows[i][7]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب نوع الوقود":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل نوع الوقود";
                    cb1.Items.Clear();
                    string[] s2 = { "بنزين", "كاز", "ديزل", "زيت الغاز" };
                    for (int i = 0; i < s2.Length; i++)
                    {
                        cb1.Items.Add(s2[i]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;

                case "حسب الموديل":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الموديل";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carModel = new CLS_FRMS.CLSCARS();
                    DataTable DtCarModel = carModel.CarDivisionGetDate();
                    for (int i = 0; i < DtCarModel.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtCarModel.Rows[i][11].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCarModel.Rows[i][11]!=null && DtCarModel.Rows[i][11].ToString()!="")
                        cb1.Items.Add(DtCarModel.Rows[i][11]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب قياس الاطار":
                    cb1.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل قياس الاطار";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS carTireSize = new CLS_FRMS.CLSCARS();
                    DataTable DtCarTireSize = carTireSize.CarDivisionGetDate();
                    for (int i = 0; i < DtCarTireSize.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtCarTireSize.Rows[i][15].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtCarTireSize.Rows[i][15] != null && DtCarTireSize.Rows[i][15].ToString() != "")
                            cb1.Items.Add(DtCarTireSize.Rows[i][15]);
                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب نوع العجلة والموديل":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل نوع العجلة";
                    cb1.Items.Clear();
                    cb2.Enabled = true;
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل الموديل";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS cartypeandModel = new CLS_FRMS.CLSCARS();
                    DataTable DtcartypeandModel = cartypeandModel.CarDivisionGetDate();
                    for (int i = 0; i < DtcartypeandModel.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtcartypeandModel.Rows[i][2].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtcartypeandModel.Rows[i][2] != null && DtcartypeandModel.Rows[i][2].ToString() != "")
                            cb1.Items.Add(DtcartypeandModel.Rows[i][2]);

                        int z = 0;
                        while (z < cb2.Items.Count && DtcartypeandModel.Rows[i][11].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DtcartypeandModel.Rows[i][11] != null && DtcartypeandModel.Rows[i][11].ToString() != "")
                            cb2.Items.Add(DtcartypeandModel.Rows[i][11]);
                    }                   
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب الشركة المصنعة و الموديل":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الشركة المصنعة";
                    cb1.Items.Clear();
                 
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل الموديل";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS carCoandModel = new CLS_FRMS.CLSCARS();
                    DataTable DtcarCoandModel = carCoandModel.CarDivisionGetDate();
                    for (int i = 0; i < DtcarCoandModel.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtcarCoandModel.Rows[i][3].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtcarCoandModel.Rows[i][3] != null && DtcarCoandModel.Rows[i][3].ToString() != "")
                            cb1.Items.Add(DtcarCoandModel.Rows[i][3]);

                        int z = 0;
                        while (z < cb2.Items.Count && DtcarCoandModel.Rows[i][11].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DtcarCoandModel.Rows[i][11] != null && DtcarCoandModel.Rows[i][11].ToString() != "")
                            cb2.Items.Add(DtcarCoandModel.Rows[i][11]);
                    }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;

                case "حسب الحالة والموديل":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الحالة";
                    cb1.Items.Clear();
                    
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل الموديل";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS carStateandModel = new CLS_FRMS.CLSCARS();
                    DataTable DtcarStateandModel = carStateandModel.CarDivisionGetDate();
                    for (int i = 0; i < DtcarStateandModel.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtcarStateandModel.Rows[i][8].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtcarStateandModel.Rows[i][8] != null && DtcarStateandModel.Rows[i][8].ToString() != "")
                            cb1.Items.Add(DtcarStateandModel.Rows[i][8]);

                        int z = 0;
                        while (z < cb2.Items.Count && DtcarStateandModel.Rows[i][11].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DtcarStateandModel.Rows[i][11] != null && DtcarStateandModel.Rows[i][11].ToString() != "")
                            cb2.Items.Add(DtcarStateandModel.Rows[i][11]);
                    }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "حسب نوع العجلة والعائدية":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل نوع العجلة";
                    cb1.Items.Clear();
                   
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل العائدية";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS cartypeandDep = new CLS_FRMS.CLSCARS();
                    DataTable DtcartypeandDep = cartypeandDep.CarDivisionGetDate();
                    for (int i = 0; i < DtcartypeandDep.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtcartypeandDep.Rows[i][2].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtcartypeandDep.Rows[i][2] != null && DtcartypeandDep.Rows[i][2].ToString() != "")
                            cb1.Items.Add(DtcartypeandDep.Rows[i][2]);

                        int z = 0;
                        while (z < cb2.Items.Count && DtcartypeandDep.Rows[i][7].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DtcartypeandDep.Rows[i][7] != null && DtcartypeandDep.Rows[i][7].ToString() != "")
                            cb2.Items.Add(DtcartypeandDep.Rows[i][7]);
                    }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;

                case "حسب الحالة والعائدية":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل الحالة";
                    cb1.Items.Clear();
                    
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل العائدية";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS carStateandDep = new CLS_FRMS.CLSCARS();
                    DataTable DtcarStateandDep = carStateandDep.CarDivisionGetDate();
                    for (int i = 0; i < DtcarStateandDep.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DtcarStateandDep.Rows[i][8].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtcarStateandDep.Rows[i][8] != null && DtcarStateandDep.Rows[i][8].ToString() != "")
                            cb1.Items.Add(DtcarStateandDep.Rows[i][8]);

                        int z = 0;
                        while (z < cb2.Items.Count && DtcarStateandDep.Rows[i][7].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DtcarStateandDep.Rows[i][7] != null && DtcarStateandDep.Rows[i][7].ToString() != "")
                            cb2.Items.Add(DtcarStateandDep.Rows[i][7]);
                    }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;

                case "حسب القسم والشعبة":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل القسم";
                    cb1.Items.Clear();
                    
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل الشعبة";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS carDivisionandDep = new CLS_FRMS.CLSCARS();
                    DataTable DTcarDivisionandDep = carDivisionandDep.CarDivisionGetDate();
                    for (int i = 0; i < DTcarDivisionandDep.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DTcarDivisionandDep.Rows[i][9].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DTcarDivisionandDep.Rows[i][9] != null && DTcarDivisionandDep.Rows[i][9].ToString() != "")
                            cb1.Items.Add(DTcarDivisionandDep.Rows[i][9]);

                        int z = 0;
                        while (z < cb2.Items.Count && DTcarDivisionandDep.Rows[i][10].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DTcarDivisionandDep.Rows[i][10] != null && DTcarDivisionandDep.Rows[i][10].ToString() != "")
                            cb2.Items.Add(DTcarDivisionandDep.Rows[i][10]);
                    }
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "خلاصة حسب نوع العجلة":
                    cb1.Enabled = true;
                  
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل نوع العجلة";
                    cb1.Items.Clear();
                    CLS_FRMS.CLSCARS SummryCarType = new CLS_FRMS.CLSCARS();
                    DataTable DtSummryCar = SummryCarType.CarDivisionGetDate();
                    for (int i = 0; i < DtSummryCar.Rows.Count; i++)
                    {

                        int j = 0;
                        while (j < cb1.Items.Count && DtSummryCar.Rows[i][2].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DtSummryCar.Rows[i][2] != null && DtSummryCar.Rows[i][2].ToString() != "")
                            cb1.Items.Add(DtSummryCar.Rows[i][2]);

                    }
                    cb2.Enabled = false;
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "خلاصة حسب الشعبة ":
                    cb1.Enabled = true;
                    cb2.Enabled = true;
                    cb1.DataSource = null;
                    cb1.BackColor = Color.Red; cb1.Text = "ادخل القسم ";
                    cb1.Items.Clear();
                   
                    cb2.DataSource = null;
                    cb2.BackColor = Color.Red; cb2.Text = "ادخل الشعبة ";
                    cb2.Items.Clear();
                    CLS_FRMS.CLSCARS SummryCarDiv = new CLS_FRMS.CLSCARS();
                    DataTable DTSummryCarDiv = SummryCarDiv.CarDivisionGetDate();
                    for (int i = 0; i < DTSummryCarDiv.Rows.Count; i++)
                    {
                        int j = 0;
                        while (j < cb1.Items.Count && DTSummryCarDiv.Rows[i][9].ToString() != cb1.Items[j].ToString())
                            j++;
                        if (j == cb1.Items.Count && DTSummryCarDiv.Rows[i][9] != null && DTSummryCarDiv.Rows[i][9].ToString() != "")
                            cb1.Items.Add(DTSummryCarDiv.Rows[i][9]);

                        int z = 0;
                        while (z < cb2.Items.Count && DTSummryCarDiv.Rows[i][10].ToString() != cb2.Items[z].ToString())
                            z++;
                        if (z == cb2.Items.Count && DTSummryCarDiv.Rows[i][10] != null && DTSummryCarDiv.Rows[i][10].ToString() != "")
                            cb2.Items.Add(DTSummryCarDiv.Rows[i][10]);
                    }
                    
                    cb3.Enabled = false;
                    cb4.Enabled = false;
                    break;
                case "خلاصة حسب العائدية":
                    cb1.Enabled = false;
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
            if (cbRPType.InvokeRequired)
            {
                cbRPType.Invoke(new MethodInvoker(delegate { name = cbRPType.Text; }));
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
                case "حسب نوع العجلة":
                    CLS_FRMS.CLS_RPCARS rp = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt = new DataTable();
                    Dt = rp.SelectCarsByCarType(name1);
                    DataTable Cons = Dt.Copy();
                    Cons.Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons.ImportRow(Dt.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons, cbRPType);
                        });
                    }
                    break;
                case "حسب الشركة المصنعة":
                    CLS_FRMS.CLS_RPCARS rp1 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt1 = new DataTable();
                    Dt1 = rp1.SelectCarsByCarCo(name1);
                    DataTable Cons1 = Dt1.Copy();
                    Cons1.Clear();
                    for (int i = 0; i < Dt1.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons1.ImportRow(Dt1.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons1, cbRPType);
                        });
                    }
                    break;
                case "حسب الحالة":
                    CLS_FRMS.CLS_RPCARS rp2 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt2 = new DataTable();
                    Dt2 = rp2.SelectCarsByCarState(name1);
                    DataTable Cons2 = Dt2.Copy();
                    Cons2.Clear();
                    for (int i = 0; i < Dt2.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons2.ImportRow(Dt2.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons2, cbRPType);
                        });
                    }
                    break;
                case "حسب عائدية العجلة":
                    CLS_FRMS.CLS_RPCARS rp3 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt3 = new DataTable();
                    Dt3 = rp3.SelectCarsByCarDep(name1);
                    DataTable Cons3 = Dt3.Copy();
                    Cons3.Clear();
                    for (int i = 0; i < Dt3.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons3.ImportRow(Dt3.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons3, cbRPType);
                        });
                    }
                    break;
                case "حسب نوع الوقود":
                    CLS_FRMS.CLS_RPCARS rp4 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt4 = new DataTable();
                    Dt4 = rp4.SelectCarsByCarFuel(name1);
                    DataTable Cons4 = Dt4.Copy();
                    Cons4.Clear();
                    for (int i = 0; i < Dt4.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons4.ImportRow(Dt4.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons4, cbRPType);
                        });
                    }
                    break;
                case "حسب الموديل":
                    CLS_FRMS.CLS_RPCARS rp5 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt5 = new DataTable();
                    Dt5 = rp5.SelectCarsByCarModel(name1);
                    DataTable Cons5 = Dt5.Copy();
                    Cons5.Clear();
                    for (int i = 0; i < Dt5.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons5.ImportRow(Dt5.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons5, cbRPType);
                        });
                    }
                    break;
                case "حسب قياس الاطار":
                    CLS_FRMS.CLS_RPCARS rpTireSize = new CLS_FRMS.CLS_RPCARS();
                    DataTable DtTireSize = new DataTable();
                    DtTireSize = rpTireSize.SelectCarsByCarTireSize(name1);
                    DataTable ConsTireSize = DtTireSize.Copy();
                    ConsTireSize.Clear();
                    for (int i = 0; i < DtTireSize.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            ConsTireSize.ImportRow(DtTireSize.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, ConsTireSize, cbRPType);
                        });
                    }
                    break;
                case "حسب نوع العجلة والموديل":
                    CLS_FRMS.CLS_RPCARS rp6 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt6 = new DataTable();
                    Dt6 = rp6.SelectCarsByCarTypeandModel(name1,name2);
                    DataTable Cons6 = Dt6.Copy();
                    Cons6.Clear();
                    for (int i = 0; i < Dt6.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons6.ImportRow(Dt6.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons6, cbRPType);
                        });
                    }
                    break;
                case "حسب الشركة المصنعة و الموديل":
                    CLS_FRMS.CLS_RPCARS rp7 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt7 = new DataTable();
                    Dt7 = rp7.SelectCarsByCarCoandModel(name1,name2);
                    DataTable Cons7 = Dt7.Copy();
                    Cons7.Clear();
                    for (int i = 0; i < Dt7.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons7.ImportRow(Dt7.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons7, cbRPType);
                        });
                    }
                    break;
                case "حسب الحالة والموديل":
                    CLS_FRMS.CLS_RPCARS rp8 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt8 = new DataTable();
                    Dt8 = rp8.SelectCarsByCarStateandModel(name1, name2);
                    DataTable Cons8 = Dt8.Copy();
                    Cons8.Clear();
                    for (int i = 0; i < Dt8.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons8.ImportRow(Dt8.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons8, cbRPType);
                        });
                    }
                    break;
                case "حسب نوع العجلة والعائدية":
                    CLS_FRMS.CLS_RPCARS rp9 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt9 = new DataTable();
                    Dt9 = rp9.SelectCarsByCarTypeandDep(name1, name2);
                    DataTable Cons9 = Dt9.Copy();
                    Cons9.Clear();
                    for (int i = 0; i < Dt9.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons9.ImportRow(Dt9.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons9, cbRPType);
                        });
                    }
                    break;

                case "حسب الحالة والعائدية":
                    CLS_FRMS.CLS_RPCARS rp10 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt10 = new DataTable();
                    Dt10 = rp10.SelectCarsByCarStateandDep(name1, name2);
                    DataTable Cons10 = Dt10.Copy();
                    Cons10.Clear();
                    for (int i = 0; i < Dt10.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons10.ImportRow(Dt10.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons10, cbRPType);
                        });
                    }
                    break;

                case "حسب القسم والشعبة":
                    CLS_FRMS.CLS_RPCARS rp11 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt11 = new DataTable();
                    Dt11 = rp11.SelectCarsByCarDivisionandDep(name1, name2);
                    DataTable Cons11 = Dt11.Copy();
                    Cons11.Clear();
                    for (int i = 0; i < Dt11.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons11.ImportRow(Dt11.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons11, cbRPType);
                        });
                    }
                    break;
                case "خلاصة حسب نوع العجلة":
                    CLS_FRMS.CLS_RPCARS rp12 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt12 = new DataTable();
                    Dt12 = rp12.SummryCarType(name1);
                    DataTable Cons12 = Dt12.Copy();
                    Cons12.Clear();
                    for (int i = 0; i < Dt12.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons12.ImportRow(Dt12.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons12, cbRPType);
                        });
                    }
                    break;
                case "خلاصة حسب الشعبة ":
                    CLS_FRMS.CLS_RPCARS rp13 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt13 = new DataTable();
                    Dt13 = rp13.SummryCarDiviion(name1,name2);
                    DataTable Cons13 = Dt13.Copy();
                    Cons13.Clear();
                    for (int i = 0; i < Dt13.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 100; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons13.ImportRow(Dt13.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons13, cbRPType);
                        });
                    }
                    break;
                case "خلاصة حسب العائدية":
                    CLS_FRMS.CLS_RPCARS rp14 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt14 = new DataTable();
                    Dt14 = rp14.SummryCarDEpartment();
                    DataTable Cons14 = Dt14.Copy();
                    Cons14.Clear();
                    for (int i = 0; i < Dt14.Rows.Count; i++)
                    {
                        int sum = 0;
                        for (int j = 0; j < 10; j++)
                        {
                            sum = sum + j;
                        }
                        lb1.Invoke((MethodInvoker)delegate { lb1.Text = i.ToString(); });
                        bgwork.ReportProgress(i);
                        Dgv.Invoke((MethodInvoker)delegate
                        {
                            Cons14.ImportRow(Dt14.Rows[i]);
                            CLS_FRMS.CLS_RPCARS dgv = new CLS_FRMS.CLS_RPCARS();
                            dgv.Dgvdesign(Dgv, Cons14, cbRPType);
                        });
                    }
                    break;
            }

        }

        private void bgwork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (cbRPType.Text)
            {
                case "حسب نوع العجلة":
                    CLS_FRMS.CLS_RPCARS rp = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt = new DataTable();
                    Dt = rp.SelectCarsByCarType(cb1.Text);
                    prog.Maximum = Dt.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب الشركة المصنعة":
                    CLS_FRMS.CLS_RPCARS rp1 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt1 = new DataTable();
                    Dt1 = rp1.SelectCarsByCarCo(cb1.Text);
                    prog.Maximum = Dt1.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب الحالة":
                    CLS_FRMS.CLS_RPCARS rp2 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt2 = new DataTable();
                    Dt2 = rp2.SelectCarsByCarState(cb1.Text);
                    prog.Maximum = Dt2.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب عائدية العجلة":
                    CLS_FRMS.CLS_RPCARS rp3 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt3 = new DataTable();
                    Dt3 = rp3.SelectCarsByCarDep(cb1.Text);
                    prog.Maximum = Dt3.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب نوع الوقود":
                    CLS_FRMS.CLS_RPCARS rp4 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt4 = new DataTable();
                    Dt4 = rp4.SelectCarsByCarFuel(cb1.Text);
                    prog.Maximum = Dt4.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب الموديل":
                    CLS_FRMS.CLS_RPCARS rp5 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt5 = new DataTable();
                    Dt5 = rp5.SelectCarsByCarModel(cb1.Text);
                    prog.Maximum = Dt5.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب قياس الاطار":
                    CLS_FRMS.CLS_RPCARS rpTireSize = new CLS_FRMS.CLS_RPCARS();
                    DataTable DtTireSize = new DataTable();
                    DtTireSize = rpTireSize.SelectCarsByCarTireSize(cb1.Text);
                    prog.Maximum = DtTireSize.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب نوع العجلة والموديل":
                    CLS_FRMS.CLS_RPCARS rp6 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt6 = new DataTable();
                    Dt6 = rp6.SelectCarsByCarTypeandModel(cb1.Text,cb2.Text);
                    prog.Maximum = Dt6.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب الشركة المصنعة و الموديل":
                    CLS_FRMS.CLS_RPCARS rp7 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt7 = new DataTable();
                    Dt7 = rp7.SelectCarsByCarCoandModel(cb1.Text, cb2.Text);
                    prog.Maximum = Dt7.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب الحالة والموديل":
                    CLS_FRMS.CLS_RPCARS rp8 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt8 = new DataTable();
                    Dt8 = rp8.SelectCarsByCarStateandModel(cb1.Text, cb2.Text);
                    prog.Maximum = Dt8.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "حسب نوع العجلة والعائدية":
                    CLS_FRMS.CLS_RPCARS rp9 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt9 = new DataTable();
                    Dt9 = rp9.SelectCarsByCarTypeandDep(cb1.Text, cb2.Text);
                    prog.Maximum = Dt9.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;

                case "حسب الحالة والعائدية":
                    CLS_FRMS.CLS_RPCARS rp10 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt10 = new DataTable();
                    Dt10 = rp10.SelectCarsByCarStateandDep(cb1.Text, cb2.Text);
                    prog.Maximum = Dt10.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;

                case "حسب القسم والشعبة":
                    CLS_FRMS.CLS_RPCARS rp11 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt11 = new DataTable();
                    Dt11 = rp11.SelectCarsByCarDivisionandDep(cb1.Text, cb2.Text);
                    prog.Maximum = Dt11.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "خلاصة حسب نوع العجلة":
                    CLS_FRMS.CLS_RPCARS rp12 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt12 = new DataTable();
                    Dt12 = rp12.SummryCarType(cb1.Text);
                    prog.Maximum = Dt12.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "خلاصة حسب الشعبة ":
                    CLS_FRMS.CLS_RPCARS rp13 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt13 = new DataTable();
                    Dt13 = rp13.SummryCarDiviion(cb1.Text,cb2.Text);
                    prog.Maximum = Dt13.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
                case "خلاصة حسب العائدية":
                    CLS_FRMS.CLS_RPCARS rp14 = new CLS_FRMS.CLS_RPCARS();
                    DataTable Dt14 = new DataTable();
                    Dt14 = rp14.SummryCarDEpartment();
                    prog.Maximum = Dt14.Rows.Count;
                    prog.Value = e.ProgressPercentage;
                    if (prog.Value == prog.Maximum - 1) { prog.Visible = false; prog.Value = 0; lb1.Visible = false; }
                    break;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLS_RPCARS rp = new CLS_FRMS.CLS_RPCARS();
            DataTable Dt = new DataTable();
            DS.DataSetMechanisms dss = new DS.DataSetMechanisms();
            REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
            switch (cbRPType.Text)
            {
                case "حسب نوع العجلة":                   
                    Dt = rp.SelectCarsByCarType(cb1.Text);
                    dss.Tables["CarsByType"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByType"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],Dt.Rows[i][2], Dt.Rows[i][3],i+1);
                    }
                    REPORTS.CarsByType rpt = new REPORTS.CarsByType();

                   
                    rpt.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\n نوع العجلة: " + cb1.Text;
                    
                    rpt.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt.DataSource = dss;
                    rpt.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt;
                    break;
                case "حسب الشركة المصنعة":
                   
                    Dt = rp.SelectCarsByCarCo(cb1.Text);
                    dss.Tables["CarsByCarCo"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByCarCo"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3],i+1);
                    }

                    
                    REPORTS.CarsByCo rpt1 = new REPORTS.CarsByCo();

                    
                    rpt1.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالشركة المصنعة: " + cb1.Text ;
                    rpt1.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt1.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt1.DataSource = dss;
                    rpt1.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt1;
                    break;
                case "حسب الحالة":
                   
                    Dt = rp.SelectCarsByCarState(cb1.Text);
                    dss.Tables["CarsByState"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByState"].Rows.Add(i + 1, Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][4], Dt.Rows[i][3]);
                    }
                    REPORTS.CarsByState rpt2 = new REPORTS.CarsByState();

                   
                    rpt2.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\n الحالة: " + cb1.Text;
                    rpt2.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt2.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt2.DataSource = dss;
                    rpt2.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt2;
                    break;
                case "حسب عائدية العجلة":
                   
                    Dt = rp.SelectCarsByCarDep(cb1.Text);
                    dss.Tables["CarsByDeptAndDivAndState"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByDeptAndDivAndState"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3],i+1);
                    }
                    REPORTS.CarsByDeptAndDivAndState rpt3 = new REPORTS.CarsByDeptAndDivAndState();

                  
                    rpt3.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nعائدية العجلة: " + cb1.Text;
                    rpt3.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt3.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt3.DataSource = dss;
                    rpt3.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt3;
                    break;
                case "حسب نوع الوقود":
                   
                    Dt = rp.SelectCarsByCarFuel(cb1.Text);
                    dss.Tables["CarsByFuel"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByFuel"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4],i+1);
                    }
                    REPORTS.CarsByFuel rpt4 = new REPORTS.CarsByFuel();

                    
                    rpt4.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nنوع الوقود: " + cb1.Text;
                    rpt4.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt4.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt4.DataSource = dss;
                    rpt4.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt4;
                    break;
                case "حسب الموديل":
                   
                    Dt = rp.SelectCarsByCarModel(cb1.Text);
                    dss.Tables["CarsByStateAndModel"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByStateAndModel"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], i + 1);
                    }
                    REPORTS.CarsByStateAndModel rpt5 = new REPORTS.CarsByStateAndModel();

                   
                    rpt5.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالموديل: " + cb1.Text;
                    rpt5.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt5.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt5.DataSource = dss;
                    rpt5.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt5;
                    break;
                case "حسب قياس الاطار":

                    Dt = rp.SelectCarsByCarTireSize(cb1.Text);
                    dss.Tables["CarsByTireSize"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByTireSize"].Rows.Add(i + 1,Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }
                    REPORTS.CarsByTireSize rptTireSize = new REPORTS.CarsByTireSize();


                    rptTireSize.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nقياس الاطار: " + cb1.Text;
                    rptTireSize.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rptTireSize.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rptTireSize.DataSource = dss;
                    rptTireSize.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rptTireSize;
                    break;
                case "حسب نوع العجلة والموديل":
                  
                    Dt = rp.SelectCarsByCarTypeandModel(cb1.Text, cb2.Text);
                    
                    dss.Tables["CarsByTypeAndModel"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByTypeAndModel"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2],i+1);
                    }
                    REPORTS.CarsByTypeAndModel rpt6 = new REPORTS.CarsByTypeAndModel();

                   
                    rpt6.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nنوع العجلة: " + cb1.Text + " \r\nالموديل: " + cb2.Text;
                    
                    rpt6.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt6.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt6.DataSource = dss;
                    rpt6.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt6;
                    break;
                case "حسب الشركة المصنعة و الموديل":
                   
                    Dt = rp.SelectCarsByCarCoandModel(cb1.Text, cb2.Text);
                  
                    dss.Tables["CarsByCoAndModel"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByCoAndModel"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2],i+1);
                    }
                    REPORTS.CarsByCoAndModel rpt7 = new REPORTS.CarsByCoAndModel();

                   
                    rpt7.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالشركة المصنعة: " + cb1.Text + " \r\nالموديل: " + cb2.Text;
                   
                    rpt7.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt7.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt7.DataSource = dss;
                    rpt7.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt7;
                    break;
                case "حسب الحالة والموديل":
                    
                    Dt = rp.SelectCarsByCarStateandModel(cb1.Text, cb2.Text);
                   
                    dss.Tables["CarsByStateAndModel"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByStateAndModel"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], i + 1);
                    }
                    REPORTS.CarsByStateAndModel rpt8 = new REPORTS.CarsByStateAndModel();

                   
                    rpt8.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالحالة: " + cb1.Text + " \r\nالموديل: " + cb2.Text;
                   
                    rpt8.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt8.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt8.DataSource = dss;
                    rpt8.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt8;
                    break;
                case "حسب نوع العجلة والعائدية":
                    
                    Dt = rp.SelectCarsByCarTypeandDep(cb1.Text, cb2.Text);
                    
                    dss.Tables["CarsByTypeAndDepartment"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByTypeAndDepartment"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2],i+1);
                    }
                    REPORTS.CarsByTypeAndDept rpt9 = new REPORTS.CarsByTypeAndDept();

                   
                    rpt9.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nنوع العجلة: " + cb1.Text + " \r\nعائدية العجلة: " + cb2.Text ;
                
                    rpt9.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt9.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt9.DataSource = dss;
                    rpt9.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt9;
                    break;

                case "حسب الحالة والعائدية":
                   
                    Dt = rp.SelectCarsByCarStateandDep(cb1.Text, cb2.Text);
                   
                    dss.Tables["CarsByDeptAndDivAndState"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        dss.Tables["CarsByDeptAndDivAndState"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3],i+1);
                    }
                    REPORTS.CarsByDeptAndDivAndState rpt10 = new REPORTS.CarsByDeptAndDivAndState();

                  
                    rpt10.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالحالة: " + cb1.Text + " \r\nعائدية العجلة: " + cb2.Text ;
                   
                    rpt10.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt10.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt10.DataSource = dss;
                    rpt10.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt10;
                    break;

                case "حسب القسم والشعبة":

                    Dt = rp.SelectCarsByCarDivisionandDep(cb1.Text, cb2.Text);
                    
                    dss.Tables["CarsByDeptAndDivAndState"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dss.Tables["CarsByDeptAndDivAndState"].Rows.Add( Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3],i+1);
                    }
                    REPORTS.CarsByDeptAndDivAndState rpt11 = new REPORTS.CarsByDeptAndDivAndState();

                   
                    rpt11.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nالقسم: " + cb1.Text + "\r\nالشعبة: " + cb2.Text ;
                   
                    rpt11.Parameters["CarsCount"].Value = Dt.Rows.Count;
                    rpt11.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt11.DataSource = dss;
                    rpt11.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt11;
                    break;
                case "خلاصة حسب نوع العجلة":

                    Dt = rp.SummryCarType(cb1.Text);

                    dss.Tables["SummryCarByType"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dss.Tables["SummryCarByType"].Rows.Add(i+1,Dt.Rows[i][0], Dt.Rows[i][1]);
                    }
                    REPORTS.SummryCarByType rpt12 = new REPORTS.SummryCarByType();

                    rpt12.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text + "\r\nنوع العجلة: " + cb1.Text ;
                    
                    rpt12.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt12.DataSource = dss;
                    rpt12.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt12;
                    break;
                case "خلاصة حسب الشعبة ":

                    Dt = rp.SummryCarDiviion(cb1.Text, cb2.Text);

                    dss.Tables["SummryCarByDivision"].Clear();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dss.Tables["SummryCarByDivision"].Rows.Add(i + 1, Dt.Rows[i][0], Dt.Rows[i][1],Dt.Rows[i][2]);
                    }
                    REPORTS.SumryCarByDiv rpt13 = new REPORTS.SumryCarByDiv();

                    rpt13.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text+ "\r\nالقسم: " + cb1.Text+ "\r\nالشعبة: " + cb2.Text ;
                    
                    rpt13.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt13.DataSource = dss;
                    rpt13.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt13;
                    break;
                case "خلاصة حسب العائدية":

                    Dt = rp.SummryCarDEpartment();

                    dss.Tables["SummryCarsByDept"].Clear();
                    string dept = Dt.Rows[0][0].ToString();
                    int index = 1;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {

                        if (dept != Dt.Rows[i][0].ToString())
                        {
                            index++;
                            dept = Dt.Rows[i][0].ToString();
                           
                        }
                        dss.Tables["SummryCarsByDept"].Rows.Add(index, Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2]);
                      
                    }
                    REPORTS.SummryCarsByDepartment rpt14 = new REPORTS.SummryCarsByDepartment();


                    rpt14.Parameters["RpType"].Value = "تقرير العجلات " + cbRPType.Text;

                    rpt14.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt14.DataSource = dss;
                    rpt14.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt14;
                    break;
            }

            
            
            frm.ShowDialog();

        }
    }
}