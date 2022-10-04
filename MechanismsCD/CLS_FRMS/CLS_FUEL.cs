using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
//using DevExpress.XtraRichEdit.API.Word;
using System.Drawing;
using DevExpress.Utils.Drawing;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLS_FUEL
    {
        

        //Select Data of Fuel Entry 
        public DataTable SelectFuelEntry()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("FuelEntriesSelecting", null);
            dal.close();
            return Dt;
        }

        //------------------------------------------------------------
        //insert new bill and fuel to store
        public void InsertFuelEntry(int StoreID, string BillNo, DateTime BillDate, string FuelType, string StoreName, double Quantity, string CarNO,
            string CarType, string RegisterName, string AddingTime, string AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param;
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDst", SqlDbType.Int);
            param[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", param);
            dal.close();

            if (Quantity + int.Parse(dtQuan.Rows[0][0].ToString()) <= int.Parse(dtQuan.Rows[0][1].ToString()))
            {
                param = new SqlParameter[10];
                param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
                param[0].Value = BillNo;
                param[1] = new SqlParameter("@BillDate", SqlDbType.Date);
                param[1].Value = BillDate;
                param[2] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50);
                param[2].Value = FuelType;
                param[3] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);
                param[3].Value = StoreName;
                param[4] = new SqlParameter("@Quantity", SqlDbType.Real);
                param[4].Value = Quantity;
                param[5] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);
                param[5].Value = CarNO;
                param[6] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);
                param[6].Value = CarType;
                param[7] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);
                param[7].Value = RegisterName;
                param[8] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);
                param[8].Value = AddingTime;
                param[9] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);
                param[9].Value = AddingDate;
                dal.open();
                dal.ExecuteCommand("FuelentriesInsertinto", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = Quantity + int.Parse(dtQuan.Rows[0][0].ToString());
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = int.Parse(dtQuan.Rows[0][1].ToString());
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("المخزن ممتلئ");
        }

        //---------------------------------------------------------------
        //Update data of billFuel in database
        public void UpdateFuelEntray(int StoreID,int idfuel, string BillNo, DateTime BillDate, string FuelType, string StoreName, double Quantity, string CarNO,
            string CarType, string RegisterName, string AddingTime, string AddingDate,double QuantityUpdate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] paramStore;
            paramStore = new SqlParameter[1];
            paramStore[0] = new SqlParameter("@IDst", SqlDbType.Int);
            paramStore[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", paramStore);
            dal.close();

            if (QuantityUpdate + Convert.ToDouble(dtQuan.Rows[0][0]) <= Convert.ToDouble(dtQuan.Rows[0][1]))
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@idfuel", SqlDbType.Int);
                param[0].Value = idfuel;
                param[1] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
                param[1].Value = BillNo;
                param[2] = new SqlParameter("@BillDate", SqlDbType.Date);
                param[2].Value = BillDate.Date;
                param[3] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50);
                param[3].Value = FuelType;
                param[4] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);
                param[4].Value = StoreName;
                param[5] = new SqlParameter("@Quantity", SqlDbType.Real);
                param[5].Value = Quantity;
                param[6] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);
                param[6].Value = CarNO;
                param[7] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);
                param[7].Value = CarType;
                param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);
                param[8].Value = RegisterName;
                param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);
                param[9].Value = AddingTime;
                param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);
                param[10].Value = AddingDate;
                dal.open();
                dal.ExecuteCommand("Fuelentriesupdate", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = QuantityUpdate + Convert.ToDouble(dtQuan.Rows[0][0]);
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = Convert.ToDouble(dtQuan.Rows[0][1]);
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("المخزن لا يكفي");
        }

        //--------------------------------------------------------------------
        //delete bill from data bill and from fuel store
        public void DeleteFuelEntry(int IDfuel,int StoreID,string StoreName,double Quantity)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] paramStore;
            paramStore = new SqlParameter[1];
            paramStore[0] = new SqlParameter("@IDst", SqlDbType.Int);
            paramStore[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", paramStore);
            dal.close();
            if (Convert.ToDouble(dtQuan.Rows[0][0]) - Quantity >= 0)
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IDfuel", SqlDbType.Int);
                param[0].Value = IDfuel;
                dal.open();
                dal.ExecuteCommand("FuelEntriesDeleting", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = Convert.ToDouble(dtQuan.Rows[0][0])-Quantity;
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = Convert.ToDouble(dtQuan.Rows[0][1]);
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("المخزن لا يكفي");
        }

        //-------------------------------------------------------------------
        //select stores to add new quantity
        public DataTable SelectStores()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("TheStoreSelecting", null);
            dal.close();
            return Dt;
        }


        //===================================================================
        //Select Data of Fuel Selling 
        public DataTable SelectFuelExit()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("FuelSellingSelecting", null);
            dal.close();
            return Dt;
        }

        //------------------------------------------------------------
        //insert new bill and selling fuel to store
        public void InsertFuelExit(int StoreID, string BillNo, DateTime BillDate, string CarNO, string CarType, double Quantity, string DriverName, string TheBeneficiary, string StoreName,
             string RegisterName, string AddingTime, string AddingDate, bool DeptInvest,double price,double totalprice)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param;
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDst", SqlDbType.Int);
            param[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", param);
            dal.close();
            
            if (int.Parse(dtQuan.Rows[0][0].ToString()) - Quantity >= 0)
            {
                param = new SqlParameter[14];
                param[0] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
                param[0].Value = BillNo;
                param[1] = new SqlParameter("@BillDate", SqlDbType.Date);
                param[1].Value = BillDate;
                param[2] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);
                param[2].Value = CarNO;
                param[3] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);
                param[3].Value = CarType;
                param[4] = new SqlParameter("@Quantity", SqlDbType.Real);
                param[4].Value = Quantity;
                param[5] = new SqlParameter("@Drivername", SqlDbType.VarChar, 50);
                param[5].Value = DriverName;
                param[6] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);
                param[6].Value = TheBeneficiary;
                param[7] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);
                param[7].Value = StoreName;
                param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);
                param[8].Value = RegisterName;
                param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);
                param[9].Value = AddingTime;
                param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);
                param[10].Value = AddingDate;
                param[11] = new SqlParameter("@DeptInvest", SqlDbType.Bit);
                param[11].Value = DeptInvest;               
                param[12] = new SqlParameter("@price", SqlDbType.Real);
                param[12].Value = price;
                param[13] = new SqlParameter("@totalprice", SqlDbType.Real);
                param[13].Value = totalprice;
                dal.open();
                dal.ExecuteCommand("FuelsellingInsertInto", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = int.Parse(dtQuan.Rows[0][0].ToString())- Quantity;
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = int.Parse(dtQuan.Rows[0][1].ToString());
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("الوقود في المخزن لا يكفي");
        }

        //---------------------------------------------------------------
        //Update data of billFuel in database
        public void UpdateFuelExit(int StoreID, int idfuel, string BillNo, DateTime BillDate, string CarNO, string CarType, double Quantity, string DriverName, string TheBeneficiary, string StoreName,
             string RegisterName, string AddingTime, string AddingDate, double QuantityUpdate, bool DeptInvest, double price,double totalprice)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] paramStore;
            paramStore = new SqlParameter[1];
            paramStore[0] = new SqlParameter("@IDst", SqlDbType.Int);
            paramStore[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", paramStore);
            dal.close();

            if (QuantityUpdate + Convert.ToDouble(dtQuan.Rows[0][0]) <= Convert.ToDouble(dtQuan.Rows[0][1]))
            {
                
                SqlParameter[] param = new SqlParameter[15];
                param[0] = new SqlParameter("@IDFuel", SqlDbType.Int);
                param[0].Value = idfuel;
                param[1] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
                param[1].Value = BillNo;
                param[2] = new SqlParameter("@BillDate", SqlDbType.Date);
                param[2].Value = BillDate;
                param[3] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);
                param[3].Value = CarNO;
                param[4] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);
                param[4].Value = CarType;
                param[5] = new SqlParameter("@Quantity", SqlDbType.Real);
                param[5].Value = Quantity;
                param[6] = new SqlParameter("@Drivername", SqlDbType.VarChar, 50);
                param[6].Value = DriverName;
                param[7] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);
                param[7].Value = TheBeneficiary;
                param[8] = new SqlParameter("@StoreName", SqlDbType.VarChar, 50);
                param[8].Value = StoreName;
                param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);
                param[9].Value = RegisterName;
                param[10] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);
                param[10].Value = AddingTime;
                param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);
                param[11].Value = AddingDate;
                param[12] = new SqlParameter("@DeptInvest", SqlDbType.Bit);
                param[12].Value = DeptInvest;
                param[13] = new SqlParameter("@price", SqlDbType.Real);
                param[13].Value = price;
                param[14] = new SqlParameter("@totalprice", SqlDbType.Real);
                param[14].Value = totalprice;
                dal.open();
                dal.ExecuteCommand("FuelsellingUpdate", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = Convert.ToDouble(dtQuan.Rows[0][0]) + QuantityUpdate;
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = Convert.ToDouble(dtQuan.Rows[0][1]);
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("المخزن لا يكفي");
        }

        //--------------------------------------------------------------------
        //delete bill from data bill and from seliing fuel store
        public void DeleteFuelExit(int IDfuel, int StoreID, string StoreName, double Quantity)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] paramStore;
            paramStore = new SqlParameter[1];
            paramStore[0] = new SqlParameter("@IDst", SqlDbType.Int);
            paramStore[0].Value = StoreID;
            dal.open();
            DataTable dtQuan = dal.SelectingData("TheStoreSelectingQuantity", paramStore);
            dal.close();

            if (Convert.ToDouble(dtQuan.Rows[0][0]) + Quantity <= Convert.ToDouble(dtQuan.Rows[0][1]))
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IDfuel", SqlDbType.Int);
                param[0].Value = IDfuel;
                dal.open();
                dal.ExecuteCommand("FuelsellingDeleting", param);
                dal.close();

                param = new SqlParameter[4];
                param[0] = new SqlParameter("@IDst", SqlDbType.Int);
                param[0].Value = StoreID;
                param[1] = new SqlParameter("@StroeName", SqlDbType.VarChar, 50);
                param[1].Value = StoreName;
                param[2] = new SqlParameter("@quantity", SqlDbType.Real);
                param[2].Value = Convert.ToDouble(dtQuan.Rows[0][0]) + Quantity;
                param[3] = new SqlParameter("@MaxQuantity", SqlDbType.Real);
                param[3].Value = Convert.ToDouble(dtQuan.Rows[0][1]);
                dal.open();
                dal.ExecuteCommand("TheStoreUPdate", param);
                dal.close();
            }
            else
                MessageBox.Show("المخزن لا يكفي");
        }

        //show data in stores in progress bar
        public void ShowStores(TableLayoutPanel StoresLayoutPanel , string page)
        {
            StoresLayoutPanel.Controls.Clear();
            DataTable dt = SelectStores();
            if (dt.Rows.Count > 0) { 
                StoresLayoutPanel.ColumnCount = dt.Rows.Count;
            
                int percent = 100 / dt.Rows.Count;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int Qun = Convert.ToInt32(dt.Rows[i][2]) * 100 / Convert.ToInt32(dt.Rows[i][3]);
                    StoresLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                    Label storeName = new Label();
                    storeName.Text = (i + 1) + "-" + dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + "-" + dt.Rows[i][3].ToString();
                    storeName.Font = new System.Drawing.Font("JF Flat", 10, FontStyle.Bold);
                    StoresLayoutPanel.Controls.Add(storeName, i, 1);
                    storeName.Dock = DockStyle.Fill;
                    storeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    if (page == "مخازن الوقود")
                    {
                        storeName.Click += delegate (object sender, EventArgs e)
                         {
                             int id = int.Parse(dt.Rows[int.Parse(storeName.Text.Substring(0, 1)) - 1][0].ToString());
                             FRMS.FRMFUELPRICE f = new FRMS.FRMFUELPRICE(id);
                             f.ShowDialog();
                         };
                        storeName.MouseHover += delegate (object sender, EventArgs e)
                          {
                              storeName.ForeColor = Color.Red;
                              storeName.Cursor = Cursors.Hand;
                          };
                        storeName.MouseLeave += delegate (object sender, EventArgs e)
                         {
                             storeName.ForeColor = Color.Black;
                         };
                    }
                    ProgressBarControl pr = new ProgressBarControl();
                    pr.Text = Qun.ToString();
                    pr.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                    pr.LookAndFeel.UseDefaultLookAndFeel = false;
                    pr.Properties.TextOrientation = TextOrientation.Horizontal;
                    pr.Properties.ProgressKind = DevExpress.XtraEditors.Controls.ProgressKind.Vertical;
                    pr.RightToLeft = RightToLeft.No;
                    pr.Font = new System.Drawing.Font("JF Flat", 15, FontStyle.Bold);

                    pr.Properties.StartColor = Color.Blue;
                    pr.Properties.EndColor = Color.Red;
                    pr.Properties.ShowTitle = true;


                    pr.Dock = DockStyle.Fill;
                    StoresLayoutPanel.Controls.Add(pr, i, 0);
                }
            }
        }
       
        //-------------------------------------------------------------------
        //show Entry data in datagridview
        public DataTable showFuelEntrayData(DataGridView DgvFuelEntry, TextBox txtID,TextBox txtBillNo,DateTimePicker DateBill,
            System.Windows.Forms.ComboBox cmbFuelType, System.Windows.Forms.ComboBox cmbStoreName,TextBox txtQuantity, System.Windows.Forms.ComboBox cmbCarNo, System.Windows.Forms.ComboBox cmbCarType,
            TextBox txtRegisterName,TextBox txtRegisterTime,TextBox txtRegisterDate)
        {
            try
            {

                DgvFuelEntry.DataSource = null;
                txtID.DataBindings.Clear();
                txtBillNo.DataBindings.Clear();
                cmbFuelType.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                cmbCarNo.DataBindings.Clear();
                cmbCarType.DataBindings.Clear();
                txtRegisterName.DataBindings.Clear();
                txtRegisterTime.DataBindings.Clear();
                txtRegisterDate.DataBindings.Clear();
                cmbStoreName.DataBindings.Clear();
                DateBill.DataBindings.Clear();

                CLS_FRMS.CLS_FUEL ShowDataFuel = new CLS_FRMS.CLS_FUEL();
                ShowDataFuel.SelectFuelEntry();
                DataTable Dt = ShowDataFuel.SelectFuelEntry();
                DgvFuelEntry.DataSource = Dt;
                DgvFuelEntry.Columns[0].Visible = false;
                DgvFuelEntry.Columns[1].HeaderText = "رقم الفاتورة";
                DgvFuelEntry.Columns[2].HeaderText = "تاريخ الفاتورة";
                DgvFuelEntry.Columns[3].HeaderText = "نوع الوقود";
                DgvFuelEntry.Columns[4].HeaderText = "اسم المخزن";
                DgvFuelEntry.Columns[5].HeaderText = "السعة";
                DgvFuelEntry.Columns[6].HeaderText = "رقم السيارة";
                DgvFuelEntry.Columns[7].HeaderText = "نوع السيارة";
                DgvFuelEntry.Columns[8].Visible = false;
                DgvFuelEntry.Columns[9].Visible = false;
                DgvFuelEntry.Columns[10].Visible = false;



                txtID.DataBindings.Add("text", Dt, "IDfuelEntry");
                txtBillNo.DataBindings.Add("text", Dt, "BillNo");
                DateBill.DataBindings.Add("text", Dt, "BillDate");
                cmbFuelType.DataBindings.Add("text", Dt, "FuelType");
                cmbStoreName.DataBindings.Add("text", Dt, "StoreName");
                cmbStoreName.SelectedIndex = cmbStoreName.FindStringExact(cmbStoreName.Text);
                txtQuantity.DataBindings.Add("text", Dt, "Quantity");
                cmbCarNo.DataBindings.Add("text", Dt, "CarNO");
                cmbCarType.DataBindings.Add("text", Dt, "CarType");
                txtRegisterName.DataBindings.Add("text", Dt, "RegisterName");
                txtRegisterTime.DataBindings.Add("text", Dt, "AddingTime");
                txtRegisterDate.DataBindings.Add("text", Dt, "AddingDate");
                txtID.Visible = false;
                return Dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                DataTable dt=null;
                return dt;
            }
        }

        //-------------------------------------------------------------------
        //show data in datagridview exit data
        public DataTable showFuelExitData(DataGridView DgvExitFuel,TextBox txtExitID,TextBox txtBillExitNo,DateTimePicker dteExitBill,
            System.Windows.Forms.ComboBox cmbExitCarNo, System.Windows.Forms.ComboBox cmbExitCarType,TextBox txtExitQuantity,TextBox txtDriveName, System.Windows.Forms.ComboBox cmbExitTheBeneficiary, System.Windows.Forms.CheckBox DeptInvest,
            System.Windows.Forms.ComboBox cmbExitStoreName,TextBox txtExitRegisterName,TextBox txtExitRegisterTime,TextBox txtExitRegisterDate,TextBox txtPrice,TextBox txtTotalPrice)
        {
            try
            {
                DgvExitFuel.DataSource = null;
                txtExitID.DataBindings.Clear();
                txtBillExitNo.DataBindings.Clear();
                dteExitBill.DataBindings.Clear();
                cmbExitCarNo.DataBindings.Clear();
                cmbExitCarType.DataBindings.Clear();
                txtExitQuantity.DataBindings.Clear();
                txtDriveName.DataBindings.Clear();
                cmbExitTheBeneficiary.DataBindings.Clear();
                DeptInvest.DataBindings.Clear();
                cmbExitStoreName.DataBindings.Clear();
                txtExitRegisterName.DataBindings.Clear();
                txtExitRegisterTime.DataBindings.Clear();
                txtExitRegisterDate.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtTotalPrice.DataBindings.Clear();

                CLS_FRMS.CLS_FUEL ShowDataFuel = new CLS_FRMS.CLS_FUEL();
                ShowDataFuel.SelectFuelExit();
                DataTable Dt = ShowDataFuel.SelectFuelExit();
                DgvExitFuel.DataSource = Dt;
                DgvExitFuel.Columns[0].Visible = false;
                DgvExitFuel.Columns[1].HeaderText = "رقم الفاتورة";
                DgvExitFuel.Columns[2].HeaderText = "تاريخ الفاتورة";
                DgvExitFuel.Columns[3].HeaderText = "رقم السيارة";
                DgvExitFuel.Columns[4].HeaderText = "نوع السيارة";
                DgvExitFuel.Columns[5].HeaderText = "السعة";
                DgvExitFuel.Columns[6].HeaderText = "اسم السائق";
                DgvExitFuel.Columns[7].HeaderText = "الجهو المستفيدة";
                DgvExitFuel.Columns[8].HeaderText = "اسم المخزن";
                DgvExitFuel.Columns[9].Visible = false;
                DgvExitFuel.Columns[10].Visible = false;
                DgvExitFuel.Columns[11].Visible = false;
                DgvExitFuel.Columns[12].Visible = false;
                DgvExitFuel.Columns[13].HeaderText = "المبلغ بدون اضافات";
                DgvExitFuel.Columns[14].HeaderText = "المبلغ الكلي";
                txtExitID.DataBindings.Add("text", Dt, "IDFuelSelling");
                txtBillExitNo.DataBindings.Add("text", Dt, "BillNO");
                dteExitBill.DataBindings.Add("text", Dt, "BillDate");
                cmbExitCarNo.DataBindings.Add("text", Dt, "CarNO");
                cmbExitCarType.DataBindings.Add("text", Dt, "CarType");
                txtExitQuantity.DataBindings.Add("text", Dt, "Quantity");
                txtDriveName.DataBindings.Add("text", Dt, "DriverName");
                cmbExitTheBeneficiary.DataBindings.Add("text", Dt, "TheBeneficiary");
                cmbExitTheBeneficiary.SelectedIndex = cmbExitTheBeneficiary.FindStringExact(cmbExitTheBeneficiary.Text);
                if (cmbExitTheBeneficiary.SelectedValue.ToString() == "True")
                    DeptInvest.Checked = true;
                else
                    DeptInvest.Checked = false;
                cmbExitStoreName.DataBindings.Add("text", Dt, "StoreName");
                cmbExitStoreName.SelectedIndex = cmbExitStoreName.FindStringExact(cmbExitStoreName.Text);
                txtExitRegisterName.DataBindings.Add("text", Dt, "RegisterName");
                txtExitRegisterTime.DataBindings.Add("text", Dt, "AddingTime");
                txtExitRegisterDate.DataBindings.Add("text", Dt, "AddingDate");
                txtPrice.DataBindings.Add("text",Dt,"price");
                txtTotalPrice.DataBindings.Add("text",Dt,"totalprice");
                txtExitID.Visible = false;
                return Dt;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                DataTable dt = null;
                return dt;
            }
        }

        //------------------------------------------------------------------------
        //serach car type by car Number   
        public void caarInfo(System.Windows.Forms.ComboBox cmb, System.Windows.Forms.ComboBox cartype)
        {
            CLS_FRMS.CLSCARS GetCars = new CLS_FRMS.CLSCARS();
            DataTable dtCar = GetCars.CarDivisionGetDate();
            cmb.DataSource = dtCar;
            cmb.DisplayMember = "رقم العجلة";
            cmb.ValueMember = "نوع العجلة";
            cartype.DataSource = dtCar;
            cartype.DisplayMember = "نوع العجلة";
        }

        //----------------------------------------------------------------------
        //add stores info to combobox
        public void StoreInfo(System.Windows.Forms.ComboBox cmb)
        {
            DataTable dtCar = SelectStores();
            cmb.DataSource = dtCar;
            cmb.DisplayMember = "StoreName";
            cmb.ValueMember = "IDst";            
        }

        //---------------------------------------------------------------------
        //select archive for fuel bill entray
        public DataTable selectFuelArchive(int idcon, TextBox txtArchiveID, TextBox txtImagePath,TextBox txtRegistername,TextBox txtAddingTime,TextBox txtAddingDate, ListView lsv)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                       param[0].Value = idcon;
            dal.open();
            DataTable Dt = dal.SelectingData("fuelArchieveSelecting", param);
            dal.close();
           
            txtArchiveID.DataBindings.Clear();
            txtImagePath.DataBindings.Clear();
            txtRegistername.DataBindings.Clear();
            txtAddingDate.DataBindings.Clear();
            txtAddingTime.DataBindings.Clear();

            txtArchiveID.DataBindings.Add("text", Dt, "IDFeuelArchive");
            txtImagePath.DataBindings.Add("text",Dt,"ImagePath");
            txtRegistername.DataBindings.Add("text",Dt, "RegisterName");
            txtAddingTime.DataBindings.Add("text",Dt, "AddingTime");
            txtAddingDate.DataBindings.Add("text",Dt, "AddingDate");

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(250, 250);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                imageListLarge.Images.Add(Bitmap.FromFile(Dt.Rows[i][3].ToString()));
                
            }
            lsv.Items.Clear();
            lsv.LargeImageList = imageListLarge;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                lsv.Items.Add(Dt.Rows[i][3].ToString(), i);
            }

            lsv.View = View.LargeIcon;
            return Dt;
        }

        //get data from image archive
        public DataTable GetDataByListView(string path,TextBox txtArchiveID, TextBox txtRegistername, TextBox txtAddingTime, TextBox txtAddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Path", SqlDbType.Text); param[0].Value = path;
            dal.open();
            DataTable Dt = dal.SelectingData("fuelArchieveSelectingByPath", param);
            dal.close();

            txtArchiveID.DataBindings.Clear();
            txtRegistername.DataBindings.Clear();
            txtAddingDate.DataBindings.Clear();
            txtAddingTime.DataBindings.Clear();

            txtArchiveID.DataBindings.Add("text",Dt, "IDFeuelArchive");
            txtRegistername.DataBindings.Add("text", Dt, "RegisterName");
            txtAddingTime.DataBindings.Add("text", Dt, "AddingTime");
            txtAddingDate.DataBindings.Add("text", Dt, "AddingDate");
         
            return Dt;
        }

        //add archive to fuel bill
        public void addArchiveFuel(int txtconID, int BillNo, string path, string txtRegistername, string txtAddingTime, string txtAddingDate)
        {           
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                                    param[0].Value = txtconID;
            param[1] = new SqlParameter("@BillNo", SqlDbType.Int);                                   param[1].Value = BillNo;
            param[2] = new SqlParameter("@ImagePath", SqlDbType.Text);                               param[2].Value = path;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar,50);                      param[3].Value = txtRegistername;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);                       param[4].Value = txtAddingTime;
            param[5] = new SqlParameter("@AddingDate", SqlDbType.VarChar,50);                        param[5].Value = txtAddingDate;
            
            dal.open();
            dal.ExecuteCommand("FuelArchieveInsertInto", param);
            dal.close();
        }

        //delete archive from fuel archive bill
        public void deleteArchiveFuel(int IDFuelArchive)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDFuelID", SqlDbType.Int);                                 param[0].Value = IDFuelArchive;
            dal.open();
            dal.ExecuteCommand("FuelArchieveDeleting", param);
            dal.close();
        }

        //get data of departments
        public void BeneficiaryInfo(System.Windows.Forms.ComboBox cmb)
        {
            CLS_FRMS.CLSCONSTENTRY Getdata = new CLS_FRMS.CLSCONSTENTRY();
            DataTable dt = Getdata.GetDataDepartment();
            cmb.DataSource = dt;
            cmb.DisplayMember = "الاقسام والمواقع";
            cmb.ValueMember = "الجهات الاستثمارية";           
        }

        //--------------------------------------------------------------------
        //update data price fuel
        public void UpdatePrice(int idcon,double price,double percentageAdd,double PriceTransport,double priceTransporteInvest,string registername,string addtime,string adddate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter []param = new SqlParameter[8];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);
            param[0].Value = idcon;
            param[1] = new SqlParameter("@Price", SqlDbType.Real);
            param[1].Value = price;
            param[2] = new SqlParameter("@percentageAdd", SqlDbType.Real);
            param[2].Value = percentageAdd;
            param[3] = new SqlParameter("@PriceTransport", SqlDbType.Real);
            param[3].Value = PriceTransport;
            param[4] = new SqlParameter("@priceTransporteInvest", SqlDbType.Real);
            param[4].Value = priceTransporteInvest;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50);
            param[5].Value = registername;
            param[6] = new SqlParameter("@addingtime", SqlDbType.VarChar,50);
            param[6].Value = addtime;
            param[7] = new SqlParameter("@addingdate", SqlDbType.VarChar,50);
            param[7].Value = adddate;
            dal.open();
            dal.ExecuteCommand("FuelPriceUpdate", param);
            dal.close();
        }

        //select data from fuel price
        public DataTable GetDataPrice(int id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int); param[0].Value = id;
            dal.open();
            DataTable Dt = dal.SelectingData("FuelPriceSelecting", param);
            dal.close();
            return Dt;
        }

       
    }
}
