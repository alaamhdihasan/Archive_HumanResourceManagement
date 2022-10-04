using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace MechanismsCD.CLS_FRMS
{
    class CLSCARS
     {
        
        public DataTable CarDivisionGetDate()// ----Get Data From CarDivision Table -------------------------------------------------------------------- 
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("DivisionCarsSeleting", null);
            dal.close();
            return Dt;
        }
        //========================================
        // Selection Data from CardivisionGetData by using CarNo.
        public DataTable CarsDivisionByCarNo(string _CarNo)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CarNO", SqlDbType.VarChar, 50);param[0].Value = _CarNo;
            dal.open();
            DataTable Dt = dal.SelectingData("DivisonCarSelectionby_CarNo", param);
            dal.close();
            return Dt;

        }

        //================================================================

        public void CarDivisionInsertData(string DocumnetNo,string CarNO,string CarType,string CarBrand,string CarBarcode,
            string CarLine,string Distenation,string Beneficiary,string TheType,string department,string division
            ,string fueltype,string  carmodel,string shasyno,string registername,
            string Addingtime,string Addingdate,string CarColor, string TireSize)//----Insert Data to CarDivision Table ----------------------------------------------------------------
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@DocumentNo", SqlDbType.VarChar, 50);                  param[0].Value = DocumnetNo;
            param[1] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);                       param[1].Value = CarNO;
            param[2] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);                     param[2].Value = CarType;
            param[3] = new SqlParameter("@theBrand", SqlDbType.VarChar, 50);                    param[3].Value = CarBrand;
            param[4] = new SqlParameter("@carBarcode", SqlDbType.VarChar, 50);                  param[4].Value = CarBarcode;
            param[5] = new SqlParameter("@transportName", SqlDbType.VarChar, 50);               param[5].Value = CarLine;
            param[6] = new SqlParameter("@distenation", SqlDbType.VarChar, 50);                 param[6].Value = Distenation;
            param[7] = new SqlParameter("@beneficairy", SqlDbType.VarChar, 50);                 param[7].Value = Beneficiary;
            param[8] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);                     param[8].Value = TheType;
            param[9] = new SqlParameter("@DepartmentName", SqlDbType.VarChar, 50);              param[9].Value = department;
            param[10] = new SqlParameter("@Division", SqlDbType.VarChar, 50);                   param[10].Value = division;
            param[11] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50);                   param[11].Value = fueltype;
            param[12] = new SqlParameter("@Carmodel", SqlDbType.VarChar, 50);                   param[12].Value = carmodel;
            param[13] = new SqlParameter("@shasyNo", SqlDbType.VarChar, 50);                    param[13].Value = shasyno;
            param[14] = new SqlParameter("@regisername", SqlDbType.VarChar, 50);                param[14].Value = Properties.Settings.Default.UserNameLogin;
            param[15] = new SqlParameter("@addingtime", SqlDbType.VarChar, 50);                 param[15].Value = DateTime.Now.ToString("hh:mm tt");
            param[16] = new SqlParameter("@addingdate", SqlDbType.VarChar, 50);                 param[16].Value = DateTime.Now.ToString("dd/MM/yyyy");
            param[17] = new SqlParameter("@CarColor", SqlDbType.VarChar, 50);                   param[17].Value = CarColor;
            param[18] = new SqlParameter("@TireSize", SqlDbType.VarChar, 50);                   param[18].Value = TireSize;
            dal.open();
            dal.ExecuteCommand("DivisionCarsInsertInto", param);
            dal.close();
            CarDivisionGetDate();
        }

        public void CarDivisionUpdateData(string DocumentNo,string CarNO, string CarType, string CarBrand, string CarBarcode,
            string CarLine, string Distenation, string Beneficiary, string TheType, string department, string division
            , string fueltype, string carmodel, string shasyno, string registername,
            string Addingtime, string Addingdate,string CarColor, string TireSize)//-----Update Data in Cardivision Table
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[19];
            param[0] = new SqlParameter("@DocumentNo", SqlDbType.VarChar, 50);
            param[0].Value = DocumentNo;
            param[1] = new SqlParameter("@Carno", SqlDbType.VarChar, 50);
            param[1].Value = CarNO;
            param[2] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);
            param[2].Value = CarType;
            param[3] = new SqlParameter("@theBrand", SqlDbType.VarChar, 50);
            param[3].Value = CarBrand;
            param[4] = new SqlParameter("@carBarcode", SqlDbType.VarChar, 50);
            param[4].Value = CarBarcode;
            param[5] = new SqlParameter("@transportName", SqlDbType.VarChar, 50);
            param[5].Value = CarLine;
            param[6] = new SqlParameter("@distenation", SqlDbType.VarChar, 50);
            param[6].Value = Distenation;
            param[7] = new SqlParameter("@beneficairy", SqlDbType.VarChar, 50);
            param[7].Value = Beneficiary;
            param[8] = new SqlParameter("@thetype", SqlDbType.VarChar, 50);
            param[8].Value = TheType;
            param[9] = new SqlParameter("@DepartmentName", SqlDbType.VarChar, 50);
            param[9].Value = department;
            param[10] = new SqlParameter("@Division", SqlDbType.VarChar, 50);
            param[10].Value = division;
            param[11] = new SqlParameter("@FuelType", SqlDbType.VarChar, 50);
            param[11].Value = fueltype;
            param[12] = new SqlParameter("@Carmodel", SqlDbType.VarChar, 50);
            param[12].Value = carmodel;
            param[13] = new SqlParameter("@shasyNo", SqlDbType.VarChar, 50);
            param[13].Value = shasyno;
            param[14] = new SqlParameter("@regisername", SqlDbType.VarChar, 50);
            param[14].Value = Properties.Settings.Default.UserNameLogin;
            param[15] = new SqlParameter("@addingtime", SqlDbType.VarChar, 50);
            param[15].Value = DateTime.Now.ToString("hh:mm tt");
            param[16] = new SqlParameter("@addingdate", SqlDbType.VarChar, 50);
            param[16].Value = DateTime.Now.ToString("dd/MM/yyyy");
            param[17] = new SqlParameter("@CarColor", SqlDbType.VarChar, 50);
            param[17].Value = CarColor;
            param[18] = new SqlParameter("@TireSize", SqlDbType.VarChar, 50);
            param[18].Value = TireSize;
            dal.open();
            dal.ExecuteCommand("DivisionCarUpdate", param);
            dal.close();
            CarDivisionGetDate();

        }
        public void CarDivisionDeleteData(string CarNO)//----Delete Data From CarDivision Table
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CarNOde", SqlDbType.VarChar, 50);
            param[0].Value = CarNO;
            dal.open();
            dal.ExecuteCommand("DivisionCarDeleting", param);
            dal.close();
            CarDivisionGetDate();

        }

        // Display Data into CarDivision Form-------------------------------------------------
        
      
        public DataTable CarDivisionDisplayData(DataGridView dgv1,TextBox carno,ComboBox cartype,ComboBox brand
            ,TextBox carbarcode,TextBox transportname,ComboBox distenation,ComboBox beneficiary,ComboBox thetype
            ,ComboBox Depratmentname,ComboBox Divisionname,ComboBox Fueltype,TextBox Carmodel
            ,TextBox ShasyNO,TextBox registername ,TextBox Addingtime, TextBox Addingdate,TextBox DocumentNo,TextBox CarColor, TextBox TireSize)
        {
          DataTable Dtdgv = new DataTable();
          Dtdgv = CarDivisionGetDate();
          dgv1.DataSource = Dtdgv;
            dgv1.Columns[11].Visible = false;
            dgv1.Columns[12].Visible = false;
            dgv1.Columns[13].Visible = false;
            dgv1.Columns[14].Visible = false;
            dgv1.Columns[15].Visible = false;
            dgv1.Columns[16].Visible = false;

            DocumentNo.DataBindings.Add("text", Dtdgv, "الاضبارة");
            carno.DataBindings.Add("text", Dtdgv, "رقم العجلة");
            cartype.DataBindings.Add("text", Dtdgv, "نوع العجلة");
            brand.DataBindings.Add("text", Dtdgv, "الشركة");
            carbarcode.DataBindings.Add("text", Dtdgv, "باركود العجلة");
            transportname.DataBindings.Add("text", Dtdgv, "الخط");
            distenation.DataBindings.Add("text", Dtdgv, "الجهة المقصودة");
            beneficiary.DataBindings.Add("text", Dtdgv, "الجهة المستفيدة");
            thetype.DataBindings.Add("text", Dtdgv, "حالة الحركة");
            Depratmentname.DataBindings.Add("text", Dtdgv, "عائدية العجلة");
            Divisionname.DataBindings.Add("text", Dtdgv, "الشعبة");
            Fueltype.DataBindings.Add("text", Dtdgv, "نوع الوقود");
            Carmodel.DataBindings.Add("text", Dtdgv, "الموديل");
            ShasyNO.DataBindings.Add("text", Dtdgv, "الشاصي");
            registername.DataBindings.Add("text", Dtdgv, "مدخل البيانات");
            Addingtime.DataBindings.Add("text", Dtdgv, "وقت الاضافة");
            Addingdate.DataBindings.Add("text", Dtdgv, "تاريخ الاضافة");
            CarColor.DataBindings.Add("text", Dtdgv, "لون العجلة");
            TireSize.DataBindings.Add("text", Dtdgv, "قياس الاطارات");

            return Dtdgv;



        }
        //-- Clear Data From CarDivision Form -------------------------------------------------------------
        public void CarDivisionClearData(DataGridView dgv1, TextBox carno, ComboBox cartype, ComboBox brand
            , TextBox carbarcode, TextBox transportname, ComboBox distenation, ComboBox beneficiary, ComboBox thetype
            , ComboBox Depratmentname, ComboBox Divisionname, ComboBox Fueltype, TextBox Carmodel
            , TextBox ShasyNO, TextBox registername, TextBox Addingtime, TextBox Addingdate,TextBox DocumentNo,TextBox CarColor, TextBox TireSize)
        {
            DataTable Dtdgv = new DataTable();
            Dtdgv = CarDivisionGetDate();
            dgv1.DataSource = null;

            DocumentNo.DataBindings.Clear();
            carno.DataBindings.Clear();
            cartype.DataBindings.Clear();
            brand.DataBindings.Clear();
            carbarcode.DataBindings.Clear();
            transportname.DataBindings.Clear();
            distenation.DataBindings.Clear();
            beneficiary.DataBindings.Clear();
            thetype.DataBindings.Clear();
            registername.DataBindings.Clear();
            Addingtime.DataBindings.Clear();
            Addingdate.DataBindings.Clear();
            Depratmentname.DataBindings.Clear();
            Divisionname.DataBindings.Clear();
            Fueltype.DataBindings.Clear();
            Carmodel.DataBindings.Clear();
            ShasyNO.DataBindings.Clear();
            CarColor.DataBindings.Clear();
            TireSize.DataBindings.Clear();
        }
        // Clear Data From Field text into the CarDivision Form-------------------------------------------- 
        public void CardivisionCleartext(TextBox carno, ComboBox cartype, ComboBox brand
            , TextBox carbarcode, TextBox transportname, ComboBox distenation, ComboBox beneficiary, ComboBox thetype
            , ComboBox Depratmentname, ComboBox Divisionname, ComboBox Fueltype, TextBox Carmodel
            , TextBox ShasyNO, TextBox registername, TextBox Addingtime, TextBox Addingdate,TextBox DocumentNo,TextBox CarColor)
        {
            DocumentNo.Text = "";
            carno.Text = "";
            cartype.Text = "";
            brand.Text = "";
            carbarcode.Text = "";
            transportname.Text = "";
            distenation.Text = "";
            beneficiary.Text = "";
            thetype.Text = "";
            registername.Text = "";
            Addingtime.Text = "";
            Addingdate.Text = "";
            Depratmentname.Text = "";
            Divisionname.Text = "";
            Fueltype.Text = "";
            Carmodel.Text = "";
            ShasyNO.Text = "";
            CarColor.Text = "";
        }
        //--- Fill The Combobox Of CarsDivision Form When The btncarnew is Clicked-------------------------------------
        public void cbodata(ComboBox cbodistenation,ComboBox cbobeneficiary,ComboBox cbothetype, ComboBox Departmentname, ComboBox cboCarType, ComboBox cboCompany, ComboBox cboDivision)
            
        {

            CLSCONSTENTRY Getdata = new CLSCONSTENTRY();
            DataTable Dt = new DataTable();
            Dt = Getdata.DistenationSelecting();

            cbodistenation.DataSource = Dt;
            cbodistenation.DisplayMember = "الجهة المقصودة";

            DataTable Dtbenefeciary = new DataTable();
            Dtbenefeciary = Getdata.GetDataDepartment();
            cbobeneficiary.DataSource = Dtbenefeciary;
            cbobeneficiary.DisplayMember = "الاقسام والمواقع";
            Departmentname.DataSource = Dtbenefeciary;
            Departmentname.DisplayMember = "الاقسام والمواقع";


            DataTable Dtthetype = new DataTable();
            Dtthetype = Getdata.TheTypeselection();
            cbothetype.DataSource = Dtthetype;
            cbothetype.DisplayMember = "الحالة";

            DataTable DtDivision = new DataTable();
            DtDivision = Getdata.GetDivisionData();
            cboDivision.DataSource = DtDivision;
            cboDivision.DisplayMember = "DivisionName";

            DataTable DtCar = CarDivisionGetDate();
            for (int i = 0; i < DtCar.Rows.Count; i++)
            {
                int j = 0;
                while (j < cboCarType.Items.Count && DtCar.Rows[i][2].ToString() != cboCarType.Items[j].ToString())
                    j++;
                if (j == cboCarType.Items.Count && DtCar.Rows[i][2] != null && DtCar.Rows[i][2].ToString() != "")
                    cboCarType.Items.Add(DtCar.Rows[i][2]);
            }

            for (int i = 0; i < DtCar.Rows.Count; i++)
            {
                int j = 0;
                while (j < cboCompany.Items.Count && DtCar.Rows[i][3].ToString() != cboCompany.Items[j].ToString())
                    j++;
                if (j == cboCompany.Items.Count && DtCar.Rows[i][3] != null && DtCar.Rows[i][3].ToString() != "")
                    cboCompany.Items.Add(DtCar.Rows[i][3]);
            }

        }
        //----------------------------------------------------------------------------------------------------------------------
        //--This function Below for GettingData From the CarArchieve table by using The Stored procedure CarArSelection .....
        public DataTable CarArSelection(string Carno,TextBox CarArID,TextBox CarArNo,TextBox CarArimage,TextBox CarArRegisterName,TextBox CarArAddingTime
            ,TextBox CarArAddingdate,ListView LstCar,Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CarNo", SqlDbType.VarChar, 50);                param[0].Value = Carno;
            dal.open();
            DataTable Dt = dal.SelectingData("CarArSelection", param);
            dal.close();

            foreach(Control p in pn.Controls)
            {
                if(p is TextBox) { p.DataBindings.Clear(); }
            }
            string st = "text";
            CarArID.DataBindings.Add(st, Dt, "IDArCar");
            CarArNo.DataBindings.Add(st, Dt, "CarNo");
            CarArimage.DataBindings.Add(st, Dt, "ImgeCopy");
            CarArRegisterName.DataBindings.Add(st, Dt, "RegisterName");
            CarArAddingTime.DataBindings.Add(st, Dt, "AddingTime");
            CarArAddingdate.DataBindings.Add(st, Dt, "AddingDate");

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(250, 250);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                imageListLarge.Images.Add(Bitmap.FromFile(Dt.Rows[i][2].ToString()));
            }
            LstCar.Items.Clear();
            LstCar.LargeImageList = imageListLarge;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                LstCar.Items.Add(Dt.Rows[i][2].ToString(), i);
            }
            LstCar.View = View.LargeIcon;          
            return Dt;
        }
        //===========================================================================================================================
        //=== This function below for inserting data to the CarArcheive by using the stord procedure VCararinsertinto......
        public void CarArInsertData( string CarArNo, string CarArimage, string CarArRegisterName, string CarArAddingTime
            , string CarArAddingdate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@CarNo", SqlDbType.VarChar, 50);param[0].Value = CarArNo;
            param[1] = new SqlParameter("@Imagecopy", SqlDbType.Text);param[1].Value = CarArimage;
            param[2] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);param[2].Value = CarArRegisterName;
            param[3] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);param[3].Value = CarArAddingdate;
            param[4] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);param[4].Value = CarArAddingTime;
            dal.open();
            dal.ExecuteCommand("CarArInsertinto", param);
            dal.close();
        }
        //=============================================================================================================================
        //== this functin Below to delete data from carArchieve by using stored procedure CarArInsertinto....
        public void CarArDelete(int CarArID)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDArCar", SqlDbType.Int); param[0].Value = CarArID;
            dal.open();
            dal.ExecuteCommand("CarArDelete", param);
            dal.close();
        }
        //=============================================================================================================================
        //== this function below for GettingData from CarArchieve by ImagePath......
        public DataTable CarArSelectionbyimagepath(string ImagePath, TextBox CarArID, TextBox CarArNo, TextBox CarArimage, TextBox CarArRegisterName, TextBox CarArAddingTime
           , TextBox CarArAddingdate, ListView LstCar, Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("ImagePath", SqlDbType.Text);                   param[0].Value = ImagePath;
            dal.open();
            DataTable Dt = dal.SelectingData("CarArSelectionbyImage", param);
            dal.close();

            foreach (Control p in pn.Controls)
            {
                if (p is TextBox) { p.DataBindings.Clear(); }
            }
            string st = "text";
            CarArID.DataBindings.Add(st, Dt, "IDArCar");
            CarArNo.DataBindings.Add(st, Dt, "CarNo");
            CarArimage.DataBindings.Add(st, Dt, "ImgeCopy");
            CarArRegisterName.DataBindings.Add(st, Dt, "RegisterName");
            CarArAddingTime.DataBindings.Add(st, Dt, "AddingTime");
            CarArAddingdate.DataBindings.Add(st, Dt, "AddingDate");
                       
            return Dt;
        }

        //==============================================================================================================================================


        
    }

}
