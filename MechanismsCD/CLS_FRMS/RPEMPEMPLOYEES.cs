using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.IO;
using System.Drawing;
using DevExpress;
using System.Windows.Forms;
using System.ComponentModel;


namespace MechanismsCD.CLS_FRMS
{
    class RPEMPEMPLOYEES
    {
        //===============================================================================================||
        public void cbpreview( ComboBox cb5) // Fill The Cb5 by the Tb_preview
        {
            cb5.Items.Clear();
            CLSCONSTENTRY getcbdata = new CLSCONSTENTRY();
            DataTable Dt = getcbdata.GetDataTbpreview();
            for(int i=0;i<Dt.Rows.Count;i++)
            {
                cb5.Items.Add(Dt.Rows[i][0].ToString());
            }
           
        }
        //===============================================================================================||
        public DataTable Emp_ConstractsAttentions() // Run the Emp_ConstractsAttentions Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt= dal.SelectingData("RPEMP_ConstractAttention", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable Emp_ConstractsBetweenTowDate(DateTimePicker dt1,DateTimePicker dt2) // Run the Emp_ConstractsBetweenTowDate Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);param[0].Value = dt1.Text;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);param[1].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_ConstractBetweentowdate", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_DivisionCounts() // Run the RPEMP_DivisionCoutns Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_DivisionCounts", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeAdministrations(int cbo1) // Run the RPEMP_EmployeesAdministrations Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int);param[0].Value = cbo1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeAdiminstrations", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeAdministrations2(int cb1,string dt1,string dt2) // Run the RPEMP_EmployeesAdministrations2 Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int);                          param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                   param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                   param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeAdiminstrations2", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeChildren(string cb1) // Run the RPEMP_EmployeeChildren Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeChildren", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeDawria() // Run the RPEMP_EmployeeDawria Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeDawria", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeDawriabyDivision(string cb1) // Run the RPEMP_EmployeeDawriabyDivision Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Division", SqlDbType.VarChar, 50);param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeDawriabyDivision", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesByDivision(string cb1) // Run the RPEMP_EmployeesByDivision Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpDivision", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesByDivision", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesByDivisionAndSheft(string Division,string Sheft) // Run the RPEMP_EmployeesByDivision Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Division", SqlDbType.VarChar, 50); param[0].Value = Division;
            param[1] = new SqlParameter("@SheftName", SqlDbType.VarChar, 50); param[1].Value = Sheft;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RP_EmpByDivisionAndSheft", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesByJob(string cb1) // Run the RPEMP_EmployeesByJob Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpJob", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesByJob", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesBySituation(string cb1) // Run the RPEMP_EmployeesBySituation Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpSitu", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesBySituation", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesByType(string cb1) // Run the RPEMP_EmployeesByType Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpType", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesByType", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesByUnit(string cb1) // Run the RPEMP_EmployeesByUnit Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpUnit", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesByUnit", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesnameAttendence(string cb1,string dt1,string dt2) // Run the RPEMP_EmployeesnameAttendence Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);    param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 10);           param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 10);           param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesNameAttendence", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesnameAttendenceDaily(string dt1) // Run the RPEMP_EmployeesnameAttendenceDaily Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 10); param[0].Value = dt1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesnameAttendenceDaily", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesTanseeb(string cb1, string dt1, string dt2) // Run the RPEMP_EmployeesTanseeb Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);               param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);               param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesTanseeb", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesTanseebTowDate( string dt1, string dt2) // Run the RPEMP_EmployeesTanseebTowDate Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[0].Value = dt1;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[1].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesTanseebTowDate", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesWorkTime(string cb1, string dt1, string dt2) // Run the RPEMP_EmployeesWorkTime Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Division", SqlDbType.VarChar, 50);        param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 10);           param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 10);           param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesWorkTime", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesWorkTimeName(string cb1, string dt1, string dt2) // Run the RPEMP_EmployeesWorkTimeName Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 10);               param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 10);               param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesWorkTimeName", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeWorkType() // Run the RPEMP_EmployeeWorkType Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeWorkType", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeWorkTypeBydivision(string cb1) // Run the RPEMP_EmployeesWorkTypeBydivision Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Division", SqlDbType.VarChar, 50); param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeWorkTypeBydivision", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeWorkTypeByType(string cb1) // Run the RPEMP_EmployeesWorkTypeByType Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@employeeworktype", SqlDbType.VarChar, 1);     param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeWorkTypeByType", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeZamanyiat( string dt1, string dt2) // Run the RPEMP_EmployeesZamanyiat Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 10); param[0].Value = dt1;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 10); param[1].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeZamanyiat", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeZamanyiatAll(string dt1, string dt2) // Run the RPEMP_EmployeesZamanyiatAll Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 10); param[0].Value = dt1;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 10); param[1].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeZamanyiatAll", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeeZamanyiatbyName(string cb1, string dt1, string dt2) // Run the RPEMP_EmployeeZamanyiatbyName Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);    param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 10);           param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 10);           param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeeZamanyiatbyName", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployessandLivePlace() // Run the RPEMP_EmployessandLivePlace Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployessandLivePlace", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_Employeesandmobile() // Run the RPEMP_Employessandmobile Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_Employessandmobile", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployeesandStduy() // Run the RPEMP_EmployessandStduy Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployessandStduy", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployessandTaghweel() // Run the RPEMP_EmployessandTaghweel Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployessandTaghweel", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmployessandTypeandchildren() // Run the RPEMP_EmployessandTypeandchildren Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployessandTypeandchildren", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_EmpSituation() // Run the RPEMP_EmpSituation Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmpSituation", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_JobsName() // Run the RPEMP_JobsName Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_JobsName", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_BeneficiaryCount() // Run the RPEMP_BeneficiaryCount Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_TheBeneficiaryCount", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_TheTypeCounts() // Run the RPEMP_TheTypeCounts Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_TheTypeCounts", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_UnitsCounts() // Run the RPEMP_UnitsCounts Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_UnitsCounts", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_VariabelComming() // Run the RPEMP_VariabelComming Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelComming", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_VariabelEmployee(int cb1) // Run the RPEMP_VariabelEmployee Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int);param[0].Value = cb1;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelEmployee", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_VariabelEmployeeTowDate(int cb1,string dt1,string dt2) // Run the RPEMP_VariabelEmployeeTowDate Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int);                      param[0].Value = cb1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 10);               param[1].Value = dt1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 10);               param[2].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelEmployeeTowDate", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_VariabelGo() // Run the RPEMP_VariabelGo Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelGo", null);
            dal.close();
            return Dt;
        } 
        //==============================================================================================||
        public DataTable RPEMP_VariabelGoBetweenTwoDates(string dt1, string dt2) // Run the RPEMP_VariabelGoBetweenTwoDates Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[0].Value = dt1;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[1].Value = dt2;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelGoBetweenTwoDates", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_VariabelNotComming() // Run the RPEMP_VariabelNotComming Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_VariabelNotComming", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_WorkPlace() // Run the RPEMP_WorkPlace Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_WorkPlace", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_TheTypecounts() // Run the RPEMP_TheTypeCounts Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_TheTypecounts", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable RPEMP_WorkingPlace(string WorkngPlace) // Run the RPEMP_EmployeesByWorkingPlace Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpWorkingPlace", SqlDbType.VarChar, 50); param[0].Value = WorkngPlace;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPEMP_EmployeesByWorkingPlace", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable WorkingPlaceGetData() // Run the WorkingPlaceGetData Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("WorkingPlaceGetData", null);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesBetweenTwoDates(DateTime date1, DateTime date2) // Run the DisputchesBetweenTwoDates Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@date1", SqlDbType.Date); param[0].Value = date1;
            param[1] = new SqlParameter("@date2", SqlDbType.Date); param[1].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesBetweenTwoDates", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesByEmpName(string name,DateTime date1, DateTime date2) // Run the DisputchesByEmpName Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@EmpName", SqlDbType.VarChar,50); param[0].Value = name;
            param[1] = new SqlParameter("@date1", SqlDbType.Date); param[1].Value = date1;
            param[2] = new SqlParameter("@date2", SqlDbType.Date); param[2].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesByEmpName", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesByCarNO(string carno,DateTime date1, DateTime date2) // Run the DisputchesByCarNO Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CarNO", SqlDbType.VarChar,50); param[0].Value = carno;
            param[1] = new SqlParameter("@date1", SqlDbType.Date); param[1].Value = date1;
            param[2] = new SqlParameter("@date2", SqlDbType.Date); param[2].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesByCarNO", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesByDistenation(string Distenation, DateTime date1, DateTime date2) // Run the DisputchesByDistenation Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Distenation", SqlDbType.VarChar,50); param[0].Value = Distenation;
            param[1] = new SqlParameter("@date1", SqlDbType.Date); param[1].Value = date1;
            param[2] = new SqlParameter("@date2", SqlDbType.Date); param[2].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesByDistenation", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesByDisCase(string DisCase, DateTime date1, DateTime date2) // Run the DisputchesByDisCase Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@DisCase", SqlDbType.VarChar, 50); param[0].Value = DisCase;
            param[1] = new SqlParameter("@date1", SqlDbType.Date); param[1].Value = date1;
            param[2] = new SqlParameter("@date2", SqlDbType.Date); param[2].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesByDisCase", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable DisputchesCompleteOrNot(string state, DateTime date1, DateTime date2) // Run the DisputchesCompleteOrNot Procedure
        {
            bool st;
            if (state == "مكتمل")
                st = true;
            else
                st = false;
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@state", SqlDbType.VarChar, 50); param[0].Value = st;
            param[1] = new SqlParameter("@date1", SqlDbType.Date); param[1].Value = date1;
            param[2] = new SqlParameter("@date2", SqlDbType.Date); param[2].Value = date2;
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("DisputchesCompleteOrNot", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public DataTable EmployeesInfoSelectByID(int id) // Run the EmployeesInfoSelectByID Procedure
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int); param[0].Value = id;
           
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("EmployeesInfoSelectByID", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================||
        public void Dgvdesign( DataGridView Dgv,DataTable Dt,ComboBox cbo)
        {
            Dgv.DataSource = Dt;
            switch (cbo.Text)
            {
                case "تنبيه العقود":
                            Dgv.DataSource = Dt;
                            Dgv.Columns[0].HeaderText = "اسم المنتسب";
                            Dgv.Columns[1].HeaderText = "الحالة";
                            Dgv.Columns[2].HeaderText = "المدة";
                            Dgv.Columns[3].HeaderText = "من تاريخ";
                            Dgv.Columns[4].HeaderText = "الى تاريخ";
                            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                      
                    break;
                case "عقود بين تاريخين":
                            Dgv.DataSource = Dt;
                            Dgv.Columns[0].HeaderText = "اسم المنتسب";
                            Dgv.Columns[1].HeaderText = "الحالة";
                            Dgv.Columns[2].HeaderText = "المدة";
                            Dgv.Columns[3].HeaderText = "من تاريخ";
                            Dgv.Columns[4].HeaderText = "الى تاريخ";
                            Dgv.Columns[5].HeaderText = "رقم الكتاب";
                            Dgv.Columns[6].HeaderText = "تاريخ الكتاب";
                            Dgv.Columns[7].HeaderText = "جهة الاصدار";
                            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                   
                    break;
                case "اعداد الشعب":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم الشعبة";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "الاوامر الادارية للمنتسب":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "عنوان الكتاب";
                    Dgv.Columns[2].HeaderText = "رقم الكتاب";
                    Dgv.Columns[3].HeaderText = "تاريخ الكتاب";
                    Dgv.Columns[4].HeaderText = "جهة الاصدار";
                    Dgv.Columns[5].HeaderText = "تفاصيل الكتاب";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "الاوامر الادارية للمنتسب بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "عنوان الكتاب";
                    Dgv.Columns[2].HeaderText = "رقم الكتاب";
                    Dgv.Columns[3].HeaderText = "تاريخ الكتاب";
                    Dgv.Columns[4].HeaderText = "جهة الاصدار";
                    Dgv.Columns[5].HeaderText = "تفاصيل الكتاب";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "بيانات اولاد المنتسب":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "اسم الابن";
                    Dgv.Columns[2].HeaderText = "الجنس";
                    Dgv.Columns[3].HeaderText = "تاريخ الولادة";
                    Dgv.Columns[4].HeaderText = "العمر";
                    Dgv.Columns[5].HeaderText = "الحالة الاجتماعية";
                    Dgv.Columns[6].HeaderText = "المهنة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "دوريات المنتسبين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الدورية";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "دوريات المنتسبين حسب الشعبة":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الدورية";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب الشعبة":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "الوحدة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.Columns[4].HeaderText = "العنوان الوظيفي";

                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب العنوان الوظيفي":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "العنوان الوظيفي";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.Columns[3].HeaderText = "الوحدة";
                    Dgv.Columns[4].HeaderText = "مكان العمل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب الموقف":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "موقف المنتسب";
                    Dgv.Columns[2].HeaderText = "الجهة المستفيدة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب الحالة":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الحالة";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.Columns[3].HeaderText = "الوحدة";
                    Dgv.Columns[4].HeaderText = "مكان العمل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب الوحدات":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الوحدة";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب مكان العمل":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "العنوان الوظيفي";
                    Dgv.Columns[2].HeaderText = "الوحدة";
                    Dgv.Columns[3].HeaderText = "الشعبة";
                    Dgv.Columns[4].HeaderText = "مكان العمل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;

                case "سجل حضور منتسب":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "وقت وتاريخ الحضور";
                    Dgv.Columns[2].HeaderText = "وقت وتاريخ الانصراف";
                    Dgv.Columns[3].HeaderText = "الوجبة";
                    Dgv.Columns[4].HeaderText = "عدد ساعات الدوام";
                    Dgv.Columns[5].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "سجل الحضور اليومي":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "وقت وتاريخ الحضور";
                    Dgv.Columns[3].HeaderText = "وقت وتاريخ الانصراف";
                    Dgv.Columns[4].HeaderText = "الوجبة";
                    Dgv.Columns[5].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "الاستضافة والتنسيب بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الحالة";
                    Dgv.Columns[2].HeaderText = "المدة / شهر";
                    Dgv.Columns[3].HeaderText = "من تاريخ";
                    Dgv.Columns[4].HeaderText = "الى تاريخ";
                    Dgv.Columns[5].HeaderText = "الجهة المستفيدة";
                    Dgv.Columns[6].HeaderText = "الموقف";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "الاستضافة والتنسيب لمنتسب بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الحالة";
                    Dgv.Columns[2].HeaderText = "المدة";
                    Dgv.Columns[3].HeaderText = "من تاريخ";
                    Dgv.Columns[4].HeaderText = "الى تاريخ";
                    Dgv.Columns[5].HeaderText = "الجهة المستفيدة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "وجبة العمل حسب الشعبة بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الوحبة";
                    Dgv.Columns[2].HeaderText = "من تاريخ";
                    Dgv.Columns[3].HeaderText = "الى تاريخ";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "وجبة عمل منتسب بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الوحبة";
                    Dgv.Columns[2].HeaderText = "من تاريخ";
                    Dgv.Columns[3].HeaderText = "الى تاريخ";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "فئة عمل المنتسبين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "فئة العمل";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "فئة عمل المنتسبين حسب الشعبة":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "فئة العمل";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب فئات العمل":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "فئة العمل";
                    Dgv.Columns[2].HeaderText = "الشعبة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد الزمنيات الغير مستقطعة بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "اجمالي الزمنيات غير المستقطعة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد كافة الزمنيات بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "اجمالي الزمنيات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "زمنيات منتسب بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الزمنيات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "عناوين المنتسبين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "الوحدة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.Columns[4].HeaderText = "السكن";
                    Dgv.Columns[5].HeaderText = "اقرب نقطة دالة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "ارقام هواتف المنتسبين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "الوحدة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.Columns[4].HeaderText = "موبايل 1";
                    Dgv.Columns[5].HeaderText = "موبايل 2";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب التحصيل الدراسي":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "الوحدة";
                    Dgv.Columns[3].HeaderText = "مكان العمل";
                    Dgv.Columns[4].HeaderText = "التحصيل الدارسي";
                    Dgv.Columns[5].HeaderText = "اخر مرحلة دراسية";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "ارقام تخاويل المنتسبين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "رقم التخويل";
                    Dgv.Columns[3].HeaderText = "تاريخ التخويل";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "بيانات عائلية":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الشعبة";
                    Dgv.Columns[2].HeaderText = "الحالة الاجتماعية";
                    Dgv.Columns[3].HeaderText = "عدد الاولاد";
                    Dgv.Columns[4].HeaderText = "مهنة الزوجة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد موقف المنتسبين":
                    Dgv.Columns[0].HeaderText = "موقف المنتسبين";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "خلاصة الاعداد حسب العنوان الوظيفي":
                    Dgv.Columns[0].HeaderText = "العنوان الوظيفي";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;

                case "خلاصة الاعداد حسب الجهات المستفيدة":
                    Dgv.Columns[0].HeaderText = "الجهة المستفيدة";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "خلاصة الاعداد حسب الحالة":
                    Dgv.Columns[0].HeaderText = "الحالة";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "خلاصة الاعداد حسب الوحدات":
                    Dgv.Columns[0].HeaderText = "الوحدة";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "المتغيرات اليومية العودة":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "ملاحظات";
                    Dgv.Columns[2].HeaderText = "تاريخ الحالة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "متغيرات منتسب":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الحالة";
                    Dgv.Columns[2].HeaderText = "عدد";
                    Dgv.Columns[3].HeaderText = "نوع الحالة";
                    Dgv.Columns[4].HeaderText = "تاريخ الانقطاع";
                    Dgv.Columns[5].HeaderText = "تاريخ العودة";
                    Dgv.Columns[6].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "متغيرات منتسب بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الحالة";
                    Dgv.Columns[2].HeaderText = "عدد";
                    Dgv.Columns[3].HeaderText = "نوع الحالة";
                    Dgv.Columns[4].HeaderText = "تاريخ الانقطاع";
                    Dgv.Columns[5].HeaderText = "تاريخ العودة";
                    Dgv.Columns[6].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "المتغيرات اليومية مجازون":
                case "المتغيرات اليومية مجازون بين تاريخين":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "ملاحظات";
                    Dgv.Columns[2].HeaderText = "تاريخ الحالة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "المنتسبين المنقطعين بدون عودة":
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "ملاحظات";
                    Dgv.Columns[2].HeaderText = "تاريخ الحالة";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "خلاصة حسب اماكن العمل":
                    Dgv.Columns[0].HeaderText = "مكان العمل";
                    Dgv.Columns[1].HeaderText = "العدد";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "جرد المنتسبين حسب الشعبة والوجبة":
                    Dgv.Columns[0].HeaderText = "اسم النتسب";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                    
                case "ايفادات حسب الاسم بين تاريخين":
                case "ايفادات حسب الجهة المقصودة بين تاريخين":
                case "ايفادات حسب رقم العجلة بين تاريخين":
                case "ايفادات بين تاريخين":
                case "جرد حسب حالة الايفاد بين تاريخين":
                case "جرد حسب مرحلة الايفاد بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";                   
                    Dgv.Columns[1].HeaderText = "رقم التخويل";
                    Dgv.Columns[2].HeaderText = "تاريخ التخويل";
                    Dgv.Columns[3].HeaderText = "رقم العجلة";
                    Dgv.Columns[4].HeaderText = "نوع العجلة";
                    Dgv.Columns[5].HeaderText = "وقت الذهاب";
                    Dgv.Columns[6].HeaderText = "تاريخ الذهاب";
                    Dgv.Columns[7].HeaderText = "وقت العودة";
                    Dgv.Columns[8].HeaderText = "تاريخ العودة";
                    Dgv.Columns[9].HeaderText = "الجهة المقصودة";
                    Dgv.Columns[10].HeaderText = "الجهة المستفيدة";
                    Dgv.Columns[11].HeaderText = "راعية / غير راعية";
                    Dgv.Columns[12].Visible = false;
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }
        }
    }
    
}
