using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLSCONSTENTRY
    {
        public DataTable GetDataDepartment()//---------------------------------جلب بيانات جدول الاقسام
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DepartmentsSelecting", null);
            dal.close();

            return Dt;
        }
        public void insertintoDepartments(string tbnamedepartment, bool DeptInvest)// -----------ادخال بيانات الى جدول الاقسام
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Department", SqlDbType.VarChar, 50);
            param[0].Value = tbnamedepartment;
            param[1] = new SqlParameter("@DeptInvest", SqlDbType.Bit);
            param[1].Value = DeptInvest;
            dal.open();
            dal.ExecuteCommand("DepartmentsInsertinto", param);
            dal.close();
            GetDataDepartment();

        }
        public void DepartmentsUpdatedata(int iddeprart, string tbnamedepartment, bool DeptInvest)//------تحديث بيانات جدول الاقسام
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IDdepart", SqlDbType.Int);
            param[0].Value = iddeprart;
            param[1] = new SqlParameter("@Department", SqlDbType.VarChar, 50);
            param[1].Value = tbnamedepartment;
            param[2] = new SqlParameter("@DeptInvest", SqlDbType.Bit);
            param[2].Value = DeptInvest;
            dal.open();
            dal.ExecuteCommand("DepartmentsUpdate", param);
            dal.close();
            GetDataDepartment();

        }
        public void DepartmentsDeleting(int iddepart)//--------الحذف من جدول الاقسام
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdepart", SqlDbType.Int);
            param[0].Value = iddepart;
            dal.open();
            dal.ExecuteCommand("DepartmentsDeleting", param);
            dal.close();
            GetDataDepartment();
        }
        public DataTable TheTypeselection()//-------------------جلب بيانات جدول الحالة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("TheTypeselecting", null);
            return Dt;

        }
        public void TheTypeInsertinto(string TheTypename)//--------ادخال البيانات الى جدول الحالة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);
            param[0].Value = TheTypename;
            dal.open();
            dal.ExecuteCommand("TheTypeInsertInto", param);
            dal.close();
            TheTypeselection();

        }

        public void TheTypeUpdate(int idtype, string thetypename)//------------تحديث بيانات جدول الحالة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDType", SqlDbType.Int);
            param[0].Value = idtype;
            param[1] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);
            param[1].Value = thetypename;
            dal.open();
            dal.ExecuteCommand("TheTypeUpdate", param);
            dal.close();
            TheTypeselection();
        }
        public void TheTypeDeleting(int idtype)//-------------------الحذف من جدول الحالة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idtype", SqlDbType.Int);
            param[0].Value = idtype;
            dal.open();
            dal.ExecuteCommand("TheTypeDeleting", param);
            dal.close();
            TheTypeselection();
            TheTypeselection();

        }

        public DataTable DistenationSelecting()//--------------------جلب بيانات جدول الجهات المقصودة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable  Dt = dal.SelectingData("DistenationSeleting", null);
            dal.close();
            return Dt;

        }
        public void DistenationInsertinto(string PlaceName)//-------------------ادخال البيانات الى الجهات المقصودة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PlaceName", SqlDbType.VarChar, 50);
            param[0].Value = PlaceName;
            dal.open();
            dal.ExecuteCommand("Distenationinsertinto", param);
            dal.close();
            DistenationSelecting();

        }
        public void DistenationUpdate(int IDdist, string PlaceName)//---------تحديث الجهات المقصودة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDdis", SqlDbType.Int);
            param[0].Value = IDdist;
            param[1] = new SqlParameter("@PlaceName", SqlDbType.VarChar, 50);
            param[1].Value = PlaceName;
            dal.open();
            dal.ExecuteCommand("DistenationUpdate", param);
            dal.close();
            DistenationSelecting();

        }
        public void DistenationDeleting(int IDdist)//------------------------الحذف من الجهات المقصودة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdis", SqlDbType.Int);
            param[0].Value = IDdist;
            dal.open();
            dal.ExecuteCommand("DistenationDeleting", param);
            dal.close();
            DistenationSelecting();

        }

        public DataTable TheCustomerSelection()//------------------------------جلب بيانات جدول المستفيدين
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("TheCustomersSeleting", null);
            dal.close();
            return Dt;

        }

        public void TheCustomerInsertInto(string Customername, string distenation
            , string thebeneficiary, string TransprotType, string customerJob, string registername)//-----------ادخال البيانات الى جدول المستفيدين
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);
            param[0].Value = Customername;
            param[1] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);
            param[1].Value = distenation;
            param[2] = new SqlParameter("@thebeneficiary", SqlDbType.VarChar, 50);
            param[2].Value = thebeneficiary;
            param[3] = new SqlParameter("@TransportType", SqlDbType.VarChar, 50);
            param[3].Value = TransprotType;
            param[4] = new SqlParameter("@customerjob", SqlDbType.VarChar, 50);
            param[4].Value = customerJob;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50);
            param[5].Value = registername;

            dal.open();
            dal.ExecuteCommand("TheCustomersinsertinto", param);
            dal.close();
            TheCustomerSelection();

        }

        public void TheCustomerUpdate(int idcust, string Customername, string distenation
           , string thebeneficiary, string TransprotType, string customerJob, string registername)//--------------تحديث جدول المستفيدين
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@IDcustomer", SqlDbType.Int);
            param[0].Value = idcust;
            param[1] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);
            param[1].Value = Customername;
            param[2] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);
            param[2].Value = distenation;
            param[3] = new SqlParameter("@thebeneficiary", SqlDbType.VarChar, 50);
            param[3].Value = thebeneficiary;
            param[4] = new SqlParameter("@TransportType", SqlDbType.VarChar, 50);
            param[4].Value = TransprotType;
            param[5] = new SqlParameter("@customerjob", SqlDbType.VarChar, 50);
            param[5].Value = customerJob;
            param[6] = new SqlParameter("@registername", SqlDbType.VarChar, 50);
            param[6].Value = registername;

            dal.open();
            dal.ExecuteCommand("TheCustomersupdate", param);
            dal.close();
            TheCustomerSelection();

        }

        public void ThecustomerDeleting(int IDcustomer)//-------------الحذف من جدول المستفيدين
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Idcustomer", SqlDbType.Int);
            param[0].Value = IDcustomer;
            dal.open();
            dal.ExecuteCommand("TheCustomersDeleting", param);
            dal.close();
            TheCustomerSelection();

        }
        //=================================================================================================================================
        //=============This Codes Below For Get Data From DivisionsNames Table / Using DivisionsNameGetData Procedure 
        public DataTable GetDivisionData()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("DivisionNamesGetdata", null);
            dal.close();
            return Dt;
        }
        //=============================================================
        //=============This Codes Below For Get Data From DivisionsNames Table / Using DivisionsNameGetData Procedure 
        public DataTable DivisionsNameGetData(DataGridView Dgv,TextBox tbdata,TextBox tbseq,Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("DivisionNamesGetdata", null);
            dal.close();
            Dgv.DataSource = null;Dgv.DataSource = Dt;
            foreach(Control p in pn.Controls) { if(p is TextBox) { (p as TextBox).DataBindings.Clear(); } }
            Dgv.Columns[0].Visible = false;
            Dgv.Columns[1].HeaderText = "اسم الشعبة";
            tbdata.DataBindings.Add("text", Dt, "DivisionName");
            tbseq.DataBindings.Add("Text", Dt, "IDdivision");
            return Dt;
        }
        //=============================================================
        //===========this codes below For insert data to the Divisionsnames Table / Using the DivisionsNameInsertData Procedure
        public void DivisionsNameInsertDdata(DataGridView dgv,TextBox tbdataR,TextBox tbseqR,Panel pnR,string tbdata)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@divisionName", SqlDbType.VarChar, 50);                param[0].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("DivisionNamesInsertData", param);
            dal.close();
            DivisionsNameGetData(dgv, tbdataR, tbseqR,pnR);
         }
        //==============================================================
        //========= This Codes Below For Update Data to DivisionsName tabel / Using The DivisionsNameUpdatedata Procedure 
        public void DivisionsNameUpdateData(DataGridView dgv,TextBox tbdataR,TextBox tbseqR,Panel pnR,string tbdata,int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDdivision", SqlDbType.Int);                          param[0].Value = tbseq;
            param[1] = new SqlParameter("@Divisionname", SqlDbType.VarChar, 50);                param[1].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("DivisionNamesUpdatedate", param);
            dal.close();
            DivisionsNameGetData(dgv, tbdataR, tbseqR, pnR);
        }
        //===================================================================
        //============== This Codes Below For Delete Data From DivisionsName Tabel / Using the DivisionNameDeleteData Procedure
        public void DivisionsNameDeleteData(DataGridView dgv,TextBox tbdataR,TextBox tbseqR,Panel pnR,int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdivision", SqlDbType.Int);                            param[0].Value = tbseq;
            dal.open();
            dal.ExecuteCommand("DivisionsNamesDeletedate", param);
            dal.close();
            DivisionsNameGetData(dgv, tbdataR, tbseqR, pnR);
        }
        //==========================================================================================================================
        //=========================================================================================================================
        //========================== This codes Blewo for Getting Data From UnitsName Table / Using the UnitsNameGetdata Procedure
        public DataTable UnitsNamesGetdata(DataGridView dgv,TextBox tbdata,TextBox tbseq,Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("UnitsNameGetDate", null);
            dal.close();
            dgv.DataSource = null;dgv.DataSource = Dt;
            foreach(Control p in pn.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); } }
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "اسم الوحدة";
            tbdata.DataBindings.Add("text", Dt, "UnitName");
            tbseq.DataBindings.Add("text", Dt, "IDunit");
            return Dt;
        }
        //=======================================================================================
        //=========== This Codes Below For Insertdata to the UnitsNames tabel / Using the UnitsNameinsertdata
        public void UnitsNamesInsertdata(DataGridView dgv,TextBox tbdataR,TextBox tbseqR,Panel pnR,string tbdata)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UnitName", SqlDbType.VarChar, 50);                param[0].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("UnitsNameInserData", param);
            dal.close();
            UnitsNamesGetdata(dgv, tbdataR, tbseqR, pnR);
        }
        //==========================================================================================
        //============ this Codes below for Update data to the Unistsnames table / using the UnitsNameUpdatedate procedure 
        public void UnitsNamesUpdatedata (DataGridView dgv,TextBox tbdataR,TextBox tbseqR,Panel pnR,string tbdata,int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDUnit", SqlDbType.Int);                              param[0].Value = tbseq;
            param[1] = new SqlParameter("@Unitname", SqlDbType.VarChar, 50);                    param[1].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("UnitsNameUpdateDate", param);
            dal.close();
            UnitsNamesGetdata(dgv, tbdataR, tbseqR, pnR);
        }
        //======================================================================
        //================
        public void UnitsNamesDeleteData(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, Panel pnR, int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDUnit", SqlDbType.Int);                              param[0].Value = tbseq;
            dal.open();
            dal.ExecuteCommand("UnitsNameDeleteDate", param);
            dal.close();
            UnitsNamesGetdata(dgv, tbdataR, tbseqR, pnR);
        }
        //=============================================================================================================================
        //===========================================================================================================================
        //================= this codes below for getting data from jobsNames tabel / Using the JobsNamesGetdata Procedure 
        public DataTable JobsNamesGetdata(DataGridView dgv, TextBox tbdata, TextBox tbseq, TextBox tbcount, Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("JobsNameGetDate", null);
            DataTable DtCount = dal.SelectingData("RPEMP_JobsName", null);
            dal.close();
            //dgv.DataSource = null; dgv.DataSource = Dt;
            //dgv.Columns[0].Visible = false;
            //dgv.Columns[1].HeaderText = "اسم الوظيفة";
            //dgv.Columns[2].HeaderText = "عدد الموظفين الكلي";
            //dgv.Columns[3].HeaderText = "عدد الموظفين الحالي";


            DataTable dtrow = new DataTable();
            dtrow.Clear();
            dtrow.Columns.Add("تسلسل");
            dtrow.Columns.Add("اسم الوظيفة");
            dtrow.Columns.Add("العدد الكلي");
            dtrow.Columns.Add("العدد الحالي");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                int j = 0;
                object[] row;
                while (j < DtCount.Rows.Count)
                {
                    if (DtCount.Rows[j][0].ToString().Equals(Dt.Rows[i][1].ToString()))
                        break;
                    j++;
                }
                if(j< DtCount.Rows.Count)
                    row = new string[] { Dt.Rows[i][0].ToString(), Dt.Rows[i][1].ToString(), Dt.Rows[i][2].ToString(), DtCount.Rows[j][1].ToString() };
                else
                    row = new string[] { Dt.Rows[i][0].ToString(), Dt.Rows[i][1].ToString(), Dt.Rows[i][2].ToString(), "0" };
                dtrow.Rows.Add(row);
            }
            dgv.DataSource = null; dgv.DataSource = dtrow;
            dgv.Columns[0].Visible = false;
            foreach (Control p in pn.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); } }
            tbdata.DataBindings.Add("text", dtrow, "اسم الوظيفة");
            tbseq.DataBindings.Add("text", dtrow, "تسلسل");
            tbcount.DataBindings.Add("text", dtrow, "العدد الكلي");
            return Dt;
        }
        //===================================================================
        //=============This Codes below for insert data to the JobsNames Table / Using the Jobsnameainsertdata Procedure
        public void JobsNamesinsertData(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, TextBox tbcount, Panel pnR, string tbdata)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Jobname", SqlDbType.VarChar, 50);                 param[0].Value = tbdata;
            param[1] = new SqlParameter("@Count", SqlDbType.Int);                           param[1].Value = int.Parse(tbcount.Text);
            dal.open();
            dal.ExecuteCommand("JobsNameInsertData", param);
            dal.close();
            JobsNamesGetdata(dgv, tbdataR, tbseqR, tbcount, pnR);
        }
        //========================================================================
        //============= This codes Below for Update data to the JobsNames tabel / Using the JobsNameUpdatedate Procedure
        public void JobsNamesUpdatedata(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, TextBox tbcount, Panel pnR, string tbdata, int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IDjobname", SqlDbType.Int);                       param[0].Value = tbseq;
            param[1] = new SqlParameter("@JobName", SqlDbType.VarChar, 50);                 param[1].Value = tbdata;
            param[2] = new SqlParameter("@Count", SqlDbType.Int);                           param[2].Value = int.Parse(tbcount.Text);
            dal.open();
            dal.ExecuteCommand("jobsNameUpdateDate", param);
            dal.close();
            JobsNamesGetdata(dgv, tbdataR, tbseqR, tbcount, pnR);
        }
        //==========================================================================
        //=========== This Codes below for Delete Data from Jobsnames table / Using the Jobsnamedeletedata Procedure
        public void JobsNamesdeleteData(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, TextBox tbcount, Panel pnR, int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDjobname", SqlDbType.Int);                       param[0].Value = tbseq;
            dal.open();
            dal.ExecuteCommand("JobsNamesDeleteDate", param);
            dal.close();
            JobsNamesGetdata(dgv, tbdataR, tbseqR, tbcount, pnR);
        }
        //============================================================================================================================
        //===========================================================================================================================
        //=================== This codes below for Getting data from StudyingNames table / Using the StudyingNamegetdata Procedure
        public DataTable StudyingNamesGetData(DataGridView dgv, TextBox tbdata, TextBox tbseq, Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("StudyingNameGetData", null);
            dal.close();
            dgv.DataSource = null; dgv.DataSource = Dt;
            foreach (Control p in pn.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); } }
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "الشهادة";
            tbdata.DataBindings.Add("text", Dt, "StudyingName");
            tbseq.DataBindings.Add("text", Dt, "IDstudy");
            return Dt;
        }
        //=====================================================================
        //================= This codes below for Insert data to the studyingname tabel / Using the StudyingNameInsertData Procedure
        public void StudyingNamesinsertdata(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, Panel pnR, string tbdata)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StudyingName", SqlDbType.VarChar, 50);                 param[0].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("StudyingNameInsertData", param);
            dal.close();
            StudyingNamesGetData(dgv, tbdataR, tbseqR, pnR);
        }
        //========================================================================
        //============= this codes below for Update data to the studyingNames table / using the StudyingNameupdatedata Procedure
        public void StudyingNamesUpdatedata(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, Panel pnR, string tbdata, int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDstudying", SqlDbType.Int);                    param[0].Value = tbseq;
            param[1] = new SqlParameter("@Studyingname", SqlDbType.VarChar, 50);              param[1].Value = tbdata;
            dal.open();
            dal.ExecuteCommand("StudyingNameUpdatedata", param);
            dal.close();
            StudyingNamesGetData(dgv, tbdataR, tbseqR, pnR);
        }
        //=========================================================================
        //================ This codes below for delete data from studyingnames table / Using the StudyingNameDeletedata Procedure
        public void StudyingNamesDeletedata(DataGridView dgv, TextBox tbdataR, TextBox tbseqR, Panel pnR, int tbseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDstudying", SqlDbType.Int);                      param[0].Value = tbseq;
            dal.open();
            dal.ExecuteCommand("StudyingNameDeleteData", param);
            dal.close();
            StudyingNamesGetData(dgv, tbdataR, tbseqR, pnR);
        }
        //=================================================================================================================================
        //=================================================================================================================================
        //====================================================================================================================================
        public DataTable JobsNamesGettingdata()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("JobsNameGetDate", null);
            dal.close();
                   
           
            return Dt;
        }
        //==================================
        public DataTable DivisionsNameGettingData()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("DivisionNamesGetdata", null);
            dal.close();
           return Dt;
        }
        //===================================
        public DataTable UnitsNamesGettingdata()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("UnitsNameGetDate", null);
            dal.close();
          return Dt;
        }
        //=======================================
        public DataTable StudyingNamesGettingData()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("StudyingNameGetData", null);
            dal.close();
         return Dt;
        }
        //================================================================================================================================================

        public DataTable GetDataTbpreview()//---------------------------------جلب بيانات جدول المعاينة
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt =dal.SelectingData("Tbpreview", null);
          
            dal.close();

            return Dt;
        }
        //=================================================
        // Get Name of Employees
        public DataTable GetnameEmployees()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("GetNameEmployee", null);
            dal.close();
            return Dt;
        }
        //================================================================
        // Get Name of Employees with barcode
        public DataTable GetnameEmployeeswithBarcode(string Empname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);param[0].Value = Empname;
            dal.open();
            DataTable Dt = dal.SelectingData("Employeessheft2Select2", param);
            dal.close();
            return Dt;
        }

        //================================================================
        //Get Date of Stores
        public DataTable SelectAllStores()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable dt = dal.SelectingData("StoriesSelection", null);
            dal.close();
            return dt;
        }

        //===============================================================
        //this function use to add new store
        public void AddNewStore(string Name, string location, string Desc,Double MaxQuantity)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);                       param[0].Value = Name;
            param[1] = new SqlParameter("@StoreLocation", SqlDbType.VarChar, 50);                   param[1].Value = location;
            param[2] = new SqlParameter("@Description", SqlDbType.Text);                            param[2].Value = Desc;
            dal.open();
            dal.ExecuteCommand("StoriesInsertInto", param);
            dal.close();
           
            DataTable dt = SelectAllStores();

            DAL.DataAccessLayer dal1 = new DAL.DataAccessLayer();
            SqlParameter[] param1 = new SqlParameter[4];
            param1[0] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50); param1[0].Value = Name;
            param1[1] = new SqlParameter("@quantity", SqlDbType.Real); param1[1].Value = 0;
            param1[2] = new SqlParameter("@MaxQuantity", SqlDbType.Real); param1[2].Value = MaxQuantity;
            param1[3] = new SqlParameter("@StForeignKey", SqlDbType.Int); param1[3].Value = Convert.ToInt32(dt.Rows[(dt.Rows.Count)-1][0]);
            dal1.open();
            dal1.ExecuteCommand("TheStoreInsertInto", param1);
            dal1.close();

            CLS_FUEL store = new CLS_FUEL();
            DataTable dt1= store.SelectStores();
            param1 = new SqlParameter[8];
            param1[0] = new SqlParameter("@IDcon", SqlDbType.VarChar, 50); param1[0].Value = Convert.ToInt32(dt1.Rows[(dt1.Rows.Count)-1][0]); 
            param1[1] = new SqlParameter("@Price", SqlDbType.Real); param1[1].Value = 0;
            param1[2] = new SqlParameter("@percentageAdd", SqlDbType.Real); param1[2].Value = 0;
            param1[3] = new SqlParameter("@PriceTransport", SqlDbType.Real); param1[3].Value =0;
            param1[4] = new SqlParameter("@priceTransporteInvest", SqlDbType.Real); param1[4].Value = 0;
            param1[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50);
            param1[5].Value = null;
            param1[6] = new SqlParameter("@addingtime", SqlDbType.VarChar, 50);
            param1[6].Value = null;
            param1[7] = new SqlParameter("@addingdate", SqlDbType.VarChar, 50);
            param1[7].Value = null;
            dal1.open();
            dal1.ExecuteCommand("FuelPriceInsert", param1);
            dal1.close();
        }

        //===============================================================
        //this Function use to update info of any store in stores
        public void UpdateStore(int IDStore, string Name, string location, string Desc,double MaxQuantity)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@IDstore", SqlDbType.Int);                               param[0].Value = IDStore;
            param[1] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);                     param[1].Value = Name;
            param[2] = new SqlParameter("@StoreLocation", SqlDbType.VarChar, 50);                 param[2].Value = location;
            param[3] = new SqlParameter("@Description", SqlDbType.Text);                          param[3].Value = Desc;
            dal.open();
            dal.ExecuteCommand("StoriesUPdate", param);
            dal.close();

            param = new SqlParameter[3];
            param[0] = new SqlParameter("@IDForegnKey", SqlDbType.Int);                           param[0].Value = IDStore;
            param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);                     param[1].Value = Name;
            param[2] = new SqlParameter("@MaxQuantity", SqlDbType.VarChar, 50);                   param[2].Value = MaxQuantity;
            dal.open();
            dal.ExecuteCommand("TheStoreUPdateInfo", param);
            dal.close();
        }

        //===============================================================
        //This Function use to Delete any store 
        public void DeleteStore(int IDStore)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDstore", SqlDbType.Int);                               param[0].Value = IDStore;
            dal.open();
            dal.ExecuteCommand("StoriesDeleting", param);
            dal.close();

            CLS_FUEL store = new CLS_FUEL();
            DataTable dt1 = store.SelectStores();

            param[0] = new SqlParameter("@IDst", SqlDbType.Int);                                  param[0].Value = IDStore;
            dal.open();
            dal.ExecuteCommand("TheStoreDeleting", param);
            dal.close();

           
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = Convert.ToInt32(dt1.Rows[(dt1.Rows.Count) - 1][0]); 
            dal.open();
            dal.ExecuteCommand("FuelPriceDeleting", param);
            dal.close();


        }

        //===============================================================
        //This Function use to get notification 
     
        
        public List<Tuple<string,int>> notifcation()
        {
            List<Tuple<string,int>> textlist = new List<Tuple<string,int>>();
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeconstractGetEndDate", null);
            dal.close();
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                double total_days = ((DateTime)Dt.Rows[i][6]- DateTime.Today ).TotalDays;
                if (total_days <= 0)
                {
                    textlist.Add(new Tuple<string, int>("("+Dt.Rows[i][2].ToString() + ") اتم فترة العقد",1));
                }
            }

            dal.open();
            DataTable Dtbook = dal.SelectingData("ThatyiaAttentionSelectionAll", null);
            dal.close();
            for (int i = 0; i < Dtbook.Rows.Count; i++)
            {
                if ((bool)Dtbook.Rows[i][9] == false)
                {
                    DateTime d = (DateTime)Dtbook.Rows[i][4];
                    if ((bool)Dtbook.Rows[i][5] == true)
                    {
                        d = d.AddDays((int)Dtbook.Rows[i][7]);
                    }
                    if ((bool)Dtbook.Rows[i][6] == true)
                    {
                        d = d.AddDays(-(int)Dtbook.Rows[i][7]);
                    }
                    double total_days = (d - DateTime.Today).TotalDays;
                    if (total_days <= 0)
                    {
                        textlist.Add(new Tuple<string, int>(Dtbook.Rows[i][2].ToString()+" "+ Dtbook.Rows[i][13].ToString() + " " + Dtbook.Rows[i][3].ToString() + " (" + Dtbook.Rows[i][8].ToString()+")",2));
                    }
                } 
            }

            dal.open();
            DataTable DtEmp = dal.SelectingData("EmployeeVariableSelectingAll", null);
            dal.close();

            for (int i = 0; i < DtEmp.Rows.Count; i++)
            {
               
                if ((int)DtEmp.Rows[i][0] >= 30428)
                {
                    int d = int.Parse(DtEmp.Rows[i][4].ToString());
                    if (d >= 30 && (((DateTime)DtEmp.Rows[i][7] - DateTime.Today).TotalDays == 0))
                    {
                        textlist.Add(new Tuple<string, int>("("+DtEmp.Rows[i][2].ToString() + ") انتهت اجزاته ",1));
                    }
                }
            }

            dal.open();
            DataTable DtBook = dal.SelectingData("BookReciveSelectingDataNotific", null);
            dal.close();
            for (int i = 0; i < DtBook.Rows.Count; i++)
            {               
                 textlist.Add(new Tuple<string, int>("تم استلام كتاب رقم " + DtBook.Rows[i][0].ToString() + " من " + DtBook.Rows[i][1].ToString(), 3));               
            }
            return textlist;
        }
      
    }
}
