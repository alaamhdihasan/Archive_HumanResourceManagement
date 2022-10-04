using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;



namespace MechanismsCD.CLS_FRMS
{
    class CLSRPCARSOPERATIONS
    {
        //=====This Function For Content Of Report Form to the CarsMovements Table===================================================================
        public void ContentCarNoBetween(DataGridView dgv, ComboBox rpcm1, ComboBox rpcm2, ComboBox rpcm3, ComboBox rpcm4, ComboBox rpcm5, ComboBox rpcm6
            , ComboBox rpcm7, DateTimePicker rpcm8, DateTimePicker rpcm9, ComboBox rpcmsearching, TextBox rpcmsearching2, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6
            , Label lb7, Label lb8, Label lb9, DevExpress.XtraEditors.SimpleButton btnpreview, DevExpress.XtraEditors.SimpleButton btnprint)
        {
            dgv.Visible = true; rpcm1.Visible = true; rpcm2.Visible = true; rpcm3.Visible = true; rpcm4.Visible = true; rpcm5.Visible = true; rpcm6.Visible = true;
            rpcm7.Visible = true; rpcm8.Visible = true; rpcm9.Visible = true; rpcmsearching.Visible = true; rpcmsearching2.Visible = true;
            btnpreview.Visible = true; btnprint.Visible = true;
            lb1.Text = "رقم العجلة"; lb1.Visible = true; lb2.Text = "نوع العجلة"; lb2.Visible = true; lb3.Text = "اسم السائق"; lb3.Visible = true;
            lb4.Text = "الحالة"; lb4.Visible = true; lb5.Text = "الجهة المقصودة"; lb5.Visible = true; lb6.Text = "الجهة المستفيدة"; lb6.Visible = true;
            lb7.Text = "المستفيد"; lb7.Visible = true; lb8.Text = "من تاريخ"; lb8.Visible = true; lb9.Text = "الى تاريخ"; lb9.Visible = true;

            CLSCONSTENTRY getdata = new CLSCONSTENTRY();
            DataTable Dtdepartments = getdata.GetDataDepartment();
            rpcm6.DataBindings.Clear();
            rpcm6.DataSource = Dtdepartments;
            rpcm6.DisplayMember = "الاقسام والمواقع";
            rpcm6.Text = "ادخل الجهة المستفيدة";

            DataTable Dtdistenation = getdata.DistenationSelecting();
            rpcm5.DataBindings.Clear();
            rpcm5.DataSource = Dtdistenation;
            rpcm5.DisplayMember = "الجهة المقصودة";
            rpcm5.Text = "ادخل الجهة المقصودة";

            DataTable Dtthetype = getdata.TheTypeselection();
            rpcm4.DataBindings.Clear();
            rpcm4.DataSource = Dtthetype;
            rpcm4.DisplayMember = "الحالة";
            rpcm4.Text = "ادخل الحالة";

            DataTable DtCustomerName = getdata.TheCustomerSelection();
            rpcm7.DataBindings.Clear();
            rpcm7.DataSource = DtCustomerName;
            rpcm7.DisplayMember = "اسم المستفيد";
            rpcm7.Text = "ادخل اسم المستفيد";

            CLSCARS getdatacar = new CLSCARS();
            DataTable DtCarNO = getdatacar.CarDivisionGetDate();
            rpcm1.DataBindings.Clear();
            rpcm2.DataBindings.Clear();
            rpcm1.DataSource = DtCarNO;
            rpcm1.DisplayMember = "رقم العجلة";
            rpcm1.Text = "ادخل رقم العجلة";
            rpcm2.DataSource = DtCarNO;
            rpcm2.DisplayMember = "نوع العجلة";

            rpcmsearching.Items.Clear();
            string[] param = new string[18];
            param[0] = "رقم عجلة"; param[1] = "نوع العجلة"; param[2] = "اسم السائق"; param[3] = "الجهة المستفيدة"; param[4] = "الجهة المقصودة";
            param[5] = "الحالة"; param[6] = "حالة وجهة مستفيدة"; param[7] = "حالة وجهة مقصودة"; param[8] = "حالة ورقم عجلة"; param[9] = "حالة واسم سائق";
            param[10] = "خلاصة الجهات المستفيدة"; param[11] = "خلاصة الجهات المقصودة"; param[12] = "خلاصة التناكر";
            param[13] = "ساعات عمل العجلات"; param[14] = "ساعات عمل السواق"; param[15] = "ساعات عمل عجلة"; param[16] = "ساعات عمل سائق";
            param[17] = "حركة بين تاريخين";
            rpcmsearching.Items.AddRange(param);


        }
        //=================================================================================================================================================

