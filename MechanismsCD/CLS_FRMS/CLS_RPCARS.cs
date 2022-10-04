
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLS_RPCARS
    {
        //==Report of Cars

        //===========================

        //=== This Function Below for get Cars info. by Car Type from DivisionCars....
        public DataTable SelectCarsByCarType(string CarType)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarType", SqlDbType.VarChar, 50); param[0].Value = CarType;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarType", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by Car Company from DivisionCars....
        public DataTable SelectCarsByCarCo(string CarCo)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarCo", SqlDbType.VarChar, 50); param[0].Value = CarCo;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarCo", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by Car State from DivisionCars....
        public DataTable SelectCarsByCarState(string CarState)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarState", SqlDbType.VarChar, 50); param[0].Value = CarState;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarState", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by Car Department from DivisionCars....
        public DataTable SelectCarsByCarDep(string CarDep)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarDep", SqlDbType.VarChar, 50); param[0].Value = CarDep;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarDep", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by Car Fuel Type from DivisionCars....
        public DataTable SelectCarsByCarFuel(string CarFuel)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarFuel", SqlDbType.VarChar, 50); param[0].Value = CarFuel;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_Carfuel", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by Car Model from DivisionCars....
        public DataTable SelectCarsByCarModel(string CarModel)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarModel", SqlDbType.VarChar, 50); param[0].Value = CarModel;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarModel", param);
            GettingData.close();
            return Dt;
        }
        //====================================================================================================

        //=== This Function Below for get Cars info. by Car Tire Size from DivisionCars....
        public DataTable SelectCarsByCarTireSize(string TireSize)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarTireSize", SqlDbType.VarChar, 50); param[0].Value = TireSize;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarTireSize", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by car type and Car Model from DivisionCars....
        public DataTable SelectCarsByCarTypeandModel(string CarType, string CarModel)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarType", SqlDbType.VarChar, 50); param[0].Value = CarType;
            param[1] = new SqlParameter("@CarModel", SqlDbType.VarChar, 50); param[1].Value = CarModel;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarTypeandModel", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by car company and Car Model from DivisionCars....
        public DataTable SelectCarsByCarCoandModel(string CarCo, string CarModel)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarCo", SqlDbType.VarChar, 50); param[0].Value = CarCo;
            param[1] = new SqlParameter("@CarModel", SqlDbType.VarChar, 50); param[1].Value = CarModel;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarCoandModel", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by car State and Car Model from DivisionCars....
        public DataTable SelectCarsByCarStateandModel(string CarState, string CarModel)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarState", SqlDbType.VarChar, 50); param[0].Value = CarState;
            param[1] = new SqlParameter("@CarModel", SqlDbType.VarChar, 50); param[1].Value = CarModel;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarStateandModel", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by car Type and Car Department from DivisionCars....
        public DataTable SelectCarsByCarTypeandDep(string CarType, string CarDep)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarType", SqlDbType.VarChar, 50); param[0].Value = CarType;
            param[1] = new SqlParameter("@CarDep", SqlDbType.VarChar, 50); param[1].Value = CarDep;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarTypeandDep", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Cars info. by car State and Car Department from DivisionCars....
        public System.Data.DataTable SelectCarsByCarStateandDep(string CarState, string CarDep)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarState", SqlDbType.VarChar, 50); param[0].Value = CarState;
            param[1] = new SqlParameter("@CarDep", SqlDbType.VarChar, 50); param[1].Value = CarDep;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarStateandDep", param);
            GettingData.close();
            return Dt;
        }

    
        //====================================================================================================

        //=== This Function Below for get Cars info. by car Division and Car Department from DivisionCars....
        public System.Data.DataTable SelectCarsByCarDivisionandDep(string CarDep, string CarDiv)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CarDep", SqlDbType.VarChar, 50); param[0].Value = CarDep;
            param[1] = new SqlParameter("@CarDivision", SqlDbType.VarChar, 50); param[1].Value = CarDiv;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_CarDivisionandDep", param);
            GettingData.close();
            return Dt;
        }
        //====================================================================================================

        //=== This Function Below for get Summary Cars info. by car Type from DivisionCars....
        public System.Data.DataTable SummryCarType(string CarType)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarType", SqlDbType.VarChar, 50); param[0].Value = CarType;
           
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_SummryCarByType", param);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //=== This Function Below for get Summary Cars info. by car division from DivisionCars....
        public System.Data.DataTable SummryCarDiviion(string Department,string Division)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@department", SqlDbType.VarChar, 50); param[0].Value = Department;
            param[1] = new SqlParameter("@Division", SqlDbType.VarChar, 50); param[1].Value = Division;

            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_SummryCarByDivision", param);
            GettingData.close();
            return Dt;
        }
        //====================================================================================================

        //=== This Function Below for get Summary Cars info. by car Department from DivisionCars....
        public DataTable SummryCarDEpartment()
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("RPCD_SummryCarByDepartment", null);
            GettingData.close();
            return Dt;
        }

        //====================================================================================================

        //design datagrid view for report
        public void Dgvdesign(DataGridView Dgv, DataTable Dt, ComboBox cbo)
        {
            Dgv.DataSource = Dt;
            switch (cbo.Text)
            {
                case "حسب نوع العجلة":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[2].HeaderText = "الموديل";
                    Dgv.Columns[3].HeaderText = "العائدية";
                    break;
                case "حسب الشركة المصنعة":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الموديل";
                    Dgv.Columns[3].HeaderText = "العائدية"; 
                    break;
                case "حسب الحالة":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "الموديل";
                    Dgv.Columns[4].HeaderText = "العائدية";
                    break;
                case "حسب عائدية العجلة":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "الموديل";
                    break;
                case "حسب نوع الوقود":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "الموديل";
                    Dgv.Columns[4].HeaderText = "العائدية";
                    break;
                case "حسب الموديل":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "العائدية";
                    break;
                case "حسب قياس الاطار":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "العائدية";
                    Dgv.Columns[4].HeaderText = "الموديل";
                    break;
                case "حسب نوع العجلة والموديل":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[2].HeaderText = "العائدية";
                    break;
                case "حسب الشركة المصنعة و الموديل":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "العائدية";
                    break;
                case "حسب الحالة والموديل":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "العائدية";
                    break;
                case "حسب نوع العجلة والعائدية":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[2].HeaderText = "الموديل";
                    break;
                case "حسب الحالة والعائدية":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "الموديل";
                    break;
                case "حسب القسم والشعبة":
                    Dgv.Columns[0].HeaderText = "رقم السيارة";
                    Dgv.Columns[1].HeaderText = "نوع السيارة";
                    Dgv.Columns[2].HeaderText = "الشركة المصنعة";
                    Dgv.Columns[3].HeaderText = "الموديل";
                    break;
                case "خلاصة حسب نوع العجلة":
                    Dgv.Columns[0].HeaderText = "عائدية العجلة";
                    Dgv.Columns[1].HeaderText = "العدد";
                    break;
                case "خلاصة حسب الشعبة ":
                    Dgv.Columns[0].HeaderText = "الشعبة";
                    Dgv.Columns[1].HeaderText = "نوع العجلة";
                    Dgv.Columns[2].HeaderText = "العدد";
                    break;
                case "خلاصة حسب العائدية":
                    Dgv.Columns[0].HeaderText = "العائدية";
                    Dgv.Columns[1].HeaderText = "نوع العجلة";
                    Dgv.Columns[2].HeaderText = "العدد";
                    break;
            }
           
            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }
    }
}
