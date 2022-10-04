using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MechanismsCD.CLS_FRMS
{
    class ProcessingDataBase
    {
        public DataTable documentWared()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("Wared1", null);
            dal.close();
            return Dt;
        }

        public DataTable documentWared2(int IDcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("Wared2", param);
            dal.close();
            return Dt;
        }

        public DataTable Getmaxid()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("Getmaxid", null);
            dal.close();
            return Dt;
        }


        //=============================================================================================
        public void TB_Adding(int ID_exp,int indexofname, string typename, int yeardoc, string ImportNo,
            string BookTitle,
           string FromDe, string ToDe, string BookDetails, string signature, string signaturepath,
           string RegisterName, string AddingTime, string AddingDate, string BookNo2,  string Murfaqat)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@IndexofName", SqlDbType.Int);                 param[0].Value = indexofname;
            param[1] = new SqlParameter("@TypeName", SqlDbType.VarChar, 50);            param[1].Value = typename;
            param[2] = new SqlParameter("@Year", SqlDbType.Int);                        param[2].Value = yeardoc;
            param[3] = new SqlParameter("@ImportNo", SqlDbType.VarChar, 50);            param[3].Value = ImportNo;
            //param[4] = new SqlParameter("@ImportDate", SqlDbType.VarChar,50);           param[4].Value = ImportDate;
            param[4] = new SqlParameter("@BookTitile", SqlDbType.NText);                param[4].Value = BookTitle;
            param[5] = new SqlParameter("@FromDe", SqlDbType.VarChar, 50);              param[5].Value = FromDe;
            param[6] = new SqlParameter("@ToDe", SqlDbType.Text);                       param[6].Value = ToDe;
            param[7] = new SqlParameter("@BookDetails", SqlDbType.NText);               param[7].Value = BookDetails;
            param[8] = new SqlParameter("@signatur", SqlDbType.VarChar, 50);            param[8].Value = signature;
            param[9] = new SqlParameter("@signaturepath", SqlDbType.Text);             param[9].Value = signaturepath;
            param[10] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);       param[10].Value = RegisterName;
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);         param[11].Value = AddingTime;
            param[12] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);         param[12].Value = AddingDate;
            param[13] = new SqlParameter("@BookNo2", SqlDbType.VarChar, 50);            param[13].Value = BookNo2;
            //param[14] = new SqlParameter("@BookDate2", SqlDbType.VarChar, 50);          param[14].Value = BookDate2;
            param[14] = new SqlParameter("@Murfaqat", SqlDbType.Text);                  param[14].Value = Murfaqat;
            param[15] = new SqlParameter("@ID_Exp", SqlDbType.Int);                     param[15].Value = ID_exp;
            dal.open();
            dal.ExecuteCommand("wared4", param);
            dal.close();

        }

        //==================================================================================================

        public void UpdateWared1(int IDnew ,int IDold)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDnew", SqlDbType.Int);param[0].Value = IDnew;
            param[1] = new SqlParameter("@IDold", SqlDbType.Int);param[1].Value = IDold;
            dal.open();
            dal.ExecuteCommand("WaredUpdate", param);
            dal.close();
        }

        public void UpdateWared2(int IDnew, int IDold)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IDnew", SqlDbType.Int); param[0].Value = IDnew;
            param[1] = new SqlParameter("@IDold", SqlDbType.Int); param[1].Value = IDold;
            dal.open();
            dal.ExecuteCommand("Wared2Update", param);
            dal.close();
        }


    }
}
