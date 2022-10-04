using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLS_Synchornization
    {
        //select data from division based on div name and ip
        public DataTable SelectData(string division, string storedProcedure, SqlParameter[] param)
        {
            string[] divName = { Properties.Settings.Default.ServerName.ToString(), Properties.Settings.Default.ServerName1.ToString(), Properties.Settings.Default.ServerName2.ToString(), Properties.Settings.Default.ServerName3.ToString() };

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            DataTable dt = null;
            if (division == divName[0])
            {
                dal.open();
                dt = dal.SelectingData(storedProcedure, param);
                dal.close();
            } else if (division == divName[1])
            {
                dal.open1();
                dt = dal.SelectingData1(storedProcedure, param);
                dal.close1();
            }
            else if (division == divName[2])
            {
                dal.open2();
                dt = dal.SelectingData2(storedProcedure, param);
                dal.close2();
            }
            else if (division == divName[3])
            {
                dal.open3();
                dt = dal.SelectingData3(storedProcedure, param);
                dal.close3();
            }
            return dt;
        }

        //excute stored procedure data from division based on div name and ip
        public void Excute(string division, string storedProcedure, SqlParameter[] param)
        {
            string[] divName = { Properties.Settings.Default.ServerName.ToString(), Properties.Settings.Default.ServerName1.ToString(), Properties.Settings.Default.ServerName2.ToString(), Properties.Settings.Default.ServerName3.ToString() };

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            if (division == divName[0])
            {
                dal.open();
                dal.ExecuteCommand(storedProcedure, param);
                dal.close();
            }
            else if (division == divName[1])
            {
                dal.open1();
                dal.ExecuteCommand1(storedProcedure, param);
                dal.close1();
            }
            else if (division == divName[2])
            {
                dal.open2();
                dal.ExecuteCommand2(storedProcedure, param);
                dal.close2();
            }
            else if (division == divName[3])
            {
                dal.open3();
                dal.ExecuteCommand3(storedProcedure, param);
                dal.close3();
            }
        }

        //get path of employee archieve
        public string GetEmployeeArchievePath(string division)
        {
            string[] divName = { Properties.Settings.Default.ServerName.ToString(), Properties.Settings.Default.ServerName1.ToString(), Properties.Settings.Default.ServerName2.ToString(), Properties.Settings.Default.ServerName3.ToString() };

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            if (division == divName[0])
            {
                return Properties.Settings.Default.PathOfEmployees.ToString();
            }
            else if (division == divName[1])
            {
                return Properties.Settings.Default.EmployeeArchieves1.ToString();
            }
            else if (division == divName[2])
            {
                return Properties.Settings.Default.EmployeeArchieves2.ToString();
            }
            else if (division == divName[3])
            {
                return Properties.Settings.Default.EmployeeArchieves3.ToString();
            }
            return null;
        }

        //get path of document employee archieve
        public string GetEmployeeDocPath(string division)
        {
            string[] divName = { Properties.Settings.Default.ServerName.ToString(), Properties.Settings.Default.ServerName1.ToString(), Properties.Settings.Default.ServerName2.ToString(), Properties.Settings.Default.ServerName3.ToString() };

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            if (division == divName[0])
            {
                return Properties.Settings.Default.pathofDocument.ToString();
            }
            else if (division == divName[1])
            {
                return Properties.Settings.Default.EmpDoc1.ToString();
            }
            else if (division == divName[2])
            {
                return Properties.Settings.Default.EmpDoc2.ToString();
            }
            else if (division == divName[3])
            {
                return Properties.Settings.Default.EmpDoc3.ToString();
            }
            return null;
        }

        //====================================================================================
        //synchornization employee doc
        public DataTable EmpDocSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@Div", SqlDbType.VarChar, 50);
            param[0].Value = div2;
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelectDiv", param);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("رقم الاضبارة");

            param[0] = new SqlParameter("@Div", SqlDbType.VarChar, 50);
            param[0].Value = div2;
            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelectDiv", param);

            for (int i = 0; i < dtDiv1.Rows.Count; i++)
            {
                int j;
                for (j = 0; j < dtDiv2.Rows.Count; j++)
                {

                    if (dtDiv1.Rows[i][0].ToString() == dtDiv2.Rows[j][0].ToString())
                        break;
                }

                if (j < dtDiv2.Rows.Count)
                {

                    for (int z = 1; z <= 47; z++)
                    {
                        if (dtDiv1.Rows[i][z].ToString() != dtDiv2.Rows[j][z].ToString() && z != 45)
                        {
                            if (z == 36 || z == 40)
                            {
                                if (DateTime.Parse(dtDiv1.Rows[i][z].ToString()) != DateTime.Parse(dtDiv2.Rows[j][z].ToString()))
                                {

                                    UpdateEmpDocInfo(div2, dtDiv1, i);
                                    dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                    break;
                                }
                            }
                            else
                            {
                                if (z == 31)
                                {
                                    if (Path.GetFileName(dtDiv1.Rows[i][z].ToString()) != Path.GetFileName(dtDiv2.Rows[j][z].ToString()))
                                    {

                                        UpdateEmpDocInfo(div2, dtDiv1, i);
                                        dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                        break;
                                    }
                                }
                                else
                                {

                                    UpdateEmpDocInfo(div2, dtDiv1, i);
                                    dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                    break;
                                }
                            }
                        }
                    }

                }
                else if (j >= dtDiv2.Rows.Count && dtDiv1.Rows.Count > 0)
                {

                    InsertNewEmpDoc(div2, dtDiv1, i);
                    dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }


        //synchornization employee doc for update info in administrator div about employees from them div
        public void EmpDocUpdate(string div1, string div2, DataGridView dgv)
        {
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelectAll", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelectAll", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("رقم الاضبارة");

            for (int i = 0; i < dtDiv1.Rows.Count; i++)
            {
                for (int j = 0; j < dtDiv2.Rows.Count; j++)
                {
                    if (dtDiv1.Rows[i][0].ToString() == dtDiv2.Rows[j][0].ToString())
                    {
                       
                        for (int z = 1; z <= 47; z++)
                        {

                            if (dtDiv1.Rows[i][z].ToString() != dtDiv2.Rows[j][z].ToString() && z != 45)
                            {

                                if (z == 36 || z == 40)
                                {

                                    if (DateTime.Parse(dtDiv1.Rows[i][z].ToString()) != DateTime.Parse(dtDiv2.Rows[j][z].ToString()))
                                    {

                                        UpdateEmpDocInfo(div2, dtDiv1, i);
                                        dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                        break;
                                    }
                                }
                                else
                                {
                                    if (z == 31)
                                    {
                                        if (Path.GetFileName(dtDiv1.Rows[i][z].ToString()) != Path.GetFileName(dtDiv2.Rows[j][z].ToString()))
                                        {

                                            UpdateEmpDocInfo(div2, dtDiv1, i);
                                            dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                            break;
                                        }
                                    }
                                    else
                                    {

                                        UpdateEmpDocInfo(div2, dtDiv1, i);
                                        dtDataGrid.Rows.Add(new object[] { dtDiv1.Rows[i][5].ToString(), dtDiv1.Rows[i][2].ToString() });
                                        break;
                                    }
                                }
                            }
                        }
                  
                }
            }
        } 
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
        }

        //insert employee doc in division from another division
        public void InsertNewEmpDoc(string div, DataTable dt, int i)
        {
            string newpath = "";
            if (dt.Rows[i][31].ToString() != null && dt.Rows[i][31].ToString() != "")
            {
                string path = GetEmployeeArchievePath(div);
                newpath = path + Path.GetFileName(dt.Rows[i][31].ToString());
                try
                {
                    if (!File.Exists(newpath))
                    {
                        File.Copy(dt.Rows[i][31].ToString(), newpath);
                    }
                }
                catch { }
            }

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[47];
            param[0] = new SqlParameter("@id", SqlDbType.Int);                              param[0].Value = dt.Rows[i][0];
            param[1] = new SqlParameter("@Emp_DocNO", SqlDbType.Int);                       param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@Emp_DocNOnew", SqlDbType.Int);                    param[2].Value = dt.Rows[i][46];
            param[3] = new SqlParameter("@Emp_type", SqlDbType.VarChar, 50);                param[3].Value = dt.Rows[i][1];
            param[4] = new SqlParameter("@Emp_IDentityNO", SqlDbType.VarChar, 50);          param[4].Value = dt.Rows[i][3];
            param[5] = new SqlParameter("@Emp_Bloodtype", SqlDbType.VarChar, 50);           param[5].Value = dt.Rows[i][4];
            param[6] = new SqlParameter("@Emp_EmployeeSituation", SqlDbType.VarChar, 50);   param[6].Value = dt.Rows[i][32];
            param[7] = new SqlParameter("@Emp_Thebeneficiary", SqlDbType.VarChar, 50);      param[7].Value = dt.Rows[i][33];
            param[8] = new SqlParameter("@Emp_Registername", SqlDbType.VarChar, 50);        param[8].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[9] = new SqlParameter("@Emp_EmployeeDawria", SqlDbType.VarChar, 50);      param[9].Value = dt.Rows[i][34];
            param[10] = new SqlParameter("@Emp_EmployeeName", SqlDbType.VarChar, 50);       param[10].Value = dt.Rows[i][5];
            param[11] = new SqlParameter("@Emp_Laqab", SqlDbType.VarChar, 50);              param[11].Value = dt.Rows[i][6];
            param[12] = new SqlParameter("@Emp_Job", SqlDbType.VarChar, 50);                param[12].Value = dt.Rows[i][8];
            param[13] = new SqlParameter("@Emp_WorkingType", SqlDbType.VarChar, 50);        param[13].Value = dt.Rows[i][7];
            param[14] = new SqlParameter("@Emp_Division", SqlDbType.VarChar, 50);           param[14].Value = dt.Rows[i][9];
            param[15] = new SqlParameter("@Emp_Unit", SqlDbType.VarChar, 50);               param[15].Value = dt.Rows[i][10];
            param[16] = new SqlParameter("@Emp_WorkingPlace", SqlDbType.VarChar, 50);       param[16].Value = dt.Rows[i][11];
            param[17] = new SqlParameter("@Emp_SN", SqlDbType.VarChar, 50);                 param[17].Value = dt.Rows[i][12];
            param[18] = new SqlParameter("@Emp_KidsCount", SqlDbType.VarChar, 50);          param[18].Value = dt.Rows[i][13];
            param[19] = new SqlParameter("@Emp_WifeWorking", SqlDbType.VarChar, 50);        param[19].Value = dt.Rows[i][14];
            param[20] = new SqlParameter("@Emp_Studing", SqlDbType.VarChar, 50);            param[20].Value = dt.Rows[i][15];
            param[21] = new SqlParameter("@Emp_LastStage", SqlDbType.VarChar, 50);          param[21].Value = dt.Rows[i][16];
            param[22] = new SqlParameter("@Emp_Taghsus", SqlDbType.VarChar, 50);            param[22].Value = dt.Rows[i][17];
            param[23] = new SqlParameter("@Emp_Maharat", SqlDbType.VarChar, 50);            param[23].Value = dt.Rows[i][18];
            param[24] = new SqlParameter("@Emp_OldWorking", SqlDbType.VarChar, 50);         param[24].Value = dt.Rows[i][19];
            param[25] = new SqlParameter("@Emp_OldWorkingPlace", SqlDbType.VarChar, 50);    param[25].Value = dt.Rows[i][20];
            param[26] = new SqlParameter("@Emp_LivePlaceNow", SqlDbType.VarChar, 50);       param[26].Value = dt.Rows[i][21];
            param[27] = new SqlParameter("@Emp_PlacePointNearest", SqlDbType.VarChar, 50);  param[27].Value = dt.Rows[i][22];
            param[28] = new SqlParameter("@Emp_OldLivePlace", SqlDbType.VarChar, 50);       param[28].Value = dt.Rows[i][23];
            param[29] = new SqlParameter("@Emp_IDentityNumber", SqlDbType.VarChar, 50);     param[29].Value = dt.Rows[i][24];
            param[30] = new SqlParameter("@Emp_DaeratAhwal", SqlDbType.VarChar, 50);        param[30].Value = dt.Rows[i][25];
            param[31] = new SqlParameter("@Emp_ShahadaNumber", SqlDbType.VarChar, 50);      param[31].Value = dt.Rows[i][26];
            param[32] = new SqlParameter("@Emp_DaeratNufuos", SqlDbType.VarChar, 50);       param[32].Value = dt.Rows[i][27];
            param[33] = new SqlParameter("@Emp_ButaqatSakan", SqlDbType.VarChar, 50);       param[33].Value = dt.Rows[i][28];
            param[34] = new SqlParameter("@Emp_MaktabMaalumat", SqlDbType.VarChar, 50);     param[34].Value = dt.Rows[i][29];
            param[35] = new SqlParameter("@Emp_BirthDay", SqlDbType.Date);                  param[35].Value = dt.Rows[i][36];
            param[36] = new SqlParameter("@Emp_BrithDayPlace", SqlDbType.VarChar, 50);      param[36].Value = dt.Rows[i][37];
            param[37] = new SqlParameter("@Emp_TaghweelNO", SqlDbType.VarChar, 50);         param[37].Value = dt.Rows[i][39];
            param[38] = new SqlParameter("@Emp_TaghweelDate", SqlDbType.Date);              param[38].Value = dt.Rows[i][40];
            param[39] = new SqlParameter("@Emp_EmpBarcode", SqlDbType.VarChar, 50);         param[39].Value = dt.Rows[i][41];
            param[40] = new SqlParameter("@Emp_Mobile1", SqlDbType.VarChar, 50);            param[40].Value = dt.Rows[i][42];
            param[41] = new SqlParameter("@Emp_Mobile2", SqlDbType.VarChar, 50);            param[41].Value = dt.Rows[i][43];
            param[42] = new SqlParameter("@Emp_EmpDepartment", SqlDbType.VarChar, 50);      param[42].Value = dt.Rows[i][44];
            param[43] = new SqlParameter("@Emp_image", SqlDbType.Text);                     param[43].Value = newpath;
            param[44] = new SqlParameter("@Emp_Notice", SqlDbType.VarChar, 50);             param[44].Value = dt.Rows[i][38];
            param[45] = new SqlParameter("@Emp_ButaqatTawmenia", SqlDbType.VarChar, 50);    param[45].Value = dt.Rows[i][30];
            param[46] = new SqlParameter("@Emp_EmployeeWorkType", SqlDbType.VarChar, 50);   param[46].Value = dt.Rows[i][35];
            

            Excute(div, "EmployeesInfoInsertDataSync", param);

            
        }

        //update employee doc in division from another division
        public void UpdateEmpDocInfo(string div, DataTable dt, int i)
        {
            string newpath = "";
            if (dt.Rows[i][31].ToString() != null && dt.Rows[i][31].ToString() != "")
            {
                string path = GetEmployeeArchievePath(div);
                newpath = path + Path.GetFileName(dt.Rows[i][31].ToString());
                try
                {
                    if (!File.Exists(newpath))
                    {
                        File.Copy(dt.Rows[i][31].ToString(), newpath);
                    }
                }
                catch { }
            }


            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[47];
            param[0] = new SqlParameter("@Emp_DocNO", SqlDbType.Int);                       param[0].Value = dt.Rows[i][2];
            param[1] = new SqlParameter("@Emp_DocNOnew", SqlDbType.Int);                    param[1].Value = dt.Rows[i][46];
            param[2] = new SqlParameter("@Emp_type", SqlDbType.VarChar, 50);                param[2].Value = dt.Rows[i][1].ToString();
            param[3] = new SqlParameter("@Emp_IDentityNO", SqlDbType.VarChar, 50);          param[3].Value = dt.Rows[i][3].ToString();
            param[4] = new SqlParameter("@Emp_Bloodtype", SqlDbType.VarChar, 50);           param[4].Value = dt.Rows[i][4].ToString();
            param[5] = new SqlParameter("@Emp_EmployeeSituation", SqlDbType.VarChar, 50);   param[5].Value = dt.Rows[i][32].ToString();
            param[6] = new SqlParameter("@Emp_Thebeneficiary", SqlDbType.VarChar, 50);      param[6].Value = dt.Rows[i][33].ToString();
            param[7] = new SqlParameter("@Emp_Registername", SqlDbType.VarChar, 50);        param[7].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[8] = new SqlParameter("@Emp_EmployeeDawria", SqlDbType.VarChar, 50);      param[8].Value = dt.Rows[i][34].ToString();
            param[9] = new SqlParameter("@Emp_EmployeeName", SqlDbType.VarChar, 50);        param[9].Value = dt.Rows[i][5].ToString();
            param[10] = new SqlParameter("@Emp_Laqab", SqlDbType.VarChar, 50);              param[10].Value = dt.Rows[i][6].ToString();
            param[11] = new SqlParameter("@Emp_Job", SqlDbType.VarChar, 50);                param[11].Value = dt.Rows[i][8].ToString();
            param[12] = new SqlParameter("@Emp_WorkingType", SqlDbType.VarChar, 50);        param[12].Value = dt.Rows[i][7].ToString();
            param[13] = new SqlParameter("@Emp_Division", SqlDbType.VarChar, 50);           param[13].Value = dt.Rows[i][9].ToString();
            param[14] = new SqlParameter("@Emp_Unit", SqlDbType.VarChar, 50);               param[14].Value = dt.Rows[i][10].ToString();
            param[15] = new SqlParameter("@Emp_WorkingPlace", SqlDbType.VarChar, 50);       param[15].Value = dt.Rows[i][11].ToString();
            param[16] = new SqlParameter("@Emp_SN", SqlDbType.VarChar, 50);                 param[16].Value = dt.Rows[i][12].ToString();
            param[17] = new SqlParameter("@Emp_KidsCount", SqlDbType.VarChar, 50);          param[17].Value = dt.Rows[i][13].ToString();
            param[18] = new SqlParameter("@Emp_WifeWorking", SqlDbType.VarChar, 50);        param[18].Value = dt.Rows[i][14].ToString();
            param[19] = new SqlParameter("@Emp_Studing", SqlDbType.VarChar, 50);            param[19].Value = dt.Rows[i][15].ToString();
            param[20] = new SqlParameter("@Emp_LastStage", SqlDbType.VarChar, 50);          param[20].Value = dt.Rows[i][16].ToString();
            param[21] = new SqlParameter("@Emp_Taghsus", SqlDbType.VarChar, 50);            param[21].Value = dt.Rows[i][17].ToString();
            param[22] = new SqlParameter("@Emp_Maharat", SqlDbType.VarChar, 50);            param[22].Value = dt.Rows[i][18].ToString();
            param[23] = new SqlParameter("@Emp_OldWorking", SqlDbType.VarChar, 50);         param[23].Value = dt.Rows[i][19].ToString();
            param[24] = new SqlParameter("@Emp_OldWorkingPlace", SqlDbType.VarChar, 50);    param[24].Value = dt.Rows[i][20].ToString();
            param[25] = new SqlParameter("@Emp_LivePlaceNow", SqlDbType.VarChar, 50);       param[25].Value = dt.Rows[i][21].ToString();
            param[26] = new SqlParameter("@Emp_PlacePointNearest", SqlDbType.VarChar, 50);  param[26].Value = dt.Rows[i][22].ToString();
            param[27] = new SqlParameter("@Emp_OldLivePlace", SqlDbType.VarChar, 50);       param[27].Value = dt.Rows[i][23].ToString();
            param[28] = new SqlParameter("@Emp_IDentityNumber", SqlDbType.VarChar, 50);     param[28].Value = dt.Rows[i][24].ToString();
            param[29] = new SqlParameter("@Emp_DaeratAhwal", SqlDbType.VarChar, 50);        param[29].Value = dt.Rows[i][25].ToString();
            param[30] = new SqlParameter("@Emp_ShahadaNumber", SqlDbType.VarChar, 50);      param[30].Value = dt.Rows[i][26].ToString();
            param[31] = new SqlParameter("@Emp_DaeratNufuos", SqlDbType.VarChar, 50);       param[31].Value = dt.Rows[i][27].ToString();
            param[32] = new SqlParameter("@Emp_ButaqatSakan", SqlDbType.VarChar, 50);       param[32].Value = dt.Rows[i][28].ToString();
            param[33] = new SqlParameter("@Emp_MaktabMaalumat", SqlDbType.VarChar, 50);     param[33].Value = dt.Rows[i][29].ToString();
            param[34] = new SqlParameter("@Emp_BirthDay", SqlDbType.Date);                  param[34].Value = dt.Rows[i][36];
            param[35] = new SqlParameter("@Emp_BrithDayPlace", SqlDbType.VarChar, 50);      param[35].Value = dt.Rows[i][37].ToString();
            param[36] = new SqlParameter("@Emp_TaghweelNO", SqlDbType.VarChar, 50);         param[36].Value = dt.Rows[i][39].ToString();
            param[37] = new SqlParameter("@Emp_TaghweelDate", SqlDbType.Date);              param[37].Value = dt.Rows[i][40];
            param[38] = new SqlParameter("@Emp_EmpBarcode", SqlDbType.VarChar, 50);         param[38].Value = dt.Rows[i][41].ToString();
            param[39] = new SqlParameter("@Emp_Mobile1", SqlDbType.VarChar, 50);            param[39].Value = dt.Rows[i][42].ToString();
            param[40] = new SqlParameter("@Emp_Mobile2", SqlDbType.VarChar, 50);            param[40].Value = dt.Rows[i][43].ToString();
            param[41] = new SqlParameter("@Emp_EmpDepartment", SqlDbType.VarChar, 50);      param[41].Value = dt.Rows[i][44].ToString();
            param[42] = new SqlParameter("@Emp_image", SqlDbType.Text);                     param[42].Value = newpath;
            param[43] = new SqlParameter("@Emp_Notice", SqlDbType.VarChar, 50);             param[43].Value = dt.Rows[i][38].ToString();
            param[44] = new SqlParameter("@Emp_ButaqatTawmenia", SqlDbType.VarChar, 50);    param[44].Value = dt.Rows[i][30].ToString();
            param[45] = new SqlParameter("@Emp_EmployeeWorkType", SqlDbType.VarChar, 50);   param[45].Value = dt.Rows[i][35].ToString();
            param[46] = new SqlParameter("@Emp_ID", SqlDbType.Int);                         param[46].Value = dt.Rows[i][0];

            Excute(div, "EmployeesInfoUpdateData", param);
           
        }


        //===========================================================================================
        //synchornization employee variable
        public DataTable EmpVariableSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param, Archparm;
            param = new SqlParameter[1];
            Archparm = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("الحالة");
            dtDataGrid.Columns.Add("عدد");
            dtDataGrid.Columns.Add("نوع الحالة");
            dtDataGrid.Columns.Add("تاريخ الحالة");

            DataTable dtVarDiv1, dtVarDiv2, dtVarArchDiv1, dtVarArchDiv2;

            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv1 = SelectData(div1, "EmployeeVariableSelecting", param);
                        param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv2 = SelectData(div2, "EmployeeVariableSelecting", param);

                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            Archparm[0] = new SqlParameter("@ID", SqlDbType.Int);
                            Archparm[0].Value = dtVarDiv1.Rows[j][0];
                            dtVarArchDiv1 = SelectData(div1, "EmployeeVarSelectArchive", Archparm);
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][6].ToString() == dtVarDiv2.Rows[z][6].ToString())
                                {
                                    if (dtVarDiv1.Rows[j][3].ToString() != dtVarDiv2.Rows[z][3].ToString() || dtVarDiv1.Rows[j][4].ToString() != dtVarDiv2.Rows[z][4].ToString() ||
                                       dtVarDiv1.Rows[j][5].ToString() != dtVarDiv2.Rows[z][5].ToString() || dtVarDiv1.Rows[j][7].ToString() != dtVarDiv2.Rows[z][7].ToString() ||
                                       dtVarDiv1.Rows[j][8].ToString() != dtVarDiv2.Rows[z][8].ToString() || dtVarDiv1.Rows[j][12].ToString() != dtVarDiv2.Rows[z][12].ToString() ||
                                       dtVarDiv1.Rows[j][13].ToString() != dtVarDiv2.Rows[z][13].ToString())
                                    {
                                        UpdateEmpVariable(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(), dtVarDiv1.Rows[j][4].ToString()
                                , dtVarDiv1.Rows[j][5].ToString(), dtVarDiv1.Rows[j][6].ToString()});
                                        Archparm[0] = new SqlParameter("@ID", SqlDbType.Int);
                                        Archparm[0].Value = dtVarDiv2.Rows[j][0];
                                        dtVarArchDiv2 = SelectData(div2, "EmployeeVarSelectArchive", Archparm);
                                        for (int x = 0; x < dtVarArchDiv1.Rows.Count; x++)
                                        {
                                            int a;
                                            for (a = 0; a < dtVarArchDiv2.Rows.Count; a++)
                                            {
                                                if (Path.GetFileName(dtVarArchDiv1.Rows[x][4].ToString()) == Path.GetFileName(dtVarArchDiv1.Rows[x][4].ToString()))
                                                {
                                                    break;
                                                }
                                            }

                                            if (a >= dtVarDiv2.Rows.Count)
                                            {
                                                string newpath = Properties.Settings.Default.PathOfArchieves + Path.GetFileName(dtVarArchDiv1.Rows[x][4].ToString());
                                                if (!File.Exists(newpath))
                                                {
                                                    File.Copy(dtVarArchDiv1.Rows[x][4].ToString(), newpath);
                                                }
                                                InsertEmpVarArchieve(div2, dtVarArchDiv1, a, Convert.ToInt32(dtVarDiv2.Rows[dtVarDiv2.Rows.Count - 1][0]) + 1, newpath);
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpVariable(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(), dtVarDiv1.Rows[j][4].ToString()
                                , dtVarDiv1.Rows[j][5].ToString(), dtVarDiv1.Rows[j][6].ToString()});
                                param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int);
                                param[0].Value = dtDiv2.Rows[i][0];
                                DataTable dtDiv2id = SelectData(div2, "EmployeeVariableSelecting", param);
                                for (int q = 0; q < dtVarArchDiv1.Rows.Count; q++)
                                {
                                    string path = GetEmployeeArchievePath(div2);
                                    Random x = new Random();
                                    string newpath = path + x.Next().ToString() + Path.GetExtension(dtVarArchDiv1.Rows[q][4].ToString());
                                    if (!File.Exists(newpath))
                                    {
                                        File.Copy(dtVarArchDiv1.Rows[q][4].ToString(), newpath);
                                    }
                                    InsertEmpVarArchieve(div2, dtVarArchDiv1, q, Convert.ToInt32(dtDiv2id.Rows[dtDiv2id.Rows.Count - 1][0]), newpath);

                                }
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee variable in division from another division
        public void InsertEmpVariable(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int);                    param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);             param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@variableType", SqlDbType.VarChar, 50);        param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@variableCount", SqlDbType.Real);              param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@TheType2", SqlDbType.VarChar, 50);            param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@VariableDate", SqlDbType.Date);        param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@CommingDate", SqlDbType.Date);         param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@Notic", SqlDbType.Text);                      param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@registerName", SqlDbType.VarChar, 50);        param[8].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[9] = new SqlParameter("@Addingtime", SqlDbType.VarChar, 50);          param[9].Value = DateTime.Now.ToString("HH:MM tt");
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[10].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[11] = new SqlParameter("@VarTypeAdd", SqlDbType.Bit);                 param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@VarTypeNotAdd", SqlDbType.Bit);              param[12].Value = dt.Rows[i][13];

            Excute(div, "EmployeeVariableInsertInot", param);
        }

        //update employee variable in division from another division
        public void UpdateEmpVariable(string div, DataTable dt, int i, int VarID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@IDvar", SqlDbType.Int);                  param[0].Value = VarID;
            param[1] = new SqlParameter("@IDconvar", SqlDbType.Int);                param[1].Value = dt.Rows[i][1];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][2];
            param[3] = new SqlParameter("@variableType", SqlDbType.VarChar, 50);    param[3].Value = dt.Rows[i][3];
            param[4] = new SqlParameter("@variableCount", SqlDbType.Real);          param[4].Value = dt.Rows[i][4];
            param[5] = new SqlParameter("@TheType2", SqlDbType.VarChar, 50);        param[5].Value = dt.Rows[i][5];
            param[6] = new SqlParameter("@VariableDate", SqlDbType.Date);           param[6].Value = dt.Rows[i][6];
            param[7] = new SqlParameter("@CommingDate", SqlDbType.Date);            param[7].Value = dt.Rows[i][7];
            param[8] = new SqlParameter("@Notic", SqlDbType.Text);                  param[8].Value = dt.Rows[i][8];
            param[9] = new SqlParameter("@registerName", SqlDbType.VarChar, 50);    param[9].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[10] = new SqlParameter("@Addingtime", SqlDbType.VarChar, 50);      param[10].Value = DateTime.Now.ToString("HH:MM tt");
            param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);     param[11].Value = DateTime.Now.ToString("yyyy/MM/dd");            
            param[12] = new SqlParameter("@VarTypeAdd", SqlDbType.Bit);             param[12].Value = dt.Rows[i][12];
            param[13] = new SqlParameter("@VarTypeNotAdd", SqlDbType.Bit);          param[13].Value = dt.Rows[i][13];

            Excute(div, "EmployeeVariableUpdate", param);
        }


        //======================================================================================
        //synchornization employee deserve
        public DataTable EmpDeserveSync(string div1, string div2, DataGridView dgv)
        {
            
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);
           
            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("السنة");
           

            
            for (int x = 0; x < dtDiv1.Rows.Count; x++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[x][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        SqlParameter[] param1= new SqlParameter[1];
                        param1[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param1[0].Value = dtDiv1.Rows[x][0];
                        DataTable dtVarDiv1 = SelectData(div1, "EmployeeDeservingSelecting", param1);

                        SqlParameter[] param2 = new SqlParameter[1];
                        param2[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param2[0].Value = dtDiv2.Rows[i][0];
                        DataTable dtVarDiv2 = SelectData(div2, "EmployeeDeservingSelecting", param2);
                        
                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][3].ToString() == dtVarDiv2.Rows[z][3].ToString())
                                {
                                    for (int index = 4; index < 38; index++)
                                    {
                                        if (index != 28 && index != 29 && index != 30)
                                        {
                                            if (!(String.IsNullOrEmpty(dtVarDiv1.Rows[j][index].ToString())) && dtVarDiv1.Rows[j][index].ToString() != dtVarDiv2.Rows[z][index].ToString())
                                            {
                                                UpdateEmpDeserve(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                                                break;
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpDeserve(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //======================================================================================
        //synchornization employee deserve Pressing
        public DataTable EmpDeservePressingSync(string div1, string div2, DataGridView dgv)
        {

            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("السنة");



            for (int x = 0; x < dtDiv1.Rows.Count; x++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[x][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        SqlParameter[] param1 = new SqlParameter[1];
                        param1[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param1[0].Value = dtDiv1.Rows[x][0];
                        DataTable dtVarDiv1 = SelectData(div1, "EmployeeDeservPressingSelecting", param1);

                        SqlParameter[] param2 = new SqlParameter[1];
                        param2[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param2[0].Value = dtDiv2.Rows[i][0];
                        DataTable dtVarDiv2 = SelectData(div2, "EmployeeDeservPressingSelecting", param2);
                       
                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][3].ToString() == dtVarDiv2.Rows[z][3].ToString())
                                {
                                    for (int index = 4; index < 34; index++)
                                    {
                                         if (!(String.IsNullOrEmpty(dtVarDiv1.Rows[j][index].ToString())) && dtVarDiv1.Rows[j][index].ToString() != dtVarDiv2.Rows[z][index].ToString())
                                         {
                                            UpdateEmpDeservePressing(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                            dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                                            break;
                                         }
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpDeservePressing(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //======================================================================================
        //synchornization employee deserve Satisfying
        public DataTable EmpDeserveSatisfyingSync(string div1, string div2, DataGridView dgv)
        {

            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("السنة");



            for (int x = 0; x < dtDiv1.Rows.Count; x++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[x][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        SqlParameter[] param1 = new SqlParameter[1];
                        param1[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param1[0].Value = dtDiv1.Rows[x][0];
                        DataTable dtVarDiv1 = SelectData(div1, "EmployeeDeserveSatisfyingSelecting", param1);

                        SqlParameter[] param2 = new SqlParameter[1];
                        param2[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param2[0].Value = dtDiv2.Rows[i][0];
                        DataTable dtVarDiv2 = SelectData(div2, "EmployeeDeserveSatisfyingSelecting", param2);

                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][3].ToString() == dtVarDiv2.Rows[z][3].ToString())
                                {
                                    for (int index = 4; index < 49; index++)
                                    {
                                        if (!(String.IsNullOrEmpty(dtVarDiv1.Rows[j][index].ToString())) && dtVarDiv1.Rows[j][index].ToString() != dtVarDiv2.Rows[z][index].ToString())
                                        {
                                            UpdateEmpDeserveSatisfying(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                            dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpDeserveSatisfying(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString() });
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee Deserve in division from another division
        public void InsertEmpDeserve(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);               param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);     param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);     param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50);          param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50);          param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50);          param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50);          param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50);          param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50);          param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50);          param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50);         param[10].Value = dt.Rows[i][11];
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50);         param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50);        param[12].Value = dt.Rows[i][13];
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50);        param[13].Value = dt.Rows[i][14];
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50);        param[14].Value = dt.Rows[i][15];
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50);        param[15].Value = dt.Rows[i][16];
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50);        param[16].Value = dt.Rows[i][17];
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50);        param[17].Value = dt.Rows[i][18];
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50);        param[18].Value = dt.Rows[i][19];
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50);        param[19].Value = dt.Rows[i][20];
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50);        param[20].Value = dt.Rows[i][21];
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50);        param[21].Value = dt.Rows[i][22];
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50);        param[22].Value = dt.Rows[i][23];
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50);        param[23].Value = dt.Rows[i][24];
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50);        param[24].Value = dt.Rows[i][25];
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50);        param[25].Value = dt.Rows[i][26];
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50);        param[26].Value = dt.Rows[i][27];
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50);        param[27].Value = dt.Rows[i][31];
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50);        param[28].Value = dt.Rows[i][32];
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50);        param[29].Value = dt.Rows[i][33];
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50);        param[30].Value = dt.Rows[i][34];
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50);        param[31].Value = dt.Rows[i][35];
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50);        param[32].Value = dt.Rows[i][36];
            param[33] = new SqlParameter("@DesmNotic", SqlDbType.VarChar,200);  param[33].Value = dt.Rows[i][37];
            param[34] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[34].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeserveInsertinto", param);

        }

        //update employee Deserve in division from another division
        public void UpdateEmpDeserve(string div, DataTable dt, int i, int VarID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[36];

            param[0] = new SqlParameter("@IDdeserve", SqlDbType.Int);               param[0].Value = VarID;
            param[1] = new SqlParameter("@IDcondeserv", SqlDbType.Int);             param[1].Value = dt.Rows[i][1];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][2];
            param[3] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);         param[3].Value = dt.Rows[i][3];
            param[4] = new SqlParameter("@m1", SqlDbType.VarChar, 50);              param[4].Value = dt.Rows[i][4];
            param[5] = new SqlParameter("@m2", SqlDbType.VarChar, 50);              param[5].Value = dt.Rows[i][5];
            param[6] = new SqlParameter("@m3", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][6];
            param[7] = new SqlParameter("@m4", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][7];
            param[8] = new SqlParameter("@m5", SqlDbType.VarChar, 50);              param[8].Value = dt.Rows[i][8];
            param[9] = new SqlParameter("@m6", SqlDbType.VarChar, 50);              param[9].Value = dt.Rows[i][9];
            param[10] = new SqlParameter("@m7", SqlDbType.VarChar, 50);             param[10].Value = dt.Rows[i][10];
            param[11] = new SqlParameter("@m8", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][11];
            param[12] = new SqlParameter("@m9", SqlDbType.VarChar, 50);             param[12].Value = dt.Rows[i][12];
            param[13] = new SqlParameter("@m10", SqlDbType.VarChar, 50);            param[13].Value = dt.Rows[i][13];
            param[14] = new SqlParameter("@m11", SqlDbType.VarChar, 50);            param[14].Value = dt.Rows[i][14];
            param[15] = new SqlParameter("@m12", SqlDbType.VarChar, 50);            param[15].Value = dt.Rows[i][15];
            param[16] = new SqlParameter("@m13", SqlDbType.VarChar, 50);            param[16].Value = dt.Rows[i][16];
            param[17] = new SqlParameter("@m14", SqlDbType.VarChar, 50);            param[17].Value = dt.Rows[i][17];
            param[18] = new SqlParameter("@m15", SqlDbType.VarChar, 50);            param[18].Value = dt.Rows[i][18];
            param[19] = new SqlParameter("@m16", SqlDbType.VarChar, 50);            param[19].Value = dt.Rows[i][19];
            param[20] = new SqlParameter("@m17", SqlDbType.VarChar, 50);            param[20].Value = dt.Rows[i][20];
            param[21] = new SqlParameter("@m18", SqlDbType.VarChar, 50);            param[21].Value = dt.Rows[i][21];
            param[22] = new SqlParameter("@m19", SqlDbType.VarChar, 50);            param[22].Value = dt.Rows[i][22];
            param[23] = new SqlParameter("@m20", SqlDbType.VarChar, 50);            param[23].Value = dt.Rows[i][23];
            param[24] = new SqlParameter("@m21", SqlDbType.VarChar, 50);            param[24].Value = dt.Rows[i][24];
            param[25] = new SqlParameter("@m22", SqlDbType.VarChar, 50);            param[25].Value = dt.Rows[i][25];
            param[26] = new SqlParameter("@m23", SqlDbType.VarChar, 50);            param[26].Value = dt.Rows[i][26];
            param[27] = new SqlParameter("@m24", SqlDbType.VarChar, 50);            param[27].Value = dt.Rows[i][27];
            param[28] = new SqlParameter("@m25", SqlDbType.VarChar, 50);            param[28].Value = dt.Rows[i][31];
            param[29] = new SqlParameter("@m26", SqlDbType.VarChar, 50);            param[29].Value = dt.Rows[i][32];
            param[30] = new SqlParameter("@m27", SqlDbType.VarChar, 50);            param[30].Value = dt.Rows[i][33];
            param[31] = new SqlParameter("@m28", SqlDbType.VarChar, 50);            param[31].Value = dt.Rows[i][34];
            param[32] = new SqlParameter("@m29", SqlDbType.VarChar, 50);            param[32].Value = dt.Rows[i][35];
            param[33] = new SqlParameter("@m30", SqlDbType.VarChar, 50);            param[33].Value = dt.Rows[i][36];
            param[34] = new SqlParameter("@DesmNotic", SqlDbType.VarChar, 200);     param[34].Value = dt.Rows[i][37];
            param[35] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param[35].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeserveUpdate", param);
        }

        //insert employee Deserve Pressing in division from another division
        public void InsertEmpDeservePressing(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[34];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                   param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50);              param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50);              param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50);              param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50);              param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50);              param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50);             param[10].Value = dt.Rows[i][11];
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50);            param[12].Value = dt.Rows[i][13];
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50);            param[13].Value = dt.Rows[i][14];
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50);            param[14].Value = dt.Rows[i][15];
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50);            param[15].Value = dt.Rows[i][16];
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50);            param[16].Value = dt.Rows[i][17];
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50);            param[17].Value = dt.Rows[i][18];
            param[18] = new SqlParameter("@mNote1", SqlDbType.VarChar, 50);         param[18].Value = dt.Rows[i][19];
            param[19] = new SqlParameter("@mNote2", SqlDbType.VarChar, 50);         param[19].Value = dt.Rows[i][20];
            param[20] = new SqlParameter("@mNote3", SqlDbType.VarChar, 50);         param[20].Value = dt.Rows[i][21];
            param[21] = new SqlParameter("@mNote4", SqlDbType.VarChar, 50);         param[21].Value = dt.Rows[i][22];
            param[22] = new SqlParameter("@mNote5", SqlDbType.VarChar, 50);         param[22].Value = dt.Rows[i][23];
            param[23] = new SqlParameter("@mNote6", SqlDbType.VarChar, 50);         param[23].Value = dt.Rows[i][24];
            param[24] = new SqlParameter("@mNote7", SqlDbType.VarChar, 50);         param[24].Value = dt.Rows[i][25];
            param[25] = new SqlParameter("@mNote8", SqlDbType.VarChar, 50);         param[25].Value = dt.Rows[i][26];
            param[26] = new SqlParameter("@mNote9", SqlDbType.VarChar, 50);         param[26].Value = dt.Rows[i][27];
            param[27] = new SqlParameter("@mNote10", SqlDbType.VarChar, 50);        param[27].Value = dt.Rows[i][28];
            param[28] = new SqlParameter("@mNote11", SqlDbType.VarChar, 50);        param[28].Value = dt.Rows[i][29];
            param[29] = new SqlParameter("@mNote12", SqlDbType.VarChar, 50);        param[29].Value = dt.Rows[i][30];
            param[30] = new SqlParameter("@mNote13", SqlDbType.VarChar, 50);        param[30].Value = dt.Rows[i][31];
            param[31] = new SqlParameter("@mNote14", SqlDbType.VarChar, 50);        param[31].Value = dt.Rows[i][32];
            param[32] = new SqlParameter("@mNote15", SqlDbType.VarChar, 50);        param[32].Value = dt.Rows[i][33];         
            param[33] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param[33].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeservePressinginsertinto", param);

        }

        //update employee Deserve Pressing in division from another division
        public void UpdateEmpDeservePressing(string div, DataTable dt, int i, int VarID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[35];

            param[0] = new SqlParameter("@IDdeserve", SqlDbType.Int);               param[0].Value = VarID;
            param[1] = new SqlParameter("@IDcondeserv", SqlDbType.Int);             param[1].Value = dt.Rows[i][1];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][2];
            param[3] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);         param[3].Value = dt.Rows[i][3];
            param[4] = new SqlParameter("@m1", SqlDbType.VarChar, 50);              param[4].Value = dt.Rows[i][4];
            param[5] = new SqlParameter("@m2", SqlDbType.VarChar, 50);              param[5].Value = dt.Rows[i][5];
            param[6] = new SqlParameter("@m3", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][6];
            param[7] = new SqlParameter("@m4", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][7];
            param[8] = new SqlParameter("@m5", SqlDbType.VarChar, 50);              param[8].Value = dt.Rows[i][8];
            param[9] = new SqlParameter("@m6", SqlDbType.VarChar, 50);              param[9].Value = dt.Rows[i][9];
            param[10] = new SqlParameter("@m7", SqlDbType.VarChar, 50);             param[10].Value = dt.Rows[i][10];
            param[11] = new SqlParameter("@m8", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][11];
            param[12] = new SqlParameter("@m9", SqlDbType.VarChar, 50);             param[12].Value = dt.Rows[i][12];
            param[13] = new SqlParameter("@m10", SqlDbType.VarChar, 50);            param[13].Value = dt.Rows[i][13];
            param[14] = new SqlParameter("@m11", SqlDbType.VarChar, 50);            param[14].Value = dt.Rows[i][14];
            param[15] = new SqlParameter("@m12", SqlDbType.VarChar, 50);            param[15].Value = dt.Rows[i][15];
            param[16] = new SqlParameter("@m13", SqlDbType.VarChar, 50);            param[16].Value = dt.Rows[i][16];
            param[17] = new SqlParameter("@m14", SqlDbType.VarChar, 50);            param[17].Value = dt.Rows[i][17];
            param[18] = new SqlParameter("@m15", SqlDbType.VarChar, 50);            param[18].Value = dt.Rows[i][18];
            param[19] = new SqlParameter("@mNote1", SqlDbType.VarChar, 50);         param[19].Value = dt.Rows[i][19];
            param[20] = new SqlParameter("@mNote2", SqlDbType.VarChar, 50);         param[20].Value = dt.Rows[i][20];
            param[21] = new SqlParameter("@mNote3", SqlDbType.VarChar, 50);         param[21].Value = dt.Rows[i][21];
            param[22] = new SqlParameter("@mNote4", SqlDbType.VarChar, 50);         param[22].Value = dt.Rows[i][22];
            param[23] = new SqlParameter("@mNote5", SqlDbType.VarChar, 50);         param[23].Value = dt.Rows[i][23];
            param[24] = new SqlParameter("@mNote6", SqlDbType.VarChar, 50);         param[24].Value = dt.Rows[i][24];
            param[25] = new SqlParameter("@mNote7", SqlDbType.VarChar, 50);         param[25].Value = dt.Rows[i][25];
            param[26] = new SqlParameter("@mNote8", SqlDbType.VarChar, 50);         param[26].Value = dt.Rows[i][26];
            param[27] = new SqlParameter("@mNote9", SqlDbType.VarChar, 50);         param[27].Value = dt.Rows[i][27];
            param[28] = new SqlParameter("@mNote10", SqlDbType.VarChar, 50);        param[28].Value = dt.Rows[i][28];
            param[29] = new SqlParameter("@mNote11", SqlDbType.VarChar, 50);        param[29].Value = dt.Rows[i][29];
            param[30] = new SqlParameter("@mNote12", SqlDbType.VarChar, 50);        param[30].Value = dt.Rows[i][30];
            param[31] = new SqlParameter("@mNote13", SqlDbType.VarChar, 50);        param[31].Value = dt.Rows[i][31];
            param[32] = new SqlParameter("@mNote14", SqlDbType.VarChar, 50);        param[32].Value = dt.Rows[i][32];
            param[33] = new SqlParameter("@mNote15", SqlDbType.VarChar, 50);        param[33].Value = dt.Rows[i][33];            
            param[34] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param[34].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeservePressingUpdate", param);
        }

        //insert employee Deserve Satisfying in division from another division
        public void InsertEmpDeserveSatisfying(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[49];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                   param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50);              param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50);              param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50);              param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50);              param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50);              param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50);             param[10].Value = dt.Rows[i][11];
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50);            param[12].Value = dt.Rows[i][13];
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50);            param[13].Value = dt.Rows[i][14];
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50);            param[14].Value = dt.Rows[i][15];
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50);            param[15].Value = dt.Rows[i][16];
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50);            param[16].Value = dt.Rows[i][17];
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50);            param[17].Value = dt.Rows[i][18];
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50);            param[18].Value = dt.Rows[i][19];
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50);            param[19].Value = dt.Rows[i][20];
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50);            param[20].Value = dt.Rows[i][21];
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50);            param[21].Value = dt.Rows[i][22];
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50);            param[22].Value = dt.Rows[i][23];
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50);            param[23].Value = dt.Rows[i][24];
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50);            param[24].Value = dt.Rows[i][25];
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50);            param[25].Value = dt.Rows[i][26];
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50);            param[26].Value = dt.Rows[i][27];
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50);            param[27].Value = dt.Rows[i][28];
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50);            param[28].Value = dt.Rows[i][29];
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50);            param[29].Value = dt.Rows[i][30];
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50);            param[30].Value = dt.Rows[i][31];
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50);            param[31].Value = dt.Rows[i][32];
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50);            param[32].Value = dt.Rows[i][33];
            param[33] = new SqlParameter("@m31", SqlDbType.VarChar, 50);            param[33].Value = dt.Rows[i][34];
            param[34] = new SqlParameter("@m32", SqlDbType.VarChar, 50);            param[34].Value = dt.Rows[i][35];
            param[35] = new SqlParameter("@m33", SqlDbType.VarChar, 50);            param[35].Value = dt.Rows[i][36];
            param[36] = new SqlParameter("@m34", SqlDbType.VarChar, 50);            param[36].Value = dt.Rows[i][37];
            param[37] = new SqlParameter("@m35", SqlDbType.VarChar, 50);            param[37].Value = dt.Rows[i][38];
            param[38] = new SqlParameter("@m36", SqlDbType.VarChar, 50);            param[38].Value = dt.Rows[i][39];
            param[39] = new SqlParameter("@m37", SqlDbType.VarChar, 50);            param[39].Value = dt.Rows[i][40];
            param[40] = new SqlParameter("@m38", SqlDbType.VarChar, 50);            param[40].Value = dt.Rows[i][41];
            param[41] = new SqlParameter("@m39", SqlDbType.VarChar, 50);            param[41].Value = dt.Rows[i][42];
            param[42] = new SqlParameter("@m40", SqlDbType.VarChar, 50);            param[42].Value = dt.Rows[i][43];
            param[43] = new SqlParameter("@m41", SqlDbType.VarChar, 50);            param[43].Value = dt.Rows[i][44];
            param[44] = new SqlParameter("@m42", SqlDbType.VarChar, 50);            param[44].Value = dt.Rows[i][45];
            param[45] = new SqlParameter("@m43", SqlDbType.VarChar, 50);            param[45].Value = dt.Rows[i][46];
            param[46] = new SqlParameter("@m44", SqlDbType.VarChar, 50);            param[46].Value = dt.Rows[i][47];
            param[47] = new SqlParameter("@m45", SqlDbType.VarChar, 50);            param[47].Value = dt.Rows[i][48];
            param[48] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param[48].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeserveSatisfyinginsertinto", param);

        }

        //update employee Deserve Satisfying in division from another division
        public void UpdateEmpDeserveSatisfying(string div, DataTable dt, int i, int VarID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[50];

            param[0] = new SqlParameter("@IDdeserve", SqlDbType.Int);                   param[0].Value = VarID;
            param[1] = new SqlParameter("@IDcondeserv", SqlDbType.Int);                 param[1].Value = dt.Rows[i][1];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);             param[2].Value = dt.Rows[i][2];
            param[3] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50);             param[3].Value = dt.Rows[i][3];
            param[4] = new SqlParameter("@m1", SqlDbType.VarChar, 50);                  param[4].Value = dt.Rows[i][4];
            param[5] = new SqlParameter("@m2", SqlDbType.VarChar, 50);                  param[5].Value = dt.Rows[i][5];
            param[6] = new SqlParameter("@m3", SqlDbType.VarChar, 50);                  param[6].Value = dt.Rows[i][6];
            param[7] = new SqlParameter("@m4", SqlDbType.VarChar, 50);                  param[7].Value = dt.Rows[i][7];
            param[8] = new SqlParameter("@m5", SqlDbType.VarChar, 50);                  param[8].Value = dt.Rows[i][8];
            param[9] = new SqlParameter("@m6", SqlDbType.VarChar, 50);                  param[9].Value = dt.Rows[i][9];
            param[10] = new SqlParameter("@m7", SqlDbType.VarChar, 50);                 param[10].Value = dt.Rows[i][10];
            param[11] = new SqlParameter("@m8", SqlDbType.VarChar, 50);                 param[11].Value = dt.Rows[i][11];
            param[12] = new SqlParameter("@m9", SqlDbType.VarChar, 50);                 param[12].Value = dt.Rows[i][12];
            param[13] = new SqlParameter("@m10", SqlDbType.VarChar, 50);                param[13].Value = dt.Rows[i][13];
            param[14] = new SqlParameter("@m11", SqlDbType.VarChar, 50);                param[14].Value = dt.Rows[i][14];
            param[15] = new SqlParameter("@m12", SqlDbType.VarChar, 50);                param[15].Value = dt.Rows[i][15];
            param[16] = new SqlParameter("@m13", SqlDbType.VarChar, 50);                param[16].Value = dt.Rows[i][16];
            param[17] = new SqlParameter("@m14", SqlDbType.VarChar, 50);                param[17].Value = dt.Rows[i][17];
            param[18] = new SqlParameter("@m15", SqlDbType.VarChar, 50);                param[18].Value = dt.Rows[i][18];
            param[19] = new SqlParameter("@m16", SqlDbType.VarChar, 50);                param[19].Value = dt.Rows[i][19];
            param[20] = new SqlParameter("@m17", SqlDbType.VarChar, 50);                param[20].Value = dt.Rows[i][20];
            param[21] = new SqlParameter("@m18", SqlDbType.VarChar, 50);                param[21].Value = dt.Rows[i][21];
            param[22] = new SqlParameter("@m19", SqlDbType.VarChar, 50);                param[22].Value = dt.Rows[i][22];
            param[23] = new SqlParameter("@m20", SqlDbType.VarChar, 50);                param[23].Value = dt.Rows[i][23];
            param[24] = new SqlParameter("@m21", SqlDbType.VarChar, 50);                param[24].Value = dt.Rows[i][24];
            param[25] = new SqlParameter("@m22", SqlDbType.VarChar, 50);                param[25].Value = dt.Rows[i][25];
            param[26] = new SqlParameter("@m23", SqlDbType.VarChar, 50);                param[26].Value = dt.Rows[i][26];
            param[27] = new SqlParameter("@m24", SqlDbType.VarChar, 50);                param[27].Value = dt.Rows[i][27];
            param[28] = new SqlParameter("@m25", SqlDbType.VarChar, 50);                param[28].Value = dt.Rows[i][28];
            param[29] = new SqlParameter("@m26", SqlDbType.VarChar, 50);                param[29].Value = dt.Rows[i][29];
            param[30] = new SqlParameter("@m27", SqlDbType.VarChar, 50);                param[30].Value = dt.Rows[i][30];
            param[31] = new SqlParameter("@m28", SqlDbType.VarChar, 50);                param[31].Value = dt.Rows[i][31];
            param[32] = new SqlParameter("@m29", SqlDbType.VarChar, 50);                param[32].Value = dt.Rows[i][32];
            param[33] = new SqlParameter("@m30", SqlDbType.VarChar, 50);                param[33].Value = dt.Rows[i][33];
            param[34] = new SqlParameter("@m31", SqlDbType.VarChar, 50);                param[34].Value = dt.Rows[i][34];
            param[35] = new SqlParameter("@m32", SqlDbType.VarChar, 50);                param[35].Value = dt.Rows[i][35];
            param[36] = new SqlParameter("@m33", SqlDbType.VarChar, 50);                param[36].Value = dt.Rows[i][36];
            param[37] = new SqlParameter("@m34", SqlDbType.VarChar, 50);                param[37].Value = dt.Rows[i][37];
            param[38] = new SqlParameter("@m35", SqlDbType.VarChar, 50);                param[38].Value = dt.Rows[i][38];
            param[39] = new SqlParameter("@m36", SqlDbType.VarChar, 50);                param[39].Value = dt.Rows[i][39];
            param[40] = new SqlParameter("@m37", SqlDbType.VarChar, 50);                param[40].Value = dt.Rows[i][40];
            param[41] = new SqlParameter("@m38", SqlDbType.VarChar, 50);                param[41].Value = dt.Rows[i][41];
            param[42] = new SqlParameter("@m39", SqlDbType.VarChar, 50);                param[42].Value = dt.Rows[i][42];
            param[43] = new SqlParameter("@m40", SqlDbType.VarChar, 50);                param[43].Value = dt.Rows[i][43];
            param[44] = new SqlParameter("@m41", SqlDbType.VarChar, 50);                param[44].Value = dt.Rows[i][44];
            param[45] = new SqlParameter("@m42", SqlDbType.VarChar, 50);                param[45].Value = dt.Rows[i][45];
            param[46] = new SqlParameter("@m43", SqlDbType.VarChar, 50);                param[46].Value = dt.Rows[i][46];
            param[47] = new SqlParameter("@m44", SqlDbType.VarChar, 50);                param[47].Value = dt.Rows[i][47];
            param[48] = new SqlParameter("@m45", SqlDbType.VarChar, 50);                param[48].Value = dt.Rows[i][48];
            param[49] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);       param[49].Value = Properties.Settings.Default.UserNameLogin;

            Excute(div, "EmployeeDeserveSatisfyingUpdate", param);
        }

        //===========================================================================================
        //synchornization employee administration order
        public DataTable EmpAdminOrderSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("موضوع الكتاب");
            dtDataGrid.Columns.Add("رقم الكتاب");
            dtDataGrid.Columns.Add("جهة الاصدار");
           

            DataTable dtVarDiv1, dtVarDiv2;
            // param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {

                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv1 = SelectData(div1, "EmpAdministrationOrderGetdata", param);
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv2 = SelectData(div2, "EmpAdministrationOrderGetdata", param);
                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][4].ToString() == dtVarDiv2.Rows[z][4].ToString())
                                {
                                    if (dtVarDiv1.Rows[j][3].ToString() != dtVarDiv2.Rows[z][3].ToString() || dtVarDiv1.Rows[j][5].ToString() != dtVarDiv2.Rows[z][5].ToString() ||
                                        dtVarDiv1.Rows[j][6].ToString() != dtVarDiv2.Rows[z][6].ToString() || dtVarDiv1.Rows[j][7].ToString() != dtVarDiv2.Rows[z][7].ToString() ||
                                        dtVarDiv1.Rows[j][8].ToString() != dtVarDiv2.Rows[z][8].ToString() || dtVarDiv1.Rows[j][9].ToString() != dtVarDiv2.Rows[z][9].ToString())
                                    {
                                        UpdateEmpAdminOrder(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][6].ToString()});
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpAdminOrder(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][6].ToString()});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee administration order in division from another division
        public void InsertEmpAdminOrder(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@Emp_Name", SqlDbType.VarChar, 50); param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50); param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@BookNo", SqlDbType.VarChar, 50); param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@BookDate", SqlDbType.Date); param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ReleaseBy", SqlDbType.VarChar, 50); param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Notice", SqlDbType.Text); param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@ImportNO", SqlDbType.VarChar, 50); param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[9].Value = Properties.Settings.Default.UserNameLogin;
            param[10] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[10].Value = DateTime.Now.ToString("HH:MM tt");
            param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[11].Value = DateTime.Now.ToString("yyyy/MM/dd");

            Excute(div, "EmpAdministrationOrderinsertData", param);
        }

        //update employee administration order in division from another division
        public void UpdateEmpAdminOrder(string div, DataTable dt, int i, int OrderID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@Emp_Name", SqlDbType.VarChar, 50); param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50); param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@BookNo", SqlDbType.VarChar, 50); param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@BookDate", SqlDbType.Date); param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ReleaseBy", SqlDbType.VarChar, 50); param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Notice", SqlDbType.Text); param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@ImportNO", SqlDbType.VarChar, 50); param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[9].Value = Properties.Settings.Default.UserNameLogin;
            param[10] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[10].Value = DateTime.Now.ToString("HH:MM tt");
            param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[11].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[12] = new SqlParameter("@Emp_ID", SqlDbType.Int); param[12].Value = OrderID;

            Excute(div, "EmpAdministrationOrderUpdateData", param);
        }

        //===========================================================================================
        //synchornization employee constract
        public DataTable EmpConsSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("الحالة");
            dtDataGrid.Columns.Add("الفترة");
            dtDataGrid.Columns.Add("من تاريخ");
            dtDataGrid.Columns.Add("رقم الكتاب");

            DataTable dtVarDiv1, dtVarDiv2;
            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {

                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv1 = SelectData(div1, "EmployeeconstractGetData", param);
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtVarDiv2 = SelectData(div2, "EmployeeconstractGetData", param);
                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][5].ToString() == dtVarDiv2.Rows[z][5].ToString())
                                {
                                    if (dtVarDiv1.Rows[j][3].ToString() != dtVarDiv2.Rows[z][3].ToString() || dtVarDiv1.Rows[j][4].ToString() != dtVarDiv2.Rows[z][4].ToString() ||
                                        dtVarDiv1.Rows[j][6].ToString() != dtVarDiv2.Rows[z][6].ToString() || dtVarDiv1.Rows[j][7].ToString() != dtVarDiv2.Rows[z][7].ToString() ||
                                        dtVarDiv1.Rows[j][8].ToString() != dtVarDiv2.Rows[z][8].ToString() || dtVarDiv1.Rows[j][9].ToString() != dtVarDiv2.Rows[z][9].ToString() ||
                                        dtVarDiv1.Rows[j][10].ToString() != dtVarDiv2.Rows[z][10].ToString())
                                    {
                                        UpdateEmpCons(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][5], dtVarDiv1.Rows[j][7]});
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpCons(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][5], dtVarDiv1.Rows[j][7]});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee constract in division from another division
        public void InsertEmpCons(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                           param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@ConsEmpName", SqlDbType.VarChar, 50);             param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ConsThetype", SqlDbType.VarChar, 50);             param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@ConsPeriod", SqlDbType.Real);                     param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@ConsFormDate", SqlDbType.Date);                   param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ConsToDate", SqlDbType.Date);                     param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@ConsBookNO", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@ConsBookDate", SqlDbType.Date);                   param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@ConsReleaseby", SqlDbType.VarChar, 50);           param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@ConsNotice", SqlDbType.Text);                     param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@ConsRegisterName", SqlDbType.VarChar, 50);       param[10].Value = Properties.Settings.Default.UserNameLogin;
            param[11] = new SqlParameter("@ConsAddingDate", SqlDbType.VarChar, 50);         param[11].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[12] = new SqlParameter("@ConsAddingTime", SqlDbType.VarChar, 50);         param[12].Value = DateTime.Now.ToString("HH:MM tt");

            Excute(div, "EmployeeconstractsInsertData", param);
        }

        //update employee constract in division from another division
        public void UpdateEmpCons(string div, DataTable dt, int i, int ConsID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                       param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@ConsEmpName", SqlDbType.VarChar, 50);         param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ConsThetype", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@ConsPeriod", SqlDbType.Real);                 param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@ConsFormDate", SqlDbType.Date);               param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ConsToDate", SqlDbType.Date);                 param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@ConsBookNO", SqlDbType.VarChar, 50);          param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@ConsBookDate", SqlDbType.Date);               param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@ConsReleaseby", SqlDbType.VarChar, 50);       param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@ConsNotice", SqlDbType.Text);                 param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@ConsRegisterName", SqlDbType.VarChar, 50);   param[10].Value = Properties.Settings.Default.UserNameLogin;
            param[11] = new SqlParameter("@ConsAddingDate", SqlDbType.VarChar, 50);     param[11].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[12] = new SqlParameter("@ConsAddingTime", SqlDbType.VarChar, 50);     param[12].Value = DateTime.Now.ToString("HH:MM tt");
            param[13] = new SqlParameter("@ConsIDseq", SqlDbType.Int);                  param[13].Value = ConsID;

            Excute(div, "EmployeeconstractsUpdateData", param);
        }

        //===========================================================================================
        //synchornization employee children
        public DataTable EmpChildSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("اسم الطفل");
            dtDataGrid.Columns.Add("الجنس");
            dtDataGrid.Columns.Add("تاريخ الولادة");
            

            DataTable dtVarDiv1, dtVarDiv2;
           
            for (int i = 0; i < dtDiv1.Rows.Count; i++)
            {
                for (int x = 0; x < dtDiv2.Rows.Count; x++)
                {
                    if (dtDiv1.Rows[i][0].ToString() == dtDiv2.Rows[x][0].ToString())
                    {
                        param[0] = new SqlParameter("@IDconchild", SqlDbType.Int);
                        param[0].Value = dtDiv1.Rows[i][0];
                        dtVarDiv1 = SelectData(div1, "EmpChildrenGettingData", param);
                        param[0] = new SqlParameter("@IDconchild", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[x][0];
                        dtVarDiv2 = SelectData(div2, "EmpChildrenGettingData", param);
                        for (int j = 0; j < dtVarDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtVarDiv2.Rows.Count; z++)
                            {
                                if (dtVarDiv1.Rows[j][2].ToString() == dtVarDiv2.Rows[z][2].ToString() && dtVarDiv1.Rows[j][3].ToString() == dtVarDiv2.Rows[z][3].ToString())
                                {
                                    if (dtVarDiv1.Rows[j][4].ToString() != dtVarDiv2.Rows[z][4].ToString() || dtVarDiv1.Rows[j][5].ToString() != dtVarDiv2.Rows[z][5].ToString() ||
                                        dtVarDiv1.Rows[j][6].ToString() != dtVarDiv2.Rows[z][6].ToString() || dtVarDiv1.Rows[j][7].ToString() != dtVarDiv2.Rows[z][7].ToString() ||
                                        dtVarDiv1.Rows[j][8].ToString() != dtVarDiv2.Rows[z][8].ToString())
                                    {
                                        UpdateEmpChild(div2, dtVarDiv1, j, Convert.ToInt32(dtVarDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][5]});
                                    }
                                    break;
                                }
                            }
                            if (z >= dtVarDiv2.Rows.Count)
                            {
                                InsertEmpChild(div2, dtVarDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtVarDiv1.Rows[j][2].ToString(), dtVarDiv1.Rows[j][3].ToString(),
                                dtVarDiv1.Rows[j][4].ToString(), dtVarDiv1.Rows[j][5]});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee children in division from another division
        public void InsertEmpChild(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@IDconchild", SqlDbType.Int);                  param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ChildName", SqlDbType.VarChar, 50);           param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@Sexchild", SqlDbType.VarChar, 50);            param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@BirthDate", SqlDbType.Date);                  param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@SocialType", SqlDbType.VarChar, 50);          param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Thejob", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@Notice", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[8].Value = Properties.Settings.Default.UserNameLogin;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[9].Value = DateTime.Now.ToString("HH:MM tt");
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[10].Value = DateTime.Now.ToString("yyyy/MM/dd");

            Excute(div, "EmpChildrenInsertData", param);
        }

        //update employee children in division from another division
        public void UpdateEmpChild(string div, DataTable dt, int i, int childID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDconchild", SqlDbType.Int);                  param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ChildName", SqlDbType.VarChar, 50);           param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@Sexchild", SqlDbType.VarChar, 50);            param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@BirthDate", SqlDbType.Date);                  param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@SocialType", SqlDbType.VarChar, 50);          param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Thejob", SqlDbType.VarChar, 50);              param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@Notice", SqlDbType.VarChar, 50);              param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[8].Value = Properties.Settings.Default.UserNameLogin;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[9].Value = DateTime.Now.ToString("HH:MM tt");
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[10].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[11] = new SqlParameter("@IDChildseq", SqlDbType.Int);                 param[11].Value = childID;
            
            Excute(div, "EmpChildrenUpdateData", param);
        }
        //======================================================================================

        //synchornization employee Tanseeb
        public DataTable EmpTanseebSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("الحالة");
            dtDataGrid.Columns.Add("المدة");
            dtDataGrid.Columns.Add("من تاريخ");
            dtDataGrid.Columns.Add("الجهة المستفيدة");

            DataTable dtTanseebDiv1, dtTanseebDiv2;
            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {

                        param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtTanseebDiv1 = SelectData(div1, "EmpTabnseebGettingData", param);
                        param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtTanseebDiv2 = SelectData(div2, "EmpTabnseebGettingData", param);
                        for (int j = 0; j < dtTanseebDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtTanseebDiv2.Rows.Count; z++)
                            {
                                if (dtTanseebDiv1.Rows[j][2].ToString() == dtTanseebDiv2.Rows[z][2].ToString() && dtTanseebDiv1.Rows[j][5].ToString() == dtTanseebDiv2.Rows[z][5].ToString())
                                {

                                    if (dtTanseebDiv1.Rows[j][4].ToString() != dtTanseebDiv2.Rows[j][4].ToString() || dtTanseebDiv1.Rows[j][3].ToString() != dtTanseebDiv2.Rows[j][3].ToString() ||
                                        dtTanseebDiv1.Rows[j][6].ToString() != dtTanseebDiv2.Rows[j][6].ToString() || dtTanseebDiv1.Rows[j][7].ToString() != dtTanseebDiv2.Rows[j][7].ToString() ||
                                        dtTanseebDiv1.Rows[j][8].ToString() != dtTanseebDiv2.Rows[j][8].ToString() || dtTanseebDiv1.Rows[j][9].ToString() != dtTanseebDiv2.Rows[j][9].ToString())
                                    {
                                        UpdateEmpTanseeb(div2, dtTanseebDiv1, j, Convert.ToInt32(dtTanseebDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtTanseebDiv1.Rows[j][2].ToString(), dtTanseebDiv1.Rows[j][3].ToString(),
                                dtTanseebDiv1.Rows[j][4].ToString(), dtTanseebDiv1.Rows[j][5], dtTanseebDiv1.Rows[j][7]});
                                        break;
                                    }
                                }
                            }
                            if (z >= dtTanseebDiv2.Rows.Count)
                            {
                                InsertEmpTanseeb(div2, dtTanseebDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtTanseebDiv1.Rows[j][2].ToString(), dtTanseebDiv1.Rows[j][3].ToString(),
                                dtTanseebDiv1.Rows[j][4].ToString(), dtTanseebDiv1.Rows[j][5], dtTanseebDiv1.Rows[j][7]});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee Tanseeb in division from another division
        public void InsertEmpTanseeb(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int);                param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);             param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@Period", SqlDbType.Real);                     param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@FromDate", SqlDbType.Date);                   param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ToDate", SqlDbType.Date);                     param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);         param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@TypeSituation", SqlDbType.VarChar, 50);       param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@Notice", SqlDbType.Text);                     param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[9].Value = Properties.Settings.Default.UserNameLogin;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[10].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);         param[11].Value = DateTime.Now.ToString("HH:MM tt");

            Excute(div, "EmpTabnseebInsertData", param);
        }

        //update employee Tanseeb in division from another division
        public void UpdateEmpTanseeb(string div, DataTable dt, int i, int tanseebID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int);                param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);             param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@Period", SqlDbType.Real);                     param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@FromDate", SqlDbType.Date);                   param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@ToDate", SqlDbType.Date);                     param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);         param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@TypeSituation", SqlDbType.VarChar, 50);       param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@Notice", SqlDbType.Text);                     param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[9].Value = Properties.Settings.Default.UserNameLogin;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[10].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);         param[11].Value = DateTime.Now.ToString("HH:MM tt");
            param[12] = new SqlParameter("@IDseqtanseeb", SqlDbType.Int);               param[12].Value = tanseebID;

            Excute(div, "EmpTanseebUpdateData", param);
        }

        //=====================================================================================================

        //synchornization employee Zamaniat
        public DataTable EmpZamaniatSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("تاريخ الزمنية");
            dtDataGrid.Columns.Add("مدة الزمنية");
            dtDataGrid.Columns.Add("ملاحظات");


            DataTable dtZamaniatDiv1, dtZamaniatDiv2;
            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        param[0] = new SqlParameter("@ZamIDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtZamaniatDiv1 = SelectData(div1, "ZamSelecting", param);
                        param[0] = new SqlParameter("@ZamIDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtZamaniatDiv2 = SelectData(div2, "ZamSelecting", param);
                        for (int j = 0; j < dtZamaniatDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtZamaniatDiv2.Rows.Count; z++)
                            {
                                if (dtZamaniatDiv1.Rows[j][2].ToString() == dtZamaniatDiv2.Rows[z][2].ToString() && dtZamaniatDiv1.Rows[j][3].ToString() == dtZamaniatDiv2.Rows[z][3].ToString() && dtZamaniatDiv1.Rows[j][4].ToString() == dtZamaniatDiv2.Rows[z][4].ToString())
                                {
                                    if (dtZamaniatDiv1.Rows[j][5].ToString() != dtZamaniatDiv2.Rows[j][5].ToString() || dtZamaniatDiv1.Rows[j][6].ToString() != dtZamaniatDiv2.Rows[j][6].ToString())
                                    {
                                        UpdateEmpZamaniat(div2, dtZamaniatDiv1, j, Convert.ToInt32(dtZamaniatDiv2.Rows[z][0]));
                                        dtDataGrid.Rows.Add(new object[] { dtZamaniatDiv1.Rows[j][2].ToString(), dtZamaniatDiv1.Rows[j][3].ToString(),
                                dtZamaniatDiv1.Rows[j][4].ToString(), dtZamaniatDiv1.Rows[j][5]});
                                    }
                                    break;
                                }
                            }
                            if (z >= dtZamaniatDiv2.Rows.Count)
                            {
                                InsertEmpZamaniat(div2, dtZamaniatDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtZamaniatDiv1.Rows[j][2].ToString(), dtZamaniatDiv1.Rows[j][3].ToString(),
                        dtZamaniatDiv1.Rows[j][4].ToString(), dtZamaniatDiv1.Rows[j][5]});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee Zamaniat in division from another division
        public void InsertEmpZamaniat(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@ZamIDcon", SqlDbType.Int);                    param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ZamDate", SqlDbType.Date);                    param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@ZamCount", SqlDbType.Real);                   param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@Notice", SqlDbType.Text);                     param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50);           param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[6].Value = Properties.Settings.Default.UserNameLogin;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[7].Value = DateTime.Now.ToString("HH:MM tt");
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);          param[8].Value = DateTime.Now.ToString("yyyy/MM/dd");
           
            Excute(div, "ZamInsertInto", param);
        }

       
        //update employee Zamaniat in division from another division
        public void UpdateEmpZamaniat(string div, DataTable dt, int i, int zamaniatID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IDzamcon", SqlDbType.Int);                    param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@ZamDate", SqlDbType.Date);                    param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@ZamCount", SqlDbType.Real);                   param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@Notice", SqlDbType.Text);                     param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50);           param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[6].Value = Properties.Settings.Default.UserNameLogin;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[7].Value = DateTime.Now.ToString("HH:MM tt");
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);          param[8].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[9] = new SqlParameter("@IDzamseq", SqlDbType.Int);                    param[9].Value = zamaniatID;
            

            Excute(div, "ZamUPdate", param);
        }

        //=====================================================================================================

        //synchornization employee Dispatches
        public DataTable EmpDispatchesSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("رقم العجلة");
            dtDataGrid.Columns.Add("نوع العجلة");
            dtDataGrid.Columns.Add("تاريخ الخروج");
            dtDataGrid.Columns.Add("كتاب الصرف");

            DataTable dtDispatchesDiv1, dtDispatchesDiv2;
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
            for (int y = 0; y < dtDiv1.Rows.Count; y++)
            {
                for (int i = 0; i < dtDiv2.Rows.Count; i++)
                {
                    if (dtDiv1.Rows[y][0].ToString() == dtDiv2.Rows[i][0].ToString())
                    {
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtDispatchesDiv1 = SelectData(div1, "DisputchesSeleting", param);
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[i][0];
                        dtDispatchesDiv2 = SelectData(div2, "DisputchesSeleting", param);
                        for (int j = 0; j < dtDispatchesDiv1.Rows.Count; j++)
                        {
                            int z;
                            for (z = 0; z < dtDispatchesDiv2.Rows.Count; z++)
                            {
                                if (dtDispatchesDiv1.Rows[j][2].ToString() == dtDispatchesDiv2.Rows[z][2].ToString() && dtDispatchesDiv1.Rows[j][5].ToString() == dtDispatchesDiv2.Rows[z][5].ToString() && dtDispatchesDiv1.Rows[j][6].ToString() == dtDispatchesDiv2.Rows[z][6].ToString())
                                {
                                    
                                    for (int index = 3; index <= 25; index++)
                                    {
                                        
                                        if (index != 5 && index != 6 && index != 20 && index != 21 && index != 22 && index != 23)
                                        {

                                            if (dtDispatchesDiv1.Rows[j][index].ToString() != dtDispatchesDiv2.Rows[z][index].ToString())
                                            {
                                                UpdateEmpDispatches(div2, dtDispatchesDiv1, j, Convert.ToInt32(dtDispatchesDiv2.Rows[z][0]));
                                                dtDataGrid.Rows.Add(new object[] { dtDispatchesDiv1.Rows[j][2].ToString(), dtDispatchesDiv1.Rows[j][3].ToString(),
                                        dtDispatchesDiv1.Rows[j][4].ToString(), dtDispatchesDiv1.Rows[j][6], dtDispatchesDiv1.Rows[j][18]});
                                                break;
                                            }

                                        }
                                    }
                                    break;
                                }
                            }
                            if (z >= dtDispatchesDiv2.Rows.Count)
                            {
                                InsertEmpDispatches(div2, dtDispatchesDiv1, j);
                                dtDataGrid.Rows.Add(new object[] { dtDispatchesDiv1.Rows[j][2].ToString(), dtDispatchesDiv1.Rows[j][3].ToString(),
                        dtDispatchesDiv1.Rows[j][4].ToString(), dtDispatchesDiv1.Rows[j][6], dtDispatchesDiv1.Rows[j][18]});
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee Dispatches in division from another division
        public void InsertEmpDispatches(string div, DataTable dt, int i)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@IDconDisputches", SqlDbType.Int);                 param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);            param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);                   param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@GoingTime", SqlDbType.VarChar, 50);               param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@GoingDate", SqlDbType.Date);                      param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@CommingTime", SqlDbType.VarChar, 50);             param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@CommingDate", SqlDbType.Date);                    param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);             param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);          param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@HourCount", SqlDbType.VarChar, 50);              param[10].Value = dt.Rows[i][11];
            param[11] = new SqlParameter("@NightCount", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@Rayia", SqlDbType.VarChar, 50);                  param[12].Value = dt.Rows[i][13];
            param[13] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50);               param[13].Value = dt.Rows[i][14];
            param[14] = new SqlParameter("@TaghweelNO", SqlDbType.VarChar, 50);             param[14].Value = dt.Rows[i][15];
            param[15] = new SqlParameter("@TaghweelDate", SqlDbType.Date);                  param[15].Value = dt.Rows[i][16];
            param[16] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50);              param[16].Value = dt.Rows[i][17];
            param[17] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50);                 param[17].Value = dt.Rows[i][18];
            param[18] = new SqlParameter("@BookDate", SqlDbType.Date);                      param[18].Value = dt.Rows[i][19];
            param[19] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);           param[19].Value = Properties.Settings.Default.UserNameLogin;
            param[20] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);             param[20].Value = DateTime.Now.ToString("HH:MM tt");
            param[21] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);             param[21].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[22] = new SqlParameter("@IDmove", SqlDbType.Int);                         param[22].Value = dt.Rows[i][23];
            param[23] = new SqlParameter("@Comp", SqlDbType.Bit);                           param[23].Value = dt.Rows[i][24];
            param[24] = new SqlParameter("@notice", SqlDbType.VarChar, 500);                param[24].Value = dt.Rows[i][25];
            Excute(div, "DisputchesInsertinto", param); 
        }


        //update employee Dispatches in division from another division
        public void UpdateEmpDispatches(string div, DataTable dt, int i, int disID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[26];
            param[0] = new SqlParameter("@IDcondis", SqlDbType.Int);                        param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);            param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);                   param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[3].Value = dt.Rows[i][4];
            param[4] = new SqlParameter("@GoingTime", SqlDbType.VarChar, 50);               param[4].Value = dt.Rows[i][5];
            param[5] = new SqlParameter("@GoingDate", SqlDbType.Date);                      param[5].Value = dt.Rows[i][6];
            param[6] = new SqlParameter("@CommingTime", SqlDbType.VarChar, 50);             param[6].Value = dt.Rows[i][7];
            param[7] = new SqlParameter("@CommingDate", SqlDbType.Date);                    param[7].Value = dt.Rows[i][8];
            param[8] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);             param[8].Value = dt.Rows[i][9];
            param[9] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);          param[9].Value = dt.Rows[i][10];
            param[10] = new SqlParameter("@HourCount", SqlDbType.VarChar, 50);              param[10].Value = dt.Rows[i][11];
            param[11] = new SqlParameter("@NightCount", SqlDbType.VarChar, 50);             param[11].Value = dt.Rows[i][12];
            param[12] = new SqlParameter("@Rayia", SqlDbType.VarChar, 50);                  param[12].Value = dt.Rows[i][13];
            param[13] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50);               param[13].Value = dt.Rows[i][14];
            param[14] = new SqlParameter("@TaghweelNO", SqlDbType.VarChar, 50);             param[14].Value = dt.Rows[i][15];
            param[15] = new SqlParameter("@TaghweelDate", SqlDbType.Date);                  param[15].Value = dt.Rows[i][16];
            param[16] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50);              param[16].Value = dt.Rows[i][17];
            param[17] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50);                 param[17].Value = dt.Rows[i][18];
            param[18] = new SqlParameter("@BookDate", SqlDbType.Date);                      param[18].Value = dt.Rows[i][19];
            param[19] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);           param[19].Value = Properties.Settings.Default.UserNameLogin;
            param[20] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);             param[20].Value = DateTime.Now.ToString("HH:MM tt");
            param[21] = new SqlParameter("@AddingDate", SqlDbType.Date);                    param[21].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[22] = new SqlParameter("@IDmove", SqlDbType.Int);                         param[22].Value = dt.Rows[i][23];
            param[23] = new SqlParameter("@IDdis", SqlDbType.Int);                          param[23].Value = disID;
            param[24] = new SqlParameter("@Comp", SqlDbType.Bit);                           param[24].Value = dt.Rows[i][24];
            param[25] = new SqlParameter("@notice", SqlDbType.VarChar,500);                 param[25].Value = dt.Rows[i][25];
            Excute(div, "DisputchesUPdate", param);
        }

        //===========================================================================================
        //synchornization employee Archieve
        public DataTable EmpArchieveSync(string div1, string div2, DataGridView dgv)
        {
            SqlParameter[] param;
            param = new SqlParameter[1];
            DataTable dtDiv1 = SelectData(div1, "EmployeesInfoSelect", null);

            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelect", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("رقم الاضبارة");

            DataTable dtArchieveDiv1, dtArchieveDiv2;


            for (int i = 0; i < dtDiv1.Rows.Count; i++)
            {
                for (int z = 0; z < dtDiv2.Rows.Count; z++)
                {
                    if (dtDiv1.Rows[i][0].ToString() == dtDiv2.Rows[z][0].ToString())
                    {
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv1.Rows[i][0];

                        dtArchieveDiv1 = SelectData(div1, "EmpArchSelect", param);
                        param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
                        param[0].Value = dtDiv2.Rows[z][0];
                        dtArchieveDiv2 = SelectData(div2, "EmpArchSelect", param);
                        for (int x = 0; x < dtArchieveDiv1.Rows.Count; x++)
                        {
                            int j = 0;
                            if (dtArchieveDiv2.Rows.Count > 0)
                            {
                                while (j < dtArchieveDiv2.Rows.Count && (dtArchieveDiv1.Rows[x][2].ToString() != dtArchieveDiv2.Rows[j][2].ToString() || dtArchieveDiv1.Rows[x][3].ToString() != dtArchieveDiv2.Rows[j][3].ToString() || Path.GetFileName(dtArchieveDiv1.Rows[x][4].ToString()) != Path.GetFileName(dtArchieveDiv2.Rows[j][4].ToString())))
                                {
                                    j++;
                                }
                            }
                            if (j >= dtArchieveDiv2.Rows.Count)
                            {
                                string file_type = Path.GetExtension(Path.GetFileName(dtArchieveDiv1.Rows[j][4].ToString()));
                                string path = null;
                                if (file_type == ".jpg" || file_type == ".bmp" || file_type == ".png")
                                {
                                    path = GetEmployeeArchievePath(div2);
                                }
                                else
                                {
                                    path = GetEmployeeDocPath(div2);
                                }
                                string newpath = path + Path.GetFileName(dtArchieveDiv1.Rows[x][4].ToString());

                                if (!File.Exists(newpath))
                                {
                                    File.Copy(dtArchieveDiv1.Rows[x][4].ToString(), newpath);
                                }
                                InsertEmpArchieve(div2, dtArchieveDiv1, x, newpath);
                                dtDataGrid.Rows.Add(new object[] { dtArchieveDiv1.Rows[x][3].ToString(), dtArchieveDiv1.Rows[x][2].ToString() });
                            }
                        }
                    }
                }
            }
            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
            return dtDataGrid;
        }

        //insert employee Archieve in division from another division
        public void InsertEmpArchieve(string div, DataTable dt, int i, string path)
        {
            DAL.DataAccessLayer emparchadding = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@IDconemparch", SqlDbType.Int);                param[0].Value = dt.Rows[i][1];
            param[1] = new SqlParameter("@docNumber", SqlDbType.Int);                   param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);             param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@PathImage", SqlDbType.Text);                  param[3].Value = path;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);        param[4].Value = Properties.Settings.Default.UserNameLogin;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);          param[5].Value = DateTime.Now.ToString("HH:MM tt");
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);          param[6].Value = DateTime.Now.ToString("yyyy/MM/dd");
            
            Excute(div, "EmparchAdding", param);
        }

        //===========================================================================================
       

        //insert employee variable Archieve in division from another division
        public void InsertEmpVarArchieve(string div, DataTable dt, int i, int varid , string path)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@IDconVar", SqlDbType.Int);                param[0].Value = varid;
            param[1] = new SqlParameter("@IDEmp", SqlDbType.Int);                   param[1].Value = dt.Rows[i][2];
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);         param[2].Value = dt.Rows[i][3];
            param[3] = new SqlParameter("@ImgPath", SqlDbType.VarChar, 800);        param[3].Value = path;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);    param[4].Value = Properties.Settings.Default.UserNameLogin;
           
            Excute(div, "EmployeeVarInsertintoArchive", param);
        }


        //===========================================================================================

        public void EmpDeleteSync(string div2, DataGridView dgv)
        {
            DataTable dtDiv2 = SelectData(div2, "EmployeesInfoSelectAll", null);

            DataTable dtDataGrid = new DataTable();
            dtDataGrid.Clear();
            dtDataGrid.Columns.Add("اسم المنتسب");
            dtDataGrid.Columns.Add("رقم الاضبارة");

            for (int j = 0; j < dtDiv2.Rows.Count; j++)
            {
                if (dtDiv2.Rows[j][11].ToString() != div2)
                {

                    DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
                    SqlParameter[] param = new SqlParameter[1];
                    param[0] = new SqlParameter("@id", SqlDbType.Int); param[0].Value = dtDiv2.Rows[j][0];

                    Excute(div2, "DeleteEmployee", param);

                    dtDataGrid.Rows.Add(new object[] { dtDiv2.Rows[j][5].ToString(), dtDiv2.Rows[j][2].ToString() });
                }
            }

            dgv.DataSource = null; dgv.DataSource = dtDataGrid;
        }
    }
}
