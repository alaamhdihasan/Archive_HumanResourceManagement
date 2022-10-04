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
    class CLS_RPATTENDENCE
    {
        //==Report of Attendence

        //===========================

        //=== This Function Below for get Attendence info. by shift and date from attendence2....
        public DataTable SelectShiftByDate(string Shift,string Day, string Date1, string Date2)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Shift", SqlDbType.VarChar, 50); param[0].Value = Shift;
            param[1] = new SqlParameter("@Day", SqlDbType.VarChar, 50); param[1].Value = Day;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[2].Value = Date1;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[3].Value = Date2;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingByDateAndShift", param);
            GettingData.close();
            return Dt;
        }

        //=== This Function Below for get Attendence info. by Employee Name and date from attendence2....
        public DataTable SelectEmpByEmpNameAndDate(string Name, string Date1, string Date2)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Name", SqlDbType.VarChar, 50); param[0].Value = Name;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = Date1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = Date2;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingByDateAndEmpName", param);
            GettingData.close();
            return Dt;
        }

        //=== This Function Below for get Attendence info. by Work Type and date from attendence2....
        public DataTable SelectEmpByWorkTypeAndDate(string WorkType, string Date1, string Date2)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@WorkType", SqlDbType.VarChar, 50); param[0].Value = WorkType;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = Date1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = Date2;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingByDateAndWorkType", param);
            GettingData.close();
            return Dt;
        }

        //=== This Function Below for get Attendence info. by Delay and date from attendence2....
        public DataTable SelectEmpByDaleytAndDate(string Shift, string Date1, string Date2)
        {
            DAL.DataAccessLayer GettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@shift", SqlDbType.VarChar, 50); param[0].Value = Shift;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = Date1;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = Date2;
            GettingData.open();
            DataTable Dt = GettingData.SelectingData("Attendence2SelectingByDateAndDelay", param);
            GettingData.close();
            return Dt;
        }

        //design datagrid view for report
        public void Dgvdesign(DataGridView Dgv, DataTable Dt, ComboBox cbo)
        {
            Dgv.DataSource = Dt;

            switch (cbo.Text)
            {
                case "وجبة بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "فئةالعمل";
                    Dgv.Columns[2].HeaderText = "وقت الحضور";
                    Dgv.Columns[3].HeaderText = "تاريخ الحضور";
                    Dgv.Columns[4].HeaderText = "وقت الانصراف";
                    Dgv.Columns[5].HeaderText = "تاريخ الانصراف";
                    Dgv.Columns[6].HeaderText = "ساعات العمل";                                  
                    Dgv.Columns[7].HeaderText = "الملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;

                case "حسب اسم المنتسب":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "الوجبة";
                    Dgv.Columns[1].HeaderText = "وقت الحضور";
                    Dgv.Columns[2].HeaderText = "تاريخ الحضور";
                    Dgv.Columns[3].HeaderText = "وقت الانصراف";
                    Dgv.Columns[4].HeaderText = "تاريخ الانصراف";
                    Dgv.Columns[5].HeaderText = "ساعات العمل";
                    Dgv.Columns[6].HeaderText = "حالة المنتسب";
                    Dgv.Columns[7].HeaderText = "الملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "زمنيات حسب الوجبة بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الوجبة";
                    Dgv.Columns[2].HeaderText = "فئةالعمل";
                    Dgv.Columns[3].HeaderText = "وقت الحضور";
                    Dgv.Columns[4].HeaderText = "تاريخ الحضور";
                    Dgv.Columns[5].HeaderText = "وقت الانصراف";
                    Dgv.Columns[6].HeaderText = "تاريخ الانصراف";
                    Dgv.Columns[7].HeaderText = "ساعات العمل";
                    Dgv.Columns[8].HeaderText = "زمنية الحضور";
                    Dgv.Columns[9].HeaderText = "زمنية الانصراف";
                    Dgv.Columns[10].HeaderText = "حالة المنتسب";
                    Dgv.Columns[11].HeaderText = "الملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case "حسب فئة العمل بين تاريخين":
                    Dgv.DataSource = Dt;
                    Dgv.Columns[0].HeaderText = "اسم المنتسب";
                    Dgv.Columns[1].HeaderText = "الوجبة";
                    Dgv.Columns[2].HeaderText = "وقت الحضور";
                    Dgv.Columns[3].HeaderText = "تاريخ الحضور";
                    Dgv.Columns[4].HeaderText = "وقت الانصراف";
                    Dgv.Columns[5].HeaderText = "تاريخ الانصراف";
                    Dgv.Columns[6].HeaderText = "ساعات العمل";
                    Dgv.Columns[7].HeaderText = "حالة المنتسب";
                    Dgv.Columns[8].HeaderText = "الملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }
        }
    }
}
