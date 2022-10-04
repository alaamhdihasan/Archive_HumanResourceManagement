using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Drawing;

namespace MechanismsCD.CLS_FRMS
{
    class CLSEMPLOYEES
    {
        //===================================================================
        //Select Employees ID and Name from employeeInfo 
        public DataTable SelectEmployees()
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = new DataTable();
            Dt = dal.SelectingData("EmployeesInfoSelect", null);
            dal.close();
            return Dt;
        }
        public DataTable Emp_RootNode(TreeView Emp_Tr)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("EmpRootNode", null);
            dal.close();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Emp_Tr.Nodes.Add("NodeName",Dt.Rows[i][0].ToString(),0,0);
            }
               
            return Dt;
        }
        //================================================
        public  DataTable EmpRootCheckNode(string Emptype)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emptype", SqlDbType.VarChar, 50);             param[0].Value = Emptype;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpRootCheckNode", param);
            dal.close();
            return Dt;

        }
        //===============================================

        public void EmpRootAddNewNode(string Emptype,string EmployeeName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Emptype", SqlDbType.VarChar, 50);             param[0].Value = Emptype;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);        param[1].Value =EmployeeName ;
            dal.open();
            dal.ExecuteCommand("EmpRootAddNewNode", param);
            dal.close();

        }
        //================================================
        public void EmpRootUpdattingNode(string OldName, string NewName)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@OldName", SqlDbType.VarChar, 50);             param[0].Value = OldName;
            param[1] = new SqlParameter("@NewName", SqlDbType.VarChar, 50);             param[1].Value = NewName;
            dal.open();
            dal.ExecuteCommand("EmpRootUpdateNode", param);
            dal.close();

        }
        //===================================================

        //===
        public void Emp_KeyDownEnter( Label LbMenueSelect,TextBox AStreenode,TextBox RenameNode,TreeView Emp_Tr)
        {
          switch(LbMenueSelect.Text)
            {
                case "اضافة دليل":
                    DataTable Dt = new DataTable();
                    Dt = EmpRootCheckNode(AStreenode.Text);
                    if(Dt.Rows.Count>0)
                    {
                        MessageBox.Show("لايمكن اضافة دليل بهذا الاسم, هذا الاسم موجود مسبقا", "رسالة تنبيهية لاضافة دليل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Emp_Tr.SelectedNode.Remove();
                    }
                    else
                    {
                        CLSEMPLOYEES AddNewNode = new CLSEMPLOYEES();
                        AddNewNode.EmpRootAddNewNode(AStreenode.Text,"");
                    }

                    break;
                case "اعادة تسمية":
                    DataTable Dtrename = new DataTable();
                    Dtrename = EmpRootCheckNode(AStreenode.Text);
                    if(Dtrename.Rows.Count>0)
                    {
                        MessageBox.Show("هذا الاسم موجود مسبقا", "رسالة تنبيهية لاعادة تسمية دليل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        CLSEMPLOYEES UpdateNode = new CLSEMPLOYEES();
                        UpdateNode.EmpRootUpdattingNode(RenameNode.Text, AStreenode.Text);
                    }
                    break;


            }
           

        }
        


        // ======== Build The Employee Interface =======================================================================================
        //========= This Function Below For Employee Form Using By EmployeeInformation Procedure==========================================
        public DataTable EmployeeInfoGetdata( string EmptypeTreeView,DataGridView DgvEmpInfo, TextBox empseq, TextBox empdocunopast, TextBox empdocunonew, ComboBox emptype, TextBox empidentityno
            , ComboBox empbloodtype, ComboBox empempsitu, ComboBox empbeneficiary, TextBox empregistername, ComboBox employeedawria, TextBox empemployeename
            , TextBox empsurname, ComboBox empjob, ComboBox empjobnow, ComboBox empdivision, ComboBox empunit, ComboBox empworkplace, ComboBox empsn
            , TextBox childrencount, ComboBox empwifetype, ComboBox empstudy, ComboBox emplaststudy, ComboBox emptaghsus, TextBox empmaharat, TextBox empoldwork
            , TextBox empoldworkplace, TextBox emplivenow, TextBox emplivesing, TextBox empoldliveplace, TextBox empjunsia, ComboBox empjunsiaplace
            , TextBox empshahada, ComboBox empshahadaplace, TextBox empbutaqasakan, ComboBox empmaqtabmu, TextBox empwatania, DateTimePicker empbirthdate
            , TextBox empbirthplace, TextBox emptaghweelno, DateTimePicker emptaghweeldate, TextBox empbarcode, TextBox empmobile1, TextBox empmobile2
            , ComboBox empdepartment, TextBox emppathimage, RichTextBox empnotice, PictureBox empimage, ComboBox employeeworktype, TableLayoutPanel pn7, TableLayoutPanel pn8, TableLayoutPanel pn9, TableLayoutPanel pn10)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_type", SqlDbType.VarChar, 50);                    param[0].Value = EmptypeTreeView;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeesInfoSelectData", param);
            dal.close();

            DgvEmpInfo.DataSource = null; DgvEmpInfo.DataSource = Dt; empimage.Image = null;

            foreach (Control p in pn7.Controls) { if (p is TextBox || p is ComboBox) { (p).DataBindings.Clear(); } }
            foreach (Control p2 in pn8.Controls) { if (p2 is TextBox || p2 is ComboBox) { (p2).DataBindings.Clear(); } }
            foreach (Control p4 in pn9.Controls) { if (p4 is TextBox || p4 is ComboBox) { (p4).DataBindings.Clear(); } }
            foreach (Control p6 in pn10.Controls) { if (p6 is TextBox || p6 is ComboBox || p6 is RichTextBox || p6 is DateTimePicker) { (p6).DataBindings.Clear(); } }


            empseq.DataBindings.Clear();
            emptype.DataBindings.Clear();
            empdocunopast.DataBindings.Clear();
            empdocunonew.DataBindings.Clear();
            empidentityno.DataBindings.Clear();
            empbloodtype.DataBindings.Clear();
            empempsitu.DataBindings.Clear();
            empbeneficiary.DataBindings.Clear();
            empregistername.DataBindings.Clear();
            employeedawria.DataBindings.Clear();
            empemployeename.DataBindings.Clear();
            empsurname.DataBindings.Clear();
            empjob.DataBindings.Clear();
            empjobnow.DataBindings.Clear();
            empdivision.DataBindings.Clear();
            empunit.DataBindings.Clear();
            empworkplace.DataBindings.Clear();
            empsn.DataBindings.Clear();
            childrencount.DataBindings.Clear();
            empwifetype.DataBindings.Clear();
            empstudy.DataBindings.Clear();
            emplaststudy.DataBindings.Clear();
            emptaghsus.DataBindings.Clear();
            empmaharat.DataBindings.Clear();
            empoldwork.DataBindings.Clear();
            empoldworkplace.DataBindings.Clear();
            emplivenow.DataBindings.Clear();
            emplivesing.DataBindings.Clear();
            empoldliveplace.DataBindings.Clear();
            empjunsia.DataBindings.Clear();
            empjunsiaplace.DataBindings.Clear();
            empshahada.DataBindings.Clear();
            empshahadaplace.DataBindings.Clear();
            empbutaqasakan.DataBindings.Clear();
            empmaqtabmu.DataBindings.Clear();
            empwatania.DataBindings.Clear();
            empbirthdate.DataBindings.Clear();
            empbirthplace.DataBindings.Clear();
            emptaghweelno.DataBindings.Clear();
            emptaghweeldate.DataBindings.Clear();
            empbarcode.DataBindings.Clear();
            empmobile1.DataBindings.Clear();
            empmobile2.DataBindings.Clear();
            empdepartment.DataBindings.Clear();
            emppathimage.DataBindings.Clear();
            empnotice.DataBindings.Clear();
            employeeworktype.DataBindings.Clear();


            empseq.DataBindings.Add("text", Dt, "Emp_ID");

            emptype.DataBindings.Add("text", Dt, "Emp_type");
            empdocunopast.DataBindings.Add("text", Dt, "Emp_DocNO");          
            empdocunonew.DataBindings.Add("text", Dt, "Emp_DocNOnew");                         
            empidentityno.DataBindings.Add("text", Dt, "Emp_IDentityNO");
            empbloodtype.DataBindings.Add("text", Dt, "Emp_BloodType");
            empempsitu.DataBindings.Add("Text", Dt, "Emp_EmployeeSituation");
            empbeneficiary.DataBindings.Add("text", Dt, "Emp_TheBeneficiary");
            empregistername.DataBindings.Add("text", Dt, "Emp_Registername");
            employeedawria.DataBindings.Add("text", Dt, "Emp_EmployeeDawria");
            empemployeename.DataBindings.Add("text", Dt, "Emp_EmployeeName");
            empsurname.DataBindings.Add("text", Dt, "Emp_Laqab");
            empjob.DataBindings.Add("text", Dt, "Emp_Job");
            empjobnow.DataBindings.Add("text", Dt, "Emp_WorkingType");
            empdivision.DataBindings.Add("text", Dt, "Emp_Division");
            empunit.DataBindings.Add("Text", Dt, "Emp_Unit");
            empworkplace.DataBindings.Add("text", Dt, "Emp_WorkingPlace");
            empsn.DataBindings.Add("text", Dt, "Emp_SN");
            childrencount.DataBindings.Add("text", Dt, "Emp_KidsCount");
            empwifetype.DataBindings.Add("text", Dt, "Emp_WifeWorking");
            empstudy.DataBindings.Add("Text", Dt, "Emp_Studing");
            emplaststudy.DataBindings.Add("Text", Dt, "Emp_LastStage");
            emptaghsus.DataBindings.Add("Text", Dt, "Emp_Taghsus");
            empmaharat.DataBindings.Add("Text", Dt, "Emp_Maharat");
            empoldwork.DataBindings.Add("Text", Dt, "Emp_OldWorking");
            empoldworkplace.DataBindings.Add("Text", Dt, "Emp_OldWorkingPlace");
            emplivenow.DataBindings.Add("Text", Dt, "Emp_LivePlaceNow");
            emplivesing.DataBindings.Add("Text", Dt, "Emp_PlacePointNearest");
            empoldliveplace.DataBindings.Add("Text", Dt, "Emp_OldLivePlace");
            empjunsia.DataBindings.Add("Text", Dt, "Emp_IDentityNumber");
            empjunsiaplace.DataBindings.Add("Text", Dt, "Emp_DaeratAhwal");
            empshahada.DataBindings.Add("Text", Dt, "Emp_ShahadaNumber");
            empshahadaplace.DataBindings.Add("Text", Dt, "Emp_DaeratNufuos");
            empbutaqasakan.DataBindings.Add("Text", Dt, "Emp_ButaqatSakan");
            empmaqtabmu.DataBindings.Add("Text", Dt, "Emp_MaktabMaalumat");
            empwatania.DataBindings.Add("Text", Dt, "Emp_ButaqatTawmenia");
            empbirthdate.DataBindings.Add("Text", Dt, "Emp_BirthDay", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            empbirthplace.DataBindings.Add("Text", Dt, "Emp_BrithDayPlace");
            emptaghweelno.DataBindings.Add("Text", Dt, "Emp_TaghweelNO");
            emptaghweeldate.DataBindings.Add("Text", Dt, "Emp_TaghweelDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            empbarcode.DataBindings.Add("Text", Dt, "Emp_EmpBarcode");
            empmobile1.DataBindings.Add("Text", Dt, "Emp_Mobile1");
            empmobile2.DataBindings.Add("Text", Dt, "Emp_Mobile2");
            empdepartment.DataBindings.Add("Text", Dt, "Emp_EmpDepartment");
            emppathimage.DataBindings.Add("Text", Dt, "Emp_image");
            empnotice.DataBindings.Add("Text", Dt, "Emp_Notice");
            employeeworktype.DataBindings.Add("text", Dt, "Emp_EmployeeWorkType");

            if (emppathimage.Text == null || emppathimage.Text == "") { empimage.Image = null; } else { empimage.Load(emppathimage.Text); }

            //string[] str1 = new string[3];
            //str1[0] = "عقد"; str1[1] = "اجور يومية"; str1[2] = "تثبيت";
            //emptype.Items.Clear();
            //emptype.Items.AddRange(str1);
            TreeView Tr = new TreeView();
            CLSEMPLOYEES AddItems = new CLSEMPLOYEES();
            DataTable DtAdditems = AddItems.Emp_RootNode(Tr);
            emptype.Items.Clear();
            for (int i = 0; i < DtAdditems.Rows.Count; i++)
            {
                emptype.Items.Add(DtAdditems.Rows[i][0].ToString());
                
            }

            string[] str2 = new string[7];
            str2[0] = "A+"; str2[1] = "A-"; str2[2] = "B+"; str2[3] = "B-"; str2[4] = "AB"; str2[5] = "O+"; str2[6] = "O-";
            empbloodtype.Items.Clear();
            empbloodtype.Items.AddRange(str2);

            string[] str3 = new string[11];
            str3[0] = "لاشيء"; str3[1] = "استضافة"; str3[2] = "تنسيب"; str3[3] = "تفريغ"; str3[4] = "نقل خدمات"; str3[5] = "انهاء خدمات"; str3[6] = "انهاء عقد"; str3[7] = "انهاء اجور يومية"; str3[8] = "استقالة"; str3[9] = "متقاعد"; str3[10] = "متوفي";
            empempsitu.Items.Clear();
            empempsitu.Items.AddRange(str3);

            string[] str4 = new string[6];
            str4[0] = "الاولى"; str4[1] = "الثانية"; str4[2] = "الثالثة"; str4[3] = "الرابعة"; str4[4] = "الخامسة"; str4[5] = "السادسة";
            emplaststudy.Items.Clear();
            
            emplaststudy.Items.AddRange(str4);

            string[] str5 = new string[4];
            str5[0] = "اعزب"; str5[1] = "متزوج"; str5[2] = "ارمل"; str5[3] = "مطلق";
            empsn.Items.Clear();
            empsn.Items.AddRange(str5);

            string[] str6 = new string[2];
            str6[0] = "موظفة"; str6[1] = "ربة بيت";
            empwifetype.Items.Clear();
            empwifetype.Items.AddRange(str6);

            string[] str7 = new string[7];
            str7[0] = "الأحد"; str7[1] = "الإثنين"; str7[2] = "الثلاثاء"; str7[3] = "الأربعاء"; str7[4] = "الخميس"; str7[5] = "الجمعة"; str7[6] = "السبت";
            employeedawria.Items.Clear();
            employeedawria.Items.AddRange(str7);

            string[] str8 = new string[4];
            str8[0] = "7"; str8[1] = "14"; str8[2] = "24"; str8[3] = "حر";
            employeeworktype.Items.Clear();
            employeeworktype.Items.AddRange(str8);


            empbeneficiary.Items.Clear();
            empdepartment.Items.Clear();
            CLSCONSTENTRY GetDate = new CLSCONSTENTRY();
            DataTable Dtdepartment = GetDate.GetDataDepartment();
            for (int i = 0; i < Dtdepartment.Rows.Count; i++)
            {
                empbeneficiary.Items.Add(Dtdepartment.Rows[i][1].ToString());
                empdepartment.Items.Add(Dtdepartment.Rows[i][1].ToString());
            }

            empjob.Items.Clear();
            empjobnow .Items.Clear();
            CLSCONSTENTRY Gettingdata = new CLSCONSTENTRY();
            DataTable Dtempjob = Gettingdata.JobsNamesGettingdata();
            for (int j = 0; j < Dtempjob.Rows.Count; j++)
            {
                empjob.Items.Add(Dtempjob.Rows[j][1].ToString());
                empjobnow.Items.Add(Dtempjob.Rows[j][1].ToString());
            }

            empunit.Items.Clear();
            CLSCONSTENTRY Getdataunit = new CLSCONSTENTRY();
            DataTable Dtunit = Getdataunit.UnitsNamesGettingdata();
            for (int jj = 0; jj < Dtunit.Rows.Count; jj++)
            {
                empunit.Items.Add(Dtunit.Rows[jj][1].ToString());
            }

            empdivision.Items.Clear();
            CLSCONSTENTRY GetdataDivision = new CLSCONSTENTRY();
            DataTable DtDivision = GetdataDivision.DivisionsNameGettingData();
            for (int ii = 0; ii < DtDivision.Rows.Count; ii++)
            {
                empdivision.Items.Add(DtDivision.Rows[ii][1].ToString());
            }

            empstudy.Items.Clear();
            CLSCONSTENTRY GetdataStudy = new CLSCONSTENTRY();
            DataTable Dtstudy = GetdataStudy.StudyingNamesGettingData();
            for (int z = 0; z < Dtstudy.Rows.Count; z++)
            {
                empstudy.Items.Add(Dtstudy.Rows[z][1].ToString());
            }

            empjunsiaplace.Items.Clear();
            empshahadaplace.Items.Clear();
            empmaqtabmu.Items.Clear();
            CLSCONSTENTRY GetData = new CLSCONSTENTRY();
            DataTable DtPlace = GetDate.DistenationSelecting();
            for (int w = 0; w < DtPlace.Rows.Count; w++)
            {
                empjunsiaplace.Items.Add(DtPlace.Rows[w][1].ToString());
                empshahadaplace.Items.Add(DtPlace.Rows[w][1].ToString());
                empmaqtabmu.Items.Add(DtPlace.Rows[w][1].ToString());
            }

            empworkplace.Items.Clear();
            RPEMPEMPLOYEES WorkPlace = new RPEMPEMPLOYEES();
            DataTable DTWorkPlace = WorkPlace.RPEMP_WorkPlace();
            for (int z = 0; z < DTWorkPlace.Rows.Count; z++)
            {
                empworkplace.Items.Add(DTWorkPlace.Rows[z][0].ToString());
            }
            return Dt;
        }
        //==================================================================
        //=============This codes below for inset data to the employeesInfo tabel / Using the Employeesinfoinsertdata Procedure
        public DataTable EmployeeInfoInsertdata(TextBox AStreenode, DataGridView DgvEmpInfo, TextBox empseq, TextBox empdocunopast, TextBox empdocunonew, ComboBox emptype, TextBox empidentityno
           , ComboBox empbloodtype, ComboBox empempsitu, ComboBox empbeneficiary, TextBox empregistername, ComboBox employeedawria, TextBox empemployeename
           , TextBox empsurname, ComboBox empjob, ComboBox empjobnow, ComboBox empdivision, ComboBox empunit, ComboBox empworkplace, ComboBox empsn
           , TextBox childrencount, ComboBox empwifetype, ComboBox empstudy, ComboBox emplaststudy, ComboBox emptaghsus, TextBox empmaharat, TextBox empoldwork
           , TextBox empoldworkplace, TextBox emplivenow, TextBox emplivesing, TextBox empoldliveplace, TextBox empjunsia, ComboBox empjunsiaplace
           , TextBox empshahada, ComboBox empshahadaplace, TextBox empbutaqasakan, ComboBox empmaqtabmu, TextBox empwatania, DateTimePicker empbirthdate
           , TextBox empbirthplace, TextBox emptaghweelno, DateTimePicker emptaghweeldate, TextBox empbarcode, TextBox empmobile1, TextBox empmobile2
           , ComboBox empdepartment, TextBox emppathimage, RichTextBox empnotice, PictureBox empimage, ComboBox employeeworktype, TableLayoutPanel pn7, TableLayoutPanel pn8, TableLayoutPanel pn9, TableLayoutPanel pn10
           , int empdocuno1, int empdocuno2, string emptype1, string empidentityno1, string empbloodtype1, string empempsitu1, string empbeneficiary1, string empregistername1
            , string employeedawria2, string empemployeename1, string empsurname1, string empjob1, string empjobnow1, string empdivision1, string empunit1, string empworkplace1
            , string empsn1, string childrencount1, string empwifetype1, string empstudy1, string emplaststudy1, string emptaghsus1, string empmaharat1, string empoldwork1
           , string empoldworkplace1, string emplivenow1, string emplivesing1, string empoldliveplace1, string empjunsia1, string empjunsiaplace1
           , string empshahada1, string empshahadaplace1, string empbutaqasakan1, string empmaqtabmu1, string empwatania1, string empbirthdate1
           , string empbirthplace1, string emptaghweelno1, string emptaghweeldate1, string empbarcode1, string empmobile11, string empmobile21
           , string empdepartment1, string emppathimage1, string empnotice1, string employeeworktype2)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[46];
            param[0] = new SqlParameter("@Emp_DocNO", SqlDbType.Int);                        param[0].Value = empdocuno1;
            param[1] = new SqlParameter("@Emp_DocNOnew", SqlDbType.Int);                     param[1].Value = empdocuno2;
            param[2] = new SqlParameter("@Emp_type", SqlDbType.VarChar, 50);                 param[2].Value = emptype1;
            param[3] = new SqlParameter("@Emp_IDentityNO", SqlDbType.VarChar, 50);           param[3].Value = empidentityno1;
            param[4] = new SqlParameter("@Emp_Bloodtype", SqlDbType.VarChar, 50);            param[4].Value = empbloodtype1;
            param[5] = new SqlParameter("@Emp_EmployeeSituation", SqlDbType.VarChar, 50);    param[5].Value = empempsitu1;
            param[6] = new SqlParameter("@Emp_Thebeneficiary", SqlDbType.VarChar, 50);       param[6].Value = empbeneficiary1;
            param[7] = new SqlParameter("@Emp_Registername", SqlDbType.VarChar, 50);         param[7].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[8] = new SqlParameter("@Emp_EmployeeDawria", SqlDbType.VarChar, 50);       param[8].Value = employeedawria2;
            param[9] = new SqlParameter("@Emp_EmployeeName", SqlDbType.VarChar, 50);         param[9].Value = empemployeename1;
            param[10] = new SqlParameter("@Emp_Laqab", SqlDbType.VarChar, 50);               param[10].Value = empsurname1;
            param[11] = new SqlParameter("@Emp_Job", SqlDbType.VarChar, 50);                 param[11].Value = empjob1;
            param[12] = new SqlParameter("@Emp_WorkingType", SqlDbType.VarChar, 50);         param[12].Value = empjobnow1;
            param[13] = new SqlParameter("@Emp_Division", SqlDbType.VarChar, 50);            param[13].Value = empdivision1;
            param[14] = new SqlParameter("@Emp_Unit", SqlDbType.VarChar, 50);                param[14].Value = empunit1;
            param[15] = new SqlParameter("@Emp_WorkingPlace", SqlDbType.VarChar, 50);        param[15].Value = empworkplace1;
            param[16] = new SqlParameter("@Emp_SN", SqlDbType.VarChar, 50);                  param[16].Value = empsn1;
            param[17] = new SqlParameter("@Emp_KidsCount", SqlDbType.VarChar, 50);           param[17].Value = childrencount1;
            param[18] = new SqlParameter("@Emp_WifeWorking", SqlDbType.VarChar, 50);         param[18].Value = empwifetype1;
            param[19] = new SqlParameter("@Emp_Studing", SqlDbType.VarChar, 50);             param[19].Value = empstudy1;
            param[20] = new SqlParameter("@Emp_LastStage", SqlDbType.VarChar, 50);           param[20].Value = emplaststudy1;
            param[21] = new SqlParameter("@Emp_Taghsus", SqlDbType.VarChar, 50);             param[21].Value = emptaghsus1;
            param[22] = new SqlParameter("@Emp_Maharat", SqlDbType.VarChar, 50);             param[22].Value = empmaharat1;
            param[23] = new SqlParameter("@Emp_OldWorking", SqlDbType.VarChar, 50);          param[23].Value = empoldwork1;
            param[24] = new SqlParameter("@Emp_OldWorkingPlace", SqlDbType.VarChar, 50);     param[24].Value = empoldworkplace1;
            param[25] = new SqlParameter("@Emp_LivePlaceNow", SqlDbType.VarChar, 50);        param[25].Value = emplivenow1;
            param[26] = new SqlParameter("@Emp_PlacePointNearest", SqlDbType.VarChar, 50);   param[26].Value = emplivesing1;
            param[27] = new SqlParameter("@Emp_OldLivePlace", SqlDbType.VarChar, 50);        param[27].Value = empoldliveplace1;
            param[28] = new SqlParameter("@Emp_IDentityNumber", SqlDbType.VarChar, 50);      param[28].Value = empjunsia1;
            param[29] = new SqlParameter("@Emp_DaeratAhwal", SqlDbType.VarChar, 50);         param[29].Value = empjunsiaplace1;
            param[30] = new SqlParameter("@Emp_ShahadaNumber", SqlDbType.VarChar, 50);       param[30].Value = empshahada1;
            param[31] = new SqlParameter("@Emp_DaeratNufuos", SqlDbType.VarChar, 50);        param[31].Value = empshahadaplace1;
            param[32] = new SqlParameter("@Emp_ButaqatSakan", SqlDbType.VarChar, 50);        param[32].Value = empbutaqasakan1;
            param[33] = new SqlParameter("@Emp_MaktabMaalumat", SqlDbType.VarChar, 50);      param[33].Value = empmaqtabmu1;
            param[34] = new SqlParameter("@Emp_BirthDay", SqlDbType.VarChar, 50);            param[34].Value = empbirthdate1;
            param[35] = new SqlParameter("@Emp_BrithDayPlace", SqlDbType.VarChar, 50);       param[35].Value = empbirthplace1;
            param[36] = new SqlParameter("@Emp_TaghweelNO", SqlDbType.VarChar, 50);          param[36].Value = emptaghweelno1;
            param[37] = new SqlParameter("@Emp_TaghweelDate", SqlDbType.VarChar, 50);        param[37].Value = emptaghweeldate1;
            param[38] = new SqlParameter("@Emp_EmpBarcode", SqlDbType.VarChar, 50);          param[38].Value = empbarcode1;
            param[39] = new SqlParameter("@Emp_Mobile1", SqlDbType.VarChar, 50);             param[39].Value = empmobile11;
            param[40] = new SqlParameter("@Emp_Mobile2", SqlDbType.VarChar, 50);             param[40].Value = empmobile21;
            param[41] = new SqlParameter("@Emp_EmpDepartment", SqlDbType.VarChar, 50);       param[41].Value = empdepartment1;
            param[42] = new SqlParameter("@Emp_image", SqlDbType.Text);                      param[42].Value = emppathimage1;
            param[43] = new SqlParameter("@Emp_Notice", SqlDbType.VarChar, 50);              param[43].Value = empnotice1;
            param[44] = new SqlParameter("@Emp_ButaqatTawmenia", SqlDbType.VarChar, 50);     param[44].Value = empwatania1;
            param[45] = new SqlParameter("@Emp_EmployeeWorkType", SqlDbType.VarChar, 50);     param[45].Value = employeeworktype2;
        
            dal.open();
            dal.ExecuteCommand("EmployeesInfoInsertData", param);
            dal.close();
            DataTable dt= EmployeeInfoGetdata(AStreenode.Text,DgvEmpInfo, empseq, empdocunopast, empdocunonew, emptype, empidentityno, empbloodtype, empempsitu, empbeneficiary, empregistername, employeedawria, empemployeename
                , empsurname, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, childrencount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace
                , emplivenow, emplivesing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqasakan, empmaqtabmu, empwatania, empbirthdate, empbirthplace
                , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, employeeworktype, pn7, pn8, pn9, pn10);
            return dt;
        }
        //====================================================================================
        //======================= This Codes Below For Update Data to the Employeeinfo table / using the EmployeeInfoUpdatedate Procedure 
        public DataTable EmployeeInfoUpdatedata(TextBox AStreenode, DataGridView DgvEmpInfo, TextBox empseq, TextBox empdocunopast, TextBox empdocunonew, ComboBox emptype, TextBox empidentityno
           , ComboBox empbloodtype, ComboBox empempsitu, ComboBox empbeneficiary, TextBox empregistername, ComboBox employeedawria, TextBox empemployeename
           , TextBox empsurname, ComboBox empjob, ComboBox empjobnow, ComboBox empdivision, ComboBox empunit, ComboBox empworkplace, ComboBox empsn
           , TextBox childrencount, ComboBox empwifetype, ComboBox empstudy, ComboBox emplaststudy, ComboBox emptaghsus, TextBox empmaharat, TextBox empoldwork
           , TextBox empoldworkplace, TextBox emplivenow, TextBox emplivesing, TextBox empoldliveplace, TextBox empjunsia, ComboBox empjunsiaplace
           , TextBox empshahada, ComboBox empshahadaplace, TextBox empbutaqasakan, ComboBox empmaqtabmu, TextBox empwatania, DateTimePicker empbirthdate
           , TextBox empbirthplace, TextBox emptaghweelno, DateTimePicker emptaghweeldate, TextBox empbarcode, TextBox empmobile1, TextBox empmobile2
           , ComboBox empdepartment, TextBox emppathimage, RichTextBox empnotice, PictureBox empimage, ComboBox employeeworktype, TableLayoutPanel pn7, TableLayoutPanel pn8, TableLayoutPanel pn9, TableLayoutPanel pn10
           , int empdocuno1, int empdocuno2, string emptype1, string empidentityno1, string empbloodtype1, string empempsitu1, string empbeneficiary1, string empregistername1
           , string employeedawria2, string empemployeename1, string empsurname1, string empjob1, string empjobnow1, string empdivision1, string empunit1, string empworkplace1
           , string empsn1, string childrencount1, string empwifetype1, string empstudy1, string emplaststudy1, string emptaghsus1, string empmaharat1, string empoldwork1
           , string empoldworkplace1, string emplivenow1, string emplivesing1, string empoldliveplace1, string empjunsia1, string empjunsiaplace1
           , string empshahada1, string empshahadaplace1, string empbutaqasakan1, string empmaqtabmu1, string empwatania1, string empbirthdate1
           , string empbirthplace1, string emptaghweelno1, string emptaghweeldate1, string empbarcode1, string empmobile11, string empmobile21
           , string empdepartment1, string emppathimage1, string empnotice1, string employeeworktype2, int empid)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[47];
            param[0] = new SqlParameter("@Emp_DocNO", SqlDbType.Int);                            param[0].Value = empdocuno1;
            param[1] = new SqlParameter("@Emp_DocNOnew", SqlDbType.Int);                         param[1].Value = empdocuno2;
            param[2] = new SqlParameter("@Emp_type", SqlDbType.VarChar, 50);                     param[2].Value = emptype1;
            param[3] = new SqlParameter("@Emp_IDentityNO", SqlDbType.VarChar, 50);               param[3].Value = empidentityno1;
            param[4] = new SqlParameter("@Emp_Bloodtype", SqlDbType.VarChar, 50);                param[4].Value = empbloodtype1;
            param[5] = new SqlParameter("@Emp_EmployeeSituation", SqlDbType.VarChar, 50);        param[5].Value = empempsitu1;
            param[6] = new SqlParameter("@Emp_Thebeneficiary", SqlDbType.VarChar, 50);           param[6].Value = empbeneficiary1;
            param[7] = new SqlParameter("@Emp_Registername", SqlDbType.VarChar, 50);             param[7].Value = Properties.Settings.Default.UserNameLogin.ToString();
            param[8] = new SqlParameter("@Emp_EmployeeDawria", SqlDbType.VarChar, 50);           param[8].Value = employeedawria2;
            param[9] = new SqlParameter("@Emp_EmployeeName", SqlDbType.VarChar, 50);             param[9].Value = empemployeename1;
            param[10] = new SqlParameter("@Emp_Laqab", SqlDbType.VarChar, 50);                   param[10].Value = empsurname1;
            param[11] = new SqlParameter("@Emp_Job", SqlDbType.VarChar, 50);                     param[11].Value = empjob1;
            param[12] = new SqlParameter("@Emp_WorkingType", SqlDbType.VarChar, 50);             param[12].Value = empjobnow1;
            param[13] = new SqlParameter("@Emp_Division", SqlDbType.VarChar, 50);                param[13].Value = empdivision1;
            param[14] = new SqlParameter("@Emp_Unit", SqlDbType.VarChar, 50);                    param[14].Value = empunit1;
            param[15] = new SqlParameter("@Emp_WorkingPlace", SqlDbType.VarChar, 50);            param[15].Value = empworkplace1;
            param[16] = new SqlParameter("@Emp_SN", SqlDbType.VarChar, 50);                      param[16].Value = empsn1;
            param[17] = new SqlParameter("@Emp_KidsCount", SqlDbType.VarChar, 50);               param[17].Value = childrencount1;
            param[18] = new SqlParameter("@Emp_WifeWorking", SqlDbType.VarChar, 50);             param[18].Value = empwifetype1;
            param[19] = new SqlParameter("@Emp_Studing", SqlDbType.VarChar, 50);                 param[19].Value = empstudy1;
            param[20] = new SqlParameter("@Emp_LastStage", SqlDbType.VarChar, 50);               param[20].Value = emplaststudy1;
            param[21] = new SqlParameter("@Emp_Taghsus", SqlDbType.VarChar, 50);                 param[21].Value = emptaghsus1;
            param[22] = new SqlParameter("@Emp_Maharat", SqlDbType.VarChar, 50);                 param[22].Value = empmaharat1;
            param[23] = new SqlParameter("@Emp_OldWorking", SqlDbType.VarChar, 50);              param[23].Value = empoldwork1;
            param[24] = new SqlParameter("@Emp_OldWorkingPlace", SqlDbType.VarChar, 50);         param[24].Value = empoldworkplace1;
            param[25] = new SqlParameter("@Emp_LivePlaceNow", SqlDbType.VarChar, 50);            param[25].Value = emplivenow1;
            param[26] = new SqlParameter("@Emp_PlacePointNearest", SqlDbType.VarChar, 50);       param[26].Value = emplivesing1;
            param[27] = new SqlParameter("@Emp_OldLivePlace", SqlDbType.VarChar, 50);            param[27].Value = empoldliveplace1;
            param[28] = new SqlParameter("@Emp_IDentityNumber", SqlDbType.VarChar, 50);          param[28].Value = empjunsia1;
            param[29] = new SqlParameter("@Emp_DaeratAhwal", SqlDbType.VarChar, 50);             param[29].Value = empjunsiaplace1;
            param[30] = new SqlParameter("@Emp_ShahadaNumber", SqlDbType.VarChar, 50);           param[30].Value = empshahada1;
            param[31] = new SqlParameter("@Emp_DaeratNufuos", SqlDbType.VarChar, 50);            param[31].Value = empshahadaplace1;
            param[32] = new SqlParameter("@Emp_ButaqatSakan", SqlDbType.VarChar, 50);            param[32].Value = empbutaqasakan1;
            param[33] = new SqlParameter("@Emp_MaktabMaalumat", SqlDbType.VarChar, 50);          param[33].Value = empmaqtabmu1;
            param[34] = new SqlParameter("@Emp_BirthDay", SqlDbType.VarChar, 50);                param[34].Value = empbirthdate1;
            param[35] = new SqlParameter("@Emp_BrithDayPlace", SqlDbType.VarChar, 50);           param[35].Value = empbirthplace1;
            param[36] = new SqlParameter("@Emp_TaghweelNO", SqlDbType.VarChar, 50);              param[36].Value = emptaghweelno1;
            param[37] = new SqlParameter("@Emp_TaghweelDate", SqlDbType.VarChar, 50);            param[37].Value = emptaghweeldate1;
            param[38] = new SqlParameter("@Emp_EmpBarcode", SqlDbType.VarChar, 50);              param[38].Value = empbarcode1;
            param[39] = new SqlParameter("@Emp_Mobile1", SqlDbType.VarChar, 50);                 param[39].Value = empmobile11;
            param[40] = new SqlParameter("@Emp_Mobile2", SqlDbType.VarChar, 50);                 param[40].Value = empmobile21;
            param[41] = new SqlParameter("@Emp_EmpDepartment", SqlDbType.VarChar, 50);           param[41].Value = empdepartment1;
            param[42] = new SqlParameter("@Emp_image", SqlDbType.Text);                          param[42].Value = emppathimage1;
            param[43] = new SqlParameter("@Emp_Notice", SqlDbType.VarChar, 50);                  param[43].Value = empnotice1;
            param[44] = new SqlParameter("@Emp_ButaqatTawmenia", SqlDbType.VarChar, 50);         param[44].Value = empwatania1;
            param[45] = new SqlParameter("@Emp_EmployeeWorkType", SqlDbType.VarChar, 50);         param[45].Value = employeeworktype2;
            param[46] = new SqlParameter("@Emp_ID", SqlDbType.Int);                              param[46].Value = empid;
        
            dal.open();
            dal.ExecuteCommand("EmployeesInfoUpdateData", param);
            dal.close();
            DataTable dt= EmployeeInfoGetdata(AStreenode.Text, DgvEmpInfo, empseq, empdocunopast,empdocunonew, emptype, empidentityno, empbloodtype, empempsitu, empbeneficiary, empregistername, employeedawria, empemployeename
                , empsurname, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, childrencount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace
               , emplivenow, emplivesing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqasakan, empmaqtabmu, empwatania, empbirthdate, empbirthplace
                , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, employeeworktype, pn7, pn8, pn9, pn10);
            return dt;
        }
        //=======================================================================
        //=============  this codes below for deleting data from employeeinfo table / Using the EmployeeInfoDeletedata Procedure 
        public DataTable EmployeeInfoDeletedata(TextBox AStreenode,DataGridView DgvEmpInfo, TextBox empseq, TextBox empdocunopast, TextBox empdocunonew, ComboBox emptype, TextBox empidentityno
           , ComboBox empbloodtype, ComboBox empempsitu, ComboBox empbeneficiary, TextBox empregistername, ComboBox employeedawria, TextBox empemployeename
           , TextBox empsurname, ComboBox empjob, ComboBox empjobnow, ComboBox empdivision, ComboBox empunit, ComboBox empworkplace, ComboBox empsn
           , TextBox childrencount, ComboBox empwifetype, ComboBox empstudy, ComboBox emplaststudy, ComboBox emptaghsus, TextBox empmaharat, TextBox empoldwork
           , TextBox empoldworkplace, TextBox emplivenow, TextBox emplivesing, TextBox empoldliveplace, TextBox empjunsia, ComboBox empjunsiaplace
           , TextBox empshahada, ComboBox empshahadaplace, TextBox empbutaqasakan, ComboBox empmaqtabmu, TextBox empwatania, DateTimePicker empbirthdate
           , TextBox empbirthplace, TextBox emptaghweelno, DateTimePicker emptaghweeldate, TextBox empbarcode, TextBox empmobile1, TextBox empmobile2
           , ComboBox empdepartment, TextBox emppathimage, RichTextBox empnotice, PictureBox empimage, ComboBox employeeworktype, TableLayoutPanel pn7, TableLayoutPanel pn8, TableLayoutPanel pn9, TableLayoutPanel pn10
           , int empid)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int); param[0].Value = empid;
            dal.open();
            dal.ExecuteCommand("EmployeeInfoDeletData", param);
            dal.close();
            DataTable dt= EmployeeInfoGetdata(AStreenode.Text,DgvEmpInfo, empseq, empdocunopast, empdocunonew, emptype, empidentityno, empbloodtype, empempsitu, empbeneficiary, empregistername, employeedawria, empemployeename
                 , empsurname, empjob, empjobnow, empdivision, empunit, empworkplace, empsn, childrencount, empwifetype, empstudy, emplaststudy, emptaghsus, empmaharat, empoldwork, empoldworkplace
                 , emplivenow, emplivesing, empoldliveplace, empjunsia, empjunsiaplace, empshahada, empshahadaplace, empbutaqasakan, empmaqtabmu, empwatania, empbirthdate, empbirthplace
                 , emptaghweelno, emptaghweeldate, empbarcode, empmobile1, empmobile2, empdepartment, emppathimage, empnotice, empimage, employeeworktype, pn7, pn8, pn9, pn10);
            return dt;
        }


        //===================================================================================================================================================
        //===================================================================================================================================================
        //=============== this codes below for Getting Data from EmployeeAdministrationOrders / Using EmpAdministrationOrders Procedure
        public DataTable EmpAdministrationOrders(DataGridView ADdgv, TextBox AdIDsequence, TextBox AdIDcon, TextBox Adempname, ComboBox Adbooktitle, TextBox AdbookNO
            , DateTimePicker Adbookdate, ComboBox Adreleaseby, TextBox AdimportNO, DateTimePicker AdimportDate, TextBox Addescription, TextBox Adregistername
            , TextBox Adaddingtime, TextBox Adaddingdate, Panel pn11, int Empseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = Empseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpAdministrationOrderGetdata", param);
            dal.close();
            ADdgv.DataSource = null; ADdgv.DataSource = Dt;
            foreach (Control p in pn11.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker) { (p).DataBindings.Clear(); } }

            ADdgv.Columns[0].Visible = false;
            ADdgv.Columns[1].Visible = false;
            ADdgv.Columns[2].Visible = false;
            ADdgv.Columns[3].HeaderText = "موضوع الكتاب";
            ADdgv.Columns[4].HeaderText = "رقم الكتاب";
            ADdgv.Columns[5].HeaderText = "تاريخ الكتاب";
            ADdgv.Columns[6].HeaderText = "جهة الاصدار";
            ADdgv.Columns[7].Visible = false;
            ADdgv.Columns[8].HeaderText = "رقم الوارد";
            ADdgv.Columns[9].HeaderText = "تاريخ الوارد";
            ADdgv.Columns[10].Visible = false;
            ADdgv.Columns[11].Visible = false;
            ADdgv.Columns[12].Visible = false;
            ADdgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            AdIDsequence.DataBindings.Clear();
            AdIDcon.DataBindings.Clear();
            Adempname.DataBindings.Clear();
            Adbooktitle.DataBindings.Clear();
            AdbookNO.DataBindings.Clear();
            Adbookdate.DataBindings.Clear();
            Adreleaseby.DataBindings.Clear();
            Addescription.DataBindings.Clear();
            AdimportNO.DataBindings.Clear();
            AdimportDate.DataBindings.Clear();
            Adregistername.DataBindings.Clear();
            Adaddingtime.DataBindings.Clear();
            Adaddingdate.DataBindings.Clear();

            AdIDsequence.DataBindings.Add("text", Dt, "idempadmin");
            AdIDcon.DataBindings.Add("text", Dt, "IDconadmin");
            Adempname.DataBindings.Add("text", Dt, "Emp_Name");
            Adbooktitle.DataBindings.Add("text", Dt, "BookTitle");
            AdbookNO.DataBindings.Add("text", Dt, "BookNO");
            Adbookdate.DataBindings.Add("text", Dt, "BookDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Adreleaseby.DataBindings.Add("text", Dt, "ReleaseBy");
            Addescription.DataBindings.Add("text", Dt, "Notice");
            AdimportNO.DataBindings.Add("Text", Dt, "ImportNo");
            AdimportDate.DataBindings.Add("text", Dt, "ImportDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Adregistername.DataBindings.Add("text", Dt, "RegisterName");
            Adaddingtime.DataBindings.Add("text", Dt, "AddingTime");
            Adaddingdate.DataBindings.Add("text", Dt, "Addingdate");
            return Dt;

        }
        //========================================================================================================================================  
        //============= this Code Below for InsertData To the Employeeinfo table / Using the EmpAdministrationInsertData Procedure
        public DataTable EmpAdinsertData(DataGridView ADdgv, TextBox AdIDsequence, TextBox AdIDcon, TextBox Adempname, ComboBox Adbooktitle, TextBox AdbookNO
            , DateTimePicker Adbookdate, ComboBox Adreleaseby, TextBox AdimportNO, DateTimePicker AdimportDate, TextBox Addescription, TextBox Adregistername
            , TextBox Adaddingtime, TextBox Adaddingdate, Panel pn11, int AdIDcon1, string Adempname1, string Adbooktitle1, string Adbookno1, string AdbookDate1
            , string Releaseby1, string AdNotice, string AdimportNo, string AdimportDate1, string AdRegistername, string Adaddingtime1, string AdaddingDate1)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = AdIDcon1;
            param[1] = new SqlParameter("@Emp_Name", SqlDbType.VarChar, 50); param[1].Value = Adempname1;
            param[2] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50); param[2].Value = Adbooktitle1;
            param[3] = new SqlParameter("@BookNo", SqlDbType.VarChar, 50); param[3].Value = Adbookno1;
            param[4] = new SqlParameter("@BookDate", SqlDbType.VarChar, 50); param[4].Value = AdbookDate1;
            param[5] = new SqlParameter("@ReleaseBy", SqlDbType.VarChar, 50); param[5].Value = Releaseby1;
            param[6] = new SqlParameter("@Notice", SqlDbType.Text); param[6].Value = AdNotice;
            param[7] = new SqlParameter("@ImportNO", SqlDbType.VarChar, 50); param[7].Value = AdimportNo;
            param[8] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[8].Value = AdimportDate1;
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[9].Value = AdRegistername;
            param[10] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[10].Value = Adaddingtime1;
            param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[11].Value = AdaddingDate1;
            dal.open();
            dal.ExecuteCommand("EmpAdministrationOrderinsertData", param);
            dal.close();
            DataTable dt= EmpAdministrationOrders(ADdgv, AdIDsequence, AdIDcon, Adempname, Adbooktitle, AdbookNO, Adbookdate, Adreleaseby, AdimportNO, AdimportDate
                , Addescription, Adregistername, Adaddingtime, Adaddingdate, pn11, int.Parse(AdIDcon.Text));
            return dt;

        }
        //===============================================================================================================================
        //============ This codes Below for Update data into the EmpAdministrationOrders tabel / Using The EmpAdministrationOrderUpdateData Procedure
        public DataTable EmpAdUpdateData(DataGridView ADdgv, TextBox AdIDsequence, TextBox AdIDcon, TextBox Adempname, ComboBox Adbooktitle, TextBox AdbookNO
            , DateTimePicker Adbookdate, ComboBox Adreleaseby, TextBox AdimportNO, DateTimePicker AdimportDate, TextBox Addescription, TextBox Adregistername
            , TextBox Adaddingtime, TextBox Adaddingdate, Panel pn11, int AdIDcon1, string Adempname1, string Adbooktitle1, string Adbookno1, string AdbookDate1
            , string Releaseby1, string AdNotice, string AdimportNo, string AdimportDate1, string AdRegistername, string Adaddingtime1, string AdaddingDate1, int AdIDseq)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = AdIDcon1;
            param[1] = new SqlParameter("@Emp_Name", SqlDbType.VarChar, 50); param[1].Value = Adempname1;
            param[2] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50); param[2].Value = Adbooktitle1;
            param[3] = new SqlParameter("@BookNo", SqlDbType.VarChar, 50); param[3].Value = Adbookno1;
            param[4] = new SqlParameter("@BookDate", SqlDbType.VarChar, 50); param[4].Value = AdbookDate1;
            param[5] = new SqlParameter("@ReleaseBy", SqlDbType.VarChar, 50); param[5].Value = Releaseby1;
            param[6] = new SqlParameter("@Notice", SqlDbType.Text); param[6].Value = AdNotice;
            param[7] = new SqlParameter("@ImportNO", SqlDbType.VarChar, 50); param[7].Value = AdimportNo;
            param[8] = new SqlParameter("@ImportDate", SqlDbType.VarChar, 50); param[8].Value = AdimportDate1;
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[9].Value = AdRegistername;
            param[10] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[10].Value = Adaddingtime1;
            param[11] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[11].Value = AdaddingDate1;
            param[12] = new SqlParameter("@Emp_ID", SqlDbType.Int); param[12].Value = AdIDseq;
            dal.open();
            dal.ExecuteCommand("EmpAdministrationOrderUpdateData", param);
            dal.close();
           DataTable dt= EmpAdministrationOrders(ADdgv, AdIDsequence, AdIDcon, Adempname, Adbooktitle, AdbookNO, Adbookdate, Adreleaseby, AdimportNO, AdimportDate
                , Addescription, Adregistername, Adaddingtime, Adaddingdate, pn11, int.Parse(AdIDcon.Text));
            return dt;

        }
        //========================================================================================================================================
        //============= This Codes Below for Delete Data From EmpAdministrationOrder tabel / Using EmpAdministrationOrderDeleteData Procedure
        public DataTable EmpAdDeleteData(DataGridView ADdgv, TextBox AdIDsequence, TextBox AdIDcon, TextBox Adempname, ComboBox Adbooktitle, TextBox AdbookNO
            , DateTimePicker Adbookdate, ComboBox Adreleaseby, TextBox AdimportNO, DateTimePicker AdimportDate, TextBox Addescription, TextBox Adregistername
            , TextBox Adaddingtime, TextBox Adaddingdate, Panel pn11, int AdIDseq)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_ID", SqlDbType.Int); param[0].Value = AdIDseq;
            dal.open();
            dal.ExecuteCommand("EmpAdministrationOrderDeleteData", param);
            dal.close();
            DataTable dt= EmpAdministrationOrders(ADdgv, AdIDsequence, AdIDcon, Adempname, Adbooktitle, AdbookNO, Adbookdate, Adreleaseby, AdimportNO, AdimportDate
                , Addescription, Adregistername, Adaddingtime, Adaddingdate, pn11, int.Parse(AdIDcon.Text));
            return dt;

        }
        //==========================================================================================================================================
        //========================================================================================================================================
        //================This codes Below for Building the EmpVariable interface -- Getting data From EmpVariable table / using EmployeeVariableSelecting Procedure
        public DataTable EmpVarGettingData(DataGridView VarDgv, TextBox VarIDseq, TextBox VarIDcon, TextBox Varempname, ComboBox Vartype, TextBox Varcount
            , ComboBox Vartype2, DateTimePicker VarDate, DateTimePicker Varcomming, TextBox VarNotice, TextBox Varregistername
            , TextBox VarAddingTime, TextBox VarAddingDate, Panel Varpn, int VarIDcon1,DevExpress.XtraEditors.ToggleSwitch VarTypeAdd, 
            DevExpress.XtraEditors.ToggleSwitch VarTypeNotAdd)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int); param[0].Value = VarIDcon1;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVariableSelecting", param);
            dal.close();
            VarDgv.DataSource = null; VarDgv.DataSource = Dt;
            foreach (Control p in Varpn.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker || p is DevExpress.XtraEditors.ToggleSwitch) { (p).DataBindings.Clear(); } }

            VarDgv.Columns[0].Visible = false;
            VarDgv.Columns[1].Visible = false;
            VarDgv.Columns[2].Visible = false;
            VarDgv.Columns[3].HeaderText = "الحالة";
            VarDgv.Columns[4].HeaderText = "عدد";
            VarDgv.Columns[5].HeaderText = "نوع الحالة";
            VarDgv.Columns[6].HeaderText = "تاريخ الحالة";
            VarDgv.Columns[7].HeaderText = "تاريخ العودة";
            VarDgv.Columns[8].HeaderText = "التفاصيل";
            VarDgv.Columns[9].Visible = false;
            VarDgv.Columns[10].Visible = false;
            VarDgv.Columns[11].Visible = false;
            VarDgv.Columns[12].Visible = false;
            VarDgv.Columns[13].Visible = false;

            VarDgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            VarIDseq.DataBindings.Clear();
            VarIDcon.DataBindings.Clear();
            Varempname.DataBindings.Clear();
            Vartype.DataBindings.Clear();
            Varcount.DataBindings.Clear();
            Vartype2.DataBindings.Clear();
            VarDate.DataBindings.Clear();
            Varcomming.DataBindings.Clear();
            VarNotice.DataBindings.Clear();
            Varregistername.DataBindings.Clear();
            VarAddingTime.DataBindings.Clear();
            VarAddingDate.DataBindings.Clear();
            VarTypeAdd.DataBindings.Clear();
            VarTypeNotAdd.DataBindings.Clear();

            VarIDseq.DataBindings.Add("text", Dt, "IDvar");
            VarIDcon.DataBindings.Add("text", Dt, "IDconempvar");
            Varempname.DataBindings.Add("text", Dt, "EmployeeName");
            Vartype.DataBindings.Add("text", Dt, "VariabelType");
            Varcount.DataBindings.Add("text", Dt, "VariableCount");
            Vartype2.DataBindings.Add("text", Dt, "TheType2");
            VarDate.DataBindings.Add("text", Dt, "VariabelDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            Varcomming.DataBindings.Add("text", Dt, "CommingDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            VarNotice.DataBindings.Add("Text", Dt, "Notice");
            Varregistername.DataBindings.Add("text", Dt, "RegisterName");
            VarAddingTime.DataBindings.Add("text", Dt, "AddingTime");
            VarAddingDate.DataBindings.Add("text", Dt, "AddingDate");
            VarTypeAdd.DataBindings.Add("text", Dt, "TypeAdd");
            VarTypeNotAdd.DataBindings.Add("text", Dt, "TypeNotAdd");

          

            string[] str1 = new string[6];
            str1[0] = "اجازة"; str1[1] = "غياب"; str1[2] = "ارسال"; str1[3] = "ارسال خاص"; str1[4] = "مباشرة"; str1[5] = "عاد من الغياب";
            Vartype.Items.Clear();
            Vartype.Items.AddRange(str1);

            string[] str2 = new string[11];
            str2[0] = "اعتيادية"; str2[1] = "بدون راتب"; str2[2] = "اعتيادية لاحقة"; str2[3] = "اعتيادية + بدون راتب"; str2[4] = "مرضية";
            str2[5] = "مرضية موافقة خاصة"; str2[6] = "طارئة"; str2[7] = "غياب"; str2[8] = "عاد من الغياب"; str2[9] = "مباشرة"; str2[10] = "دراسية";
            Vartype2.Items.Clear();
            Vartype2.Items.AddRange(str2);


            return Dt;

        }
        //================================================================================================================
        //======= this codes below for insert Data to the Empvariabel table / Using the EmployeeVariableinsertinto Procedure
        public DataTable EmpVarInsertData(DataGridView VarDgv, TextBox VarIDseq, TextBox VarIDcon, TextBox Varempname, ComboBox Vartype, TextBox Varcount
           , ComboBox Vartype2, DateTimePicker VarDate, DateTimePicker Varcomming, TextBox VarNotice, TextBox Varregistername
           , TextBox VarAddingTime, TextBox VarAddingDate,DevExpress.XtraEditors.ToggleSwitch VartypeAdd
            ,DevExpress.XtraEditors.ToggleSwitch VarTypeNotAdd, Panel Varpn, int VarIDcon1, string varempname1, string vartype1, double varcount1
            , string vartype21, string varDate1, string Varcomming1, string VarNotice1, string Varregistername1, string VarAddingTime1,
            string VarAddingDate1,bool VarTypeAdd2,bool VarTypeNotAdd2)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@VarIDcon", SqlDbType.Int);                                    param[0].Value = VarIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);                             param[1].Value = varempname1;
            param[2] = new SqlParameter("@variableType", SqlDbType.VarChar,50);                         param[2].Value = vartype1;
            param[3] = new SqlParameter("@variableCount", SqlDbType.Real);                              param[3].Value = varcount1;
            param[4] = new SqlParameter("@TheType2", SqlDbType.VarChar, 50);                            param[4].Value = vartype21;
            param[5] = new SqlParameter("@VariableDate", SqlDbType.VarChar, 50);                        param[5].Value = varDate1;
            param[6] = new SqlParameter("@CommingDate", SqlDbType.VarChar, 50);                         param[6].Value = Varcomming1;
            param[7] = new SqlParameter("@Notic", SqlDbType.Text);                                      param[7].Value = VarNotice1;
            param[8] = new SqlParameter("@registerName", SqlDbType.VarChar, 50);                        param[8].Value = Varregistername1;
            param[9] = new SqlParameter("@Addingtime", SqlDbType.VarChar, 50);                          param[9].Value = VarAddingTime1;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);                         param[10].Value = VarAddingDate1;
            param[11] = new SqlParameter("@VarTypeAdd", SqlDbType.Bit);                                 param[11].Value = VarTypeAdd2;
            param[12] = new SqlParameter("@VarTypeNotAdd", SqlDbType.Bit);                              param[12].Value = VarTypeNotAdd2;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVariableInsertInot", param);
            dal.close();
            DataTable dtv= EmpVarGettingData(VarDgv, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, Varcomming, VarNotice, Varregistername
                , VarAddingTime, VarAddingDate, Varpn, VarIDcon1,VartypeAdd,VarTypeNotAdd);
            return dtv;
        }
        //===========================================================================================================================
        //===============This codes below for Update Data to the EmpVariable Table / Using the EmployeeVariableUpdate Procedure 
        public DataTable EmpVarUpdateData(DataGridView VarDgv, TextBox VarIDseq, TextBox VarIDcon, TextBox Varempname, ComboBox Vartype
            , TextBox Varcount, ComboBox Vartype2, DateTimePicker VarDate, DateTimePicker Varcomming, TextBox VarNotice
            , TextBox Varregistername, TextBox VarAddingTime, TextBox VarAddingDate
            , DevExpress.XtraEditors.ToggleSwitch VartypeAdd
            , DevExpress.XtraEditors.ToggleSwitch VarTypeNotAdd, Panel Varpn, int VarIDcon1, string varempname1
            , string vartype1, double varcount1, string vartype21, string varDate1, string Varcomming1, string VarNotice1
            , string Varregistername1, string VarAddingTime1, string VarAddingDate1, int VarID,bool VarTypeAdd2,bool VarTypeNotAdd2)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@IDconvar", SqlDbType.Int);                        param[0].Value = VarIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50);                 param[1].Value = varempname1;
            param[2] = new SqlParameter("@variableType", SqlDbType.VarChar, 50);            param[2].Value = vartype1;
            param[3] = new SqlParameter("@variableCount", SqlDbType.Real);                  param[3].Value = varcount1;
            param[4] = new SqlParameter("@TheType2", SqlDbType.VarChar, 50);                param[4].Value = vartype21;
            param[5] = new SqlParameter("@VariableDate", SqlDbType.VarChar, 50);            param[5].Value = varDate1;
            param[6] = new SqlParameter("@CommingDate", SqlDbType.VarChar, 50);             param[6].Value = Varcomming1;
            param[7] = new SqlParameter("@Notic", SqlDbType.Text);                          param[7].Value = VarNotice1;
            param[8] = new SqlParameter("@registerName", SqlDbType.VarChar, 50);            param[8].Value = Varregistername1;
            param[9] = new SqlParameter("@Addingtime", SqlDbType.VarChar, 50);              param[9].Value = VarAddingTime1;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);             param[10].Value = VarAddingDate1;
            param[11] = new SqlParameter("@IDvar", SqlDbType.Int);                          param[11].Value = VarID;
            param[12] = new SqlParameter("@VarTypeAdd", SqlDbType.Bit);                     param[12].Value = VarTypeAdd2;
            param[13] = new SqlParameter("@VarTypeNotAdd", SqlDbType.Bit);                  param[13].Value = VarTypeNotAdd2;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVariableUpdate", param);
            dal.close();
            DataTable dtv= EmpVarGettingData(VarDgv, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, Varcomming, VarNotice, Varregistername
                , VarAddingTime, VarAddingDate, Varpn, VarIDcon1,VartypeAdd,VarTypeNotAdd);
            return dtv;
        }
        //=========================================================================================================================================]
        //======== This codes below for Delete Data from the Empvariable tabel / Using the RmployeeVariableDeleting Procedure
        public DataTable EmpVarDeleteData(DataGridView VarDgv, TextBox VarIDseq, TextBox VarIDcon, TextBox Varempname, ComboBox Vartype
            , TextBox Varcount, ComboBox Vartype2, DateTimePicker VarDate, DateTimePicker Varcomming, TextBox VarNotice
            , TextBox Varregistername, TextBox VarAddingTime, TextBox VarAddingDate
            , DevExpress.XtraEditors.ToggleSwitch VartypeAdd
            , DevExpress.XtraEditors.ToggleSwitch VarTypeNotAdd, Panel Varpn, int VarIDcon1, int VarID)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDvar", SqlDbType.Int); param[0].Value = VarID;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVariableDeleting", param);
            dal.close();
            DataTable dtv= EmpVarGettingData(VarDgv, VarIDseq, VarIDcon, Varempname, Vartype, Varcount, Vartype2, VarDate, Varcomming, VarNotice, Varregistername
                , VarAddingTime, VarAddingDate, Varpn, VarIDcon1,VartypeAdd,VarTypeNotAdd);
            return dtv;
        }
        //[*****************************************************************************************************************************************]
        //[=========================================================================================================================================]
        //[========================================= building the EmpDeserve interface
        //[======= This Codes Below for Getting Data from the EmpDeserve Table / Using the EmployeeDeservingSelecting procedure
        public DataTable EmpDesGettingData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
            , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
            , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
            , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30,
            Panel PnDes, int IDseq, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate, TextBox DesmNotic)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservingSelecting", param);
            dal.close();
            DgvDes.DataSource = null; DgvDes.DataSource = Dt;
            foreach (Control p in PnDes.Controls) { if (p is TextBox) { (p as TextBox).DataBindings.Clear(); } }
            Desyear.DataBindings.Clear();
            for (int x = 4; x < DgvDes.Columns.Count; x++)
            {
                for (int j = 0; j < 3; j++)
                {
                    DgvDes.Columns[x].Visible = false;
                    DgvDes.Columns[j].Visible = false;
                    DgvDes.Columns[3].HeaderText = "السنة";
                    DgvDes.Columns[3].Width = 150;
                }
            }

            DesIDseq.DataBindings.Clear();
            DesIDcon.DataBindings.Clear();
            DesEmpname.DataBindings.Clear();
            Desyear.DataBindings.Clear();
            Desm1.DataBindings.Clear(); Desm2.DataBindings.Clear(); Desm3.DataBindings.Clear();
            Desm4.DataBindings.Clear(); Desm5.DataBindings.Clear(); Desm6.DataBindings.Clear();
            Desm7.DataBindings.Clear(); Desm8.DataBindings.Clear(); Desm9.DataBindings.Clear();
            Desm10.DataBindings.Clear(); Desm11.DataBindings.Clear(); Desm12.DataBindings.Clear();
            Desm13.DataBindings.Clear(); Desm14.DataBindings.Clear(); Desm15.DataBindings.Clear(); 
            Desm16.DataBindings.Clear(); Desm17.DataBindings.Clear(); Desm18.DataBindings.Clear();
            Desm19.DataBindings.Clear(); Desm20.DataBindings.Clear(); Desm21.DataBindings.Clear(); 
            Desm22.DataBindings.Clear(); Desm23.DataBindings.Clear(); Desm24.DataBindings.Clear(); 
            Desm25.DataBindings.Clear(); Desm26.DataBindings.Clear(); Desm27.DataBindings.Clear(); 
            Desm28.DataBindings.Clear(); Desm29.DataBindings.Clear(); Desm30.DataBindings.Clear();
            RegisterName.DataBindings.Clear(); AddingTime.DataBindings.Clear(); AddingDate.DataBindings.Clear();
            DesmNotic.DataBindings.Clear();

            string p1 = "Text";
            DesIDseq.DataBindings.Add(p1, Dt, "IDdeserve");
            DesIDcon.DataBindings.Add(p1, Dt, "IDconempdeserve");
            DesEmpname.DataBindings.Add(p1, Dt, "EmployeeName");
            Desyear.DataBindings.Add(p1, Dt, "Emp_years");
            Desm1.DataBindings.Add(p1, Dt, "m1"); Desm2.DataBindings.Add(p1, Dt, "m2"); Desm3.DataBindings.Add(p1, Dt, "m3");
            Desm4.DataBindings.Add(p1, Dt, "m4"); Desm5.DataBindings.Add(p1, Dt, "m5"); Desm6.DataBindings.Add(p1, Dt, "m6");
            Desm7.DataBindings.Add(p1, Dt, "m7"); Desm8.DataBindings.Add(p1, Dt, "m8"); Desm9.DataBindings.Add(p1, Dt, "m9");
            Desm10.DataBindings.Add(p1, Dt, "m10"); Desm11.DataBindings.Add(p1, Dt, "m11"); Desm12.DataBindings.Add(p1, Dt, "m12");
            Desm13.DataBindings.Add(p1, Dt, "m13"); Desm14.DataBindings.Add(p1, Dt, "m14"); Desm15.DataBindings.Add(p1, Dt, "m15"); 
            Desm16.DataBindings.Add(p1, Dt, "m16"); Desm17.DataBindings.Add(p1, Dt, "m17"); Desm18.DataBindings.Add(p1, Dt, "m18"); 
            Desm19.DataBindings.Add(p1, Dt, "m19"); Desm20.DataBindings.Add(p1, Dt, "m20"); Desm21.DataBindings.Add(p1, Dt, "m21"); 
            Desm22.DataBindings.Add(p1, Dt, "m22"); Desm23.DataBindings.Add(p1, Dt, "m23"); Desm24.DataBindings.Add(p1, Dt, "m24");
            Desm25.DataBindings.Add(p1, Dt, "m25"); Desm26.DataBindings.Add(p1, Dt, "m26"); Desm27.DataBindings.Add(p1, Dt, "m27");
            Desm28.DataBindings.Add(p1, Dt, "m28"); Desm29.DataBindings.Add(p1, Dt, "m29"); Desm30.DataBindings.Add(p1, Dt, "m30");
            RegisterName.DataBindings.Add(p1, Dt, "RegisterName"); AddingTime.DataBindings.Add(p1, Dt, "AddingTime"); AddingDate.DataBindings.Add(p1, Dt, "AddingDate");
            DesmNotic.DataBindings.Add(p1, Dt, "DesmNotic");
            return Dt;

        }
        //[===================================================================================================================================
        //======== this codes Below for insert data to the EmpDeserve table / using the EmployeeDeserveinsertinto Procedure 
        public void EmpDesInsertData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
           , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30,
            Panel PnDes, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate, TextBox DesmNotic,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string m16, string m17, string m18, string m19, string m20, string m21, string m22
            , string m23, string m24, string m25, string m26, string m27, string m28, string m29, string m30, string DesmNoticstring)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50); param[18].Value = m16;
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50); param[19].Value = m17;
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50); param[20].Value = m18;
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50); param[21].Value = m19;
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50); param[22].Value = m20;
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50); param[23].Value = m21;
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50); param[24].Value = m22;
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50); param[25].Value = m23;
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50); param[26].Value = m24;
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50); param[27].Value = m25;
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50); param[28].Value = m26;
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50); param[29].Value = m27;
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50); param[30].Value = m28;
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50); param[31].Value = m29;
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50); param[32].Value = m30;
            param[33] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[33].Value = Properties.Settings.Default.UserNameLogin;
            param[34] = new SqlParameter("@DesmNotic", SqlDbType.VarChar, 200); param[34].Value = DesmNoticstring;

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveInsertinto", param);
            dal.close();
            EmpDesGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
           , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
           , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
           , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
           PnDes, int.Parse(DesIDcon.Text),RegisterName,AddingTime,AddingDate, DesmNotic);
        }
        //[[===========================================================================================================]]]====================
        //============== This codes below for updata the EmpDeserve Table / Using the EmployeeDeserveUpdate Procedure
        public void EmpDesUpdatetData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
           , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30, 
            Panel PnDes, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate, TextBox DesmNotic,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string m16, string m17, string m18, string m19, string m20, string m21, string m22
            , string m23, string m24, string m25, string m26, string m27, string m28, string m29, string m30, string DesmNoticstring, int Desseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[36];
            param[0] = new SqlParameter("@IDcondeserv", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50); param[18].Value = m16;
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50); param[19].Value = m17;
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50); param[20].Value = m18;
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50); param[21].Value = m19;
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50); param[22].Value = m20;
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50); param[23].Value = m21;
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50); param[24].Value = m22;
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50); param[25].Value = m23;
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50); param[26].Value = m24;
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50); param[27].Value = m25;
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50); param[28].Value = m26;
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50); param[29].Value = m27;
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50); param[30].Value = m28;
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50); param[31].Value = m29;
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50); param[32].Value = m30;
            param[33] = new SqlParameter("@IDdeserve", SqlDbType.Int);   param[33].Value = Desseq;
            param[34] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[34].Value = Properties.Settings.Default.UserNameLogin;
            param[35] = new SqlParameter("@DesmNotic", SqlDbType.VarChar, 200); param[35].Value = DesmNoticstring;

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveUpdate", param);
            dal.close();
            EmpDesGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
           , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
           , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
           , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
           PnDes, int.Parse(DesIDcon.Text), RegisterName,AddingTime,AddingDate, DesmNotic);
        }
        //[[=================================================================================================================================
        //[[============= This codes below for Delete Data from EmpDeserve tabel / Using the EmployeeDeservingDeleting Procedure
        public void EmpDesDeleteData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
           , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30,
            Panel PnDes, int Desseq, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate, TextBox DesmNotic)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdes", SqlDbType.Int); param[0].Value = Desseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservingdeleting", param);
            dal.close();
            EmpDesGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
           , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
           , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
           , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29, Desm30,
           PnDes, int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate, DesmNotic);
        }
        //[[=============================================================================================================================
        //[[*****************************************************************************************************************************
        //[[============= Build the Deserve Pressing Employees Form 
        //[======= This Codes Below for Getting Data from the EmpDeservePressing Table / Using the EmployeeDeservPressingSelecting procedure
        public DataTable EmpDesPressingGettingDataDT(int IDseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservPressingSelectingAuto", param);
            dal.close();
            return Dt;
        }

        public DataTable EmpDesPressingGettingData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
        , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
        , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox DesmNote1, TextBox DesmNote2, TextBox DesmNote3, TextBox DesmNote4, TextBox DesmNote5
        , TextBox DesmNote6, TextBox DesmNote7, TextBox DesmNote8, TextBox DesmNote9, TextBox DesmNote10, TextBox DesmNote11, TextBox DesmNote12, TextBox DesmNote13, TextBox DesmNote14, TextBox DesmNote15,
        int IDseq, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservPressingSelecting", param);
            dal.close();
            DgvDes.DataSource = null; DgvDes.DataSource = Dt;
            
            Desyear.DataBindings.Clear();
            for (int x = 4; x < DgvDes.Columns.Count; x++)
            {
                for (int j = 0; j < 3; j++)
                {
                    DgvDes.Columns[x].Visible = false;
                    DgvDes.Columns[j].Visible = false;
                    DgvDes.Columns[3].HeaderText = "السنة";
                    DgvDes.Columns[3].Width = 150;
                }
            }

            DesIDseq.DataBindings.Clear();
            DesIDcon.DataBindings.Clear();
            DesEmpname.DataBindings.Clear();
            Desyear.DataBindings.Clear();
            Desm1.DataBindings.Clear(); Desm2.DataBindings.Clear(); Desm3.DataBindings.Clear();
            Desm4.DataBindings.Clear(); Desm5.DataBindings.Clear(); Desm6.DataBindings.Clear();
            Desm7.DataBindings.Clear(); Desm8.DataBindings.Clear(); Desm9.DataBindings.Clear();
            Desm10.DataBindings.Clear(); Desm11.DataBindings.Clear(); Desm12.DataBindings.Clear();
            Desm13.DataBindings.Clear(); Desm14.DataBindings.Clear(); Desm15.DataBindings.Clear();
            DesmNote1.DataBindings.Clear(); DesmNote2.DataBindings.Clear(); DesmNote3.DataBindings.Clear();
            DesmNote4.DataBindings.Clear(); DesmNote5.DataBindings.Clear(); DesmNote6.DataBindings.Clear();
            DesmNote7.DataBindings.Clear(); DesmNote8.DataBindings.Clear(); DesmNote9.DataBindings.Clear();
            DesmNote10.DataBindings.Clear(); DesmNote11.DataBindings.Clear(); DesmNote12.DataBindings.Clear();
            DesmNote13.DataBindings.Clear(); DesmNote14.DataBindings.Clear(); DesmNote15.DataBindings.Clear();
            RegisterName.DataBindings.Clear(); AddingTime.DataBindings.Clear(); AddingDate.DataBindings.Clear();
          

            string p1 = "Text";
            DesIDseq.DataBindings.Add(p1, Dt, "IDdeserve");
            DesIDcon.DataBindings.Add(p1, Dt, "IDcondeserv");
            DesEmpname.DataBindings.Add(p1, Dt, "EmpName");
            Desyear.DataBindings.Add(p1, Dt, "Empyear");
            Desm1.DataBindings.Add(p1, Dt, "m1"); Desm2.DataBindings.Add(p1, Dt, "m2"); Desm3.DataBindings.Add(p1, Dt, "m3");
            Desm4.DataBindings.Add(p1, Dt, "m4"); Desm5.DataBindings.Add(p1, Dt, "m5"); Desm6.DataBindings.Add(p1, Dt, "m6");
            Desm7.DataBindings.Add(p1, Dt, "m7"); Desm8.DataBindings.Add(p1, Dt, "m8"); Desm9.DataBindings.Add(p1, Dt, "m9");
            Desm10.DataBindings.Add(p1, Dt, "m10"); Desm11.DataBindings.Add(p1, Dt, "m11"); Desm12.DataBindings.Add(p1, Dt, "m12");
            Desm13.DataBindings.Add(p1, Dt, "m13"); Desm14.DataBindings.Add(p1, Dt, "m14"); Desm15.DataBindings.Add(p1, Dt, "m15");
            DesmNote1.DataBindings.Add(p1, Dt, "mNote1"); DesmNote2.DataBindings.Add(p1, Dt, "mNote2"); DesmNote3.DataBindings.Add(p1, Dt, "mNote3");
            DesmNote4.DataBindings.Add(p1, Dt, "mNote4"); DesmNote5.DataBindings.Add(p1, Dt, "mNote5"); DesmNote6.DataBindings.Add(p1, Dt, "mNote6");
            DesmNote7.DataBindings.Add(p1, Dt, "mNote7"); DesmNote8.DataBindings.Add(p1, Dt, "mNote8"); DesmNote9.DataBindings.Add(p1, Dt, "mNote9");
            DesmNote10.DataBindings.Add(p1, Dt, "mNote10"); DesmNote11.DataBindings.Add(p1, Dt, "mNote11"); DesmNote12.DataBindings.Add(p1, Dt, "mNote12");
            DesmNote13.DataBindings.Add(p1, Dt, "mNote13"); DesmNote14.DataBindings.Add(p1, Dt, "mNote14"); DesmNote15.DataBindings.Add(p1, Dt, "mNote15");
            RegisterName.DataBindings.Add(p1, Dt, "RegisterName"); AddingTime.DataBindings.Add(p1, Dt, "AddingTime"); AddingDate.DataBindings.Add(p1, Dt, "AddingDate");
            
            return Dt;

        }

        //[===================================================================================================================================
        //======== this codes Below for insert data to the EmpDeservePressing table / using the EmployeeDeservePressinginsertinto Procedure 
        public void EmpDesPressingInsertData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox DesmNote1, TextBox DesmNote2, TextBox DesmNote3, TextBox DesmNote4, TextBox DesmNote5
            , TextBox DesmNote6, TextBox DesmNote7, TextBox DesmNote8, TextBox DesmNote9, TextBox DesmNote10, TextBox DesmNote11, TextBox DesmNote12, TextBox DesmNote13, TextBox DesmNote14, TextBox DesmNote15,
            TextBox RegisterName, TextBox AddingTime, TextBox AddingDate,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string mNote1, string mNote2, string mNote3, string mNote4, string mNote5, string mNote6, string mNote7
            , string mNote8, string mNote9, string mNote10, string mNote11, string mNote12, string mNote13, string mNote14, string mNote15)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[34];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@mNote1", SqlDbType.VarChar, 100); param[18].Value = mNote1;
            param[19] = new SqlParameter("@mNote2", SqlDbType.VarChar, 100); param[19].Value = mNote2;
            param[20] = new SqlParameter("@mNote3", SqlDbType.VarChar, 100); param[20].Value = mNote3;
            param[21] = new SqlParameter("@mNote4", SqlDbType.VarChar, 100); param[21].Value = mNote4;
            param[22] = new SqlParameter("@mNote5", SqlDbType.VarChar, 100); param[22].Value = mNote5;
            param[23] = new SqlParameter("@mNote6", SqlDbType.VarChar, 100); param[23].Value = mNote6;
            param[24] = new SqlParameter("@mNote7", SqlDbType.VarChar,100);  param[24].Value = mNote7;
            param[25] = new SqlParameter("@mNote8", SqlDbType.VarChar, 100); param[25].Value = mNote8;
            param[26] = new SqlParameter("@mNote9", SqlDbType.VarChar,100);  param[26].Value = mNote9;
            param[27] = new SqlParameter("@mNote10", SqlDbType.VarChar, 100); param[27].Value = mNote10;
            param[28] = new SqlParameter("@mNote11", SqlDbType.VarChar, 100); param[28].Value = mNote11;
            param[29] = new SqlParameter("@mNote12", SqlDbType.VarChar, 100); param[29].Value = mNote12;
            param[30] = new SqlParameter("@mNote13", SqlDbType.VarChar, 100); param[30].Value = mNote13;
            param[31] = new SqlParameter("@mNote14", SqlDbType.VarChar, 100); param[31].Value = mNote14;
            param[32] = new SqlParameter("@mNote15", SqlDbType.VarChar, 100); param[32].Value = mNote15;
            param[33] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[33].Value = Properties.Settings.Default.UserNameLogin;

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservePressingInsertinto", param);
            dal.close();
            EmpDesPressingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
           , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
           , Desm12, Desm13, Desm14, Desm15, DesmNote1, DesmNote2, DesmNote3, DesmNote4, DesmNote5
           , DesmNote6, DesmNote7, DesmNote8, DesmNote9, DesmNote10, DesmNote11, DesmNote12, DesmNote13, DesmNote14, DesmNote15,
            int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }
        //[[===========================================================================================================]]]====================
        //============== This codes below for updata the EmpDeservePressing Table / Using the EmployeeDeservePressingUpdate Procedure
        public void EmpDesPressingUpdatetData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox DesmNote1, TextBox DesmNote2, TextBox DesmNote3, TextBox DesmNote4, TextBox DesmNote5
            , TextBox DesmNote6, TextBox DesmNote7, TextBox DesmNote8, TextBox DesmNote9, TextBox DesmNote10, TextBox DesmNote11, TextBox DesmNote12, TextBox DesmNote13, TextBox DesmNote14, TextBox DesmNote15,
            TextBox RegisterName, TextBox AddingTime, TextBox AddingDate,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string mNote1, string mNote2, string mNote3, string mNote4, string mNote5, string mNote6, string mNote7
            , string mNote8, string mNote9, string mNote10, string mNote11, string mNote12, string mNote13, string mNote14, string mNote15, int Desseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[35];
            param[0] = new SqlParameter("@IDcondeserv", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@mNote1", SqlDbType.VarChar,100); param[18].Value = mNote1;
            param[19] = new SqlParameter("@mNote2", SqlDbType.VarChar, 100); param[19].Value = mNote2;
            param[20] = new SqlParameter("@mNote3", SqlDbType.VarChar, 100); param[20].Value = mNote3;
            param[21] = new SqlParameter("@mNote4", SqlDbType.VarChar, 100); param[21].Value = mNote4;
            param[22] = new SqlParameter("@mNote5", SqlDbType.VarChar, 100); param[22].Value = mNote5;
            param[23] = new SqlParameter("@mNote6", SqlDbType.VarChar, 100); param[23].Value = mNote6;
            param[24] = new SqlParameter("@mNote7", SqlDbType.VarChar, 100); param[24].Value = mNote7;
            param[25] = new SqlParameter("@mNote8", SqlDbType.VarChar, 100); param[25].Value = mNote8;
            param[26] = new SqlParameter("@mNote9", SqlDbType.VarChar, 100); param[26].Value = mNote9;
            param[27] = new SqlParameter("@mNote10", SqlDbType.VarChar, 100); param[27].Value = mNote10;
            param[28] = new SqlParameter("@mNote11", SqlDbType.VarChar,100); param[28].Value = mNote11;
            param[29] = new SqlParameter("@mNote12", SqlDbType.VarChar, 100); param[29].Value = mNote12;
            param[30] = new SqlParameter("@mNote13", SqlDbType.VarChar, 100); param[30].Value = mNote13;
            param[31] = new SqlParameter("@mNote14", SqlDbType.VarChar, 100); param[31].Value = mNote14;
            param[32] = new SqlParameter("@mNote15", SqlDbType.VarChar, 100); param[32].Value = mNote15;
            param[33] = new SqlParameter("@IDdeserve", SqlDbType.Int); param[33].Value = Desseq;
            param[34] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[34].Value = Properties.Settings.Default.UserNameLogin;
          

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservePressingUpdate", param);
            dal.close();
            EmpDesPressingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
             , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
             , Desm12, Desm13, Desm14, Desm15, DesmNote1, DesmNote2, DesmNote3, DesmNote4, DesmNote5
             , DesmNote6, DesmNote7, DesmNote8, DesmNote9, DesmNote10, DesmNote11, DesmNote12, DesmNote13, DesmNote14, DesmNote15,
              int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }

        public void EmpDesPressingUpdatetDataAuto(int idcon, DateTime vardate, int varcount)
        {
            DataTable dtsat = EmpDesPressingGettingDataDT(idcon);

            if (dtsat.Rows.Count > 0)
            {

                int j = 0;
                for (j = 4; j < 19; j++)
                {
                    if (dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == null || dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == "" || Convert.ToDateTime(dtsat.Rows[dtsat.Rows.Count - 1][j].ToString()) == vardate)
                    {
                        break;
                    }
                }

                if (dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == null || dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == "")
                {

                    for (int i = 0; i < varcount; i++)
                    {
                        if (j < 19)
                        {
                            dtsat.Rows[dtsat.Rows.Count - 1][j++] = vardate.AddDays(i).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            MessageBox.Show("تم استيفاء جميع الايام المتاحة في السنة والمتبقي من الاجازة " + (varcount - i) + " يوم");
                            break;
                        }
                    }
                }
                else
                {
                    if (j >= 19)
                    {
                        MessageBox.Show("لا يوجد ايام متوفرة اضف سنة جديدة");
                    }
                    else
                    {
                        MessageBox.Show("تاريخ الانقطاع مسجل مسبقا");
                    }
                }

                DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
                SqlParameter[] param = new SqlParameter[35];
                param[0] = new SqlParameter("@IDcondeserv", SqlDbType.Int); param[0].Value = int.Parse(dtsat.Rows[dtsat.Rows.Count - 1][1].ToString());
                param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = dtsat.Rows[dtsat.Rows.Count - 1][2].ToString(); 
                param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = dtsat.Rows[dtsat.Rows.Count - 1][3].ToString(); 
                param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = dtsat.Rows[dtsat.Rows.Count - 1][4].ToString(); 
                param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = dtsat.Rows[dtsat.Rows.Count - 1][5].ToString(); 
                param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = dtsat.Rows[dtsat.Rows.Count - 1][6].ToString(); 
                param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = dtsat.Rows[dtsat.Rows.Count - 1][7].ToString(); 
                param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = dtsat.Rows[dtsat.Rows.Count - 1][8].ToString(); 
                param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = dtsat.Rows[dtsat.Rows.Count - 1][9].ToString(); 
                param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = dtsat.Rows[dtsat.Rows.Count - 1][10].ToString(); 
                param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = dtsat.Rows[dtsat.Rows.Count - 1][11].ToString(); 
                param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = dtsat.Rows[dtsat.Rows.Count - 1][12].ToString(); 
                param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = dtsat.Rows[dtsat.Rows.Count - 1][13].ToString(); 
                param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = dtsat.Rows[dtsat.Rows.Count - 1][14].ToString(); 
                param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = dtsat.Rows[dtsat.Rows.Count - 1][15].ToString();
                param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = dtsat.Rows[dtsat.Rows.Count - 1][16].ToString();
                param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = dtsat.Rows[dtsat.Rows.Count - 1][17].ToString(); 
                param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = dtsat.Rows[dtsat.Rows.Count - 1][18].ToString(); 
                param[18] = new SqlParameter("@mNote1", SqlDbType.VarChar, 100); param[18].Value = dtsat.Rows[dtsat.Rows.Count - 1][19].ToString(); 
                param[19] = new SqlParameter("@mNote2", SqlDbType.VarChar, 100); param[19].Value = dtsat.Rows[dtsat.Rows.Count - 1][20].ToString(); 
                param[20] = new SqlParameter("@mNote3", SqlDbType.VarChar, 100); param[20].Value = dtsat.Rows[dtsat.Rows.Count - 1][21].ToString(); 
                param[21] = new SqlParameter("@mNote4", SqlDbType.VarChar, 100); param[21].Value = dtsat.Rows[dtsat.Rows.Count - 1][22].ToString(); 
                param[22] = new SqlParameter("@mNote5", SqlDbType.VarChar, 100); param[22].Value = dtsat.Rows[dtsat.Rows.Count - 1][23].ToString(); 
                param[23] = new SqlParameter("@mNote6", SqlDbType.VarChar, 100); param[23].Value = dtsat.Rows[dtsat.Rows.Count - 1][24].ToString(); 
                param[24] = new SqlParameter("@mNote7", SqlDbType.VarChar, 100); param[24].Value = dtsat.Rows[dtsat.Rows.Count - 1][25].ToString(); 
                param[25] = new SqlParameter("@mNote8", SqlDbType.VarChar, 100); param[25].Value = dtsat.Rows[dtsat.Rows.Count - 1][26].ToString(); 
                param[26] = new SqlParameter("@mNote9", SqlDbType.VarChar, 100); param[26].Value = dtsat.Rows[dtsat.Rows.Count - 1][27].ToString(); 
                param[27] = new SqlParameter("@mNote10", SqlDbType.VarChar, 100); param[27].Value = dtsat.Rows[dtsat.Rows.Count - 1][28].ToString(); 
                param[28] = new SqlParameter("@mNote11", SqlDbType.VarChar, 100); param[28].Value = dtsat.Rows[dtsat.Rows.Count - 1][29].ToString(); 
                param[29] = new SqlParameter("@mNote12", SqlDbType.VarChar, 100); param[29].Value = dtsat.Rows[dtsat.Rows.Count - 1][30].ToString();
                param[30] = new SqlParameter("@mNote13", SqlDbType.VarChar, 100); param[30].Value = dtsat.Rows[dtsat.Rows.Count - 1][31].ToString(); 
                param[31] = new SqlParameter("@mNote14", SqlDbType.VarChar, 100); param[31].Value = dtsat.Rows[dtsat.Rows.Count - 1][32].ToString(); 
                param[32] = new SqlParameter("@mNote15", SqlDbType.VarChar, 100); param[32].Value = dtsat.Rows[dtsat.Rows.Count - 1][33].ToString(); 
                param[33] = new SqlParameter("@IDdeserve", SqlDbType.Int); param[33].Value = int.Parse(dtsat.Rows[dtsat.Rows.Count - 1][0].ToString());
                param[34] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[34].Value = Properties.Settings.Default.UserNameLogin;


                dal.open();
                DataTable Dt = dal.SelectingData("EmployeeDeservePressingUpdate", param);
                dal.close();
            }
            else
            {
                MessageBox.Show("اضف سنة جديدة");
            }
        }
        //[[=================================================================================================================================
        //[[============= This codes below for Delete Data from EmpDeservePressing tabel / Using the EmployeeDeservePressingDeleting Procedure
        public void EmpDesPressingDeleteData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox DesmNote1, TextBox DesmNote2, TextBox DesmNote3, TextBox DesmNote4, TextBox DesmNote5
            , TextBox DesmNote6, TextBox DesmNote7, TextBox DesmNote8, TextBox DesmNote9, TextBox DesmNote10, TextBox DesmNote11, TextBox DesmNote12, TextBox DesmNote13, TextBox DesmNote14, TextBox DesmNote15,
             int Desseq, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdes", SqlDbType.Int); param[0].Value = Desseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeservePressingdeleting", param);
            dal.close();
            EmpDesPressingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
            , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
            , Desm12, Desm13, Desm14, Desm15, DesmNote1, DesmNote2, DesmNote3, DesmNote4, DesmNote5
            , DesmNote6, DesmNote7, DesmNote8, DesmNote9, DesmNote10, DesmNote11, DesmNote12, DesmNote13, DesmNote14, DesmNote15,
             int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }

        //[*****************************************************************************************************************************************]
        //[=========================================================================================================================================]
        //[========================================= building the EmpDeserveSatisfying interface
        //[======= This Codes Below for Getting Data from the EmpDeserveSatisfying Table / Using the EmployeeDeserveSatisfyingSelecting procedure

         // get as datatable 
        public DataTable EmpDesSatisfyingGettingDataDT(int IDseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyingSelectingAuto", param);
            dal.close();

            return Dt;
        }

        // get as datatable and put data in textbox
        public DataTable EmpDesSatisfyingGettingData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
        , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
        , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
        , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30
        , TextBox Desm31, TextBox Desm32, TextBox Desm33, TextBox Desm34, TextBox Desm35, TextBox Desm36
        , TextBox Desm37, TextBox Desm38, TextBox Desm39, TextBox Desm40, TextBox Desm41, TextBox Desm42, TextBox Desm43, TextBox Desm44, TextBox Desm45
        , int IDseq, TextBox RegisterName, TextBox AddingTime, TextBox AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyingSelecting", param);
            dal.close();
            DgvDes.DataSource = null; DgvDes.DataSource = Dt;
            
            Desyear.DataBindings.Clear();
            for (int x = 4; x < DgvDes.Columns.Count; x++)
            {
                for (int j = 0; j < 3; j++)
                {
                    DgvDes.Columns[x].Visible = false;
                    DgvDes.Columns[j].Visible = false;
                    DgvDes.Columns[3].HeaderText = "السنة";
                    DgvDes.Columns[3].Width = 150;
                }
            }

            DesIDseq.DataBindings.Clear();
            DesIDcon.DataBindings.Clear();
            DesEmpname.DataBindings.Clear();
            Desyear.DataBindings.Clear();
            Desm1.DataBindings.Clear(); Desm2.DataBindings.Clear(); Desm3.DataBindings.Clear();
            Desm4.DataBindings.Clear(); Desm5.DataBindings.Clear(); Desm6.DataBindings.Clear();
            Desm7.DataBindings.Clear(); Desm8.DataBindings.Clear(); Desm9.DataBindings.Clear();
            Desm10.DataBindings.Clear(); Desm11.DataBindings.Clear(); Desm12.DataBindings.Clear();
            Desm13.DataBindings.Clear(); Desm14.DataBindings.Clear(); Desm15.DataBindings.Clear();
            Desm16.DataBindings.Clear(); Desm17.DataBindings.Clear(); Desm18.DataBindings.Clear();
            Desm19.DataBindings.Clear(); Desm20.DataBindings.Clear(); Desm21.DataBindings.Clear();
            Desm22.DataBindings.Clear(); Desm23.DataBindings.Clear(); Desm24.DataBindings.Clear();
            Desm25.DataBindings.Clear(); Desm26.DataBindings.Clear(); Desm27.DataBindings.Clear();
            Desm28.DataBindings.Clear(); Desm29.DataBindings.Clear(); Desm30.DataBindings.Clear();
            Desm31.DataBindings.Clear(); Desm32.DataBindings.Clear(); Desm33.DataBindings.Clear();        
            Desm34.DataBindings.Clear(); Desm35.DataBindings.Clear(); Desm36.DataBindings.Clear();
            Desm37.DataBindings.Clear(); Desm38.DataBindings.Clear(); Desm39.DataBindings.Clear();
            Desm40.DataBindings.Clear(); Desm41.DataBindings.Clear(); Desm42.DataBindings.Clear();
            Desm43.DataBindings.Clear(); Desm44.DataBindings.Clear(); Desm45.DataBindings.Clear();
            RegisterName.DataBindings.Clear(); AddingTime.DataBindings.Clear(); AddingDate.DataBindings.Clear();
           

            string p1 = "Text";
            DesIDseq.DataBindings.Add(p1, Dt, "IDdeserve");
            DesIDcon.DataBindings.Add(p1, Dt, "IDcondeserv");
            DesEmpname.DataBindings.Add(p1, Dt, "EmpName");
            Desyear.DataBindings.Add(p1, Dt, "Empyear");
            Desm1.DataBindings.Add(p1, Dt, "m1"); Desm2.DataBindings.Add(p1, Dt, "m2"); Desm3.DataBindings.Add(p1, Dt, "m3");
            Desm4.DataBindings.Add(p1, Dt, "m4"); Desm5.DataBindings.Add(p1, Dt, "m5"); Desm6.DataBindings.Add(p1, Dt, "m6");
            Desm7.DataBindings.Add(p1, Dt, "m7"); Desm8.DataBindings.Add(p1, Dt, "m8"); Desm9.DataBindings.Add(p1, Dt, "m9");
            Desm10.DataBindings.Add(p1, Dt, "m10"); Desm11.DataBindings.Add(p1, Dt, "m11"); Desm12.DataBindings.Add(p1, Dt, "m12");
            Desm13.DataBindings.Add(p1, Dt, "m13"); Desm14.DataBindings.Add(p1, Dt, "m14"); Desm15.DataBindings.Add(p1, Dt, "m15");
            Desm16.DataBindings.Add(p1, Dt, "m16"); Desm17.DataBindings.Add(p1, Dt, "m17"); Desm18.DataBindings.Add(p1, Dt, "m18");
            Desm19.DataBindings.Add(p1, Dt, "m19"); Desm20.DataBindings.Add(p1, Dt, "m20"); Desm21.DataBindings.Add(p1, Dt, "m21");
            Desm22.DataBindings.Add(p1, Dt, "m22"); Desm23.DataBindings.Add(p1, Dt, "m23"); Desm24.DataBindings.Add(p1, Dt, "m24");
            Desm25.DataBindings.Add(p1, Dt, "m25"); Desm26.DataBindings.Add(p1, Dt, "m26"); Desm27.DataBindings.Add(p1, Dt, "m27");
            Desm28.DataBindings.Add(p1, Dt, "m28"); Desm29.DataBindings.Add(p1, Dt, "m29"); Desm30.DataBindings.Add(p1, Dt, "m30");
            Desm31.DataBindings.Add(p1, Dt, "m31"); Desm32.DataBindings.Add(p1, Dt, "m32"); Desm33.DataBindings.Add(p1, Dt, "m33");            
            Desm34.DataBindings.Add(p1, Dt, "m34"); Desm35.DataBindings.Add(p1, Dt, "m35"); Desm36.DataBindings.Add(p1, Dt, "m36");
            Desm37.DataBindings.Add(p1, Dt, "m37"); Desm38.DataBindings.Add(p1, Dt, "m38"); Desm39.DataBindings.Add(p1, Dt, "m39");
            Desm40.DataBindings.Add(p1, Dt, "m40"); Desm41.DataBindings.Add(p1, Dt, "m41"); Desm42.DataBindings.Add(p1, Dt, "m42");
            Desm43.DataBindings.Add(p1, Dt, "m43"); Desm44.DataBindings.Add(p1, Dt, "m44"); Desm45.DataBindings.Add(p1, Dt, "m45");
            RegisterName.DataBindings.Add(p1, Dt, "RegisterName"); AddingTime.DataBindings.Add(p1, Dt, "AddingTime"); AddingDate.DataBindings.Add(p1, Dt, "AddingDate");

        
           
            return Dt;

        }
        //[===================================================================================================================================
        //======== this codes Below for insert data to the EmpDeserveSatisfying table / using the EmployeeDeserveSatisfyinginsertinto Procedure 
        public void EmpDesSatisfyingInsertData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
            , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
            , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
            , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30
            , TextBox Desm31, TextBox Desm32, TextBox Desm33, TextBox Desm34, TextBox Desm35, TextBox Desm36
            , TextBox Desm37, TextBox Desm38, TextBox Desm39, TextBox Desm40, TextBox Desm41, TextBox Desm42, TextBox Desm43, TextBox Desm44, TextBox Desm45
            , TextBox RegisterName, TextBox AddingTime, TextBox AddingDate,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string m16, string m17, string m18, string m19, string m20, string m21, string m22
            , string m23, string m24, string m25, string m26, string m27, string m28, string m29, string m30, string m31, string m32, string m33, string m34
            , string m35, string m36, string m37, string m38, string m39, string m40, string m41, string m42, string m43, string m44, string m45)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[49];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50); param[18].Value = m16;
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50); param[19].Value = m17;
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50); param[20].Value = m18;
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50); param[21].Value = m19;
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50); param[22].Value = m20;
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50); param[23].Value = m21;
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50); param[24].Value = m22;
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50); param[25].Value = m23;
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50); param[26].Value = m24;
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50); param[27].Value = m25;
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50); param[28].Value = m26;
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50); param[29].Value = m27;
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50); param[30].Value = m28;
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50); param[31].Value = m29;
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50); param[32].Value = m30;
            param[33] = new SqlParameter("@m31", SqlDbType.VarChar, 50); param[33].Value = m31;
            param[34] = new SqlParameter("@m32", SqlDbType.VarChar, 50); param[34].Value = m32;
            param[35] = new SqlParameter("@m33", SqlDbType.VarChar, 50); param[35].Value = m33;
            param[36] = new SqlParameter("@m34", SqlDbType.VarChar, 50); param[36].Value = m34;
            param[37] = new SqlParameter("@m35", SqlDbType.VarChar, 50); param[37].Value = m35;
            param[38] = new SqlParameter("@m36", SqlDbType.VarChar, 50); param[38].Value = m36;
            param[39] = new SqlParameter("@m37", SqlDbType.VarChar, 50); param[39].Value = m37;
            param[40] = new SqlParameter("@m38", SqlDbType.VarChar, 50); param[40].Value = m38;
            param[41] = new SqlParameter("@m39", SqlDbType.VarChar, 50); param[41].Value = m39;
            param[42] = new SqlParameter("@m40", SqlDbType.VarChar, 50); param[42].Value = m40;
            param[43] = new SqlParameter("@m41", SqlDbType.VarChar, 50); param[43].Value = m41;
            param[44] = new SqlParameter("@m42", SqlDbType.VarChar, 50); param[44].Value = m42;
            param[45] = new SqlParameter("@m43", SqlDbType.VarChar, 50); param[45].Value = m43;
            param[46] = new SqlParameter("@m44", SqlDbType.VarChar, 50); param[46].Value = m44;
            param[47] = new SqlParameter("@m45", SqlDbType.VarChar, 50); param[47].Value = m45;
            param[48] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[48].Value = Properties.Settings.Default.UserNameLogin;
           

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyinginsertinto", param);
            dal.close();
            EmpDesSatisfyingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
           , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
           , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
           , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29
           , Desm30, Desm31, Desm32, Desm33, Desm34, Desm35, Desm36, Desm37, Desm38
           , Desm39, Desm40, Desm41, Desm42, Desm43, Desm44, Desm45,
           int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }
        //[[===========================================================================================================]]]====================
        //============== This codes below for updata the EmpDeserveSatisfying Table / Using the EmployeeDeserveSatisfyingUpdate Procedure
        public void EmpDesSatisfyingUpdatetData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
           , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30
           , TextBox Desm31, TextBox Desm32, TextBox Desm33, TextBox Desm34, TextBox Desm35, TextBox Desm36
           , TextBox Desm37, TextBox Desm38, TextBox Desm39, TextBox Desm40, TextBox Desm41, TextBox Desm42, TextBox Desm43, TextBox Desm44, TextBox Desm45
           , TextBox RegisterName, TextBox AddingTime, TextBox AddingDate,
            int DesIDcon1, string DesEmpname1
            , string Desyear1, string m1, string m2, string m3, string m4, string m5, string m6, string m7, string m8, string m9, string m10, string m11
            , string m12, string m13, string m14, string m15, string m16, string m17, string m18, string m19, string m20, string m21, string m22
            , string m23, string m24, string m25, string m26, string m27, string m28, string m29, string m30, string m31, string m32, string m33, string m34
            , string m35, string m36, string m37, string m38, string m39, string m40, string m41, string m42, string m43, string m44, string m45, int Desseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[50];
            param[0] = new SqlParameter("@IDcondeserv", SqlDbType.Int); param[0].Value = DesIDcon1;
            param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = DesEmpname1;
            param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = Desyear1;
            param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = m1;
            param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = m2;
            param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = m3;
            param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = m4;
            param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = m5;
            param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = m6;
            param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = m7;
            param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = m8;
            param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = m9;
            param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = m10;
            param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = m11;
            param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = m12;
            param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = m13;
            param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = m14;
            param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = m15;
            param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50); param[18].Value = m16;
            param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50); param[19].Value = m17;
            param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50); param[20].Value = m18;
            param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50); param[21].Value = m19;
            param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50); param[22].Value = m20;
            param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50); param[23].Value = m21;
            param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50); param[24].Value = m22;
            param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50); param[25].Value = m23;
            param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50); param[26].Value = m24;
            param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50); param[27].Value = m25;
            param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50); param[28].Value = m26;
            param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50); param[29].Value = m27;
            param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50); param[30].Value = m28;
            param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50); param[31].Value = m29;
            param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50); param[32].Value = m30;
            param[33] = new SqlParameter("@m31", SqlDbType.VarChar, 50); param[33].Value = m31;
            param[34] = new SqlParameter("@m32", SqlDbType.VarChar, 50); param[34].Value = m32;
            param[35] = new SqlParameter("@m33", SqlDbType.VarChar, 50); param[35].Value = m33;
            param[36] = new SqlParameter("@m34", SqlDbType.VarChar, 50); param[36].Value = m34;
            param[37] = new SqlParameter("@m35", SqlDbType.VarChar, 50); param[37].Value = m35;
            param[38] = new SqlParameter("@m36", SqlDbType.VarChar, 50); param[38].Value = m36;
            param[39] = new SqlParameter("@m37", SqlDbType.VarChar, 50); param[39].Value = m37;
            param[40] = new SqlParameter("@m38", SqlDbType.VarChar, 50); param[40].Value = m38;
            param[41] = new SqlParameter("@m39", SqlDbType.VarChar, 50); param[41].Value = m39;
            param[42] = new SqlParameter("@m40", SqlDbType.VarChar, 50); param[42].Value = m40;
            param[43] = new SqlParameter("@m41", SqlDbType.VarChar, 50); param[43].Value = m41;
            param[44] = new SqlParameter("@m42", SqlDbType.VarChar, 50); param[44].Value = m42;
            param[45] = new SqlParameter("@m43", SqlDbType.VarChar, 50); param[45].Value = m43;
            param[46] = new SqlParameter("@m44", SqlDbType.VarChar, 50); param[46].Value = m44;
            param[47] = new SqlParameter("@m45", SqlDbType.VarChar, 50); param[47].Value = m45;
            param[48] = new SqlParameter("@IDdeserve", SqlDbType.Int); param[48].Value = Desseq;
            param[49] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[49].Value = Properties.Settings.Default.UserNameLogin;
           

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyingUpdate", param);
            dal.close();
            EmpDesSatisfyingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
          , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
          , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
          , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29
          , Desm30, Desm31, Desm32, Desm33, Desm34, Desm35, Desm36, Desm37, Desm38
          , Desm39, Desm40, Desm41, Desm42, Desm43, Desm44, Desm45,
          int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }

        //Auto update the EmpDeserveSatisfying Table / Using the EmployeeDeserveSatisfyingUpdate Procedure with add new variable
        public void EmpDesSatisfyingUpdatetDataAuto(int idcon, DateTime vardate, int varcount)
        {

            DataTable dtsat = EmpDesSatisfyingGettingDataDT(idcon);

            if (dtsat.Rows.Count > 0)
            {

                int j = 0;
                for (j = 4; j < 49; j++)
                {
                    if (dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == null || dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == "" || Convert.ToDateTime(dtsat.Rows[dtsat.Rows.Count - 1][j].ToString()) == vardate)
                    {
                        break;
                    }
                }

                if (dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == null || dtsat.Rows[dtsat.Rows.Count - 1][j].ToString() == "")
                {
                   
                        for (int i = 0; i < varcount; i++)
                        {
                            if (j < 49)
                            {
                                dtsat.Rows[dtsat.Rows.Count - 1][j++] = vardate.AddDays(i).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                MessageBox.Show("تم استيفاء جميع الايام المتاحة في السنة والمتبقي من الاجازة "+(varcount-i)+" يوم");
                            break;
                            }
                        }
                   
                   
                }
                else
                {
                    if (j >= 49)
                    {
                        MessageBox.Show("لا يوجد ايام متوفرة اضف سنة جديدة");
                    }
                    else
                    {
                        MessageBox.Show("تاريخ الانقطاع مسجل مسبقا");
                    }
                }

                DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
                SqlParameter[] param = new SqlParameter[50];
                param[0] = new SqlParameter("@IDcondeserv", SqlDbType.Int); param[0].Value = int.Parse(dtsat.Rows[dtsat.Rows.Count - 1][1].ToString());
                param[1] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[1].Value = dtsat.Rows[dtsat.Rows.Count - 1][2].ToString();
                param[2] = new SqlParameter("@Empyear", SqlDbType.VarChar, 50); param[2].Value = dtsat.Rows[dtsat.Rows.Count - 1][3].ToString();
                param[3] = new SqlParameter("@m1", SqlDbType.VarChar, 50); param[3].Value = dtsat.Rows[dtsat.Rows.Count - 1][4].ToString();
                param[4] = new SqlParameter("@m2", SqlDbType.VarChar, 50); param[4].Value = dtsat.Rows[dtsat.Rows.Count - 1][5].ToString();
                param[5] = new SqlParameter("@m3", SqlDbType.VarChar, 50); param[5].Value = dtsat.Rows[dtsat.Rows.Count - 1][6].ToString();
                param[6] = new SqlParameter("@m4", SqlDbType.VarChar, 50); param[6].Value = dtsat.Rows[dtsat.Rows.Count - 1][7].ToString();
                param[7] = new SqlParameter("@m5", SqlDbType.VarChar, 50); param[7].Value = dtsat.Rows[dtsat.Rows.Count - 1][8].ToString();
                param[8] = new SqlParameter("@m6", SqlDbType.VarChar, 50); param[8].Value = dtsat.Rows[dtsat.Rows.Count - 1][9].ToString();
                param[9] = new SqlParameter("@m7", SqlDbType.VarChar, 50); param[9].Value = dtsat.Rows[dtsat.Rows.Count - 1][10].ToString();
                param[10] = new SqlParameter("@m8", SqlDbType.VarChar, 50); param[10].Value = dtsat.Rows[dtsat.Rows.Count - 1][11].ToString();
                param[11] = new SqlParameter("@m9", SqlDbType.VarChar, 50); param[11].Value = dtsat.Rows[dtsat.Rows.Count - 1][12].ToString();
                param[12] = new SqlParameter("@m10", SqlDbType.VarChar, 50); param[12].Value = dtsat.Rows[dtsat.Rows.Count - 1][13].ToString();
                param[13] = new SqlParameter("@m11", SqlDbType.VarChar, 50); param[13].Value = dtsat.Rows[dtsat.Rows.Count - 1][14].ToString();
                param[14] = new SqlParameter("@m12", SqlDbType.VarChar, 50); param[14].Value = dtsat.Rows[dtsat.Rows.Count - 1][15].ToString();
                param[15] = new SqlParameter("@m13", SqlDbType.VarChar, 50); param[15].Value = dtsat.Rows[dtsat.Rows.Count - 1][16].ToString();
                param[16] = new SqlParameter("@m14", SqlDbType.VarChar, 50); param[16].Value = dtsat.Rows[dtsat.Rows.Count - 1][17].ToString();
                param[17] = new SqlParameter("@m15", SqlDbType.VarChar, 50); param[17].Value = dtsat.Rows[dtsat.Rows.Count - 1][18].ToString();
                param[18] = new SqlParameter("@m16", SqlDbType.VarChar, 50); param[18].Value = dtsat.Rows[dtsat.Rows.Count - 1][19].ToString();
                param[19] = new SqlParameter("@m17", SqlDbType.VarChar, 50); param[19].Value = dtsat.Rows[dtsat.Rows.Count - 1][20].ToString();
                param[20] = new SqlParameter("@m18", SqlDbType.VarChar, 50); param[20].Value = dtsat.Rows[dtsat.Rows.Count - 1][21].ToString();
                param[21] = new SqlParameter("@m19", SqlDbType.VarChar, 50); param[21].Value = dtsat.Rows[dtsat.Rows.Count - 1][22].ToString();
                param[22] = new SqlParameter("@m20", SqlDbType.VarChar, 50); param[22].Value = dtsat.Rows[dtsat.Rows.Count - 1][23].ToString();
                param[23] = new SqlParameter("@m21", SqlDbType.VarChar, 50); param[23].Value = dtsat.Rows[dtsat.Rows.Count - 1][24].ToString();
                param[24] = new SqlParameter("@m22", SqlDbType.VarChar, 50); param[24].Value = dtsat.Rows[dtsat.Rows.Count - 1][25].ToString();
                param[25] = new SqlParameter("@m23", SqlDbType.VarChar, 50); param[25].Value = dtsat.Rows[dtsat.Rows.Count - 1][26].ToString();
                param[26] = new SqlParameter("@m24", SqlDbType.VarChar, 50); param[26].Value = dtsat.Rows[dtsat.Rows.Count - 1][27].ToString();
                param[27] = new SqlParameter("@m25", SqlDbType.VarChar, 50); param[27].Value = dtsat.Rows[dtsat.Rows.Count - 1][28].ToString();
                param[28] = new SqlParameter("@m26", SqlDbType.VarChar, 50); param[28].Value = dtsat.Rows[dtsat.Rows.Count - 1][29].ToString();
                param[29] = new SqlParameter("@m27", SqlDbType.VarChar, 50); param[29].Value = dtsat.Rows[dtsat.Rows.Count - 1][30].ToString();
                param[30] = new SqlParameter("@m28", SqlDbType.VarChar, 50); param[30].Value = dtsat.Rows[dtsat.Rows.Count - 1][31].ToString();
                param[31] = new SqlParameter("@m29", SqlDbType.VarChar, 50); param[31].Value = dtsat.Rows[dtsat.Rows.Count - 1][32].ToString();
                param[32] = new SqlParameter("@m30", SqlDbType.VarChar, 50); param[32].Value = dtsat.Rows[dtsat.Rows.Count - 1][33].ToString();
                param[33] = new SqlParameter("@m31", SqlDbType.VarChar, 50); param[33].Value = dtsat.Rows[dtsat.Rows.Count - 1][34].ToString();
                param[34] = new SqlParameter("@m32", SqlDbType.VarChar, 50); param[34].Value = dtsat.Rows[dtsat.Rows.Count - 1][35].ToString();
                param[35] = new SqlParameter("@m33", SqlDbType.VarChar, 50); param[35].Value = dtsat.Rows[dtsat.Rows.Count - 1][36].ToString();
                param[36] = new SqlParameter("@m34", SqlDbType.VarChar, 50); param[36].Value = dtsat.Rows[dtsat.Rows.Count - 1][37].ToString();
                param[37] = new SqlParameter("@m35", SqlDbType.VarChar, 50); param[37].Value = dtsat.Rows[dtsat.Rows.Count - 1][38].ToString();
                param[38] = new SqlParameter("@m36", SqlDbType.VarChar, 50); param[38].Value = dtsat.Rows[dtsat.Rows.Count - 1][39].ToString();
                param[39] = new SqlParameter("@m37", SqlDbType.VarChar, 50); param[39].Value = dtsat.Rows[dtsat.Rows.Count - 1][40].ToString();
                param[40] = new SqlParameter("@m38", SqlDbType.VarChar, 50); param[40].Value = dtsat.Rows[dtsat.Rows.Count - 1][41].ToString();
                param[41] = new SqlParameter("@m39", SqlDbType.VarChar, 50); param[41].Value = dtsat.Rows[dtsat.Rows.Count - 1][42].ToString();
                param[42] = new SqlParameter("@m40", SqlDbType.VarChar, 50); param[42].Value = dtsat.Rows[dtsat.Rows.Count - 1][43].ToString();
                param[43] = new SqlParameter("@m41", SqlDbType.VarChar, 50); param[43].Value = dtsat.Rows[dtsat.Rows.Count - 1][44].ToString();
                param[44] = new SqlParameter("@m42", SqlDbType.VarChar, 50); param[44].Value = dtsat.Rows[dtsat.Rows.Count - 1][45].ToString();
                param[45] = new SqlParameter("@m43", SqlDbType.VarChar, 50); param[45].Value = dtsat.Rows[dtsat.Rows.Count - 1][46].ToString();
                param[46] = new SqlParameter("@m44", SqlDbType.VarChar, 50); param[46].Value = dtsat.Rows[dtsat.Rows.Count - 1][47].ToString();
                param[47] = new SqlParameter("@m45", SqlDbType.VarChar, 50); param[47].Value = dtsat.Rows[dtsat.Rows.Count - 1][48].ToString();
                param[48] = new SqlParameter("@IDdeserve", SqlDbType.Int); param[48].Value = dtsat.Rows[dtsat.Rows.Count - 1][0].ToString();
                param[49] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[49].Value = Properties.Settings.Default.UserNameLogin;


                dal.open();
                DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyingUpdate", param);
                dal.close();

                
            }
            else
            {
                MessageBox.Show("اضف سنة جديدة");
            }

            
            
        }
        //[[=================================================================================================================================
        //[[============= This codes below for Delete Data from EmpDeserveSatisfying tabel / Using the EmployeeDeserveSatisfyingDeleting Procedure
        public void EmpDesSatisfyingDeleteData(DataGridView DgvDes, TextBox Desyear, TextBox DesIDseq, TextBox DesIDcon, TextBox DesEmpname, TextBox Desm1
           , TextBox Desm2, TextBox Desm3, TextBox Desm4, TextBox Desm5, TextBox Desm6, TextBox Desm7, TextBox Desm8, TextBox Desm9, TextBox Desm10, TextBox Desm11
           , TextBox Desm12, TextBox Desm13, TextBox Desm14, TextBox Desm15, TextBox Desm16, TextBox Desm17, TextBox Desm18, TextBox Desm19, TextBox Desm20
           , TextBox Desm21, TextBox Desm22, TextBox Desm23, TextBox Desm24, TextBox Desm25, TextBox Desm26, TextBox Desm27, TextBox Desm28, TextBox Desm29, TextBox Desm30
            , TextBox Desm31, TextBox Desm32, TextBox Desm33, TextBox Desm34, TextBox Desm35, TextBox Desm36
           , TextBox Desm37, TextBox Desm38, TextBox Desm39, TextBox Desm40, TextBox Desm41, TextBox Desm42, TextBox Desm43, TextBox Desm44, TextBox Desm45
           , TextBox RegisterName, TextBox AddingTime, TextBox AddingDate,  int Desseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdes", SqlDbType.Int); param[0].Value = Desseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeDeserveSatisfyingDeleting", param);
            dal.close();
            EmpDesSatisfyingGettingData(DgvDes, Desyear, DesIDseq, DesIDcon, DesEmpname, Desm1
          , Desm2, Desm3, Desm4, Desm5, Desm6, Desm7, Desm8, Desm9, Desm10, Desm11
          , Desm12, Desm13, Desm14, Desm15, Desm16, Desm17, Desm18, Desm19, Desm20
          , Desm21, Desm22, Desm23, Desm24, Desm25, Desm26, Desm27, Desm28, Desm29
          , Desm30, Desm31, Desm32, Desm33, Desm34, Desm35, Desm36, Desm37, Desm38
          , Desm39, Desm40, Desm41, Desm42, Desm43, Desm44, Desm45,
          int.Parse(DesIDcon.Text), RegisterName, AddingTime, AddingDate);
        }

        //[[=============================================================================================================================
        //[[*****************************************************************************************************************************
        //[[============= Build the Disputches Form 
        public DataTable DisGettingData(DataGridView Dgv, TextBox DisIDseq, TextBox DisIDcon, TextBox DisEmpname, TextBox DisCarNO, TextBox DisCartype
            , TextBox DisGoingTime, DateTimePicker DisGoingDate, TextBox DisCommingTime, DateTimePicker DisCommingDate, ComboBox DisDistenation, ComboBox Disbeneficiary
            , TextBox DisHourCount, TextBox DisNightCount, ComboBox DisRayia, ComboBox DisWorkTime, TextBox DisTaghweelNO, DateTimePicker DisTaghweelDate
            , TextBox DisBookNO, DateTimePicker DisBookDate, ComboBox DisFinishing, TextBox DisRegistername, TextBox DisAddingTime, TextBox DisAddingDate
            , TextBox DisIDmove, CheckBox DisComp, Panel Dispn1, TextBox Notice, int IDseq)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IDseq;
            dal.open();
            DataTable Dt = dal.SelectingData("DisputchesSeleting", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in Dispn1.Controls) { if (p is TextBox || p is ComboBox || p is DateTimePicker || p is CheckBox) { p.DataBindings.Clear(); } }

            for (int j = 0; j < 3; j++)
            {
                for (int i = 20; i < Dt.Columns.Count; i++)
                {
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[3].HeaderText = "رقم العجلة";
                    Dgv.Columns[4].HeaderText = "نوع العجلة";
                    Dgv.Columns[5].HeaderText = "وقت الخروج";
                    Dgv.Columns[6].HeaderText = "تاريخ الخروج";
                    Dgv.Columns[7].HeaderText = "وقت العودة";
                    Dgv.Columns[8].HeaderText = "تاريخ العودة";
                    Dgv.Columns[9].HeaderText = "الجهة المقصودة";
                    Dgv.Columns[10].HeaderText = "الجهة المستفيدة";
                    Dgv.Columns[11].HeaderText = "عدد الساعات";
                    Dgv.Columns[12].HeaderText = "عدد الليالي";
                    Dgv.Columns[13].HeaderText = "راعية/غير راعية";
                    Dgv.Columns[14].HeaderText = "دوام المنتسب";
                    Dgv.Columns[15].HeaderText = "رقم التخويل";
                    Dgv.Columns[16].HeaderText = "تاريخ التخويل";
                    Dgv.Columns[17].HeaderText = "تم";
                    Dgv.Columns[18].HeaderText = "كتاب الصرف";
                    Dgv.Columns[19].HeaderText = "تاريخ الكتاب";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }

            }

            DisIDseq.DataBindings.Clear();
            DisIDcon.DataBindings.Clear();
            DisEmpname.DataBindings.Clear();
            DisCarNO.DataBindings.Clear();
            DisCartype.DataBindings.Clear();
            DisGoingTime.DataBindings.Clear();
            DisGoingDate.DataBindings.Clear();
            DisCommingTime.DataBindings.Clear();
            DisCommingDate.DataBindings.Clear();
            DisDistenation.DataBindings.Clear();
            Disbeneficiary.DataBindings.Clear();
            DisHourCount.DataBindings.Clear();
            DisNightCount.DataBindings.Clear();
            DisRayia.DataBindings.Clear();
            DisWorkTime.DataBindings.Clear();
            DisTaghweelNO.DataBindings.Clear();
            DisTaghweelDate.DataBindings.Clear();
            DisFinishing.DataBindings.Clear();
            DisBookNO.DataBindings.Clear();
            DisBookDate.DataBindings.Clear();
            DisRegistername.DataBindings.Clear();
            DisAddingTime.DataBindings.Clear();
            DisAddingDate.DataBindings.Clear();
            DisIDmove.DataBindings.Clear();
            DisComp.DataBindings.Clear();
            Notice.DataBindings.Clear();

            string str = "text";
            DisIDseq.DataBindings.Add(str, Dt, "IDdisputch");
            DisIDcon.DataBindings.Add(str, Dt, "IDconempdisputch");
            DisEmpname.DataBindings.Add(str, Dt, "EmployeeName");
            DisCarNO.DataBindings.Add(str, Dt, "CarNO");
            DisCartype.DataBindings.Add(str, Dt, "CarType");
            DisGoingTime.DataBindings.Add(str, Dt, "GoingTime");
            DisGoingDate.DataBindings.Add(str, Dt, "GoingDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            DisCommingTime.DataBindings.Add(str, Dt, "CommingTime");
            DisCommingDate.DataBindings.Add(str, Dt, "CommingDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            DisDistenation.DataBindings.Add(str, Dt, "Distenation");
            Disbeneficiary.DataBindings.Add(str, Dt, "TheBeneficiary");
            DisHourCount.DataBindings.Add(str, Dt, "HourCount");
            DisNightCount.DataBindings.Add(str, Dt, "NightCount");
            DisRayia.DataBindings.Add(str, Dt, "Rayia");
            DisWorkTime.DataBindings.Add(str, Dt, "WorkTime");
            DisTaghweelNO.DataBindings.Add(str, Dt, "TaghweelNO");
            DisTaghweelDate.DataBindings.Add(str, Dt, "TaghweelDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            DisFinishing.DataBindings.Add(str, Dt, "Finishing");
            DisBookNO.DataBindings.Add(str, Dt, "BookNO");
            DisBookDate.DataBindings.Add(str, Dt, "BookDate");
            DisRegistername.DataBindings.Add(str, Dt, "RegisterName");
            DisAddingTime.DataBindings.Add(str, Dt, "AddingTime");
            DisAddingDate.DataBindings.Add(str, Dt, "AddingDate");
            DisIDmove.DataBindings.Add(str, Dt, "IDmoving");
            DisComp.DataBindings.Add("checked", Dt, "Complete");
            Notice.DataBindings.Add("text", Dt, "Notice");

            string[] r1 = new string[2];
            r1[0] = "راعية"; r1[1] = "غير راعية";
            DisRayia.Items.Clear();
            DisRayia.Items.AddRange(r1);

            string[] r2 = new string[6];
            r2[0] = "صباحي"; r2[1] = "مسائي"; r2[2] = "ليلي"; r2[3] = "صباحي مستمر"; r2[4] = "مسائي مستمر"; r2[5] = "ليلي مستمر";
            DisWorkTime.Items.Clear();
            DisWorkTime.Items.AddRange(r2);

            string[] r3 = new string[4];
            r3[0] = "تم الصرف"; r3[1] = "لم يصرف"; r3[2] = "تم الرفع من الشعبة"; r3[3] = "لم يرفع من الشعبة";
            DisFinishing.Items.Clear();
            DisFinishing.Items.AddRange(r3);

            Disbeneficiary.Items.Clear();
            CLSCONSTENTRY GetDataDepartment = new CLSCONSTENTRY();
            DataTable DtDepartment = GetDataDepartment.GetDataDepartment();
            for (int i = 0; i < DtDepartment.Rows.Count; i++)
            {
                Disbeneficiary.Items.Add(DtDepartment.Rows[i][1].ToString());

            }

            DisDistenation.Items.Clear();
            CLSCONSTENTRY GetDataDistenation = new CLSCONSTENTRY();
            DataTable DtDistenation = GetDataDistenation.DistenationSelecting();
            for (int x = 0; x < DtDistenation.Rows.Count; x++)
            {

                DisDistenation.Items.Add(DtDistenation.Rows[x][1].ToString());

            }


            return Dt;
        }
        //[[==============================================================================================================================
        //[[=========== This codes Below for insert Data to the Disputches Table / Using The Disputchesinsertinto Procedure 
        public DataTable DisInsertData(DataGridView Dgv, TextBox DisIDseq, TextBox DisIDcon, TextBox DisEmpname, TextBox DisCarNO, TextBox DisCartype
            , TextBox DisGoingTime, DateTimePicker DisGoingDate, TextBox DisCommingTime, DateTimePicker DisCommingDate, ComboBox DisDistenation, ComboBox Disbeneficiary
            , TextBox DisHourCount, TextBox DisNightCount, ComboBox DisRayia, ComboBox DisWorkTime, TextBox DisTaghweelNO, DateTimePicker DisTaghweelDate
            , TextBox DisBookNO, DateTimePicker DisBookDate, ComboBox DisFinishing, TextBox DisRegistername, TextBox DisAddingTime, TextBox DisAddingDate, TextBox Notice
            , TextBox DisIDmove, CheckBox DisComp, Panel Dispn1, int DisIDcon1, string DisEmpname1, string DisCarNO1, string DisCartype1, string DisGoingTime1, string DisGoingDate1
            , string DisCommingTime1, string DisCommingDate1, string DisDistenation1, string Disbeneficiary1, string DisHourCount1, string DisNightCount1, string DisRayia2
            , string DisWorkTime1, string DisTaghweelNO1, string DisTaghweelDate1, string DisFinishing1, string DisBookNO1, string DisBookDate1
            , string DisRegisterName1, string DisAddingTime1, string DisAddingDate1, int DisIDmove1, bool DisComp1, string Notice1)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@IDconDisputches", SqlDbType.Int); param[0].Value = DisIDcon1;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = DisEmpname1;
            param[2] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50); param[2].Value = DisCarNO1;
            param[3] = new SqlParameter("@CarType", SqlDbType.VarChar, 50); param[3].Value = DisCartype1;
            param[4] = new SqlParameter("@GoingTime", SqlDbType.VarChar, 50); param[4].Value = DisGoingTime1;
            param[5] = new SqlParameter("@GoingDate", SqlDbType.VarChar, 50); param[5].Value = DisGoingDate1;
            param[6] = new SqlParameter("@CommingTime", SqlDbType.VarChar, 50); param[6].Value = DisCommingTime1;
            param[7] = new SqlParameter("@CommingDate", SqlDbType.VarChar, 50); param[7].Value = DisCommingDate1;
            param[8] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50); param[8].Value = DisDistenation1;
            param[9] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50); param[9].Value = Disbeneficiary1;
            param[10] = new SqlParameter("@HourCount", SqlDbType.VarChar, 50); param[10].Value = DisHourCount1;
            param[11] = new SqlParameter("@NightCount", SqlDbType.VarChar, 50); param[11].Value = DisNightCount1;
            param[12] = new SqlParameter("@Rayia", SqlDbType.VarChar, 50); param[12].Value = DisRayia2;
            param[13] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50); param[13].Value = DisWorkTime1;
            param[14] = new SqlParameter("@TaghweelNO", SqlDbType.VarChar, 50); param[14].Value = DisTaghweelNO1;
            param[15] = new SqlParameter("@TaghweelDate", SqlDbType.VarChar, 50); param[15].Value = DisTaghweelDate1;
            param[16] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50); param[16].Value = DisFinishing1;
            param[17] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50); param[17].Value = DisBookNO1;
            param[18] = new SqlParameter("@BookDate", SqlDbType.VarChar, 50); param[18].Value = DisBookDate1;
            param[19] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[19].Value = DisRegisterName1;
            param[20] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[20].Value = DisAddingTime1;
            param[21] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[21].Value = DisAddingDate1;
            param[22] = new SqlParameter("@IDmove", SqlDbType.Int); param[22].Value = DisIDmove1;
            param[23] = new SqlParameter("@Comp", SqlDbType.Bit); param[23].Value = DisComp1;
            param[24] = new SqlParameter("@notice", SqlDbType.VarChar, 500); param[24].Value = Notice1;
            dal.open();
            dal.ExecuteCommand("DisputchesInsertinto", param);
            dal.close();
            DataTable dt= DisGettingData(Dgv, DisIDseq, DisIDcon, DisEmpname, DisCarNO, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime, DisCommingDate
                , DisDistenation, Disbeneficiary, DisHourCount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate, DisBookNO
                , DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate, DisIDmove, DisComp, Dispn1, Notice, int.Parse(DisIDcon.Text));
            return dt;
        }
        //[[=============================================================================================================================
        //=============this codes below for update the Empdeserve tabel / using DisputechesUpdate Procedure 
        public DataTable DisUpdateData(DataGridView Dgv, TextBox DisIDseq, TextBox DisIDcon, TextBox DisEmpname, TextBox DisCarNO, TextBox DisCartype
            , TextBox DisGoingTime, DateTimePicker DisGoingDate, TextBox DisCommingTime, DateTimePicker DisCommingDate, ComboBox DisDistenation, ComboBox Disbeneficiary
            , TextBox DisHourCount, TextBox DisNightCount, ComboBox DisRayia, ComboBox DisWorkTime, TextBox DisTaghweelNO, DateTimePicker DisTaghweelDate
            , TextBox DisBookNO, DateTimePicker DisBookDate, ComboBox DisFinishing, TextBox DisRegistername, TextBox DisAddingTime, TextBox DisAddingDate, TextBox Notice
            , TextBox DisIDmove, CheckBox DisComp, Panel Dispn1, int DisIDcon1, string DisEmpname1, string DisCarNO1, string DisCartype1, string DisGoingTime1, DateTime DisGoingDate1
            , string DisCommingTime1, DateTime DisCommingDate1, string DisDistenation1, string Disbeneficiary1, string DisHourCount1, string DisNightCount1, string DisRayia2
            , string DisWorkTime1, string DisTaghweelNO1, DateTime DisTaghweelDate1, string DisFinishing1, string DisBookNO1, DateTime DisBookDate1
            , string DisRegisterName1, string DisAddingTime1, DateTime DisAddingDate1, int DisIDmove1, int DisIdseq, bool DisComp1, string Notice1)
        {
            
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[26];
            param[0] = new SqlParameter("@IDdis", SqlDbType.Int);                   param[0].Value = DisIdseq;
            param[1] = new SqlParameter("@IDcondis", SqlDbType.Int);                param[1].Value = DisIDcon1;
            param[2] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);    param[2].Value = DisEmpname1;
            param[3] = new SqlParameter("@CarNO", SqlDbType.VarChar, 50);           param[3].Value = DisCarNO1;
            param[4] = new SqlParameter("@CarType", SqlDbType.VarChar, 50);         param[4].Value = DisCartype1;
            param[5] = new SqlParameter("@GoingTime", SqlDbType.VarChar, 50);       param[5].Value = DisGoingTime1;
            param[6] = new SqlParameter("@GoingDate", SqlDbType.Date);              param[6].Value = DisGoingDate1;
            param[7] = new SqlParameter("@CommingTime", SqlDbType.VarChar, 50);     param[7].Value = DisCommingTime1;
            param[8] = new SqlParameter("@CommingDate", SqlDbType.Date);            param[8].Value = DisCommingDate1;
            param[9] = new SqlParameter("@Distenation", SqlDbType.VarChar, 50);     param[9].Value = DisDistenation1;
            param[10] = new SqlParameter("@TheBeneficiary", SqlDbType.VarChar, 50); param[10].Value = Disbeneficiary1;
            param[11] = new SqlParameter("@HourCount", SqlDbType.VarChar, 50);      param[11].Value = DisHourCount1;
            param[12] = new SqlParameter("@NightCount", SqlDbType.VarChar, 50);     param[12].Value = DisNightCount1;
            param[13] = new SqlParameter("@Rayia", SqlDbType.VarChar, 50);          param[13].Value = DisRayia2;
            param[14] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50);       param[14].Value = DisWorkTime1;
            param[15] = new SqlParameter("@TaghweelNO", SqlDbType.VarChar, 50);     param[15].Value = DisTaghweelNO1;
            param[16] = new SqlParameter("@TaghweelDate", SqlDbType.Date);          param[16].Value = DisTaghweelDate1;
            param[17] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50);      param[17].Value = DisFinishing1;
            param[18] = new SqlParameter("@BookNO", SqlDbType.VarChar, 50);         param[18].Value = DisBookNO1;
            param[19] = new SqlParameter("@BookDate", SqlDbType.Date);              param[19].Value = DisBookDate1;
            param[20] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param[20].Value = Properties.Settings.Default.UserNameLogin;
            param[21] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);     param[21].Value = DateTime.Now.ToString("hh:mm tt");
            param[22] = new SqlParameter("@AddingDate", SqlDbType.Date);            param[22].Value = DateTime.Now.ToString("yyyy/MM/dd");
            param[23] = new SqlParameter("@IDmove", SqlDbType.Int);                 param[23].Value = DisIDmove1;           
            param[24] = new SqlParameter("@Comp", SqlDbType.Bit);                   param[24].Value = DisComp1;
            param[25] = new SqlParameter("@notice", SqlDbType.VarChar, 500);        param[25].Value = Notice1;
            dal.open();
            dal.ExecuteCommand("DisputchesUPdate", param);
            dal.close();
            DataTable dt= DisGettingData(Dgv, DisIDseq, DisIDcon, DisEmpname, DisCarNO, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime, DisCommingDate
                , DisDistenation, Disbeneficiary, DisHourCount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate, DisBookNO
                , DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate, DisIDmove, DisComp, Dispn1,Notice, int.Parse(DisIDcon.Text));
            return dt;
        }
        //==============================================================================================================================
        //======= this codes below for Delete Data from Disputches Table/ Using DisputchesDeleting Procedure 
        public DataTable DisDeleteData(DataGridView Dgv, TextBox DisIDseq, TextBox DisIDcon, TextBox DisEmpname, TextBox DisCarNO, TextBox DisCartype
            , TextBox DisGoingTime, DateTimePicker DisGoingDate, TextBox DisCommingTime, DateTimePicker DisCommingDate, ComboBox DisDistenation, ComboBox Disbeneficiary
            , TextBox DisHourCount, TextBox DisNightCount, ComboBox DisRayia, ComboBox DisWorkTime, TextBox DisTaghweelNO, DateTimePicker DisTaghweelDate
            , TextBox DisBookNO, DateTimePicker DisBookDate, ComboBox DisFinishing, TextBox DisRegistername, TextBox DisAddingTime, TextBox DisAddingDate
            , TextBox DisIDmove, CheckBox DisComp, Panel Dispn1, TextBox Notice, int DisIDseq1)
        {

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDdis", SqlDbType.Int); param[0].Value = DisIDseq1;
            dal.open();
            dal.ExecuteCommand("DisputchesDeleting", param);
            dal.close();
            DataTable dt= DisGettingData(Dgv, DisIDseq, DisIDcon, DisEmpname, DisCarNO, DisCartype, DisGoingTime, DisGoingDate, DisCommingTime, DisCommingDate
                , DisDistenation, Disbeneficiary, DisHourCount, DisNightCount, DisRayia, DisWorkTime, DisTaghweelNO, DisTaghweelDate, DisBookNO
                , DisBookDate, DisFinishing, DisRegistername, DisAddingTime, DisAddingDate, DisIDmove, DisComp, Dispn1,Notice, int.Parse(DisIDcon.Text));

            return dt;

        }
        //================================================================================================================================
        //===============================================================================================================================
        //[[============ this codes below for building the EmployeeConstracts Form 
        public DataTable EmpConsGettingData(DataGridView dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
            , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
            , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
            , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
            , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ConsIDcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = ConsIDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeconstractGetData", param);
            dal.close();
            dgv.DataSource = null; dgv.DataSource = Dt;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 11; j < dgv.Columns.Count; j++)
                {
                    dgv.Columns[i].Visible = false;
                    dgv.Columns[j].Visible = false;
                    dgv.Columns[3].HeaderText = "الحالة";
                    dgv.Columns[4].HeaderText = "الفترة";
                    dgv.Columns[5].HeaderText = "من تاريخ";
                    dgv.Columns[6].HeaderText = "الى تاريخ";
                    dgv.Columns[7].HeaderText = "رقم الكتاب";
                    dgv.Columns[8].HeaderText = "تاريخ الكتاب";
                    dgv.Columns[9].HeaderText = "جهة الاصدار";
                    dgv.Columns[10].HeaderText = "التفاصيل";
                    
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "الحالة"; lb5.Text = "الفترة"; lb6.Text = "من تاريخ";
            lb7.Text = "الى تاريخ"; lb8.Text = "رقم الكتاب"; lb9.Text = "تاريخ الكتاب"; lb10.Text = "جهة الاصدار"; lb11.Text = "التفاصيل"; lb12.Visible = false;
            lb13.Visible = false; lb14.Visible = false;

            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker) || (p is Label) || (p is DevExpress.XtraEditors.SimpleButton))
                {
                    (p).DataBindings.Clear();
                    (p).Visible = true;
                    btnclear.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btndelete.Visible = true;
                    tbsearching.Visible = true;
                    tb12.Visible = false;
                    tb13.Visible = false;
                    tb14.Visible = false;
                    lb12.Visible = false; lb13.Visible = false; lb14.Visible = false;
                }

            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;

            string str = "text";
            tb1.DataBindings.Add(str, Dt, "Cons_ID"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDcon"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "Cons_Emp_Name"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "Cons_thetype"); tb4.AutoCompleteMode = AutoCompleteMode.Append;
            tb5.DataBindings.Add(str, Dt, "Cons_Period");
            tb6.DataBindings.Add(str, Dt, "Cons_FromDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb7.DataBindings.Add(str, Dt, "Cons_ToDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); tb7.Enabled = false;
            tb8.DataBindings.Add(str, Dt, "Cons_BookNO");
            tb9.DataBindings.Add(str, Dt, "Cons_BookDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb10.DataBindings.Add(str, Dt, "Cons_ReleaseBy"); tb10.AutoCompleteMode = AutoCompleteMode.Append;
            tb11.DataBindings.Add(str, Dt, "Cons_Notice"); tb11.Multiline = true; tb11.Height = 100;
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Enabled = false; tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingDate"); tb13.Enabled = false; tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingTime"); tb14.Enabled = false; tb14.Visible = false;
            
            tb4.Items.Clear();
            string[] m = new string[4];
            m[0] = "عقد"; m[1] = "تثبيت"; m[2] = "اجور يومية"; m[3] = "عقد منتهي";
            tb4.Items.AddRange(m);

            tb10.Items.Clear();
            CLS_FRMS.CLSCONSTENTRY GetDeparments = new CLSCONSTENTRY();
            DataTable dtdepartment = GetDeparments.GetDataDepartment();
            for (int i = 0; i < dtdepartment.Rows.Count; i++)
            {
                tb10.Items.Add(dtdepartment.Rows[i][1].ToString());
            }
            
            return Dt;
        }
        //=================================================================================
        //======= this codes below for insert data to the EmpConstract Table / Using The EmployeeconstractsInsertData Procedure
        public void EmpConsInsertData(DataGridView dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ConsIDcon
            , string ConsEmpName, string ConsThetype, double ConsPeriod, DateTime ConsFormDate, DateTime ConsToDate, string ConsBookNO, DateTime ConsBookDate
            , string ConsReleaseby, string ConsNotice, string ConsRegisterName, string ConsAddingDate, string ConsAddingTime)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = ConsIDcon;
            param[1] = new SqlParameter("@ConsEmpName", SqlDbType.VarChar, 50); param[1].Value = ConsEmpName;
            param[2] = new SqlParameter("@ConsThetype", SqlDbType.VarChar, 50); param[2].Value = ConsThetype;
            param[3] = new SqlParameter("@ConsPeriod", SqlDbType.Real); param[3].Value = ConsPeriod;
            param[4] = new SqlParameter("@ConsFormDate", SqlDbType.Date); param[4].Value = ConsFormDate;
            param[5] = new SqlParameter("@ConsToDate", SqlDbType.Date); param[5].Value = ConsToDate;
            param[6] = new SqlParameter("@ConsBookNO", SqlDbType.VarChar, 50); param[6].Value = ConsBookNO;
            param[7] = new SqlParameter("@ConsBookDate", SqlDbType.Date); param[7].Value = ConsBookDate;
            param[8] = new SqlParameter("@ConsReleaseby", SqlDbType.VarChar, 50); param[8].Value = ConsReleaseby;
            param[9] = new SqlParameter("@ConsNotice", SqlDbType.Text); param[9].Value = ConsNotice;
            param[10] = new SqlParameter("@ConsRegisterName", SqlDbType.VarChar, 50); param[10].Value = ConsRegisterName;
            param[11] = new SqlParameter("@ConsAddingDate", SqlDbType.VarChar, 50); param[11].Value = ConsAddingDate;
            param[12] = new SqlParameter("@ConsAddingTime", SqlDbType.VarChar, 50); param[12].Value = ConsAddingTime;
         
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeconstractsInsertData", param);
            dal.close();
            EmpConsGettingData(dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
            , tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd
            , btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));


        }
        //=======================================================================================
        // ==== This codes below for UpdateDate Of EmpConstract Table / Using the EmployeeConstractUpdateData procedure
        public void EmpConsUpdateData(DataGridView dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ConsIDcon
            , string ConsEmpName, string ConsThetype, double ConsPeriod, DateTime ConsFormDate, DateTime ConsToDate, string ConsBookNO, DateTime ConsBookDate
            , string ConsReleaseby, string ConsNotice, string ConsRegisterName, string ConsAddingDate, string ConsAddingTime, int ConsIDseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = ConsIDcon;
            param[1] = new SqlParameter("@ConsEmpName", SqlDbType.VarChar, 50); param[1].Value = ConsEmpName;
            param[2] = new SqlParameter("@ConsThetype", SqlDbType.VarChar, 50); param[2].Value = ConsThetype;
            param[3] = new SqlParameter("@ConsPeriod", SqlDbType.Real); param[3].Value = ConsPeriod;
            param[4] = new SqlParameter("@ConsFormDate", SqlDbType.Date); param[4].Value = ConsFormDate;
            param[5] = new SqlParameter("@ConsToDate", SqlDbType.Date); param[5].Value = ConsToDate;
            param[6] = new SqlParameter("@ConsBookNO", SqlDbType.VarChar, 50); param[6].Value = ConsBookNO;
            param[7] = new SqlParameter("@ConsBookDate", SqlDbType.Date); param[7].Value = ConsBookDate;
            param[8] = new SqlParameter("@ConsReleaseby", SqlDbType.VarChar, 50); param[8].Value = ConsReleaseby;
            param[9] = new SqlParameter("@ConsNotice", SqlDbType.Text); param[9].Value = ConsNotice;
            param[10] = new SqlParameter("@ConsRegisterName", SqlDbType.VarChar, 50); param[10].Value = ConsRegisterName;
            param[11] = new SqlParameter("@ConsAddingDate", SqlDbType.VarChar, 50); param[11].Value = ConsAddingDate;
            param[12] = new SqlParameter("@ConsAddingTime", SqlDbType.VarChar, 50); param[12].Value = ConsAddingTime;
            param[13] = new SqlParameter("@ConsIDseq", SqlDbType.Int); param[13].Value = ConsIDseq;
            
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeconstractsUpdateData", param);
            dal.close();
            EmpConsGettingData(dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
            , tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd
            , btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //======================================================================================
        //// ==== This Codes Below for delete Data From EmpConstract Table / Using the EmployeeconstractDeletedata Procedure
        public void EmpConsDeleteData(DataGridView dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ConsIDseq
          )
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ConsIDseq", SqlDbType.Int); param[0].Value = ConsIDseq;

            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeconstractsDeleteData", param);
            dal.close();
            EmpConsGettingData(dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14
            , tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd
            , btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //============================================================================================================================
        //============================================================================================================================
        //======= this codes Below for Build the Zamaniat form / Getting Data to the Form Zamaniat
        public DataTable EmpZamaniatGetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ZamIDcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ZamIDcon", SqlDbType.Int); param[0].Value = ZamIDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("ZamSelecting", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker))
                {
                    p.DataBindings.Clear();
                    p.Visible = true;
                    tbsearching.Visible = true;
                    btnclear.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btndelete.Visible = true;
                    tb5.Visible = false; tb7.Visible = false; tb9.Visible = false; tb10.Visible = false;
                }

            }
            foreach (Control q in tbpn.Controls)
            {
                if (q is Label) { (q as Label).Visible = true; };
                lb5.Visible = false; lb7.Visible = false; lb9.Visible = false; lb10.Visible = false; lb12.Visible = false; lb13.Visible = false;
                lb14.Visible = false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 7; j < Dt.Columns.Count; j++)
                {
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[3].HeaderText = "تاريخ الزمنية";
                    Dgv.Columns[4].HeaderText = "مدة الزمنية";
                    Dgv.Columns[5].HeaderText = "ملاحظات";
                    Dgv.Columns[6].HeaderText = "تم/ لم يتم";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;

          

            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "مدة الزمنية"; lb6.Text = "التاريخ";
            lb8.Text = "تم / لم يتم"; lb11.Text = "ملاحظات";
            string str = "text";
            tb1.DataBindings.Add(str, Dt, "IDZam"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDconzam"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "EmployeeName"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "ZamCount"); tb4.Items.Clear();
            tb6.DataBindings.Add(str, Dt, "ZamDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb11.DataBindings.Add(str, Dt, "Notice"); tb11.Multiline = true; tb11.Height = 100;
            tb8.DataBindings.Add(str, Dt, "Finishing"); tb8.AutoCompleteMode = AutoCompleteMode.Append;
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingTime"); tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingDate"); tb14.Visible = false;

            tb8.Items.Clear();
            string[] s = new string[2];
            s[0] = "تم"; s[1] = "لم يتم";
            tb8.Items.AddRange(s);

            return Dt;
        }
        //====================================================================================================================================
        //========= This codes below for insert data to the Empzamaniat table / Using ZamInsertInto Procedure 
        public void EmpZamaniatInsertData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ZamIDcon
            , string EmployeeName, DateTime ZamDate, double @ZamCount, string ZamNotice, string Finishing, string RegisterName, string AddingTime
            , string AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@ZamIDcon", SqlDbType.Int); param[0].Value = ZamIDcon;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@ZamDate", SqlDbType.Date); param[2].Value = ZamDate;
            param[3] = new SqlParameter("@ZamCount", SqlDbType.Real); param[3].Value = ZamCount;
            param[4] = new SqlParameter("@Notice", SqlDbType.Text); param[4].Value = ZamNotice;
            param[5] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50); param[5].Value = Finishing;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;
            dal.open();
            dal.ExecuteCommand("ZamInsertInto", param);
            dal.close();

            EmpZamaniatGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //====================================================================================================================================
        //========== this codes below for UpdateData in the EmpZamaniat tabel / Using the ZamUPdate Procedure
        public void EmpZamaniatUpdateData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int ZamIDcon
            , string EmployeeName, DateTime ZamDate, double @ZamCount, string ZamNotice, string Finishing, string RegisterName, string AddingTime
            , string AddingDate, int IDZamseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IDzamcon", SqlDbType.Int); param[0].Value = ZamIDcon;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@ZamDate", SqlDbType.Date); param[2].Value = ZamDate;
            param[3] = new SqlParameter("@ZamCount", SqlDbType.Real); param[3].Value = ZamCount;
            param[4] = new SqlParameter("@Notice", SqlDbType.Text); param[4].Value = ZamNotice;
            param[5] = new SqlParameter("@Finishing", SqlDbType.VarChar, 50); param[5].Value = Finishing;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;
            param[9] = new SqlParameter("@IDzamseq", SqlDbType.Int); param[9].Value = IDZamseq;
            dal.open();
            dal.ExecuteCommand("ZamUPdate", param);
            dal.close();

            EmpZamaniatGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //====================================================================================================================================
        //============= This codes Below for Deleted Data From Empzamaniat table / Using zamDeleting Procedure 
        public void EmpZamaniatDeleteData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDZamseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idzam", SqlDbType.Int); param[0].Value = IDZamseq;

            dal.open();
            dal.ExecuteCommand("zamDeleting", param);
            dal.close();

            EmpZamaniatGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }

        //==================================================================================================================================
        //=================================================================================================================================
        //=============== This codes Below For Building the Worktime tabel And Getting Data By the WorktimeSelecting Procedure
        public DataTable EmpWorktimeGetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int WorkIDcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@WorkIDcon", SqlDbType.Int); param[0].Value = WorkIDcon;
            dal.open();
            DataTable Dt = dal.SelectingData("WorktimeSelecting", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker))
                {
                    p.DataBindings.Clear();
                    p.Visible = true;
                    tbsearching.Visible = true;
                    btnclear.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btndelete.Visible = true;
                    tb5.Visible = false; tb8.Visible = false; tb9.Visible = false; tb10.Visible = false;
                    p.Enabled = true;
                }

            }
            foreach (Control q in tbpn.Controls)
            {
                if (q is Label) { (q as Label).Visible = true; };
                lb5.Visible = false; lb8.Visible = false; lb9.Visible = false; lb10.Visible = false; lb12.Visible = false; lb13.Visible = false;
                lb14.Visible = false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 7; j < Dt.Columns.Count; j++)
                {
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[3].HeaderText = "الوجبة";
                    Dgv.Columns[4].HeaderText = "من تاريخ";
                    Dgv.Columns[5].HeaderText = "الى تاريخ";
                    Dgv.Columns[6].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;


            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "الوجبة"; lb6.Text = "من تاريخ";
            lb7.Text = "الى تاريخ"; lb11.Text = "ملاحظات";
            string str = "text";
            tb1.DataBindings.Add(str, Dt, "IDwork"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDconworktime"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "EmployeeName"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "WorkTime"); tb4.Items.Clear();
            tb6.DataBindings.Add(str, Dt, "FromDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb7.DataBindings.Add(str, Dt, "ToDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb11.DataBindings.Add(str, Dt, "Notice"); tb11.Multiline = true; tb11.Height = 100; 
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingTime"); tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingDate"); tb14.Visible = false;

            tb4.Items.Clear();
            string[] s = new string[3];
            s[0] = "الوجبة الصباحية"; s[1] = "الوجبة المسائية"; s[2] = "الوجبة الليلية";
            tb4.Items.AddRange(s);

            return Dt;
        }
        //=============================================================================================================================
        //============= This Codes below for insertData to the WorkTime tabel / Using the WorkTimeInsertInto Procedure 
        public void EmpWorktimeInsertData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int WorkIDcon
            , string EmployeeName, string Worktime, DateTime FromDate, DateTime ToDate, string WorkNotice, string RegisterName, string AddingTime
            , string AddingDate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@WorkIDcon", SqlDbType.Int); param[0].Value = WorkIDcon;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50); param[2].Value = Worktime;
            param[3] = new SqlParameter("@FromDate", SqlDbType.Date); param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.Date); param[4].Value = ToDate;
            param[5] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[5].Value = WorkNotice;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;
            dal.open();
            dal.ExecuteCommand("WrokTimeInsertInto", param);
            dal.close();

            EmpWorktimeGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //==============================================================================================================================
        //========== This codes Below for Update Data to the Worktime table / Using WorkTimeUpdateData Procedure 
        public void EmpWorktimeUpdateData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int WorkIDcon
            , string EmployeeName, string Worktime, DateTime FromDate, DateTime ToDate, string WorkNotice, string RegisterName, string AddingTime
            , string AddingDate, int IDwork)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@IDworkcon", SqlDbType.Int); param[0].Value = WorkIDcon;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@WorkTime", SqlDbType.VarChar, 50); param[2].Value = Worktime;
            param[3] = new SqlParameter("@FromDate", SqlDbType.Date); param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.Date); param[4].Value = ToDate;
            param[5] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[5].Value = WorkNotice;
            param[6] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[6].Value = RegisterName;
            param[7] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[7].Value = AddingTime;
            param[8] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[8].Value = AddingDate;
            param[9] = new SqlParameter("@IDwork", SqlDbType.Int); param[9].Value = IDwork;
            dal.open();
            dal.ExecuteCommand("WrokTimeUPdate", param);
            dal.close();

            EmpWorktimeGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //=====================================================================================================================================
        //=========== This codes below for Delete Data from the worktime table / Using the worktimedelete procedure 
        public void EmpWorktimeDeleteData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
          , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
          , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
          , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
          , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDwork)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDworktime", SqlDbType.Int); param[0].Value = IDwork;

            dal.open();
            dal.ExecuteCommand("WorkTimeDeleting", param);
            dal.close();

            EmpWorktimeGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //===================================================================================================================================
        //==================================================================================================================================
        //============= This Codes Below For Building The EmpTanseeb Form / Getting Data From Emptanseeb using the EmpTabnseebGettingData Procedure
        public DataTable EmpTanseebGetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDcontanseeb)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int); param[0].Value = IDcontanseeb;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpTabnseebGettingData", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker))
                {
                    p.DataBindings.Clear();
                    p.Visible = true;
                    tbsearching.Visible = true;
                    btnclear.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btndelete.Visible = true;
                    tb9.Visible = false; tb12.Visible = false; tb13.Visible = false; tb14.Visible = false;
                    p.Enabled = true;
                }

            }
            foreach (Control q in tbpn.Controls)
            {
                if (q is Label) { (q as Label).Visible = true; };
                lb9.Visible = false; lb12.Visible = false; lb13.Visible = false; lb14.Visible = false;

            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 9; j < Dt.Columns.Count; j++)
                {
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[3].HeaderText = "الحالة";
                    Dgv.Columns[4].HeaderText = "المدة";
                    Dgv.Columns[5].HeaderText = "من تاريخ";
                    Dgv.Columns[6].HeaderText = "الى تاريخ";
                    Dgv.Columns[7].HeaderText = "الجهة المستفيدة";
                    Dgv.Columns[8].HeaderText = "الموقف";
                    Dgv.Columns[9].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;

            //tb1.DataBindings.Clear();
            //tb2.DataBindings.Clear();
            //tb3.DataBindings.Clear();
            //tb4.DataBindings.Clear();
            //tb5.DataBindings.Clear();
            //tb6.DataBindings.Clear();
            //tb7.DataBindings.Clear();
            //tb8.DataBindings.Clear();
            //tb10.DataBindings.Clear();
            //tb11.DataBindings.Clear();
            //tb12.DataBindings.Clear();
            //tb13.DataBindings.Clear();
            //tb14.DataBindings.Clear();

            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "الحالة"; lb5.Text = "المدة/شهر";
            lb6.Text = "من تاريخ"; lb7.Text = "الى تاريخ"; lb8.Text = "الجهة المستفيدة"; lb10.Text = "الموقف"; lb11.Text = "ملاحظات";
            string str = "text";
            tb1.DataBindings.Add(str, Dt, "IDtanseebseq"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDcontanseeb"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "EmployeeName"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "TheType"); tb4.Items.Clear();
            tb5.DataBindings.Add(str, Dt, "Period"); tb5.Items.Clear();
            tb6.DataBindings.Add(str, Dt, "FromDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            tb7.DataBindings.Add(str, Dt, "ToDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); tb7.Enabled = false;
            tb8.DataBindings.Add(str, Dt, "Beneficiary"); tb8.Items.Clear();
            tb10.DataBindings.Add(str, Dt, "TypeSituation"); tb10.Items.Clear();
            tb11.DataBindings.Add(str, Dt, "Notice"); tb11.Multiline = true; tb11.Height = 100;
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingDate"); tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingTime"); tb14.Visible = false;

            tb4.Items.Clear();
            string[] s = new string[3];
            s[0] = "تنسيب"; s[1] = "تفريغ"; s[2] = "استضافة";
            tb4.Items.AddRange(s);

            tb8.Items.Clear();
            CLS_FRMS.CLSCONSTENTRY GetDeparments = new CLSCONSTENTRY();
            DataTable dtdepartment = GetDeparments.GetDataDepartment();
            for (int i = 0; i < dtdepartment.Rows.Count; i++)
            {
                tb8.Items.Add(dtdepartment.Rows[i][1].ToString());
            }
            tb10.Items.Clear();
            string[] b = new string[2];
            b[0] = "تمت"; b[1] = "لم تتم";
            tb10.Items.AddRange(b);

            return Dt;
        }
        //--==========================================================================================================================
        //======== This Codes Below For Insert data to the EmpTanseeb Table / using the EmpTabnseebInsertData Procedure 
        public void EmpTanseebinsertData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDcontanseeb
            , string EmployeeName, string TheType, double Period, DateTime FromDate, DateTime ToDate, string Beneficiary, string TypeSituation, string Notice
            , string RegisterName, string AddingDate, string AddingTime)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int);                            param[0].Value = IDcontanseeb;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50);                    param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@TheType", SqlDbType.VarChar, 50);                         param[2].Value = TheType;
            param[3] = new SqlParameter("@Period", SqlDbType.Real);                                 param[3].Value = Period;
            param[4] = new SqlParameter("@FromDate", SqlDbType.Date);                               param[4].Value = FromDate;
            param[5] = new SqlParameter("@ToDate", SqlDbType.Date);                                 param[5].Value = ToDate;
            param[6] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50);                     param[6].Value = Beneficiary;
            param[7] = new SqlParameter("@TypeSituation", SqlDbType.VarChar, 50);                   param[7].Value = TypeSituation;
            param[8] = new SqlParameter("@Notice", SqlDbType.Text);                                 param[8].Value = Notice;
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);                    param[9].Value = RegisterName;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50);                     param[10].Value = AddingDate;
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50);                     param[11].Value = AddingTime;


            dal.open();
            DataTable Dt = dal.SelectingData("EmpTabnseebInsertData", param);
            dal.close();

            EmpTanseebGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
                , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //=======================================================================================================================
        //====== This Codes Below For Update data to the EmpTanseeb Table / using the EmpTabnseebUpdatetData Procedure
        public void EmpTanseebUpdatetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDcontanseeb
            , string EmployeeName, string TheType, double Period, DateTime FromDate, DateTime ToDate, string Beneficiary, string TypeSituation, string Notice
            , string RegisterName, string AddingDate, string AddingTime, int IDseqtanseeb)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@IDcontanseeb", SqlDbType.Int); param[0].Value = IDcontanseeb;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@TheType", SqlDbType.VarChar, 50); param[2].Value = TheType;
            param[3] = new SqlParameter("@Period", SqlDbType.Real); param[3].Value = Period;
            param[4] = new SqlParameter("@FromDate", SqlDbType.Date); param[4].Value = FromDate;
            param[5] = new SqlParameter("@ToDate", SqlDbType.Date); param[5].Value = ToDate;
            param[6] = new SqlParameter("@Beneficiary", SqlDbType.VarChar, 50); param[6].Value = Beneficiary;
            param[7] = new SqlParameter("@TypeSituation", SqlDbType.VarChar, 50); param[7].Value = TypeSituation;
            param[8] = new SqlParameter("@Notice", SqlDbType.Text); param[8].Value = Notice;
            param[9] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[9].Value = RegisterName;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[10].Value = AddingDate;
            param[11] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[11].Value = AddingTime;
            param[12] = new SqlParameter("@IDseqtanseeb", SqlDbType.Int); param[12].Value = IDseqtanseeb;

            dal.open();
            DataTable Dt = dal.SelectingData("EmpTanseebUpdateData", param);
            dal.close();
            EmpTanseebGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
               , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //===========================================================================================================================
        //-========= this codes below for Deleting Data From Emptanseeb table / Usint the EmpTanseebDeleteData Procedure 
        public void EmpTanseebDeleteData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDseqtanseeb)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDseqtanseeb", SqlDbType.Int); param[0].Value = IDseqtanseeb;

            dal.open();
            DataTable Dt = dal.SelectingData("EmpTanseebDeleteData", param);
            dal.close();
            EmpTanseebGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
               , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //=====================================================================================================================
        //=====================================================================================================================================
        //======= This Codes Before For Build the Attendence Form And Getting Data /Using the Attenddenceselected procedure
        public DataTable EmpAttendenceGetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDconAttendence)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDconAttendence", SqlDbType.Int); param[0].Value = IDconAttendence;
            dal.open();
            DataTable Dt = dal.SelectingData("AttendenceSelected", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker))
                {
                    p.DataBindings.Clear();
                    p.Visible = true;
                    tbsearching.Visible = false;
                    btnclear.Visible = false;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = false;
                    btndelete.Visible = false;
                    tb6.Visible = false; tb7.Visible = false; tb12.Visible = false; tb13.Visible = false; tb14.Visible = false;
                    tb9.Visible = false; tb10.Visible = false;
                    p.Enabled = true;
                }

            }
            foreach (Control q in tbpn.Controls)
            {
                if (q is Label) { (q as Label).Visible = true; };
                lb9.Visible = false; lb10.Visible = false; lb12.Visible = false; lb13.Visible = false; lb14.Visible = false;
                lb6.Visible = false; lb7.Visible = false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 7; j < Dt.Columns.Count; j++)
                {
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[3].HeaderText = "وقت وتاريخ الحضور";
                    Dgv.Columns[4].HeaderText = "وقت وتاريخ المغادرة";
                    Dgv.Columns[5].HeaderText = "وجبة المنتسب";
                    Dgv.Columns[6].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;

           

            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "وقت وتاريخ الحضور"; lb5.Text = "وقت وتاريخ المغادرة";
            lb8.Text = "وجبة المنتسب"; lb11.Text = "ملاحظات";
            string str = "text";
            tb1.DataBindings.Add(str, Dt, "IDcomming"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDconattendence"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "EmployeeName"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "CommingDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); tb4.Enabled = false;
            tb5.DataBindings.Add(str, Dt, "GoingDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern); tb5.Enabled = false;
            tb8.DataBindings.Add(str, Dt, "WorkTime"); tb8.Enabled = false;
            tb11.DataBindings.Add(str, Dt, "Notice"); tb11.Enabled = false; tb11.Multiline = true; tb11.Height = 100;
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingDate"); tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingTime"); tb14.Visible = false;

            tb8.Items.Clear();
            string[] s = new string[3];
            s[0] = "الوجبة الصباحية"; s[1] = "الوجبة المسائية"; s[2] = "الوجبة الليلية";
            tb8.Items.AddRange(s);



            return Dt;
        }
        //==================================================================================================================================
        //==== =================== ===================== ========================= ========================= ============================
        // ===========this codes below for build the EmpChildren form / Getting Data from EmpChildrengettingdata procedure
        public DataTable EmpChildrenGetData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDconchild)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDconchild", SqlDbType.Int); param[0].Value = IDconchild;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpChildrenGettingData", param);
            dal.close();
            Dgv.DataSource = null; Dgv.DataSource = Dt;
            foreach (Control p in tbpn.Controls)
            {
                if ((p is TextBox) || (p is ComboBox) || (p is DateTimePicker))
                {
                    p.DataBindings.Clear();
                    p.Visible = true;
                    tbsearching.Visible = true;
                    btnclear.Visible = true;
                    btnAdd.Visible = true;
                    btnUpdate.Visible = true;
                    btndelete.Visible = true;
                    tb9.Visible = false; tb7.Visible = false;
                }

            }
            foreach (Control q in tbpn.Controls)
            {
                if (q is Label) { (q as Label).Visible = true; };
                lb9.Visible = false; lb7.Visible = false; lb12.Visible = false; lb13.Visible = false; lb14.Visible = false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 10; j < Dt.Columns.Count; j++)
                {
                    Dgv.Columns[i].Visible = false;
                    Dgv.Columns[j].Visible = false;
                    Dgv.Columns[3].HeaderText = "الاسم";
                    Dgv.Columns[4].HeaderText = "الجنس";
                    Dgv.Columns[5].HeaderText = "تاريخ الولادة";
                    Dgv.Columns[6].HeaderText = "العمر";
                    Dgv.Columns[7].HeaderText = "الحالة";
                    Dgv.Columns[8].HeaderText = "المهنة";
                    Dgv.Columns[9].HeaderText = "ملاحظات";
                    Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
            }

            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
            tb4.Text = null;
            tb5.Text = null;
            tb6.Text = null;
            tb7.Text = null;
            tb8.Text = null;
            tb10.Text = null;
            tb11.Text = null;
            tb12.Text = null;
            tb13.Text = null;
            tb14.Text = null;

          

            lb1.Text = "الرقم التسلسلي"; lb2.Text = "الرقم التعريفي"; lb3.Text = "الاسم"; lb4.Text = "اسم الطفل"; lb5.Text = "الجنس";
            lb6.Text = "تاريخ الولادة"; lb7.Text = "العمر"; lb8.Text = "الحالة"; lb10.Text = "المهنة"; lb11.Text = "ملاحظات";
            string str = "text";
            tb1.DataBindings.Add(str, Dt, "IDseqChild"); tb1.Enabled = false;
            tb2.DataBindings.Add(str, Dt, "IDconChild"); tb2.Enabled = false;
            tb3.DataBindings.Add(str, Dt, "EmployeeName"); tb3.Enabled = false;
            tb4.DataBindings.Add(str, Dt, "ChildName");
            tb5.DataBindings.Add(str, Dt, "Sex");
            tb6.DataBindings.Add(str, Dt, "BirthDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);

            tb8.DataBindings.Add(str, Dt, "SocialType");
            tb10.DataBindings.Add(str, Dt, "Job");
            tb11.DataBindings.Add(str, Dt, "Notice"); tb11.Enabled = true; tb11.Multiline = true; tb11.Height = 100;
            tb12.DataBindings.Add(str, Dt, "RegisterName"); tb12.Visible = false;
            tb13.DataBindings.Add(str, Dt, "AddingTime"); tb13.Visible = false;
            tb14.DataBindings.Add(str, Dt, "AddingDate"); tb14.Visible = false;

            tb8.Items.Clear();
            string[] s = new string[2];
            s[0] = "تم الحجب"; s[1] = "لم يتم";
            tb8.Items.AddRange(s);

            tb5.Items.Clear();
            string[] b = new string[2];
            b[0] = "ذكر"; b[1] = "انثى";
            tb5.Items.AddRange(b);

            tb10.Items.Clear();
            string[] c = new string[7];
            c[0] = "طفل"; c[1] = "طالب"; c[2] = "متزوج"; c[3] = "متزوجة"; c[4] = "موظف"; c[5] = "موظفة"; c[6] = "ربة بيت";
            tb10.Items.AddRange(c);
            return Dt;
        }
        //=======================================================================================
        //==== This Codes Below for Insert Data to the EmpChildren Table / Using the EmpChildrenInsertData Procedure
        public void EmpChildrenInsertData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDconchild
            , string EmployeeName, string childName, string sex, DateTime BirthDate, string Socialtype, string job, string Notice, string registername
            , string AddingTime, string Addingdate)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@IDconchild", SqlDbType.Int); param[0].Value = IDconchild;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@ChildName", SqlDbType.VarChar, 50); param[2].Value = childName;
            param[3] = new SqlParameter("@Sexchild", SqlDbType.VarChar, 50); param[3].Value = sex;
            param[4] = new SqlParameter("@BirthDate", SqlDbType.Date); param[4].Value = BirthDate;
            param[5] = new SqlParameter("@SocialType", SqlDbType.VarChar, 50); param[5].Value = Socialtype;
            param[6] = new SqlParameter("@Thejob", SqlDbType.VarChar, 50); param[6].Value = job;
            param[7] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[7].Value = Notice;
            param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[8].Value = registername;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[9].Value = AddingTime;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[10].Value = Addingdate;

            dal.open();
            DataTable Dt = dal.SelectingData("EmpChildrenInsertData", param);
            dal.close();
            EmpChildrenGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
              , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));

        }
        //=================================================================================================================================
        //=== This codes below for Update Data of EmpChildren Table / Using the EmpChildrenUpdateData Procedure
        public void EmpChildrenUpdateData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDconchild
            , string EmployeeName, string childName, string sex, DateTime BirthDate, string Socialtype, string job, string Notice, string registername
            , string AddingTime, string Addingdate, int IDchildseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@IDconchild", SqlDbType.Int); param[0].Value = IDconchild;
            param[1] = new SqlParameter("@EmployeeName", SqlDbType.VarChar, 50); param[1].Value = EmployeeName;
            param[2] = new SqlParameter("@ChildName", SqlDbType.VarChar, 50); param[2].Value = childName;
            param[3] = new SqlParameter("@Sexchild", SqlDbType.VarChar, 50); param[3].Value = sex;
            param[4] = new SqlParameter("@BirthDate", SqlDbType.Date); param[4].Value = BirthDate;
            param[5] = new SqlParameter("@SocialType", SqlDbType.VarChar, 50); param[5].Value = Socialtype;
            param[6] = new SqlParameter("@Thejob", SqlDbType.VarChar, 50); param[6].Value = job;
            param[7] = new SqlParameter("@Notice", SqlDbType.VarChar, 50); param[7].Value = Notice;
            param[8] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[8].Value = registername;
            param[9] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[9].Value = AddingTime;
            param[10] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[10].Value = Addingdate;
            param[11] = new SqlParameter("@IDChildseq", SqlDbType.Int); param[11].Value = IDchildseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpChildrenUpdateData", param);
            dal.close();
            EmpChildrenGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
            , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //===================================================================================================================================
        //======= This codes below for Delete Data From EmpChildren Table / Using the EmpChildrenDeleteData Procedure
        public void EmpChildrenDeleteData(DataGridView Dgv, TextBox tb1, TextBox tb2, TextBox tb3, ComboBox tb4, ComboBox tb5, DateTimePicker tb6
           , DateTimePicker tb7, ComboBox tb8, DateTimePicker tb9, ComboBox tb10, TextBox tb11, ComboBox tb12, ComboBox tb13, ComboBox tb14
           , TableLayoutPanel tbpn, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6, Label lb7, Label lb8, Label lb9, Label lb10, Label lb11
           , Label lb12, Label lb13, Label lb14, DevExpress.XtraEditors.SimpleButton btnclear, DevExpress.XtraEditors.SimpleButton btnAdd
           , DevExpress.XtraEditors.SimpleButton btnUpdate, DevExpress.XtraEditors.SimpleButton btndelete, TextBox tbsearching, int IDchildseq)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDChildseq", SqlDbType.Int); param[0].Value = IDchildseq;
            dal.open();
            DataTable Dt = dal.SelectingData("EmpChildrenUpdateData", param);
            dal.close();
            EmpChildrenGetData(Dgv, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb14, tbpn, lb1, lb2, lb3, lb4, lb5, lb6, lb7
            , lb8, lb9, lb10, lb11, lb12, lb13, lb14, btnclear, btnAdd, btnUpdate, btndelete, tbsearching, int.Parse(tb2.Text));
        }
        //================================================================================================================================
        //--- This function Below For Getting Data from EmpArchieves by Using EmpArchSelect Procedure
        public DataTable EmpArchSelect(int IdconArch, ListView Lsv, TextBox emparch1, TextBox emparch2, TextBox emparch3, TextBox emparch4, TextBox emparch5
            , TextBox emparch6, TextBox emparch7, TextBox emparch8, Panel pnarch1)
            
        {
            DAL.DataAccessLayer EmpArchGettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = IdconArch;
            EmpArchGettingData.open();
            DataTable Dt = EmpArchGettingData.SelectingData("EmpArchselect", param);
            EmpArchGettingData.close();

            foreach (Control p in pnarch1.Controls) { if (p is TextBox) { p.DataBindings.Clear(); } }


            string str = "text";
            emparch1.DataBindings.Add(str, Dt, "Idemparchieves");
            emparch2.DataBindings.Add(str, Dt, "IDconempArchieves");
            emparch3.DataBindings.Add(str, Dt, "Doc_number");
            emparch4.DataBindings.Add(str, Dt, "EmpName");
            emparch5.DataBindings.Add(str, Dt, "pathImage");
            emparch6.DataBindings.Add(str, Dt, "registername");
            emparch7.DataBindings.Add(str, Dt, "Addingtime");
            emparch8.DataBindings.Add(str, Dt, "AddingDate");

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(250, 250);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                try
                {
                    imageListLarge.Images.Add(Bitmap.FromFile(Dt.Rows[i][4].ToString()));
                }
                catch
                {
                    CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
                    imageListLarge.Images.Add(Getarchive.iconfile(Path.GetExtension(Dt.Rows[i][4].ToString())));
                }
            }
            Lsv.Items.Clear();
            Lsv.LargeImageList = imageListLarge;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                Lsv.Items.Add(Dt.Rows[i][4].ToString(), i);
            }

            Lsv.View = View.LargeIcon;

            return Dt;
        }
        //==============================================================================================================================
        //--- This function below for Adding data to the EmpArchieves table by using the EmpArchAdding Procedure....
        public void EmpArchAdding(int IDconemparch, int docnumber, string EmpName, string PathImgae, string RegisterName, string Addingtime, string AddingDate)
        {
            DAL.DataAccessLayer emparchadding = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@IDconemparch", SqlDbType.Int); param[0].Value = IDconemparch;
            param[1] = new SqlParameter("@docNumber", SqlDbType.Int); param[1].Value = docnumber;
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[2].Value = EmpName;
            param[3] = new SqlParameter("@PathImage", SqlDbType.Text); param[3].Value = PathImgae;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[4].Value = RegisterName;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[5].Value = Addingtime;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[6].Value = AddingDate;
            emparchadding.open();
            emparchadding.ExecuteCommand("EmparchAdding", param);
            emparchadding.close();
        }
        //===============================================================================================================================
        //--- This Function below for Updating Data of Emparchieves table by using EmpArchUpdate Procedure....
        public void EmpArchUpdate(int IDconemparch, int docnumber, string EmpName, string PathImgae, string RegisterName, string Addingtime
            , string AddingDate, int Idemparch)
        {
            DAL.DataAccessLayer emparchadding = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@IDconemparch", SqlDbType.Int); param[0].Value = IDconemparch;
            param[1] = new SqlParameter("@docNumber", SqlDbType.Int); param[1].Value = docnumber;
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[2].Value = EmpName;
            param[3] = new SqlParameter("@PathImage", SqlDbType.Text); param[3].Value = PathImgae;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[4].Value = RegisterName;
            param[5] = new SqlParameter("@AddingTime", SqlDbType.VarChar, 50); param[5].Value = Addingtime;
            param[6] = new SqlParameter("@AddingDate", SqlDbType.VarChar, 50); param[6].Value = AddingDate;
            param[7] = new SqlParameter("@IDempArch", SqlDbType.Int); param[7].Value = Idemparch;
            emparchadding.open();
            emparchadding.ExecuteCommand("EmpArchUpdate", param);
            emparchadding.close();
        }
        //===============================================================================================================================
        //---- this function below for Deleting data from emparchieves table by using EmpArchDelete Procedure....
        public void EmpArchDelete(int Idemparch)
        {
            DAL.DataAccessLayer emparchadding = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idemparch", SqlDbType.Int); param[0].Value = Idemparch;

            emparchadding.open();
            emparchadding.ExecuteCommand("EmpArchDelete", param);
            emparchadding.close();
        }


        //===============================================================================================================================
        //=====This Function Below for Getting Data of EmployeesArchieve using PathImage....
        public DataTable EmployeesArchpathimage(string PathImage, ListView Lsv, TextBox emparch1, TextBox emparch2, TextBox emparch3, TextBox emparch4, TextBox emparch5
           , TextBox emparch6, TextBox emparch7, TextBox emparch8, Panel pnarch1)
          
        {
            DAL.DataAccessLayer EmpArchGettingData = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PathImage", SqlDbType.Text);                   param[0].Value = PathImage;
            EmpArchGettingData.open();
            DataTable Dt = EmpArchGettingData.SelectingData("EmpArchSelectionPathImage", param);
            EmpArchGettingData.close();

            foreach (Control p in pnarch1.Controls) { if (p is TextBox) { p.DataBindings.Clear(); } }


            string str = "text";
            emparch1.DataBindings.Add(str, Dt, "Idemparchieves");
            emparch2.DataBindings.Add(str, Dt, "IDconempArchieves");
            emparch3.DataBindings.Add(str, Dt, "Doc_number");
            emparch4.DataBindings.Add(str, Dt, "EmpName");
            emparch5.DataBindings.Add(str, Dt, "pathImage");
            emparch6.DataBindings.Add(str, Dt, "registername");
            emparch7.DataBindings.Add(str, Dt, "Addingtime");
            emparch8.DataBindings.Add(str, Dt, "AddingDate");

            return Dt;
        }
        //=======================================================================================================================================
        //== This function below for GettingData of employees Documents , Using By stored Procedure EmployeesDocuments....
        public DataTable EmployeesDocuments(string emptype, DataGridView Dgv,DataGridView Dgv1)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmpType", SqlDbType.VarChar,50);                           param[0].Value = "انهاء خدمات";
            dal.open();
            DataTable Dt;
            
            if (emptype == "منتهي")
            {
                Dgv.DataSource = null;
                Dgv.Rows.Clear();
                Dgv.ColumnCount = 5;
                Dgv.Columns[0].HeaderText = "رقم الاضبارة";
                Dgv.Columns[1].HeaderText = "رقم الاضبارة ثاني";
                Dgv.Columns[2].HeaderText = "اسم المنتسب";
                Dgv.Columns[3].HeaderText = "موقف المنتسب";
                Dgv.Columns[4].HeaderText = "ملاحظات";

                Dt = dal.SelectingData("EmployeesDocuments", param);

                int j = 0;
                for (int i = 1; i <= Convert.ToInt32(Dt.Rows[Dt.Rows.Count-1][1]); i++)
                {
                    
                    if (Dt.Rows[j][1].ToString() == i.ToString())
                    {
                        string[] row = new string[] { Dt.Rows[j][0].ToString(), Dt.Rows[j][1].ToString(), Dt.Rows[j][2].ToString(),
                        Dt.Rows[j][3].ToString(), Dt.Rows[j][4].ToString() };
                        Dgv.Rows.Add(row);
                        j++;
                    }
                    else
                    {
                        string[] row = new string[] { "", i.ToString(), "", "", "" };
                        Dgv.Rows.Add(row);
                        Dgv.Rows[Dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                }
            }
            else
            {
                Dgv.DataSource = null;
                Dgv.Rows.Clear();
                Dgv.ColumnCount = 5;
                Dgv.Columns[0].HeaderText = "رقم الاضبارة";
                Dgv.Columns[1].HeaderText = "رقم الاضبارة ثاني";
                Dgv.Columns[2].HeaderText = "اسم المنتسب";
                Dgv.Columns[3].HeaderText = "موقف المنتسب";
                Dgv.Columns[4].HeaderText = "ملاحظات";

                Dt = dal.SelectingData("EmployeesDocuments2", null);

                int j = 0;
                for (int i = 1; i <= Convert.ToInt32(Dt.Rows[Dt.Rows.Count - 1][0]); i++)
                {

                    if (Dt.Rows[j][0].ToString() == i.ToString())
                    {
                        string[] row = new string[] { Dt.Rows[j][0].ToString(), Dt.Rows[j][1].ToString(), Dt.Rows[j][2].ToString(),
                        Dt.Rows[j][3].ToString(), Dt.Rows[j][4].ToString() };
                        Dgv.Rows.Add(row);
                        j++;
                    }
                    else
                    {
                        string[] row = new string[] { i.ToString(), "", "", "", "" };
                        Dgv.Rows.Add(row);
                        Dgv.Rows[Dgv.Rows.Count - 1].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                }
            }
            dal.close();
            
           
            

            Dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            return Dt;
        }
        //=========================================================================================
        //==

        public DataTable EmpVarGettingData2( int VarIDcon1, DevExpress.XtraEditors.ToggleSwitch VarTypeAdd,
           DevExpress.XtraEditors.ToggleSwitch VarTypeNotAdd)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@VarID", SqlDbType.Int);               param[0].Value = VarIDcon1;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVariableSelectingForTogglebtn", param);
            dal.close();
           
            return Dt;

        }
        //==========================================================================================
        //==== Searching in DataTabel In TreeNode...
        public DataTable TreeNodeSearching( DataGridView DgvEmpSearching)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("TreeNodeSearchingEmployees", null);
            dal.close();

            DgvEmpSearching.DataSource = null; DgvEmpSearching.DataSource = Dt; 

           
            return Dt;
        }
        //=============================================================================================
        // === Searching In DataTable in TreeNode 2 ...
        public DataTable TreeNodeSearching2(string Emp_Name, DataGridView DgvEmpInfo, TextBox empseq, TextBox empdocunopast, TextBox empdocunonew, ComboBox emptype, TextBox empidentityno
            , ComboBox empbloodtype, ComboBox empempsitu, ComboBox empbeneficiary, TextBox empregistername, ComboBox employeedawria, TextBox empemployeename
            , TextBox empsurname, ComboBox empjob, ComboBox empjobnow, ComboBox empdivision, ComboBox empunit, ComboBox empworkplace, ComboBox empsn
            , TextBox childrencount, ComboBox empwifetype, ComboBox empstudy, ComboBox emplaststudy, ComboBox emptaghsus, TextBox empmaharat, TextBox empoldwork
            , TextBox empoldworkplace, TextBox emplivenow, TextBox emplivesing, TextBox empoldliveplace, TextBox empjunsia, ComboBox empjunsiaplace
            , TextBox empshahada, ComboBox empshahadaplace, TextBox empbutaqasakan, ComboBox empmaqtabmu, TextBox empwatania, DateTimePicker empbirthdate
            , TextBox empbirthplace, TextBox emptaghweelno, DateTimePicker emptaghweeldate, TextBox empbarcode, TextBox empmobile1, TextBox empmobile2
            , ComboBox empdepartment, TextBox emppathimage, RichTextBox empnotice, PictureBox empimage, ComboBox employeeworktype, TableLayoutPanel pn7, TableLayoutPanel pn8, TableLayoutPanel pn9, TableLayoutPanel pn10)

        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Emp_Name", SqlDbType.VarChar,50); param[0].Value = Emp_Name;
            dal.open();
            DataTable Dt = dal.SelectingData("TreeNodeSearchingEmployees2", param);
            dal.close();

            DgvEmpInfo.DataSource = null; DgvEmpInfo.DataSource = Dt; empimage.Image = null;

            foreach (Control p in pn7.Controls) { if (p is TextBox || p is ComboBox) { (p).DataBindings.Clear(); } }
            foreach (Control p2 in pn8.Controls) { if (p2 is TextBox || p2 is ComboBox) { (p2).DataBindings.Clear(); } }
            foreach (Control p4 in pn9.Controls) { if (p4 is TextBox || p4 is ComboBox) { (p4).DataBindings.Clear(); } }
            foreach (Control p6 in pn10.Controls) { if (p6 is TextBox || p6 is ComboBox || p6 is RichTextBox || p6 is DateTimePicker) { (p6).DataBindings.Clear(); } }

            empseq.DataBindings.Clear();
            emptype.DataBindings.Clear();
            empdocunopast.DataBindings.Clear();
            empdocunonew.DataBindings.Clear();
            empidentityno.DataBindings.Clear();
            empbloodtype.DataBindings.Clear();
            empempsitu.DataBindings.Clear();
            empbeneficiary.DataBindings.Clear();
            empregistername.DataBindings.Clear();
            employeedawria.DataBindings.Clear();
            empemployeename.DataBindings.Clear();
            empsurname.DataBindings.Clear();
            empjob.DataBindings.Clear();
            empjobnow.DataBindings.Clear();
            empdivision.DataBindings.Clear();
            empunit.DataBindings.Clear();
            empworkplace.DataBindings.Clear();
            empsn.DataBindings.Clear();
            childrencount.DataBindings.Clear();
            empwifetype.DataBindings.Clear();
            empstudy.DataBindings.Clear();
            emplaststudy.DataBindings.Clear();
            emptaghsus.DataBindings.Clear();
            empmaharat.DataBindings.Clear();
            empoldwork.DataBindings.Clear();
            empoldworkplace.DataBindings.Clear();
            emplivenow.DataBindings.Clear();
            emplivesing.DataBindings.Clear();
            empoldliveplace.DataBindings.Clear();
            empjunsia.DataBindings.Clear();
            empjunsiaplace.DataBindings.Clear();
            empshahada.DataBindings.Clear();
            empshahadaplace.DataBindings.Clear();
            empbutaqasakan.DataBindings.Clear();
            empmaqtabmu.DataBindings.Clear();
            empwatania.DataBindings.Clear();
            empbirthdate.DataBindings.Clear();
            empbirthplace.DataBindings.Clear();
            emptaghweelno.DataBindings.Clear();
            emptaghweeldate.DataBindings.Clear();
            empbarcode.DataBindings.Clear();
            empmobile1.DataBindings.Clear();
            empmobile2.DataBindings.Clear();
            empdepartment.DataBindings.Clear();
            emppathimage.DataBindings.Clear();
            empnotice.DataBindings.Clear();
            employeeworktype.DataBindings.Clear();

            empseq.DataBindings.Add("text", Dt, "Emp_ID");

            emptype.DataBindings.Add("text", Dt, "Emp_type");
            empdocunopast.DataBindings.Add("text", Dt, "Emp_DocNO");
            empdocunonew.DataBindings.Add("text", Dt, "Emp_DocNOnew");
            empidentityno.DataBindings.Add("text", Dt, "Emp_IDentityNO");
            empbloodtype.DataBindings.Add("text", Dt, "Emp_BloodType");
            empempsitu.DataBindings.Add("Text", Dt, "Emp_EmployeeSituation");
            empbeneficiary.DataBindings.Add("text", Dt, "Emp_TheBeneficiary");
            empregistername.DataBindings.Add("text", Dt, "Emp_Registername");
            employeedawria.DataBindings.Add("text", Dt, "Emp_EmployeeDawria");
            empemployeename.DataBindings.Add("text", Dt, "Emp_EmployeeName");
            empsurname.DataBindings.Add("text", Dt, "Emp_Laqab");
            empjob.DataBindings.Add("text", Dt, "Emp_Job");
            empjobnow.DataBindings.Add("text", Dt, "Emp_WorkingType");
            empdivision.DataBindings.Add("text", Dt, "Emp_Division");
            empunit.DataBindings.Add("Text", Dt, "Emp_Unit");
            empworkplace.DataBindings.Add("text", Dt, "Emp_WorkingPlace");
            empsn.DataBindings.Add("text", Dt, "Emp_SN");
            childrencount.DataBindings.Add("text", Dt, "Emp_KidsCount");
            empwifetype.DataBindings.Add("text", Dt, "Emp_WifeWorking");
            empstudy.DataBindings.Add("Text", Dt, "Emp_Studing");
            emplaststudy.DataBindings.Add("Text", Dt, "Emp_LastStage");
            emptaghsus.DataBindings.Add("Text", Dt, "Emp_Taghsus");
            empmaharat.DataBindings.Add("Text", Dt, "Emp_Maharat");
            empoldwork.DataBindings.Add("Text", Dt, "Emp_OldWorking");
            empoldworkplace.DataBindings.Add("Text", Dt, "Emp_OldWorkingPlace");
            emplivenow.DataBindings.Add("Text", Dt, "Emp_LivePlaceNow");
            emplivesing.DataBindings.Add("Text", Dt, "Emp_PlacePointNearest");
            empoldliveplace.DataBindings.Add("Text", Dt, "Emp_OldLivePlace");
            empjunsia.DataBindings.Add("Text", Dt, "Emp_IDentityNumber");
            empjunsiaplace.DataBindings.Add("Text", Dt, "Emp_DaeratAhwal");
            empshahada.DataBindings.Add("Text", Dt, "Emp_ShahadaNumber");
            empshahadaplace.DataBindings.Add("Text", Dt, "Emp_DaeratNufuos");
            empbutaqasakan.DataBindings.Add("Text", Dt, "Emp_ButaqatSakan");
            empmaqtabmu.DataBindings.Add("Text", Dt, "Emp_MaktabMaalumat");
            empwatania.DataBindings.Add("Text", Dt, "Emp_ButaqatTawmenia");
            empbirthdate.DataBindings.Add("Text", Dt, "Emp_BirthDay", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            empbirthplace.DataBindings.Add("Text", Dt, "Emp_BrithDayPlace");
            emptaghweelno.DataBindings.Add("Text", Dt, "Emp_TaghweelNO");
            emptaghweeldate.DataBindings.Add("Text", Dt, "Emp_TaghweelDate", true, DataSourceUpdateMode.OnValidation, "", CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            empbarcode.DataBindings.Add("Text", Dt, "Emp_EmpBarcode");
            empmobile1.DataBindings.Add("Text", Dt, "Emp_Mobile1");
            empmobile2.DataBindings.Add("Text", Dt, "Emp_Mobile2");
            empdepartment.DataBindings.Add("Text", Dt, "Emp_EmpDepartment");
            emppathimage.DataBindings.Add("Text", Dt, "Emp_image");
            empnotice.DataBindings.Add("Text", Dt, "Emp_Notice");
            employeeworktype.DataBindings.Add("text", Dt, "Emp_EmployeeWorkType");

            if (emppathimage.Text == null || emppathimage.Text == "") { empimage.Image = null; } else { empimage.Load(emppathimage.Text); }

            //string[] str1 = new string[3];
            //str1[0] = "عقد"; str1[1] = "اجور يومية"; str1[2] = "تثبيت";
            //emptype.Items.Clear();
            //emptype.Items.AddRange(str1);
            TreeView Tr = new TreeView();
            CLSEMPLOYEES AddItems = new CLSEMPLOYEES();
            DataTable DtAdditems = AddItems.Emp_RootNode(Tr);
            emptype.Items.Clear();
            for (int i = 0; i < DtAdditems.Rows.Count; i++)
            {
                emptype.Items.Add(DtAdditems.Rows[i][0].ToString());
            }

            string[] str2 = new string[7];
            str2[0] = "A+"; str2[1] = "A-"; str2[2] = "B+"; str2[3] = "B-"; str2[4] = "AB"; str2[5] = "O+"; str2[6] = "O-";
            empbloodtype.Items.Clear();
            empbloodtype.Items.AddRange(str2);

            string[] str3 = new string[11];
            str3[0] = "لاشيء"; str3[1] = "استضافة"; str3[2] = "تنسيب"; str3[3] = "تفريغ"; str3[4] = "نقل خدمات"; str3[5] = "انهاء خدمات"; str3[6] = "انهاء عقد"; str3[7] = "انهاء اجور يومية"; str3[8] = "استقالة"; str3[9] = "متقاعد"; str3[10] = "متوفي";
            empempsitu.Items.Clear();
            empempsitu.Items.AddRange(str3);
            

            string[] str4 = new string[6];
            str4[0] = "الاولى"; str4[1] = "الثانية"; str4[2] = "الثالثة"; str4[3] = "الرابعة"; str4[4] = "الخامسة"; str4[5] = "السادسة";
            emplaststudy.Items.Clear();
            emplaststudy.Items.AddRange(str4);

            string[] str5 = new string[4];
            str5[0] = "اعزب"; str5[1] = "متزوج"; str5[2] = "ارمل"; str5[3] = "مطلق";
            empsn.Items.Clear();
            empsn.Items.AddRange(str5);

            string[] str6 = new string[2];
            str6[0] = "موظفة"; str6[1] = "ربة بيت";
            empwifetype.Items.Clear();
            empwifetype.Items.AddRange(str6);

            string[] str7 = new string[7];
            str7[0] = "الأحد"; str7[1] = "الإثنين"; str7[2] = "الثلاثاء"; str7[3] = "الأربعاء"; str7[4] = "الخميس"; str7[5] = "الجمعة"; str7[6] = "السبت";
            employeedawria.Items.Clear();
            employeedawria.Items.AddRange(str7);

            string[] str8 = new string[4];
            str8[0] = "7"; str8[1] = "14"; str8[2] = "24"; str8[3] = "حر";
            employeeworktype.Items.Clear();
            employeeworktype.Items.AddRange(str8);


            empbeneficiary.Items.Clear();
            empdepartment.Items.Clear();
            CLSCONSTENTRY GetDate = new CLSCONSTENTRY();
            DataTable Dtdepartment = GetDate.GetDataDepartment();
            for (int i = 0; i < Dtdepartment.Rows.Count; i++)
            {
                empbeneficiary.Items.Add(Dtdepartment.Rows[i][1].ToString());
                empdepartment.Items.Add(Dtdepartment.Rows[i][1].ToString());
            }

            empjob.Items.Clear();
            CLSCONSTENTRY Gettingdata = new CLSCONSTENTRY();
            DataTable Dtempjob = Gettingdata.JobsNamesGettingdata();
            for (int j = 0; j < Dtempjob.Rows.Count; j++)
            {
                empjob.Items.Add(Dtempjob.Rows[j][1].ToString());
            }

            empunit.Items.Clear();
            CLSCONSTENTRY Getdataunit = new CLSCONSTENTRY();
            DataTable Dtunit = Getdataunit.UnitsNamesGettingdata();
            for (int jj = 0; jj < Dtunit.Rows.Count; jj++)
            {
                empunit.Items.Add(Dtunit.Rows[jj][1].ToString());
            }

            empdivision.Items.Clear();
            CLSCONSTENTRY GetdataDivision = new CLSCONSTENTRY();
            DataTable DtDivision = GetdataDivision.DivisionsNameGettingData();
            for (int ii = 0; ii < DtDivision.Rows.Count; ii++)
            {
                empdivision.Items.Add(DtDivision.Rows[ii][1].ToString());
            }

            empstudy.Items.Clear();
            CLSCONSTENTRY GetdataStudy = new CLSCONSTENTRY();
            DataTable Dtstudy = GetdataStudy.StudyingNamesGettingData();
            for (int z = 0; z < Dtstudy.Rows.Count; z++)
            {
                empstudy.Items.Add(Dtstudy.Rows[z][1].ToString());
            }

            empjunsiaplace.Items.Clear();
            empshahadaplace.Items.Clear();
            empmaqtabmu.Items.Clear();
            CLSCONSTENTRY GetData = new CLSCONSTENTRY();
            DataTable DtPlace = GetDate.DistenationSelecting();
            for (int w = 0; w < DtPlace.Rows.Count; w++)
            {
                empjunsiaplace.Items.Add(DtPlace.Rows[w][1].ToString());
                empshahadaplace.Items.Add(DtPlace.Rows[w][1].ToString());
                empmaqtabmu.Items.Add(DtPlace.Rows[w][1].ToString());
            }

            return Dt;
        }

        //=========================================
        public void BtnProperties(DevExpress.XtraBars.BarButtonItem btnPersonUI,DevExpress.XtraBars.BarButtonItem btnAdministorOrders
            ,DevExpress.XtraBars.BarButtonItem btnEmployeesVariable,DevExpress.XtraBars.BarButtonItem btndeserve
            ,DevExpress.XtraBars.BarButtonItem btndisputched,DevExpress.XtraBars.BarButtonItem btncontracts,DevExpress.XtraBars.BarButtonItem btnchildren
            ,DevExpress.XtraBars.BarButtonItem btnZam,DevExpress.XtraBars.BarButtonItem  btntanseeb,DevExpress.XtraBars.BarButtonItem btnattendence
            ,DevExpress.XtraBars.BarButtonItem btnworksheft,DevExpress.XtraBars.BarButtonItem btnArchieves,DevExpress.XtraBars.BarButtonItem btnDocumemnts
            ,DevExpress.XtraBars.BarButtonItem btnDeservePressing, DevExpress.XtraBars.BarButtonItem btnDeserveSatisfying)
        {

            btnPersonUI.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnPersonUI.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnPersonUI.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnPersonUI.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnPersonUI.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnPersonUI.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnPersonUI.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnPersonUI.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnAdministorOrders.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnAdministorOrders.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnAdministorOrders.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnAdministorOrders.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnAdministorOrders.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnAdministorOrders.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnAdministorOrders.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnAdministorOrders.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btncontracts.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btncontracts.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btncontracts.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btncontracts.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btncontracts.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btncontracts.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btncontracts.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btncontracts.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnEmployeesVariable.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnEmployeesVariable.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnEmployeesVariable.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnEmployeesVariable.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnEmployeesVariable.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnEmployeesVariable.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnEmployeesVariable.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnEmployeesVariable.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btndisputched.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndisputched.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndisputched.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndisputched.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndisputched.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndisputched.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndisputched.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndisputched.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btndeserve.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndeserve.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndeserve.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndeserve.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndeserve.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndeserve.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btndeserve.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btndeserve.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnchildren.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnchildren.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnchildren.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnchildren.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnchildren.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnchildren.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnchildren.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnchildren.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btntanseeb.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btntanseeb.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btntanseeb.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btntanseeb.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btntanseeb.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btntanseeb.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btntanseeb.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btntanseeb.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnworksheft.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnworksheft.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnworksheft.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnworksheft.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnworksheft.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnworksheft.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnworksheft.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnworksheft.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnattendence.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnattendence.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnattendence.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnattendence.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnattendence.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnattendence.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnattendence.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnattendence.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnArchieves.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnArchieves.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnArchieves.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnArchieves.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnArchieves.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnArchieves.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnArchieves.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnArchieves.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnZam.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnZam.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnZam.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnZam.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnZam.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnZam.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnZam.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnZam.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            btnDocumemnts.ItemAppearance.Disabled.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnDocumemnts.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnDocumemnts.ItemAppearance.Hovered.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnDocumemnts.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnDocumemnts.ItemAppearance.Normal.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnDocumemnts.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            btnDocumemnts.ItemAppearance.Pressed.Font = new Font("JF Flat", 9, FontStyle.Bold);
            btnDocumemnts.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;



            CLS_UsersAndPermissions per = new CLS_UsersAndPermissions();
            DataTable Dt = per.PerOne(Properties.Settings.Default.UserNameLogin, Properties.Settings.Default.PasswordLogin);
            if (Dt.Rows.Count > 0)
            {
                
                if (Dt.Rows[0][29].ToString() == null || Dt.Rows[0][29].ToString() == "" || Dt.Rows[0][29].ToString() == "False")
                    btnAdministorOrders.Enabled = false;
                else btnAdministorOrders.Enabled = true;

                if (Dt.Rows[0][31].ToString() == null || Dt.Rows[0][31].ToString() == "" || Dt.Rows[0][31].ToString() == "False")
                    btncontracts.Enabled = false;
                else btncontracts.Enabled = true;

                if (Dt.Rows[0][30].ToString() == null || Dt.Rows[0][30].ToString() == "" || Dt.Rows[0][30].ToString() == "False")
                    btnEmployeesVariable.Enabled = false;
                else btnEmployeesVariable.Enabled = true;

                if (Dt.Rows[0][18].ToString() == null || Dt.Rows[0][18].ToString() == "" || Dt.Rows[0][18].ToString() == "False")
                    btndisputched.Enabled = false;
                else btndisputched.Enabled = true;

                if (Dt.Rows[0][17].ToString() == null || Dt.Rows[0][17].ToString() == "" || Dt.Rows[0][17].ToString() == "False")
                    btndeserve.Enabled = false;
                else btndeserve.Enabled = true;

                if (Dt.Rows[0][32].ToString() == null || Dt.Rows[0][32].ToString() == "" || Dt.Rows[0][32].ToString() == "False")
                    btnchildren.Enabled = false;
                else btnchildren.Enabled = true;

                if (Dt.Rows[0][34].ToString() == null || Dt.Rows[0][34].ToString() == "" || Dt.Rows[0][34].ToString() == "False")
                    btntanseeb.Enabled = false;
                else btntanseeb.Enabled = true;

                if (Dt.Rows[0][16].ToString() == null || Dt.Rows[0][15].ToString() == "" || Dt.Rows[0][15].ToString() == "False")
                    btnworksheft.Enabled = false;
                else btnworksheft.Enabled = true;

                if (Dt.Rows[0][15].ToString() == null || Dt.Rows[0][14].ToString() == "" || Dt.Rows[0][14].ToString() == "False")
                    btnattendence.Enabled = false;
                else btnattendence.Enabled = true;

                if (Dt.Rows[0][35].ToString() == null || Dt.Rows[0][35].ToString() == "" || Dt.Rows[0][35].ToString() == "False")
                    btnArchieves.Enabled = false;
                else btnArchieves.Enabled = true;

                if (Dt.Rows[0][33].ToString() == null || Dt.Rows[0][33].ToString() == "" || Dt.Rows[0][33].ToString() == "False")
                    btnZam.Enabled = false;
                else btnZam.Enabled = true;

                if (Dt.Rows[0][38].ToString() == null || Dt.Rows[0][38].ToString() == "" || Dt.Rows[0][38].ToString() == "False")
                    btnDeservePressing.Enabled = false;
                else btnDeservePressing.Enabled = true;

                if (Dt.Rows[0][39].ToString() == null || Dt.Rows[0][39].ToString() == "" || Dt.Rows[0][39].ToString() == "False")
                    btnDeserveSatisfying.Enabled = false;
                else btnDeserveSatisfying.Enabled = true;


            }
         }
         //--------------------------------------------------------------------------------------
         //Employe Variables Archive
         
          //select Data
         public DataTable EmpVararchSelectdata(int IDVarCon)
         {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = IDVarCon;
            dal.open();
            DataTable Dt = dal.SelectingData("EmployeeVarSelectArchive", param);
            dal.close();

            return Dt;
         }

        //----------------

        //insert data
        public void EmpVararchInsertdata(int IDVarcon,int IDEmp,string EmpName,string ImgPath)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@IDconVar", SqlDbType.Int); param[0].Value = IDVarcon;
            param[1] = new SqlParameter("@IDEmp", SqlDbType.Int); param[1].Value = IDEmp;
            param[2] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[2].Value = EmpName;
            param[3] = new SqlParameter("@ImgPath", SqlDbType.VarChar, 800); param[3].Value = ImgPath;
            param[4] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[4].Value = Properties.Settings.Default.UserNameLogin;
            dal.open();
            dal.ExecuteCommand("EmployeeVarInsertintoArchive", param);
            dal.close();

        }

        //----------------

        //Update date
        public void EmpVararchUpdatedata(int id, int IDVarcon, int IDEmp, string EmpName, string ImgPath)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = id;
            param[1] = new SqlParameter("@IDconVar", SqlDbType.Int); param[1].Value = IDVarcon;
            param[2] = new SqlParameter("@IDEmp", SqlDbType.Int); param[2].Value = IDEmp;
            param[3] = new SqlParameter("@EmpName", SqlDbType.VarChar, 50); param[3].Value = EmpName;
            param[4] = new SqlParameter("@ImgPath", SqlDbType.VarChar, 800); param[4].Value = ImgPath;
            param[5] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50); param[5].Value = Properties.Settings.Default.UserNameLogin;
            dal.open();
            dal.ExecuteCommand("EmployeeVarUpdateintoArchive", param);
            dal.close();

        }

        //----------------

        //delete data
        public void EmpVararchDeletedata(int IDVarcon)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = IDVarcon;
            dal.open();
            dal.ExecuteCommand("EmployeeVarDeleteintoArchive", param);
            dal.close();

        }

    }
}
