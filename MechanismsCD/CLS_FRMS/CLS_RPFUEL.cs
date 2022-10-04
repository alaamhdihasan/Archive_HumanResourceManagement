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
    class CLS_RPFUEL
    {
        //Report for bill between tow date
        public DataTable FUEL_BillEntrayBetweenTowDate(string storename,DateTimePicker dt1, DateTimePicker dt2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@storename", SqlDbType.VarChar, 50); param[0].Value = storename;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = dt1.Text;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillEntryBetweentowdate", param);
            dal.close();
            return Dt;
        }

        //-------------------------------------------------------------
        //Report bill exit between date
        public DataTable FUEL_BillExitBetweenTowDate(DateTimePicker dt1, DateTimePicker dt2,string FuelType)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[0].Value = dt1.Text;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[1].Value = dt2.Text;
            param[2] = new SqlParameter("@storename", SqlDbType.VarChar, 50); param[2].Value = FuelType;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillExitBetweentowdate", param);
            dal.close();
           
            return Dt;
        }

        //---------------------------------------------------------------
        //Report bill exit departments between tow date
        public DataTable FUEL_BillEXitDeptBetweenTowDate(string Dept,string FuelType, DateTimePicker dt1, DateTimePicker dt2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Dept", SqlDbType.VarChar, 50); param[0].Value = Dept;
            param[1] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50); param[1].Value = FuelType;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[2].Value = dt1.Text;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[3].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillExitDeptBetweentowdate", param);
            dal.close();
            return Dt;
        }

        //--------------------------------------------------------------
        //Report bill exit departments summary
        public DataTable FUEL_BillEXitDeptsSummaryBetweenTowDate(string FuelType, DateTimePicker dt1, DateTimePicker dt2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50); param[0].Value = FuelType;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = dt1.Text;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillExitDeptsSummaryBetweentowdate", param);
            dal.close();
            return Dt;
        }

        //-----------------------------------------------------------
        //Report bill exit for car between tow date
        public DataTable FUEL_BillEXitCarBetweenTowDate(string carNo, DateTimePicker dt1, DateTimePicker dt2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50); param[0].Value = carNo;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = dt1.Text;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillExitCarBetweentowdate", param);
            dal.close();
            return Dt;
        }

        //-----------------------------------------------------------
        //Report bill exit for car summary between tow date
        public DataTable FUEL_BillEXitCarsSummaryBetweenTowDate(string FuelType, DateTimePicker dt1, DateTimePicker dt2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50); param[0].Value = FuelType;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50); param[1].Value = dt1.Text;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50); param[2].Value = dt2.Text;
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("RPFUEL_BillExitCarsSummaryBetweentowdate", param);
            dal.close();
            return Dt;
        }

        //---------------------------------------------------------
        //design datagrid view for report
        public void Dgvdesign(DataGridView Dgv, DataTable Dt, ComboBox cbo, string RPtype)
        {
            Dgv.DataSource = Dt;
            if (RPtype == "ادخال")
            {
                switch (cbo.Text)
                {
                    case "فواتير بين تاريخين":
                        
                        Dgv.DataSource = Dt;
                        
                        Dgv.Columns[0].HeaderText = "رقم الفاتورة";
                        Dgv.Columns[1].HeaderText = "تاريخ الفاتورة";
                        Dgv.Columns[2].HeaderText = "نوع الوقود";
                        Dgv.Columns[3].HeaderText = "اسم المخزن";
                        Dgv.Columns[4].HeaderText = "السعة";
                        Dgv.Columns[5].HeaderText = "رقم السيارة";
                        Dgv.Columns[6].HeaderText = "نوع السيارة";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;

                    
                }
            }else if (RPtype == "اخراج")
            {
                switch (cbo.Text)
                {
                    case "فواتير بين تاريخين":
                        
                        Dgv.DataSource = Dt;
                        Dgv.Columns[0].HeaderText = "رقم الفاتورة";
                        Dgv.Columns[1].HeaderText = "تاريخ الفاتورة";
                        Dgv.Columns[2].HeaderText = "رقم السيارة";
                        Dgv.Columns[3].HeaderText = "نوع السيارة";
                        Dgv.Columns[4].HeaderText = "السعة";                        
                        Dgv.Columns[5].HeaderText = "الجهة المستفيدة";
                        Dgv.Columns[6].HeaderText = "المبلغ بدون اضافات";
                        Dgv.Columns[7].HeaderText = "المبلغ الكلي";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;

                    case "فواتير قسم بين تاريخين":
                        
                        Dgv.DataSource = Dt;
                        Dgv.Columns[0].HeaderText = "رقم الفاتورة";
                        Dgv.Columns[1].HeaderText = "تاريخ الفاتورة";
                        Dgv.Columns[2].HeaderText = "رقم السيارة";
                        Dgv.Columns[3].HeaderText = "نوع السيارة";
                        Dgv.Columns[4].HeaderText = "السعة";
                        Dgv.Columns[5].HeaderText = "المبلغ بدون اضافة";
                        Dgv.Columns[6].HeaderText = "المبلغ الكلي";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;

                    case "خلاصة صرفيات الاقسام بين تاريخين":
                       
                        Dgv.DataSource = Dt;
                        Dgv.Columns[0].HeaderText = "القسم";
                        Dgv.Columns[1].HeaderText = "الكمية";
                        Dgv.Columns[2].HeaderText = "المبلغ بدون اضافة";
                        Dgv.Columns[3].HeaderText = "المبلغ الكلي";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;

                    case "صرفيات عجلة بين تاريخين":
                        
                        Dgv.DataSource = Dt;
                        Dgv.Columns[0].HeaderText = "رقم الفاتورة";
                        Dgv.Columns[1].HeaderText = "تاريخ الفاتورة";
                        Dgv.Columns[2].HeaderText = "السعة";
                        Dgv.Columns[3].HeaderText = "اسم السائق";
                        Dgv.Columns[4].HeaderText = "الجهة المستفيدة";
                        Dgv.Columns[5].HeaderText = "المبلغ بدون اضافة";
                        Dgv.Columns[6].HeaderText = "المبلغ الكلي";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;

                    case "خلاصة عجلات بين تاريخين":
                       
                        Dgv.DataSource = Dt;
                        Dgv.Columns[0].HeaderText = "رقم السيارة";
                        Dgv.Columns[1].HeaderText = "نوع السيارة";
                        Dgv.Columns[2].HeaderText = "الجهة المستفيدة";
                        Dgv.Columns[3].HeaderText = "الكمية";
                        Dgv.Columns[4].HeaderText = "المبلغ بدون اضافة";
                        Dgv.Columns[5].HeaderText = "المبلغ الكلي";
                        Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        break;
                }
            }
        }
    }
}
