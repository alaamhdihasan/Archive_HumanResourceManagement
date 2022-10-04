using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLSCARSOPERATIONS
    {
        //---GetData From DivisionCars Table And Carsituation Table ---- CarsituationsOperations Procedure-
        // And Build The Form Of CarsSituation-----------------------------------------------------------------------------------------------------
        public DataTable CarsSituationGetData(string Searching, DataGridView Dgv, TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            , TextBox ope13, Label lbope1, Label lbope2, Label lbope3, Label lbope4, Label lbope5, Label lbope6, Label lbope7, Label lbope8, Label lbope9
            , Label lbope10, Label lbope11, Label lbope12, Label lbope13)
        {
            DAL.DataAccessLayer GetData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SearchingCarNo", SqlDbType.VarChar, 50);
            param[0].Value = Searching;
            GetData.open();
            DataTable Dt = GetData.SelectingData("CarSituationOperations", param);
            GetData.close();
            Dgv.DataSource = null;

            ope1.DataBindings.Clear(); ope2.DataBindings.Clear(); ope3.DataBindings.Clear(); ope4.DataBindings.Clear(); ope5.DataBindings.Clear();
            ope6.DataBindings.Clear(); ope7.DataBindings.Clear(); ope8.DataBindings.Clear(); ope9.DataBindings.Clear(); ope10.DataBindings.Clear();

            Dgv.DataSource = Dt; Dgv.Visible = true;
            Dgv.Columns[0].Visible = false; Dgv.Columns[1].Visible = false; Dgv.Columns[2].HeaderText = "موقف العجلة";
            Dgv.Columns[3].HeaderText = "الجهة المستفيدة"; Dgv.Columns[4].HeaderText = "من تاريخ"; Dgv.Columns[5].HeaderText = "الى تاريخ";
            Dgv.Columns[6].Visible = false; Dgv.Columns[7].Visible = false; Dgv.Columns[8].Visible = false; Dgv.Columns[9].Visible = false;

            ope1.DataBindings.Add("text", Dt, "CarNo");                                 ope1.Visible = true;        ope1.Enabled = true;
            ope2.DataBindings.Add("text", Dt, "CarType");                               ope2.Visible = true;        ope2.Enabled = true;
            ope3.DataBindings.Add("text", Dt, "CarSituation");                          ope3.Visible = true;        ope3.Enabled = true;
            ope4.DataBindings.Add("text", Dt, "TheBeneficiary");                        ope4.Visible = true;        ope4.Enabled = true;
            ope5.DataBindings.Add("text", Dt, "FromDate");                              ope5.Visible = true;        ope5.Enabled = true;
            ope6.DataBindings.Add("text", Dt, "ToDate");                                ope6.Visible = true;        ope6.Enabled = true;
            ope7.DataBindings.Add("text", Dt, "RegisterName");                          ope7.Visible = true;        ope7.Enabled = false;
            ope8.DataBindings.Add("text", Dt, "AddingTime");                            ope8.Visible = true;        ope8.Enabled = false;
            ope9.DataBindings.Add("text", Dt, "AddingDate");                            ope9.Visible = true;        ope9.Enabled = false;
            ope10.DataBindings.Add("text", Dt, "IDsit");                                ope10.Visible = true;       ope10.Enabled = false;

            lbope1.Text = "رقم العجلة"; lbope1.Visible = true; lbope2.Text = "نوع العجلة"; lbope2.Visible = true;
            lbope3.Text = "موقف العجلة"; lbope3.Visible = true; lbope4.Text = "الجهة المستفيدة"; lbope4.Visible = true;
            lbope5.Text = "من"; lbope5.Visible = true; lbope6.Text = "الى"; lbope6.Visible = true;
            lbope7.Text = "مدخل البيانات"; lbope7.Visible = true; lbope8.Text = "وقت الاضافة"; lbope8.Visible = true;
            lbope9.Text = "تاريخ الاضافة"; lbope9.Visible = true; lbope10.Text = "الرقم التعريفي"; lbope10.Visible = true;

            return Dt;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //---- Insert Data To The CarsSituations Table------------------------------------------------------------------------------------------
        public void CarsituationInsertData(string ope1, string ope2, string ope3, string ope4
            , string ope5, string ope6, string ope7, string ope8, string ope9)
        {
            DAL.DataAccessLayer InsertData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                   param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[1].Value = ope2;
            param[2] = new SqlParameter("@Carsituation", SqlDbType.VarChar, 50);            param[2].Value = ope3;
            param[3] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);             param[3].Value = ope4;
            param[4] = new SqlParameter("@FromDate", SqlDbType.VarChar, 50);                param[4].Value = ope5;
            param[5] = new SqlParameter("@ToDate", SqlDbType.VarChar, 50);                  param[5].Value = ope6;
            param[6] = new SqlParameter("@Registername", SqlDbType.VarChar, 50);            param[6].Value = ope7;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);              param[7].Value = ope8;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);              param[8].Value = ope9;
            InsertData.open();
            InsertData.ExecuteCommand("CarSituationInsertInto", param);
            InsertData.close();

        }
        //--------------------------------------------------------------------------------------------------------------------------------------

        //---- Update Data To The CarsSituation Table ------------------------------------------------------------------------------------------
        public void CarsituationUpdateDate(string ope1, string ope2, string ope3, string ope4
            , string ope5, string ope6, string ope7, string ope8, string ope9,int ope10)
        {
            DAL.DataAccessLayer UpdateData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                    param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                  param[1].Value = ope2;
            param[2] = new SqlParameter("@Carsituation", SqlDbType.VarChar, 50);             param[2].Value = ope3;
            param[3] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);              param[3].Value = ope4;
            param[4] = new SqlParameter("@FromDate", SqlDbType.VarChar, 50);                 param[4].Value = ope5;
            param[5] = new SqlParameter("@ToDate", SqlDbType.VarChar, 50);                   param[5].Value = ope6;
            param[6] = new SqlParameter("@Registername", SqlDbType.VarChar, 50);             param[6].Value = ope7;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);               param[7].Value = ope8;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);               param[8].Value = ope9;
            param[9] = new SqlParameter("@IDsit", SqlDbType.Int);                            param[9].Value = ope10;
            UpdateData.open();
            UpdateData.ExecuteCommand("CarSituationUpdate", param);
            UpdateData.close();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        //---- Delete Data From The CarsSituation Table ---------------------------------------------------------------------------------------
        public void CarsituationDeleteData(int ope10)
        {
            DAL.DataAccessLayer DeleteData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDsit", SqlDbType.Int);                            param[0].Value = ope10;
            DeleteData.open();
            DeleteData.ExecuteCommand("CarSituationDeleting", param);
            DeleteData.close();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------

        //---- Hide The content Of Form of Carsoperations in the start of open-----------------------------------------------------------------
        public void HideContentForm(DataGridView Dgv, TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            ,TextBox ope13, Label lbope1, Label lbope2, Label lbope3, Label lbope4, Label lbope5, Label lbope6, Label lbope7, Label lbope8, Label lbope9
            , Label lbope10, Label lbope11, Label lbope12,Label lbope13)
        {
            Dgv.Visible = false;ope1.Visible = false;ope2.Visible = false;ope3.Visible = false;ope4.Visible = false;ope5.Visible = false;
             ope6.Visible = false; ope7.Visible = false;ope8.Visible = false;ope9.Visible = false;ope10.Visible = false;
           ope11.Visible = false;ope12.Visible = false;ope13.Visible = false; lbope1.Visible = false; lbope2.Visible = false;lbope3.Visible = false;
            lbope4.Visible = false;lbope5.Visible = false;lbope6.Visible = false;lbope7.Visible = false;lbope8.Visible = false;
            lbope9.Visible = false;lbope10.Visible = false;lbope11.Visible = false;lbope12.Visible = false; lbope13.Visible = false;
            
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
         
        //-----This Function For  Clear The Form Content of CarsituationsOperationInterface------------------------------------------------------

         public void CarsituationClearData(TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12)
        {
            ope3.Text = "";ope7.Clear(); ope8.Clear();ope9.Clear();ope10.Clear();ope11.Clear();ope12.Clear();
            CLS_FRMS.CLSCONSTENTRY getdata = new CLSCONSTENTRY();
            DataTable Dt = getdata.GetDataDepartment();
            ope4.DataSource = Dt;
            ope4.DisplayMember = "الاقسام والمواقع";
            ope4.Text = "";
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        //------Get Data From CarsAccident Table And DivisionCars Table ------ CarsAccidentGetData Procedure ------------------------------------
        public DataTable CarsAccidentGetData(string Searching, DataGridView Dgv, TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            , TextBox ope13, Label lbope1, Label lbope2, Label lbope3, Label lbope4, Label lbope5, Label lbope6, Label lbope7, Label lbope8, Label lbope9
            , Label lbope10, Label lbope11, Label lbope12, Label lbope13)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@searchingCarNo", SqlDbType.VarChar, 50);                      param[0].Value = Searching;
            dal.open();
            DataTable Dt= dal.SelectingData("CarAccidentsGetdata", param);
            dal.close();
            Dgv.DataSource = null;

            ope1.DataBindings.Clear();ope2.DataBindings.Clear();ope3.DataBindings.Clear();ope5.DataBindings.Clear();ope7.DataBindings.Clear();
            ope8.DataBindings.Clear();ope9.DataBindings.Clear();ope10.DataBindings.Clear();ope11.DataBindings.Clear();

            Dgv.DataSource = Dt;Dgv.Visible = true;
            Dgv.Columns[0].Visible = false;Dgv.Columns[1].Visible = false;Dgv.Columns[2].Visible = false;Dgv.Columns[3].HeaderText = "اليوم";
            Dgv.Columns[4].HeaderText = "تاريخ الحادث";Dgv.Columns[5].HeaderText = "ملاحظات";Dgv.Columns[6].Visible = false;
            Dgv.Columns[7].Visible = false;Dgv.Columns[8].Visible = false;

            ope1.DataBindings.Add("text", Dt, "CarNO");                   ope1.Visible = true;          ope1.Enabled = true; 
            ope2.DataBindings.Add("text", Dt, "CarType");                 ope2.Visible = true;          ope2.Enabled = true;
            ope3.DataBindings.Add("text", Dt, "AccidentDay");             ope3.Visible = true;          ope3.Enabled = true;
            ope5.DataBindings.Add("text", Dt, "AccidentDate");            ope5.Visible = true;          ope5.Enabled = true;
            ope7.DataBindings.Add("text", Dt, "RegisterName");            ope7.Visible = true;          ope7.Enabled = false;
            ope8.DataBindings.Add("text", Dt, "AddingTime");              ope8.Visible = true;          ope8.Enabled = false;
            ope9.DataBindings.Add("text", Dt, "AddingDate");              ope9.Visible = true;          ope9.Enabled = false;
            ope10.DataBindings.Add("text", Dt, "IDaccident");             ope10.Visible = true;         ope10.Enabled = false;
            ope11.DataBindings.Add("text", Dt, "Notice");                 ope11.Multiline = true;       ope11.Height = 120;
                                                                                                        ope11.Visible = true;
                                                                                                        ope11.Enabled=true;

            lbope1.Text = "رقم العجلة"; lbope1.Visible=true; lbope2.Text = "نوع العجلة"; lbope2.Visible = true;
            lbope3.Text = "اليوم"; lbope3.Visible = true; lbope5.Text = "تاريخ"; lbope5.Visible = true;
            lbope7.Text = "مدخل البيانات";lbope7.Visible = true;lbope8.Text = "وقت  الاضافة";lbope8.Visible = true;
            lbope9.Text = "تاريخ الاضافة"; lbope9.Visible = true; lbope10.Text = "الرقم التعريفي"; lbope10.Visible = true;
            lbope11.Text = "ملاحظات";lbope11.Visible = true;

            return Dt;
        }
       // -----------------------------------------------------------------------------------------------------------------------------------
       //------ This Function For Clear Content Form of CarAccidentGetData Procedure---------------------------------------------------------
        public void CarAccidentClearData(TextBox ope1, TextBox ope2, ComboBox ope3,DateTimePicker ope5, TextBox ope7, TextBox ope8, 
              TextBox ope9, TextBox ope10, TextBox ope11)
        {
            ope7.Text = "";ope8.Text = "";ope9.Text = "";ope10.Text = "";ope11.Text = "";
            ope3.Items.Add("السبت"); ope3.Items.Add("الأحد"); ope3.Items.Add("الإثنين"); ope3.Items.Add("الثلاثاء"); ope3.Items.Add("الأربعاء");
            ope3.Items.Add("الخميس"); ope3.Items.Add("الجمعة"); ope3.Text = "";
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //---- Insert Data To CarsAccident Table -------------------------------------------------------------------------------------------
        public void CarsAccidentInsertData(string ope1,string ope2,string ope3, string ope5,string ope7,string ope8,string ope9,string ope11)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                           param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                         param[1].Value = ope2;
            param[2] = new SqlParameter("@AccidentDay", SqlDbType.VarChar, 50);                     param[2].Value = ope3;
            param[3] = new SqlParameter("@AccidentDate", SqlDbType.VarChar, 50);                    param[3].Value = ope5;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);                    param[4].Value = ope7;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);                      param[5].Value = ope8;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);                      param[6].Value = ope9;
            param[7] = new SqlParameter("@Notice", SqlDbType.Text);                                 param[7].Value = ope11;
            dal.open();
            dal.ExecuteCommand("CarAccidentInsert", param);
            dal.close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //--- Update Data To CarsAccident Table -------------------------------------------------------------------------------------------
        public void CarsAccidentUpdateDate(int ope10,string ope1, string ope2, string ope3, string ope5, string ope7, string ope8, string ope9, string ope11)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);                                      param[0].Value = ope10;
            param[1] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                           param[1].Value = ope1;
            param[2] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                         param[2].Value = ope2;
            param[3] = new SqlParameter("@AccidentDay", SqlDbType.VarChar, 50);                     param[3].Value = ope3;
            param[4] = new SqlParameter("@AccidentDate", SqlDbType.VarChar, 50);                    param[4].Value = ope5;
            param[5] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);                    param[5].Value = ope7;
            param[6] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);                      param[6].Value = ope8;
            param[7] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);                      param[7].Value = ope9;
            param[8] = new SqlParameter("@Notice", SqlDbType.Text);                                 param[8].Value = ope11;
            dal.open();
            dal.ExecuteCommand("CarAccidentUpDate", param);
            dal.close();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //-----Delete From CarsAccident Table ----------------------------------------------------------------------------------------------
        public void CarsAccidentDeleting(int ope10)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ope10;
            dal.open();
            dal.ExecuteCommand("CarAccidentDeleting", param);
            dal.close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //--- Get Data From CarsCounters Table ----------------------------------------------------------------------------------------------
        public DataTable CarsCounterGetData(string Searching, DataGridView Dgv, TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            , TextBox ope13, Label lbope1, Label lbope2, Label lbope3, Label lbope4, Label lbope5, Label lbope6, Label lbope7, Label lbope8, Label lbope9
            , Label lbope10, Label lbope11, Label lbope12, Label lbope13)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SearchingNo", SqlDbType.VarChar, 50);                               param[0].Value = Searching;
            dal.open();
            DataTable Dt = dal.SelectingData("CarCountersSeleting", param);
            dal.close();
            Dgv.DataSource = null;

            ope1.DataBindings.Clear();ope2.DataBindings.Clear();ope3.DataBindings.Clear();ope5.DataBindings.Clear();ope7.DataBindings.Clear();
            ope8.DataBindings.Clear();ope9.DataBindings.Clear();ope10.DataBindings.Clear(); ope11.DataBindings.Clear();ope4.DataBindings.Clear();

            Dgv.DataSource = Dt; Dgv.Visible = true;
            Dgv.Columns[0].Visible = false;Dgv.Columns[1].Visible = false;Dgv.Columns[2].Visible = false;Dgv.Columns[3].Visible = false;
            Dgv.Columns[4].HeaderText = "تاريخ العداد";Dgv.Columns[5].HeaderText = "عداد العجلة";Dgv.Columns[6].HeaderText = "مدخل البيانات";
            Dgv.Columns[7].Visible = false;Dgv.Columns[8].Visible = false;Dgv.Columns[9].Visible = false;

            ope1.DataBindings.Add("text", Dt, "CarNO");                   ope1.Visible = true;ope1.Enabled = true;
            ope2.DataBindings.Add("text", Dt, "CarType");                 ope2.Visible = true;ope2.Enabled = true;
            ope3.DataBindings.Add("text", Dt, "CounterDay");              ope3.Visible = true;ope3.Enabled = true;
            ope4.DataBindings.Add("text", Dt, "Advisor");                 ope4.Visible = true;ope4.Enabled = true;
            ope5.DataBindings.Add("text", Dt, "CounterDate");             ope5.Visible = true;ope5.Enabled = true;
            ope7.DataBindings.Add("text", Dt, "CarCounter");              ope7.Visible = true;ope7.Enabled = true;
            ope8.DataBindings.Add("text", Dt, "IDcounter");               ope8.Visible = true;ope8.Enabled = false;
            ope9.DataBindings.Add("text", Dt, "registername");            ope9.Visible = true;ope9.Enabled = false;
            ope10.DataBindings.Add("text", Dt, "Addingtime");             ope10.Visible = true;ope10.Enabled = false;
            ope11.DataBindings.Add("text", Dt, "AddingDate");             ope11.Visible = true;ope11.Enabled = false;ope11.Height = 34;
            

            lbope1.Text = "رقم العجلة";lbope1.Visible = true;lbope2.Text = "نوع العجلة";lbope2.Visible = true;
            lbope3.Text = "اليوم";lbope3.Visible = true;lbope5.Text = "التاريخ";lbope5.Visible = true;
            lbope7.Text = "العداد";lbope7.Visible = true;lbope8.Text = "الرقم التعريفي";lbope8.Visible = true;
            lbope9.Text = "مدخل البيانات";lbope9.Visible = true;lbope10.Text = "وقت الاضافة";lbope10.Visible = true;
            lbope11.Text = "تاريخ الاضافة";lbope11.Visible = true; lbope4.Visible = true; ; lbope4.Text = "تبديل الزيت";


            return Dt;
        }
        //---- Clear Data Of Carscounter Interface For New Adding-----------------------------------------------------------------------------
        public void CarsCountersClearData( TextBox ope1, TextBox ope2, ComboBox ope3, DateTimePicker ope5, TextBox ope7, TextBox ope8,
             TextBox ope9, TextBox ope10, TextBox ope11,ComboBox ope4)
        {
            ope4.Items.Clear();
            ope4.Items.Add("تبديل");
            ope7.Clear();ope8.Clear();ope9.Text = "";ope10.Text = DateTime.Now.ToString("hh:mm tt");
            ope11.Text = DateTime.Now.ToString("yyyy/MM/dd");
            ope3.Items.Add("السبت"); ope3.Items.Add("الأحد"); ope3.Items.Add("الإثنين"); ope3.Items.Add("الثلاثاء"); ope3.Items.Add("الأربعاء");
            ope3.Items.Add("الخميس"); ope3.Items.Add("الجمعة");ope3.Text = "";
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //----- Insert into CarsCounter Table ------ used The CarsCounterInsertinto Procedure---------------------------------------------------
        public void CarsCounterinsertData(string ope1,string ope2,string ope3,string ope5,double ope7,string ope9,string ope10,string ope11,string ope4)
            
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                   param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[1].Value = ope2;
            param[2] = new SqlParameter("@CounterDay", SqlDbType.VarChar, 50);              param[2].Value = ope3;
            param[3] = new SqlParameter("@CounterDate", SqlDbType.VarChar, 50);             param[3].Value = ope5;
            param[4] = new SqlParameter("@CarCounter", SqlDbType.Real);                     param[4].Value = ope7;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50);            param[5].Value = ope9;
            param[6] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);              param[6].Value = ope10;
            param[7] = new SqlParameter("@AddingDate", SqlDbType.VarChar,50);               param[7].Value = ope11;
            param[8] = new SqlParameter("@Advisor", SqlDbType.VarChar, 50);                 param[8].Value = ope4;
            dal.open();
            dal.ExecuteCommand("CarsCountersInsertInto", param);
            dal.close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //-- Update Data to CarsCounter Table --- used the CarsCounterUpdate procedure------------------------------------------------------
        public void CarsCounterUpdateDate( string ope1, string ope2, string ope3, string ope5, double ope7, string ope9
            , string ope10, string ope11, int ope8,string  ope4)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                   param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[1].Value = ope2;
            param[2] = new SqlParameter("@CounterDay", SqlDbType.VarChar, 50);              param[2].Value = ope3;
            param[3] = new SqlParameter("@CounterDate", SqlDbType.VarChar, 50);             param[3].Value = ope5;
            param[4] = new SqlParameter("@CarCounter", SqlDbType.Real);                     param[4].Value = ope7;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50);            param[5].Value = ope9;
            param[6] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);              param[6].Value = ope10;
            param[7] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);              param[7].Value = ope11;
            param[8] = new SqlParameter("@IDcounter", SqlDbType.Int);                       param[8].Value = ope8;
            param[9] = new SqlParameter("@Advisor", SqlDbType.VarChar, 50);                 param[9].Value = ope4;
            dal.open();
            dal.ExecuteCommand("CarsCountersUpDate", param);
            dal.close();
        }
        //------------------------------------------------------------------------------------------------------------------------------------
        //---- Delete From CarsCounter Table ----- used CarsCounterDelete procedure-----------------------------------------------------------
        public void CarsCounterDeleteData(int ope8)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@IDCounter", SqlDbType.Int); param[0].Value = ope8;
            dal.open();
            dal.ExecuteCommand("CarsCounterDeleting", param);
            dal.close();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--- Getting Data From CarsFuel Table -- used CarsFuelSelecting Data Procedure ------------------------------------------------------
        public DataTable CarsFuelGettingData(string Searching, DataGridView Dgv, TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            , TextBox ope13, Label lbope1, Label lbope2, Label lbope3, Label lbope4, Label lbope5, Label lbope6, Label lbope7, Label lbope8, Label lbope9
            , Label lbope10, Label lbope11, Label lbope12, Label lbope13,PictureBox pic)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Searching", SqlDbType.VarChar, 50); param[0].Value = Searching;
            dal.open();
            DataTable Dt = dal.SelectingData("CarsFuelSeleting", param);
            dal.close();
            if (Dt.Rows.Count == 0)
            {
                Dgv.DataSource = null;
                ope1.DataBindings.Clear(); ope2.DataBindings.Clear(); ope3.DataBindings.Clear(); ope5.DataBindings.Clear(); ope6.DataBindings.Clear();
                ope7.DataBindings.Clear(); ope8.DataBindings.Clear(); ope9.DataBindings.Clear(); ope10.DataBindings.Clear(); ope11.DataBindings.Clear();
                ope12.DataBindings.Clear(); ope4.DataBindings.Clear();ope13.DataBindings.Clear();
                CarsFuelClearData(ope1,ope2,ope3,ope4,ope5,ope6,ope7,ope8,ope9,ope10,ope11,ope12,ope13,pic);
                return Dt;
            }
            else
            {
                Dgv.DataSource = null;
                ope1.DataBindings.Clear(); ope2.DataBindings.Clear(); ope3.DataBindings.Clear(); ope5.DataBindings.Clear(); ope6.DataBindings.Clear();
                ope7.DataBindings.Clear(); ope8.DataBindings.Clear(); ope9.DataBindings.Clear(); ope10.DataBindings.Clear(); ope11.DataBindings.Clear();
                ope12.DataBindings.Clear(); ope4.DataBindings.Clear(); ope13.DataBindings.Clear();
               
                Dgv.DataSource = Dt; Dgv.Visible = true;
                Dgv.Columns[0].Visible = false; Dgv.Columns[1].Visible = false; Dgv.Columns[2].Visible = false; Dgv.Columns[3].Visible = false;
                Dgv.Columns[4].HeaderText = "التاريخ"; Dgv.Columns[5].HeaderText = "الكمية"; Dgv.Columns[6].HeaderText = "رقم الفاتورة";
                Dgv.Columns[7].HeaderText = "تاريخ الفاتورة"; Dgv.Columns[8].HeaderText = "اجمالي الفاتورة"; Dgv.Columns[9].Visible = false;
                Dgv.Columns[10].Visible = false; Dgv.Columns[11].Visible = false;Dgv.Columns[12].Visible = false;

                ope1.DataBindings.Add("text", Dt, "CarNo");                         ope1.Visible = true; ope1.Enabled = true;
                ope2.DataBindings.Add("text", Dt, "CarType");                       ope2.Visible = true; ope2.Enabled = true;
                ope3.DataBindings.Add("text", Dt, "FuelDay");                       ope3.Visible = true; ope3.Enabled = true;
                ope5.DataBindings.Add("text", Dt, "FuelDate");                      ope5.Visible = true; ope5.Enabled = true;
                ope7.DataBindings.Add("text", Dt, "FuelQuantity");                  ope7.Visible = true; ope7.Enabled = true;
                ope8.DataBindings.Add("text", Dt, "Billno");                        ope8.Visible = true; ope8.Enabled = true;
                ope6.DataBindings.Add("text", Dt, "BillDate");                      ope6.Visible = true; ope6.Enabled = true;
                ope9.DataBindings.Add("text", Dt, "BillTotalmoney");                ope9.Visible = true; ope9.Enabled = true;
                ope10.DataBindings.Add("text", Dt, "RegisterName");                 ope10.Visible = true; ope10.Enabled = false;
                ope11.DataBindings.Add("text", Dt, "AddingTime");                   ope11.Visible = true; ope11.Enabled = false;ope11.Height = 34;
                ope12.DataBindings.Add("text", Dt, "AddingDate");                   ope12.Visible = true; ope12.Enabled = false;
                ope13.DataBindings.Add("text", Dt, "imagepath");                    ope13.Visible = true;ope13.Enabled = false;
                ope4.DataBindings.Add("text", Dt, "IDFuel");                        ope4.Visible = true;ope4.Enabled = false;
                                                                                    
                if (ope13.Text == "")
                {
                    pic.Image = null;
                }
                else
                {
                    pic.Load(ope13.Text);
                }
                                                                                                 
                lbope1.Text = "رقم العجلة"; lbope1.Visible = true; lbope2.Text = "نوع العجلة"; lbope2.Visible = true;
                lbope3.Text = "اليوم"; lbope3.Visible = true; lbope5.Text = "التاريخ"; lbope5.Visible = true;
                lbope7.Text = "الكمية"; lbope7.Visible = true; lbope8.Text = "رقم الفاتورة"; lbope8.Visible = true;
                lbope9.Text = "اجمالي المبلغ"; lbope9.Visible = true; lbope10.Text = "مدخل البيانات"; lbope10.Visible = true;
                lbope11.Text = "وقت الاضافة"; lbope11.Visible = true; lbope12.Text = "تاريخ الاضافة"; lbope12.Visible = true;
                lbope4.Text = "الرقم التعريفي"; lbope4.Visible = true;lbope13.Text = "نسخة مصورة";lbope13.Visible = true;
                lbope6.Text = "تاريخ الفاتورة";lbope6.Visible = true;

                return Dt;
            }
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //----- This Function For Clear content Of CarsFuel Form----------------------------------------------------------------------------
        public void CarsFuelClearData( TextBox ope1, TextBox ope2, ComboBox ope3, ComboBox ope4
            , DateTimePicker ope5, DateTimePicker ope6, TextBox ope7, TextBox ope8, TextBox ope9, TextBox ope10, TextBox ope11, TextBox ope12
            , TextBox ope13, PictureBox pic)
        {
            ope1.Text = "";ope2.Text = "";ope4.Text = "";ope5.Text = "";ope7.Text = "";ope8.Text = "";ope9.Text = "";
            ope10.Text = "";ope11.Text = DateTime.Now.ToString("hh:mm tt");ope12.Text =DateTime.Now.ToString("yyyy/MM/dd");
            ope13.Text = "";pic.Image = null;
            ope3.Items.Add("السبت"); ope3.Items.Add("الأحد"); ope3.Items.Add("الإثنين"); ope3.Items.Add("الثلاثاء"); ope3.Items.Add("الأربعاء");
            ope3.Items.Add("الخميس"); ope3.Items.Add("الجمعة"); ope3.Text = "";

        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--- Insert Data Into CarsFuel Table By Used The CarsFuelinsertinto Procedure-------------------------------------------------------
        public void CarFuelInsertData(string ope1, string ope2, string ope3, string ope5, string ope6,
             double ope7, int ope8, double ope9, string ope10, string ope11, string ope12, string ope13)
            
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                       param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                     param[1].Value = ope2;
            param[2] = new SqlParameter("@FuelDay", SqlDbType.VarChar, 50);                     param[2].Value = ope3;
            param[3] = new SqlParameter("@FuelDate", SqlDbType.VarChar, 50);                    param[3].Value = ope5;
            param[4] = new SqlParameter("@FuelQuantity", SqlDbType.Real);                       param[4].Value = ope7;
            param[5] = new SqlParameter("@BillNo", SqlDbType.Int);                              param[5].Value = ope8;
            param[6] = new SqlParameter("@BillDate", SqlDbType.VarChar, 50);                    param[6].Value = ope6;
            param[7] = new SqlParameter("@BillTotal", SqlDbType.Real);                          param[7].Value = ope9;
            param[8] = new SqlParameter("@registername", SqlDbType.VarChar, 50);                param[8].Value = ope10;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);                  param[9].Value = ope11;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);                 param[10].Value = ope12;
            param[11] = new SqlParameter("@imagepath", SqlDbType.Text);                         param[11].Value = ope13;
            dal.open();
            dal.ExecuteCommand("CarsFuelInsetinto", param);
            dal.close();

        }
        //------------------------------------------------------------------------------------------------------------------------------------
        //---- Update Data in CarsFuel Table by used the CarsFuelUpdate Procedure-------------------------------------------------------------
        public void CarsFuelUpdateData(string ope1, string ope2, string ope3, string ope5, string ope6,int ope4,
             double ope7, int ope8, double ope9, string ope10, string ope11, string ope12, string ope13)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                   param[0].Value = ope1;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[1].Value = ope2;
            param[2] = new SqlParameter("@FuelDay", SqlDbType.VarChar, 50);                 param[2].Value = ope3;
            param[3] = new SqlParameter("@FuelDate", SqlDbType.VarChar, 50);                param[3].Value = ope5;
            param[4] = new SqlParameter("@FuelQuantity", SqlDbType.Real);                   param[4].Value = ope7;
            param[5] = new SqlParameter("@BillNo", SqlDbType.Int);                          param[5].Value = ope8;
            param[6] = new SqlParameter("@BillDate", SqlDbType.VarChar, 50);                param[6].Value = ope6;
            param[7] = new SqlParameter("@BillTotal", SqlDbType.Real);                      param[7].Value = ope9;
            param[8] = new SqlParameter("@registername", SqlDbType.VarChar, 50);            param[8].Value = ope10;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);              param[9].Value = ope11;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);             param[10].Value = ope12;
            param[11] = new SqlParameter("@imagepath", SqlDbType.Text);                     param[11].Value = ope13;
            param[12] = new SqlParameter("IDFuel", SqlDbType.Int);                          param[12].Value =ope4;
            dal.open();
            dal.ExecuteCommand("CarsFuelUpdate", param);
            dal.close();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--- Delete Data From CarsFuel Table By using The CarsFuelDelete Procedure ---------------------------------------------------------
        public void CarsFuelDeletingData(int ope4)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDfuel", SqlDbType.Int);                              param[0].Value = ope4;
            dal.open();
            dal.ExecuteCommand("CarsFuelDeleting", param);
            dal.close();
        }
        //---------------------------------------------------------------------------------------------------------------------------------
        public void FillCbo(ComboBox ope3,ComboBox ope4)
        {

        }
    }   
}
