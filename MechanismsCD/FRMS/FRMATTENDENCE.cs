using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Bunifu.Framework.Lib;


namespace MechanismsCD.FRMS
{
    public partial class FRMATTENDENCE : Form
    {
        public FRMATTENDENCE()
        {
            InitializeComponent();
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRMATTENDENCE_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Properties.Settings.Default.UserNameLogin;
            this.Text = "الحضور والانصراف";
            CLS_FRMS.CLS_UsersAndPermissions Per3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Per3.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), this.Text);
            
            Per3.PerThreeAtten(Dt, btnAtten1Add, btnAtten1Save, btnAtten1Delete, btnAddTimeEmp, btnAddNoticEmp, btnDeleteEmp, btnDeleteAllEmp,btnSyncEmp,btnSyncRest);
        }

        private void btnAtten1Loading_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLSATTENDENCE AtGettingData = new CLS_FRMS.CLSATTENDENCE();
                AtGettingData.Attendence1SelectingData(dgvsheft1, Atten1ID, Atten1SheftDateStart, Atten1SheftDateEnd, Atten1SheftDay, Atten1SheftName, Atten1RegisterName
                    , Atten1AddingTime, Atten1AddingDate, TimeStart, TimeEnd, txtAddingTime);

                CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
                DataTable Dt = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                     Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                     int.Parse(Atten1ID.Text));
                At2GettingData.dgvdesign(atten2dgv, Dt);
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAtten1New_Click(object sender, EventArgs e)
        {
            Atten1SheftDateStart.Text = "";
            Atten1SheftDateEnd.Text = "";
            Atten1SheftDay.Text = "";
            Atten1SheftName.Text = "";
            TimeStart.DataBindings.Clear();
            TimeEnd.DataBindings.Clear();
            Atten1RegisterName.Text = "RegisterName";
            Atten1AddingTime.Text = DateTime.Now.ToString("HH:mm tt");
            Atten1AddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            txtAddingTime.DataBindings.Clear();
            txtAddingTime.Text = "0";
        }

        private void btnAtten1Add_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSATTENDENCE AtinsertingData = new CLS_FRMS.CLSATTENDENCE();
            AtinsertingData.Attendence1insertData(Atten1SheftDateStart.Text, Atten1SheftDateEnd.Text, Atten1SheftDay.Text, Atten1SheftName.Text, Atten1RegisterName.Text
                , Atten1AddingTime.Text, Atten1AddingDate.Text,TimeStart.Value.TimeOfDay.ToString(),TimeEnd.Value.TimeOfDay.ToString(), double.Parse(txtAddingTime.Text));

            CLS_FRMS.CLSATTENDENCE AtGettingData = new CLS_FRMS.CLSATTENDENCE();
            AtGettingData.Attendence1SelectingData(dgvsheft1, Atten1ID, Atten1SheftDateStart, Atten1SheftDateEnd, Atten1SheftDay, Atten1SheftName, Atten1RegisterName
                , Atten1AddingTime, Atten1AddingDate,TimeStart,TimeEnd, txtAddingTime);
        }

        private void btnAtten1Save_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSATTENDENCE AtUpdateData = new CLS_FRMS.CLSATTENDENCE();
            AtUpdateData.Attendence1UpdateData(Atten1SheftDateStart.Text, Atten1SheftDateEnd.Text, Atten1SheftDay.Text, Atten1SheftName.Text, Atten1RegisterName.Text
                , Atten1AddingTime.Text, Atten1AddingDate.Text, int.Parse(Atten1ID.Text), TimeStart.Value.TimeOfDay.ToString(), TimeEnd.Value.TimeOfDay.ToString(), double.Parse(txtAddingTime.Text));

            CLS_FRMS.CLSATTENDENCE AtGettingData = new CLS_FRMS.CLSATTENDENCE();
            AtGettingData.Attendence1SelectingData(dgvsheft1, Atten1ID, Atten1SheftDateStart, Atten1SheftDateEnd, Atten1SheftDay, Atten1SheftName, Atten1RegisterName
                , Atten1AddingTime, Atten1AddingDate, TimeStart, TimeEnd, txtAddingTime);
        }

        private void btnAtten1Delete_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSATTENDENCE AtDeletingData = new CLS_FRMS.CLSATTENDENCE();
            AtDeletingData.Attendence1DeleteData(int.Parse(Atten1ID.Text));

            CLS_FRMS.CLSATTENDENCE AtGettingData = new CLS_FRMS.CLSATTENDENCE();
            AtGettingData.Attendence1SelectingData(dgvsheft1, Atten1ID, Atten1SheftDateStart,Atten1SheftDateEnd, Atten1SheftDay, Atten1SheftName, Atten1RegisterName
                , Atten1AddingTime, Atten1AddingDate, TimeStart, TimeEnd, txtAddingTime);
        }


        private void bgwatten_DoWork(object sender, DoWorkEventArgs e)
        {
            string Atten1SheftName1 = "";
            if (Atten1SheftName.InvokeRequired) { Atten1SheftName.Invoke(new MethodInvoker(delegate { Atten1SheftName1 = Atten1SheftName.Text; })); }
            TextBox Atten2ID1=new TextBox() ;
            if (Atten2ID.InvokeRequired) { Atten2ID.Invoke(new MethodInvoker(delegate { Atten2ID1 = Atten2ID; })); }
            TextBox Atten2IDcon1 = new TextBox();
            if (Atten2IDcon.InvokeRequired) { Atten2IDcon.Invoke(new MethodInvoker(delegate { Atten2IDcon1 = Atten2IDcon; })); }
            TextBox Atten2EmpName1 = new TextBox();
            if (Atten2EmpName.InvokeRequired) { Atten2EmpName.Invoke(new MethodInvoker(delegate { Atten2EmpName1 = Atten2EmpName; })); }
            TextBox Atten2EmpBarcode1 = new TextBox();
            if (Atten2EmpBarcode.InvokeRequired) { Atten2EmpBarcode.Invoke(new MethodInvoker(delegate { Atten2EmpBarcode1 = Atten2EmpBarcode; })); }
            TextBox Atten2EmpSheft1 = new TextBox();
            if (Atten2EmpSheft.InvokeRequired) { Atten2EmpSheft.Invoke(new MethodInvoker(delegate { Atten2EmpSheft1 = Atten2EmpSheft; })); }
            TextBox Atten2WorkType1 = new TextBox();
            if (Atten2WorkType.InvokeRequired) { Atten2WorkType.Invoke(new MethodInvoker(delegate { Atten2WorkType1 = Atten2WorkType; })); }
            TextBox Atten2TimeIn1 = new TextBox();
            if (Atten2TimeIn.InvokeRequired) { Atten2TimeIn.Invoke(new MethodInvoker(delegate { Atten2TimeIn1 = Atten2TimeIn; })); }
            TextBox Atten2TimeOut1 = new TextBox();
            if (Atten2TimeOut.InvokeRequired) { Atten2TimeOut.Invoke(new MethodInvoker(delegate { Atten2TimeOut1 = Atten2TimeOut; })); }
            TextBox Atten2HourCount1 = new TextBox();
            if (Atten2HourCount.InvokeRequired) { Atten2HourCount.Invoke(new MethodInvoker(delegate { Atten2HourCount1 = Atten2HourCount; })); }
            TextBox Atten2EmpType1 = new TextBox();
            if (Atten2EmpType.InvokeRequired) { Atten2EmpType.Invoke(new MethodInvoker(delegate { Atten2EmpType1 = Atten2EmpType; })); }
            RichTextBox Atten2Notice1 = new RichTextBox();
            if (Atten2Notice.InvokeRequired) { Atten2Notice.Invoke(new MethodInvoker(delegate { Atten2Notice1 = Atten2Notice; })); }
            TextBox Atten2RegisterName1 = new TextBox();
            if (Atten2RegisterName.InvokeRequired) { Atten2RegisterName.Invoke(new MethodInvoker(delegate { Atten2RegisterName1 = Atten2RegisterName; })); }
            TextBox Atten2AddingTime1 = new TextBox();
            if (Atten2AddingTime.InvokeRequired) { Atten2AddingTime.Invoke(new MethodInvoker(delegate { Atten2AddingTime1 = Atten2AddingTime; })); }
            TextBox Atten2AddingDate1 = new TextBox();
            if (Atten2AddingDate.InvokeRequired) { Atten2AddingDate.Invoke(new MethodInvoker(delegate { Atten2AddingDate1 = Atten2AddingDate; })); }
            TextBox Atten1ID1 = new TextBox();
            if (Atten1ID.InvokeRequired) { Atten1ID.Invoke(new MethodInvoker(delegate { Atten1ID1 = Atten1ID; })); }
          
            //CLS_FRMS.CLSATTENDENCE Atten1GettingData = new CLS_FRMS.CLSATTENDENCE();
            //DataTable Dt = Atten1GettingData.Syntax1(Atten1SheftName1);

            CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
            DataTable Dt2 = At2GettingData.Attendence2GettingData(Atten2ID1, Atten2IDcon1, Atten2EmpName1, Atten2EmpBarcode1, Atten2EmpSheft1, Atten2WorkType1,
            Atten2TimeIn1, Atten2TimeOut1, Atten2HourCount1, Atten2EmpType1, Atten2Notice1, Atten2RegisterName1, Atten2AddingTime1, Atten2AddingDate1,
            int.Parse(Atten1ID1.Text));
            DataTable Dt3 = Dt2.Copy();
            Dt3.Clear();
          
                for (int i = 0; i < Dt2.Rows.Count; i++)
                {
                        lbatten.Invoke(new MethodInvoker(delegate { lbatten.Text = i.ToString(); }));
                        bgwatten.ReportProgress(i);
                        atten2dgv.Invoke((MethodInvoker)delegate
                        {
                            Dt3.ImportRow(Dt2.Rows[i]);
                            CLS_FRMS.CLSATTENDENCE dgv = new CLS_FRMS.CLSATTENDENCE();
                            dgv.dgvdesign(atten2dgv, Dt3);
                        });
                

                        int sum = 0;
                        for (int k = 0; k < 200000000; k++)
                        {
                            sum = sum + k;
                        }
                 }
         
        }
        private void bgwatten_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string Atten1SheftName1 = "";
            if (Atten1SheftName.InvokeRequired) { Atten1SheftName.Invoke(new MethodInvoker(delegate { Atten1SheftName1 = Atten1SheftName.Text; })); }
           

           
            CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
            DataTable Dt2 = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                int.Parse( Atten1ID.Text));

            ns1.BunifuProgressBar pbatten1 = new ns1.BunifuProgressBar ();
            if (pbatten2.InvokeRequired) { pbatten2.Invoke(new MethodInvoker(delegate { pbatten1 = pbatten2; })); }
            Label lbatten1 = new Label();
            if (lbatten.InvokeRequired) { lbatten.Invoke(new MethodInvoker(delegate { lbatten1 = lbatten; })); }
                     
                pbatten2.MaximumValue = Dt2.Rows.Count;
                pbatten2.Value = e.ProgressPercentage;
                if (pbatten2.Value == pbatten2.MaximumValue -1)
                {
                    
                    pbatten2.Visible = false;
                    lbatten.Visible = false;
                    pbatten2.Value = 0;
                }                  
        }

        private void dgvsheft1_SelectionChanged(object sender, EventArgs e)
            {
                if (Atten1ID.Text == "" || Atten1ID.Text == null)
                {

                }
                else
                {
                    CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
                    DataTable Dt = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                         Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                         int.Parse(Atten1ID.Text));
                    At2GettingData.dgvdesign(atten2dgv, Dt);
                }

         }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            
             CLS_FRMS.CLSATTENDENCE Atten1GettingData = new CLS_FRMS.CLSATTENDENCE();
                DataTable Dt = Atten1GettingData.Syntax1(Atten1SheftName.Text,Atten1SheftDateStart.Value);
            
            CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
                DataTable Dt2 = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                    Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                    int.Parse(Atten1ID.Text));
               
                if (Dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        bool flag = false;
                        for (int j = 0; j < Dt2.Rows.Count; j++)
                        {
                            if (Dt.Rows[i][2].ToString() == Dt2.Rows[j][3].ToString())
                            {
                                flag = true;
                            }

                        }
                        if (flag == false)
                        {
                            Atten2EmpName.Text = Dt.Rows[i][1].ToString();
                            Atten2EmpBarcode.Text = Dt.Rows[i][2].ToString();
                            Atten2EmpSheft.Text = Dt.Rows[i][0].ToString();
                            CLS_FRMS.CLSATTENDENCE Atinsert = new CLS_FRMS.CLSATTENDENCE();
                            Atinsert.SyntaxAdd(int.Parse(Atten1ID.Text), Atten2EmpName.Text, Atten2EmpBarcode.Text, Atten2EmpSheft.Text);
                                                
                        }
                                            
                    }
                }
                else
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                       
                        Atten2EmpName.Text = Dt.Rows[i][1].ToString();
                        Atten2EmpBarcode.Text = Dt.Rows[i][2].ToString();
                        Atten2EmpSheft.Text = Dt.Rows[i][0].ToString();
                        CLS_FRMS.CLSATTENDENCE Atinsert = new CLS_FRMS.CLSATTENDENCE();
                        Atinsert.SyntaxAdd(int.Parse(Atten1ID.Text), Atten2EmpName.Text, Atten2EmpBarcode.Text, Atten2EmpSheft.Text);
                                         
                    }
                }


                if (bgwatten.IsBusy) { }
                else
                {
                    pbatten2.Visible = true;
                    lbatten.Visible = true;
                   bgwatten.RunWorkerAsync();

                }
            }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            
            
            if (bgwatten.IsBusy) { }
            else
            {
                lbatten.Invoke(new MethodInvoker(delegate { lbatten.Visible = true; }));
                pbatten2.Invoke(new MethodInvoker(delegate { pbatten2.Visible = true; }));
                bgwatten.RunWorkerAsync();
            }
           
        }

        private void pbatten_Click(object sender, EventArgs e)
        {

        }
        //==============================================================================================================================================
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSATTENDENCE SH = new CLS_FRMS.CLSATTENDENCE();
            DataTable Dt1 = SH.SyntaxHolday();

            CLS_FRMS.CLSATTENDENCE At2GettingData = new CLS_FRMS.CLSATTENDENCE();
            DataTable Dt2 = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                int.Parse(Atten1ID.Text));

            CLS_FRMS.CLSATTENDENCE At2Variables = new CLS_FRMS.CLSATTENDENCE();
            DataTable Dt3 = At2Variables.SyntaxVariables();

            // Checking for Dawryia to insert it to the Attendence2 Table .. ..........
            if (Dt2.Rows.Count > 0)
            {

                for (int i = 0; i < Dt1.Rows.Count; i++)
                {

                    for (int j = 0; j < Dt2.Rows.Count; j++)
                    {
                        // Check And Adding The WorkType to The Attendence2 Table......
                        if (Dt1.Rows[i][1].ToString() == Dt2.Rows[j][3].ToString())
                        {
                            Atten2IDcon.Text = Dt2.Rows[j][1].ToString();
                            Atten2EmpBarcode.Text = Dt1.Rows[i][1].ToString();
                            Atten2WorkType.Text = Dt1.Rows[i][3].ToString();

                            CLS_FRMS.CLSATTENDENCE UpdateSyntax = new CLS_FRMS.CLSATTENDENCE();
                            UpdateSyntax.SyntaxWorkTypeInsert(Atten2EmpBarcode.Text, Atten2WorkType.Text, int.Parse(Atten2IDcon.Text));


                        }
                        // End Checking......

                        // Check And Adding The EmployeeType As a HolyDay To The Attendence2 Table .......
                        if (Dt1.Rows[i][1].ToString() == Dt2.Rows[j][3].ToString() && Dt1.Rows[i][2].ToString() == Atten1SheftDay.Text)
                        {
                            Atten2ID.Text = Dt2.Rows[j][0].ToString();
                            Atten2EmpType.Text = "دورية";

                            CLS_FRMS.CLSATTENDENCE At2Update1 = new CLS_FRMS.CLSATTENDENCE();
                            At2Update1.SyntaxAddHolyDay(int.Parse(Atten2ID.Text), Atten2EmpType.Text);


                        }
                        // End Checking.....

                    }
                }

                // Checking And Adding Variables To The Attendence2 Table ........
                for (int i = 0; i < Dt3.Rows.Count; i++)
                {
                    for (int j = 0; j < Dt2.Rows.Count; j++)
                    {
                        if (Dt3.Rows[i][0].ToString() == Dt2.Rows[j][2].ToString())
                        {
                            Atten2ID.Text = Dt2.Rows[i][0].ToString();
                            Atten2EmpType.Text = Dt3.Rows[i][1].ToString();

                            CLS_FRMS.CLSATTENDENCE At2Update = new CLS_FRMS.CLSATTENDENCE();
                            At2Update.syntaxAddVariables(int.Parse(Atten2ID.Text), Atten2EmpType.Text);
                        }
                    }
                }
                // End Checking Variables..........

                // Checking And Adding Rest To The Attendence2 Table ........   
                Dt2 = At2GettingData.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                   Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                   int.Parse(Atten1ID.Text));

                for (int i = 0; i < Dt2.Rows.Count; i++)
                {


                if (Dt2.Rows[i][5].ToString() == "14")
                {
                    DateTime date = Atten1SheftDateStart.Value.AddDays(-1);
                    CLS_FRMS.CLSATTENDENCE At2Update = new CLS_FRMS.CLSATTENDENCE();
                    DataTable dt = At2Update.SelectEmployeeTypeByDate(Dt2.Rows[i][2].ToString(), date.Date);

                    if (dt.Rows.Count > 0 && (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == ""))
                    {
                        Atten2ID.Text = Dt2.Rows[i][0].ToString();
                        Atten2EmpType.Text = "استراحة";
                        MessageBox.Show(Atten2ID.Text.ToString());
                        CLS_FRMS.CLSATTENDENCE At2Update1 = new CLS_FRMS.CLSATTENDENCE();
                        At2Update1.SyntaxAddHolyDay(int.Parse(Atten2ID.Text), Atten2EmpType.Text);
                    }
                }
                if (Dt2.Rows[i][5].ToString() == "24")
                {
                    CLS_FRMS.CLSATTENDENCE At2Update = new CLS_FRMS.CLSATTENDENCE();
                    DateTime date =Atten1SheftDateStart.Value.AddDays(-1);

                    DataTable dt = At2Update.SelectEmployeeTypeByDate(Dt2.Rows[i][2].ToString(), date.Date);

                    DateTime date1 = Atten1SheftDateStart.Value.AddDays(-2);

                    DataTable dt1 = At2Update.SelectEmployeeTypeByDate(Dt2.Rows[i][2].ToString(), date1.Date);
                        
                    if ((dt.Rows.Count > 0 && (dt.Rows[0][0] == null || dt.Rows[0][0].ToString() == "")) || (dt1.Rows.Count > 0 && (dt1.Rows[0][0] == null || dt1.Rows[0][0].ToString() == "")))
                    {
                        Atten2ID.Text = Dt2.Rows[i][0].ToString();
                        Atten2EmpType.Text = "استراحة";

                        CLS_FRMS.CLSATTENDENCE At2Update1 = new CLS_FRMS.CLSATTENDENCE();
                        At2Update1.SyntaxAddHolyDay(int.Parse(Atten2ID.Text), Atten2EmpType.Text);
                    }
                }



            }
              

                // End Checking Rest..........
            }
            else
            {
                MessageBox.Show("قم بأضافة الوجبة اولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
            if (bgwatten.IsBusy)
            {

            }
            else
            {
                lbatten.Invoke(new MethodInvoker(delegate { lbatten.Visible = true; }));
                pbatten2.Invoke(new MethodInvoker(delegate { pbatten2.Visible = true; }));
                bgwatten.RunWorkerAsync();
            }
       }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            BarcodeSearching.Text = null;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //=== This function below for add time of come and go for one employee in one sheft in the Attendence2 table 
            CLS_FRMS.CLSATTENDENCE At2Update1 = new CLS_FRMS.CLSATTENDENCE();
            DataTable dt=At2Update1.SelectEmployeeByBarcode(BarcodeSearching.Text, Atten1SheftDateStart.Value, Atten1SheftName.Text);

            string RegisterName = Properties.Settings.Default.UserNameLogin.ToString();
            string RegisterTime = DateTime.Now.ToString("hh:mm tt");
            string RegisterDate = DateTime.Now.ToString("yyyy/MM/dd");
            bool flag = true;
            //=== detect if employee rest or off or not 
            if (dt.Rows[0][3] != null  && dt.Rows[0][3].ToString() != "" && (dt.Rows[0][1].ToString() == "" || dt.Rows[0][1] == null))
            {
                DialogResult dialogResult = MessageBox.Show("هذا المنتسب اليوم "+dt.Rows[0][3].ToString()+"هل تريد اضافته!", "تأكييد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    flag = false;
                }
            }
            if (flag == true)
            {
                //=== detect if this time of come or go
                if (dt.Rows[0][1] == null || dt.Rows[0][1].ToString() == "")
                {
                    At2Update1.addTimeIn(int.Parse(dt.Rows[0][0].ToString()), Atten2Notice.Text, RegisterName, RegisterTime, RegisterDate,int.Parse(dt.Rows[0][5].ToString()));
                }
                else
                {

                    if (dt.Rows[0][2].ToString() == "" || dt.Rows[0][2].ToString() == null)
                    {
                        DateTime time = Convert.ToDateTime(dt.Rows[0][1].ToString());
                       

                        At2Update1.addTimeout(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), Atten2Notice.Text, Convert.ToDateTime(dt.Rows[0][4]),
                             RegisterName, RegisterTime, RegisterDate, int.Parse(dt.Rows[0][5].ToString()));
                    }
                }
            }
            DataTable Dt = At2Update1.Attendence2GettingData(Atten2ID, Atten2IDcon, Atten2EmpName, Atten2EmpBarcode, Atten2EmpSheft, Atten2WorkType,
                     Atten2TimeIn, Atten2TimeOut, Atten2HourCount, Atten2EmpType, Atten2Notice, Atten2RegisterName, Atten2AddingTime, Atten2AddingDate,
                     int.Parse(Atten1ID.Text));
            At2Update1.dgvdesign(atten2dgv, Dt);
            BarcodeSearching.Text = null;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //=== This function below for add notice for one employee in one sheft in the Attendence2 table 
            if (Atten2HourCount.Text==null || Atten2HourCount.Text == "")
                 Atten2HourCount.Text = "0";
            CLS_FRMS.CLSATTENDENCE At2Update1 = new CLS_FRMS.CLSATTENDENCE();
            At2Update1.Attendence2UpdateData(int.Parse(Atten2IDcon.Text), Atten2EmpName.Text, Atten2EmpBarcode.Text, Atten2EmpSheft.Text, Atten2WorkType.Text, Atten2TimeIn.Text
            , Atten2TimeOut.Text, Atten2HourCount.Text, Atten2EmpType.Text, Atten2Notice.Text, Atten2RegisterName.Text, Atten2AddingTime.Text, Atten2AddingDate.Text
            , int.Parse(Atten2ID.Text));
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            //=== This function below for Deleting Data from the Attendence2 table for one employee
            CLS_FRMS.CLSATTENDENCE At2Delete = new CLS_FRMS.CLSATTENDENCE();
            At2Delete.Attendence2DeletingData(int.Parse(Atten2ID.Text));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //=== This function below for Deleting Data from the Attendence2 table for all employee in sheft
            CLS_FRMS.CLSATTENDENCE At2Delete = new CLS_FRMS.CLSATTENDENCE();
            At2Delete.Attendence2DeletingDataBySheft(Atten1SheftName.Text,Atten1SheftDateStart.Value);
        }

        private void dgvsheft1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Atten1ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarcodeSearching_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (atten2dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[EmployeeBarcode] like '%{0}%'", BarcodeSearching.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Atten1SheftDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Atten1SheftDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Atten1SheftName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Atten1AddingDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten1AddingTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten1RegisterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbatten2_progressChanged(object sender, EventArgs e)
        {

        }

        private void lbatten_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void atten2dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Atten2Notice_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2AddingDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2AddingTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2RegisterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2IDcon_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2HourCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2TimeOut_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2TimeIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2EmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2EmpType_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2EmpBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2EmpSheft_TextChanged(object sender, EventArgs e)
        {

        }

        private void Atten2WorkType_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Timestart_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TimeEnd_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void BarcodeSearching_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }


        //=============================
    }
}

