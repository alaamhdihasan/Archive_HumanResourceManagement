using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;
using System.IO;
using System.Globalization;
using TwainLib;
using DevExpress.XtraEditors;




namespace MechanismsCD.FRMS
{
    public partial class MAINFRM : Form
    {
        public string newpath;
        public string pathimage;
        public string nameimage;
        List<Tuple<string,int>> notifclest;
        CurrencyManager CmCar;
        DataTable DtSlave;
        DataTable DtCar;
        public MAINFRM()
        {
            try { 
            InitializeComponent();

            xtraTabPage1.Show();


            btnmain.Dock = DockStyle.Right;
            btnmain.Width = 130;
            lbmain.Text = "الرئيسية";
            lbmain.Dock = DockStyle.Right;
            btnmain.BringToFront();

            // This is InterFaces For Programming---------------------------


            this.pnfile.Visible = false;
            this.pnentry.Visible = false;
            this.pnthatia.Visible = false;
            this.pnemployee.Visible = false;
            this.pncars.Visible = false;
            this.pnadvisor.Visible = false;
            this.pnsetting.Visible = false;
            this.pnFuel.Visible = false;

            // this code for buttons Click in pnentry panel
            this.simpleButton9.Click += new System.EventHandler(this.button_Click);
            this.simpleButton10.Click += new System.EventHandler(this.button_Click);
            this.simpleButton11.Click += new System.EventHandler(this.button_Click);
            this.simpleButton12.Click += new System.EventHandler(this.button_Click);
            this.btndivision.Click += new System.EventHandler(this.button_Click);
            this.btnunits.Click += new System.EventHandler(this.button_Click);
            this.btnjobs.Click += new System.EventHandler(this.button_Click);
            this.btndegree.Click += new System.EventHandler(this.button_Click);
           this.BtnStores.Click += new System.EventHandler(this.button_Click);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (pn_main.Width == 200)
            {
                pn_main.Width = 40;
                animatorPN.ShowSync(pn_main);

            }
            else if (pn_main.Width == 40)
            {
                pn_main.Width = 200;
                animatorPN.ShowSync(pn_main);
            }
        }

        private void MAINFRM_Load(object sender, EventArgs e)
        {
            try
            {
                FRM_LOGIN frm = new FRM_LOGIN();
            CLS_FRMS.CLS_UsersAndPermissions PermissionOne = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = PermissionOne.PerOne(Properties.Settings.Default.UserNameLogin.ToString(),Properties.Settings.Default.PasswordLogin.ToString());


            PermissionOne.PerTow(Dt, btnbackupdate, btnrestoredate, simpleButton9, simpleButton10
                , simpleButton11, simpleButton12, btndivision, btnunits, btnjobs, btndegree, simpleButton15, simpleButton16, btnSynchornization
                , simpleButton18, simpleButton38, btncardivision, btncarsmovment, btncartanker, btncaraccident, btncarfuel, btncarcounter
                , simpleButton13, simpleButton41, simpleButton40, simpleButton39, btnSynchornization, FRMDivReceive, btnEmployee, btnArchivie, btnCar, btnDivRecevie);

            DataTable Dt2 = PermissionOne.PerTow(Properties.Settings.Default.UserNameLogin.ToString(), Properties.Settings.Default.PasswordLogin.ToString());
            PermissionOne.PerTow2(Dt2, btnrepocarmovemnet, btnrepocardivision, btnrepocartanker, btnrepocarfuel, btnrepocaraccident, btnrepocarcounter
                , simpleButton24, btnRepAttendance, btnRPEmployee, btnRPCar);

                CLS_FRMS.CLSCONSTENTRY notifc = new CLS_FRMS.CLSCONSTENTRY();
                notifclest = notifc.notifcation();
                lblnotfic.Text = notifclest.Count.ToString();

                //dc1.VlbOne = 50;
                lblUserName.Text = Properties.Settings.Default.UserNameLogin;
            lblSystemName.Text= Properties.Settings.Default.ServerName;
                DataTable  dtcarper = PermissionOne.PerThree(Properties.Settings.Default.UserNameLogin, Properties.Settings.Default.PasswordLogin, "العجلات");
    
                if (dtcarper.Rows.Count > 0)
                {
                    
                    if (dtcarper.Rows[0][5].ToString() == null || dtcarper.Rows[0][5].ToString() == "" || dtcarper.Rows[0][5].ToString() == "False")
                        btncaradd.Enabled = false;
                    else btncaradd.Enabled = true;
                    if (dtcarper.Rows[0][6].ToString() == null || dtcarper.Rows[0][6].ToString() == "" || dtcarper.Rows[0][6].ToString() == "False")
                        btncarsave.Enabled = false;
                    else btncarsave.Enabled = true;
                    if (dtcarper.Rows[0][7].ToString() == null || dtcarper.Rows[0][7].ToString() == "" || dtcarper.Rows[0][7].ToString() == "False")
                        btncardelete.Enabled = false;
                    else btncardelete.Enabled = true;
                    if (dtcarper.Rows[0][8].ToString() == null || dtcarper.Rows[0][8].ToString() == "" || dtcarper.Rows[0][8].ToString() == "False")
                        btnCarPrint.Enabled = false;
                    else btnCarPrint.Enabled = true;

                }
        }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try { 
            if (pnfile.Visible == false)
            {
                pnfile.BringToFront();
                pnfile.Visible = true;
                pnfile.Dock = DockStyle.Right;
                pnfile.Width = 218;

            }
            else if (pnfile.Visible == true)
            {
                pnfile.Visible = false;

            }
            pnentry.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnthatia.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try { 
            if (pnentry.Visible == false)
            {
                pnentry.BringToFront();
                pnentry.Visible = true;
                pnentry.Dock = DockStyle.Right;
                pnentry.Width = 218;
                animatorPN.ShowSync(pnentry);


            }
            else if (pnentry.Visible == true)
            {
                pnentry.Visible = false;

            }
            pnfile.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnthatia.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try { 
            if (pnthatia.Visible == false)
            {
                pnthatia.BringToFront();
                pnthatia.Visible = true;
                pnthatia.Dock = DockStyle.Right;
                pnthatia.Width = 218;

            }
            else if (pnthatia.Visible == true)
            {
                pnthatia.Visible = false;

            }
            pnfile.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnentry.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try { 
            if (pnemployee.Visible == false)
            {
                pnemployee.BringToFront();
                pnemployee.Visible = true;
                pnemployee.Dock = DockStyle.Right;
                pnemployee.Width = 260;

            }
            else if (pnemployee.Visible == true)
            {
                pnemployee.Visible = false;

            }
            pnfile.Visible = false;
            pnthatia.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnentry.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try { 
            if (pncars.Visible == false)
            {
                pncars.BringToFront();
                pncars.Visible = true;
                pncars.Dock = DockStyle.Right;
                pncars.Width = 260;

            }
            else if (pncars.Visible == true)
            {
                pncars.Visible = false;

            }
            pnfile.Visible = false;
            pnthatia.Visible = false;
            pnemployee.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnentry.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            try { 
            if (pnsetting.Visible == false)
            {
                pnsetting.BringToFront();
                pnsetting.Visible = true;
                pnsetting.Dock = DockStyle.Right;
                pnsetting.Width = 218;

            }
            else if (pnsetting.Visible == true)
            {
                pnsetting.Visible = false;
            }
            pnfile.Visible = false;
            pnthatia.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnentry.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnmain_Click(object sender, EventArgs e)
        {


        }

        private void btnentryclose_Click(object sender, EventArgs e)
        {
            EntryInterfaceClose();

        }

        private void btnentry_Click(object sender, EventArgs e)
        {
            xtraTabPage2.PageVisible = true;
            EntryInterfaceShow();

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            try { 
            if (pnadvisor.Visible == false)
            {
                pnadvisor.BringToFront();
                pnadvisor.Visible = true;
                pnadvisor.Dock = DockStyle.Right;
                pnadvisor.Width = 218;
            }
            else if (pnadvisor.Visible == true)
            {
                pnadvisor.Visible = false;
            }
            pnfile.Visible = false;
            pnthatia.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnsetting.Visible = false;
            pnentry.Visible = false;
            pnFuel.Visible = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.pnentry.Visible = false;

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.pnfile.Visible = false;

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            pnthatia.Visible = false;

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            pnemployee.Visible = false;

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            pnsetting.Visible = false;

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            pncars.Visible = false;

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            pnadvisor.Visible = false;
        }

        private void simpleButton9_Click_1(object sender, EventArgs e)
        {

            databindingclear();
            EntryInterfaceShow();


        }
        public void EntryInterfaceShow()
        {
            btnentry.Dock = DockStyle.Right;
            btnentry.Width = 130;
            btnentry.BringToFront();
            btnentry.Visible = true;
            tmdataentry.Start();
            xtraTabPage2.PageVisible = true;
            xtraTabPage2.Show();

        }
        public void EntryInterfaceClose()
        {

            entryinterface.Width = 462;
            groupdata.Width = 460;

        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void button_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.SimpleButton button = sender as DevExpress.XtraEditors.SimpleButton;

            lbentry.Text = button.Text;
            lbentry.Dock = DockStyle.Right;

            EntryInterfaceShow();
            pnentry.Visible = false;

        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();

        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void tmdataentry_Tick(object sender, EventArgs e)
        {
            try { 
            if (lbentry.Text == "المستفيدين" )
            {
                pncustomer.Dock = DockStyle.Right;
                pncustomer.Width = 333;
                pncustomer.Visible = true;
                pndata.Dock = DockStyle.Fill;
                tbdata.Visible = false;
                tbseq.Visible = false;
                tbCustomerName.Focus();
                entryinterface.Dock = DockStyle.Fill;
                entryinterface.Visible = true;

                label1.Text = "الرقم التعريفي";
                label2.Text ="اسم المستفيد";
                label3.Text = "الجهة المقصودة";
                label4.Text = "الجهة المستفيدة";
                label7.Visible = true;               
                label4.Visible = true;
                label5.Text = "الحالة";
                label6.Visible = true;
                DeptInvest.Visible = false;
                cboTheType.Visible = true;
                cboJob.Visible = true;
                tbRegisterName.Enabled = false;
                tbRegisterName.Multiline = false;
                tbRegisterName.Location = new Point(cboJob.Location.X, 539);
                tbRegisterName.Size = new Size(cboBeneficiary.Size.Width, cboBeneficiary.Size.Height);
            }
            else
            { if (lbentry.Text == "المخازن")
                {
                    pncustomer.Dock = DockStyle.Right;
                    pncustomer.Width = 333;
                    pncustomer.Visible = true;
                    pndata.Dock = DockStyle.Fill;
                    tbdata.Visible = false;
                    tbseq.Visible = false;
                    tbCustomerName.Focus();
                    entryinterface.Dock = DockStyle.Fill;
                    entryinterface.Visible = true;

                    label1.Text = "رقم المخزن";
                    label2.Text = "اسم المخزن";
                    label3.Text = "موقع المخزن";
                    label4.Text = "سعة المخزن";
                    label5.Text = "الوصف";
                    tbRegisterName.Enabled = true;
                    tbRegisterName.Multiline = true;
                    tbRegisterName.Location = new Point(cboTheType.Location.X, cboTheType.Location.Y);
                    tbRegisterName.Size= new Size(cboBeneficiary.Size.Width, 200);
                   
                    label6.Visible = false;
                    label7.Visible = false;                    
                    
                    cboTheType.Visible = false;
                    cboJob.Visible = false;
                    DeptInvest.Visible = false;
                }
                else
                {
                    if (lbentry.Text == "اقسام العتبة")
                    {
                        pncustomer.Visible = false;
                        pndata.Dock = DockStyle.Right;
                        pndata.Width = 462;
                        tbdata.Visible = true;
                        tbseq.Visible = true;
                        tbdata.Focus();
                        entryinterface.Dock = DockStyle.Fill;
                        entryinterface.Visible = true;
                        DeptInvest.Visible = true;
                    } else
                    {
                        pncustomer.Visible = false;
                        pndata.Dock = DockStyle.Right;
                        pndata.Width = 462;
                        tbdata.Visible = true;
                        tbseq.Visible = true;
                        tbdata.Focus();
                        entryinterface.Dock = DockStyle.Fill;
                        entryinterface.Visible = true;
                        DeptInvest.Visible = false;
                    }
                }
            }
            tmdataentry.Stop();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCONSTENTRY clscon = new CLS_FRMS.CLSCONSTENTRY();
            if (lbentry.Text == "اقسام العتبة")
            {
                databindingclear();
                clscon.GetDataDepartment();
                DataTable Dt = clscon.GetDataDepartment();

               
                dgvdata.DataSource = Dt;
                dgvdata.Columns[0].Visible = false;
                tbseq.DataBindings.Add("text", Dt, "IDdepart");
                tbdata.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                DeptInvest.DataBindings.Add("Checked", Dt, "الجهات الاستثمارية");
                    txtCount.Visible = false; 
            }
            else if (lbentry.Text == "بيانات الحالة")
            {
                databindingclear();
                clscon.TheTypeselection();
                DataTable Dt = clscon.TheTypeselection();
                dgvdata.DataSource = Dt;
                dgvdata.Columns[0].Visible = false;
                tbseq.DataBindings.Add("text", Dt, "IDType");
                tbdata.DataBindings.Add("text", Dt, "الحالة");
                    txtCount.Visible = false;
                }
            else if (lbentry.Text == "مواقع واماكن")
            {
                databindingclear();
                clscon.DistenationSelecting();
                DataTable Dt = clscon.DistenationSelecting();
                dgvdata.DataSource = Dt;
                dgvdata.Columns[0].Visible = false;
                tbseq.DataBindings.Add("text", Dt, "IDdis");
                tbdata.DataBindings.Add("text", Dt, "الجهة المقصودة");
                    txtCount.Visible = false;
                }
            else if (lbentry.Text == "المستفيدين")
            {
                databindingclear();
                clscon.TheCustomerSelection();
                DataTable Dt = clscon.TheCustomerSelection();
                dgvdata.DataSource = Dt;
                dgvdata.Columns[0].Visible = false;
                tbsequence.DataBindings.Add("text", Dt, "IDcustomer");
                tbCustomerName.DataBindings.Add("text", Dt, "اسم المستفيد");
                cboDistenation.DataBindings.Add("text", Dt, "الجهة المقصودة");
                cboBeneficiary.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                cboTheType.DataBindings.Add("text", Dt, "نوع الحالة");
                cboJob.DataBindings.Add("text", Dt, "الوظيفة");
                tbRegisterName.DataBindings.Add("text", Dt, "مدخل البيانات");
                    txtCount.Visible = false;
                }
            else if (lbentry.Text == "الشعب")
            {
                clscon.DivisionsNameGetData(dgvdata, tbdata, tbseq, pnbtnsdata);
                    txtCount.Visible = false;
                }
            else if (lbentry.Text == "الوحدات")
            {
                clscon.UnitsNamesGetdata(dgvdata, tbdata, tbseq, pnbtnsdata);
                    txtCount.Visible = false;
                }
            else if (lbentry.Text == "الوظائف")
            {
                clscon.JobsNamesGetdata(dgvdata, tbdata, tbseq,txtCount, pnbtnsdata);
                    txtCount.Visible = true;
                }
            else if (lbentry.Text == "الشهادة")
            {
                clscon.StudyingNamesGetData(dgvdata, tbdata, tbseq, pnbtnsdata);
                    txtCount.Visible = false;
                }
            else if(lbentry.Text == "المخازن")
            {
                databindingclear();
                clscon.SelectAllStores();
                DataTable Dt = clscon.SelectAllStores();
                dgvdata.DataSource = Dt;
                dgvdata.Columns[0].Visible = false;
                dgvdata.Columns[1].HeaderText = "اسم المخزن";
                dgvdata.Columns[2].HeaderText = "موقع المخزن";
                dgvdata.Columns[3].HeaderText = "الوصف";
                tbsequence.DataBindings.Add("text", Dt, "IDStore");
                tbCustomerName.DataBindings.Add("text", Dt, "StoreName");
                cboDistenation.DataBindings.Add("text", Dt, "StoreLocation");
                tbRegisterName.DataBindings.Add("text",Dt, "Description");
                    txtCount.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void databindingclear()
        {
            try { 
            dgvdata.DataSource = null;
            tbdata.DataBindings.Clear();
            tbseq.DataBindings.Clear();
                txtCount.DataBindings.Clear();
            tbsequence.DataBindings.Clear();
            tbCustomerName.DataBindings.Clear();
            cboDistenation.DataBindings.Clear();
            cboBeneficiary.DataBindings.Clear();
            cboTheType.DataBindings.Clear();
            cboJob.DataBindings.Clear();
            tbRegisterName.DataBindings.Clear();
            DeptInvest.DataBindings.Clear();

            tbdata.Clear();
            tbseq.Clear();
            tbsequence.Clear();
            tbCustomerName.Clear();
            cboDistenation.Text = "";
            cboBeneficiary.Text = "";
            cboJob.Text = "";
            cboTheType.Text = "";
            tbRegisterName.Clear();
                txtCount.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnadddata_Click(object sender, EventArgs e)
        {
            try {
                DialogResult d = MessageBox.Show("هل تريد اضافة هذا القيد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSCONSTENTRY AddData = new CLS_FRMS.CLSCONSTENTRY();

                    if (lbentry.Text == "اقسام العتبة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {

                            AddData.insertintoDepartments(tbdata.Text, DeptInvest.Checked);

                            databindingclear();
                            AddData.GetDataDepartment();
                            DataTable Dt = AddData.GetDataDepartment();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdepart");
                            tbdata.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                            DeptInvest.DataBindings.Add("Checked", Dt, "الجهات الاستثمارية");
                        }

                    }
                    else if (lbentry.Text == "بيانات الحالة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الحالة", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.TheTypeInsertinto(tbdata.Text);

                            databindingclear();
                            AddData.TheTypeselection();
                            DataTable Dt = AddData.TheTypeselection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDType");
                            tbdata.DataBindings.Add("text", Dt, "الحالة");
                        }

                    }
                    else if (lbentry.Text == "مواقع واماكن")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المواقع والاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.DistenationInsertinto(tbdata.Text);

                            databindingclear();
                            AddData.DistenationSelecting();
                            DataTable Dt = AddData.DistenationSelecting();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdis");
                            tbdata.DataBindings.Add("text", Dt, "الجهة المقصودة");

                        }

                    }
                    else if (lbentry.Text == "المستفيدين")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المستفيدين", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.TheCustomerInsertInto(tbCustomerName.Text, cboDistenation.Text, cboBeneficiary.Text
                                , cboTheType.Text, cboJob.Text, tbRegisterName.Text);

                            databindingclear();
                            AddData.TheCustomerSelection();
                            DataTable Dt = AddData.TheCustomerSelection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbsequence.DataBindings.Add("text", Dt, "IDcustomer");
                            tbCustomerName.DataBindings.Add("text", Dt, "اسم المستفيد");
                            cboDistenation.DataBindings.Add("text", Dt, "الجهة المقصودة");
                            cboBeneficiary.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                            cboTheType.DataBindings.Add("text", Dt, "نوع الحالة");
                            cboJob.DataBindings.Add("text", Dt, "الوظيفة");
                            tbRegisterName.DataBindings.Add("text", Dt, "مدخل البيانات");
                        }

                    }
                    else if (lbentry.Text == "الشعب")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الشعب", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.DivisionsNameInsertDdata(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text);
                        }
                    }
                    else if (lbentry.Text == "الوحدات")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الوحدات", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.UnitsNamesInsertdata(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text);
                        }
                    }
                    else if (lbentry.Text == "الوظائف")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الوظيفة", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.JobsNamesinsertData(dgvdata, tbdata, tbseq, txtCount, pnbtnsdata, tbdata.Text);
                        }
                    }
                    else if (lbentry.Text == "الشهادة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الشهادة", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.StudyingNamesinsertdata(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text);
                        }
                    }
                    else if (lbentry.Text == "المخازن")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل اسم المخزن", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            AddData.AddNewStore(tbCustomerName.Text, cboDistenation.Text, tbRegisterName.Text, Convert.ToDouble(cboBeneficiary.Text));

                            databindingclear();
                            AddData.SelectAllStores();
                            DataTable Dt = AddData.SelectAllStores();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            dgvdata.Columns[1].HeaderText = "اسم المخزن";
                            dgvdata.Columns[2].HeaderText = "موقع المخزن";
                            dgvdata.Columns[3].HeaderText = "الوصف";
                            tbsequence.DataBindings.Add("text", Dt, "IDStore");
                            tbCustomerName.DataBindings.Add("text", Dt, "StoreName");
                            cboDistenation.DataBindings.Add("text", Dt, "StoreLocation");
                            tbRegisterName.DataBindings.Add("text", Dt, "Description");
                        }

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            try { 
            tbdata.Clear();
            tbseq.Clear();
            tbsequence.Clear();
            tbCustomerName.Clear();
            cboDistenation.Text = "";
            cboBeneficiary.Text = "";
            cboJob.Text = "";
            cboTheType.Text = "";
            tbRegisterName.Clear();

            btnadddata.Enabled = true;

            if (lbentry.Text == "المستفيدين")
            {
                CLS_FRMS.CLSCONSTENTRY clscon = new CLS_FRMS.CLSCONSTENTRY();
                DataTable Dtdistenation = clscon.DistenationSelecting();
                cboDistenation.DataSource = Dtdistenation;
                cboDistenation.DisplayMember = "الجهة المقصودة";

                DataTable Dtdepartment = clscon.GetDataDepartment();
                cboBeneficiary.DataSource = Dtdepartment;
                cboBeneficiary.DisplayMember = "الاقسام والمواقع";

                DataTable Dtthetype = clscon.TheTypeselection();
                cboTheType.DataSource = Dtthetype;
                cboTheType.DisplayMember = "الحالة";

            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnsavedata_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريدتعديل هذا القيد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSCONSTENTRY savedata = new CLS_FRMS.CLSCONSTENTRY();
                    if (lbentry.Text == "اقسام العتبة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {

                            savedata.DepartmentsUpdatedata(Convert.ToInt32(tbseq.Text), tbdata.Text, DeptInvest.Checked);

                            databindingclear();
                            savedata.GetDataDepartment();
                            DataTable Dt = savedata.GetDataDepartment();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdepart");
                            tbdata.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                            DeptInvest.DataBindings.Add("Checked", Dt, "الجهات الاستثمارية");
                        }


                    }
                    else if (lbentry.Text == "بيانات الحالة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الحالة", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.TheTypeUpdate(Convert.ToInt32(tbseq.Text), tbdata.Text);

                            databindingclear();
                            savedata.TheTypeselection();
                            DataTable Dt = savedata.TheTypeselection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDType");
                            tbdata.DataBindings.Add("text", Dt, "الحالة");
                        }

                    }
                    else if (lbentry.Text == "مواقع واماكن")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المواقع والاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.DistenationUpdate(Convert.ToInt32(tbseq.Text), tbdata.Text);

                            databindingclear();
                            savedata.DistenationSelecting();
                            DataTable Dt = savedata.DistenationSelecting();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdis");
                            tbdata.DataBindings.Add("text", Dt, "الجهة المقصودة");
                        }

                    }
                    else if (lbentry.Text == "المستفيدين")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المستفيدين", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbCustomerName.Focus();
                        }
                        else
                        {
                            savedata.TheCustomerUpdate(Convert.ToInt32(tbsequence.Text), tbCustomerName.Text, cboDistenation.Text, cboBeneficiary.Text
                                , cboTheType.Text, cboJob.Text, tbRegisterName.Text);

                            databindingclear();
                            savedata.TheCustomerSelection();
                            DataTable Dt = savedata.TheCustomerSelection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbsequence.DataBindings.Add("text", Dt, "IDcustomer");
                            tbCustomerName.DataBindings.Add("text", Dt, "اسم المستفيد");
                            cboDistenation.DataBindings.Add("text", Dt, "الجهة المقصودة");
                            cboBeneficiary.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                            cboTheType.DataBindings.Add("text", Dt, "نوع الحالة");
                            cboJob.DataBindings.Add("text", Dt, "الوظيفة");
                            tbRegisterName.DataBindings.Add("text", Dt, "مدخل البيانات");
                        }

                    }
                    else if (lbentry.Text == "الشعب")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.DivisionsNameUpdateData(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text, Convert.ToInt32(tbseq.Text));
                        }

                    }
                    else if (lbentry.Text == "الوحدات")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.UnitsNamesUpdatedata(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "الوظائف")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.JobsNamesUpdatedata(dgvdata, tbdata, tbseq, txtCount, pnbtnsdata, tbdata.Text, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "الشهادة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.StudyingNamesUpdatedata(dgvdata, tbdata, tbseq, pnbtnsdata, tbdata.Text, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "المخازن")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            savedata.UpdateStore(int.Parse(tbsequence.Text), tbCustomerName.Text, cboDistenation.Text, tbRegisterName.Text, Convert.ToDouble(cboBeneficiary.Text));

                            databindingclear();
                            savedata.SelectAllStores();
                            DataTable Dt = savedata.SelectAllStores();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            dgvdata.Columns[1].HeaderText = "اسم المخزن";
                            dgvdata.Columns[2].HeaderText = "موقع المخزن";
                            dgvdata.Columns[3].HeaderText = "الوصف";
                            tbsequence.DataBindings.Add("text", Dt, "IDStore");
                            tbCustomerName.DataBindings.Add("text", Dt, "StoreName");
                            cboDistenation.DataBindings.Add("text", Dt, "StoreLocation");
                            tbRegisterName.DataBindings.Add("text", Dt, "Description");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btndeleledata_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذا القيد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSCONSTENTRY deletedata = new CLS_FRMS.CLSCONSTENTRY();
                    if (lbentry.Text == "اقسام العتبة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {

                            deletedata.DepartmentsDeleting(Convert.ToInt32(tbseq.Text));

                            databindingclear();
                            deletedata.GetDataDepartment();
                            DataTable Dt = deletedata.GetDataDepartment();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdepart");
                            tbdata.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                            DeptInvest.DataBindings.Add("Checked", Dt, "الجهات الاستثمارية", false, DataSourceUpdateMode.OnPropertyChanged);
                        }

                    }
                    else if (lbentry.Text == "بيانات الحالة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات الحالة", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.TheTypeDeleting(Convert.ToInt32(tbseq.Text));

                            databindingclear();
                            deletedata.TheTypeselection();
                            DataTable Dt = deletedata.TheTypeselection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDType");
                            tbdata.DataBindings.Add("text", Dt, "الحالة");
                        }

                    }
                    else if (lbentry.Text == "مواقع واماكن")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المواقع والاقسام", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.DistenationDeleting(Convert.ToInt32(tbseq.Text));

                            databindingclear();
                            deletedata.DistenationSelecting();
                            DataTable Dt = deletedata.DistenationSelecting();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbseq.DataBindings.Add("text", Dt, "IDdis");
                            tbdata.DataBindings.Add("text", Dt, "الجهة المقصودة");
                        }

                    }
                    else if (lbentry.Text == "المستفيدين")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى ملىء حقل بيانات المستفيدين", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.ThecustomerDeleting(Convert.ToInt32(tbsequence.Text));

                            databindingclear();
                            deletedata.TheCustomerSelection();
                            DataTable Dt = deletedata.TheCustomerSelection();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            tbsequence.DataBindings.Add("text", Dt, "IDcustomer");
                            tbCustomerName.DataBindings.Add("text", Dt, "اسم المستفيد");
                            cboDistenation.DataBindings.Add("text", Dt, "الجهة المقصودة");
                            cboBeneficiary.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                            cboTheType.DataBindings.Add("text", Dt, "نوع الحالة");
                            cboJob.DataBindings.Add("text", Dt, "الوظيفة");
                            tbRegisterName.DataBindings.Add("text", Dt, "مدخل البيانات");
                        }

                    }
                    else if (lbentry.Text == "الشعب")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى جلب الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.DivisionsNameDeleteData(dgvdata, tbdata, tbseq, pnbtnsdata, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "الوحدات")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى جلب الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.UnitsNamesDeleteData(dgvdata, tbdata, tbseq, pnbtnsdata, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "الوظائف")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى جلب الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.JobsNamesdeleteData(dgvdata, tbdata, tbseq, txtCount, pnbtnsdata, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "الشهادة")
                    {
                        if (tbdata.Text == "")
                        {
                            MessageBox.Show("يرجى جلب الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.StudyingNamesDeletedata(dgvdata, tbdata, tbseq, pnbtnsdata, Convert.ToInt32(tbseq.Text));
                        }
                    }
                    else if (lbentry.Text == "المخازن")
                    {
                        if (tbCustomerName.Text == "")
                        {
                            MessageBox.Show("يرجى جلب الحقول اولا", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbdata.Focus();
                        }
                        else
                        {
                            deletedata.DeleteStore(int.Parse(tbsequence.Text));

                            databindingclear();
                            deletedata.SelectAllStores();
                            DataTable Dt = deletedata.SelectAllStores();
                            dgvdata.DataSource = Dt;
                            dgvdata.Columns[0].Visible = false;
                            dgvdata.Columns[1].HeaderText = "اسم المخزن";
                            dgvdata.Columns[2].HeaderText = "موقع المخزن";
                            dgvdata.Columns[3].HeaderText = "الوصف";
                            tbsequence.DataBindings.Add("text", Dt, "IDStore");
                            tbCustomerName.DataBindings.Add("text", Dt, "StoreName");
                            cboDistenation.DataBindings.Add("text", Dt, "StoreLocation");
                            tbRegisterName.DataBindings.Add("text", Dt, "Description");
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }


        private void btncarload_Click(object sender, EventArgs e)
        {
            try { 
            SelectDivisionCars();

            CLS_FRMS.CLSCARS GetArcheive = new CLS_FRMS.CLSCARS();
            DataTable Dt = GetArcheive.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate,
                LstCar, PnCarAr);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncardivision_Click(object sender, EventArgs e)
        {

           
        }

        private void btncarnew_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS cleartext = new CLS_FRMS.CLSCARS();
            cleartext.CardivisionCleartext(tbcarnobarcode, cbocartypebarcode, cbobrandbarcode
             , tbcarbarcode, tbtransportnamebarcode, cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode
             , cbobelogto, cbodivision, cboFuelType, tbcarmodel, tbshasyno, tbregisternamebarcode, tbaddtimebarcode, tbaddingdatebarcode
             ,tbCarDocumentNo,tbCarColor);

            cleartext.cbodata(cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode, cbobelogto, cbocartypebarcode,cbobrandbarcode,cbodivision);
            tbregisternamebarcode.Text = "";
            tbaddingdatebarcode.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tbaddtimebarcode.Text = DateTime.Now.ToString("hh:mm tt");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCarinterface_Click(object sender, EventArgs e)
        {
            //maininterface.Visible = false;
            //entryinterface.Visible = false;

            //CarsInterFace.Dock = DockStyle.Fill;
            //CarsInterFace.Visible = true;

        }

        private void btncarinterfaceclose_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS displaydata = new CLS_FRMS.CLSCARS();
            displaydata.CarDivisionClearData(dgvcarsdivision, tbcarnobarcode, cbocartypebarcode, cbobrandbarcode
             , tbcarbarcode, tbtransportnamebarcode, cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode
             , cbobelogto, cbodivision, cboFuelType, tbcarmodel, tbshasyno, tbregisternamebarcode, tbaddtimebarcode, tbaddingdatebarcode
             ,tbCarDocumentNo,tbCarColor,txtTireSize);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //CarsInterFace.Visible = false;
            //btnCarinterface.Visible = false;
            //btncarinterfaceclose.Visible = false;
        }

        private void tbsearchingbarcode_TextChanged(object sender, EventArgs e)
        {
            try { 
            (dgvcarsdivision.DataSource as DataTable).DefaultView.RowFilter = string.Format("[رقم العجلة] LIKE '%{0}%' OR [نوع العجلة] like'%{1}%' OR [الخط] like'%{2}%' OR [عائدية العجلة] like'%{3}%' OR [الشعبة] like'%{4}%' OR [نوع الوقود] like'%{5}%' OR [الشاصي] like'%{6}%' OR [قياس الاطارات] like'%{6}%'", tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text, tbsearchingbarcode.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncaradd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة هذه العجلة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSCARS insertdata = new CLS_FRMS.CLSCARS();
                    insertdata.CarDivisionInsertData(tbCarDocumentNo.Text, tbcarnobarcode.Text, cbocartypebarcode.Text, cbobrandbarcode.Text
                        , tbcarbarcode.Text, tbtransportnamebarcode.Text, cbodistenationbarcode.Text, cbobeneficiarybarcode.Text
                        , cbothetypebarcode.Text, cbobelogto.Text, cbodivision.Text, cboFuelType.Text, tbcarmodel.Text
                        , tbshasyno.Text, tbregisternamebarcode.Text, tbaddtimebarcode.Text, tbaddingdatebarcode.Text, tbCarColor.Text, txtTireSize.Text
                        );

                    SelectDivisionCars();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncarsave_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult dialogResult = MessageBox.Show("هل تريد التعديل على هذه العجلة!", "تأكييد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CLS_FRMS.CLSCARS updatedata = new CLS_FRMS.CLSCARS();
                updatedata.CarDivisionUpdateData(tbCarDocumentNo.Text, tbcarnobarcode.Text, cbocartypebarcode.Text, cbobrandbarcode.Text
                    , tbcarbarcode.Text, tbtransportnamebarcode.Text, cbodistenationbarcode.Text, cbobeneficiarybarcode.Text
                    , cbothetypebarcode.Text, cbobelogto.Text, cbodivision.Text, cboFuelType.Text, tbcarmodel.Text, tbshasyno.Text
                    , tbregisternamebarcode.Text, tbaddtimebarcode.Text, tbaddingdatebarcode.Text,tbCarColor.Text, txtTireSize.Text);

                SelectDivisionCars();
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncardelete_Click(object sender, EventArgs e)
        {
            try{ 
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذه العجلة!", "تأكييد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CLS_FRMS.CLSCARS deletedata = new CLS_FRMS.CLSCARS();
                deletedata.CarDivisionDeleteData(tbcarnobarcode.Text);

                SelectDivisionCars();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btncarsmovment_Click(object sender, EventArgs e)
        {
            

        }



        private void btncommingbarcodesys_Click(object sender, EventArgs e)
        {


        }



        //---- This Function For Getting Data Or Selection Data From DivisionCars Table-------------------------------------
        public void SelectDivisionCars()
        {
            try { 
            CLS_FRMS.CLSCARS displaydata = new CLS_FRMS.CLSCARS();

            displaydata.CarDivisionClearData(dgvcarsdivision, tbcarnobarcode, cbocartypebarcode, cbobrandbarcode
              , tbcarbarcode, tbtransportnamebarcode, cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode
              , cbobelogto, cbodivision, cboFuelType, tbcarmodel, tbshasyno, tbregisternamebarcode, tbaddtimebarcode, tbaddingdatebarcode
              ,tbCarDocumentNo,tbCarColor,txtTireSize);
            DtCar = null;
            displaydata.cbodata(cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode, cbobelogto, cbocartypebarcode, cbobrandbarcode, cbodivision);

            DtCar = displaydata.CarDivisionDisplayData(dgvcarsdivision, tbcarnobarcode, cbocartypebarcode, cbobrandbarcode
              , tbcarbarcode, tbtransportnamebarcode, cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode
              , cbobelogto, cbodivision, cboFuelType, tbcarmodel, tbshasyno, tbregisternamebarcode, tbaddtimebarcode, tbaddingdatebarcode
              ,tbCarDocumentNo,tbCarColor,txtTireSize);
            CmCar= (CurrencyManager)this.BindingContext[DtCar];

                //  displaydata.cbodata(cbodistenationbarcode, cbobeneficiarybarcode, cbothetypebarcode, cbobelogto, cbocartypebarcode, cbobrandbarcode,cbodivision);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }




        private void btncartanker_Click(object sender, EventArgs e)
        {
           
        }



        private void btncaraccident_Click(object sender, EventArgs e)
        {
            
        }

        private void btncarcounter_Click(object sender, EventArgs e)
        {
           
        }

        private void btncarfuel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrepocarmovemnet_Click(object sender, EventArgs e)
        {
           

        }

        private void btnrepocarfuel_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrepocaraccident_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrepocartanker_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrepocarcounter_Click(object sender, EventArgs e)
        {
           
        }

        private void simpleButton15_Click(object sender, EventArgs e)
        {
            Label x = new Label();
            x.Text = "المنتسبين";
            FRMEMPLOYEES FRM = new FRMEMPLOYEES(x);
            FRM.ShowDialog();
            pnemployee.Visible = false;
        }

        private void simpleButton40_Click(object sender, EventArgs e)
        {
            FRMS.FRM_SETTING FRM = new FRM_SETTING();
            FRM.ShowDialog();
            pnsetting.Visible = false;
        }

        private void btndivision_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void btnunits_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void btnjobs_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void btndegree_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void simpleButton24_Click(object sender, EventArgs e)
        {
            FRMRPEMPEMPLOYEES frm = new FRMRPEMPEMPLOYEES();
            frm.Show();
            pnemployee.Visible = false;
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            Guidthatyia frm = new Guidthatyia(this);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.MinimumSize = frm.Size;
            frm.MaximumSize = frm.Size;
            pnthatia.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {
            //btnwajba.Dock = DockStyle.Right;
            //btnwajba.Width = 130;
            //btnwajba.BringToFront();
            //lbwajba.Text = simpleButton17.Text;
            //lbwajba.Dock = DockStyle.Right;
            //btnwajba.Visible = true;
            //xtraTabPage4.PageVisible = true;
            //xtraTabPage4.Show();
            //pnemployee.Visible = false;
            FRMSynchornization frm = new FRMSynchornization();
            frm.ShowDialog();
        }

        private void lbmain_Click(object sender, EventArgs e)
        {
            xtraTabPage1.Show();
        }

        private void lbentry_Click(object sender, EventArgs e)
        {
            xtraTabPage2.Show();
        }

        private void btnentryclose_Click_1(object sender, EventArgs e)
        {
            btnentry.Visible = false;
            xtraTabPage2.PageVisible = false;
        }

        private void lbcarinterface_Click(object sender, EventArgs e)
        {
            xtraTabPage3.Show();
        }

        private void carinterfaceclose_Click(object sender, EventArgs e)
        {
            xtraTabPage3.PageVisible = false;
            btncarinterface.Visible = false;
        }

        private void lbmain_Click_1(object sender, EventArgs e)
        {
            xtraTabPage1.PageVisible = true;
            xtraTabPage1.Show();
        }

        private void btnsheft2loading_Click(object sender, EventArgs e)
        {
            try { 
            // This button form loading data from Employeeshesft1 table .......
            CLS_FRMS.CLSATTENDENCE GetDatasheft1 = new CLS_FRMS.CLSATTENDENCE();
            GetDatasheft1.EmployeesSheft1GetData(dgvsheft1, tbidsheft1, tbnamesheft1, tbfromdatesheft1
                , tbtodatesheft1, tbregistersheft1, tbaddingtimesheft1, tbaddingdatesheft1);

            CLS_FRMS.CLSATTENDENCE GetDataSheft = new CLS_FRMS.CLSATTENDENCE();
            GetDataSheft.EmpSheftGetData(dgv3);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void simpleButton26_Click(object sender, EventArgs e)
        {
            try { 
            // This button form updating Data of Employeessheft1 table ......
            tbaddingtimesheft1.Text = DateTime.Now.ToString("HH:mm tt");
            tbaddingdatesheft1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            tbregistersheft1.Text = Properties.Settings.Default.UserNameLogin.ToString();
            CLS_FRMS.CLSATTENDENCE UpdateDatasheft1 = new CLS_FRMS.CLSATTENDENCE();
            UpdateDatasheft1.EmployeesSheft1Update(int.Parse(tbidsheft1.Text), tbnamesheft1.Text, tbfromdatesheft1.Text, tbtodatesheft1.Text,
                tbregistersheft1.Text, tbaddingtimesheft1.Text, tbaddingdatesheft1.Text);

            UpdateDatasheft1.EmployeesSheft1GetData(dgvsheft1, tbidsheft1, tbnamesheft1, tbfromdatesheft1
                , tbtodatesheft1, tbregistersheft1, tbaddingtimesheft1, tbaddingdatesheft1);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnsheft2new_Click(object sender, EventArgs e)
        {
            try { 
            tbnamesheft2.Text = "";
            tbbarcodesheft2.Text = "";
            tbregistersheft2.Text = Properties.Settings.Default.UserNameLogin.ToString();
            tbaddingtimesheft2.Text = DateTime.Now.ToString("HH:mm tt");
            tbaddingdatesheft2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            tbidconsheft2.Text = tbidsheft1.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnsheft2add_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSATTENDENCE Sheft2insertData = new CLS_FRMS.CLSATTENDENCE();
            Sheft2insertData.EmployeesSheft2Insert(int.Parse(tbidconsheft2.Text), tbnamesheft2.Text, tbbarcodesheft2.Text, tbregistersheft2.Text
                , tbaddingtimesheft2.Text, tbaddingdatesheft2.Text);

            CLS_FRMS.CLSATTENDENCE Sheft2selectData = new CLS_FRMS.CLSATTENDENCE();
            Sheft2selectData.EmployeesSheft2GetData(dgv2, tbidsheft2, tbidconsheft2, tbnamesheft2, tbbarcodesheft2
                , tbregistersheft2, tbaddingtimesheft2, tbaddingdatesheft2, int.Parse(tbidsheft1.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnsheft2save_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSATTENDENCE Sheft2UpdateData = new CLS_FRMS.CLSATTENDENCE();
            Sheft2UpdateData.EmployeesSheft2Update(int.Parse(tbidsheft2.Text), int.Parse(tbidconsheft2.Text), tbnamesheft2.Text, tbbarcodesheft2.Text,
                tbregistersheft2.Text, tbaddingtimesheft2.Text, tbaddingdatesheft2.Text);

            CLS_FRMS.CLSATTENDENCE Sheft2selectData = new CLS_FRMS.CLSATTENDENCE();
            Sheft2selectData.EmployeesSheft2GetData(dgv2, tbidsheft2, tbidconsheft2, tbnamesheft2, tbbarcodesheft2
                , tbregistersheft2, tbaddingtimesheft2, tbaddingdatesheft2, int.Parse(tbidsheft1.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvsheft1_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            if (tbidsheft1.Text == null || tbidsheft1.Text == "")
            {
                CLS_FRMS.CLSATTENDENCE Sheft2selectData = new CLS_FRMS.CLSATTENDENCE();
                Sheft2selectData.EmployeesSheft2GetData(dgv2, tbidsheft2, tbidconsheft2, tbnamesheft2, tbbarcodesheft2
                    , tbregistersheft2, tbaddingtimesheft2, tbaddingdatesheft2, 1);
                Employeescount.Text = "عدد الوجبة " + " " + dgv2.Rows.Count;
            }
            else
            {
                CLS_FRMS.CLSATTENDENCE Sheft2selectData = new CLS_FRMS.CLSATTENDENCE();
                Sheft2selectData.EmployeesSheft2GetData(dgv2, tbidsheft2, tbidconsheft2, tbnamesheft2, tbbarcodesheft2
                    , tbregistersheft2, tbaddingtimesheft2, tbaddingdatesheft2, int.Parse(tbidsheft1.Text));
                Employeescount.Text = "عدد الوجبة " + " " + dgv2.Rows.Count;
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbnamesheft2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            //Filter by EmployeeName To Get The Barcode of Employee.......
            CLS_FRMS.CLSCONSTENTRY GetBarcodeEmp = new CLS_FRMS.CLSCONSTENTRY();
            DataTable Dt = GetBarcodeEmp.GetnameEmployeeswithBarcode(tbnamesheft2.Text);
            tbbarcodesheft2.Text = Dt.Rows[0][0].ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnsheft2delete_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult Resault = MessageBox.Show("هل تريد بالتأكيد حذف البيانات المحددة", "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Resault == DialogResult.Yes)
            {
                CLS_FRMS.CLSATTENDENCE Sheft2DeleteData = new CLS_FRMS.CLSATTENDENCE();

                foreach (DataGridViewRow item in dgv2.SelectedRows)
                {
                    if (dgv2.SelectedRows.Count > 0)
                    {
                        tbidsheft2.Text = item.Cells[0].Value.ToString();
                        Sheft2DeleteData.EmployeesSheft2Delete(int.Parse(tbidsheft2.Text));
                    }
                    else
                    {
                        break;
                    }
                }

            }
            else
            {

            }
            CLS_FRMS.CLSATTENDENCE Sheft2SelectData = new CLS_FRMS.CLSATTENDENCE();
            Sheft2SelectData.EmployeesSheft2GetData(dgv2, tbidsheft2, tbidconsheft2, tbnamesheft2, tbbarcodesheft2
                , tbregistersheft2, tbaddingtimesheft2, tbaddingdatesheft2, int.Parse(tbidsheft1.Text));

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbnamesheft2_TextChanged(object sender, EventArgs e)
        {
            //Filter by EmployeeName To Get The Barcode of Employee.......
            try { 
            CLS_FRMS.CLSCONSTENTRY GetBarcodeEmp = new CLS_FRMS.CLSCONSTENTRY();
            DataTable Dt = GetBarcodeEmp.GetnameEmployeeswithBarcode(tbnamesheft2.Text);
            if (Dt.Rows.Count > 0)
                tbbarcodesheft2.Text = Dt.Rows[0][0].ToString();
            else
                tbbarcodesheft2.Text = "";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dgv2.SelectAll();
        }

        private void btnsheft2move_Click(object sender, EventArgs e)
        {
            // This button for trans. the selected rows to the EmpSheft Table ..... 
            try { 
            CLS_FRMS.CLSATTENDENCE EmpSheftinsert = new CLS_FRMS.CLSATTENDENCE();

            foreach (DataGridViewRow item in dgv2.SelectedRows)
            {
                if (dgv2.SelectedRows.Count > 0)
                {
                    tbnamesheft2.Text = item.Cells[2].Value.ToString();
                    tbbarcodesheft2.Text = item.Cells[3].Value.ToString();
                    tbregistersheft2.Text = item.Cells[4].Value.ToString();
                    tbaddingtimesheft2.Text = item.Cells[5].Value.ToString();
                    tbaddingdatesheft2.Text = item.Cells[6].Value.ToString();

                    EmpSheftinsert.EmpSheftinsertData(tbnamesheft2.Text, tbbarcodesheft2.Text, tbnamesheft1.Text, tbfromdatesheft1.Text,
                        tbtodatesheft1.Text, "", tbregistersheft2.Text, tbaddingtimesheft2.Text, tbaddingdatesheft2.Text);

                }
                else
                {
                    break;
                }
            }
            Tssheft2.RunWorkerAsync();
            if (PbTssheft2.Visible == false) { PbTssheft2.Visible = true; lbTssheft2.Visible = true; }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Tssheft2_DoWork(object sender, DoWorkEventArgs e)
        {
            try { 
            for (int i = 0; i < dgv2.SelectedRows.Count; i++)
            {
                lbTssheft2.Invoke((MethodInvoker)delegate { lbTssheft2.Text = i.ToString(); });
                Tssheft2.ReportProgress(i);
                int sum = 0;
                for (int j = 0; j < 100000000; j++)
                {
                    sum = sum + j;
                }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Tssheft2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try { 
            PbTssheft2.MaximumValue = dgv2.SelectedRows.Count;
            PbTssheft2.Value = e.ProgressPercentage;
            if (PbTssheft2.Value == PbTssheft2.MaximumValue - 1)
            {
                PbTssheft2.Visible = false; lbTssheft2.Visible = false;
                CLS_FRMS.CLSATTENDENCE GetDataSheft = new CLS_FRMS.CLSATTENDENCE();
                GetDataSheft.EmpSheftGetData(dgv3);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnwajbaclose_Click(object sender, EventArgs e)
        {
            xtraTabPage4.PageVisible = false;
            btnwajba.Visible = false;
        }

        private void lbwajba_Click(object sender, EventArgs e)
        {
            xtraTabPage4.PageVisible = true;
            xtraTabPage4.Show();
        }

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            FRMS.FRMATTENDENCE frm = new FRMATTENDENCE();
            frm.Show();
        }

        private void xtraTabPage14_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS GetArcheive = new CLS_FRMS.CLSCARS();
            DataTable Dt = GetArcheive.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate,
                LstCar, PnCarAr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ScannImageOne_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS InsertImage = new CLS_FRMS.CLSCARS();

            var b = TwainOperations.ScanImages();
            foreach (var Itm in b)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfCars + nameimage;
                CarArPic.Load(Itm);
                CarArPic.Image.Save(newpath);

                CarArNo.Text = tbcarnobarcode.Text;
                CarArImage.Text = newpath;
                LstCar.Items.Add(CarArImage.Text);
                CarArRegisterName.Text =Properties.Settings.Default.UserNameLogin.ToString();
                CarArAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                CarArAddingTime.Text = DateTime.Now.ToString("HH:mm tt");

                InsertImage.CarArInsertData(CarArNo.Text, CarArImage.Text, CarArRegisterName.Text, CarArAddingTime.Text, CarArAddingDate.Text);
            }
            InsertImage.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate
                , LstCar, PnCarAr);


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=============================================================================================================
        // Display Image to print or anything....
        private void LstCar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { 
            if (LstCar.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = LstCar.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = LstCar.Items[intselectedindex].Text;
                System.Diagnostics.Process.Start(text);

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=============================================================================================================
        //
        private void dgvcarsdivision_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS GetArcheive = new CLS_FRMS.CLSCARS();
            DataTable Dt = GetArcheive.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate,
                LstCar, PnCarAr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //====================================================================================================================
        //==== This Function Below for Scanning many images.......
        private void ScannImageMore_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS InsertImage = new CLS_FRMS.CLSCARS();

            var b = TwainOperations.ScanImages();
            foreach (var Itm in b)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfCars + nameimage;
                CarArPic.Load(Itm);
                CarArPic.Image.Save(newpath);

                CarArNo.Text = tbcarnobarcode.Text;
                CarArImage.Text = newpath;
                LstCar.Items.Add(CarArImage.Text);
                CarArRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();
                CarArAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                CarArAddingTime.Text = DateTime.Now.ToString("HH:mm tt");

                InsertImage.CarArInsertData(CarArNo.Text, CarArImage.Text, CarArRegisterName.Text, CarArAddingTime.Text, CarArAddingDate.Text);
            }
            InsertImage.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate
                , LstCar, PnCarAr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LstCar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //===================================================================================================================
        private void LstCar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try { 
            if (LstCar.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = LstCar.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = LstCar.Items[intselectedindex].Text;
                CLS_FRMS.CLSCARS GettingData = new CLS_FRMS.CLSCARS();
                DataTable Dt = GettingData.CarArSelectionbyimagepath(text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime,
                    CarArAddingDate, LstCar, PnCarAr);

            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //===============================================================================================================

        private void DeleteImage_Click(object sender, EventArgs e)
        { 
            try { 
            CLS_FRMS.CLSCARS Deleting = new CLS_FRMS.CLSCARS();
            Deleting.CarArDelete(int.Parse(CarArID.Text));

            Deleting.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate
                , LstCar, PnCarAr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //============================================================================================================

        private void simpleButton39_Click(object sender, EventArgs e)
        {
            FRM_USERS_PERMISSIONS frm = new FRM_USERS_PERMISSIONS();
            frm.Show();
            pnsetting.Hide();

        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            //CLS_FRMS.ProcessingDataBase Get1 = new CLS_FRMS.ProcessingDataBase();
            //DataTable Dt=  Get1.documentWared();

            //int x = 75000;
            //for (int i = 0; i < Dt.Rows.Count; i++)
            //{
            //    Get1.UpdateWared1(x, int.Parse(Dt.Rows[i][0].ToString()));
                
            //    DataTable Dt2 = new DataTable();
            //    Dt2 = Get1.documentWared2(int.Parse(Dt.Rows[i][0].ToString()));
            //    if (Dt2.Rows.Count > 0)
            //    {
            //      Get1.UpdateWared2(x,int.Parse( Dt.Rows[i][0].ToString()));
                   
            //    }
            //    Dt2 = null;
            //    x = x + 1;

            //}

        }
       private void BtnStores_Click(object sender, EventArgs e)
        {
            databindingclear();
            EntryInterfaceShow();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void btnfuel_Click(object sender, EventArgs e)
        {
            if (pnFuel.Visible == false)
            {
                pnFuel.BringToFront();
                pnFuel.Visible = true;
                pnFuel.Dock = DockStyle.Right;
                pnFuel.Width = 255;

            }
            else if (pnFuel.Visible == true)
            {
                pnFuel.Visible = false;

            }
            pnfile.Visible = false;
            pnemployee.Visible = false;
            pncars.Visible = false;
            pnadvisor.Visible = false;
            pnsetting.Visible = false;
            pnentry.Visible = false;
            pnthatia.Visible = false;
        }

        private void pnnew_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void interfacepro_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton9_Click_1(object sender, EventArgs e)
        {
            this.pnFuel.Visible = false;
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pncustomer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton30_Click(object sender, EventArgs e)
        {
            FRMS.FRMEntryFuel f = new FRMEntryFuel("ادخال وقود");
            f.ShowDialog();
            pnFuel.Visible = false;
        }

        private void simpleButton34_Click(object sender, EventArgs e)
        {
            FRMS.FRMEntryFuel f = new FRMEntryFuel("مخازن الوقود");
            f.ShowDialog();
            pnFuel.Visible = false;

        }

        private void simpleButton27_Click(object sender, EventArgs e)
        {
            FRMS.FRMEntryFuel f = new FRMEntryFuel("اخراج وقود");
            f.ShowDialog();
            pnFuel.Visible = false;
        }

        private void simpleButton25_Click(object sender, EventArgs e)
        {
            FRMS.FRMRPFUEL f = new FRMRPFUEL("تقارير اخراج وقود");
            f.Show();
            pnFuel.Visible = false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton31_Click(object sender, EventArgs e)
        {
            FRMS.FRMRPFUEL f = new FRMRPFUEL("تقارير ادخال وقود");
            f.Show();
            pnFuel.Visible = false;
        }

        private void btnbackupdate_Click(object sender, EventArgs e)
        {
            pnfile.Visible = false;
            FRMbackup backup = new FRMbackup("backup");
            backup.ShowDialog();
            
        }

        private void btnrestoredate_Click(object sender, EventArgs e)
        {
            pnfile.Visible = false;
            FRMbackup backup = new FRMbackup("recovery");
            backup.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnbell_Click(object sender, EventArgs e)
        {
            try { 
            FRMnotifc f = new FRMnotifc(notifclest,this);
            f.Location = new Point(btnbell.Location.X,btnbell.Location.Y);
        
            f.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbthetypelogin_Click(object sender, EventArgs e)
        {

        }

        private void pn_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnwajba_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btncarinterface_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnentry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnmain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void entryinterface_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pndata_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupdata_Enter(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnbtnsdata_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeptInvest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbseq_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbdata_TextChanged(object sender, EventArgs e)
        {

        }

        private void pncustomer_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void cboJob_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTheType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDistenation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbRegisterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbCustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbsequence_TextChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CarsInterFace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvcarsdivision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pncarmainly_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbCarDocumentNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void LbCarDocumentNo_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbothetypebarcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbobeneficiarybarcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbodistenationbarcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbtransportnamebarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbcarbarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbobrandbarcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbocartypebarcode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbcarnobarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void tbshasyno_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbcarmodel_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbodivision_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbobelogto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tbregisternamebarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbaddtimebarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbaddingdatebarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuCar_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ScannImage_Click(object sender, EventArgs e)
        {

        }

        private void PcImage_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSCARS InsertImage = new CLS_FRMS.CLSCARS();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select an file|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file_type = Path.GetExtension(ofd.FileName);
                pathimage = ofd.FileName;
                nameimage = System.IO.Path.GetFileName(pathimage);
                Random x = new Random();
                newpath = Properties.Settings.Default.PathOfCars + x.Next().ToString() + Path.GetExtension(nameimage);
                CarArPic.Load(pathimage);
                CarArPic.Image.Save(newpath);

                CarArNo.Text = tbcarnobarcode.Text;
                CarArImage.Text = newpath;
                LstCar.Items.Add(CarArImage.Text);
                CarArRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();
                CarArAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                CarArAddingTime.Text = DateTime.Now.ToString("HH:mm tt");

                InsertImage.CarArInsertData(CarArNo.Text, CarArImage.Text, CarArRegisterName.Text, CarArAddingTime.Text, CarArAddingDate.Text);
            }
            InsertImage.CarArSelection(tbcarnobarcode.Text, CarArID, CarArNo, CarArImage, CarArRegisterName, CarArAddingTime, CarArAddingDate
                , LstCar, PnCarAr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PnCarAr_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CarArPic_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void CarArRegisgggterName_Click(object sender, EventArgs e)
        {

        }

        private void CarArImagegggg_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void CarArAddingDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarArAddingTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarArRegisterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarArImage_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarArNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarArID_TextChanged(object sender, EventArgs e)
        {

        }

        private void xtraTabPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel19_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PbTssheft2_progressChanged(object sender, EventArgs e)
        {

        }

        private void lbTssheft2_Click(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbsearchsheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Employeescount_Click(object sender, EventArgs e)
        {

        }

        private void tbidsheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbidconsheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbnamesheft1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbaddingtimesheft1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbregistersheft1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void tbaddingdatesheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbaddingtimesheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbregistersheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbbarcodesheft2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbidsheft1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbaddingdatesheft1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbtodatesheft1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbfromdatesheft1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvsheft1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnleftsid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnentry_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnemployee_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton37_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton38_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton20_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton22_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton23_Click(object sender, EventArgs e)
        {
            FRMRPATTENDENCE f = new FRMRPATTENDENCE();
            f.Show();
            pnemployee.Visible = false;
        }

        private void simpleButton19_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {

        }

        private void pnthatia_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pnsetting_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnadvisor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton41_Click(object sender, EventArgs e)
        {

        }

        private void pncars_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnrepocardivision_Click(object sender, EventArgs e)
        {

        }

        private void pnfile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {

        }

        private void pnFuel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton29_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton28_Click(object sender, EventArgs e)
        {

        }

        private void tmDgvCarmovement_Tick(object sender, EventArgs e)
        {

        }

        private void tmbarcodedata_Tick(object sender, EventArgs e)
        {

        }

        private void btncardivision_Click_1(object sender, EventArgs e)
        {
            lbcarinterface.Text = btncardivision.Text;
            lbcarinterface.Dock = DockStyle.Right;
            btncarinterface.Dock = DockStyle.Right;

            btncarinterface.Width = 130;
            btncarinterface.BringToFront();
            btncarinterface.Visible = true;
            CarsInterFace.Dock = DockStyle.Fill;
            xtraTabPage13.PageVisible = true;
            xtraTabPage3.PageVisible = true;
            xtraTabPage3.Show();
            this.pncars.Visible = false;

        }

        private void btncarsmovment_Click_1(object sender, EventArgs e)
        {
            FRMBARCODESYSTEM frm = new FRMBARCODESYSTEM();
            frm.lbtitle.Text = "نظام الباركود";
            frm.ShowDialog();
            this.pncars.Visible = false;

        }

        private void btncartanker_Click_1(object sender, EventArgs e)
        {
            FRMCARSOPERATIONS frm = new FRMCARSOPERATIONS();
            frm.lbtitle.Text = btncartanker.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btncaraccident_Click_1(object sender, EventArgs e)
        {
            FRMCARSOPERATIONS frm = new FRMCARSOPERATIONS();
            frm.lbtitle.Text = btncaraccident.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btncarfuel_Click_1(object sender, EventArgs e)
        {
            FRMCARSOPERATIONS frm = new FRMCARSOPERATIONS();
            frm.lbtitle.Text = btncarfuel.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btncarcounter_Click_1(object sender, EventArgs e)
        {
            FRMCARSOPERATIONS frm = new FRMCARSOPERATIONS();
            frm.lbtitle.Text = btncarcounter.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btnrepocardivision_Click_1(object sender, EventArgs e)
        {
            FRMRPCAR f = new FRMRPCAR();
            f.ShowDialog();
            pncars.Visible = false;
        }

        private void btnrepocarmovemnet_Click_1(object sender, EventArgs e)
        {
            REPORTS.RPCARSOPERATIONS frm = new REPORTS.RPCARSOPERATIONS();
            frm.btntitle.ButtonText = btnrepocarmovemnet.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btnrepocartanker_Click_1(object sender, EventArgs e)
        {
            REPORTS.RPCARSOPERATIONS frm = new REPORTS.RPCARSOPERATIONS();
            frm.btntitle.ButtonText = btnrepocartanker.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btnrepocaraccident_Click_1(object sender, EventArgs e)
        {
            REPORTS.RPCARSOPERATIONS frm = new REPORTS.RPCARSOPERATIONS();
            frm.btntitle.ButtonText = btnrepocaraccident.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btnrepocarfuel_Click_1(object sender, EventArgs e)
        {
            REPORTS.RPCARSOPERATIONS frm = new REPORTS.RPCARSOPERATIONS();
            frm.btntitle.ButtonText = btnrepocarfuel.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void btnrepocarcounter_Click_1(object sender, EventArgs e)
        {
            REPORTS.RPCARSOPERATIONS frm = new REPORTS.RPCARSOPERATIONS();
            frm.btntitle.ButtonText = btnrepocarcounter.Text;
            frm.ShowDialog();
            pncars.Visible = false;

        }

        private void simpleButton32_Click(object sender, EventArgs e)
        {
            FRMBookReciveInternal f = new FRMBookReciveInternal();
            f.ShowDialog();
            pnthatia.Visible = false;
        }

        private void simpleButton36_Click(object sender, EventArgs e)
        {
            CmCar.Position = 0;
        }

        private void simpleButton42_Click(object sender, EventArgs e)
        {
            CmCar.Position -= 1;
        }

        private void simpleButton35_Click(object sender, EventArgs e)
        {
            CmCar.Position += 1;
        }

        private void simpleButton33_Click(object sender, EventArgs e)
        {
            CmCar.Position = DtCar.Rows.Count;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLSCARS rp = new CLS_FRMS.CLSCARS();
                DataTable Dt = new DataTable();
                DS.DataSetMechanisms dss = new DS.DataSetMechanisms();
                REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                Dt = rp.CarsDivisionByCarNo(tbcarnobarcode.Text);
                dss.Tables["CarByCarNo"].Clear();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    dss.Tables["CarByCarNo"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1], Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5],
                        Dt.Rows[i][6], Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11], Dt.Rows[i][12], Dt.Rows[i][13],
                        Dt.Rows[i][17],Dt.Rows[i][18]);
                }
                REPORTS.CarDocument rpt = new REPORTS.CarDocument();

                rpt.Parameters["Date"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                rpt.DataSource = dss;
                rpt.RequestParameters = false;
                frm.documentViewer1.DocumentSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblSystemName_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Guidthatyia frm = new Guidthatyia(this);
            frm.Show();
            frm.WindowState = FormWindowState.Maximized;
            frm.MinimumSize = frm.Size;
            frm.MaximumSize = frm.Size;
          
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Label x = new Label();
            x.Text = "المنتسبين";
            FRMEMPLOYEES FRM = new FRMEMPLOYEES(x);
            FRM.ShowDialog();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            lbcarinterface.Text = btncardivision.Text;
            lbcarinterface.Dock = DockStyle.Right;
            btncarinterface.Dock = DockStyle.Right;

            btncarinterface.Width = 130;
            btncarinterface.BringToFront();
            btncarinterface.Visible = true;
            CarsInterFace.Dock = DockStyle.Fill;
            xtraTabPage13.PageVisible = true;
            xtraTabPage3.PageVisible = true;
            xtraTabPage3.Show();
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            FRMBookReciveInternal f = new FRMBookReciveInternal();
            f.ShowDialog();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            FRMRPEMPEMPLOYEES frm = new FRMRPEMPEMPLOYEES();
            frm.Show();
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            FRMRPCAR f = new FRMRPCAR();
            f.ShowDialog();
        }



        //==============================================================================================================


    }



}       




