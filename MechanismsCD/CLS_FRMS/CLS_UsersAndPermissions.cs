using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace MechanismsCD.CLS_FRMS
{
    class CLS_UsersAndPermissions
    {

        //=== This Function Below for Getting Data from the UsersTable by using the 
        // === Stored Procedure UsersSelection...
        public DataTable UsersGettingData(TextBox Users_ID, TextBox Users_UserName, TextBox Users_Password, System.Windows.Forms.ComboBox Users_Permission
           , TextBox Users_RegisterName, TextBox Users_AddingTime, TextBox Users_AddingDatge, Panel Pn1, Panel Pn2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("UsersSelecting", null);
            dal.close();
            foreach (Control item in Pn1.Controls)
            {
                if (item is TextBox || item is System.Windows.Forms.ComboBox) item.DataBindings.Clear();
            }
            string st = "Text";
            Users_ID.DataBindings.Add(st, Dt, "IDUser"); Users_ID.Enabled = false; Users_ID.ReadOnly = true;
            Users_UserName.DataBindings.Add(st, Dt, "UserName");
            Users_Password.DataBindings.Add(st, Dt, "Password");
            Users_Permission.DataBindings.Add(st, Dt, "Permissions");
            Users_RegisterName.DataBindings.Add(st, Dt, "RegisterName"); Users_RegisterName.Enabled = false;
            Users_AddingTime.DataBindings.Add(st, Dt, "AddingTime"); Users_AddingTime.Enabled = false;
            Users_AddingDatge.DataBindings.Add(st, Dt, "AddingDate"); Users_AddingDatge.Enabled = false;
            return Dt;
        }
        //==========================================================================================================================
        //==== this function below for inserting data to the UsersTable  by using the Stored Procedure (UsersInsertInto) .......
        public void UsersInserting(string Users_UserName, string Users_Password, string Users_Permission, string Users_RegisterName
            , string Users_AddingTime, string Users_AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = Users_UserName;
            param[1] = new SqlParameter("@psw", SqlDbType.VarChar, 50); param[1].Value = Users_Password;
            param[2] = new SqlParameter("@Permission", SqlDbType.VarChar, 50); param[2].Value = Users_Permission;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[3].Value = Users_RegisterName;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[4].Value = Users_AddingTime;
            param[5] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[5].Value = Users_AddingDate;

            dal.open();
            dal.ExecuteCommand("UsersInsertInto", param);
            dal.close();

        }
        //=================================================================================================================================
        //=== This Function below for Updating Data of UsersTable by using UsersUpdate Stored Procedure .....
        public void UsersUpdating(string Users_UserName, string Users_Password, string Users_Permission, string Users_RegisterName
            , string Users_AddingTime, string Users_AddingDate, int IDusers)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = Users_UserName;
            param[1] = new SqlParameter("@psw", SqlDbType.VarChar, 50); param[1].Value = Users_Password;
            param[2] = new SqlParameter("@Permission", SqlDbType.VarChar, 50); param[2].Value = Users_Permission;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[3].Value = Users_RegisterName;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[4].Value = Users_AddingTime;
            param[5] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[5].Value = Users_AddingDate;
            param[6] = new SqlParameter("@IDusers", SqlDbType.Int); param[6].Value = IDusers;
            dal.open();
            dal.ExecuteCommand("UsersUpate", param);
            dal.close();

        }
        //==================================================================================================================================
        //===This Funtion below for Deleting Data from usersTable by using usersDeleting Stored procedure......
        public void UsersDeleting(int IDusers)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDusers", SqlDbType.Int); param[0].Value = IDusers;
            dal.open();
            dal.ExecuteCommand("usersDeleting", param);
            dal.close();

        }
        //=================================================================================================================================
        //====This Function below for getting data from Userstable2 by using Users2Selections2 Stored procedure......
        public DataTable Users2Selection2(CheckedListBoxControl Lst, TextBox User2_ID, TextBox Users2_IDcon, TextBox Users2_UserName, int Users_IDcon
            , TextBox Users2_PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = Users_IDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("Users2Selection2", param);
            dal.close();

            Lst.DataBindings.Clear();
            Lst.Items.Clear();
            if (Dt.Rows.Count > 0)
            {
                for (int i = 4; i < Dt.Columns.Count; i++)
                {
                    if (Dt.Rows[0][i].ToString() != "True" || Dt.Rows[0][i].ToString() == null || Dt.Rows[0][i].ToString() == "")
                    {
                        Lst.Items.Add(Dt.Columns[i].ColumnName, false);
                    }
                    else
                    {
                        Lst.Items.Add(Dt.Columns[i].ColumnName, true);
                    }
                }
                User2_ID.DataBindings.Clear(); Users2_IDcon.DataBindings.Clear(); Users2_UserName.DataBindings.Clear(); Users2_PassWord.DataBindings.Clear();
                string st = "text";
                User2_ID.DataBindings.Add(st, Dt, "الرقم التعريفي");
                Users2_IDcon.DataBindings.Add(st, Dt, "رقم الاتصال");
                Users2_UserName.DataBindings.Add(st, Dt, "اسم المستخدم");
                Users2_PassWord.DataBindings.Add(st, Dt, "كلمة المرور");

            }
            else
            {
                for (int i = 4; i < Dt.Columns.Count; i++)
                {
                    Lst.Items.Add(Dt.Columns[i].ColumnName, false);

                }
            }


            return Dt;

        }
        //==============================================================================================================================================
        //===This function below for inserting data to the user2tabel by using the Users2Insertinto Stored procedure.....
        public void Users2Inserting(int ID_con, string UserName, string PassWord, bool P_backup, bool P_reconvery, bool Frm_typetype, bool Frm_Department, bool Frm_Places, bool Frm_Customer
            , bool Frm_Divisions, bool Frm_Units, bool Frm_Jobs, bool Frm_Studies, bool Frm_Employees, bool Frm_Attendence, bool Frm_WorkingSheft, bool Frm_Deserving
            , bool Frm_Dispatches, bool Frm_Cars, bool Frm_CarsMovements, bool Frm_CarSituations, bool Frm_CarAccidents, bool Frm_CarFuel, bool frm_Car_Counters, bool Frm_Archieves
            , bool Frm_Advisor, bool Frm_SystemSetting, bool Frm_Users, bool FRM_Synchornization, bool FRM_AdminOrders, bool FRM_Variables, bool FRM_Constractes, bool FRM_ChildInfo, bool FRM_Zamaniat, bool FRM_Tanseeb, bool FRM_Archive, bool FRM_DivReceive, bool FRM_DeservePressing, bool FRM_DeserveSatisfying)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[39];
            param[0] = new SqlParameter("@ID_con", SqlDbType.Int);                  param[0].Value = ID_con;
            param[1] = new SqlParameter("@UserName_2", SqlDbType.VarChar, 50);      param[1].Value = UserName;
            param[2] = new SqlParameter("@PassWord_3", SqlDbType.VarChar, 50);      param[2].Value = PassWord;
            param[3] = new SqlParameter("@P_BackUp_3", SqlDbType.Bit);              param[3].Value = P_backup;
            param[4] = new SqlParameter("@P_Recovery_4", SqlDbType.Bit);            param[4].Value = P_reconvery;
            param[5] = new SqlParameter("@FRM_TypeType_5", SqlDbType.Bit);          param[5].Value = Frm_typetype;
            param[6] = new SqlParameter("@FRM_Department_6", SqlDbType.Bit);        param[6].Value = Frm_Department;
            param[7] = new SqlParameter("@FRM_Places_7", SqlDbType.Bit);            param[7].Value = Frm_Places;
            param[8] = new SqlParameter("@FRM_Customer_8", SqlDbType.Bit);          param[8].Value = Frm_Customer;
            param[9] = new SqlParameter("@FRM_Divisions_9", SqlDbType.Bit);         param[9].Value = Frm_Divisions;
            param[10] = new SqlParameter("@FRM_Units_10", SqlDbType.Bit);           param[10].Value = Frm_Units;
            param[11] = new SqlParameter("@FRM_Jobs_11", SqlDbType.Bit);            param[11].Value = Frm_Jobs;
            param[12] = new SqlParameter("@FRM_Studies_12", SqlDbType.Bit);         param[12].Value = Frm_Studies;
            param[13] = new SqlParameter("@FRM_Employees_13", SqlDbType.Bit);       param[13].Value = Frm_Employees;
            param[14] = new SqlParameter("@FRM_Attendenct_14", SqlDbType.Bit);      param[14].Value = Frm_Attendence;
            param[15] = new SqlParameter("@FRM_WorkingSheft_15", SqlDbType.Bit);    param[15].Value = Frm_WorkingSheft;
            param[16] = new SqlParameter("@FRM_Deserving_16", SqlDbType.Bit);       param[16].Value = Frm_Deserving;
            param[17] = new SqlParameter("@FRM_Dispatches_17", SqlDbType.Bit);      param[17].Value = Frm_Dispatches;
            param[18] = new SqlParameter("@FRM_Cars_18", SqlDbType.Bit);            param[18].Value = Frm_Cars;
            param[19] = new SqlParameter("@FRM_CarsMovements_19", SqlDbType.Bit);   param[19].Value = Frm_CarsMovements;
            param[20] = new SqlParameter("@FRM_CarSituations_20", SqlDbType.Bit);   param[20].Value = Frm_CarSituations;
            param[21] = new SqlParameter("@FRM_CarAccidents_21", SqlDbType.Bit);    param[21].Value = Frm_CarAccidents;
            param[22] = new SqlParameter("@FRM_CarFuel_22", SqlDbType.Bit);         param[22].Value = Frm_CarFuel;
            param[23] = new SqlParameter("@FRM_CarCounters_23", SqlDbType.Bit);     param[23].Value = frm_Car_Counters;
            param[24] = new SqlParameter("@FRM_Archeives_24", SqlDbType.Bit);       param[24].Value = Frm_Archieves;
            param[25] = new SqlParameter("@FRM_Advisor_25", SqlDbType.Bit);         param[25].Value = Frm_Advisor;
            param[26] = new SqlParameter("@FRM_SystemSetting_26", SqlDbType.Bit);   param[26].Value = Frm_SystemSetting;
            param[27] = new SqlParameter("@FRM_Users_27", SqlDbType.Bit);           param[27].Value = Frm_Users;
            param[28] = new SqlParameter("@FRM_Synchornization", SqlDbType.Bit);    param[28].Value = FRM_Synchornization;
            param[29] = new SqlParameter("@FRM_AdminOrders", SqlDbType.Bit);        param[29].Value = FRM_AdminOrders;
            param[30] = new SqlParameter("@FRM_Variables", SqlDbType.Bit);          param[30].Value = FRM_Variables;
            param[31] = new SqlParameter("@FRM_Constractes", SqlDbType.Bit);        param[31].Value = FRM_Constractes;
            param[32] = new SqlParameter("@FRM_ChildInfo", SqlDbType.Bit);          param[32].Value = FRM_ChildInfo;
            param[33] = new SqlParameter("@FRM_Zamaniat", SqlDbType.Bit);           param[33].Value = FRM_Zamaniat;
            param[34] = new SqlParameter("@FRM_Tanseeb", SqlDbType.Bit);            param[34].Value = FRM_Tanseeb;
            param[35] = new SqlParameter("@FRM_Archive", SqlDbType.Bit);            param[35].Value = FRM_Archive;
            param[36] = new SqlParameter("@FRM_DivReceive", SqlDbType.Bit);         param[36].Value = FRM_DivReceive;
            param[37] = new SqlParameter("@FRM_DeservePressing", SqlDbType.Bit);    param[37].Value = FRM_DeservePressing;
            param[38] = new SqlParameter("@FRM_DeserveSatisfying", SqlDbType.Bit);  param[38].Value = FRM_DeserveSatisfying;

            dal.open();
            dal.ExecuteCommand("Users2InsertInto", param);
            dal.close();

        }
        //====================================================================================================================================================
        //== This Function below for updating data of Users2table by using Users2UPdate Stored procedure.....
        public void Users2Updating(int ID_con, string UserName, bool P_backup, bool P_reconvery, bool Frm_typetype, bool Frm_Department, bool Frm_Places, bool Frm_Customer
           , bool Frm_Divisions, bool Frm_Units, bool Frm_Jobs, bool Frm_Studies, bool Frm_Employees, bool Frm_Attendence, bool Frm_WorkingSheft, bool Frm_Deserving
           , bool Frm_Dispatches, bool Frm_Cars, bool Frm_CarsMovements, bool Frm_CarSituations, bool Frm_CarAccidents, bool Frm_CarFuel, bool frm_Car_Counters, bool Frm_Archieves
           , bool Frm_Advisor, bool Frm_SystemSetting, bool Frm_Users, bool Frm_Synchornization, int ID_user2, string Password, bool FRM_AdminOrders, bool FRM_Variables, bool FRM_Constractes,
            bool FRM_ChildInfo, bool FRM_Zamaniat, bool FRM_Tanseeb, bool FRM_Archive, bool FRM_DivReceive, bool FRM_DeservePressing, bool FRM_DeserveSatisfying)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[40];
            param[0] = new SqlParameter("@ID_con", SqlDbType.Int);                          param[0].Value = ID_con;
            param[1] = new SqlParameter("@UserName_2", SqlDbType.VarChar, 50);              param[1].Value = UserName;
            param[2] = new SqlParameter("@P_BackUp_3", SqlDbType.Bit);                      param[2].Value = P_backup;
            param[3] = new SqlParameter("@P_Recovery_4", SqlDbType.Bit);                    param[3].Value = P_reconvery;
            param[4] = new SqlParameter("@FRM_TypeType_5", SqlDbType.Bit);                  param[4].Value = Frm_typetype;
            param[5] = new SqlParameter("@FRM_Department_6", SqlDbType.Bit);                param[5].Value = Frm_Department;
            param[6] = new SqlParameter("@FRM_Places_7", SqlDbType.Bit);                    param[6].Value = Frm_Places;
            param[7] = new SqlParameter("@FRM_Customer_8", SqlDbType.Bit);                  param[7].Value = Frm_Customer;
            param[8] = new SqlParameter("@FRM_Divisions_9", SqlDbType.Bit);                 param[8].Value = Frm_Divisions;
            param[9] = new SqlParameter("@FRM_Units_10", SqlDbType.Bit);                    param[9].Value = Frm_Units;
            param[10] = new SqlParameter("@FRM_Jobs_11", SqlDbType.Bit);                    param[10].Value = Frm_Jobs;
            param[11] = new SqlParameter("@FRM_Studies_12", SqlDbType.Bit);                 param[11].Value = Frm_Studies;
            param[12] = new SqlParameter("@FRM_Employees_13", SqlDbType.Bit);               param[12].Value = Frm_Employees;
            param[13] = new SqlParameter("@FRM_Attendenct_14", SqlDbType.Bit);              param[13].Value = Frm_Attendence;
            param[14] = new SqlParameter("@FRM_WorkingSheft_15", SqlDbType.Bit);            param[14].Value = Frm_WorkingSheft;
            param[15] = new SqlParameter("@FRM_Deserving_16", SqlDbType.Bit);               param[15].Value = Frm_Deserving;
            param[16] = new SqlParameter("@FRM_Dispatches_17", SqlDbType.Bit);              param[16].Value = Frm_Dispatches;
            param[17] = new SqlParameter("@FRM_Cars_18", SqlDbType.Bit);                    param[17].Value = Frm_Cars;
            param[18] = new SqlParameter("@FRM_CarsMovements_19", SqlDbType.Bit);           param[18].Value = Frm_CarsMovements;
            param[19] = new SqlParameter("@FRM_CarSituations_20", SqlDbType.Bit);           param[19].Value = Frm_CarSituations;
            param[20] = new SqlParameter("@FRM_CarAccidents_21", SqlDbType.Bit);            param[20].Value = Frm_CarAccidents;
            param[21] = new SqlParameter("@FRM_CarFuel_22", SqlDbType.Bit);                 param[21].Value = Frm_CarFuel;
            param[22] = new SqlParameter("@FRM_CarCounters_23", SqlDbType.Bit);             param[22].Value = frm_Car_Counters;
            param[23] = new SqlParameter("@FRM_Archeives_24", SqlDbType.Bit);               param[23].Value = Frm_Archieves;
            param[24] = new SqlParameter("@FRM_Advisor_25", SqlDbType.Bit);                 param[24].Value = Frm_Advisor;
            param[25] = new SqlParameter("@FRM_SystemSetting_26", SqlDbType.Bit);           param[25].Value = Frm_SystemSetting;
            param[26] = new SqlParameter("@FRM_Users_27", SqlDbType.Bit);                   param[26].Value = Frm_Users;
            param[27] = new SqlParameter("@IDUsers2", SqlDbType.Int);                       param[27].Value = ID_user2;
            param[28] = new SqlParameter("@PassWord_3", SqlDbType.VarChar, 50);             param[28].Value = Password;
            param[29] = new SqlParameter("@FRM_Synchornization", SqlDbType.Bit);            param[29].Value = Frm_Synchornization;
            param[30] = new SqlParameter("@FRM_AdminOrders", SqlDbType.Bit);                param[30].Value = FRM_AdminOrders;
            param[31] = new SqlParameter("@FRM_Variables", SqlDbType.Bit);                  param[31].Value = FRM_Variables;
            param[32] = new SqlParameter("@FRM_Constractes", SqlDbType.Bit);                param[32].Value = FRM_Constractes;
            param[33] = new SqlParameter("@FRM_ChildInfo", SqlDbType.Bit);                  param[33].Value = FRM_ChildInfo;
            param[34] = new SqlParameter("@FRM_Zamaniat", SqlDbType.Bit);                   param[34].Value = FRM_Zamaniat;
            param[35] = new SqlParameter("@FRM_Tanseeb", SqlDbType.Bit);                    param[35].Value = FRM_Tanseeb;
            param[36] = new SqlParameter("@FRM_Archive", SqlDbType.Bit);                    param[36].Value = FRM_Archive;
            param[37] = new SqlParameter("@FRM_DivReceive", SqlDbType.Bit);                 param[37].Value = FRM_DivReceive;
            param[38] = new SqlParameter("@FRM_DeservePressing", SqlDbType.Bit);            param[38].Value = FRM_DeservePressing;
            param[39] = new SqlParameter("@FRM_DeserveSatisfying", SqlDbType.Bit);          param[39].Value = FRM_DeserveSatisfying;

            dal.open();
            dal.ExecuteCommand("Users2UPDate", param);
            dal.close();

        }
        //====================================================================================================================================================================
        //=========this function below for Getting data from Frm_name Table by using stored procedure Frm_Name...
        public DataTable Frm_NameGettingData()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("getfrmname", null);
            dal.close();
            return Dt;
        }
        //====================================================================================================================================================================
        //==== this function below for Getting data from Users3Selecting2 Stored procedure ......
        public DataTable Users3Selecting2(DataGridView Dgv, int IDcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("Users3Selecting2", param);
            dal.close();
            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            for (int i = 0; i < 4; i++)
            {
                Dgv.Columns[i].Visible = false;
            }


            return Dt;
        }
        //======================================================================================================================================================================
        //== this function below for inserting data to the Users3table by using stored procedure Users3Inserting.....
        public void Users3InsertingData(int IDcon, string UserName, string PassWord, string FrmName, bool Adding, bool Editing, bool Deleting, bool printing)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID_con_1", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@UserName3_2", SqlDbType.VarChar, 50); param[1].Value = UserName;
            param[2] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[2].Value = PassWord;
            param[3] = new SqlParameter("@Frm_Name_3", SqlDbType.VarChar, 50); param[3].Value = FrmName;
            param[4] = new SqlParameter("@Per_Adding_4", SqlDbType.Bit); param[4].Value = Adding;
            param[5] = new SqlParameter("@Per_Editing_5", SqlDbType.Bit); param[5].Value = Editing;
            param[6] = new SqlParameter("@Per_Deleting_6", SqlDbType.Bit); param[6].Value = Deleting;
            param[7] = new SqlParameter("@Per_Printing_7", SqlDbType.Bit); param[7].Value = printing;

            dal.open();
            dal.ExecuteCommand("Users3Inserting", param);
            dal.close();
        }
        //=======================================================================================================================================================================
        //==== This function below for updating data for users3table by using stored procedure Users3Updating.....
        public void Users3UpdatingData(int IDcon, string UserName, string PassWord, string FrmName, bool Adding, bool Editing, bool Deleting, bool printing)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@ID_con_1", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@UserName3_2", SqlDbType.VarChar, 50); param[1].Value = UserName;
            param[2] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[2].Value = PassWord;
            param[3] = new SqlParameter("@Frm_Name_3", SqlDbType.VarChar, 50); param[3].Value = FrmName;
            param[4] = new SqlParameter("@Per_Adding_4", SqlDbType.Bit); param[4].Value = Adding;
            param[5] = new SqlParameter("@Per_Editing_5", SqlDbType.Bit); param[5].Value = Editing;
            param[6] = new SqlParameter("@Per_Deleting_6", SqlDbType.Bit); param[6].Value = Deleting;
            param[7] = new SqlParameter("@Per_Printing_7", SqlDbType.Bit); param[7].Value = printing;


            dal.open();
            dal.ExecuteCommand("Users3Updating", param);
            dal.close();
        }
        //====================================================================================================================================================
        //==== This Function below for getting data from Users4Table by using Stored Procedure ( Users4Selecting2 ).....
        public DataTable Users4Selection2(CheckedListBoxControl Lst, int Users_IDcon, TextBox ID_user4)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = Users_IDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("User4Selecting2", param);
            dal.close();

            Lst.DataBindings.Clear();
            Lst.Items.Clear();
            if (Dt.Rows.Count > 0)
            {
                for (int i = 4; i < Dt.Columns.Count; i++)
                {
                    if (Dt.Rows[0][i].ToString() != "True" || Dt.Rows[0][i].ToString() == null || Dt.Rows[0][i].ToString() == "")
                    {
                        Lst.Items.Add(Dt.Columns[i].ColumnName, false);
                    }
                    else
                    {
                        Lst.Items.Add(Dt.Columns[i].ColumnName, true);
                    }
                }

            }
            else
            {
                for (int i = 4; i < Dt.Columns.Count; i++)
                {
                    Lst.Items.Add(Dt.Columns[i].ColumnName, false);

                }
            }
            ID_user4.DataBindings.Clear();
            ID_user4.DataBindings.Add("Text", Dt, "الرقم التعريفي");

            return Dt;

        }
        //=====================================================================================================================================================
        //==== This Function below for Inserting Data to User4Table by using the stored procedure ( User4Inser5ting ) ....
        public void Users4InsertingData(int IDcon, string UserName, bool Rep_CarsMovement, bool Rep_Cars, bool Rep_CarSituations, bool Rep_CarFuel, bool Rep_CarAccident
            , bool Rep_CarCounters, bool Rep_Employees, bool Rep_Attendance, string PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@ID_con_1", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@UserName4_2", SqlDbType.VarChar, 50); param[1].Value = UserName;
            param[2] = new SqlParameter("@Rep_CarsMovement_3", SqlDbType.Bit); param[2].Value = Rep_CarsMovement;
            param[3] = new SqlParameter("@Rep_Cars_4", SqlDbType.Bit); param[3].Value = Rep_Cars;
            param[4] = new SqlParameter("@Rep_CarSituations_5", SqlDbType.Bit); param[4].Value = Rep_CarSituations;
            param[5] = new SqlParameter("@Rep_CarFuel_6", SqlDbType.Bit); param[5].Value = Rep_CarFuel;
            param[6] = new SqlParameter("@Rep_CarAccident_7", SqlDbType.Bit); param[6].Value = Rep_CarAccident;
            param[7] = new SqlParameter("@Rep_CarCounters_8", SqlDbType.Bit); param[7].Value = Rep_CarCounters;
            param[8] = new SqlParameter("@Rep_Employees_9", SqlDbType.Bit); param[8].Value = Rep_Employees;
            param[9] = new SqlParameter("@UserPassWord", SqlDbType.VarChar, 50); param[9].Value = PassWord;
            param[10] = new SqlParameter("@Rep_Attendance_10", SqlDbType.Bit); param[10].Value = Rep_Attendance;
            dal.open();
            dal.ExecuteCommand("User4Inserting", param);
            dal.close();
        }

        //=====================================================================================================================================================
        //-=== This function below for updating data of user4table by using stored procedure ( user4Updating ) ...
        public void Users4UpdatingData(int IDcon, string UserName, bool Rep_CarsMovement, bool Rep_Cars, bool Rep_CarSituations, bool Rep_CarFuel, bool Rep_CarAccident
                 , bool Rep_CarCounters, bool Rep_Employees, bool Rep_Attendance, int ID_users4, string PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@ID_con_1", SqlDbType.Int); param[0].Value = IDcon;
            param[1] = new SqlParameter("@UserName4_2", SqlDbType.VarChar, 50); param[1].Value = UserName;
            param[2] = new SqlParameter("@Rep_CarsMovement_3", SqlDbType.Bit); param[2].Value = Rep_CarsMovement;
            param[3] = new SqlParameter("@Rep_Cars_4", SqlDbType.Bit); param[3].Value = Rep_Cars;
            param[4] = new SqlParameter("@Rep_CarSituations_5", SqlDbType.Bit); param[4].Value = Rep_CarSituations;
            param[5] = new SqlParameter("@Rep_CarFuel_6", SqlDbType.Bit); param[5].Value = Rep_CarFuel;
            param[6] = new SqlParameter("@Rep_CarAccident_7", SqlDbType.Bit); param[6].Value = Rep_CarAccident;
            param[7] = new SqlParameter("@Rep_CarCounters_8", SqlDbType.Bit); param[7].Value = Rep_CarCounters;
            param[8] = new SqlParameter("@Rep_Employees_9", SqlDbType.Bit); param[8].Value = Rep_Employees;
            param[9] = new SqlParameter("@IDUsers", SqlDbType.Int); param[9].Value = ID_users4;
            param[10] = new SqlParameter("@UserPassWord", SqlDbType.VarChar, 50); param[10].Value = PassWord;
            param[11] = new SqlParameter("@Rep_Attendance_10", SqlDbType.Bit); param[11].Value = Rep_Attendance;
            dal.open();
            dal.ExecuteCommand("User4Updating", param);
            dal.close();
        }

        //===========================================================================================================================================================
        //==== This Function below for Login........
        public DataTable Login_Users(string UserName, string Password)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = UserName;
            param[1] = new SqlParameter("@Password", SqlDbType.VarChar, 50); param[1].Value = Password;
            dal.open();
            DataTable Dt = dal.SelectingData("UserLogin", param);
            dal.close();


            return Dt;
        }
        //=================================================================================================
        //=== This Function Below for Execute Permission One....
        public DataTable PerOne(string UserName, string PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = UserName;
            param[1] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[1].Value = PassWord;
            dal.open();
            DataTable Dt = dal.SelectingData("PerOne", param);
            dal.close();

            return Dt;

        }
        //==================================================================================================
        public void PerTow(DataTable Dt, SimpleButton btnBackup, SimpleButton btnRecovery, SimpleButton frmthetype
            , SimpleButton frmdepartment, SimpleButton frmplaces, SimpleButton frmcustomer, SimpleButton frmdivisions, SimpleButton frmunits
            , SimpleButton frmjobs, SimpleButton frmstudies, SimpleButton frmemployees, SimpleButton frmattendence, SimpleButton frmworkingsheft
            , SimpleButton frmdeserving, SimpleButton frmdispatches, SimpleButton frmcars, SimpleButton frmcarsmovements, SimpleButton frmcarsituations
            , SimpleButton frmcaraccident, SimpleButton frmcarfuel, SimpleButton frmcarcounters, SimpleButton frmarcheives, SimpleButton frmadvisor
            , SimpleButton frmsystemsetting, SimpleButton frmusers, SimpleButton FRM_Synchornization, SimpleButton FRM_DivReceive,
            GunaButton btnEmployeem, GunaButton btnArchivie, GunaButton btnCar, GunaButton btnDivRecevie)
        {
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][4].ToString() == null || Dt.Rows[0][4].ToString() == "" || Dt.Rows[0][4].ToString() == "False")
                    btnBackup.Enabled = false;
                else btnBackup.Enabled = true;
                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                    btnRecovery.Enabled = false;
                else btnRecovery.Enabled = true;
                if (Dt.Rows[0][6].ToString() == null || Dt.Rows[0][6].ToString() == "" || Dt.Rows[0][6].ToString() == "False")
                    frmthetype.Enabled = false;
                else frmthetype.Enabled = true;
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                    frmdepartment.Enabled = false;
                else frmdepartment.Enabled = true;
                if (Dt.Rows[0][8].ToString() == null || Dt.Rows[0][8].ToString() == "" || Dt.Rows[0][8].ToString() == "False")
                    frmplaces.Enabled = false;
                else frmplaces.Enabled = true;
                if (Dt.Rows[0][9].ToString() == null || Dt.Rows[0][9].ToString() == "" || Dt.Rows[0][9].ToString() == "False")
                    frmcustomer.Enabled = false;
                else frmcustomer.Enabled = true;
                if (Dt.Rows[0][10].ToString() == null || Dt.Rows[0][10].ToString() == "" || Dt.Rows[0][10].ToString() == "False")
                    frmdivisions.Enabled = false;
                else frmdivisions.Enabled = true;
                if (Dt.Rows[0][11].ToString() == null || Dt.Rows[0][11].ToString() == "" || Dt.Rows[0][11].ToString() == "False")
                    frmunits.Enabled = false;
                else frmunits.Enabled = true;
                if (Dt.Rows[0][12].ToString() == null || Dt.Rows[0][12].ToString() == "" || Dt.Rows[0][12].ToString() == "False")
                    frmjobs.Enabled = false;
                else frmjobs.Enabled = true;
                if (Dt.Rows[0][13].ToString() == null || Dt.Rows[0][13].ToString() == "" || Dt.Rows[0][13].ToString() == "False")
                    frmstudies.Enabled = false;
                else frmstudies.Enabled = true;
                if (Dt.Rows[0][14].ToString() == null || Dt.Rows[0][14].ToString() == "" || Dt.Rows[0][14].ToString() == "False")
                {   frmemployees.Enabled = false;
                    btnEmployeem.Enabled = false;
                }
                else{
                    frmemployees.Enabled = true;
                    btnEmployeem.Enabled = true;
                }
                if (Dt.Rows[0][15].ToString() == null || Dt.Rows[0][15].ToString() == "" || Dt.Rows[0][15].ToString() == "False")
                    frmattendence.Enabled = false;
                else frmattendence.Enabled = true;
                if (Dt.Rows[0][16].ToString() == null || Dt.Rows[0][16].ToString() == "" || Dt.Rows[0][16].ToString() == "False")
                    frmworkingsheft.Enabled = false;
                else frmworkingsheft.Enabled = true;
                if (Dt.Rows[0][17].ToString() == null || Dt.Rows[0][17].ToString() == "" || Dt.Rows[0][17].ToString() == "False")
                    frmdeserving.Enabled = false;
                else frmdeserving.Enabled = true;
                if (Dt.Rows[0][18].ToString() == null || Dt.Rows[0][18].ToString() == "" || Dt.Rows[0][18].ToString() == "False")
                    frmdispatches.Enabled = false;
                else frmdispatches.Enabled = true;
                if (Dt.Rows[0][19].ToString() == null || Dt.Rows[0][19].ToString() == "" || Dt.Rows[0][19].ToString() == "False")
                {
                    frmcars.Enabled = false;
                    btnCar.Enabled = false;
                }
                else
                {
                    frmcars.Enabled = true;
                    btnCar.Enabled = true;
                }
                if (Dt.Rows[0][20].ToString() == null || Dt.Rows[0][20].ToString() == "" || Dt.Rows[0][20].ToString() == "False")
                    frmcarsmovements.Enabled = false;
                else frmcarsmovements.Enabled = true;
                if (Dt.Rows[0][21].ToString() == null || Dt.Rows[0][21].ToString() == "" || Dt.Rows[0][21].ToString() == "False")
                    frmcarsituations.Enabled = false;
                else frmcarsituations.Enabled = true;
                if (Dt.Rows[0][22].ToString() == null || Dt.Rows[0][22].ToString() == "" || Dt.Rows[0][22].ToString() == "False")
                    frmcaraccident.Enabled = false;
                else frmcaraccident.Enabled = true;
                if (Dt.Rows[0][23].ToString() == null || Dt.Rows[0][23].ToString() == "" || Dt.Rows[0][23].ToString() == "False")
                    frmcarfuel.Enabled = false;
                else frmcarfuel.Enabled = true;
                if (Dt.Rows[0][24].ToString() == null || Dt.Rows[0][24].ToString() == "" || Dt.Rows[0][24].ToString() == "False")
                    frmcarcounters.Enabled = false;
                else frmcarcounters.Enabled = true;
                if (Dt.Rows[0][25].ToString() == null || Dt.Rows[0][25].ToString() == "" || Dt.Rows[0][25].ToString() == "False")
                {
                    frmarcheives.Enabled = false;
                    btnArchivie.Enabled = false;
                }
                else
                {
                    frmarcheives.Enabled = true;
                    btnArchivie.Enabled = true;
                }
                if (Dt.Rows[0][26].ToString() == null || Dt.Rows[0][26].ToString() == "" || Dt.Rows[0][26].ToString() == "False")
                    frmadvisor.Enabled = false;
                else frmadvisor.Enabled = true;
                if (Dt.Rows[0][27].ToString() == null || Dt.Rows[0][27].ToString() == "" || Dt.Rows[0][27].ToString() == "False")
                    frmsystemsetting.Enabled = false;
                else frmsystemsetting.Enabled = true;
                if (Dt.Rows[0][28].ToString() == null || Dt.Rows[0][28].ToString() == "" || Dt.Rows[0][28].ToString() == "False")
                    frmusers.Enabled = false;
                else frmusers.Enabled = true;
                if (Dt.Rows[0][36].ToString() == null || Dt.Rows[0][36].ToString() == "" || Dt.Rows[0][36].ToString() == "False")
                    FRM_Synchornization.Enabled = false;
                else FRM_Synchornization.Enabled = true;
                if (Dt.Rows[0][37].ToString() == null || Dt.Rows[0][37].ToString() == "" || Dt.Rows[0][37].ToString() == "False")
                {
                    FRM_DivReceive.Enabled = false;
                    btnDivRecevie.Enabled = false;
                }
                else
                {
                    FRM_DivReceive.Enabled = true;
                    btnDivRecevie.Enabled = true;
                }




            }
        }
        //===========================================================================================================================
        //=== This Function Below for Execute Permission Tow....
        public DataTable PerTow(string UserName, string PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = UserName;
            param[1] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[1].Value = PassWord;
            dal.open();
            DataTable Dt = dal.SelectingData("PerTow", param);
            dal.close();

            return Dt;

        }
        //==================================================================================================
        //== This function Below for Permission Tow.......
        public void PerTow2(DataTable Dt, SimpleButton Rep_Carsmovements, SimpleButton Rep_Cars, SimpleButton Rep_CarSituations
            , SimpleButton Rep_CarFuel, SimpleButton Rep_CarAccident, SimpleButton Rep_Counters, SimpleButton Rep_Employees, SimpleButton Rep_Attendance,
            GunaButton btnRPEmployee, GunaButton btnRPCar)
        {
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][4].ToString() == null || Dt.Rows[0][4].ToString() == "" || Dt.Rows[0][4].ToString() == "False")
                    Rep_Carsmovements.Enabled = false;
                else Rep_Carsmovements.Enabled = true;
                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                {
                    Rep_Cars.Enabled = false;
                    btnRPCar.Enabled = false;
                }
                else
                {
                    Rep_Cars.Enabled = true;
                    btnRPCar.Enabled = true;
                }
                if (Dt.Rows[0][6].ToString() == null || Dt.Rows[0][6].ToString() == "" || Dt.Rows[0][6].ToString() == "False")
                    Rep_CarSituations.Enabled = false;
                else Rep_CarSituations.Enabled = true;
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                    Rep_CarFuel.Enabled = false;
                else Rep_CarFuel.Enabled = true;
                if (Dt.Rows[0][8].ToString() == null || Dt.Rows[0][8].ToString() == "" || Dt.Rows[0][8].ToString() == "False")
                    Rep_CarAccident.Enabled = false;
                else Rep_CarAccident.Enabled = true;
                if (Dt.Rows[0][9].ToString() == null || Dt.Rows[0][9].ToString() == "" || Dt.Rows[0][9].ToString() == "False")
                    Rep_Counters.Enabled = false;
                else Rep_Counters.Enabled = true;
                if (Dt.Rows[0][10].ToString() == null || Dt.Rows[0][10].ToString() == "" || Dt.Rows[0][10].ToString() == "False")
                {
                    Rep_Employees.Enabled = false;
                    btnRPEmployee.Enabled = false;
                }
                else
                {
                    Rep_Employees.Enabled = true;
                    btnRPEmployee.Enabled = true;
                }
                if (Dt.Rows[0][11].ToString() == null || Dt.Rows[0][11].ToString() == "" || Dt.Rows[0][11].ToString() == "False")
                    Rep_Attendance.Enabled = false;
                else Rep_Attendance.Enabled = true;

            }

        }
        //=========================================================================================================================
        //===========================================================================================================================
        //=== This Function Below for Execute Permission Three....
        public DataTable PerThree(string UserName, string PassWord, string frmName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = UserName;
            param[1] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[1].Value = PassWord;
            param[2] = new SqlParameter("@frmName", SqlDbType.VarChar, 50); param[2].Value = frmName;
            dal.open();
            DataTable Dt = dal.SelectingData("PerThree", param);
            dal.close();

            return Dt;

        }
        //================================================================================================================
        public void PerThree2(DataTable Dt, SimpleButton btnAdd, SimpleButton btnEdit, SimpleButton btnDelete
            , SimpleButton btnPrint, DevExpress.XtraBars.BarButtonItem btnPr)
        {
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                    btnAdd.Enabled = false;
                else btnAdd.Enabled = true;
                if (Dt.Rows[0][6].ToString() == null || Dt.Rows[0][6].ToString() == "" || Dt.Rows[0][6].ToString() == "False")
                    btnEdit.Enabled = false;
                else btnEdit.Enabled = true;
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                    btnDelete.Enabled = false;
                else btnDelete.Enabled = true;
                if (Dt.Rows[0][8].ToString() == null || Dt.Rows[0][8].ToString() == "" || Dt.Rows[0][8].ToString() == "False")
                    btnPrint.Enabled = false;
                else btnPrint.Enabled = true;

            }

        }
        //=====================================================================================================================
        public void PerThree3(DataTable Dt, SimpleButton btnAdd, SimpleButton btnEdit, SimpleButton btnDelete)
        {
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                    btnAdd.Enabled = false;
                else btnAdd.Enabled = true;
                if (Dt.Rows[0][6].ToString() == null || Dt.Rows[0][6].ToString() == "" || Dt.Rows[0][6].ToString() == "False")
                    btnEdit.Enabled = false;
                else btnEdit.Enabled = true;
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                    btnDelete.Enabled = false;
                else btnDelete.Enabled = true;


            }


        }
        //=====================================================================================================================
        public void PerThreeAtten(DataTable Dt, SimpleButton btnAddShift, SimpleButton btnEditShift, SimpleButton btnDeleteShift,SimpleButton btnAddEmoloyee,SimpleButton btnEditEmployee,
            SimpleButton btnDeleteEmployee, SimpleButton btnDeleteAllEmployee,SimpleButton btnSyncEmp,SimpleButton btnSuncRest)
        {
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][5].ToString() == null || Dt.Rows[0][5].ToString() == "" || Dt.Rows[0][5].ToString() == "False")
                {
                    btnAddShift.Enabled = false;
                    btnAddEmoloyee.Enabled = false;
                    btnSyncEmp.Enabled = false;
                    btnSuncRest.Enabled = false;
                }

                else {
                    btnAddShift.Enabled = true;
                    btnAddEmoloyee.Enabled = true;
                    btnSyncEmp.Enabled = true;
                    btnSuncRest.Enabled = true; 
                }
                if (Dt.Rows[0][6].ToString() == null || Dt.Rows[0][6].ToString() == "" || Dt.Rows[0][6].ToString() == "False")
                {
                    btnEditShift.Enabled = false;
                    btnEditEmployee.Enabled = false;
                }
                else
                {
                    btnEditShift.Enabled = true;
                    btnAddEmoloyee.Enabled = true;
                }
                if (Dt.Rows[0][7].ToString() == null || Dt.Rows[0][7].ToString() == "" || Dt.Rows[0][7].ToString() == "False")
                {
                    btnDeleteShift.Enabled = false;
                    btnDeleteEmployee.Enabled = false;
                    btnDeleteAllEmployee.Enabled = false;

                }
                else
                {
                    btnDeleteShift.Enabled = true;
                    btnDeleteEmployee.Enabled = true;
                    btnDeleteAllEmployee.Enabled = true;
                }
            }
        }

        //=================================================
        public DataTable UserPer(string UserName, string PassWord)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@UserName", SqlDbType.VarChar, 50); param[0].Value = UserName;
            param[1] = new SqlParameter("@PassWord", SqlDbType.VarChar, 50); param[1].Value = PassWord;
            
            dal.open();
            DataTable Dt = dal.SelectingData("PerThree", param);
            dal.close();

            return Dt;

        }
        //======================================================================
        /// ==== This For Test Team Project
        /// ===== This is Test tow.....
        /// //=== FORM MUS.....
        /// === from the alaa pc.....
        /// 

        //======================================================================
        public string DeleteEndSpace(string word)
        {
            string NeWord=null;
            int i = word.Length-1;
            while (word[i].ToString() == " ")
            { i--;
                }

            for(int j = 0; j <= i; j++)
            {
                NeWord += word[j];
            }
           
            return NeWord;
        }
    }
}


