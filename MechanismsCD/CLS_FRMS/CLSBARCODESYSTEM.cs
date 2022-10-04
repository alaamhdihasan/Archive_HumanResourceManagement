using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace MechanismsCD.CLS_FRMS
{
    
    class CLSBARCODESYSTEM
    {
        CurrencyManager cm;
        // -----GetData From BarcodeSystem (DivisionCar Table and CarsMovement Table)----------------------------------------------------------------
        public DataTable BarcodesystemGetdata(string CarNOsearching, DataGridView dgv, TextBox carno, ComboBox cartype, ComboBox brand, TextBox Carbarcode
            , TextBox carline, ComboBox distenation, ComboBox beneficiary, ComboBox thetype, TextBox carno2, TextBox cartype2
            , TextBox goingtimedate, TextBox drivename1, TextBox commingtimedate, TextBox drivername2, ComboBox thetype2
            , ComboBox Customername, ComboBox distenation2, ComboBox beneficiary2, RichTextBox notice, TextBox registername,TextBox registername2
            , TextBox Nowdate, TextBox tbseqmove,TextBox transcount,ComboBox watertype)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param= new SqlParameter[1];
            param[0] = new SqlParameter("@CarNOsearching", SqlDbType.VarChar, 50);              param[0].Value = CarNOsearching;
            dal.open();
            DataTable Dt = dal.SelectingData("BarcodeSystem", param);
            dal.close();

            dgv.DataSource = null;
            
            carno.DataBindings.Clear();cartype.DataBindings.Clear();brand.DataBindings.Clear();Carbarcode.DataBindings.Clear();
            carline.DataBindings.Clear();distenation.DataBindings.Clear();beneficiary.DataBindings.Clear(); thetype.DataBindings.Clear();
            carno2.DataBindings.Clear();cartype2.DataBindings.Clear();goingtimedate.DataBindings.Clear();drivename1.DataBindings.Clear();
            commingtimedate.DataBindings.Clear();drivername2.DataBindings.Clear();thetype2.DataBindings.Clear();Customername.DataBindings.Clear();
            distenation2.DataBindings.Clear();beneficiary2.DataBindings.Clear();notice.DataBindings.Clear();registername.DataBindings.Clear();
            registername2.DataBindings.Clear(); Nowdate.DataBindings.Clear();transcount.DataBindings.Clear();watertype.DataBindings.Clear();
            tbseqmove.DataBindings.Clear();
            
            dgv.DataSource = Dt;
            dgv.Columns[0].Visible = false;dgv.Columns[1].Visible = false;dgv.Columns[2].Visible = false;
            dgv.Columns[3].Visible = false;dgv.Columns[4].Visible = false;dgv.Columns[5].Visible = false;dgv.Columns[6].Visible = false;
            dgv.Columns[7].Visible = false;dgv.Columns[8].Visible = false;dgv.Columns[9].Visible = false;dgv.Columns[10].HeaderText = "وقت الخروج";
            dgv.Columns[11].HeaderText = "اسم السائق1";dgv.Columns[12].HeaderText = "وقت العودة";dgv.Columns[13].HeaderText = "اسم السائق2";
            dgv.Columns[14].HeaderText = "الحالة";dgv.Columns[15].HeaderText = "اسم المستفيد";dgv.Columns[16].HeaderText = "الجهة المقصودة";
            dgv.Columns[17].HeaderText = "الجهة المستفيدة";dgv.Columns[18].Visible = false;dgv.Columns[19].Visible = false;
            dgv.Columns[20].Visible = false;dgv.Columns[21].Visible = false;dgv.Columns[22].Visible = false;dgv.Columns[23].Visible = false;
            dgv.Columns[24].Visible = false;
            carno.DataBindings.Add("text", Dt, "CarNO");cartype.DataBindings.Add("text", Dt, "CarType");
            brand.DataBindings.Add("text", Dt, "TheBrand");Carbarcode.DataBindings.Add("text", Dt, "CarBarcode");
            carline.DataBindings.Add("text", Dt, "TransportName");distenation.DataBindings.Add("text", Dt, "distenation");
            beneficiary.DataBindings.Add("text", Dt, "Thebeneficiary");thetype.DataBindings.Add("text", Dt, "TheType");
            carno2.DataBindings.Add("text", Dt, "Carno2");cartype2.DataBindings.Add("text", Dt, "CarType2");
            goingtimedate.DataBindings.Add("text", Dt, "GoingTimeDate");drivename1.DataBindings.Add("Text", Dt, "DriverName1");
            commingtimedate.DataBindings.Add("Text", Dt, "CommingTimeDate");drivername2.DataBindings.Add("text", Dt, "DriverName2");
            thetype2.DataBindings.Add("text", Dt, "TheType2"); Customername.DataBindings.Add("text", Dt, "CustomerName");
            distenation2.DataBindings.Add("text", Dt, "Distenation2"); beneficiary2.DataBindings.Add("Text", Dt, "TheBeneficiary2");
            notice.DataBindings.Add("text", Dt, "Notice"); registername.DataBindings.Add("Text", Dt, "RegisterName");
            registername2.DataBindings.Add("text", Dt, "registername2");
            Nowdate.DataBindings.Add("text", Dt, "NowDate"); transcount.DataBindings.Add("text", Dt, "TransCount");
            watertype.DataBindings.Add("text", Dt, "TypeWater");tbseqmove.DataBindings.Add("text", Dt, "IDmove");
            
            return Dt;

        }

        // ------ Insert The Data in CarsMovements Table ---------------------------------------------------------------------------------------------
        public void CarsmovementsInsertData(string CarNO,string CarType,string GoingTimeDate,string DriverName1
            ,string CommingTimeDate,string DriverName2,string TheType,string CustomerName,string Distenation
            ,string Beneficiary,string Notice,string RegisterName,string Registername2,string NowDate,double transcount, string watertype)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);                   param[0].Value = CarNO;
            param[1] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[1].Value = CarType;
            param[2] = new SqlParameter("@GoingTimeDate", SqlDbType.VarChar, 50);           param[2].Value = GoingTimeDate;
            param[3] = new SqlParameter("@DriverName1", SqlDbType.VarChar,50);              param[3].Value = DriverName1;
            param[4] = new SqlParameter("@CommingTimeDate", SqlDbType.VarChar, 50);         param[4].Value = CommingTimeDate;
            param[5] = new SqlParameter("@DriverName2", SqlDbType.VarChar, 50);             param[5].Value = DriverName2;
            param[6] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);                 param[6].Value = TheType;
            param[7] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);            param[7].Value = CustomerName;
            param[8] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);             param[8].Value = Distenation;
            param[9] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);          param[9].Value = Beneficiary;
            param[10] = new SqlParameter("@Notice", SqlDbType.Text);                        param[10].Value = Notice;
            param[11] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);           param[11].Value = RegisterName;
            param[12] = new SqlParameter("@RegisterName2", SqlDbType.VarChar, 50);          param[12].Value = Registername2;
            param[13] = new SqlParameter("@NowDate", SqlDbType.VarChar, 50);                param[13].Value = NowDate;
            param[14] = new SqlParameter("@transcount", SqlDbType.Real);                    param[14].Value = transcount;
            param[15] = new SqlParameter("@watertype", SqlDbType.VarChar,50);               param[15].Value = watertype;
            dal.open();
            dal.ExecuteCommand("CarsMovementInsertInto", param);
            dal.close();
         }
        //--------Update Date In CarsMovements Table -------------------------------------------------------------------------------------------------------
        public void CarsMovementsUpdateDate(int IDMovement,string CarNO, string CarType, string GoingTimeDate, string DriverName1
            , string CommingTimeDate, string DriverName2, string TheType, string CustomerName, string Distenation
            , string Beneficiary, string Notice, string RegisterName,string RegisterName2, string NowDate, double transcount, string watertype)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@IDmove", SqlDbType.Int);                          param[0].Value = IDMovement;
            param[1] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);                   param[1].Value = CarNO;
            param[2] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                 param[2].Value = CarType;
            param[3] = new SqlParameter("@GoingTimeDate", SqlDbType.VarChar, 50);           param[3].Value = GoingTimeDate;
            param[4] = new SqlParameter("@DriverName1", SqlDbType.VarChar, 50);             param[4].Value = DriverName1;
            param[5] = new SqlParameter("@CommingTimeDate", SqlDbType.VarChar, 50);         param[5].Value = CommingTimeDate;
            param[6] = new SqlParameter("@DriverName2", SqlDbType.VarChar, 50);             param[6].Value = DriverName2;
            param[7] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);                 param[7].Value = TheType;
            param[8] = new SqlParameter("@CustomerName", SqlDbType.VarChar, 50);            param[8].Value = CustomerName;
            param[9] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);             param[9].Value = Distenation;
            param[10] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50);         param[10].Value = Beneficiary;
            param[11] = new SqlParameter("@Notice", SqlDbType.Text);                        param[11].Value = Notice;
            param[12] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);           param[12].Value = RegisterName;
            param[13] = new SqlParameter("@RegisterName2", SqlDbType.VarChar, 50);          param[13].Value = RegisterName2;
            param[14] = new SqlParameter("@NowDate", SqlDbType.VarChar, 50);                param[14].Value = NowDate;
            param[15] = new SqlParameter("@transcount", SqlDbType.Real);                    param[15].Value = transcount;
            param[16] = new SqlParameter("@watertype", SqlDbType.VarChar,50);               param[16].Value = watertype;
            dal.open();
            dal.ExecuteCommand("CarsMovementUPdate", param);
            dal.close();
        }
       //--------Delete From CarsMovements Table ---------------------------------------------------------------------------------------------------------
        public void CarsMovementDeletofing(int IDmove)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDmov", SqlDbType.Int);
            param[0].Value = IDmove;
            dal.open();
            dal.ExecuteCommand("CarsMovementsDeleting", param);
            dal.close();

        }


        // ------- Fill the Combobox in the CarMovements Interface---------------------------------------------------------------------------------------
        public void FillCboDate(ComboBox thetype,ComboBox customername, ComboBox distenation ,ComboBox beneficiary)
        {
            CLSCONSTENTRY Entrydata = new CLSCONSTENTRY();

            DataTable DtDepartment = Entrydata.GetDataDepartment();
            beneficiary.DataSource = DtDepartment;
            beneficiary.DisplayMember = "الاقسام والمواقع";

            DataTable DtDistenation = Entrydata.DistenationSelecting();
            distenation.DataSource = DtDistenation;
            distenation.DisplayMember = "الجهة المقصودة";

            DataTable DtTheType = Entrydata.TheTypeselection();
            thetype.DataSource = DtTheType;
            thetype.DisplayMember = "الحالة";

            DataTable Dtcustomername = Entrydata.TheCustomerSelection();
            customername.DataSource = Dtcustomername;
            customername.DisplayMember = "اسم المستفيد";


        }

        
    }
}
