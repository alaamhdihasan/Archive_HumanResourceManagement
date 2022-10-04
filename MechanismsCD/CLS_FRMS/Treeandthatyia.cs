using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Net;
using System.Globalization;

namespace MechanismsCD.CLS_FRMS
{
    
    class Treeandthatyia
    {
        
        
        //=========================================================================
        // This code below for Getting Data to the MainlyNode... running the Treeone Procedure
        public DataTable Getmainlynodd()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("Treeone", null);
            dal.close();
            return Dt;
        }
        //=========================================================================
        // This code below for Getting Date to the nestedNode... running the Treeone2 Procedure
        public DataTable GetSecondarynodd(int indx)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@indexofName", SqlDbType.Int); param[0].Value = indx;
            dal.open();
            DataTable Dt2 = dal.SelectingData("Treeone2", param);
            dal.close();
            return Dt2;
        }
        //========================================================================
        // This code below for Getting Date By year and index... running the Treeone3 Procedure
        public DataTable GetDatanode(string indx, string yearindx)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@indexofName", SqlDbType.VarChar, 50); param[0].Value = indx;
            param[1] = new SqlParameter("@Year_Exp_Imp", SqlDbType.VarChar, 50); param[1].Value = yearindx;
            dal.open();
            DataTable Dt2 = dal.SelectingData("Treeone3", param);
            dal.close();
            return Dt2;
        }
        //===============================================================================
        // Design The DataGridView And The Gui (Textbox etc) in the Frame......
        public void DesignGrid(DataGridView Dgv, DataTable Dt, TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, TextBox tb5, DateTimePicker tb6
            , TextBox tb7, DateTimePicker tb8, TextBox tb9, ComboBox tb10, TextBox tb11, TextBox tb12, TextBox tb13, TextBox tb14, TextBox tb15, TextBox tb16
            , ComboBox tb17, ComboBox tb18, ComboBox tb19, RichTextBox tb20, DateTimePicker tb21, TextBox tb22, DateTimePicker tb23, RichTextBox tb24,
            TableLayoutPanel pntb, Panel pnbtn, TextBox tbnode11, TextBox tbnode22,DataGridView DgvSearching)
        {
            foreach (Control p in pntb.Controls) { if ((p is TextBox) || (p is DateTimePicker) || (p is ComboBox) || (p is RichTextBox)) p.DataBindings.Clear(); };
            tb20.DataBindings.Clear();
            Dgv.DataSource = null;
            Dgv.DataSource = Dt;
            DgvSearching.DataSource = null;
            DgvSearching.DataSource = Dgv.DataSource;

            tb1.DataBindings.Clear();
            tb2.DataBindings.Clear();
            tb3.DataBindings.Clear();
            tb4.DataBindings.Clear();
            tb5.DataBindings.Clear();
            tb6.DataBindings.Clear();
            tb7.DataBindings.Clear();
            tb8.DataBindings.Clear();
            tb9.DataBindings.Clear();
            tb10.DataBindings.Clear();
            tb11.DataBindings.Clear();
            tb12.DataBindings.Clear();
            tb13.DataBindings.Clear();
            tb14.DataBindings.Clear();
            tb15.DataBindings.Clear();
            tb16.DataBindings.Clear();
            tb17.DataBindings.Clear();
            tb18.DataBindings.Clear();
            tb19.DataBindings.Clear();
            tb20.DataBindings.Clear();
            tb21.DataBindings.Clear();
            tb22.DataBindings.Clear();
            tb23.DataBindings.Clear();
            tb24.DataBindings.Clear();


            string st = "text";
            tb1.DataBindings.Add(st, Dt, "ID_Exp_Imp"); //tb1.Visible = true;
            tb2.DataBindings.Add(st, Dt, "IndexofName"); //tb2.Visible = false;
            tb3.DataBindings.Add(st, Dt, "TypeName"); //tb3.Visible = false;
            tb4.DataBindings.Add(st, Dt, "Year_Exp_Imp");// tb4.Visible = false;
            tb5.DataBindings.Add(st, Dt, "ImportNo"); tb5.Enabled = false;
            tb6.DataBindings.Add(st, Dt, "ImportDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb7.DataBindings.Add(st, Dt, "BookNO"); tb7.Enabled = false;
            tb8.DataBindings.Add(st, Dt, "BookDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb9.DataBindings.Add(st, Dt, "HijriDay");
            tb10.DataBindings.Add(st, Dt, "HijriMonth");
            tb11.DataBindings.Add(st, Dt, "HijriYear");
            tb12.DataBindings.Add(st, Dt, "signature");
            tb13.DataBindings.Add(st, Dt, "signatureparth");
            tb14.DataBindings.Add(st, Dt, "RegisterName"); tb14.ReadOnly = true;
            tb15.DataBindings.Add(st, Dt, "AddingTime"); tb15.ReadOnly = true;
            tb16.DataBindings.Add(st, Dt, "AddingDate"); tb16.ReadOnly = true;
            tb17.DataBindings.Add(st, Dt, "BookTitle");
            tb18.DataBindings.Add(st, Dt, "FromDe");
            tb19.DataBindings.Add(st, Dt, "ToDe");
            tb20.DataBindings.Add(st, Dt, "BookDetails");
            tb21.DataBindings.Add(st, Dt, "DeliverDate");
            tb22.DataBindings.Add(st, Dt, "BookNo2");
            tb23.DataBindings.Add(st, Dt, "BookDate2");
            tb24.DataBindings.Add(st, Dt, "Murfaqat");
            

            if (tbnode22.Visible == true && tbnode11.Visible == false)
            {
                for (int i = 0; i < Dgv.Columns.Count; i++)
                {
                    Dgv.Columns[0].Visible = false;
                    Dgv.Columns[1].Visible = false;
                    Dgv.Columns[2].Visible = false;
                    Dgv.Columns[3].Visible = false;
                    Dgv.Columns[4].Visible = false;
                    Dgv.Columns[5].Visible = false;
                    Dgv.Columns[6].HeaderText = "رقم الصادر";
                    Dgv.Columns[7].HeaderText = "تاريخ الصادر";
                    Dgv.Columns[8].Visible = false;
                    Dgv.Columns[9].Visible = false;
                    Dgv.Columns[10].Visible = false;
                    Dgv.Columns[11].HeaderText = "عنوان الكتاب";
                    Dgv.Columns[12].HeaderText = "جهة الاصدار";
                    Dgv.Columns[13].HeaderText = "الجهة الصادر لها";
                    Dgv.Columns[14].Visible = false;
                    Dgv.Columns[15].HeaderText = "تفاصيل الكتاب";
                    Dgv.Columns[16].Visible = false;
                    Dgv.Columns[17].Visible = false;
                    Dgv.Columns[18].Visible = false;
                    Dgv.Columns[19].Visible = false;
                    Dgv.Columns[20].Visible = false;
                    Dgv.Columns[21].Visible = false;
                    Dgv.Columns[22].Visible = false;
                    Dgv.Columns[23].Visible = false;

                }
            }
            else if (tbnode11.Visible == true && tbnode22.Visible == false)
            {
                for (int i = 0; i < Dgv.Columns.Count; i++)
                {
                    Dgv.Columns[0].Visible = false;
                    Dgv.Columns[1].Visible = false;
                    Dgv.Columns[2].Visible = false;
                    Dgv.Columns[3].Visible = false;
                    Dgv.Columns[4].HeaderText = "رقم الوارد";
                    Dgv.Columns[5].HeaderText = "تاريخ الوارد";
                    Dgv.Columns[6].Visible = false;
                    Dgv.Columns[7].Visible = false;
                    Dgv.Columns[8].Visible = false;
                    Dgv.Columns[9].Visible = false;
                    Dgv.Columns[10].Visible = false;
                    Dgv.Columns[11].HeaderText = "عنوان الكتاب";
                    Dgv.Columns[12].HeaderText = "جهة الاصدار";
                    Dgv.Columns[13].HeaderText = "الجهة الصادر لها";
                    Dgv.Columns[14].Visible = false;
                    Dgv.Columns[15].HeaderText = "تفاصيل الكتاب";
                    Dgv.Columns[16].Visible = false;
                    Dgv.Columns[17].Visible = false;
                    Dgv.Columns[18].Visible = false;
                    Dgv.Columns[19].Visible = false;
                    Dgv.Columns[20].Visible = false;
                    Dgv.Columns[21].HeaderText = "صادر الكتاب";
                    Dgv.Columns[22].HeaderText = "تاريخ الكتاب";
                    Dgv.Columns[23].Visible = false;
                }
            }
            else
            {
                for (int i = 0; i < Dgv.Columns.Count; i++)
                {
                    Dgv.Columns[0].Visible = false;
                    Dgv.Columns[1].Visible = false;
                    Dgv.Columns[2].Visible = false;
                    Dgv.Columns[3].Visible = false;
                    Dgv.Columns[4].Visible = false;
                    Dgv.Columns[5].Visible = false;
                    Dgv.Columns[6].Visible = false;
                    Dgv.Columns[7].Visible = false;
                    Dgv.Columns[8].Visible = false;
                    Dgv.Columns[9].Visible = false;
                    Dgv.Columns[10].Visible = false;
                    Dgv.Columns[11].HeaderText = "عنوان";
                    Dgv.Columns[12].HeaderText = "جهة الاصدار";
                    Dgv.Columns[13].Visible = false;
                    Dgv.Columns[14].Visible = false;
                    Dgv.Columns[15].HeaderText = "تفاصيل الكتاب";
                    Dgv.Columns[16].Visible = false;
                    Dgv.Columns[17].Visible = false;
                    Dgv.Columns[18].Visible = false;
                    Dgv.Columns[19].Visible = false;
                    Dgv.Columns[20].Visible = false;
                    Dgv.Columns[21].HeaderText = "صادر الكتاب";
                    Dgv.Columns[22].HeaderText = "تاريخ الكتاب";
                    Dgv.Columns[23].Visible = false;
                }

            }
           
        }

        //========================================================================================
        //=== This Function to Adding Data to the Thatyai Table by the ThatyiaAdding procedure
        public void ThatyiaAdding(int indexofname, string typename, int yeardoc, string ImportNo, string ImportDate,
           string BookNo, string BookDate, string HijirDay, string hijirimonth, string Hijriyear, string BookTitle,
           string FromDe, string ToDe, string DeliverDate, string BookDetails, string signature, string signaturepath,
           string RegisterName, string AddingTime, string AddingDate, string BookNo2, string BookDate2, string Murfaqat)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[23];
            param[0] = new SqlParameter("@IndexofName", SqlDbType.Int); param[0].Value = indexofname;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[1].Value = typename;
            param[2] = new SqlParameter("@Year", SqlDbType.Int); param[2].Value = yeardoc;
            param[3] = new SqlParameter("@ImportNo", SqlDbType.VarChar, 50); param[3].Value = ImportNo;
            param[4] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[4].Value = ImportDate;
            param[5] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50); param[5].Value = BookNo;
            param[6] = new SqlParameter("@BookDate", SqlDbType.VarChar, 50); param[6].Value = BookDate;
            param[7] = new SqlParameter("@HijiriDay", SqlDbType.VarChar, 2); param[7].Value = HijirDay;
            param[8] = new SqlParameter("@HijiriMonth", SqlDbType.VarChar, 50); param[8].Value = hijirimonth;
            param[9] = new SqlParameter("@HijriYear", SqlDbType.VarChar, 4); param[9].Value = Hijriyear;
            param[10] = new SqlParameter("@BookTitile", SqlDbType.NText); param[10].Value = BookTitle;
            param[11] = new SqlParameter("@FromDe", SqlDbType.VarChar, 50); param[11].Value = FromDe;
            param[12] = new SqlParameter("@ToDe", SqlDbType.Text); param[12].Value = ToDe;
            param[13] = new SqlParameter("@DeliverDate", SqlDbType.VarChar, 50); param[13].Value = DeliverDate;
            param[14] = new SqlParameter("@BookDetails", SqlDbType.NText); param[14].Value = BookDetails;
            param[15] = new SqlParameter("@signatur", SqlDbType.VarChar, 50); param[15].Value = signature;
            param[16] = new SqlParameter("@signaturepath", SqlDbType.Text); param[16].Value = signaturepath;
            param[17] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[17].Value = RegisterName;
            param[18] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[18].Value = AddingTime;
            param[19] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[19].Value = AddingDate;
            param[20] = new SqlParameter("@BookNo2", SqlDbType.VarChar, 50); param[20].Value = BookNo2;
            param[21] = new SqlParameter("@BookDate2", SqlDbType.VarChar, 50); param[21].Value = BookDate2;
            param[22] = new SqlParameter("@Murfaqat", SqlDbType.Text); param[22].Value = Murfaqat;
            dal.open();
            dal.ExecuteCommand("ThatyiaAdding", param);
            dal.close();

        }
        //========================================================================================================
        // ==== This Function For Update Data To the thaytia Table by running ThatyiaUpdate Procedure
        public void ThatyiaUpdate(int indexofname, string typename, int yeardoc, string ImportNo, string ImportDate,
           string BookNo, string BookDate, string HijirDay, string hijirimonth, string Hijriyear, string BookTitle,
           string FromDe, string ToDe, string DeliverDate, string BookDetails, string signature, string signaturepath,
           string RegisterName, string AddingTime, string AddingDate, int ID_Exp, string BookNo2, string BookDate2, string Murfaqat)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[24];
            param[0] = new SqlParameter("@IndexofName", SqlDbType.Int); param[0].Value = indexofname;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[1].Value = typename;
            param[2] = new SqlParameter("@Year", SqlDbType.Int); param[2].Value = yeardoc;
            param[3] = new SqlParameter("@ImportNo", SqlDbType.VarChar, 50); param[3].Value = ImportNo;
            param[4] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[4].Value = ImportDate;
            param[5] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50); param[5].Value = BookNo;
            param[6] = new SqlParameter("@BookDate", SqlDbType.VarChar, 50); param[6].Value = BookDate;
            param[7] = new SqlParameter("@HijiriDay", SqlDbType.VarChar, 2); param[7].Value = HijirDay;
            param[8] = new SqlParameter("@HijiriMonth", SqlDbType.VarChar, 50); param[8].Value = hijirimonth;
            param[9] = new SqlParameter("@HijriYear", SqlDbType.VarChar, 4); param[9].Value = Hijriyear;
            param[10] = new SqlParameter("@BookTitile", SqlDbType.NText); param[10].Value = BookTitle;
            param[11] = new SqlParameter("@FromDe", SqlDbType.VarChar, 50); param[11].Value = FromDe;
            param[12] = new SqlParameter("@ToDe", SqlDbType.Text); param[12].Value = ToDe;
            param[13] = new SqlParameter("@DeliverDate", SqlDbType.VarChar, 50); param[13].Value = DeliverDate;
            param[14] = new SqlParameter("@BookDetails", SqlDbType.NText); param[14].Value = BookDetails;
            param[15] = new SqlParameter("@signatur", SqlDbType.VarChar, 50); param[15].Value = signature;
            param[16] = new SqlParameter("@signaturepath", SqlDbType.Text); param[16].Value = signaturepath;
            param[17] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[17].Value = RegisterName;
            param[18] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[18].Value = AddingTime;
            param[19] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[19].Value = AddingDate;
            param[20] = new SqlParameter("@ID_Exp_Imp", SqlDbType.Int); param[20].Value = ID_Exp;
            param[21] = new SqlParameter("@BookNo2", SqlDbType.VarChar, 50); param[21].Value = BookNo2;
            param[22] = new SqlParameter("@BookDate2", SqlDbType.VarChar, 50); param[22].Value = BookDate2;
            param[23] = new SqlParameter("@Murfaqat", SqlDbType.Text); param[23].Value = Murfaqat;
            dal.open();
            dal.ExecuteCommand("ThatyiaUpdate", param);
            dal.close();

        }
        //==================================================================================================================
        //=== This function for Delete Data from Thatyia table by running the ThatyiaDelete Procedure..
        public void ThatyiaDelete(int ID_Exp)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID_Exp_Imp", SqlDbType.Int); param[0].Value = ID_Exp;

            dal.open();
            dal.ExecuteCommand("ThatyiaDeleting", param);
            dal.close();

        }
        //===================================================================================================================
        //===== This Function Below for Getting last Record Of thatyia by running the ThatyiaAddingID Procedure...
        public DataTable thatyiaAddingID(int year, int indexofname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", SqlDbType.Int); param[0].Value = year;
            param[1] = new SqlParameter("@IndexOfName", SqlDbType.Int); param[1].Value = indexofname;
            dal.open();
            DataTable Dt = dal.SelectingData("ThatyiaAddingID", param);
            dal.close();
            return Dt;
        }
        //===================================================================================================================
        public DataTable thatyiaAddingID2(int year, int indexofname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Year", SqlDbType.Int);                        param[0].Value = year;
            param[1] = new SqlParameter("@IndexOfName", SqlDbType.Int);                 param[1].Value = indexofname;
            dal.open();
            DataTable Dt = dal.SelectingData("ThatyiaAddingID2", param);
            dal.close();
            return Dt;
        }
        //=====================================================================================================================
        //=== This function for buttonNew ....
        public void btnNew(DataTable Dt, TextBox tb1, TextBox tb2, TextBox tb3, TextBox tb4, TextBox tb5, DateTimePicker tb6
            , TextBox tb7, DateTimePicker tb8, TextBox tb9, ComboBox tb10, TextBox tb11, TextBox tb12, TextBox tb13, TextBox tb14
            , TextBox tb15, TextBox tb16, ComboBox tb17, ComboBox tb18, ComboBox tb19, RichTextBox tb20, RichTextBox tb24)
        {
            if (Dt.Rows.Count > 0)
            {


                if (Dt.Rows[0][0].ToString() != "")
                {
                    if (tb5.Visible==false && tb7.Visible==true)
                    {
                        int x;
                        x = int.Parse(Dt.Rows[0][0].ToString());
                        tb7.Text = (x + 1).ToString();
                    }
                    else if (tb5.Visible==true && tb7.Visible==false)
                    {
                        int x;
                        x = int.Parse(Dt.Rows[0][0].ToString());
                        tb5.Text = (x + 1).ToString();
                    }
                }
                else
                {
                    int y = 0;
                    if (tb5.Visible == false && tb7.Visible == true) { tb7.Text = (y + 1).ToString(); }
                    else if (tb5.Visible == true && tb7.Visible == false) { tb5.Text = (y + 1).ToString(); }
                }
                
                tb9.Clear(); tb10.Text = ""; tb11.Clear(); tb12.Clear(); tb13.Clear(); tb14.Clear(); tb15.Clear(); tb16.Clear();
                tb17.Text = ""; tb18.Text = ""; tb19.Text = ""; tb20.Clear(); tb24.Clear();
            }
            else
            {

            }
        }

        //=========================================================================================================================
        //====== This Fuction Below for Getting Data from thatyia2 by running Thatyia2select procedure
        public DataTable thatyia2select(int idcon, TextBox archtb1, TextBox archtb2, TextBox archtb3, TextBox archtb4,
            TextBox archtb5, TextBox archtb6, TextBox archtb7, TextBox archtb8, TextBox archtb9, Panel pn, ListView lsv)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = idcon;
            dal.open();
            DataTable Dt = dal.SelectingData("Thatyia2Select", param);
            dal.close();
            foreach (Control p in pn.Controls) { if (p is TextBox) { p.DataBindings.Clear(); } }
            string str = "text";
            archtb1.DataBindings.Add(str, Dt, "IDindex");
            archtb2.DataBindings.Add(str, Dt, "IDcon");
            archtb3.DataBindings.Add(str, Dt, "TypeName");
            archtb4.DataBindings.Add(str, Dt, "Year_Exp_Imp");
            archtb5.DataBindings.Add(str, Dt, "BookNumber");
            archtb6.DataBindings.Add(str, Dt, "PathImage");
            archtb7.DataBindings.Add(str, Dt, "RegisterName");
            archtb8.DataBindings.Add(str, Dt, "AddingDate");
            archtb9.DataBindings.Add(str, Dt, "AddingTime");
            


           


            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(250, 250);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                try
                {                  
                    imageListLarge.Images.Add(Bitmap.FromFile(Dt.Rows[i][5].ToString()));
                }
                catch
                {
                    imageListLarge.Images.Add(iconfile(Path.GetExtension(Dt.Rows[i][5].ToString())));                   
                }
            }
            lsv.Items.Clear();
            lsv.LargeImageList = imageListLarge;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                lsv.Items.Add(Dt.Rows[i][5].ToString(), i);
            }
            
            lsv.View = View.LargeIcon;
            
            return Dt;
        }
        //=========================================================================================================================
        //=== This function Below for Adding Data to the thatyia2 Tables by running the Thatyia2Adding Procedure .....
        public void Thatyia2Adding(int idcon, string typename, int yearbook, string booknumber, string pathimage
            , string registername, string addingdate, string addingtime)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@Idcon", SqlDbType.Int); param[0].Value = idcon;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[1].Value = typename;
            param[2] = new SqlParameter("@year", SqlDbType.Int); param[2].Value = yearbook;
            param[3] = new SqlParameter("@BookNumber", SqlDbType.VarChar, 50); param[3].Value = booknumber;
            param[4] = new SqlParameter("@PathImage", SqlDbType.Text); param[4].Value = pathimage;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50); param[5].Value = registername;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[6].Value = addingdate;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = addingtime;
            dal.open();
            dal.ExecuteCommand("Thatyia2Adding", param);
            dal.close();
            

        }
        //==========================================================================================================================
        //===== This function Below for Update Data of thatyia2 table by using Thatyia2Update Procedure ......
        public void Thatyia2Update(int idcon, string typename, int yearbook, string booknumber, string pathimage
            , string registername, string addingdate, string addingtime, int Idindex)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Idcon", SqlDbType.Int); param[0].Value = idcon;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[1].Value = typename;
            param[2] = new SqlParameter("@year", SqlDbType.Int); param[2].Value = yearbook;
            param[3] = new SqlParameter("@BookNumber", SqlDbType.VarChar, 50); param[3].Value = booknumber;
            param[4] = new SqlParameter("@PathImage", SqlDbType.Text); param[4].Value = pathimage;
            param[5] = new SqlParameter("@registername", SqlDbType.VarChar, 50); param[5].Value = registername;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[6].Value = addingdate;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = addingtime;
            param[8] = new SqlParameter("@Idindex", SqlDbType.Int); param[8].Value = Idindex;
            dal.open();
            dal.ExecuteCommand("Thatyia2Update", param);
            dal.close();


        }
        //==========================================================================================================================
        //===== This function Below for Delete Data from Thatyia2 Table by using Thatyia2Delete Procedure 
        public void Thatyia2Delete(int Idindex)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Idindex", SqlDbType.Int); param[0].Value = Idindex;
            dal.open();
            dal.ExecuteCommand("Thatyia2Delete", param);
            dal.close();

        }
        //==========================================================================================================================
        // ===== This function for print Document From The Tb_Thatyia table by using Stored Procedure PrintDocument...
        public DataTable PrintDoc(int indexdoc)
        {
            DAL.DataAccessLayer Printdocument = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IndexDoc", SqlDbType.Int); param[0].Value = indexdoc;
            Printdocument.open();
            DataTable Dt = Printdocument.SelectingData("PrintDocument", param);
            Printdocument.close();
            return Dt;
        }
        //===================================================================================================================
        //--==== This function Below for Checking TreeView .....
        public DataTable TreeChecking(int indexofName, int yearoftree)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@indexName", SqlDbType.Int); param[0].Value = indexofName;
            param[1] = new SqlParameter("@Treeyear", SqlDbType.Int); param[1].Value = yearoftree;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeCheck", param);
            dal.close();
            return Dt;

        }
        //================================================================================================================
        //==== This function below for Adding TreeNode Child To the main table Tb_Thatyia... 
        public void TreeAddingChild(int indexName, int Treeyear, string TypeName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@indexName", SqlDbType.Int); param[0].Value = indexName;
            param[1] = new SqlParameter("@TreeYear", SqlDbType.Int); param[1].Value = Treeyear;
            param[2] = new SqlParameter("@NameParent", SqlDbType.VarChar, 50); param[2].Value = TypeName;
            dal.open();
            dal.ExecuteCommand("TreeAddChild", param);
            dal.close();
        }
        //==============================================================================================================
        //==== This Function below for Check MainNode in TreeView which names is Treeone.....
        public DataTable TreenodeCheckMain(string TypeName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[0].Value = TypeName;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeCheckMain", param);
            dal.close();
            return Dt;
        }
        //==============================================================================================================
        public DataTable TreeIndexOfName()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("Treeindexofname", null);
            dal.close();
            return Dt;
        }
        //============================================================================================================
        //=== This function below for Adding MainNode to the TreeView (Treeone) .........
        public void TreeAddMain(int IndexOfName, string TypeName, int TreeYear)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@indexofname", SqlDbType.Int); param[0].Value = IndexOfName;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[1].Value = TypeName;
            param[2] = new SqlParameter("@TreeYear", SqlDbType.Int); param[2].Value = TreeYear;
            dal.open();
            dal.ExecuteCommand("TreeAddMain", param);
            dal.close();


        }
        //==========================================================================================================
        //=== this function below for fill textbox from check treeview treeone...
        public DataTable TreeforFill(string TypeName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[0].Value = TypeName;
            dal.open();
            DataTable Dt = dal.SelectingData("Treeforfill", param);
            dal.close();
            return Dt;
        }
        //====================================================================================================
        //==== this function for check the Treechild....
        public DataTable TreeCheckChild(int indexofname)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@indexofname", SqlDbType.Int); param[0].Value = indexofname;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeCheckChild", param);
            dal.close();
            return Dt;
        }
        //=================================================================================================
        //---- This Function Below for Eventof KeyDown of TreeView (TreeOne) .....
        public void EventKeyDown(Label LbMenu, Label Lbrename, Label indexold, TextBox tbnode1, TextBox tbnode2, TreeView Tr, Timer LoadData)
        {
            if (LbMenu.Text == "اعادة تسمية")
            {
                var SelectedNode = Tr.SelectedNode;
                if (SelectedNode.Parent == null)
                {
                    DataTable Dtch = new DataTable();
                    Dtch = TreenodeCheckMain(tbnode1.Text);
                    if (Dtch.Rows.Count > 0)
                    {
                        MessageBox.Show("هذا الدليل موجود مسبقا, لا يمكن اعادة التسمية بنفس الاسم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        CLS_FRMS.WorkingProperties guidpro = new WorkingProperties();
                        DataTable Dtg = guidpro.ThatyiaPropertiesSelectingByGuidTow(tbnode1.Text);
                        if (Dtg.Rows.Count > 0)
                        {
                            return;
                        }
                        else
                        {
                            guidpro.ThatyiaPropertiesUpdattingTow(int.Parse(indexold.Text), tbnode1.Text);
                        }
                        TreeUpdate(tbnode1.Text, int.Parse(indexold.Text));

                        return;
                    }
                }
                else
                {
                    DataTable Dtch2 = new DataTable();
                    Dtch2 = TreeChecking(int.Parse(tbnode1.Text), int.Parse(Lbrename.Text));
                    if (Dtch2.Rows.Count > 0)
                    {
                        MessageBox.Show("لا يمكن اعادة التسمية بهذا الاسم, الاسم موجود مسبقا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        TreeUpdateChild(int.Parse(tbnode1.Text), int.Parse(Lbrename.Text), int.Parse(indexold.Text));

                        return;
                    }
                }



            }
            else if (LbMenu.Text == "حذف")
            {
                var SelectedNode = Tr.SelectedNode;
                if (SelectedNode.Parent == null)
                {
                    DataTable Dtchm = new DataTable();
                    Dtchm = CheckMainNodeForDeleting(tbnode1.Text);
                    if (Dtchm.Rows.Count > 0)
                    {
                        DialogResult Resualt = MessageBox.Show("هذا الدليل يحتوي  بداخله على مجلدات فرعية ، هل تريد بالتأكيد حذف الدليل  الرئيسي: حذف الدليل سيؤدي الى حذف البيانات التي بداخله كافة ولايمكن التراجع عنه", "تنبيه حذف دليل رئيسي", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (Resualt == DialogResult.Yes)
                        {
                            CLS_FRMS.WorkingProperties GuidPro = new WorkingProperties();
                            DataTable Dtguid = GuidPro.ThatyiaPropertiesSelectingByGuidTow(tbnode1.Text);
                            if (Dtguid.Rows.Count > 0)
                            {
                                GuidPro.ThatyiaPropertiesDeleting(tbnode1.Text);
                            }
                            else
                            {

                            }

                            DeletingMainNode(int.Parse(tbnode2.Text));
                            MessageBox.Show("تم الحذف بنجاح", "حذف مجلد", MessageBoxButtons.OK, MessageBoxIcon.None);
                            SelectedNode.Remove();

                            LoadData.Start();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    DataTable Dtchc = new DataTable();
                    Dtchc = CheckChildNodeForDeleting(int.Parse(tbnode2.Text), int.Parse(tbnode1.Text));
                    if (Dtchc.Rows.Count > 1)
                    {
                        DialogResult Resualt = MessageBox.Show("هذا المجلد يحتوي  بداخله على بيانات ، هل تريد بالتأكيد حذف هذا المجلد: حذف هذا المجلد سيؤدي الى حذف البيانات التي بداخله كافة ولايمكن التراجع عنه", "تنبيه حذف مجلد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (Resualt == DialogResult.Yes)
                        {
                            DeletingChildNode(int.Parse(tbnode2.Text), int.Parse(tbnode1.Text));
                            SelectedNode.Remove();
                            LoadData.Start();
                        }
                        else
                        {
                            return;
                        }

                    }
                    else
                    {
                        DeletingChildNode(int.Parse(tbnode2.Text), int.Parse(tbnode1.Text));
                        MessageBox.Show("تم الحذف بنجاح", "حذف مجلد", MessageBoxButtons.OK, MessageBoxIcon.None);
                        SelectedNode.Remove();
                        LoadData.Start();
                    }

                }
            }
            else if (LbMenu.Text == "اضافة دليل" || LbMenu.Text == "اضافة فرع")
            {
                var SelectedNode = Tr.SelectedNode;
                if (SelectedNode.Parent == null)
                {
                    CLS_FRMS.Treeandthatyia CheckMaintree = new CLS_FRMS.Treeandthatyia();
                    DataTable Dtmain = CheckMaintree.TreenodeCheckMain(tbnode1.Text);

                    CLS_FRMS.Treeandthatyia Getindex = new CLS_FRMS.Treeandthatyia();
                    DataTable Dtindex = Getindex.TreeIndexOfName();

                    if (Dtmain.Rows.Count == 0)
                    {
                        int x;
                        x = int.Parse(DateTime.Now.Year.ToString());
                        tbnode2.Text = Dtindex.Rows[0][0].ToString();
                        CLS_FRMS.Treeandthatyia AddMainNode = new CLS_FRMS.Treeandthatyia();
                        AddMainNode.TreeAddMain(int.Parse(tbnode2.Text), tbnode1.Text, x);

                        CLS_FRMS.WorkingProperties GuidProperties = new WorkingProperties();
                        DataTable DtGuid = GuidProperties.ThatyiaPropertiesSelectingByGuidTow(tbnode1.Text);
                        if (DtGuid.Rows.Count > 0)
                        {
                            return;
                        }
                        else
                        {
                            GuidProperties.ThatyiaPropertiesinsertingTow(int.Parse(tbnode2.Text), tbnode1.Text);
                        }

                        LoadData.Start();



                    }
                    else
                    {
                        MessageBox.Show("لايمكن انشاء هذا الدليل، هذا الدليل موجود مسبقا", "اعادة تسمية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Tr.SelectedNode.Remove();

                    }
                }
                else
                {
                    CLS_FRMS.Treeandthatyia CheckTree = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = CheckTree.TreeChecking(int.Parse(tbnode2.Text), int.Parse(tbnode1.Text));
                    if (Dt.Rows.Count > 0)
                    {
                        MessageBox.Show("لا يمكن انشاء هذا المجلد، هذا المجلد موجود مسبقا", "انشاء مجلد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Tr.SelectedNode.Remove();

                        MessageBox.Show(Dt.Rows[0][0].ToString()+" "+ Dt.Rows[0][1].ToString());
                    }
                    else
                    {
                        CLS_FRMS.Treeandthatyia TreeAdding = new CLS_FRMS.Treeandthatyia();
                        TreeAdding.TreeAddingChild(int.Parse(tbnode2.Text), int.Parse(tbnode1.Text), Tr.SelectedNode.Parent.Text);


                    }
                }

            }


        }
        //============================================================================================================================
        //=== This Function Below for Update TreeNodeMain in treeview Treeone....
        public void TreeUpdate(string TypeName, int indexofname)
        {
            DAL.DataAccessLayer TrUpdate = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[0].Value = TypeName;
            param[1] = new SqlParameter("@indexofname", SqlDbType.Int); param[1].Value = indexofname;
            TrUpdate.open();
            TrUpdate.ExecuteCommand("TreeNodeMainUpdate", param);
            TrUpdate.close();

        }
        //================================================================================================================================
        //=== This Function Below for Update TreeNodeChild in treeview Treeone....
        public void TreeUpdateChild(int yearNew, int yearold, int indexofname)
        {
            DAL.DataAccessLayer TrUpdate = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@yearname", SqlDbType.Int); param[0].Value = yearNew;
            param[1] = new SqlParameter("@yearNameold", SqlDbType.Int); param[1].Value = yearold;
            param[2] = new SqlParameter("@Indexofname", SqlDbType.Int); param[2].Value = indexofname;
            TrUpdate.open();
            TrUpdate.ExecuteCommand("TreeNodeChildUpdate", param);
            TrUpdate.close();

        }
        //================================================================================================================================
        //== This function Below for Check Main node in treeView Treeone For Deleting.....
        public DataTable CheckMainNodeForDeleting(string TypeName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50); param[0].Value = TypeName;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeCheckMainForDeleting", param);
            dal.close();
            return Dt;
        }
        //==========================================================================================================
        //=== This Function Below for Check Child Node in TreeView Treeone For Deleting....
        public DataTable CheckChildNodeForDeleting(int IndexOfName, int YearFolder)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IndexOfName", SqlDbType.Int); param[0].Value = IndexOfName;
            param[1] = new SqlParameter("@YearFolder", SqlDbType.Int); param[1].Value = YearFolder;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeCheckChildForDeleting", param);
            dal.close();
            return Dt;
        }
        //============================================================================================================
        //=== This Function below for Deleting MainNode in TreeView Treeone....
        public void DeletingMainNode(int IndexOfName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IndexOfName", SqlDbType.Int); param[0].Value = IndexOfName;
            dal.open();
            dal.ExecuteCommand("TreeMainDeleting", param);
            dal.close();
        }
        //=============================================================================================================
        //=== This Function Below for delting ChildNode int treeview Treeone....
        public void DeletingChildNode(int IndexOfName, int YearName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@indexofname", SqlDbType.Int); param[0].Value = IndexOfName;
            param[1] = new SqlParameter("@YearName", SqlDbType.Int); param[1].Value = YearName;
            dal.open();
            dal.ExecuteCommand("TreeChildDeleting", param);
            dal.close();
        }
        //==============================================================================================================
        //=== this function below for Getting Data from Thatyia2 table by using listview ....
        public DataTable thatyia2selectbylistview(string Pathimage, TextBox archtb1, TextBox archtb2, TextBox archtb3, TextBox archtb4,
             TextBox archtb5, TextBox archtb6, TextBox archtb7, TextBox archtb8, TextBox archtb9, Panel pn)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PathImage", SqlDbType.Text);              param[0].Value = Pathimage;
            dal.open();
            DataTable Dt = dal.SelectingData("Thatyia2GetDatabyListView", param);
            dal.close();
            foreach (Control p in pn.Controls) { if (p is TextBox) { p.DataBindings.Clear(); } }
            string str = "text";
            archtb1.DataBindings.Add(str, Dt, "IDindex");
            archtb2.DataBindings.Add(str, Dt, "IDcon");
            archtb3.DataBindings.Add(str, Dt, "TypeName");
            archtb4.DataBindings.Add(str, Dt, "Year_Exp_Imp");
            archtb5.DataBindings.Add(str, Dt, "BookNumber");
            archtb6.DataBindings.Add(str, Dt, "PathImage");
            archtb7.DataBindings.Add(str, Dt, "RegisterName");
            archtb8.DataBindings.Add(str, Dt, "AddingDate");
            archtb9.DataBindings.Add(str, Dt, "AddingTime");


            return Dt;
        }
        //=================================================================================================================
        // == This Function Below for Selectio Data From Tb_thatyiaAttention Table , Using by ThatyiaAttentionSelection 
        // Stored Procedure.....
        public DataTable ThatyiaAttentionSelectionData(int IDconAttention,DevExpress.XtraEditors.TextEdit TbAttenID,DevExpress.XtraEditors.TextEdit TbAttenIDcon
            ,DevExpress.XtraEditors.TextEdit TbTypeAttention,DevExpress.XtraEditors.TextEdit TbAttentionNumber,DevExpress.XtraEditors.DateEdit TbAttentionDate
            ,DevExpress.XtraEditors.ToggleSwitch TbAfterAttention,DevExpress.XtraEditors.ToggleSwitch TbBeforeAttention,NumericUpDown TbAttentionPeriod
            ,DevExpress.XtraEditors.ToggleSwitch TbAttentionFinishing,DevExpress.XtraEditors.TextEdit TbAttenRegisterName,DevExpress.XtraEditors.TextEdit TbAttenAddingTime
            ,DevExpress.XtraEditors.TextEdit TbAttenAddingDate,RichTextBox TbAttentionNotice,DevExpress.XtraEditors.GroupControl GroupAttention ,  DevExpress.XtraEditors.TextEdit TbAttenYear)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                   param[0].Value = IDconAttention;
            dal.open();
            DataTable Dt = dal.SelectingData("ThatyiaAttentionSelection", param);
            dal.close();
            foreach (Control item in GroupAttention.Controls)
            {
                item.DataBindings.Clear();
            }

            TbAttenID.DataBindings.Clear();
            TbAttenIDcon.DataBindings.Clear();
            TbTypeAttention.DataBindings.Clear();
            TbAttentionNumber.DataBindings.Clear();
            TbAttentionDate.DataBindings.Clear();
            TbAfterAttention.DataBindings.Clear();
            TbBeforeAttention.DataBindings.Clear();
            TbAttentionPeriod.DataBindings.Clear();
            TbAttentionNotice.DataBindings.Clear();
            TbAttentionFinishing.DataBindings.Clear();
            TbAttenRegisterName.DataBindings.Clear();
            TbAttenAddingTime.DataBindings.Clear();
            TbAttenAddingDate.DataBindings.Clear();
            TbAttenYear.DataBindings.Clear();

            string st = "Text";
            TbAttenID.DataBindings.Add(st, Dt, "IDThatyiaAttention");
            TbAttenIDcon.DataBindings.Add(st, Dt, "IDcon");
            TbTypeAttention.DataBindings.Add(st, Dt, "TypeAttention");
            TbAttentionNumber.DataBindings.Add(st, Dt, "TypeNumber");
            TbAttentionDate.DataBindings.Add(st, Dt, "AttentionDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            TbAfterAttention.DataBindings.Add(st, Dt, "AfterAttentionDate");
            TbBeforeAttention.DataBindings.Add(st, Dt, "BeforeAttentionDate");
            TbAttentionPeriod.DataBindings.Add(st, Dt, "AttentionPeriod");
            TbAttentionNotice.DataBindings.Add(st, Dt, "AttentionNotice");
            TbAttentionFinishing.DataBindings.Add(st, Dt, "AttentionFinishing");
            TbAttenRegisterName.DataBindings.Add(st, Dt, "AttregisterName");
            TbAttenAddingTime.DataBindings.Add(st, Dt, "AttAddingTime");
            TbAttenAddingDate.DataBindings.Add(st, Dt, "AttAddingDate");
            TbAttenYear.DataBindings.Add(st,Dt, "Year_Exp_Imp");

            if (Dt.Rows.Count > 0)
            {
           
            if (Dt.Rows[0][5].ToString() == "True") { TbAfterAttention.IsOn = true; }
            else { TbAfterAttention.IsOn = false; }
            if (Dt.Rows[0][6].ToString() == "True") { TbBeforeAttention.IsOn = true; }
            else { TbBeforeAttention.IsOn = false; }
            if (Dt.Rows[0][9].ToString() == "True") { TbAttentionFinishing.IsOn = true; }
            else { TbAttentionFinishing.IsOn = false; }
            }
            else
            {
               
            }


            return Dt;
        }
        //==============================================================================================================================
        //== This Function Below For insert data to the ThatyiaAttention Tabel using by StordProcedure ThatyiaAttentioninserting
        public  void ThatyiaAttentionInsertingData(int IDcon,string TypeAttention,string TypeNumber,string AttentionDate,bool AfterAttention
            ,bool BeforeAttention,int AttentionPeriod,string AttentionNotice,bool AttentionFinishing,string AttRegisterName,string AttAddingTime
            ,string AttAddingDate,int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                               param[0].Value = IDcon;
            param[1] = new SqlParameter("@TypeAttention", SqlDbType.VarChar, 50);               param[1].Value = TypeAttention;
            param[2] = new SqlParameter("@TypeNumber", SqlDbType.VarChar, 50);                  param[2].Value = TypeNumber;
            param[3] = new SqlParameter("@AttentionDate",SqlDbType.Date );                      param[3].Value = AttentionDate;
            param[4] = new SqlParameter("@AfterAttentionDate", SqlDbType.Bit);                  param[4].Value = AfterAttention;
            param[5] = new SqlParameter("@BeforeAttentionDate", SqlDbType.Bit);                 param[5].Value = BeforeAttention;
            param[6] = new SqlParameter("@AttentionPeriod", SqlDbType.Int);                     param[6].Value = AttentionPeriod;
            param[7] = new SqlParameter("@AttentionNotice", SqlDbType.Text);                    param[7].Value = AttentionNotice;
            param[8] = new SqlParameter("@AttentionFinishing", SqlDbType.Bit);                  param[8].Value = AttentionFinishing;
            param[9] = new SqlParameter("@AttRegisterName", SqlDbType.VarChar, 50);             param[9].Value = AttRegisterName;
            param[10] = new SqlParameter("@AttAddingTime", SqlDbType.VarChar, 50);              param[10].Value = AttAddingTime;
            param[11] = new SqlParameter("@AttAddingDate", SqlDbType.VarChar, 50);              param[11].Value = AttAddingDate;
            param[12] = new SqlParameter("@year", SqlDbType.Int);                               param[12].Value = year;
            dal.open();
            dal.ExecuteCommand("ThatyiaAttentionInserting", param);
            dal.close();

        }
        //================================================================================================================================
        //=== this function below for Updatting data fo thatyiaAttention tabel using storedprocedure ThatyiaAttentionupdatting....
        public void ThatyiaAttentionUpdattingDate(int IDcon, string TypeAttention, string TypeNumber, string AttentionDate, bool AfterAttention
            , bool BeforeAttention, int AttentionPeriod, string AttentionNotice, bool AttentionFinishing, string AttRegisterName, string AttAddingTime
            , string AttAddingDate,int IDAttention,int year)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int);                               param[0].Value = IDcon;
            param[1] = new SqlParameter("@TypeAttention", SqlDbType.VarChar, 50);               param[1].Value = TypeAttention;
            param[2] = new SqlParameter("@TypeNumber", SqlDbType.VarChar, 50);                  param[2].Value = TypeNumber;
            param[3] = new SqlParameter("@AttentionDate", SqlDbType.Date);                      param[3].Value = AttentionDate;
            param[4] = new SqlParameter("@AfterAttentionDate", SqlDbType.Bit);                  param[4].Value = AfterAttention;
            param[5] = new SqlParameter("@BeforeAttentionDate", SqlDbType.Bit);                 param[5].Value = BeforeAttention;
            param[6] = new SqlParameter("@AttentionPeriod", SqlDbType.Int);                     param[6].Value = AttentionPeriod;
            param[7] = new SqlParameter("@AttentionNotice", SqlDbType.Text);                    param[7].Value = AttentionNotice;
            param[8] = new SqlParameter("@AttentionFinishing", SqlDbType.Bit);                  param[8].Value = AttentionFinishing;
            param[9] = new SqlParameter("@AttRegisterName", SqlDbType.VarChar, 50);             param[9].Value = AttRegisterName;
            param[10] = new SqlParameter("@AttAddingTime", SqlDbType.VarChar, 50);              param[10].Value = AttAddingTime;
            param[11] = new SqlParameter("@AttAddingDate", SqlDbType.VarChar, 50);              param[11].Value = AttAddingDate;
            param[12] = new SqlParameter("@IDAtten", SqlDbType.Int);                            param[12].Value = IDAttention;
            param[13] = new SqlParameter("@year", SqlDbType.Int);                               param[13].Value = year;
            dal.open();
            dal.ExecuteCommand("ThatyiaAttentionUpdatting", param);
            dal.close();
        }
        //===================================================================================================================================
        //=== this function below for Deleting from thatyiaattention tabel using stored procedure [ThatyiaAttentionDeleting]...
        public  void ThatyiaAttentionDelettingData(int IDAttention)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDAtten", SqlDbType.Int);                             param[0].Value = IDAttention;
           
            dal.open();
            dal.ExecuteCommand("ThatyiaAttentionDeleting", param);
            dal.close();
        }
        //===============================================================================================================================
        //===this function below for get file icon
        public Image iconfile(string fileex)
        {
            List<string> exWord = new List<string>(new string[] { ".doc", ".doc", ".wbk" , ".docx", ".docm", ".dotx" , ".dotm" , ".docb" });

            List<string> exExcel = new List<string>(new string[] { ".xls", ".xlt", ".xlm", ".xlsx", ".xlsm", ".xltx", ".xltm", ".xlsb", ".xla", ".xlam", ".xll", ".xlw" });

            List<string> exVideo = new List<string>(new string[] { ".webm", ".mkv", ".flv", ".vob", ".ogv", ".ogg", ".drc", ".gif" , ".gifv", ".mng", ".avi", ".MTS", ".M2TS", ".TS",
                ".mov", ".qt", ".wmv", ".yuv", ".rm", ".rmvb", ".asf", ".amv", ".mp4", ".m4p ", ".m4v", ".mpg", ".mp2", ".mpeg", ".mpe", ".mpv" ,
                ".mpg", ".mpeg", ".m2v", ".m4v", ".svi", ".3gp", ".3g2", ".mxf", ".roq", ".nsv", ".flv", ".f4v" , ".f4p", ".f4a", ".f4b"});

            List<string> exPowerPoint = new List<string>(new string[] { ".ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx", ".potm", ".ppam", ".ppsx", ".ppsm", ".sldx", ".sldm" });

            List<string> exAudio = new List<string>(new string[] { ".3gp", ".aa", ".aac", ".aax", ".act", ".aiff", ".alac", ".amr" , ".ape", ".au", ".awb", ".dct", ".dss", ".dvf",
                ".flac", ".gsm", ".iklax", ".ivs", ".m4a", ".m4b", ".m4p", ".mmf", ".mp3", ".mpc ", ".msv", ".nmf", ".nsf", ".mogg", ".oga", ".ogg" ,
                ".opus", ".rm", ".ra", ".raw", ".rf64", ".sln", ".tta", ".voc", ".vox", ".wav", ".wma", ".wv" , ".webm", ".8svx", ".cda" });

            if (exWord.Contains(fileex))
                return Properties.Resources.word;
            if (exExcel.Contains(fileex))
                return Properties.Resources.excel;
            if (exVideo.Contains(fileex))
                return Properties.Resources.video;
            if (exPowerPoint.Contains(fileex))
                return Properties.Resources.powerpoint;
            if (exAudio.Contains(fileex))
                return Properties.Resources.audio;
            if (fileex==".pdf")
                return Properties.Resources.pdf;
            if (fileex == ".txt")
                return Properties.Resources.txt;

            return Properties.Resources.الاليات;
        }

       
    }

}
