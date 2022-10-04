using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MechanismsCD.CLS_FRMS
{
    class WorkingProperties
    {
        /* This Functions Below For Properties of Archieve Working...
         * insert function, update function ,select function  And deleting
         * These function use in gui of Archieve to hide or display what we want.
         * 
         * */
         public DataTable ThatyiaPropertiesSelecting()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("ThatyiaPropertiesSelecting", null);
            dal.close();
            return Dt;
        }
        //=========
        public void ThatyiaPropertiesinserting(int indexvalue,string GuidName,bool Pimportno,bool Pbookno,bool Pbookdate,
            bool Pimportdate,bool Phijriday,bool Phijrimont,bool Phijriyear,bool Psignature,bool Psignaturepath,
            bool Pmurfaqat,bool pbooktitle,bool Pfromde,bool ptode,bool Precieve,bool Pbookdetail,bool Pbook2no,bool Pbook2date
            ,bool Pregistername,bool Paddingtime,bool Paddingdate)
            
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@IndexValue", SqlDbType.Int);              param[0].Value = indexvalue;
            param[1] = new SqlParameter("GuidName", SqlDbType.VarChar,50);          param[1].Value = GuidName;
            param[2] = new SqlParameter("@PimportNo", SqlDbType.Bit);               param[2].Value = Pimportno;
            param[3] = new SqlParameter("@PimportDate", SqlDbType.Bit);             param[3].Value = Pimportdate;
            param[4] = new SqlParameter("@Pbookno", SqlDbType.Bit);                 param[4].Value = Pbookno;
            param[5] = new SqlParameter("@Pbookdate", SqlDbType.Bit);               param[5].Value = Pbookdate;
            param[6] = new SqlParameter("@Phijriday", SqlDbType.Bit);               param[6].Value = Phijriday;
            param[7] = new SqlParameter("@Phijrimonth", SqlDbType.Bit);             param[7].Value = Phijrimont;
            param[8] = new SqlParameter("@Phijriyear", SqlDbType.Bit);              param[8].Value = Phijriyear;
            param[9] = new SqlParameter("@Psingnature", SqlDbType.Bit);             param[9].Value = Psignature;
            param[10] = new SqlParameter("@Psignaturepath", SqlDbType.Bit);         param[10].Value = Psignaturepath;
            param[11] = new SqlParameter("@Pmorfaqat", SqlDbType.Bit);              param[11].Value = Pmurfaqat;
            param[12] = new SqlParameter("@Pbooktitle", SqlDbType.Bit);             param[12].Value = pbooktitle;
            param[13] = new SqlParameter("@Pfromde", SqlDbType.Bit);                param[13].Value = Pfromde;
            param[14] = new SqlParameter("@Ptode", SqlDbType.Bit);                  param[14].Value = ptode;
            param[15] = new SqlParameter("@Precievedate", SqlDbType.Bit);           param[15].Value = Precieve;
            param[16] = new SqlParameter("@Pbookdetail", SqlDbType.Bit);            param[16].Value = Pbookdetail;
            param[17] = new SqlParameter("@Pbook2no", SqlDbType.Bit);               param[17].Value = Pbook2no;
            param[18] = new SqlParameter("@Pbook2date", SqlDbType.Bit);             param[18].Value = Pbook2date;
            param[19] = new SqlParameter("@Pregistername", SqlDbType.Bit);          param[19].Value = Pregistername;
            param[20] = new SqlParameter("@Paddingtime", SqlDbType.Bit);            param[20].Value = Paddingtime;
            param[21] = new SqlParameter("@Paddingdate", SqlDbType.Bit);            param[21].Value = Paddingdate;
            dal.open();
            dal.ExecuteCommand("ThatyiaPropertiesinserting", param);
            dal.close();

        }
        //===========================
        public void ThatyiaPropertiesUpdatting(int indexvalue, string GuidName, bool Pimportno,bool Pimportdate, 
           bool Pbookno, bool Pbookdate, bool Phijriday, bool Phijrimont, bool Phijriyear, bool Psignature, bool Psignaturepath,
           bool Pmurfaqat, bool pbooktitle, bool Pfromde, bool ptode, bool Precieve, bool Pbookdetail, bool Pbook2no, bool Pbook2date
           , bool Pregistername, bool Paddingtime, bool Paddingdate,int IDproperties)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[23];
            param[0] = new SqlParameter("@IndexValue", SqlDbType.Int);                  param[0].Value = indexvalue;
            param[1] = new SqlParameter("GuidName", SqlDbType.VarChar,50);              param[1].Value = GuidName;
            param[2] = new SqlParameter("@PimportNo", SqlDbType.Bit);                   param[2].Value = Pimportno;
            param[3] = new SqlParameter("@PimportDate", SqlDbType.Bit);                 param[3].Value = Pimportdate;
            param[4] = new SqlParameter("@Pbookno", SqlDbType.Bit);                     param[4].Value = Pbookno;
            param[5] = new SqlParameter("@Pbookdate", SqlDbType.Bit);                   param[5].Value = Pbookdate;
            param[6] = new SqlParameter("@Phijriday", SqlDbType.Bit);                   param[6].Value = Phijriday;
            param[7] = new SqlParameter("@Phijrimonth", SqlDbType.Bit);                 param[7].Value = Phijrimont;
            param[8] = new SqlParameter("@Phijriyear", SqlDbType.Bit);                  param[8].Value = Phijriyear;
            param[9] = new SqlParameter("@Psingnature", SqlDbType.Bit);                 param[9].Value = Psignature;
            param[10] = new SqlParameter("@Psignaturepath", SqlDbType.Bit);             param[10].Value = Psignaturepath;
            param[11] = new SqlParameter("@Pmorfaqat", SqlDbType.Bit);                  param[11].Value = Pmurfaqat;
            param[12] = new SqlParameter("@Pbooktitle", SqlDbType.Bit);                 param[12].Value = pbooktitle;
            param[13] = new SqlParameter("@Pfromde", SqlDbType.Bit);                    param[13].Value = Pfromde;
            param[14] = new SqlParameter("@Ptode", SqlDbType.Bit);                      param[14].Value = ptode;
            param[15] = new SqlParameter("@Precievedate", SqlDbType.Bit);               param[15].Value = Precieve;
            param[16] = new SqlParameter("@Pbookdetail", SqlDbType.Bit);                param[16].Value = Pbookdetail;
            param[17] = new SqlParameter("@Pbook2no", SqlDbType.Bit);                   param[17].Value = Pbook2no;
            param[18] = new SqlParameter("@Pbook2date", SqlDbType.Bit);                 param[18].Value = Pbook2date;
            param[19] = new SqlParameter("@Pregistername", SqlDbType.Bit);              param[19].Value = Pregistername;
            param[20] = new SqlParameter("@Paddingtime", SqlDbType.Bit);                param[20].Value = Paddingtime;
            param[21] = new SqlParameter("@Paddingdate", SqlDbType.Bit);                param[21].Value = Paddingdate;
            param[22] = new SqlParameter("@IDproperties", SqlDbType.Int);               param[22].Value = IDproperties;
            dal.open();
            dal.ExecuteCommand("ThatyiaPropertiesUpdating", param);
            dal.close();

        }
        //==================================
        public void ThatyiaPropertiesDeleting(string GuidName)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            
            param[0] = new SqlParameter("@GuidName", SqlDbType.VarChar,50);                        param[0].Value = GuidName;
            dal.open();
            dal.ExecuteCommand("ThatyiaPropertiesDeleting", param);
            dal.close();

        }
        //====================================
        //==== This funcion below for Selecting Data By GuidName 
        public DataTable ThatyiaPropertiesSelectingByGuid(string GuidName,CheckedListBoxControl lst,TextBox tbindexofvalue  ,TextBox tbidproperties
            ,TextBox tbguidname)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@GuidName", SqlDbType.VarChar,50);                         param[0].Value = GuidName;
            dal.open();
            DataTable Dt= dal.SelectingData("ThatyiaPropertiesSelectingbyGuidName", param);
            dal.close();

            lst.DataBindings.Clear();
            lst.Items.Clear();
            for (int i = 3; i < Dt.Columns.Count; i++)
            {
                if( Dt.Rows[0][i].ToString() != "True" || Dt.Rows[0][i].ToString() ==null || Dt.Rows[0][i].ToString()=="")
                {
                    lst.Items.Add(Dt.Columns[i].ColumnName, false);
                }
                else
                {
                    lst.Items.Add(Dt.Columns[i].ColumnName, true);
                }
            }
            tbindexofvalue.DataBindings.Clear();tbidproperties.DataBindings.Clear();tbguidname.DataBindings.Clear();
            tbindexofvalue.DataBindings.Add("text", Dt, "IndexValue");
            tbidproperties.DataBindings.Add("text", Dt, "ID");
            tbguidname.DataBindings.Add("text", Dt, "GuidName");

            return Dt;
        }
        //==================
        public void ThatyiaPropertiesinsertingTow(int indexvalue, string GuidName)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IndexValue", SqlDbType.Int);                  param[0].Value = indexvalue;
            param[1] = new SqlParameter("@GuidName", SqlDbType.VarChar, 50);             param[1].Value = GuidName;
            dal.open();
            dal.ExecuteCommand("ThatyiaPropertiesInsertingbytow", param);
            dal.close();

        }
        //================
        public void ThatyiaPropertiesUpdattingTow(int indexvalue, string GuidName)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IndexValue", SqlDbType.Int);                  param[0].Value = indexvalue;
            param[1] = new SqlParameter("@GuidName", SqlDbType.VarChar, 50);             param[1].Value = GuidName;
            dal.open();
            dal.ExecuteCommand("ThatyiaPropertiesUpdattingTow", param);
            dal.close();

        }
        //================
        public DataTable ThatyiaPropertiesSelectingByGuidTow(string GuidName)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GuidName", SqlDbType.VarChar, 50);             param[0].Value = GuidName;
            dal.open();
            DataTable Dt=dal.SelectingData("ThatyiaPropertiesSelectingByGuidTow", param);
             dal.close();
            return Dt;

        }
        //==================
        //=== Apply Properties of ThayiaGuid
        
        public  DataTable ThatyiaPropertiesExecute(string GuidName,TextBox tbimportNo,DateTimePicker tbimportdate,TextBox tbbookno,DateTimePicker tbbookdate
            ,TextBox tbhijriday,System.Windows.Forms.ComboBox tbhijrimont,TextBox tbhijriyear,TextBox tbsingnature,TextBox tbsignaturepath
            ,RichTextBox tbmorfaqat,System.Windows.Forms.ComboBox tbbooktitle,System.Windows.Forms.ComboBox tbfromde
            ,System.Windows.Forms.ComboBox tbtode,DateTimePicker tbrecieve,RichTextBox tbbookdetail,TextBox tbbook2no,
            DateTimePicker tbbook2date,TextBox tbregistername,TextBox tbaddingtime,TextBox tbaddingdate,DevExpress.XtraEditors.SimpleButton btnprint
            ,Label lbimportno,Label lbimportdate,Label lbbookno,Label lbbookdate,Label lbhijriday,Label lbhijrimonth,Label lbhijriyear,Label lbsignature
            ,Label lbmorfaqat,Label lbbooktitle,Label lbfromde,Label lbtode,Label lbrecieve,Label lbbookdetails,Label lbbook2no,Label lbbook2date,
            Label lbregistername,Label lbaddingtime,Label lbaddingdate,TextBox tbnode11,TextBox tbnode22,PictureBox sin)
            
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1]; 
            param[0] = new SqlParameter("@GuidName", SqlDbType.VarChar, 50);                  param[0].Value = GuidName;
            dal.open();
            DataTable Dt = dal.SelectingData("ThatyiaPropertiesSelectiongGuidThree", param);
            dal.close();
            if(Dt.Rows.Count>0)
            {
                if (Dt.Rows[0][3].ToString() == "True") { tbimportNo.Visible = true;tbnode11.Visible = true; lbimportno.Visible = true; }
                else { tbimportNo.Visible = false;tbnode11.Visible = false; lbimportno.Visible = false; }
                if (Dt.Rows[0][4].ToString() == "True") { tbimportdate.Visible = true;lbimportdate.Visible = true; }
                else { tbimportdate.Visible = false;lbimportdate.Visible = false; }
                if (Dt.Rows[0][5].ToString() == "True") { tbbookno.Visible = true;tbnode22.Visible = true; lbbookno.Visible = true; }
                else { tbbookno.Visible = false; tbnode22.Visible = false; lbbookno.Visible = false; }
                if (Dt.Rows[0][6].ToString() == "True") { tbbookdate.Visible = true; lbbookdate.Visible = true; }
                else { tbbookdate.Visible = false; lbbookdate.Visible = false; }
                if (Dt.Rows[0][7].ToString() == "True") { tbhijriday.Visible = true; lbhijriday.Visible = true; }
                else { tbhijriday.Visible = false; lbhijriday.Visible = false; lbhijriday.Visible = false; }
                if (Dt.Rows[0][8].ToString() == "True") { tbhijrimont.Visible = true;lbhijrimonth.Visible = true; }
                else { tbhijrimont.Visible = false;lbhijrimonth.Visible = false; }
                if (Dt.Rows[0][9].ToString() == "True") { tbhijriyear.Visible = true;lbhijriyear.Visible = true; }
                else { tbhijriyear.Visible = false;lbhijriyear.Visible = false; }
                if (Dt.Rows[0][10].ToString() == "True") { tbsingnature.Visible = true; lbsignature.Visible = true;sin.Visible = true; }
                else { tbsingnature.Visible = false; lbsignature.Visible = false;sin.Visible = false; }
                if (Dt.Rows[0][11].ToString() == "True") { tbsignaturepath.Visible = true; }
                else { tbsignaturepath.Visible = false; }
                if (Dt.Rows[0][12].ToString() == "True") { tbmorfaqat.Visible = true;lbmorfaqat.Visible = true; }
                else { tbmorfaqat.Visible = false; lbmorfaqat.Visible = false; }
                if (Dt.Rows[0][13].ToString() == "True") { tbbooktitle.Visible = true; lbbooktitle.Visible = true; }
                else { tbbooktitle.Visible = false; lbbooktitle.Visible = false; }
                if (Dt.Rows[0][14].ToString() == "True") { tbfromde.Visible = true;lbfromde.Visible = true; }
                else { tbfromde.Visible = false;lbfromde.Visible = false; }
                if (Dt.Rows[0][15].ToString() == "True") { tbtode.Visible = true;lbtode.Visible = true; }
                else { tbtode.Visible = false;lbtode.Visible = false; }
                if (Dt.Rows[0][16].ToString() == "True") { tbrecieve.Visible = true;lbrecieve.Visible = true; }
                else { tbrecieve.Visible = false;lbrecieve.Visible = false; }
                if (Dt.Rows[0][17].ToString() == "True") { tbbookdetail.Visible = true;lbbookdetails.Visible = true; }
                else { tbbookdetail.Visible = false;lbbookdetails.Visible = false; }
                if (Dt.Rows[0][18].ToString() == "True") { tbbook2no.Visible = true;lbbook2no.Visible = true; }
                else { tbbook2no.Visible = false;lbbook2no.Visible = false; }
                if (Dt.Rows[0][19].ToString() == "True") { tbbook2date.Visible = true;lbbook2date.Visible = true; }
                else { tbbook2date.Visible = false; lbbook2date.Visible = false; }
                if (Dt.Rows[0][20].ToString() == "True") { tbregistername.Visible = true;lbregistername.Visible = true; }
                else { tbregistername.Visible = false;lbregistername.Visible = false; }
                if (Dt.Rows[0][21].ToString() == "True") { tbaddingdate.Visible = true;lbaddingdate.Visible = true; }
                else { tbaddingdate.Visible = false;lbaddingdate.Visible = false; }
                if (Dt.Rows[0][22].ToString() == "True") { tbaddingtime.Visible = true;lbaddingtime.Visible = true; }
                else { tbaddingtime.Visible = false;lbaddingtime.Visible = false; }


            }
            else
            {

            }
            
            return Dt;
        }

    }
}
