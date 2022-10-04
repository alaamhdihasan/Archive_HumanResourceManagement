using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using asprise_imaging_api;
using System.Collections.Generic;
using WIA;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
//using TwainScanning;
using TwainLib;
using System.ComponentModel;
using System.Diagnostics;
using ZXing;
using System.Drawing.Printing;
using ZXing.Common;

namespace MechanismsCD.FRMS
{
    public partial class FRMEMPLOYEES : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string newpath;
        public string pathimage;
        public string nameimage;
      
        string EmpName;
        DataTable Dt_Emp, Dt_AdminOrder, Dt_Variable , Dt_Dispatch;
        CurrencyManager cm;
        CurrencyManager cmAdminOrder, cmVariable, cmDispatch;
        public Label x;
           
        public FRMEMPLOYEES(Label y)
        {
            InitializeComponent();
            // Employeeinterface.Visible = false;
            
            x = y;
        }

        public FRMEMPLOYEES(Label y,string name)
        {
            InitializeComponent();
            // Employeeinterface.Visible = false;          
            EmpName = name;
            x = y;
        }
        private void FRMEMPLOYEES_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Caption = Properties.Settings.Default.UserNameLogin;
                //Label x = new Label();
                //x.Text = "المنتسبين";
                CLS_FRMS.CLSEMPLOYEES EmpRootNode = new CLS_FRMS.CLSEMPLOYEES();
                DataTable DtrootNode = EmpRootNode.Emp_RootNode(Emp_Tr);
                ribbonPage1.Visible = false;
                EmpRootNode.BtnProperties(BtnPersonUi, btnManagement, btnVariablesEmployees, btnDeserveEmployees
                    , btndisputchesEmployees, btnConstractEmployee, btnChildrenEmp, btnZamEmployees, btntanseebemp
                    , btnAttendenceemployees, btnSheftEmployees, btnArcheivesEmployees, btnDoc, btnDeservePressingEmployees, btnDeserveSatisfyingEmployees);

