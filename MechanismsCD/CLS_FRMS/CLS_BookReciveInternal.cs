using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.CLS_FRMS
{
    class CLS_BookReciveInternal
    {
        //===============================================================================================================================

        //=== This Function Below for send book from this server to other server (internal)....
        public void SendBook(int id, int idcon, string Book_Date, string RegisterName, string AddTime, string AddDate, string to, string BookTitle)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@idcon", SqlDbType.Int);                   param[0].Value = idcon;
            param[1] = new SqlParameter("@Sender", SqlDbType.VarChar, 50);          param[1].Value = Properties.Settings.Default.ServerName;
            param[2] = new SqlParameter("@Book_Date", SqlDbType.VarChar, 50);       param[2].Value = Book_Date;
            param[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);    param[3].Value = Properties.Settings.Default.UserNameLogin;
            param[4] = new SqlParameter("@AddTime", SqlDbType.VarChar, 50);         param[4].Value = DateTime.Now.ToString("HH:mm:ss"); 
            param[5] = new SqlParameter("@AddDate", SqlDbType.VarChar, 50);         param[5].Value = DateTime.Today.ToString("dd-MM-yyyy");
            param[6] = new SqlParameter("@RecType", SqlDbType.VarChar, 50);         param[6].Value = to;
            param[7] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50);       param[7].Value = BookTitle;
            param[8] = new SqlParameter("@Notific", SqlDbType.Bit);                 param[8].Value = false;
            if (to == "كافة الشعب" || to == "السيد رئيس القسم" || to == "السيد المعاون الاداري" || to == "السيد المعاون الفني")
            {
               
                dal.open1();
                dal.ExecuteCommand1("BookReciveInsertData", param);
                dal.close1();
                SendBookArchive(id, Properties.Settings.Default.ServerIp1);

                SqlParameter[] param1 = new SqlParameter[9];
                param1[0] = new SqlParameter("@idcon", SqlDbType.Int);                  param1[0].Value = idcon;
                param1[1] = new SqlParameter("@Sender", SqlDbType.VarChar, 50);         param1[1].Value = Properties.Settings.Default.ServerName;
                param1[2] = new SqlParameter("@Book_Date", SqlDbType.VarChar, 50);      param1[2].Value = Book_Date;
                param1[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);   param1[3].Value = Properties.Settings.Default.UserNameLogin;
                param1[4] = new SqlParameter("@AddTime", SqlDbType.VarChar, 50);        param1[4].Value = DateTime.Now.ToString("HH:mm:ss");
                param1[5] = new SqlParameter("@AddDate", SqlDbType.VarChar, 50);        param1[5].Value = DateTime.Today.ToString("dd-MM-yyyy");
                param1[6] = new SqlParameter("@RecType", SqlDbType.VarChar, 50);        param1[6].Value = to;
                param1[7] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50);      param1[7].Value = BookTitle;
                param1[8] = new SqlParameter("@Notific", SqlDbType.Bit);                param1[8].Value = false;

                dal.open2();
                dal.ExecuteCommand2("BookReciveInsertData", param1);
                dal.close2();
                SendBookArchive(id, Properties.Settings.Default.ServerIp2);

                SqlParameter[] param2 = new SqlParameter[9];
                param2[0] = new SqlParameter("@idcon", SqlDbType.Int);                   param2[0].Value = idcon;
                param2[1] = new SqlParameter("@Sender", SqlDbType.VarChar, 50);          param2[1].Value = Properties.Settings.Default.ServerName;
                param2[2] = new SqlParameter("@Book_Date", SqlDbType.VarChar, 50);       param2[2].Value = Book_Date;
                param2[3] = new SqlParameter("@RegisterName", SqlDbType.VarChar, 50);    param2[3].Value = Properties.Settings.Default.UserNameLogin;
                param2[4] = new SqlParameter("@AddTime", SqlDbType.VarChar, 50);         param2[4].Value = DateTime.Now.ToString("HH:mm:ss");
                param2[5] = new SqlParameter("@AddDate", SqlDbType.VarChar, 50);         param2[5].Value = DateTime.Today.ToString("dd-MM-yyyy");
                param2[6] = new SqlParameter("@RecType", SqlDbType.VarChar, 50);         param2[6].Value = to;
                param2[7] = new SqlParameter("@BookTitle", SqlDbType.VarChar, 50);       param2[7].Value = BookTitle;
                param2[8] = new SqlParameter("@Notific", SqlDbType.Bit);                 param2[8].Value = false;

                dal.open3();
                dal.ExecuteCommand3("BookReciveInsertData", param2);
                dal.close3();
                SendBookArchive(id, Properties.Settings.Default.ServerIp3);
            }
            else
            {
                    if (to == Properties.Settings.Default.ServerName1.ToString())
                    {
                        dal.open1();
                        dal.ExecuteCommand1("BookReciveInsertData", param);
                        dal.close1();

                        SendBookArchive(id, Properties.Settings.Default.ServerIp1);
                    }
                    else
                    {
                        if (to == Properties.Settings.Default.ServerName2.ToString())
                        {
                            dal.open2();
                            dal.ExecuteCommand2("BookReciveInsertData", param);
                            dal.close2();

                            SendBookArchive(id, Properties.Settings.Default.ServerIp2);
                        }
                        else
                        {
                            if (to == Properties.Settings.Default.ServerName3.ToString())
                            {
                                dal.open3();
                                dal.ExecuteCommand3("BookReciveInsertData", param);
                                dal.close3();

                                SendBookArchive(id, Properties.Settings.Default.ServerIp3);
                            }
                        }
                    }
                
            }

        }

        //--this function for add images morfakat of book send to other server and save it in other server(this function uses in sendBook function)
        public void SendBookArchive(int id, string ip)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = id;
            dal.open();
            DataTable Dt = dal.SelectingData("Thatyia2Select", param);
            dal.close();

            
            DataTable DtId = null;
            
            if (ip == Properties.Settings.Default.ServerIp1)
            {
                dal.open1();
                DtId = dal.SelectingData1("SelectBookReciveLastId", null);
                dal.close1();
            }
            else
            {
                if (ip == Properties.Settings.Default.ServerIp2)
                {
                    dal.open2();
                    DtId = dal.SelectingData2("SelectBookReciveLastId", null);
                    dal.close2();
                }
                else
                {
                    if (ip == Properties.Settings.Default.ServerIp3)
                    {
                        dal.open3();
                        DtId = dal.SelectingData3("SelectBookReciveLastId", null);
                        dal.close3();
                    }
                }
            }
            
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                string path = GetArchievePath(ip);
                string pathimage = Dt.Rows[i][5].ToString();
                string nameimage = Path.GetFileName(pathimage);
                string newpath = path + nameimage;
                //try
                //{
                File.Copy(Dt.Rows[i][5].ToString(), newpath);
                //}
                //catch { }
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@idcon", SqlDbType.Int);
                param[0].Value = int.Parse(DtId.Rows[0][0].ToString());
                param[1] = new SqlParameter("@Path", SqlDbType.VarChar, 500); param[1].Value = newpath;



                if (ip == Properties.Settings.Default.ServerIp1)
                {
                    dal.open1();
                    dal.ExecuteCommand1("BookReciveMorfakatInsertData", param);
                    dal.close1();
                }
                else
                {
                    if (ip == Properties.Settings.Default.ServerIp2)
                    {
                        dal.open2();
                        dal.ExecuteCommand2("BookReciveMorfakatInsertData", param);
                        dal.close2();
                    }
                    else
                    {
                        if (ip == Properties.Settings.Default.ServerIp3)
                        {
                            dal.open3();
                            dal.ExecuteCommand3("BookReciveMorfakatInsertData", param);
                            dal.close3();
                        }
                    }
                }
            }
        }
        //=========================================================================
        // This code below for Getting Data Recive Book internal From Book_Receive table
        public DataTable Book_Receive(DataGridView Dgv, TextBox Recive_Num, TextBox Recive_Date, TextBox Recive_Time,
            TextBox txtBook_Num, TextBox Book_Date, TextBox From, TextBox RegisterName, TextBox addtime, TextBox adddate, TextBox booktitle)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            dal.open();
            DataTable Dt = dal.SelectingData("BookReciveSelectingData", null);
            dal.close();
            
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@username", SqlDbType.VarChar,50); param[0].Value = Properties.Settings.Default.UserNameLogin.ToString();
            dal.open();
            DataTable Dtuser = dal.SelectingData("usersSelectingforper", param);
            dal.close();

            Dgv.DataSource = null;
            
            if (Dtuser.Rows[0][3].ToString() == "رئيس قسم")
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i][9].ToString() != Properties.Settings.Default.ServerName1.ToString() && Dt.Rows[i][9].ToString() != "السيد رئيس القسم")
                        Dt.Rows[i].Delete();
                }
            }
            else
            {
                if (Dtuser.Rows[0][3].ToString() == "معاون اداري")
                {
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        if (Dt.Rows[i][9].ToString() != Properties.Settings.Default.ServerName1.ToString() && Dt.Rows[i][9].ToString() != "السيد المعاون الاداري")
                            Dt.Rows[i].Delete();
                    }
                }
                else
                {
                    if (Dtuser.Rows[0][3].ToString() == "معاون فني")
                    {
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            if (Dt.Rows[i][9].ToString() != Properties.Settings.Default.ServerName1.ToString() && Dt.Rows[i][9].ToString() != "السيد المعاون الفني")
                                Dt.Rows[i].Delete();
                        }
                    }
                   
                }
            }
            Dt.AcceptChanges();
            Dgv.DataSource = Dt;

            Recive_Num.DataBindings.Clear();
            Recive_Date.DataBindings.Clear();
            Recive_Time.DataBindings.Clear();
            txtBook_Num.DataBindings.Clear();
            Book_Date.DataBindings.Clear();
            From.DataBindings.Clear();
            RegisterName.DataBindings.Clear();
            addtime.DataBindings.Clear();
            adddate.DataBindings.Clear();
            booktitle.DataBindings.Clear();

            string str = "text";
            Recive_Num.DataBindings.Add(str, Dt, "id");
            Recive_Date.DataBindings.Add(str, Dt, "DateSend");
            Recive_Time.DataBindings.Add(str, Dt, "TimeSend");
            txtBook_Num.DataBindings.Add(str, Dt, "id_con");
            Book_Date.DataBindings.Add(str, Dt, "Book_Date");
            From.DataBindings.Add(str, Dt, "Sender");
            RegisterName.DataBindings.Add(str, Dt, "RegisterName");
            addtime.DataBindings.Add(str, Dt, "AddTime");
            adddate.DataBindings.Add(str, Dt, "AddDate");
            booktitle.DataBindings.Add(str, Dt, "BookTitle");

            Dgv.Columns[0].HeaderText = "رقم الوارد";
            Dgv.Columns[1].HeaderText = "رقم الكتاب";
            Dgv.Columns[2].Visible = false;
            Dgv.Columns[3].HeaderText = "وقت الوارد";
            Dgv.Columns[4].HeaderText = "تاريخ الوارد";
            Dgv.Columns[5].HeaderText = "تاريخ الكتاب";            
            Dgv.Columns[6].Visible = false;
            Dgv.Columns[7].Visible = false;
            Dgv.Columns[8].Visible = false;
            Dgv.Columns[9].Visible = false;
            Dgv.Columns[10].HeaderText = "عنوان الكتاب";
            Dgv.Columns[11].Visible = false;
            return Dt;
        }

        //===============================================================================================================================

        //=== This Function Below for update book recive data from other server in this server (internal)....
        public void updateReciveBook(int id, int idcon, string Sender, string Book_Date)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@id", SqlDbType.Int);                   param[0].Value = id;
            param[1] = new SqlParameter("@idcon", SqlDbType.Int);                param[1].Value =idcon;
            param[2] = new SqlParameter("@Sender", SqlDbType.VarChar, 50);       param[2].Value = Sender;
            param[3] = new SqlParameter("@Book_Date", SqlDbType.VarChar, 50);    param[3].Value = Book_Date;
           
            dal.open();
            dal.ExecuteCommand("BookReciveUpdateData", param);
            dal.close();
        }

        //============================================================================================================
        //=== This Function below for Deleting book in Book_Receive table....
        public void DeletingReciveBook(int id)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int); param[0].Value = id;
            dal.open();
            dal.ExecuteCommand("BookReciveDeleteData", param);
            dal.close();
            param = new SqlParameter[1];
            param[0] = new SqlParameter("@IDcon", SqlDbType.Int); param[0].Value = id;
            dal.open();
            dal.ExecuteCommand("BookReciveMorfakatDeleteDataByIDcon", param);
            dal.close();
        }

        //---------------------------------------------------------------------
        //select archive for book recive internal
        public DataTable selectBookreciveArchive(int idcon, TextBox txtArchiveID, ListView lsv)
        {
            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@idcon", SqlDbType.Int); param[0].Value = idcon;
            dal.open();
            DataTable Dt = dal.SelectingData("BookReciveMorfakatSelectingData", param);
            dal.close();

            txtArchiveID.DataBindings.Clear();
           

            txtArchiveID.DataBindings.Add("text", Dt, "id");
            

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(250, 250);
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                try
                {
                    imageListLarge.Images.Add(Bitmap.FromFile(Dt.Rows[i][2].ToString()));
                }
                catch
                {
                    imageListLarge.Images.Add(iconfile(Path.GetExtension(Dt.Rows[i][2].ToString())));
                }

            }
            lsv.Items.Clear();
            lsv.LargeImageList = imageListLarge;
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                lsv.Items.Add(Dt.Rows[i][2].ToString(), i);
            }

            lsv.View = View.LargeIcon;
            return Dt;
        }

        //get path of employee archieve
        public string GetArchievePath(string ip)
        {
            string[] divName = { Properties.Settings.Default.ServerIp.ToString(), Properties.Settings.Default.ServerIp1.ToString(), Properties.Settings.Default.ServerIp2.ToString(), Properties.Settings.Default.ServerIp3.ToString() };

            DAL.DataAccessLayer dal = new DAL.DataAccessLayer();

            if (ip == divName[0])
            {
                return Properties.Settings.Default.PathOfArchieves.ToString();
            }
            else if (ip == divName[1])
            {
                return Properties.Settings.Default.Archieves1.ToString();
            }
            else if (ip == divName[2])
            {
                return Properties.Settings.Default.Archieves2.ToString();
            }
            else if (ip == divName[3])
            {
                return Properties.Settings.Default.Archieves3.ToString();
            }
            return null;
        }


        //===============================================================================================================================
        //===this function below for get file icon
        public Image iconfile(string fileex)
        {
            List<string> exWord = new List<string>(new string[] { ".doc", ".doc", ".wbk", ".docx", ".docm", ".dotx", ".dotm", ".docb" });

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
            if (fileex == ".pdf")
                return Properties.Resources.pdf;
            if (fileex == ".txt")
                return Properties.Resources.txt;

            return Properties.Resources.الاليات;
        }

    }
}