        //====== This code Below For Get Data From RPCM_CarNobetween Procedure ========================================================================

        public DataTable RpcmCarNo(DataGridView dgv, string rpcm1, string rpcm2, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@carno", SqlDbType.VarChar, 50);                           param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Cartype", SqlDbType.VarChar, 50);                         param[1].Value = rpcm2;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[2].Value = rpcm8;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[3].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_CarNoBetween", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //========================================================================================================
        //========== This Function Below for Build A DataGridView For RPCM_CarNOBetween Procedure ================
        public void DgvCarNOBetween(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;
            if (dt.Columns.Count == 16)
            {
                dgv.Columns[0].HeaderText = "رقم العجلة";
                dgv.Columns[1].HeaderText = "نوع العجلة";
                dgv.Columns[2].HeaderText = "وقت وتاريخ الخروج";
                dgv.Columns[3].HeaderText = "اسم السائق1";
                dgv.Columns[4].HeaderText = "وقت وتاريخ العودة";
                dgv.Columns[5].HeaderText = "اسم السائق2";
                dgv.Columns[6].HeaderText = "الحالة";
                dgv.Columns[7].HeaderText = "المستفيد";
                dgv.Columns[8].HeaderText = "الجهة المقصودة";
                dgv.Columns[9].HeaderText = "الجهة المستفيدة";
                dgv.Columns[10].Visible = false;
                dgv.Columns[11].HeaderText = "عدد النقلات";
                dgv.Columns[12].HeaderText = "نوع الماء";
                dgv.Columns[13].Visible = false;
                dgv.Columns[14].HeaderText = "التخريج";
                dgv.Columns[15].HeaderText = "التعويد";
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            else
            {
                dgv.Columns[0].HeaderText = "رقم العجلة";
                dgv.Columns[1].HeaderText = "نوع العجلة";
                dgv.Columns[2].HeaderText = "وقت وتاريخ الخروج";
                dgv.Columns[3].HeaderText = "اسم السائق1";
                dgv.Columns[4].HeaderText = "وقت وتاريخ العودة";
                dgv.Columns[5].HeaderText = "اسم السائق2";
                dgv.Columns[6].HeaderText = "الحالة";
                dgv.Columns[7].HeaderText = "المستفيد";
                dgv.Columns[8].HeaderText = "الجهة المقصودة";
                dgv.Columns[9].HeaderText = "الجهة المستفيدة"; 
                dgv.Columns[10].Visible = false;
                dgv.Columns[11].Visible = false;
                dgv.Columns[12].HeaderText = "التخريج";
                dgv.Columns[13].HeaderText = "التعويد";
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }

        }
        //==============================================================================================================================================
        //============This Function For RPCM_MovementsBetween Procedure =================================================================================
        public DataTable RpcmBetweenTowDate(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_MovementsBetween", param);
            dal.close();
            dgv.DataSource = null;

            DgvMovementBetween(dgv, Dt);

            return Dt;
        }
        //==================================================================================================
        //==========This Function Below For a Build DataGridview For RPCM_MovementsBetween==================
        public void DgvMovementBetween(DataGridView dgv, DataTable dt)
        {
            dgv.DataSource = dt;
           
                dgv.Columns[0].HeaderText = "رقم العجلة";
                dgv.Columns[1].HeaderText = "نوع العجلة";
                dgv.Columns[2].HeaderText = "وقت وتاريخ الخروج";
                dgv.Columns[3].HeaderText = "اسم السائق1";
                dgv.Columns[4].HeaderText = "وقت وتاريخ العودة";
                dgv.Columns[5].HeaderText = "اسم السائق2";
                dgv.Columns[6].HeaderText = "الحالة";
                dgv.Columns[7].HeaderText = "المستفيد";
                dgv.Columns[8].HeaderText = "الجهة المقصودة";
                dgv.Columns[9].HeaderText = "الجهة المستفيدة";
                dgv.Columns[10].Visible = false;
                dgv.Columns[11].HeaderText = "عدد النقلات";
                dgv.Columns[12].HeaderText = "نوع الماء"; 
                dgv.Columns[13].Visible = false;
                dgv.Columns[14].HeaderText = "التخريج";
                dgv.Columns[15].HeaderText = "التعويد";
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        //===============================================================================================================================================
        //===========This function Below For RPCM_CarType Procedure =====================================================================================
        public DataTable RpcmCarType(DataGridView dgv,string rpcm2, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);             param[0].Value = rpcm2;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);               param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);               param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_CarType", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //==============================================================================================================================================
        //==========This Function Below For RPCM_Distenation Procedure =================================================================================
        public DataTable RpcmDistenation(DataGridView dgv, string rpcm5, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);                 param[0].Value = rpcm5;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_Distenation", param);
            dal.close();
            dgv.DataSource = null;