                page1.Show();

                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                    Properties.Settings.Default.PasswordLogin.ToString(), x.Text);
                    
                Permissions.PerThree3(Dt, simpleButton3, simpleButton2, simpleButton1);

                if (simpleButton1.Enabled == true)
                {
                    btnCreateBarcode.Enabled = true;
                    btnPrintBarcode.Enabled = true;
                }

                if (EmpName != null)
                {
                
                    foreach(TreeNode n in Emp_Tr.Nodes)
                    {
                   
                        Emp_Tr.SelectedNode = n;
                        for(int i = 0; i < cmbEmp.Items.Count; i++)
                        {
                            if (cmbEmp.GetItemText(cmbEmp.Items[i]) == EmpName)
                            {
                                cmbEmp.Text = EmpName;
                                goto End;
                                
                            }
                        }
                      
                    }  
                }
                End:;

                Adreleaseby.Items.Clear();
                CLS_FRMS.CLSCONSTENTRY GetDepartments = new CLS_FRMS.CLSCONSTENTRY();
                DataTable Dtdepartment = GetDepartments.GetDataDepartment();
                for (int i = 0; i < Dtdepartment.Rows.Count; i++)
                {
                    Adreleaseby.Items.Add(Dtdepartment.Rows[i][1].ToString());
                }
                    DataTable DtDiv = GetDepartments.GetDivisionData();
                    for (int i = 0; i < DtDiv.Rows.Count; i++)
                    {
                        Adreleaseby.Items.Add(DtDiv.Rows[i][1].ToString());
                    }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); 
        }
}

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadministrationorders_Click(object sender, EventArgs e)
        {

        }

        private void btnemployeeinterface_Click(object sender, EventArgs e)
        {
          

        }
        // ======= This code For Searching In DataGridView Which Point To the EmployeesInfo Table...........=============================
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { 
            //(Dgvempinfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);

            (DgvSearching.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);
            
            if(DgvSearching.Rows.Count==1)
            {
                Dt_Emp = null;
                TreeNodeSearchingtxt.Text = DgvSearching.Rows[0].Cells[5].Value.ToString();
                CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
                DataTable Dt = Getdata.TreeNodeSearching2(TreeNodeSearchingtxt.Text, Dgvempinfo, empseq, empdocnopast,empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername, empdawria
                    , empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork
                    , empoldworkplace, emplivenow, empsing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania
                    , empbirthdate, empbirthplace, emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework
                    , tbl7, tbl8, tbl9, tbl13);
                Dt_Emp = Dt;
                cm = (CurrencyManager)this.BindingContext[Dt_Emp];

            }
            else
            {

            }


            if (emppathimage.Text == "" || emppathimage.Text == null)
            {
                empimage.Image = null;
            }
            else
            {
                empimage.Load(emppathimage.Text);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=================================================================================================================================

        //============ This Code For Clean EveryThing In The Interface of Employeeinfo Table............
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            try { 
            foreach (Control p in tbl7.Controls) { if (p is TextBox || p is ComboBox) { p.DataBindings.Clear(); p.Text = ""; } }
            foreach (Control p2 in tbl8.Controls) { if (p2 is TextBox || p2 is ComboBox) { p2.DataBindings.Clear(); p2.Text = ""; } }
            foreach (Control p3 in tbl9.Controls) { if (p3 is TextBox || p3 is ComboBox) { p3.DataBindings.Clear(); p3.Text = ""; } }
            foreach (Control p4 in tbl13.Controls) { if (p4 is TextBox || p4 is ComboBox || p4 is DateTimePicker) { p4.DataBindings.Clear(); p4.Text = ""; } }
            foreach (Control p5 in tbl12.Controls) { if (p5 is TextBox || p5 is ComboBox || p5 is DateTimePicker) { p5.DataBindings.Clear(); p5.Text = ""; } }
                empimage.DataBindings.Clear();
                empimage.Image = null;
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=================================================================================================================================

        //=========== This code for InsertData to the EmployeeInfo tabel .....................
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة اضبارة جديدة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Emp = null;
                    CLS_FRMS.CLSEMPLOYEES InsertData = new CLS_FRMS.CLSEMPLOYEES();
                    if (empdocnonew.Text == null || empdocnonew.Text == "")
                        empdocnonew.Text = "0";
                    Dt_Emp = InsertData.EmployeeInfoInsertdata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                         , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                         , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                         , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                         , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                         , tbl13, int.Parse(empdocnopast.Text), int.Parse(empdocnonew.Text), emptype.Text, empidentityno.Text, empbloodtype.Text, empemployeesituation.Text, empbeneficiary.Text, empregistername.Text
                     , empdawria.Text, empemployeename.Text, empsurename.Text, empjob.Text, empjobnow.Text, empdivision.Text, empunit.Text, empworkplace.Text
                     , empsn.Text, empchilderncount.Text, empwifetype.Text, empstudy.Text, emplaststudy.Text, emptaghsus.Text, empmaharat.Text, empoldwork.Text
                    , empoldworkplace.Text, emplivenow.Text, empsing.Text, empoldliveplace.Text, empjunsia.Text, empjunsiaplace.Text
                    , empshahada.Text, empshahadaplace.Text, empbutaqatshakan.Text, empmaqtabmua.Text, empwatania.Text, empbirthdate.Text
                    , empbirthplace.Text, emptaghweelno.Text, emptaghweeldate.Text, empbarcode.Text, empmobile1.Text, empmobile2.Text
                    , empdepartment.Text, emppathimage.Text, empnotice.Text, emptypework.Text);
                    cm = (CurrencyManager)this.BindingContext[Dt_Emp];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============ This code Below for Update Data in to the EmployeeInfo table / Using the EmployeesInfoUpdatedata Procedure===================================

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل على هذه الاضبارة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Emp = null;
                    CLS_FRMS.CLSEMPLOYEES UpdatetData = new CLS_FRMS.CLSEMPLOYEES();
                    if (empdocnonew.Text == null || empdocnonew.Text == "")
                        empdocnonew.Text = "0";
                    int p = cm.Position;
                    string name = empemployeename.Text;
                    Dt_Emp = UpdatetData.EmployeeInfoUpdatedata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                    , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                    , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                    , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                    , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                    , tbl13, int.Parse(empdocnopast.Text), int.Parse(empdocnonew.Text), emptype.Text, empidentityno.Text, empbloodtype.Text, empemployeesituation.Text, empbeneficiary.Text, empregistername.Text
                , empdawria.Text, empemployeename.Text, empsurename.Text, empjob.Text, empjobnow.Text, empdivision.Text, empunit.Text, empworkplace.Text
                , empsn.Text, empchilderncount.Text, empwifetype.Text, empstudy.Text, emplaststudy.Text, emptaghsus.Text, empmaharat.Text, empoldwork.Text
               , empoldworkplace.Text, emplivenow.Text, empsing.Text, empoldliveplace.Text, empjunsia.Text, empjunsiaplace.Text
               , empshahada.Text, empshahadaplace.Text, empbutaqatshakan.Text, empmaqtabmua.Text, empwatania.Text, empbirthdate.Text
               , empbirthplace.Text, emptaghweelno.Text, emptaghweeldate.Text, empbarcode.Text, empmobile1.Text, empmobile2.Text
               , empdepartment.Text, emppathimage.Text, empnotice.Text, emptypework.Text, int.Parse(empseq.Text));
                    cm = (CurrencyManager)this.BindingContext[Dt_Emp];

                    cm.Position = p;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //==============================================================================================================================================================
        //===== This code for Delete Data From Employeeinfo / using EmployeeinfoDeleteData Procedure =================================================================
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذه الاضبارة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Emp = null;
                    CLS_FRMS.CLSEMPLOYEES DeleteData = new CLS_FRMS.CLSEMPLOYEES();
                    Dt_Emp = DeleteData.EmployeeInfoDeletedata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                        , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                        , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                        , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                        , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                        , tbl13, int.Parse(empseq.Text));
                    cm = (CurrencyManager)this.BindingContext[Dt_Emp];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=============================================================================================================================================================
        //============= this code below for clean the EmpAdministration interface 
        private void AdbtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة امر اداري جديد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    foreach (Control p in tblOfficerOrder.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.DataBindings.Clear(); } }
                    foreach (Control q in tblOfficerOrder.Controls) { if (q is TextBox) { if ((q as TextBox).ReadOnly != true) { (q as TextBox).Text = ""; } } }
                    foreach (Control q in tblOfficerOrder.Controls) { if (q is ComboBox) { q.Text = ""; } }
                    foreach (Control q in tblOfficerOrder.Controls) { if (q is DateTimePicker) { q.Text = ""; } }

                    AdIDcon.Text = empseq.Text; Adempname.Text = empemployeename.Text;
                    Adregistername.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    AdAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    AdAddingTime.Text = DateTime.Now.ToString("hh:mm tt");
                    Dt_AdminOrder = null;
                    CLS_FRMS.CLSEMPLOYEES InsertData = new CLS_FRMS.CLSEMPLOYEES();
                    Dt_AdminOrder= InsertData.EmpAdinsertData(AdDGV, AdIDsequence, AdIDcon, Adempname, AdBooktitle, AdbookNO, AdBookDate, Adreleaseby, AdImportNo, AdimportDate, Addescription
                        , Adregistername, AdAddingTime, AdAddingDate, pn11, int.Parse(AdIDcon.Text), Adempname.Text, AdBooktitle.Text, AdbookNO.Text, AdBookDate.Text, Adreleaseby.Text
                        , Addescription.Text, AdImportNo.Text, AdimportDate.Text, Adregistername.Text, AdAddingTime.Text, AdAddingDate.Text);
                    cmAdminOrder = (CurrencyManager)this.BindingContext[Dt_AdminOrder];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=============================================================================================================================================================
        //================== This codes Below for insert data into EmpAdministrationOrders table / Using EmpAdministrationOrderInsertData Procedure
        private void AdbtnAdd_Click(object sender, EventArgs e)
        {
            try { 
            if (Properties.Settings.Default.UserNameLogin.ToString() == Adregistername.Text)
            {
                DialogResult d = MessageBox.Show("هل تريد حفظ التعديل؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(d == DialogResult.Yes)
                {
                        Dt_AdminOrder = null;
                    CLS_FRMS.CLSEMPLOYEES UpdateData = new CLS_FRMS.CLSEMPLOYEES();
                    Dt_AdminOrder= UpdateData.EmpAdUpdateData(AdDGV, AdIDsequence, AdIDcon, Adempname, AdBooktitle, AdbookNO, AdBookDate, Adreleaseby, AdImportNo, AdimportDate, Addescription
                        , Adregistername, AdAddingTime, AdAddingDate, pn11, int.Parse(AdIDcon.Text), Adempname.Text, AdBooktitle.Text, AdbookNO.Text, AdBookDate.Text, Adreleaseby.Text
                        , Addescription.Text, AdImportNo.Text, AdimportDate.Text, Adregistername.Text, AdAddingTime.Text, AdAddingDate.Text, int.Parse(AdIDsequence.Text));
                        cmAdminOrder = (CurrencyManager)this.BindingContext[Dt_AdminOrder];
                    }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("هذا القيد انشأ من قبل مستخدم آخر ، لا تستطيع التحفظ عليه", "خطأ حفظ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }
        //============================================================================================================================================================
        //============== this codes below for Update data to the EmpAdministrationOrder table / Using EmpAdministrationOrderUpdateData Procedure
        private void AdbtnSave_Click(object sender, EventArgs e)
        {
            try { 
         
           DialogResult d = MessageBox.Show("هل تريد التعديل على القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Adregistername.Text =Adregistername.Text+ " + " +  Properties.Settings.Default.UserNameLogin.ToString();
                AdAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                AdAddingTime.Text = DateTime.Now.ToString("hh:mm tt");
                    Dt_AdminOrder = null;
                CLS_FRMS.CLSEMPLOYEES UpdateData = new CLS_FRMS.CLSEMPLOYEES();
                Dt_AdminOrder= UpdateData.EmpAdUpdateData(AdDGV, AdIDsequence, AdIDcon, Adempname, AdBooktitle, AdbookNO, AdBookDate, Adreleaseby, AdImportNo, AdimportDate, Addescription
                    , Adregistername, AdAddingTime, AdAddingDate, pn11, int.Parse(AdIDcon.Text), Adempname.Text, AdBooktitle.Text, AdbookNO.Text, AdBookDate.Text, Adreleaseby.Text
                    , Addescription.Text, AdImportNo.Text, AdimportDate.Text, Adregistername.Text, AdAddingTime.Text, AdAddingDate.Text, int.Parse(AdIDsequence.Text));
                    cmAdminOrder = (CurrencyManager)this.BindingContext[Dt_AdminOrder];
                }
            else
            {

            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //===================================================================================================================================================
        //=========== This codes below for Delete Data from EmpAdministrationOrder table / Using EmpAdministrationOrderDeleteData Procedure
        private void AdbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذا القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_AdminOrder = null;
                    CLS_FRMS.CLSEMPLOYEES DeletData = new CLS_FRMS.CLSEMPLOYEES();
                    Dt_AdminOrder =DeletData.EmpAdDeleteData(AdDGV, AdIDsequence, AdIDcon, Adempname, AdBooktitle, AdbookNO, AdBookDate, Adreleaseby, AdImportNo, AdimportDate, Addescription
                        , Adregistername, AdAddingTime, AdAddingDate, pn11, int.Parse(AdIDsequence.Text));
                    cmAdminOrder = (CurrencyManager)this.BindingContext[Dt_AdminOrder];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=====================================================================================================================================
        //[==== This Cocdes Below For Running The Scanner / Scan image for Employees========]
        private void scannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            var item = TwainOperations.ScanImages();
            foreach (var Itm in item)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfEmployees + nameimage;
                empimage.Load(Itm);
                empimage.Image.Save(newpath);
                emppathimage.Text = newpath;

            }
            Dt_Emp = null;
            CLS_FRMS.CLSEMPLOYEES UpdatetData = new CLS_FRMS.CLSEMPLOYEES();
            if (empdocnonew.Text == null || empdocnonew.Text == "")
                empdocnonew.Text = "0";
            int p = cm.Position;
            Dt_Emp = UpdatetData.EmployeeInfoUpdatedata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                , tbl13, int.Parse(empdocnopast.Text), int.Parse(empdocnonew.Text), emptype.Text, empidentityno.Text, empbloodtype.Text, empemployeesituation.Text, empbeneficiary.Text, empregistername.Text
            , empdawria.Text, empemployeename.Text, empsurename.Text, empjob.Text, empjobnow.Text, empdivision.Text, empunit.Text, empworkplace.Text
            , empsn.Text, empchilderncount.Text, empwifetype.Text, empstudy.Text, emplaststudy.Text, emptaghsus.Text, empmaharat.Text, empoldwork.Text
           , empoldworkplace.Text, emplivenow.Text, empsing.Text, empoldliveplace.Text, empjunsia.Text, empjunsiaplace.Text
           , empshahada.Text, empshahadaplace.Text, empbutaqatshakan.Text, empmaqtabmua.Text, empwatania.Text, empbirthdate.Text
           , empbirthplace.Text, emptaghweelno.Text, emptaghweeldate.Text, empbarcode.Text, empmobile1.Text, empmobile2.Text
           , empdepartment.Text, emppathimage.Text, empnotice.Text, emptypework.Text, int.Parse(empseq.Text));
            cm = (CurrencyManager)this.BindingContext[Dt_Emp];

            cm.Position = p;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=============================================================================================================================
        //========= This Codes Below for Calling Function OF Getting Data of Empvariable table 

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }
        //===================================================================================================================================
        //================ This Codes Belwo for Calling Function OF Update Data To the Empvariable Table
        private void btnvarUpdate_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult d = MessageBox.Show("هل تريد تعديل  البيانات على هذا القيد", "تعديل  بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (d == DialogResult.Yes)
            {

                    DataTable dtv;
                    Dt_Variable = null;
                if (Varcount.Text == null || Varcount.Text == "")
                {
                    DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                    Varcount.Text = "0";
                    endDate = endDate.AddDays(-60000);
                    DateTime end = endDate;
                    this.VarComming.Text = end.ToShortDateString();
                    Varregistername.Text = Varregistername.Text + " + " + Properties.Settings.Default.UserNameLogin.ToString();

                    CLS_FRMS.CLSEMPLOYEES VarUpdateData = new CLS_FRMS.CLSEMPLOYEES();
                    dtv=VarUpdateData.EmpVarUpdateData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                        , VarAddingTime, VarAddingDate,VarTypeAddbtn,VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                        Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                        , int.Parse(VarIDseq.Text), Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                }
                else
                {
                    Varregistername.Text = Varregistername.Text + " + " + Properties.Settings.Default.UserNameLogin.ToString();

                    DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                    Int64 addedDays = Convert.ToInt64(Varcount.Text);
                    endDate = endDate.AddDays(addedDays);
                    DateTime end = endDate;
                    this.VarComming.Text = end.ToShortDateString();

                    CLS_FRMS.CLSEMPLOYEES VarUpdateData = new CLS_FRMS.CLSEMPLOYEES();
                        dtv= VarUpdateData.EmpVarUpdateData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                        , VarAddingTime, VarAddingDate,VarTypeAddbtn,VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                        Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                        , int.Parse(VarIDseq.Text), Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                }
                    Dt_Variable = dtv;
                    cmVariable = (CurrencyManager)this.BindingContext[Dt_Variable];
                }
            else{

            }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=======================================================================================================================
        //============== The codes below for Calling Function of Insert Data to the Empvariable tabel 
        private void btnvarAdd_Click(object sender, EventArgs e)
        {
            try
            {


                if (Properties.Settings.Default.UserNameLogin.ToString() == Varregistername.Text)
            {
                DialogResult d = MessageBox.Show("هل تريد حفظ البيانات على هذا القيد", "حفظ بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                        DataTable dtv;
                        Dt_Variable = null;
                    if (Varcount.Text == null || Varcount.Text == "")
                    {
                        DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                        Varcount.Text = "0";
                        endDate = endDate.AddDays(-60000);
                        DateTime end = endDate;
                        this.VarComming.Text = end.ToShortDateString();

                        CLS_FRMS.CLSEMPLOYEES VarUpdateData = new CLS_FRMS.CLSEMPLOYEES();
                        dtv=VarUpdateData.EmpVarUpdateData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                       , VarAddingTime, VarAddingDate, VarTypeAddbtn, VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                       Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                       , int.Parse(VarIDseq.Text), Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                    }
                    else
                    {
                        DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                        Int64 addedDays = Convert.ToInt64(Varcount.Text);
                        endDate = endDate.AddDays(addedDays);
                        DateTime end = endDate;
                        this.VarComming.Text = end.ToShortDateString();

                        if (Vartype.Text == "ارسال")
                        {
                            CLS_FRMS.CLSEMPLOYEES varemp = new CLS_FRMS.CLSEMPLOYEES();
                            varemp.EmpDesSatisfyingUpdatetDataAuto(int.Parse(VarIDcon.Text), Convert.ToDateTime(VarDate.Text), int.Parse(Varcount.Text));

                        }
                        if(Vartype2.Text == "طارئة")
                        {
                            CLS_FRMS.CLSEMPLOYEES varemp = new CLS_FRMS.CLSEMPLOYEES();
                            varemp.EmpDesPressingUpdatetDataAuto(int.Parse(VarIDcon.Text), Convert.ToDateTime(VarDate.Text), int.Parse(Varcount.Text));
                        }


                        CLS_FRMS.CLSEMPLOYEES VarUpdateData = new CLS_FRMS.CLSEMPLOYEES();
                        dtv=VarUpdateData.EmpVarUpdateData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                       , VarAddingTime, VarAddingDate, VarTypeAddbtn, VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                       Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                       , int.Parse(VarIDseq.Text), Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                    }
                        Dt_Variable = dtv;
                        cmVariable = (CurrencyManager)this.BindingContext[Dt_Variable];
                    }
            }
            else
            {
                MessageBox.Show("هذا القيد انشأ من قبل مستخدم اخر لا يمكنك التعديل عليه", "حفظ بيانات ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private static DateTime? GetDateSample2(DateTime? dateSample2)
        {
            return dateSample2;
        }

        //========================================================================================================================
        //============== The codes below for Calling Function of Delete Data From the Empvariable tabel 
        private void btnvardelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذا القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES VarDeleteData = new CLS_FRMS.CLSEMPLOYEES();

                    VarDeleteData.EmpVararchDeletedata(int.Parse(VarIDseq.Text));
                    DataTable dtv;
                    Dt_Variable = null;
                    dtv=VarDeleteData.EmpVarDeleteData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                        , VarAddingTime, VarAddingDate, VarTypeAddbtn, VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), int.Parse(VarIDseq.Text));
                    Dt_Variable = dtv;
                    cmVariable = (CurrencyManager)this.BindingContext[Dt_Variable];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=========================================================================================================================
        private void btnvarclear_Click(object sender, EventArgs e)
        {
            try {
                DialogResult d = MessageBox.Show("هل تريد اضافة اجازة جديدة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    VarIDcon.Text = empseq.Text;
                    Varempname.Text = empemployeename.Text;
                    Varregistername.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    VarAddingTime.Text = DateTime.Now.ToString("hh:mm tt");
                    VarAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    Vartype.Text = ""; Vartype2.Text = ""; Varcount.Clear(); VarNotice.Clear();
                    VarDate.Text = DateTime.Now.ToString("hh:mm tt");

                    Dt_Variable = null;
                    DataTable dtv;
                    if (Varcount.Text == null || Varcount.Text == "")
                    {
                        DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                        Varcount.Text = "0";
                        endDate = endDate.AddDays(-60000);
                        DateTime end = endDate;
                        this.VarComming.Text = end.ToShortDateString();

                        CLS_FRMS.CLSEMPLOYEES VarInsertData = new CLS_FRMS.CLSEMPLOYEES();
                        dtv=VarInsertData.EmpVarInsertData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                        , VarAddingTime, VarAddingDate, VarTypeAddbtn, VarTypeNotAddbtn
                        , Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                        Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                        , Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                    }
                    else
                    {
                        DateTime endDate = Convert.ToDateTime(this.VarDate.Text);
                        Int64 addedDays = Convert.ToInt64(Varcount.Text);
                        endDate = endDate.AddDays(addedDays);
                        DateTime end = endDate;
                        this.VarComming.Text = end.ToShortDateString();

                        CLS_FRMS.CLSEMPLOYEES VarInsertData = new CLS_FRMS.CLSEMPLOYEES();
                        dtv=VarInsertData.EmpVarInsertData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                            , VarAddingTime, VarAddingDate, VarTypeAddbtn, VarTypeNotAddbtn, Varpn1, int.Parse(VarIDcon.Text), Varempname.Text, Vartype.Text, double.Parse(Varcount.Text),
                            Vartype2.Text, VarDate.Text, VarComming.Text, VarNotice.Text, Varregistername.Text, VarAddingTime.Text, VarAddingDate.Text
                            , Convert.ToBoolean(VarTypeAddbtn.EditValue), Convert.ToBoolean(VarTypeNotAddbtn.EditValue));
                    }
                    Dt_Variable = dtv;
                    cmVariable = (CurrencyManager)this.BindingContext[Dt_Variable];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=========================================================================================================================
        //============= this codes below for Calling function of Getting Data from Empdeserve table 
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
           
        }
        //=========================================================================================================================
        //============= This codes below for Clear textboxes of EmpDeserve Form
        private void DesbtnClear_Click(object sender, EventArgs e)
        {
            try { 
            foreach (Control p in tbl19.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }
            foreach (Control p in tbl18.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }

            DesIDcon.Text = empseq.Text;
            Desempname.Text = empemployeename.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //=============This codes Below For Call InsertData Function From the EmpDeserve Table
        private void DesbtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة سنة جديدة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES InsertDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    InsertDataDeserve.EmpDesInsertData(Dgvdeserve, DesYear, DesIDseq, DesIDcon, Desempname, Desm1, Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9
                        , Desm10, Desm11, Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20, Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
                        Pndeserve, txtRegisterName, txtAddingTime, txtAddingDate, txtDesmNotic
                        , int.Parse(DesIDcon.Text), Desempname.Text, DesYear.Text, Desm1.Text, Desm2.Text, Desm3.Text, Desm4.Text, Desm5.Text, Desm6.Text
                        , Desm7.Text, Desm8.Text, Desm9.Text, Desm10.Text, Desm11.Text, Desm12.Text, Desm13.Text, Desm14.Text, Desm15.Text, Desm16.Text
                        , Desm17.Text, Desm18.Text, Desm19.Text, Desm20.Text, Desm21.Text, Desm22.Text, Desm23.Text, Desm24.Text, Desm25.Text, Desm26.Text, Desm27.Text, Desm28.Text, Desm29.Text, Desm30.Text, txtDesmNotic.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= This Codes below for Calling Function of UpdateData to the EmpDeserve Table 
        private void DesbtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل على هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES UpdateDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    UpdateDataDeserve.EmpDesUpdatetData(Dgvdeserve, DesYear, DesIDseq, DesIDcon, Desempname, Desm1, Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9
                        , Desm10, Desm11, Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20, Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
                        Pndeserve, txtRegisterName, txtAddingTime, txtAddingDate, txtDesmNotic
                        , int.Parse(DesIDcon.Text), Desempname.Text, DesYear.Text, Desm1.Text, Desm2.Text, Desm3.Text, Desm4.Text, Desm5.Text, Desm6.Text
                        , Desm7.Text, Desm8.Text, Desm9.Text, Desm10.Text, Desm11.Text, Desm12.Text, Desm13.Text, Desm14.Text, Desm15.Text, Desm16.Text
                        , Desm17.Text, Desm18.Text, Desm19.Text, Desm20.Text, Desm21.Text, Desm22.Text, Desm23.Text, Desm24.Text, Desm25.Text, Desm26.Text, Desm27.Text, Desm28.Text, Desm29.Text, Desm30.Text, txtDesmNotic.Text,
                        int.Parse(DesIDseq.Text));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= this codes below for Calling Function of Deleting Data From EmpDeserve table 
        private void DesbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES DeleteDatadeserve = new CLS_FRMS.CLSEMPLOYEES();
                    DeleteDatadeserve.EmpDesDeleteData(Dgvdeserve, DesYear, DesIDseq, DesIDcon, Desempname, Desm1, Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9
                        , Desm10, Desm11, Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20, Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
                        Pndeserve, int.Parse(DesIDseq.Text), txtRegisterName, txtAddingTime, txtAddingDate, txtDesmNotic);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= This code for Calling Function of Getdata of the Disputches
        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
           
        }
        //=========================================================================================================================
        //============= This codes Below for Clear form of disputches 
        private void DisbtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control p in tbl20.Controls)
                {
                    if (p is TextBox || p is ComboBox || p is CheckBox || p is DateTimePicker)
                    {
                        p.Text = "";
                        DisIDcon.Text = empseq.Text;
                        DisEmpname.Text = empemployeename.Text;
                        DisRegistername.Text = Properties.Settings.Default.UserNameLogin.ToString();
                        DisAddingTime.Text = DateTime.Now.ToString("hh:mm tt");
                        DisAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                        DisIDmove.Text = "0";
                    }
                }
                txtNotice.Text = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= This Codes Below for Calling Function of InsertData to the Disputches Table
        private void DisbtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حفظ هذا الايفاد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Dispatch = null;
                    CLS_FRMS.CLSEMPLOYEES InsertData = new CLS_FRMS.CLSEMPLOYEES();
                    DataTable dtd=InsertData.DisInsertData(DisDgv, DisIDseq, DisIDcon, DisEmpname, DisCarNo, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime
                        , DisCommingDate, DisDistenation, DisBeneficiary, DisHourcount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate
                        , DisBookNO, DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate,txtNotice, DisIDmove, DisComp, Dispn1,
                        int.Parse(DisIDcon.Text)
                        , DisEmpname.Text, DisCarNo.Text, DisCartype.Text, DisGoingTime.Text, DisGoingDate.Text, DisCommingTime.Text, DisCommingDate.Text
                        , DisDistenation.Text, DisBeneficiary.Text, DisHourcount.Text, DisNightCount.Text, DisRayia.Text, DisWorkTime.Text, DisTaghweelNO.Text
                        , DisTaghweelDate.Text, DisFinishing.Text, DisBookNO.Text, DisBookDate.Text, DisRegistername.Text, DisAddingTime.Text
                        , DisAddingDate.Text, int.Parse(DisIDmove.Text), DisComp.Checked, txtNotice.Text);
                    Dt_Dispatch = dtd;
                    cmDispatch = (CurrencyManager)this.BindingContext[Dt_Dispatch];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= this code for calling function of Updatedata to the Disputches tabel
        private void DisbtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل على هذا الايفاد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Dispatch = null;
                    CLS_FRMS.CLSEMPLOYEES UpdateData = new CLS_FRMS.CLSEMPLOYEES();
                    DataTable dtd= UpdateData.DisUpdateData(DisDgv, DisIDseq, DisIDcon, DisEmpname, DisCarNo, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime
                        , DisCommingDate, DisDistenation, DisBeneficiary, DisHourcount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate
                        , DisBookNO, DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate,txtNotice, DisIDmove, DisComp, Dispn1, int.Parse(DisIDcon.Text)
                        , DisEmpname.Text, DisCarNo.Text, DisCartype.Text, DisGoingTime.Text, DisGoingDate.Value, DisCommingTime.Text, DisCommingDate.Value
                        , DisDistenation.Text, DisBeneficiary.Text, DisHourcount.Text, DisNightCount.Text, DisRayia.Text, DisWorkTime.Text, DisTaghweelNO.Text
                        , DisTaghweelDate.Value, DisFinishing.Text, DisBookNO.Text, DisBookDate.Value, DisRegistername.Text, DisAddingTime.Text
                        , Convert.ToDateTime(DisAddingDate.Text), int.Parse(DisIDmove.Text), int.Parse(DisIDseq.Text), DisComp.Checked,txtNotice.Text);
                    Dt_Dispatch = dtd;
                    cmDispatch = (CurrencyManager)this.BindingContext[Dt_Dispatch];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= this codes below for Deleting Data from Disputches Table 
        private void DisbtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذا الايفاد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    Dt_Dispatch = null;
                    CLS_FRMS.CLSEMPLOYEES DeleteData = new CLS_FRMS.CLSEMPLOYEES();
                    DataTable dtd= DeleteData.DisDeleteData(DisDgv, DisIDseq, DisIDcon, DisEmpname, DisCarNo, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime
                        , DisCommingDate, DisDistenation, DisBeneficiary, DisHourcount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate
                        , DisBookNO, DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate, DisIDmove, DisComp, Dispn1,txtNotice, int.Parse(DisIDseq.Text));
                    Dt_Dispatch = dtd;
                    cmDispatch = (CurrencyManager)this.BindingContext[Dt_Dispatch];
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= Open Form Of EmployeeConstract --------
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
           
        }
        //=========================================================================================================================
        //============= this button for clear data from EmployeeConstract Form Or Zamaiant form-------
        private void btntbclear_Click(object sender, EventArgs e)
        {
            try { 
            string NamePage = page6.Text;
            switch (NamePage)
            {
                case "العقود":
                    foreach (Control p in tbl21.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.Text = ""; p.DataBindings.Clear(); } }
                    tb2.Text = empseq.Text;
                    tb3.Text = empemployeename.Text;
                    tb12.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb13.Text = DateTime.Now.ToShortTimeString();
                    tb14.Text = DateTime.Now.ToShortDateString();
                    break;
                case "الزمنيات":
                    foreach (Control p in tbl21.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.Text = ""; p.DataBindings.Clear(); } }
                    tb2.Text = empseq.Text;
                    tb3.Text = empemployeename.Text;
                    tb12.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb13.Text = DateTime.Now.ToShortTimeString();
                    tb14.Text = DateTime.Now.ToShortDateString();
                    break;

                case "الوجبات":
                    foreach (Control p in tbl21.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.Text = ""; p.DataBindings.Clear(); } }
                    tb2.Text = empseq.Text;
                    tb3.Text = empemployeename.Text;
                    tb12.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb13.Text = DateTime.Now.ToShortTimeString();
                    tb14.Text = DateTime.Now.ToShortDateString();

                    break;
                case "تنسيب و":
                    foreach (Control p in tbl21.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.Text = ""; p.DataBindings.Clear(); } }
                    tb2.Text = empseq.Text;
                    tb3.Text = empemployeename.Text;
                    tb12.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb13.Text = DateTime.Now.ToShortTimeString();
                    tb14.Text = DateTime.Now.ToShortDateString();

                    break;
                case "معلومات الاولاد":
                    foreach (Control p in tbl21.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { p.Text = ""; p.DataBindings.Clear(); } }
                    tb2.Text = empseq.Text;
                    tb3.Text = empemployeename.Text;
                    tb12.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb13.Text = DateTime.Now.ToShortTimeString();
                    tb14.Text = DateTime.Now.ToShortDateString();

                    break;



            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= this button For Calling Function Of InsertData to the Empconstract Table
        private void btntbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة هذا القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    string Namepage = page6.Text;
                    switch (Namepage)
                    {
                        case "العقود":
                            tb7.Value = tb6.Value.AddDays((double.Parse(tb5.Text)) * 30);

                            CLS_FRMS.CLSEMPLOYEES insertdata = new CLS_FRMS.CLSEMPLOYEES();
                            insertdata.EmpConsInsertData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, double.Parse(tb5.Text), tb6.Value, tb7.Value
                    , tb8.Text, tb9.Value, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text);
                            break;
                        case "الزمنيات":
                            CLS_FRMS.CLSEMPLOYEES insertdata1 = new CLS_FRMS.CLSEMPLOYEES();
                            insertdata1.EmpZamaniatInsertData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb6.Value, double.Parse(tb4.Text), tb11.Text, tb8.Text
                    , tb12.Text, tb13.Text, tb14.Text);

                            break;
                        case "الوجبات":
                            CLS_FRMS.CLSEMPLOYEES insertdata2 = new CLS_FRMS.CLSEMPLOYEES();
                            insertdata2.EmpWorktimeInsertData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, tb6.Value, tb7.Value, tb11.Text
                    , tb12.Text, tb13.Text, tb14.Text);

                            break;
                        case "تنسيب و":
                            tb7.Value = tb6.Value.AddDays((double.Parse(tb5.Text)) * 30);
                            CLS_FRMS.CLSEMPLOYEES insertdata3 = new CLS_FRMS.CLSEMPLOYEES();
                            insertdata3.EmpTanseebinsertData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, double.Parse(tb5.Text), tb6.Value, tb7.Value,
                    tb8.Text, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text);

                            break;
                        case "معلومات الاولاد":

                            CLS_FRMS.CLSEMPLOYEES insertdata4 = new CLS_FRMS.CLSEMPLOYEES();
                            insertdata4.EmpChildrenInsertData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, tb5.Text, tb6.Value,
                    tb8.Text, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text);

                            break;




                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= This Codes below For Calling Function Of UpdateData to the EmpConstract Table
        private void btntbupdate_Click(object sender, EventArgs e)
        {
            try {
                DialogResult d = MessageBox.Show("هل تريد التعديل على القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    string Namepage = page6.Text;
                    switch (Namepage)
                    {
                        case "العقود":

                            tb7.Value = tb6.Value.AddDays((double.Parse(tb5.Text)) * 30);
                            CLS_FRMS.CLSEMPLOYEES UpdateData = new CLS_FRMS.CLSEMPLOYEES();
                            UpdateData.EmpConsUpdateData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, double.Parse(tb5.Text), tb6.Value, tb7.Value
                    , tb8.Text, tb9.Value, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text, int.Parse(tb1.Text));
                            break;
                        case "الزمنيات":
                            CLS_FRMS.CLSEMPLOYEES UpdateData1 = new CLS_FRMS.CLSEMPLOYEES();
                            UpdateData1.EmpZamaniatUpdateData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb6.Value, double.Parse(tb4.Text), tb11.Text, tb8.Text
                    , tb12.Text, tb13.Text, tb14.Text, int.Parse(tb1.Text));

                            break;
                        case "الوجبات":
                            CLS_FRMS.CLSEMPLOYEES UpdateData2 = new CLS_FRMS.CLSEMPLOYEES();
                            UpdateData2.EmpWorktimeUpdateData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, tb6.Value, tb7.Value, tb11.Text
                    , tb12.Text, tb13.Text, tb14.Text, int.Parse(tb1.Text));

                            break;

                        case "تنسيب و":
                            tb7.Value = tb6.Value.AddDays((double.Parse(tb5.Text)) * 30);
                            CLS_FRMS.CLSEMPLOYEES UpdateData3 = new CLS_FRMS.CLSEMPLOYEES();
                            UpdateData3.EmpTanseebUpdatetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, double.Parse(tb5.Text), tb6.Value, tb7.Value,
                    tb8.Text, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text, int.Parse(tb1.Text));

                            break;
                        case "معلومات الاولاد":

                            CLS_FRMS.CLSEMPLOYEES UpdateData4 = new CLS_FRMS.CLSEMPLOYEES();
                            UpdateData4.EmpChildrenUpdateData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb2.Text), tb3.Text, tb4.Text, tb5.Text, tb6.Value,
                    tb8.Text, tb10.Text, tb11.Text, tb12.Text, tb13.Text, tb14.Text, int.Parse(tb1.Text));

                            break;

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
        //============= This Codes For Calling Function to Delete Data From EmpConstract tabel
        private void btntbdelete_Click(object sender, EventArgs e)
        {
            try {
                DialogResult d = MessageBox.Show("هل تريد حذف هذا القيد", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    string Namepage = page6.Text;
                    switch (Namepage)
                    {
                        case "العقود":
                            CLS_FRMS.CLSEMPLOYEES DeleteData = new CLS_FRMS.CLSEMPLOYEES();
                            DeleteData.EmpConsDeleteData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb1.Text));

                            break;
                        case "الزمنيات":
                            CLS_FRMS.CLSEMPLOYEES DeleteData1 = new CLS_FRMS.CLSEMPLOYEES();
                            DeleteData1.EmpZamaniatDeleteData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb1.Text));

                            break;
                        case "الوجبات":
                            CLS_FRMS.CLSEMPLOYEES DeleteData2 = new CLS_FRMS.CLSEMPLOYEES();
                            DeleteData2.EmpWorktimeDeleteData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb1.Text));

                            break;
                        case "تنسيب و":

                            CLS_FRMS.CLSEMPLOYEES DeleteData3 = new CLS_FRMS.CLSEMPLOYEES();
                            DeleteData3.EmpTanseebDeleteData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb1.Text));

                            break;
                        case "معلومات الاولاد":

                            CLS_FRMS.CLSEMPLOYEES DeleteData4 = new CLS_FRMS.CLSEMPLOYEES();
                            DeleteData4.EmpChildrenDeleteData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
                    , tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd
                    , btntbupdate, btntbdelete, tbsearching, int.Parse(tb1.Text));

                            break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=========================================================================================================================
       

        private void pnpath_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            if (archtb5.Text == "" || archtb5.Text == null)
                pbimage.Image = null;
            else pbimage.Load(archtb5.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void emppathimage_TextChanged(object sender, EventArgs e)
        {
            try { 
            // to display the image in the empimage box..
            if (emppathimage.Text == "" || emppathimage.Text == null)
            {
                empimage.Image = null;
            }
            else
            {
                empimage.Load(emppathimage.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //=======================================================================
        //==== this button for run scanner and scan imaging to the archive of employees 
     
        //=================================================================================
        // ===== this code below ( change text of archtb5 textbox) to load an image to the pbimage picturebox
        private void archtb5_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (archtb5.Text =="" || archtb5.Text == null) { pbimage.Image = null; }
            else
            {
                string file_type = Path.GetExtension(archtb5.Text);
                if(file_type == ".jpg" || file_type == ".bmp" || file_type == ".png")
                     pbimage.Load(archtb5.Text);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnPersonUi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            page1.Show();
        }

        private void btnManagement_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES GetdataAd = new CLS_FRMS.CLSEMPLOYEES();
            DataTable DtAd = GetdataAd.EmpAdministrationOrders(AdDGV, AdIDsequence, AdIDcon, Adempname, AdBooktitle, AdbookNO, AdBookDate, Adreleaseby, AdImportNo, AdimportDate
                , Addescription, Adregistername, AdAddingTime, AdAddingDate, pn11, Convert.ToInt32(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "الاوامر الادارية");

            Permissions.PerThree3(Dt, AdbtnAdd, AdbtnSave, AdbtnDelete);
                Dt_AdminOrder = null;
                Dt_AdminOrder = DtAd;
                cmAdminOrder = (CurrencyManager)this.BindingContext[Dt_AdminOrder];
                page2.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnVariablesEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Dt_Variable = null;
                CLS_FRMS.CLSEMPLOYEES VarGettingData = new CLS_FRMS.CLSEMPLOYEES();
                DataTable dtv= VarGettingData.EmpVarGettingData(Dgvvar, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, VarComming, VarNotice, Varregistername
                    , VarAddingTime, VarAddingDate, Varpn1, int.Parse(empseq.Text), VarTypeAddbtn, VarTypeNotAddbtn);
                Dt_Variable = dtv;
                cmVariable = (CurrencyManager)this.BindingContext[Dt_Variable];

                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                    Properties.Settings.Default.PasswordLogin.ToString(), "المتغرات");

                Permissions.PerThree3(Dt, btnvarAdd, btnvarUpdate, btnvardelete);


                page3.Show();
                if (VarIDseq.Text != null && VarIDseq.Text != "")
                {
                    DataTable dt1 = VarGettingData.EmpVararchSelectdata(int.Parse(VarIDseq.Text));
                    lstbVarArch.Items.Clear();
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        lstbVarArch.Items.Add(dt1.Rows[i][4]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } 
        }

        private void btnDeserveEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES GettingData = new CLS_FRMS.CLSEMPLOYEES();
            GettingData.EmpDesGettingData(Dgvdeserve, DesYear, DesIDseq, DesIDcon, Desempname, Desm1, Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
                , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20, Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
                Pndeserve, int.Parse(empseq.Text), txtRegisterName, txtAddingTime, txtAddingDate, txtDesmNotic);

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "الاستحقاقات");

            Permissions.PerThree3(Dt, DesbtnAdd, DesbtnUpdate, DesbtnDelete);
            page4.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btndisputchesEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES GetDataDis = new CLS_FRMS.CLSEMPLOYEES();
                Dt_Dispatch = null;
            DataTable dtd= GetDataDis.DisGettingData(DisDgv, DisIDseq, DisIDcon, DisEmpname, DisCarNo, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime, DisCommingDate
                , DisDistenation, DisBeneficiary, DisHourcount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate, DisBookNO, DisBookDate
                , DisFinishing, DisRegistername, DisAddingTime, DisAddingDate, DisIDmove, DisComp, Dispn1,txtNotice, int.Parse(empseq.Text));
                Dt_Dispatch = dtd;
                cmDispatch = (CurrencyManager)this.BindingContext[Dt_Dispatch];
                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "الايفادات");

            Permissions.PerThree3(Dt, DisbtnAdd, DisbtnSave, DisbtnDelete);
            page5.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnConstractEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "العقود";
            CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
            Getdata.EmpConsGettingData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "العقود");

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnChildrenEmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "معلومات الاولاد";
            CLS_FRMS.CLSEMPLOYEES EmpChildrenGettingData = new CLS_FRMS.CLSEMPLOYEES();
            EmpChildrenGettingData.EmpChildrenGetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "بيانات الاولاد");

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnZamEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "الزمنيات";
            CLS_FRMS.CLSEMPLOYEES ZamGettingData = new CLS_FRMS.CLSEMPLOYEES();
            ZamGettingData.EmpZamaniatGetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));


            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "الزمنيات");

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btntanseebemp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "تنسيب و";
            CLS_FRMS.CLSEMPLOYEES EmpTanseebGettingData = new CLS_FRMS.CLSEMPLOYEES();
            EmpTanseebGettingData.EmpTanseebGetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "التنسيب والاستضافة");

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAttendenceemployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "الحضور والانصراف";
            CLS_FRMS.CLSEMPLOYEES EmpAttendGettingData = new CLS_FRMS.CLSEMPLOYEES();
            EmpAttendGettingData.EmpAttendenceGetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), x.Text);

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSheftEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            page6.Text = "الوجبات";
            CLS_FRMS.CLSEMPLOYEES WorkTimeGettingData = new CLS_FRMS.CLSEMPLOYEES();
            WorkTimeGettingData.EmpWorktimeGetData(tbdgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbl21, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btntbclear, btntbAdd, btntbupdate, btntbdelete, tbsearching, int.Parse(empseq.Text));

            CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), "وجبات العمل");

            Permissions.PerThree3(Dt, btntbAdd, btntbupdate, btntbdelete);

            page6.Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnArcheivesEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try {

                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                    Properties.Settings.Default.PasswordLogin.ToString(), "ارشيف المنتسبين");

                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                    مسحضوئيToolStripMenuItem.Enabled = false;
                else مسحضوئيToolStripMenuItem.Enabled = true;
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                    حذفToolStripMenuItem.Enabled = false;
                else حذفToolStripMenuItem.Enabled = true;


                page7.Show();
                CLS_FRMS.CLSEMPLOYEES emparchGettingdata = new CLS_FRMS.CLSEMPLOYEES();
                emparchGettingdata.EmpArchSelect(int.Parse(empseq.Text), Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Lsv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try { 
            if (Lsv.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = Lsv.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = Lsv.Items[intselectedindex].Text;

                CLS_FRMS.CLSEMPLOYEES GetData = new CLS_FRMS.CLSEMPLOYEES();
                DataTable Dt = GetData.EmployeesArchpathimage(text, Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Lsv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { 
            if (Lsv.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = Lsv.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = Lsv.Items[intselectedindex].Text;
                
                System.Diagnostics.Process.Start(text);

                CLS_FRMS.CLSEMPLOYEES GetData = new CLS_FRMS.CLSEMPLOYEES();
                DataTable Dt = GetData.EmployeesArchpathimage(archtb5.Text, Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=================================================================================================
        /// <summary>
        /// This Function Below For Scanning Image one by one.....
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void فرديToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES insertData = new CLS_FRMS.CLSEMPLOYEES();

            var item = TwainOperations.ScanImages();
            foreach (var Itm in item)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfEmployees + nameimage;
                imageArchieve.Load(Itm);
                imageArchieve.Image.Save(newpath);
                archtb5.Text = newpath;

                archtb2.Text = empseq.Text;
                archtb3.Text = empdocnopast.Text;
                archtb4.Text = empemployeename.Text;
                archtb6.Text = Properties.Settings.Default.UserNameLogin.ToString();
                archtb7.Text = DateTime.Now.ToString("HH:mm tt");
                archtb8.Text = DateTime.Now.ToString("yyyy/MM/dd");

                insertData.EmpArchAdding(int.Parse(archtb2.Text), int.Parse(archtb3.Text), archtb4.Text, archtb5.Text
                , archtb6.Text, archtb7.Text, archtb8.Text);
            }
            DataTable Dt = insertData.EmpArchSelect(int.Parse(empseq.Text), Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
               archtb6, archtb7, archtb8, pnarch1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //======================================================================================================================
        /// <summary>
        /// this function below for Scanning images more than one..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void مرفقاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES insertData = new CLS_FRMS.CLSEMPLOYEES();
            
            var item = TwainOperations.ScanImages();
            foreach (var Itm in item)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfEmployees + nameimage;
                imageArchieve.Load(Itm);
                imageArchieve.Image.Save(newpath);
                archtb5.Text = newpath;

                archtb2.Text = empseq.Text;
                archtb3.Text = empdocnopast.Text;
                archtb4.Text = empemployeename.Text;
                archtb6.Text = Properties.Settings.Default.UserNameLogin.ToString();
                archtb7.Text = DateTime.Now.ToString("HH:mm tt");
                archtb8.Text = DateTime.Now.ToString("yyyy/MM/dd");

                insertData.EmpArchAdding(int.Parse(archtb2.Text), int.Parse(archtb3.Text), archtb4.Text, archtb5.Text
                , archtb6.Text, archtb7.Text, archtb8.Text);
                
            }

            DataTable Dt = insertData.EmpArchSelect(int.Parse(empseq.Text), Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //===============================================================================================================
        /// <summary>
        /// This function for GettingData from Tb_EmployeeInfo 
        /// using Change Selection of TreeView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emp_Tr_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try { 
            AStreenode.Text = Emp_Tr.SelectedNode.Text;
            ribbonPage1.Visible = true;
           
            CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
            DataTable Dt = Getdata.EmployeeInfoGetdata(AStreenode.Text,Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername, empdawria
                , empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork
                , empoldworkplace, emplivenow, empsing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania
                , empbirthdate, empbirthplace, emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework
                , tbl7, tbl8, tbl9, tbl13);

            DataTable Dt2 = Getdata.TreeNodeSearching(DgvSearching);

            Dt_Emp = null;
            Dt_Emp = Dt;
            cm = (CurrencyManager)this.BindingContext[Dt_Emp];
           

            page1.Show();
            TotalEmp.Caption = Emp_Tr.SelectedNode.Text;

            TE.EditValue = Dt.Rows.Count;
            TE.Caption = Emp_Tr.SelectedNode.Text;
            cmbEmp.Items.Clear();
                for (int i = 0; i < Dt_Emp.Rows.Count; i++)
                {
                    cmbEmp.Items.Add(Dt_Emp.Rows[i][5].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //========================================================================================================================

        private void Emp_Tr_KeyDown(object sender, KeyEventArgs e)
        {
            try { 
            if(e.KeyCode==Keys.Enter)
            {
                AStreenode.Text = Emp_Tr.SelectedNode.Text;
            }
            CLS_FRMS.CLSEMPLOYEES ExecuteEnter = new CLS_FRMS.CLSEMPLOYEES();
            ExecuteEnter.Emp_KeyDownEnter(LbMenuSelect, AStreenode,RenameNode, Emp_Tr);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //=======================================================================================================================

        private void اضافةدليلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            LbMenuSelect.Text = اضافةدليلToolStripMenuItem.Text;
            TreeNode newnode = Emp_Tr.Nodes.Add("MainNode", "New Folder", 0, 0);
            this.Emp_Tr.SelectedNode = newnode;
            Emp_Tr.LabelEdit = true;
            newnode.BeginEdit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void اعادةتسميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            LbMenuSelect.Text = اعادةتسميةToolStripMenuItem.Text;
            RenameNode.Text = Emp_Tr.SelectedNode.Text;
            TreeNode newnode = Emp_Tr.SelectedNode;
            this.Emp_Tr.SelectedNode = newnode;
            Emp_Tr.LabelEdit = true;
            newnode.BeginEdit();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES emparchDeleting = new CLS_FRMS.CLSEMPLOYEES();
            emparchDeleting.EmpArchDelete(int.Parse(archtb1.Text));
            emparchDeleting.EmpArchSelect(int.Parse(empseq.Text), Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //======================================================================================================================
        private void Searching_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //(Dgvempinfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);
            try { 
            (DgvSearching.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);
            if (DgvSearching.Rows.Count == 1)
            {
                Dt_Emp = null;
                TreeNodeSearchingtxt2.Text = DgvSearching.Rows[0].Cells[2].Value.ToString();
                CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
                DataTable Dt = Getdata.TreeNodeSearching2(TreeNodeSearchingtxt2.Text, Dgvempinfo, empseq, empdocnopast,empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername, empdawria
                    , empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork
                    , empoldworkplace, emplivenow, empsing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania
                    , empbirthdate, empbirthplace, emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework
                    , tbl7, tbl8, tbl9, tbl13);
                Dt_Emp = Dt;
                cm = (CurrencyManager)this.BindingContext[Dt_Emp];

            }
            else
            {

            }


            if (emppathimage.Text == "" || emppathimage.Text == null)
            {
                empimage.Image = null;
            }
            else
            {
                empimage.Load(emppathimage.Text);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

       

        private void Searching_EditValueChanged(object sender, EventArgs e)
        {
            //(Dgvempinfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", Searching.EditValue);



            //(Dgvempinfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);
            try { 
            (DgvSearching.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%'", textBox2.Text);
            if (DgvSearching.Rows.Count == 1)
            {
                Dt_Emp = null;
                TreeNodeSearchingtxt2.Text = DgvSearching.Rows[0].Cells[2].Value.ToString();
                CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
                DataTable Dt = Getdata.TreeNodeSearching2(TreeNodeSearchingtxt2.Text, Dgvempinfo, empseq, empdocnopast,empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername, empdawria
                    , empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork
                    , empoldworkplace, emplivenow, empsing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania
                    , empbirthdate, empbirthplace, emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework
                    , tbl7, tbl8, tbl9, tbl13);
                Dt_Emp = Dt;
                cm = (CurrencyManager)this.BindingContext[Dt_Emp];

            }
            else
            {

            }


            if (emppathimage.Text == "" || emppathimage.Text == null)
            {
                empimage.Image = null;
            }
            else
            {
                empimage.Load(emppathimage.Text);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position -= 1;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position = Dt_Emp.Rows.Count;
        }

        private void BtnNextEmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position += 1;
        }

        private void BtnFirstEmp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position = 0;
        }

        private void btnDoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRMDisplayEmployees frm = new FRMDisplayEmployees();
            frm.Show();
        }

        private void Dgvvar_SelectionChanged(object sender, EventArgs e)
        {
            try { 
            if (VarIDseq.Text == "")
            {
                VarIDseq.Text = "0";
            }

            CLS_FRMS.CLSEMPLOYEES ForToggle = new CLS_FRMS.CLSEMPLOYEES();
            
            DataTable Dt = ForToggle.EmpVarGettingData2(int.Parse(VarIDseq.Text), VarTypeAddbtn, VarTypeNotAddbtn);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][12].ToString() == "True") { VarTypeAddbtn.IsOn = true; }
                else { VarTypeAddbtn.IsOn = false; }
                if (Dt.Rows[0][13].ToString() == "True") { VarTypeNotAddbtn.IsOn = true; }
                else { VarTypeNotAddbtn.IsOn = false; }
            }
            DataTable dt1 = ForToggle.EmpVararchSelectdata(int.Parse(VarIDseq.Text));
            lstbVarArch.Items.Clear();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                lstbVarArch.Items.Add(dt1.Rows[i][4]);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void حاسبةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "select an file|*.jpg; *.bmp; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string file_type = Path.GetExtension(ofd.FileName);

                    if (file_type == ".jpg" || file_type == ".bmp" || file_type == ".png")
                    {

                        pathimage = ofd.FileName;
                        nameimage = System.IO.Path.GetFileName(pathimage);
                        Random x = new Random();
                        newpath = Properties.Settings.Default.PathOfEmployees + x.Next().ToString() + Path.GetExtension(nameimage);
                        empimage.Load(pathimage);
                        empimage.Image.Save(newpath);
                        emppathimage.Text = newpath;

                        Dt_Emp = null;
                        CLS_FRMS.CLSEMPLOYEES UpdatetData = new CLS_FRMS.CLSEMPLOYEES();
                        if (empdocnonew.Text == null || empdocnonew.Text == "")
                            empdocnonew.Text = "0";
                        int p = cm.Position;
                        Dt_Emp = UpdatetData.EmployeeInfoUpdatedata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                            , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                            , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                            , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                            , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                            , tbl13, int.Parse(empdocnopast.Text), int.Parse(empdocnonew.Text), emptype.Text, empidentityno.Text, empbloodtype.Text, empemployeesituation.Text, empbeneficiary.Text, empregistername.Text
                        , empdawria.Text, empemployeename.Text, empsurename.Text, empjob.Text, empjobnow.Text, empdivision.Text, empunit.Text, empworkplace.Text
                        , empsn.Text, empchilderncount.Text, empwifetype.Text, empstudy.Text, emplaststudy.Text, emptaghsus.Text, empmaharat.Text, empoldwork.Text
                       , empoldworkplace.Text, emplivenow.Text, empsing.Text, empoldliveplace.Text, empjunsia.Text, empjunsiaplace.Text
                       , empshahada.Text, empshahadaplace.Text, empbutaqatshakan.Text, empmaqtabmua.Text, empwatania.Text, empbirthdate.Text
                       , empbirthplace.Text, emptaghweelno.Text, emptaghweeldate.Text, empbarcode.Text, empmobile1.Text, empmobile2.Text
                       , empdepartment.Text, emppathimage.Text, empnotice.Text, emptypework.Text, int.Parse(empseq.Text));
                        cm = (CurrencyManager)this.BindingContext[Dt_Emp];
                        cm.Position = p;
                    }
                }

               }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void حذفالدليلToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tbvarsearching_TextChanged(object sender, EventArgs e)
        {

        }

        private void Lsv_MouseMove(object sender, MouseEventArgs e)
        {
            try { 
            if (chk_showdoc.Checked==true && Lsv.HitTest(e.X, e.Y).Item != null)
            {
                picload.Image = null;
                GC.Collect();
                picload.Image = Image.FromFile(Lsv.HitTest(e.X, e.Y).Item.Text);
                picload.Visible = true;
                //CLS_FRMS.CLSEMPLOYEES GetData = new CLS_FRMS.CLSEMPLOYEES();
                //DataTable Dt = GetData.EmployeesArchpathimage(Lsv.HitTest(e.X, e.Y).Item.Text, Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                //archtb6, archtb7, archtb8, pnarch1);
            }
            else
            {
                picload.Image = null;
                GC.Collect();
                picload.Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void empdocnopast_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.empdocnopast, "رقم الاضبارة القديم");
        }

        private void empdocnonew_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.empdocnonew, "رقم الاضبارة الجديد");
        }

        private void حاسبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.CLSEMPLOYEES insertData = new CLS_FRMS.CLSEMPLOYEES();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select an file|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file_type = Path.GetExtension(ofd.FileName);
                
                if (file_type == ".jpg" || file_type == ".bmp" || file_type == ".png")
                {

                    pathimage = ofd.FileName;
                    nameimage = System.IO.Path.GetFileName(pathimage);
                    Random x = new Random();
                    newpath = Properties.Settings.Default.PathOfEmployees + x.Next().ToString() + Path.GetExtension(nameimage);
                    empimage.Load(pathimage);
                    empimage.Image.Save(newpath);
                    archtb5.Text = newpath;
                    Lsv.Items.Add(archtb6.Text);

                    archtb2.Text = empseq.Text;
                    archtb3.Text = empdocnopast.Text;
                    archtb4.Text = empemployeename.Text;
                    archtb6.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    archtb7.Text = DateTime.Now.ToString("HH:mm tt");
                    archtb8.Text = DateTime.Now.ToString("yyyy/MM/dd");

                    insertData.EmpArchAdding(int.Parse(archtb2.Text), int.Parse(archtb3.Text), archtb4.Text, archtb5.Text
                    , archtb6.Text, archtb7.Text, archtb8.Text);
                }
                else
                {
                    
                    
                    string filename = System.IO.Path.GetFileName(ofd.FileName);
                    newpath = Properties.Settings.Default.pathofDocument + filename;
                    File.Copy(ofd.FileName, newpath);
                    Random x = new Random();
                    filename = Properties.Settings.Default.pathofDocument + x.Next().ToString() + Path.GetExtension(ofd.FileName);
                   
                    File.Move(newpath, filename);

                    archtb5.Text = filename;
                    Lsv.Items.Add(archtb6.Text);

                    archtb2.Text = empseq.Text;
                    archtb3.Text = empdocnopast.Text;
                    archtb4.Text = empemployeename.Text;
                    archtb6.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    archtb7.Text = DateTime.Now.ToString("HH:mm tt");
                    archtb8.Text = DateTime.Now.ToString("yyyy/MM/dd");

                    insertData.EmpArchAdding(int.Parse(archtb2.Text), int.Parse(archtb3.Text), archtb4.Text, archtb5.Text
                     , archtb6.Text, archtb7.Text, archtb8.Text);

                }
                DataTable Dt = insertData.EmpArchSelect(int.Parse(empseq.Text), Lsv, archtb1, archtb2, archtb3, archtb4, archtb5,
                archtb6, archtb7, archtb8, pnarch1);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void cmbEmp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (DgvSearching.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '{0}%'", cmbEmp.Text);

                if (DgvSearching.Rows.Count == 1)
                {
                    Dt_Emp = null;
                    TreeNodeSearchingtxt.Text = DgvSearching.Rows[0].Cells[5].Value.ToString();
                    CLS_FRMS.CLSEMPLOYEES Getdata = new CLS_FRMS.CLSEMPLOYEES();
                    DataTable Dt = Getdata.TreeNodeSearching2(TreeNodeSearchingtxt.Text, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername, empdawria
                        , empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork
                        , empoldworkplace, emplivenow, empsing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania
                        , empbirthdate, empbirthplace, emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework
                        , tbl7, tbl8, tbl9, tbl13);
                    Dt_Emp = Dt;
                    cm = (CurrencyManager)this.BindingContext[Dt_Emp];
                    

                }
                else
                {

                }


                if (emppathimage.Text == "" || emppathimage.Text == null)
                {
                    empimage.Image = null;
                }
                else
                {
                    empimage.Load(emppathimage.Text);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void tbdgv_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void label109_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void طباعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            Process p = new Process();
            p.StartInfo.FileName = archtb5.Text;
            p.StartInfo.Verb = "Print";
            p.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            try
            {
                var b = TwainOperations.ScanImages();
                foreach (var Itm in b)
                {
                    pathimage = Itm;
                    nameimage = Path.GetFileName(pathimage);
                    newpath = Properties.Settings.Default.PathOfEmployees + nameimage;
                    PictureBox picsave = new PictureBox();
                    picsave.Load(Itm);
                    picsave.Image.Save(newpath);
                    lstbVarArch.Items.Add(newpath);

                    CLS_FRMS.CLSEMPLOYEES archadding = new CLS_FRMS.CLSEMPLOYEES();
                    archadding.EmpVararchInsertdata(int.Parse(VarIDseq.Text), int.Parse(VarIDcon.Text), Varempname.Text,newpath);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void lstbVarArch_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Process.Start(lstbVarArch.SelectedItem.ToString());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void cameraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                emppathimage.Text = null;

                CLS_FRMS.CLSEMPLOYEES UpdatetData = new CLS_FRMS.CLSEMPLOYEES();
                if (empdocnonew.Text == null || empdocnonew.Text == "")
                    empdocnonew.Text = "0";
                int p = cm.Position;
                Dt_Emp = null;
                Dt_Emp= UpdatetData.EmployeeInfoUpdatedata(AStreenode, Dgvempinfo, empseq, empdocnopast, empdocnonew, emptype, empidentityno, empbloodtype, empemployeesituation, empbeneficiary, empregistername
                    , empdawria, empemployeename, empsurename, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, empchilderncount
                    , empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace, emplivenow, empsing, empoldliveplace
                    , empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqatshakan, empmaqtabmua, empwatania, empbirthdate, empbirthplace
                    , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, emptypework, tbl7, tbl8, tbl9
                    , tbl13, int.Parse(empdocnopast.Text), int.Parse(empdocnonew.Text), emptype.Text, empidentityno.Text, empbloodtype.Text, empemployeesituation.Text, empbeneficiary.Text, empregistername.Text
                , empdawria.Text, empemployeename.Text, empsurename.Text, empjob.Text, empjobnow.Text, empdivision.Text, empunit.Text, empworkplace.Text
                , empsn.Text, empchilderncount.Text, empwifetype.Text, empstudy.Text, emplaststudy.Text, emptaghsus.Text, empmaharat.Text, empoldwork.Text
               , empoldworkplace.Text, emplivenow.Text, empsing.Text, empoldliveplace.Text, empjunsia.Text, empjunsiaplace.Text
               , empshahada.Text, empshahadaplace.Text, empbutaqatshakan.Text, empmaqtabmua.Text, empwatania.Text, empbirthdate.Text
               , empbirthplace.Text, emptaghweelno.Text, emptaghweeldate.Text, empbarcode.Text, empmobile1.Text, empmobile2.Text
               , empdepartment.Text, emppathimage.Text, empnotice.Text, emptypework.Text, int.Parse(empseq.Text));
                cm = (CurrencyManager)this.BindingContext[Dt_Emp];
                cm.Position = p;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Dissearching_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (DisDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[GoingDate] = '{0}'", Dissearching.Text);
            }
            catch
            {
                (DisDgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Distenation] like '%{0}%'", Dissearching.Text);
            }
        }

        private void btnCreateBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                Random r = new Random();
                empbarcode.Text = r.Next(0, 1000000000).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnPrintBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument printDocument1 = new PrintDocument();
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.Print();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            BarcodeWriter w = new BarcodeWriter() { Format = BarcodeFormat.CODE_128,
               Options = new ZXing.Common.EncodingOptions
               {
                   Height = 80,
                   Width = 100,
                   Margin = 0
               },
            };
            w.Options.PureBarcode =true;
            PictureBox p = new PictureBox();
            p.Image = w.Write(empbarcode.Text);
            e.Graphics.DrawImage(p.Image, 0, 0);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeservePressingEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CLS_FRMS.CLSEMPLOYEES GettingData = new CLS_FRMS.CLSEMPLOYEES();
                GettingData.EmpDesPressingGettingData(DGVDesmP, DesmPyear, DesmPIDseq, DesmPIDcon, DesmPname, DesmP1, DesmP2, DesmP3, DesmP4, DesmP5, DesmP6, DesmP7, DesmP8, DesmP9, DesmP10, DesmP11
                    , DesmP12, DesmP13, DesmP14, DesmP15, DesmPnote1, DesmPnote2, DesmPnote3, DesmPnote4, DesmPnote5, DesmPnote6, DesmPnote7, DesmPnote8, DesmPnote9, DesmPnote10, DesmPnote11,
                    DesmPnote12, DesmPnote13, DesmPnote14, DesmPnote15,
                    int.Parse(empseq.Text), DesmPRegisterName, DesmPAddingTime, DesmPAddingdate);

                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                    Properties.Settings.Default.PasswordLogin.ToString(), "استحقاقات طارئة");

                Permissions.PerThree3(Dt, DesmPbtnadd, DesmPbtnupdate, DesmPbtndelete);


                page8.Show();
                foreach (Control p in tbl22.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeserveSatisfyingEmployees_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CLS_FRMS.CLSEMPLOYEES GettingData = new CLS_FRMS.CLSEMPLOYEES();
                GettingData.EmpDesSatisfyingGettingData(DGVDesmS, DesmSyear, DesmSIDseq, DesmSIDcon, DesmSname, DesmS1, DesmS2, DesmS3, DesmS4, DesmS5, DesmS6, DesmS7, DesmS8, DesmS9, DesmS10, DesmS11
                    , DesmS12, DesmS13, DesmS14, DesmS15, DesmS16, DesmS17, DesmS18, DesmS19, DesmS20, DesmS21, DesmS22, DesmS23, DesmS24, DesmS25, DesmS26, DesmS27, DesmS28, DesmS29, DesmS30,
                     DesmS31, DesmS32, DesmS33, DesmS34, DesmS35, DesmS36, DesmS37, DesmS38, DesmS39, DesmS40, DesmS41, DesmS42, DesmS43, DesmS44, DesmS45,
                     int.Parse(empseq.Text), DesmSRegisterName, DesmSAddingTime, DesmSAddingDate);

                CLS_FRMS.CLS_UsersAndPermissions Permissions = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Permissions.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                    Properties.Settings.Default.PasswordLogin.ToString(), "استحقاقات مرضية");

                Permissions.PerThree3(Dt, DesmSbtnadd, DesmSbtnupdate, DesmSbtndelete);      

                page9.Show();
                foreach (Control p in tbl24.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmPbtnnew_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control p in tbl22.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }
                foreach (Control p in tbl23.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }

                DesmPIDcon.Text = empseq.Text;
                DesmPname.Text = empemployeename.Text;
                foreach (Control p in tbl22.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmSbtnnew_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control p in tbl24.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }
                foreach (Control p in tbl25.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); (p as TextBox).Clear(); } }
                foreach (Control p in tbl24.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                DesmSIDcon.Text = empseq.Text;
                DesmSname.Text = empemployeename.Text;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmPbtnadd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة سنة جديدة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES InsertDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    InsertDataDeserve.EmpDesPressingInsertData(DGVDesmP, DesmPyear, DesmPIDseq, DesmPIDcon, DesmPname, DesmP1, DesmP2, DesmP3, DesmP4, DesmP5, DesmP6, DesmP7, DesmP8, DesmP9
                        , DesmP10, DesmP11, DesmP12, DesmP13, DesmP14, DesmP15, DesmPnote1, DesmPnote2, DesmPnote3, DesmPnote4, DesmPnote5, DesmPnote6, DesmPnote7, DesmPnote8, DesmPnote9, DesmPnote10, DesmPnote11,
                          DesmPnote12, DesmPnote13, DesmPnote14, DesmPnote15,
                          DesmPRegisterName, DesmPAddingTime, DesmPAddingdate
                        , int.Parse(DesmPIDcon.Text), DesmPname.Text, DesmPyear.Text, DesmP1.Text, DesmP2.Text, DesmP3.Text, DesmP4.Text, DesmP5.Text, DesmP6.Text
                        , DesmP7.Text, DesmP8.Text, DesmP9.Text, DesmP10.Text, DesmP11.Text, DesmP12.Text, DesmP13.Text, DesmP14.Text, DesmP15.Text, DesmPnote1.Text
                        , DesmPnote2.Text, DesmPnote3.Text, DesmPnote4.Text, DesmPnote5.Text, DesmPnote6.Text, DesmPnote7.Text, DesmPnote8.Text, DesmPnote9.Text, DesmPnote10.Text, DesmPnote11.Text, DesmPnote12.Text, DesmPnote13.Text, DesmPnote14.Text, DesmPnote15.Text);

                    foreach (Control p in tbl22.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmPbtnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل على هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES UpdateDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    UpdateDataDeserve.EmpDesPressingUpdatetData(DGVDesmP, DesmPyear, DesmPIDseq, DesmPIDcon, DesmPname, DesmP1, DesmP2, DesmP3, DesmP4, DesmP5, DesmP6, DesmP7, DesmP8, DesmP9
                        , DesmP10, DesmP11, DesmP12, DesmP13, DesmP14, DesmP15, DesmPnote1, DesmPnote2, DesmPnote3, DesmPnote4, DesmPnote5, DesmPnote6, DesmPnote7, DesmPnote8, DesmPnote9, DesmPnote10, DesmPnote11, DesmPnote12, DesmPnote13, DesmPnote14, DesmPnote15,
                         DesmPRegisterName, DesmPAddingTime, DesmPAddingdate
                        , int.Parse(DesmPIDcon.Text), DesmPname.Text, DesmPyear.Text, DesmP1.Text, DesmP2.Text, DesmP3.Text, DesmP4.Text, DesmP5.Text, DesmP6.Text
                        , DesmP7.Text, DesmP8.Text, DesmP9.Text, DesmP10.Text, DesmP11.Text, DesmP12.Text, DesmP13.Text, DesmP14.Text, DesmP15.Text, DesmPnote1.Text
                        , DesmPnote2.Text, DesmPnote3.Text, DesmPnote4.Text, DesmPnote5.Text, DesmPnote6.Text, DesmPnote7.Text, DesmPnote8.Text, DesmPnote9.Text, DesmPnote10.Text, DesmPnote11.Text, DesmPnote12.Text, DesmPnote13.Text, DesmPnote14.Text, DesmPnote15.Text,
                        int.Parse(DesmPIDseq.Text));
                    foreach (Control p in tbl22.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmPbtndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES DeleteDatadeserve = new CLS_FRMS.CLSEMPLOYEES();
                    DeleteDatadeserve.EmpDesPressingDeleteData(DGVDesmP, DesmPyear, DesmPIDseq, DesmPIDcon, DesmPname, DesmP1, DesmP2, DesmP3, DesmP4, DesmP5, DesmP6, DesmP7, DesmP8, DesmP9
                        , DesmP10, DesmP11, DesmP12, DesmP13, DesmP14, DesmP15, DesmPnote1, DesmPnote2, DesmPnote3, DesmPnote4, DesmPnote5, DesmPnote6, DesmPnote7, DesmPnote8, DesmPnote9, DesmPnote10, DesmPnote11, DesmPnote12, DesmPnote13, DesmPnote14, DesmPnote15,
                       int.Parse(DesmPIDseq.Text), DesmPRegisterName, DesmPAddingTime, DesmPAddingdate);
                    foreach (Control p in tbl22.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmSbtnadd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة سنة جديدة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES InsertDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    InsertDataDeserve.EmpDesSatisfyingInsertData(DGVDesmS, DesmSyear, DesmSIDseq, DesmSIDcon, DesmSname, DesmS1, DesmS2, DesmS3, DesmS4, DesmS5, DesmS6, DesmS7, DesmS8, DesmS9, DesmS10, DesmS11
                    , DesmS12, DesmS13, DesmS14, DesmS15, DesmS16, DesmS17, DesmS18, DesmS19, DesmS20, DesmS21, DesmS22, DesmS23, DesmS24, DesmS25, DesmS26, DesmS27, DesmS28, DesmS29, DesmS30,
                     DesmS31, DesmS32, DesmS33, DesmS34, DesmS35, DesmS36, DesmS37, DesmS38, DesmS39, DesmS40, DesmS41, DesmS42, DesmS43, DesmS44, DesmS45,
                          DesmSRegisterName, DesmSAddingTime, DesmSAddingDate
                        , int.Parse(DesmSIDcon.Text), DesmSname.Text, DesmSyear.Text, DesmS1.Text, DesmS2.Text, DesmS3.Text, DesmS4.Text, DesmS5.Text, DesmS6.Text
                        , DesmS7.Text, DesmS8.Text, DesmS9.Text, DesmS10.Text, DesmS11.Text, DesmS12.Text, DesmS13.Text, DesmS14.Text, DesmS15.Text, DesmS16.Text
                        , DesmS17.Text, DesmS18.Text, DesmS19.Text, DesmS20.Text, DesmS21.Text, DesmS22.Text, DesmS23.Text, DesmS24.Text, DesmS25.Text, DesmS26.Text, DesmS27.Text, DesmS28.Text, DesmS29.Text, DesmS30.Text
                        , DesmS31.Text, DesmS32.Text, DesmS33.Text, DesmS34.Text, DesmS35.Text, DesmS36.Text, DesmS37.Text, DesmS38.Text, DesmS39.Text, DesmS40.Text, DesmS41.Text, DesmS42.Text, DesmS43.Text, DesmS44.Text, DesmS45.Text);
                    foreach (Control p in tbl24.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmSbtnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد التعديل على هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES UpdateDataDeserve = new CLS_FRMS.CLSEMPLOYEES();
                    UpdateDataDeserve.EmpDesSatisfyingUpdatetData(DGVDesmS, DesmSyear, DesmSIDseq, DesmSIDcon, DesmSname, DesmS1, DesmS2, DesmS3, DesmS4, DesmS5, DesmS6, DesmS7, DesmS8, DesmS9, DesmS10, DesmS11
                    , DesmS12, DesmS13, DesmS14, DesmS15, DesmS16, DesmS17, DesmS18, DesmS19, DesmS20, DesmS21, DesmS22, DesmS23, DesmS24, DesmS25, DesmS26, DesmS27, DesmS28, DesmS29, DesmS30,
                     DesmS31, DesmS32, DesmS33, DesmS34, DesmS35, DesmS36, DesmS37, DesmS38, DesmS39, DesmS40, DesmS41, DesmS42, DesmS43, DesmS44, DesmS45
                        , DesmSRegisterName, DesmSAddingTime, DesmSAddingDate
                        , int.Parse(DesmSIDcon.Text), DesmSname.Text, DesmSyear.Text, DesmS1.Text, DesmS2.Text, DesmS3.Text, DesmS4.Text, DesmS5.Text, DesmS6.Text
                        , DesmS7.Text, DesmS8.Text, DesmS9.Text, DesmS10.Text, DesmS11.Text, DesmS12.Text, DesmS13.Text, DesmS14.Text, DesmS15.Text, DesmS16.Text
                        , DesmS17.Text, DesmS18.Text, DesmS19.Text, DesmS20.Text, DesmS21.Text, DesmS22.Text, DesmS23.Text, DesmS24.Text, DesmS25.Text, DesmS26.Text, DesmS27.Text, DesmS28.Text, DesmS29.Text, DesmS30.Text
                        , DesmS31.Text, DesmS32.Text, DesmS33.Text, DesmS34.Text, DesmS35.Text, DesmS36.Text, DesmS37.Text, DesmS38.Text, DesmS39.Text, DesmS40.Text, DesmS41.Text, DesmS42.Text, DesmS43.Text, DesmS44.Text, DesmS45.Text
                        , int.Parse(DesmSIDseq.Text));
                    foreach (Control p in tbl24.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DesmSbtndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد حذف هذه السنة؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.CLSEMPLOYEES DeleteDatadeserve = new CLS_FRMS.CLSEMPLOYEES();
                    DeleteDatadeserve.EmpDesSatisfyingDeleteData(DGVDesmS, DesmSyear, DesmSIDseq, DesmSIDcon, DesmSname, DesmS1, DesmS2, DesmS3, DesmS4, DesmS5, DesmS6, DesmS7, DesmS8, DesmS9, DesmS10, DesmS11
                        , DesmS12, DesmS13, DesmS14, DesmS15, DesmS16, DesmS17, DesmS18, DesmS19, DesmS20, DesmS21, DesmS22, DesmS23, DesmS24, DesmS25, DesmS26, DesmS27, DesmS28, DesmS29, DesmS30
                        , DesmS31, DesmS32, DesmS33, DesmS34, DesmS35, DesmS36, DesmS37, DesmS38, DesmS39, DesmS40, DesmS41, DesmS42, DesmS43, DesmS44, DesmS45
                        , DesmSRegisterName, DesmSAddingTime, DesmSAddingDate, int.Parse(DesmSIDseq.Text));
                    foreach (Control p in tbl24.Controls) { if (p is TextBox) { if ((p as TextBox).Text.Length > 0) { (p as TextBox).BackColor = Color.Yellow; } else { (p as TextBox).BackColor = Color.White; } } }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Desm19_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPrintDoc_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.RPEMPEMPLOYEES rp = new CLS_FRMS.RPEMPEMPLOYEES();
                DataTable Dt = new DataTable();
                Dt = rp.EmployeesInfoSelectByID(int.Parse(empseq.Text));
                DS.DataSetMechanisms DS = new DS.DataSetMechanisms();
                DS.Tables["EmployeesInfoSelectByID"].Clear();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DS.Tables["EmployeesInfoSelectByID"].Rows.Add(Dt.Rows[i][1], Dt.Rows[i][2]
                        , Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],Dt.Rows[i][7]
                        , Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11], Dt.Rows[i][12]
                        , Dt.Rows[i][13], Dt.Rows[i][14], Dt.Rows[i][15], Dt.Rows[i][16], Dt.Rows[i][17]
                        , Dt.Rows[i][18], Dt.Rows[i][19], Dt.Rows[i][20], Dt.Rows[i][21], Dt.Rows[i][22]
                        , Dt.Rows[i][23], Dt.Rows[i][24], Dt.Rows[i][25], Dt.Rows[i][26], Dt.Rows[i][27]
                        , Dt.Rows[i][28], Dt.Rows[i][29], Dt.Rows[i][30], Dt.Rows[i][31], Dt.Rows[i][32]
                        , Dt.Rows[i][33], Dt.Rows[i][34], Dt.Rows[i][35], Convert.ToDateTime(Dt.Rows[i][36]).ToString("dd/MM/yyyy"), Dt.Rows[i][37]
                        , Dt.Rows[i][38], Dt.Rows[i][39], Convert.ToDateTime(Dt.Rows[i][40]).ToString("dd/MM/yyyy"), Dt.Rows[i][41], Dt.Rows[i][42]
                        , Dt.Rows[i][43], Dt.Rows[i][44], Dt.Rows[i][46], Dt.Rows[i][47]);
                }

                REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                REPORTS.EmpDocRP rpt = new REPORTS.EmpDocRP();

             

                for (int i = 0; i < rpt.Parameters.Count; i++)
                {
                    rpt.Parameters[i].Visible = false;
                }
                rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                rpt.Parameters["date"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                rpt.DataSource = DS;
                rpt.RequestParameters = false;
                frm.documentViewer1.DocumentSource = rpt;
                frm.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnFirstAdminOrder_Click(object sender, EventArgs e)
        {
            cmAdminOrder.Position = 0;
        }

        private void btnBeforAdminOrder_Click(object sender, EventArgs e)
        {
            cmAdminOrder.Position -= 1;
        }

        private void btnFirstVariable_Click(object sender, EventArgs e)
        {
            cmVariable.Position = 0;
        }

        private void btnBeforVariable_Click(object sender, EventArgs e)
        {
            cmVariable.Position -= 1;
        }

        private void btnFirstDispatch_Click(object sender, EventArgs e)
        {
            cmDispatch.Position = 0;
        }

        private void btnBeforDispatch_Click(object sender, EventArgs e)
        {
            cmDispatch.Position -= 1;
        }

        private void btnAfterDispatch_Click(object sender, EventArgs e)
        {
            cmDispatch.Position += 1;
        }

        private void btnLastDispatch_Click(object sender, EventArgs e)
        {
            cmDispatch.Position = Dt_Dispatch.Rows.Count;
        }

        private void DesYear_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Desm1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Dgvdeserve_SelectionChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (DesYear.Text != null && DesYear.Text != "")
                if (int.Parse(DesYear.Text) == DateTime.Now.Year)
                {
                    foreach (Control p in tbl19.Controls)
                    {
                        if (p is TextBox)
                        {
                            if ((p as TextBox).Text == null || (p as TextBox).Text == "")
                            {
                                switch ((p as TextBox).Name)
                                {
                                    case "Desm1":
                                        if (DateTime.Now.Month == 1 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 1)
                                            count++;
                                        break;
                                    case "Desm2":
                                        if (DateTime.Now.Month == 1 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 1)
                                            count++;
                                        break;
                                    case "Desm3":
                                        if (DateTime.Now.Month == 2 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 2)
                                            count++;
                                        break;
                                    case "Desm4":
                                        if (DateTime.Now.Month == 2 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 2)
                                            count++;
                                        break;
                                    case "Desm5":
                                        if (DateTime.Now.Month == 3 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 3)
                                            count++;
                                        break;
                                    case "Desm6":
                                        if (DateTime.Now.Month == 3 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 3)
                                            count++;
                                        break;
                                    case "Desm7":
                                        if (DateTime.Now.Month == 4 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 4)
                                            count++;
                                        break;
                                    case "Desm8":
                                        if (DateTime.Now.Month == 4 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 4)
                                            count++;
                                        break;
                                    case "Desm9":
                                        if (DateTime.Now.Month == 5 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 5)
                                            count++;
                                        break;
                                    case "Desm10":
                                        if (DateTime.Now.Month == 5 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 5)
                                            count++;
                                        break;
                                    case "Desm11":
                                        if (DateTime.Now.Month == 6 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 6)
                                            count++;
                                        break;
                                    case "Desm12":
                                        if (DateTime.Now.Month == 6 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 6)
                                            count++;
                                        break;
                                    case "Desm13":
                                        if (DateTime.Now.Month == 7 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 7)
                                            count++;
                                        break;
                                    case "Desm14":
                                        if (DateTime.Now.Month == 7 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 7)
                                            count++;
                                        break;
                                    case "Desm15":
                                        if (DateTime.Now.Month == 7 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 7)
                                            count++;
                                        break;
                                    case "Desm16":
                                        if (DateTime.Now.Month == 8 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 8)
                                            count++;
                                        break;
                                    case "Desm17":
                                        if (DateTime.Now.Month == 8 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 8)
                                            count++;
                                        break;
                                    case "Desm18":
                                        if (DateTime.Now.Month == 8 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 8)
                                            count++;
                                        break;
                                    case "Desm19":
                                        if (DateTime.Now.Month == 9 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 9)
                                            count++;
                                        break;
                                    case "Desm20":
                                        if (DateTime.Now.Month == 9 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 9)
                                            count++;
                                        break;
                                    case "Desm21":
                                        if (DateTime.Now.Month > 9)
                                            count++;
                                        break;
                                    case "Desm22":
                                        if (DateTime.Now.Month == 10 && DateTime.Now.Day > 10)
                                            count++;
                                        else if (DateTime.Now.Month > 10)
                                            count++;
                                        break;
                                    case "Desm23":
                                        if (DateTime.Now.Month == 10 && DateTime.Now.Day > 20)
                                            count++;
                                        else if (DateTime.Now.Month > 10)
                                            count++;
                                        break;
                                    case "Desm24":
                                        if (DateTime.Now.Month == 10 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 10)
                                            count++;
                                        break;
                                    case "Desm25":
                                        if (DateTime.Now.Month == 1 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 1)
                                            count++;
                                        break;
                                    case "Desm26":
                                        if (DateTime.Now.Month > 2)
                                            count++;
                                        break;
                                    case "Desm27":
                                        if (DateTime.Now.Month == 3 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 3)
                                            count++;
                                        break;
                                    case "Desm28":
                                        if (DateTime.Now.Month > 4)
                                            count++;
                                        break;
                                    case "Desm29":
                                        if (DateTime.Now.Month == 5 && DateTime.Now.Day > 30)
                                            count++;
                                        else if (DateTime.Now.Month > 5)
                                            count++;
                                        break;
                                    case "Desm30":
                                        if (DateTime.Now.Month > 6)
                                            count++;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Control p in tbl19.Controls) { if (p is TextBox) { if (String.IsNullOrWhiteSpace((p as TextBox).Text)) { count++; } } }
                }
            txt_DesCount.Text = count.ToString();
        }

        private void btnAfterVariable_Click(object sender, EventArgs e)
        {
            cmVariable.Position += 1;
        }

        private void btnLastVariable_Click(object sender, EventArgs e)
        {
            cmVariable.Position = Dt_Variable.Rows.Count;
        }

        private void btnAfterAdminOrder_Click(object sender, EventArgs e)
        {
            cmAdminOrder.Position += 1;
        }

        private void btnLastAdminOrder_Click(object sender, EventArgs e)
        {
            cmAdminOrder.Position = Dt_AdminOrder.Rows.Count;
        }

        private void DGVDesmSview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        //=========================================================================================================================
        //============= 
    }
}
