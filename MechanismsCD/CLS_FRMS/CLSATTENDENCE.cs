using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace MechanismsCD.CLS_FRMS
{
    class CLSATTENDENCE
    {



        public DataTable EmployeesSheft1GetData(DataGridView dgv, TextBox tbid, ComboBox tbnameofwajba, DateTimePicker tbfromdate
            , DateTimePicker tbtodate, TextBox tbregistername, TextBox tbaddingtime, TextBox tbaddingdate)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeesSheftSelect", null);
            dal.close();

            dgv.DataSource = null;
            dgv.DataSource = Dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "الوجبة";
            for (int i = 2; i < 7; i++)
            {
                dgv.Columns[i].Visible = false;
            }


            tbid.DataBindings.Clear(); tbnameofwajba.DataBindings.Clear(); tbfromdate.DataBindings.Clear();
            tbtodate.DataBindings.Clear(); tbregistername.DataBindings.Clear(); tbaddingdate.DataBindings.Clear();
            tbaddingtime.DataBindings.Clear();

            string str = "text";
            tbid.DataBindings.Add(str, Dt, "ID");
            tbnameofwajba.DataBindings.Add(str, Dt, "NameofSheft");
            tbfromdate.DataBindings.Add(str, Dt, "FromDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tbtodate.DataBindings.Add(str, Dt, "ToDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tbregistername.DataBindings.Add(str, Dt, "RegisterName");
            tbaddingtime.DataBindings.Add(str, Dt, "AddingTime");
            tbaddingdate.DataBindings.Add(str, Dt, "AddingDate");

            string[] strr = new string[3];
            strr[0] = "الوجبة الصباحية"; strr[1] = "الوجبة المسائية"; strr[2] = "الوجبة الليلية";
            tbnameofwajba.Items.Clear();
            tbnameofwajba.Items.AddRange(strr);

            return Dt;
        }
        //===========================================================================================================
        //=== This function below for Updating data of EmployeesSheft1 Table by Using EmployeesSheftUpdate procedure....
        public void EmployeesSheft1Update(int ID, string Nameofsheft, string FromDate, string ToDate, string registerName,
            string AddingTime, string AddingDate)
        {
            DAL.DataAccessLayer Updatesheft = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = ID;
            param[1] = new SqlParameter("@NameofSheft", SqlDbType.NVarChar, 50); param[1].Value = Nameofsheft;
            param[2] = new SqlParameter("@FromDate", SqlDbType.VarChar, 50); param[2].Value = FromDate;
            param[3] = new SqlParameter("@ToDate", SqlDbType.VarChar, 50); param[3].Value = ToDate;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[4].Value = registerName;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[5].Value = AddingTime;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[6].Value = AddingDate;
            Updatesheft.open();
            Updatesheft.ExecuteCommand("EmployeesSheftUpdate", param);
            Updatesheft.close();
        }
        //=================================================================================================================
        //=== This function below for Getting Data from EmployeesSheft2 Table by Using EmployeesSheft2Select Procedure
        public DataTable EmployeesSheft2GetData(DataGridView dgvsheft2, TextBox Idsheft2, TextBox Idconsheft2, ComboBox Namesheft2, TextBox Barcodesheft2
            , TextBox RegisterNamesheft2, TextBox Addingtimesheft2, TextBox AddingDateSheft2, int IDconnection)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDconnection;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeesSheft2Select", param);
            dal.close();

            Idsheft2.DataBindings.Clear(); Idconsheft2.DataBindings.Clear(); Namesheft2.DataBindings.Clear(); Barcodesheft2.DataBindings.Clear();
            RegisterNamesheft2.DataBindings.Clear(); Addingtimesheft2.DataBindings.Clear(); AddingDateSheft2.DataBindings.Clear();

            dgvsheft2.DataSource = null;
            dgvsheft2.DataSource = Dt;
            for (int i = 0; i <= 6; i++)
            {
                if (i == 2)
                    dgvsheft2.Columns[i].HeaderText = "الاسم";
                else
                    dgvsheft2.Columns[i].Visible = false;
            }
            dgvsheft2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string st = "text";
            Idsheft2.DataBindings.Add(st, Dt, "ID"); Idsheft2.Visible = false;
            Idconsheft2.DataBindings.Add(st, Dt, "IDcon"); Idconsheft2.Visible = false;
            Namesheft2.DataBindings.Add(st, Dt, "EmpName");
            Barcodesheft2.DataBindings.Add(st, Dt, "EmpBarcode");
            RegisterNamesheft2.DataBindings.Add(st, Dt, "RegisterName"); RegisterNamesheft2.Visible = false;
            Addingtimesheft2.DataBindings.Add(st, Dt, "AddingTime"); Addingtimesheft2.Visible = false;
            AddingDateSheft2.DataBindings.Add(st, Dt, "AddingDate"); AddingDateSheft2.Visible = false;

            CLS_FRMS.CLSCONSTENTRY GetEmpName = new CLSCONSTENTRY();
            DataTable Empname = GetEmpName.GetnameEmployees();
            Namesheft2.Items.Clear();
            for (int i = 0; i < Empname.Rows.Count; i++)
            {
                Namesheft2.Items.Add(Empname.Rows[i][0].ToString());
            }

            return Dt;
        }
        //==========================================================================================================================
        // This function Below for insert Data to the EmployeesSheft2 Table by Using the Employeessheft2Insert Procedure....
        public void EmployeesSheft2Insert(int IDcon, string EmpName, string EmpBarcode, string RegisterName, string AddingTime, string AddingDate)
        {
            DAL.DataAccessLayer Insertdata = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = EmpName;
            param[2] = new SqlParameter("@EmpBarcode", SqlDbType.VarChar, 50); param[2].Value = EmpBarcode;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[3].Value = RegisterName;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[4].Value = AddingTime;
            param[5] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[5].Value = AddingDate;

            Insertdata.open();
            Insertdata.ExecuteCommand("EmployeesSheft2Insert", param);
            Insertdata.close();

        }
        //============================================================================================================================
        //=== this function below for Updating Data of Employeessheft2 Table by using Employeessheft2Update Procedure.....
        public void EmployeesSheft2Update(int IDUpdate, int IDcon, string EmpName, string EmpBarcode, string RegisterName, string AddingTime, string AddingDate)
        {
            DAL.DataAccessLayer UpdateDate = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = EmpName;
            param[2] = new SqlParameter("@EmpBarcode", SqlDbType.VarChar, 50); param[2].Value = EmpBarcode;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[3].Value = RegisterName;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[4].Value = AddingTime;
            param[5] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[5].Value = AddingDate;
            param[6] = new SqlParameter("@IDUpdate", SqlDbType.Int); param[6].Value = IDUpdate;

            UpdateDate.open();
            UpdateDate.ExecuteCommand("EmployeesSheft2Update", param);
            UpdateDate.close();
        }
        //=============================================================================================================================
        //== This function below for Delete Data from Employeessheft2 table by using Employeessheft2Delete Procedure.....
        public void EmployeesSheft2Delete(int IDdelete)
        {
            DAL.DataAccessLayer DeleteData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDDelete", SqlDbType.Int); param[0].Value = IDdelete;
            DeleteData.open();
            DeleteData.ExecuteCommand("EmployeessSheft2Delete", param);
            DeleteData.close();
        }
        //=============================================================================================================================
        //=== This function below for Getting Data from Employeessheft1 Table by using EmpsheftGetDate Procedure......
        public DataTable EmpSheftGetData(DataGridView dgv)
        {
            DAL.DataAccessLayer Sheft1GetData = new DAL.DataAccessLayer();
            Sheft1GetData.open();
            DataTable Dt = Sheft1GetData.SelectingData("EmpSheftGetDate", null);
            Sheft1GetData.close();
            dgv.DataBindings.Clear();
            dgv.DataSource = Dt;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "اسم المنتسب";
            dgv.Columns[2].HeaderText = "باركود المنتسب";
            dgv.Columns[3].HeaderText = "الوجبة";
            dgv.Columns[4].HeaderText = "من تاريخ";
            dgv.Columns[5].HeaderText = "الى تاريخ";
            dgv.Columns[6].HeaderText = "الملاحظات";
            dgv.Columns[7].Visible = false;
            dgv.Columns[8].Visible = false;
            dgv.Columns[9].Visible = false;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            return Dt;
        }
        //=============================================================================================================================
        // This function below for insert Data to the EmployeesSheft1 Table by Using EmpsheftInsert Procedure......
        public void EmpSheftinsertData(string PerName, string PerBarcode, string Persheft, string FromDate, string ToDate
            , string PerNotice, string RegisterName, string AddingTime, string AddingDate)
        {
            DAL.DataAccessLayer Empsheftinsert = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@PerName", SqlDbType.VarChar, 50); param[0].Value = PerName;
            param[1] = new SqlParameter("@PerBarcode", SqlDbType.VarChar, 50); param[1].Value = PerBarcode;
            param[2] = new SqlParameter("@Persheft", SqlDbType.VarChar, 50); param[2].Value = Persheft;
            param[3] = new SqlParameter("@FromDate", SqlDbType.VarChar, 50); param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.VarChar, 50); param[4].Value = ToDate;
            param[5] = new SqlParameter("@PerNotice", SqlDbType.VarChar, 50); param[5].Value = PerNotice;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;

            Empsheftinsert.open();
            Empsheftinsert.ExecuteCommand("EmpSheftInsert", param);
            Empsheftinsert.close();

        }
        //===============================================================================================================================
        //===This function below for Updating data of EmployeesSheft1 Table by Using EmpSheftUpdate Procedure.....
        public void EmpSheftUpdateData(string PerName, string PerBarcode, string Persheft, string FromDate, string ToDate
           , string PerNotice, string RegisterName, string AddingTime, string AddingDate, int ID)
        {
            DAL.DataAccessLayer Empsheftinsert = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@PerName", SqlDbType.VarChar, 50); param[0].Value = PerName;
            param[1] = new SqlParameter("@PerBarcode", SqlDbType.VarChar, 50); param[1].Value = PerBarcode;
            param[2] = new SqlParameter("@Persheft", SqlDbType.VarChar, 50); param[2].Value = Persheft;
            param[3] = new SqlParameter("@FromDate", SqlDbType.VarChar, 50); param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.VarChar, 50); param[4].Value = ToDate;
            param[5] = new SqlParameter("@PerNotice", SqlDbType.VarChar, 50); param[5].Value = PerNotice;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;
            param[9] = new SqlParameter("@ID", SqlDbType.Int); param[9].Value = ID;

            Empsheftinsert.open();
            Empsheftinsert.ExecuteCommand("EmpSheftUpdate", param);
            Empsheftinsert.close();

        }
        //===================================================================================================================================
        //======This function Below for Deleting Data from employeesSheft1 Table by Using EmpSheftDelete Procedure......
        public void EmpSheftDeleteData(int ID)
        {
            DAL.DataAccessLayer EmpSheftDelete = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = ID;
            EmpSheftDelete.open();
            EmpSheftDelete.ExecuteCommand("EmpSheftDelete", param);
            EmpSheftDelete.close();

        }
        //================================================================================================================
        //=== This function Below for GettingData from Attendence1 Table by using procedure Attendence1SelectingData.....
        public DataTable Attendence1SelectingData(DataGridView dgv, TextBox Atten1ID, DateTimePicker Atten1DateStart, DateTimePicker Atten1DateEnd, ComboBox Atten1SheftDay,
            ComboBox Atten1SheftName, TextBox Atten1RegisterName, TextBox Atten1AddingTime, TextBox Atten1AddingDate, DateTimePicker TimeStart, DateTimePicker TimeEnd, TextBox ExtraTime)
        {
            DAL.DataAccessLayer Atten1GettingData = new DAL.DataAccessLayer();
            Atten1GettingData.open();
            DataTable Dt = Atten1GettingData.SelectingData("Attendence1SelectingData", null);
            Atten1GettingData.close();
            Atten1ID.DataBindings.Clear(); Atten1DateStart.DataBindings.Clear(); Atten1DateEnd.DataBindings.Clear(); Atten1SheftDay.DataBindings.Clear();
            Atten1SheftName.DataBindings.Clear(); Atten1RegisterName.DataBindings.Clear(); Atten1AddingTime.DataBindings.Clear();
            Atten1AddingDate.DataBindings.Clear(); TimeStart.DataBindings.Clear(); TimeEnd.DataBindings.Clear();
            dgv.DataBindings.Clear(); ExtraTime.DataBindings.Clear();
            dgv.DataSource = Dt;

            for (int i = 0; i <= 10; i++)
            {
                if (i == 1) { dgv.Columns[i].HeaderText = "التاريخ"; }
                else if (i == 3) { dgv.Columns[i].HeaderText = "الوجبة"; }
                else if (i == 7) { dgv.Columns[i].HeaderText = "وقت الحضور"; }
                else if (i == 8) { dgv.Columns[i].HeaderText = "وقت الانصراف"; }
                else { dgv.Columns[i].Visible = false; }
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string st = "text";
            Atten1ID.DataBindings.Add(st, Dt, "ID");
            Atten1DateStart.DataBindings.Add(st, Dt, "SheftDateStart", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Atten1DateEnd.DataBindings.Add(st, Dt, "SheftDateEnd", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Atten1SheftDay.DataBindings.Add(st, Dt, "SheftDay");
            Atten1SheftName.DataBindings.Add(st, Dt, "SheftName");
            Atten1RegisterName.DataBindings.Add(st, Dt, "RegisterName");
            Atten1AddingTime.DataBindings.Add(st, Dt, "AddingTime");
            Atten1AddingDate.DataBindings.Add(st, Dt, "AddingDate");
            TimeStart.DataBindings.Add(st, Dt, "TimeStart");
            TimeEnd.DataBindings.Add(st, Dt, "TimeEnd");
            ExtraTime.DataBindings.Add(st, Dt, "ExtraTime");

            string[] st1 = new string[7];
            st1[0] = "الأحد"; st1[1] = "الإثنين"; st1[2] = "الثلاثاء"; st1[3] = "الأربعاء"; st1[4] = "الخميس"; st1[5] = "الجمعة"; st1[6] = "السبت";
            Atten1SheftDay.Items.Clear();
            Atten1SheftDay.Items.AddRange(st1);

            string[] st2 = new string[3];
            st2[0] = "الوجبة الصباحية"; st2[1] = "الوجبة المسائية"; st2[2] = "الوجبة الليلية";
            Atten1SheftName.Items.Clear();
            Atten1SheftName.Items.AddRange(st2);


            return Dt;
        }
        //===================================================================================================================================
        //==== This function below for insert Data to the Attendence1 Table by using stored procedure Attendence1insertData ......
        public void Attendence1insertData(string Atten1SheftDateStart, string Atten1SheftDateEnd, string Atten1SheftDay, string Atten1SheftName, string Atten1registername
            , string Atten1AddingTime, string Atten1AddingDate, string TimeStart, string TimeEnd, double ExtreaTime)
        {
            DAL.DataAccessLayer Atten1insertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@SheftDateStart", SqlDbType.VarChar, 50);      param[0].Value = Atten1SheftDateStart;
            param[1] = new SqlParameter("@SheftDateEnd", SqlDbType.VarChar, 50);        param[1].Value = Atten1SheftDateEnd;
            param[2] = new SqlParameter("@SheftDay", SqlDbType.VarChar, 50);            param[2].Value = Atten1SheftDay;
            param[3] = new SqlParameter("@SheftName", SqlDbType.VarChar, 50);           param[3].Value = Atten1SheftName;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[4].Value = Atten1registername;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[5].Value = Atten1AddingTime;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);          param[6].Value = Atten1AddingDate;
            param[7] = new SqlParameter("@TimeStart", SqlDbType.VarChar, 50);           param[7].Value = TimeStart;
            param[8] = new SqlParameter("@TimeEnd", SqlDbType.VarChar, 50);             param[8].Value = TimeEnd;
            param[9] = new SqlParameter("@extraTime", SqlDbType.Real);             param[9].Value = ExtreaTime;
            Atten1insertData.open();
            Atten1insertData.ExecuteCommand("Attendence1InsertData", param);
            Atten1insertData.close();

        }
        //====================================================================================================================================
        // This function below for Updating Data of Attendence1 Table by using Stored Procedure Attendence1UpdatData ......
        public void Attendence1UpdateData(string Atten1SheftDateStart, string Atten1SheftDateEnd, string Atten1SheftDay, string Atten1SheftName, string Atten1registername
           , string Atten1AddingTime, string Atten1AddingDate, int Atten1ID, string TimeStart, string TimeEnd, double ExtraTime)
        {
            DAL.DataAccessLayer Atten1insertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@IDAtte1", SqlDbType.Int);                     param[0].Value = Atten1ID;
            param[1] = new SqlParameter("@SheftDateStart", SqlDbType.VarChar, 50);      param[1].Value = Atten1SheftDateStart;
            param[2] = new SqlParameter("@SheftDateEnd", SqlDbType.VarChar, 50);        param[2].Value = Atten1SheftDateEnd;
            param[3] = new SqlParameter("@SheftDay", SqlDbType.VarChar, 50);            param[3].Value = Atten1SheftDay;
            param[4] = new SqlParameter("@SheftName", SqlDbType.VarChar, 50);           param[4].Value = Atten1SheftName;
            param[5] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[5].Value = Atten1registername;
            param[6] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[6].Value = Atten1AddingTime;
            param[7] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);          param[7].Value = Atten1AddingDate;      
            param[8] = new SqlParameter("@TimeStart", SqlDbType.VarChar, 50);           param[8].Value = TimeStart;
            param[9] = new SqlParameter("@TimeEnd", SqlDbType.VarChar, 50);             param[9].Value = TimeEnd;
            param[10] = new SqlParameter("@ExtraTime", SqlDbType.Real);             param[10].Value = ExtraTime;
            Atten1insertData.open();
            Atten1insertData.ExecuteCommand("Attendence1UpdateData", param);
            Atten1insertData.close();

        }
        //====================================================================================================================================
        // === This function Below for Deleting Data from Attendence1 Table by Using Strored Procedure Attendence1DeleteData .....
        public void Attendence1DeleteData(int Atten1ID)
        {
            DAL.DataAccessLayer Atten1insertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDAtte1", SqlDbType.Int); param[0].Value = Atten1ID;
            Atten1insertData.open();
            Atten1insertData.ExecuteCommand("Attendence1DeleteData", param);
            Atten1insertData.close();

        }
        //=====================================================================================================================================
        //==== This function below for Getting data from Attendence2 Table By Using the Stored Procedure Attendence2Selecting.....
        public DataTable Attendence2GettingData(TextBox Atten2ID, TextBox Atten2IDcon, TextBox Atten2EmpName, TextBox Atten2EmpBarcode, TextBox Atten2EmpSheft
            , TextBox Atten2Worktype, TextBox TimeIn, TextBox TimeOut, TextBox Atten2Hourcount, TextBox Atten2Emptype, RichTextBox Atten2Notice, TextBox Atten2RegisterName
            , TextBox Atten2AddingTime, TextBox Atten2AddingDate, int IDconnection)
        {
            DAL.DataAccessLayer Atten2SelectingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDconnection;
            Atten2SelectingData.open();
            DataTable Dt = Atten2SelectingData.SelectingData("Attendence2Selecting", param);
            Atten2SelectingData.close();

            Atten2ID.DataBindings.Clear(); Atten2IDcon.DataBindings.Clear(); Atten2EmpName.DataBindings.Clear(); Atten2EmpBarcode.DataBindings.Clear();
            Atten2EmpSheft.DataBindings.Clear(); Atten2Worktype.DataBindings.Clear(); TimeIn.DataBindings.Clear(); TimeOut.DataBindings.Clear();
            Atten2Hourcount.DataBindings.Clear(); Atten2Emptype.DataBindings.Clear(); Atten2Notice.DataBindings.Clear(); Atten2RegisterName.DataBindings.Clear();
            Atten2AddingTime.DataBindings.Clear(); Atten2AddingDate.DataBindings.Clear();



            string st = "text";
            Atten2ID.Invoke(new MethodInvoker(delegate { Atten2ID.DataBindings.Add(st, Dt, "IDAtte2"); }));
            Atten2IDcon.Invoke(new MethodInvoker(delegate { Atten2IDcon.DataBindings.Add(st, Dt, "IDcon"); }));
            Atten2EmpName.Invoke(new MethodInvoker(delegate { Atten2EmpName.DataBindings.Add(st, Dt, "EmployeeName"); }));
            Atten2EmpBarcode.Invoke(new MethodInvoker(delegate { Atten2EmpBarcode.DataBindings.Add(st, Dt, "EmployeeBarcode"); }));
            Atten2EmpSheft.Invoke(new MethodInvoker(delegate { Atten2EmpSheft.DataBindings.Add(st, Dt, "EmployeeSheft"); }));
            Atten2Worktype.Invoke(new MethodInvoker(delegate { Atten2Worktype.DataBindings.Add(st, Dt, "WorkType"); }));
            TimeIn.Invoke(new MethodInvoker(delegate { TimeIn.DataBindings.Add(st, Dt, "TimeIn"); }));
            TimeOut.Invoke(new MethodInvoker(delegate { TimeOut.DataBindings.Add(st, Dt, "TimeOut"); }));
            Atten2Hourcount.Invoke(new MethodInvoker(delegate { Atten2Hourcount.DataBindings.Add(st, Dt, "HourCount"); }));
            Atten2Emptype.Invoke(new MethodInvoker(delegate { Atten2Emptype.DataBindings.Add(st, Dt, "EmployeeType"); }));
            Atten2Notice.Invoke(new MethodInvoker(delegate { Atten2Notice.DataBindings.Add(st, Dt, "Notice"); }));
            Atten2RegisterName.Invoke(new MethodInvoker(delegate { Atten2RegisterName.DataBindings.Add(st, Dt, "RegisterName"); }));
            Atten2AddingTime.Invoke(new MethodInvoker(delegate { Atten2AddingTime.DataBindings.Add(st, Dt, "AddingTime"); }));
            Atten2AddingDate.Invoke(new MethodInvoker(delegate { Atten2AddingDate.DataBindings.Add(st, Dt, "AddingDate"); }));


            return Dt;
        }
        //=============================================================================================================================
        //== This function below for inserting Data to  the Attendence2 Table By Using The Stored Procedure Attendence2InsertData.....
        public void Attendence2InsertingData(int Atten2IDcon, string Atten2EmpName, string Atten2EmpBarcode, string Atten2EmpSheft, string Atten2WorkType, string TimeIn
            , string TimeOut, float Atten2HourCount, string Atten2EmpType, string Atten2Notice, string Atten2RegisterName, string Atten2AddingTime, string Atten2AddingDate)

        {
            DAL.DataAccessLayer Atten2InsertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = Atten2IDcon;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = Atten2EmpName;
            param[2] = new SqlParameter("@EmployeeBarcode", SqlDbType.VarChar, 50); param[2].Value = Atten2EmpBarcode;
            param[3] = new SqlParameter("@EmployeeSheft", SqlDbType.VarChar, 50); param[3].Value = Atten2EmpSheft;
            param[4] = new SqlParameter("@WorkType", SqlDbType.VarChar, 50); param[4].Value = Atten2WorkType;
            param[5] = new SqlParameter("@TimeIn", SqlDbType.VarChar, 50); param[5].Value = TimeIn;
            param[6] = new SqlParameter("@TimeOut", SqlDbType.VarChar, 50); param[6].Value = TimeOut;
            param[7] = new SqlParameter("@HourCount", SqlDbType.Real); param[7].Value = Atten2HourCount;
            param[8] = new SqlParameter("@EmployeeType", SqlDbType.VarChar, 50); param[8].Value = Atten2EmpType;
            param[9] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[9].Value = Atten2Notice;
            param[10] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[10].Value = Atten2RegisterName;
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[11].Value = Atten2AddingTime;
            param[12] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[12].Value = Atten2AddingDate;

            Atten2InsertData.open();
            Atten2InsertData.ExecuteCommand("Attendence2InsertData", param);
            Atten2InsertData.close();

        }
        //=================================================================================================================================
        //=== This function below for Updating Data of Attendence2 Table by using the stored procedure Attendence2UpdateData....
        public void Attendence2UpdateData(int Atten2IDcon, string Atten2EmpName, string Atten2EmpBarcode, string Atten2EmpSheft, string Atten2WorkType, string TimeIn
            , string TimeOut, string Atten2HourCount, string Atten2EmpType, string Atten2Notice, string Atten2RegisterName, string Atten2AddingTime, string Atten2AddingDate
            , int Atten2ID)

        {
            DAL.DataAccessLayer Atten2UpdatetData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[1] = new SqlParameter("@IDcon", SqlDbType.Int); param[1].Value = Atten2IDcon;
            param[2] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[2].Value = Atten2EmpName;
            param[3] = new SqlParameter("@EmployeeBarcode", SqlDbType.VarChar, 50); param[3].Value = Atten2EmpBarcode;
            param[4] = new SqlParameter("@EmployeeSheft", SqlDbType.VarChar, 50); param[4].Value = Atten2EmpSheft;
            param[5] = new SqlParameter("@WorkType", SqlDbType.VarChar, 50); param[5].Value = Atten2WorkType;
            param[6] = new SqlParameter("@TimeIn", SqlDbType.VarChar, 50); param[6].Value = TimeIn;
            param[7] = new SqlParameter("@TimeOut", SqlDbType.VarChar, 50); param[7].Value = TimeOut;
            param[8] = new SqlParameter("@HourCount", SqlDbType.Real); param[8].Value = Atten2HourCount;
            param[9] = new SqlParameter("@EmployeeType", SqlDbType.VarChar, 50); param[9].Value = Atten2EmpType;
            param[10] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[10].Value = Atten2Notice;
            param[11] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[11].Value = Atten2RegisterName;
            param[12] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[12].Value = Atten2AddingTime;
            param[13] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[13].Value = Atten2AddingDate;
            param[0] = new SqlParameter("@IDatten2", SqlDbType.Int); param[0].Value = Atten2ID;
            Atten2UpdatetData.open();
            Atten2UpdatetData.ExecuteCommand("Attendence2UpdateData", param);
            Atten2UpdatetData.close();

        }
        //=========================================================================================================================================
        //=== This function below for Deleting Data from the Attendence2 table by using the stored procedure Attendence2DeletingData.....
        public void Attendence2DeletingData(int Atten2ID)

        {
            DAL.DataAccessLayer Atten2DeleteData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDAtte2", SqlDbType.Int); param[0].Value = Atten2ID;
            Atten2DeleteData.open();
            Atten2DeleteData.ExecuteCommand("Attendence2DeletingData", param);
            Atten2DeleteData.close();

        }
        //=========================================================================================================================================
        //=== This function below for Deleting Data from the Attendence2 table by Shift and Date by using the stored procedure Attendence2DeletingDataBySheft.....
        public void Attendence2DeletingDataBySheft(string SheftName, DateTime date)

        {
            DAL.DataAccessLayer Atten2DeleteData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date", SqlDbType.Date); param[0].Value = date;
            param[1] = new SqlParameter("@ShiftName", SqlDbType.VarChar, 50); param[1].Value = SheftName;
            Atten2DeleteData.open();
            Atten2DeleteData.ExecuteCommand("Attendence2DeletingDataBySheft", param);
            Atten2DeleteData.close();
        }
        //=========================================================================================================================================
        // == This Function below for asyntax Attendence  By using a Stored Procedure Syntax .......
        public DataTable Syntax1(string SheftName, DateTime date)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@SheftName", SqlDbType.VarChar, 50); param[0].Value = SheftName;
            param[1] = new SqlParameter("@Date", SqlDbType.Date); param[1].Value = date;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Syntax1", param);
            GettingData.close();
            return Dt;
        }
        //========================================================================================================================================
        //== This Function Below for Syntax of Dawryia And Worktype for the Attendence ......
        public DataTable SyntaxHolday()
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("SyntaxHolyday", null);
            GettingData.close();
            return Dt;
        }
        //=====================================================================================================================================
        //=== This Function Below for Syntax of Variables to the Attencence....
        public DataTable SyntaxVariables()
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("SyntaxVariables", null);
            GettingData.close();
            return Dt;
        }
        //=====================================================================================================================================
        public void SyntaxWorkTypeInsert(string EmpBarcode, string EmpWorkType, int IDcon)
        {
            DAL.DataAccessLayer insertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmpBarcode", SqlDbType.VarChar, 50); param[0].Value = EmpBarcode;
            param[1] = new SqlParameter("@EmpWorkType", SqlDbType.VarChar, 50); param[1].Value = EmpWorkType;
            param[2] = new SqlParameter("@IDcon", SqlDbType.Int); param[2].Value = IDcon;
            insertData.open();
            insertData.ExecuteCommand("SyntaxWorkTypeInsert", param);
            insertData.close();
        }
        //=========================================================================================================================================
        public void SyntaxAdd(int Atten2IDcon, string Atten2EmpName, string Atten2EmpBarcode, string Atten2EmpSheft)
        {
            DAL.DataAccessLayer insertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Atten2IDcon", SqlDbType.Int); param[0].Value = Atten2IDcon;
            param[1] = new SqlParameter("@Atten2EmpName", SqlDbType.VarChar, 50); param[1].Value = Atten2EmpName;
            param[2] = new SqlParameter("@Atten2EmpBarcode", SqlDbType.VarChar, 50); param[2].Value = Atten2EmpBarcode;
            param[3] = new SqlParameter("@Atten2EmpSheft", SqlDbType.VarChar, 50); param[3].Value = Atten2EmpSheft;
            insertData.open();
            insertData.ExecuteCommand("SyntaxAddSheft", param);
            insertData.close();

        }
        //===========================================================================================================================================
        public void SyntaxAddHolyDay(int ID, string HolyDay)
        {
            DAL.DataAccessLayer updateData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDUpdate", SqlDbType.Int); param[0].Value = ID;
            param[1] = new SqlParameter("@HolyDay", SqlDbType.VarChar, 50); param[1].Value = HolyDay;
            updateData.open();
            updateData.ExecuteCommand("SyntaxHolyDayInsert", param);
            updateData.close();
        }
        //==========================================================================================================================================
        public void syntaxAddVariables(int ID, string TheType)
        {
            DAL.DataAccessLayer Updatevariables = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("IDUpdate", SqlDbType.Int); param[0].Value = ID;
            param[1] = new SqlParameter("@TheType", SqlDbType.VarChar, 50); param[1].Value = TheType;
            Updatevariables.open();
            Updatevariables.ExecuteCommand("SyntaxAddVariables", param);
            Updatevariables.close();
        }
        //=========================================================================================================================================
        //=== This Function Below for Syntax of Variables to the Attencence....
        public DataTable SelectEmployeeTypeByDate(string EmpName, DateTime Date)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50); param[0].Value = EmpName;
            param[1] = new SqlParameter("@Date", SqlDbType.Date); param[1].Value = Date;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingByDate", param);
            GettingData.close();
            return Dt;
        }
        //=========================================================================================================================================
        //=== This Function Below for get time in and timeout of Employee by barcode....
        public DataTable SelectEmployeeByBarcode(string Barcode, DateTime Date, string ShiftName)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@barcode", SqlDbType.VarChar, 50); param[0].Value = Barcode;
            param[1] = new SqlParameter("@Date", SqlDbType.Date); param[1].Value = Date;
            param[2] = new SqlParameter("@ShiftName", SqlDbType.VarChar, 50); param[2].Value = ShiftName;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingBybarcode", param);
            GettingData.close();
            return Dt;
        }
        //=========================================================================================================================================
        //=== This Function Below for add time in  for Employee by barcode in attendence2....
        public void addTimeIn(int ID,string notic,string RegisterName, string AddingTime, string AddingDate, int idcon)
        {
            DAL.DataAccessLayer Updatevariables = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@IDatten2", SqlDbType.Int);                param[0].Value = ID;
            param[1] = new SqlParameter("@notic", SqlDbType.Text);                  param[1].Value = notic;
            param[2] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);    param[2].Value = RegisterName;
            param[3] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);      param[3].Value = AddingTime;
            param[4] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);      param[4].Value = AddingDate;
            param[5] = new SqlParameter("@Idcon", SqlDbType.Int);      param[5].Value =idcon;
            Updatevariables.open();
            Updatevariables.ExecuteCommand("Attendence2AddTime", param);
            Updatevariables.close();
        }
        //=========================================================================================================================================
        //=== This Function Below for add time out  for Employee by barcode in attendence2....
        public void addTimeout(int ID,string timecpme, string notic, DateTime datecome, string RegisterName, string AddingTime, string AddingDate,int idcon)
        {
            
            DAL.DataAccessLayer Updatevariables = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@IDatten2", SqlDbType.Int);                param[0].Value = ID;
            param[1] = new SqlParameter("@TimeCome", SqlDbType.Time, 7);            param[1].Value = TimeSpan.Parse(timecpme);
            param[2] = new SqlParameter("@notic", SqlDbType.Text);                  param[2].Value = notic;
            param[3] = new SqlParameter("@datecome", SqlDbType.Date);               param[3].Value = datecome;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);    param[4].Value = RegisterName;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);      param[5].Value = AddingTime;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);     param[6].Value = AddingDate;
            param[7] = new SqlParameter("@Idcon", SqlDbType.Int);                  param[7].Value = idcon;
            Updatevariables.open();
            Updatevariables.ExecuteCommand("Attendence2AddTimeOut", param);
            Updatevariables.close();
        }

        //========================================================================================================================================
        //== This function below for Design DataGridView for Attendence2 Table .....
        public void dgvdesign(DataGridView dgv, DataTable Dt)
        {
            CultureInfo cultures = new CultureInfo("en-us");
            dgv.DataBindings.Clear();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i][8] != null && Dt.Rows[i][8].ToString() != "")                
                    Dt.Rows[i][8] = Math.Round((double.Parse(Dt.Rows[i][8].ToString()) / 60),2);                
                if (Dt.Rows[i][6] != null && Dt.Rows[i][6].ToString() != "")
                    Dt.Rows[i][6] =Convert.ToDateTime( Dt.Rows[i][6]).ToString("hh:mm tt");
                if (Dt.Rows[i][7] != null && Dt.Rows[i][7].ToString() != "")
                    Dt.Rows[i][7] = Convert.ToDateTime(Dt.Rows[i][7]).ToString("hh:mm tt");
            }
            dgv.DataSource = null;
            dgv.DataSource = Dt;
            
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dgv.Columns[2].HeaderText = "الاسم";
            dgv.Columns[3].Visible = false;
            dgv.Columns[4].HeaderText = "وجبة المنتسب";
            dgv.Columns[5].HeaderText = "فئة العمل";
            dgv.Columns[6].HeaderText = "وقت الحضور";
           
            dgv.Columns[7].HeaderText = "وقت الانصراف";
            dgv.Columns[8].HeaderText = "مدة العمل";
            dgv.Columns[9].HeaderText = "حالة المنتسب";
            dgv.Columns[10].Visible = false;
            dgv.Columns[11].Visible = false;
            dgv.Columns[12].Visible = false;
            dgv.Columns[13].Visible = false;
            dgv.Columns[14].HeaderText = "تاريخ الحضور";
            dgv.Columns[15].HeaderText = "تاريخ الانصراف";
            dgv.Columns[16].HeaderText = "زمنية الحضور";
            dgv.Columns[17].HeaderText = "زمنية الانصراف";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        //==============================================================================================================================================


        

    }
}