            DgvMovementBetween(dgv, Dt);

            return Dt;
        }
        //==============================================================================================================================================
        //=========== This Function below For RPCM_DriveName Procedure ================================================================================
        public DataTable RpcmDriverName(DataGridView dgv, string rpcm3, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@DriverName", SqlDbType.VarChar, 50);                  param[0].Value = rpcm3;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_DriverName", param);
            dal.close();
            dgv.DataSource = null;

            DgvMovementBetween(dgv, Dt);

            return Dt;
        }
        //=============================================================================================================================================
        //==========This Function Below for RPCM_Beneficiary Procedure ================================================================================
        public DataTable RpcmBeneficiary(DataGridView dgv, string rpcm6, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);                     param[0].Value = rpcm6;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheBeneficiary", param);
            dal.close();
            dgv.DataSource = null;

            DgvMovementBetween(dgv, Dt);

            return Dt;
        }
        //===============================================================================================================================================
        //========This Function Below For RPCM_Thetype Procedure=========================================================================================
        public DataTable RpcmTheType(DataGridView dgv, string rpcm4, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);                         param[0].Value = rpcm4;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheType", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //===============================================================================================================================================
        //========This Function Below for RPCM_Thetypeandbeneficiary Procedure ==========================================================================
        public DataTable RpcmTheTypeAndBeneficiary(DataGridView dgv, string rpcm6,string rpcm4, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@beneficiary", SqlDbType.VarChar, 50);                     param[0].Value = rpcm6;
            param[1] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);                         param[1].Value = rpcm4;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[2].Value = rpcm8;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[3].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheTypeAndBeneficiary", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //================================================================================================================================================
        //=========This Function Below For RPCM_TheTypeAndCar Procedure ==================================================================================
        public DataTable RpcmTheTypeAndCar(DataGridView dgv, string rpcm1, string rpcm4, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                           param[0].Value = rpcm1;
            param[1] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);                         param[1].Value = rpcm4;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[2].Value = rpcm8;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[3].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheTypeAndCar", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //================================================================================================================================================
        //========This Function Below For the RPCM_TheTypeandDistenation Procefure=======================================================================
        public DataTable RpcmTheTypeAndDistenation(DataGridView dgv, string rpcm5, string rpcm4, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);                     param[0].Value = rpcm5;
            param[1] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);                         param[1].Value = rpcm4;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[2].Value = rpcm8;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[3].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheTypeAndDistenation", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //================================================================================================================================================
        //========This function For the RPCM_TheTypeAndDrivername Procedure ===============================================================================
        public DataTable RpcmTheTypeAndDrivername(DataGridView dgv, string rpcm3, string rpcm4, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Drivername", SqlDbType.VarChar, 50);                      param[0].Value = rpcm3;
            param[1] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);                         param[1].Value = rpcm4;
            param[2] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[2].Value = rpcm8;
            param[3] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[3].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_TheTypeAndDrivername", param);
            dal.close();
            dgv.DataSource = null;

            DgvCarNOBetween(dgv, Dt);

            return Dt;
        }
        //=================================================================================================================================================
        //=======This function Bleow For RPCM_SummaryBeneficiary Procedure ===============================================================================
        public DataTable RpcmSummaryBeneficiary(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date" +
                "" +
                "1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_SummaryofBeneficiary", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "القسم المستفيد";
            dgv.Columns[1].HeaderText = "عدد الحركات";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            return Dt;
        }
        //==================================================================================================================================================
        //====== This Function Below For The RPCM_SummaryDistenation Procedure ============================================================================
        public DataTable RpcmSummarydistenation(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_SummaryofDistenation", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "الجهة المقصودة";
            dgv.Columns[1].HeaderText = "عدد الحركات";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            return Dt;
        }
        //================================================================================================================================================
        //======== This Function below for the RPCM_SummaryTankers Procedure =============================================================================
        public DataTable RpcmSummaryTankers(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_SummaryTankers", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "الجهة المستفيدة";
            dgv.Columns[1].HeaderText = "نوع المياه";
            dgv.Columns[2].HeaderText = "مجموع النقلات";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //=================================================================================================================================================
        //====== This Function Below For The RPCM_CarHour Procedure ======================================================================================
        public DataTable RpcmCarHour(DataGridView dgv,string rpcm1, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);                       param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_CarsHours", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة";
            dgv.Columns[2].HeaderText = "اسم السائق";
            dgv.Columns[3].HeaderText = "وقت وتاريخ الخروج";
            dgv.Columns[4].HeaderText = "وقت وتاريخ العودة";
            dgv.Columns[5].HeaderText = "الحالة";
            dgv.Columns[6].HeaderText = "المدة الزمنية";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //================================================================================================================================================
        // ======= This Function Below For The RPCM_DriverHours Procedure ================================================================================
        public DataTable RpcmDriverHours(DataGridView dgv, string rpcm3, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Drivername", SqlDbType.VarChar, 50);                       param[0].Value = rpcm3;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                            param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                            param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_DriverHours", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "اسم السائق";
            dgv.Columns[1].HeaderText = "رقم العجلة";
            dgv.Columns[2].HeaderText = "نوع العجلة";
            dgv.Columns[3].HeaderText = "وقت وتاريخ الخروج";
            dgv.Columns[4].HeaderText = "وقت وتاريخ العودة";
            dgv.Columns[5].HeaderText = "الحالة";
            dgv.Columns[6].HeaderText = "المدة الزمنية";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //===============================================================================================================================================
        //====== This Function Below For the RPCM_SummaryCarsHours Procedure=============================================================================
        public DataTable RpcmSummaryCarsHours(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_SummaryCarsHours", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة";
            dgv.Columns[2].HeaderText = "عدد الحركات";
            dgv.Columns[3].HeaderText = "مجموع الساعات";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //===============================================================================================================================================
        //====== This Function Below For the RPCM_SummaryDriverHours Procedure ==========================================================================
        public DataTable RpcmSummaryDriversHours(DataGridView dgv, string rpcm8, string rpcm9)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                   param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                   param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCM_SummaryDriverHours", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "اسم السائق";
            dgv.Columns[1].HeaderText = "عدد الحركات";
            dgv.Columns[2].HeaderText = "مجموع الساعات";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //=================================================================================================================================================
        //=================================================================================================================================================
        //=================================================================================================================================================
        //=====This Function For Content Of Report Form to the CarsFuel Table =============================================================================
        public void ContentCarFuels(DataGridView dgv, ComboBox rpcm1,ComboBox rpcm2, DateTimePicker rpcm8, DateTimePicker rpcm9, ComboBox rpcmsearching1, TextBox rpcmsearching2
             , Label lb1,Label lb2, Label lb8, Label lb9, DevExpress.XtraEditors.SimpleButton btnpreview, DevExpress.XtraEditors.SimpleButton btnprint)
        {
            rpcm1.Visible = true;rpcm2.Visible = true;rpcm8.Visible = true;rpcm9.Visible = true;
            lb1.Text = "رقم العجلة";lb1.Visible = true;lb2.Text = "نوع العجلة";lb2.Visible = true;lb8.Text = "من تاريخ";lb8.Visible = true;
            lb9.Text = "الى تاريخ";lb9.Visible = true;rpcmsearching1.Visible = true;rpcmsearching2.Visible = true;btnpreview.Visible = true;btnprint.Visible = true;
            dgv.Visible = true;

            CLSCARS getdatacar = new CLSCARS();
            DataTable DtCarNO = getdatacar.CarDivisionGetDate();
            rpcm1.DataBindings.Clear();
            rpcm2.DataBindings.Clear();
            rpcm1.DataSource = DtCarNO;
            rpcm1.DisplayMember = "رقم العجلة";
            rpcm1.Text = "ادخل رقم العجلة";
            rpcm2.DataSource = DtCarNO;
            rpcm2.DisplayMember = "نوع العجلة";
            
            rpcmsearching1.Items.Clear();
            string[] param = new string[4];
            param[0] = "عجلة بين تاريخين";param[1] = "بين تاريخين";param[2] = "اجمالي عجلات";param[3] = "اجمالي عجلة";
            rpcmsearching1.Items.AddRange(param);
         }
        //============================================================================
        //============= This Function Below For The RPCF_CarNoBetween Tow Date  Procedure /Using the CarsFuel Table =================================
        public DataTable rpcfCarNoBetween(DataGridView dgv,string rpcm1,string rpcm8,string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                   param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                   param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                   param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("PRCF_SummaryCarNo", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "اليوم";
            dgv.Columns[3].HeaderText = "التاريخ";
            dgv.Columns[4].HeaderText = "رقم الفاتورة";
            dgv.Columns[5].HeaderText = "تاريخ الفاتورة";
            dgv.Columns[6].HeaderText = "الكمية / لتر";
            dgv.Columns[7].HeaderText = "مبلغ الفاتورة / دينار";
            dgv.Columns[8].HeaderText = "مدخل البيانات";
            dgv.Columns[9].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //============================================================================================================================================
        //=== This Function below for the RpcF_CarNobetweenTowDate using by the stored procedure PRCF_CarNoBewtweenTowDate....
        public DataTable rpcfCarNoBetweentowDate(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                   param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                   param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                   param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("PRCF_CarNOBetweenTowDate", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "اليوم";
            dgv.Columns[3].HeaderText = "التاريخ";
            dgv.Columns[4].HeaderText = "رقم الفاتورة";
            dgv.Columns[5].HeaderText = "تاريخ الفاتورة";
            dgv.Columns[6].HeaderText = "الكمية / لتر";
            dgv.Columns[7].HeaderText = "مبلغ الفاتورة / دينار";
            dgv.Columns[8].HeaderText = "مدخل البيانات";
            dgv.Columns[9].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }



        //==============================================================================================================================================
        //============ This function Below For the RPCF_BetweenTowDate Procedure /Using the CarsFuel table ===========================================
        public DataTable rpcfbetweentowdate(DataGridView dgv, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("PRCF_BetweenTowDate", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "اليوم";
            dgv.Columns[3].HeaderText = "التاريخ";
            dgv.Columns[4].HeaderText = "رقم الفاتورة";
            dgv.Columns[5].HeaderText = "تاريخ الفاتورة";
            dgv.Columns[6].HeaderText = "الكمية / لتر";
            dgv.Columns[7].HeaderText = "مبلغ الفاتورة / دينار";
            dgv.Columns[8].HeaderText = "مدخل البيانات";
            dgv.Columns[9].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //=============================================================================================================================================
        //========= This Function Below For RPCF_SUMMARY Procedure / Using The CarsFuel Table ======================================================
        public DataTable rpcfSummaryFuel(DataGridView dgv, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("PRCF_Summary", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "الكمية / لتر";
            dgv.Columns[3].HeaderText = "المبلغ / دينار";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //================================================================================================================================================
        //====== This Function Below For RPCF_SummaryCarNo Procedure / Using the CarsFuel Table ========================================================
        public DataTable rpcfSummaryCarNo(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                           param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("PRCF_SummaryCarNo", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "الكمية / لتر";
            dgv.Columns[3].HeaderText = "المبلغ / دينار";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //===============================================================================================================================================
        //===============================================================================================================================================
        //===============================================================================================================================================
        //============= This Function Below for Build the Form of Report of CarsAccident ===============================================================
        public void ContentCarAccident(DataGridView dgv, ComboBox rpcm1, ComboBox rpcm2, DateTimePicker rpcm8, DateTimePicker rpcm9, ComboBox rpcmsearching1, TextBox rpcmsearching2
             , Label lb1, Label lb2, Label lb8, Label lb9, DevExpress.XtraEditors.SimpleButton btnpreview, DevExpress.XtraEditors.SimpleButton btnprint)
        {
            rpcm1.Visible = true; rpcm2.Visible = true; rpcm8.Visible = true; rpcm9.Visible = true;
            lb1.Text = "رقم العجلة"; lb1.Visible = true; lb2.Text = "نوع العجلة"; lb2.Visible = true; lb8.Text = "من تاريخ"; lb8.Visible = true;
            lb9.Text = "الى تاريخ"; lb9.Visible = true; rpcmsearching1.Visible = true; rpcmsearching2.Visible = true; btnpreview.Visible = true; btnprint.Visible = true;
            dgv.Visible = true;

            CLSCARS getdatacar = new CLSCARS();
            DataTable DtCarNO = getdatacar.CarDivisionGetDate();
            rpcm1.DataBindings.Clear();
            rpcm2.DataBindings.Clear();
            rpcm1.DataSource = DtCarNO;
            rpcm1.DisplayMember = "رقم العجلة";
            rpcm1.Text = "ادخل رقم العجلة";
            rpcm2.DataSource = DtCarNO;
            rpcm2.DisplayMember = "نوع العجلة";

            rpcmsearching1.Items.Clear();
            string[] param = new string[2];
            param[0] = "عجلة بين تاريخين"; param[1] = "بين تاريخين";
            rpcmsearching1.Items.AddRange(param);
        }
        //===============================================================================================================================================
        //=========== This Function Below For RPCA_BetweenTowDate Procedure / Using CarsAccidents Table  =======================================
        public DataTable rpcabetweentowdate(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCA_BetweenTowDate", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "يوم الحادث";
            dgv.Columns[3].HeaderText = "تاريخ الحادث";
            dgv.Columns[4].HeaderText = "ملاحظات";
            dgv.Columns[5].HeaderText = "مدخل البيانات";
            dgv.Columns[6].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //==============================================================================================================================================
        //============== This Function Below for RPCA_CarNObetween Procedure / Using CasAccident Table =================================================
        public DataTable rpcaCarNO(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                           param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCA_CarNO", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "يوم الحادث";
            dgv.Columns[3].HeaderText = "تاريخ الحادث";
            dgv.Columns[4].HeaderText = "ملاحظات";
            dgv.Columns[5].HeaderText = "مدخل البيانات";
            dgv.Columns[6].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //============================================================================================================================================
        //=============================================================================================================================================
        //=============================================================================================================================================
        //==================This Function Below For build A form of Report Of Carsitutions Table =======================================================
        public void ContentCarSituation(DataGridView dgv, ComboBox rpcm1, ComboBox rpcm2, DateTimePicker rpcm8, DateTimePicker rpcm9, ComboBox rpcmsearching1
            , TextBox rpcmsearching2, Label lb1, Label lb2, Label lb8, Label lb9, DevExpress.XtraEditors.SimpleButton btnpreview,
             DevExpress.XtraEditors.SimpleButton btnprint)
        {
            rpcm1.Visible = true; rpcm2.Visible = true; rpcm8.Visible = true; rpcm9.Visible = true;
            lb1.Text = "رقم العجلة"; lb1.Visible = true; lb2.Text = "نوع العجلة"; lb2.Visible = true; lb8.Text = "من تاريخ"; lb8.Visible = true;
            lb9.Text = "الى تاريخ"; lb9.Visible = true; rpcmsearching1.Visible = true; rpcmsearching2.Visible = true; btnpreview.Visible = true; btnprint.Visible = true;
            dgv.Visible = true;

            CLSCARS getdatacar = new CLSCARS();
            DataTable DtCarNO = getdatacar.CarDivisionGetDate();
            rpcm1.DataBindings.Clear();
            rpcm2.DataBindings.Clear();
            rpcm1.DataSource = DtCarNO;
            rpcm1.DisplayMember = "رقم العجلة";
            rpcm1.Text = "ادخل رقم العجلة";
            rpcm2.DataSource = DtCarNO;
            rpcm2.DisplayMember = "نوع العجلة";

            rpcmsearching1.Items.Clear();
            string[] param = new string[2];
            param[0] = "عجلة بين تاريخين"; param[1] = "بين تاريخين";
            rpcmsearching1.Items.AddRange(param);
        }
        ///============================================================================================================================================
        /////==================== This function Below For RPCS_BetweenTowDate Procedure / using Carsituation Table =============================
        public DataTable rpcsbetweentowdate(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                                       param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                                       param[1].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCS_BetweenTowDate", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "موقف العجلة";
            dgv.Columns[3].HeaderText = "الجهة المستفيدة";
            dgv.Columns[4].HeaderText = "من تاريخ";
            dgv.Columns[5].HeaderText = "الى تاريخ";
            dgv.Columns[6].HeaderText = "مدخل البيانات";
            dgv.Columns[7].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //=============================================================================================================================================
        public DataTable rpcsCarNObetweentowdate(DataGridView dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                           param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[2].Value = rpcm9;
            dal.open();
            DataTable Dt = dal.SelectingData("RPCS_CarNOBetweentowdate", param);
            dal.close();
            dgv.DataSource = null;

            dgv.DataSource = Dt;
            dgv.Columns[0].HeaderText = "رقم العجلة";
            dgv.Columns[1].HeaderText = "نوع العجلة ";
            dgv.Columns[2].HeaderText = "موقف العجلة";
            dgv.Columns[3].HeaderText = "الجهة المستفيدة";
            dgv.Columns[4].HeaderText = "من تاريخ";
            dgv.Columns[5].HeaderText = "الى تاريخ";
            dgv.Columns[6].HeaderText = "مدخل البيانات";
            dgv.Columns[7].HeaderText = "تاريخ الادخال";
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;

        }
        //===================================================================================================================================================
        //===================================================================================================================================================
        //=================================================================================================================================================
        //=========== This Function Below For Build The Form Of Report Of CarsCounters 
        public void ContentCarsCounters(DataGridView dgv, ComboBox rpcm1, ComboBox rpcm2,ComboBox rpcm3,ComboBox rpcm4,ComboBox rpcm5
            , DateTimePicker rpcm8, DateTimePicker rpcm9, ComboBox rpcmsearching1, TextBox rpcmsearching2
            , Label lb1, Label lb2,Label lb3,Label lb4,Label lb5, Label lb8, Label lb9, DevExpress.XtraEditors.SimpleButton btnpreview,
           DevExpress.XtraEditors.SimpleButton btnprint)
        {
            rpcm1.Visible = true;rpcm2.Visible = true;rpcm3.Visible = true; rpcm4.Visible = true;rpcm5.Visible = true;rpcm8.Visible = true;rpcm9.Visible = true;
            lb1.Text = "رقم العجلة";lb1.Visible = true;lb2.Text = "نوع العجلة";lb2.Visible = true;lb3.Text = "العملية";lb3.Visible = true;
            lb4.Text = "القيمة الاولى";lb4.Visible = true;lb5.Text = "القيمة الثانية";lb5.Visible = true;lb8.Text = "من";lb8.Visible = true;
            lb9.Text = "الى";lb9.Visible = true;dgv.Visible = true;rpcmsearching1.Visible = true;rpcmsearching2.Visible = true;
            btnpreview.Visible = true;btnprint.Visible = true;

            CLSCARS getdatacar = new CLSCARS();
            DataTable DtCarNO = getdatacar.CarDivisionGetDate();
            rpcm1.DataBindings.Clear();
            rpcm2.DataBindings.Clear();
            rpcm1.DataSource = DtCarNO;
            rpcm1.DisplayMember = "رقم العجلة";
            rpcm1.Text = "ادخل رقم العجلة";
            rpcm2.DataSource = DtCarNO;
            rpcm2.DisplayMember = "نوع العجلة";

            rpcmsearching1.Items.Clear();
            string[] param = new string[6];
            param[0] = "عدادات عجلة"; param[1] = "مسافة عجلة";param[2] = "مسافة عجلات"; param[3] = "مراقب زيت محرك عجلة";param[4] = "مراقب زيت عجلات";
            param[5] = "بحث في مراقب زيت العجلات";
            rpcmsearching1.Items.AddRange(param);

            rpcm3.Items.Clear();
            string[] sign = new string[6];
            sign[0] = ">=";sign[1] = "<=";sign[2] = "=";sign[3] = "<";sign[4] = ">";sign[5] = "Between";
            rpcm3.Items.AddRange(sign);
            rpcm4.Text = "0";
            rpcm5.Text = "0";
        }
        //============================================================================================================================================
        //======================This Function For RPCC_CarNOBetweenTowDate Procedure / Using CarsCounter Table =========================
        public DataTable RPCCcCarNoBetween(DataGridView Dgv,string rpcm1, string rpcm8,string rpcm9)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                       param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[2].Value = rpcm9;
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarNoBetweentowdate", param);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "اليوم";
            Dgv.Columns[3].HeaderText = "التاريخ";
            Dgv.Columns[4].HeaderText = "العداد";
            Dgv.Columns[5].HeaderText = "مدخل البيانات";
            Dgv.Columns[6].HeaderText = "تاريخ الادخال";
            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
             return Dt;

        }
        //==============================================================================================================================================
        //========================= This Function For RPCC_CarDistance Procedure / Using CarsCounter Table ======================================
        public DataTable RPCCcCarDistance(DataGridView Dgv, string rpcm1, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                       param[0].Value = rpcm1;
            param[1] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                       param[1].Value = rpcm8;
            param[2] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                       param[2].Value = rpcm9;
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarDistance", param);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "العداد الابتدائي";
            Dgv.Columns[3].HeaderText = "العداد النهائي";
            Dgv.Columns[4].HeaderText = "المسافة المقطوعة";
            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
          }
        //===============================================================================================================================================
        //=================This Function For RPCC_CarsDistance Procedure / Using CarsCounter Table ======================================================
        public DataTable RPCCcCarsDistance(DataGridView Dgv, string rpcm8, string rpcm9)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Date1", SqlDbType.VarChar, 50);                           param[0].Value = rpcm8;
            param[1] = new SqlParameter("@Date2", SqlDbType.VarChar, 50);                           param[1].Value = rpcm9;
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarsDistance", param);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "المسافة المقطوعة";
            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //===============================================================================================================================================
        //===================== This Function For RPCC_CarAdvisor Procedure / Using CarsAdvisor1 Table ============================================
        public DataTable RPCCcCarAdvisor(DataGridView Dgv,string rpcm1)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                            param[0].Value = rpcm1;
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarAdvisor", param);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "عداد تبديل الزيت";
            Dgv.Columns[3].HeaderText = "العداد الحالي";
            Dgv.Columns[4].HeaderText = "المسافة المقطوعة";

            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //=============================================================================================================================================
        //============ This Function For RPCC_CarAdvisor2 Procedure / Using CarsAdvisor1 Table ===========
        public DataTable RPCCcCarAdvisor2(DataGridView Dgv)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarAdvisor2", null);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "عداد تبديل الزيت";
            Dgv.Columns[3].HeaderText = "العداد الحالي";
            Dgv.Columns[4].HeaderText = "المسافة المقطوعة";

            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //==============================================================================================================================================
        //========= This Function For RPCC_CarAdvisor4 Procedure / Using CarsAdvisor1 Table ======================================
        public DataTable RPCCCaradvisor4(DataGridView Dgv, string rpcm3, string rpcm4, string rpcm5)
        {
            DAL.DataAccessLayer Dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Sign", SqlDbType.VarChar, 50);                    param[0].Value = rpcm3;
            param[1] = new SqlParameter("@QY", SqlDbType.VarChar, 50);                      param[1].Value = rpcm4;
            param[2] = new SqlParameter("@QY2", SqlDbType.VarChar, 50);                     param[2].Value = rpcm5;
            Dal.open();
            DataTable Dt = Dal.SelectingData("RPCC_CarAdvisor4", param);
            Dal.close();

            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            Dgv.Columns[0].HeaderText = "رقم العجلة";
            Dgv.Columns[1].HeaderText = "نوع العجلة";
            Dgv.Columns[2].HeaderText = "عداد تبديل الزيت";
            Dgv.Columns[3].HeaderText = "العداد الحالي";
            Dgv.Columns[4].HeaderText = "المسافة المقطوعة";
            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            return Dt;
        }
        //================================================================================================================================================
        //=============
    }

}
