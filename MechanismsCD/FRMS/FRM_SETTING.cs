using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;
using System.IO;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using MechanismsCD.Properties;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Http;
using asprise_imaging_api;
using System.Net.Sockets;
using System.Management;
using System.Data.Sql;

namespace MechanismsCD.FRMS
{
    public partial class FRM_SETTING : Form
    {
        //DAL.DataAccessLayer conn = new DAL.DataAccessLayer();

        public FRM_SETTING()
        {
            InitializeComponent();
            try
            {
                txtServerName.Text = Properties.Settings.Default.ServerName.ToString();
                cboserverIp.Text = Properties.Settings.Default.ServerIp.ToString();
                cbodbname.Text = Properties.Settings.Default.DBName.ToString();
                tbusername.Text = Properties.Settings.Default.DBuserName.ToString();
                tbpassword.Text = Properties.Settings.Default.DBpassword.ToString();

                PathofArchieve.Text = Properties.Settings.Default.PathOfArchieves.ToString();
                PathofEmployees.Text = Properties.Settings.Default.PathOfEmployees.ToString();
                Pathofcars.Text = Properties.Settings.Default.PathOfCars.ToString();
                pathofFuel.Text = Properties.Settings.Default.pathofFuel.ToString();
                pathdocument.Text = Properties.Settings.Default.pathofDocument.ToString();


                txt1servername.Text = Properties.Settings.Default.ServerName1;
                cmb1serverip.Text = Properties.Settings.Default.ServerIp1;
                cmb1database.Text = Properties.Settings.Default.DBName1;
                txt1username.Text = Properties.Settings.Default.DBuserName1;
                txt1password.Text = Properties.Settings.Default.DBpassword1;
                txt1Archive.Text = Properties.Settings.Default.Archieves1;
                txt1EmployeeArchive.Text = Properties.Settings.Default.EmployeeArchieves1;

                txt2servername.Text = Properties.Settings.Default.ServerName2;
                cmb2serverip.Text = Properties.Settings.Default.ServerIp2;
                cmb2database.Text = Properties.Settings.Default.DBName2;
                txt2username.Text = Properties.Settings.Default.DBuserName2;
                txt2password.Text = Properties.Settings.Default.DBpassword2;
                txt2Archive.Text = Properties.Settings.Default.Archieves2;
                txt2EmployeeArchive.Text = Properties.Settings.Default.EmployeeArchieves2;

                txt3servername.Text = Properties.Settings.Default.ServerName3;
                cmb3serverip.Text = Properties.Settings.Default.ServerIp3;
                cmb3database.Text = Properties.Settings.Default.DBName3;
                txt3username.Text = Properties.Settings.Default.DBuserName3;
                txt3password.Text = Properties.Settings.Default.DBpassword3;
                txt3Archive.Text = Properties.Settings.Default.Archieves3;
                txt3EmployeeArchive.Text = Properties.Settings.Default.EmployeeArchieves3;

                txt1EmpDoc.Text = Properties.Settings.Default.EmpDoc1;
                txt2EmpDoc.Text = Properties.Settings.Default.EmpDoc2;
                txt3EmpDoc.Text = Properties.Settings.Default.EmpDoc3;

            }
            catch (Exception)
            {

                throw;
            }
            
           
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void FRM_SETTING_Load(object sender, EventArgs e)
        {

            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                string d = servers.Rows[i]["ServerName"].ToString();
                string ip = Dns.GetHostByName(d).AddressList[0].ToString();
                cboserverIp.Items.Add(ip);
                cmb1serverip.Items.Add(ip);
                cmb2serverip.Items.Add(ip);
                cmb3serverip.Items.Add(ip);
            }
        }
            

        private void btnsavesetting_Click(object sender, EventArgs e)
        {
           
            Properties.Settings.Default.ServerName = txtServerName.Text;
            Properties.Settings.Default.ServerIp= cboserverIp.Text.ToString();
            Properties.Settings.Default.DBName = cbodbname.Text;
            Properties.Settings.Default.DBuserName = tbusername.Text;
            Properties.Settings.Default.DBpassword = tbpassword.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ");
        }

        private void btnclearsetting_Click(object sender, EventArgs e)
        {
            txtServerName.Text = null;
            cboserverIp.Text = "";
            cbodbname.Text = "";
            tbusername.Clear();
            tbpassword.Clear();

        }

        private void cboservername_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnloadserver_Click(object sender, EventArgs e)
        {
            lbtxt.Items.Clear();

            SqlConnection sqlcon = new SqlConnection(@"Data Source=" + tbtxt2.Text + ";initial Catalog=master; persist Security info=True; user id="+ Properties.Settings.Default.DBuserName.ToString()+";password="+ Properties.Settings.Default.DBpassword.ToString()+"");
           sqlcon.Open();
           SqlCommand cmd = new SqlCommand("select Name from sys.databases", sqlcon);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                lbtxt.Items.Add(Dr[0].ToString());

            }
            sqlcon.Close();
           
        }

        private void btncreatedb_Click(object sender, EventArgs e)
        {
            string connectionstring ="Server="+ Properties.Settings.Default.ServerIp.ToString() +";Integrated security=SSPI;database="+ tbtxt.Text +"";
            var connectionString = new SqlConnectionStringBuilder(connectionstring);
            var serverConnection = new ServerConnection(Properties.Settings.Default.ServerIp.ToString());
            var serverInstance = new Server(serverConnection);
            if (serverInstance.Databases.Contains(connectionString.InitialCatalog))
                serverInstance.KillDatabase(connectionString.InitialCatalog);

            var db = new Database(serverInstance, connectionString.InitialCatalog);

            try
            {
                db.Create();
                MessageBox.Show("تم انشاء قاعدة البيانات بنجاح", "Databases", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                throw;
            }

            

            
        }

        private void lbtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbtxt.Text = lbtxt.SelectedItem.ToString();

        }

        private void btndeletedb_Click(object sender, EventArgs e)
        {
            string connectionstring = "Server=" + Properties.Settings.Default.ServerIp.ToString() + ";Integrated security=SSPI;database=" + tbtxt.Text + "";
            var connectionString = new SqlConnectionStringBuilder(connectionstring);
            var serverConnection = new ServerConnection(Properties.Settings.Default.ServerIp.ToString());
            var serverInstance = new Server(serverConnection);
            if (serverInstance.Databases.Contains(connectionString.InitialCatalog))
                serverInstance.KillDatabase(connectionString.InitialCatalog);

            MessageBox.Show("تم مسح قاعدة البيانات بنجاح", "Databases", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnexecute_Click(object sender, EventArgs e)
        {
             string connectionString;
           
             connectionString = "Data Source=" + Properties.Settings.Default.ServerIp.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName.ToString() + ";password=" + Properties.Settings.Default.DBpassword.ToString() + "";
             using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    Server db = new Server(new ServerConnection(conn));
                    string script = File.ReadAllText(tbscript.Text);

                    string[] commands = script.Split(
                    new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string c in commands)
                    {
                        conn.Open();

                        SqlCommand sqlcmd = new SqlCommand(c, conn);
                        sqlcmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    MessageBox.Show("تمت عملية انشاء محتويات قاعدة البيانات بنجاح", "انشاء المحتوى", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            
            



        }

        private void btnloadscript_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbscript.Text = ofd.FileName;
                
            }
        }

        private void btnloadscript2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tbscripts2.Text = ofd.FileName;
            }
        }

        private void btnexcutescript2_Click(object sender, EventArgs e)
        {
            string connectionString;

            connectionString = "Data Source=" + Properties.Settings.Default.ServerIp.ToString() + ";initial Catalog=" + Properties.Settings.Default.DBName.ToString() + "; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName.ToString() + ";password=" + Properties.Settings.Default.DBpassword.ToString() + "";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                Server db = new Server(new ServerConnection(conn));
                string script = File.ReadAllText(tbscripts2.Text);

                string[] commands = script.Split(
                 new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string c in commands)
                {
                    conn.Open();

                    SqlCommand sqlcmd = new SqlCommand(c, conn);
                    sqlcmd.ExecuteNonQuery();
                    conn.Close();
                }

                MessageBox.Show("تمت تحديث محتويات قاعدة البيانات بنجاح", "تحديث المحتوى", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void cbodbname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            listDatabases.Items.Clear();

            SqlConnection sqlcon = new SqlConnection(@"Data Source=" + cboserverIp.Text + ";initial Catalog=master; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName.ToString() + ";password=" + Properties.Settings.Default.DBpassword.ToString() + "");
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("select Name from sys.databases", sqlcon);
            SqlDataReader Dr = cmd.ExecuteReader();
            while (Dr.Read())
            {
                listDatabases.Items.Add(Dr[0].ToString());

            }
            sqlcon.Close();
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbodbname.Text = listDatabases.SelectedItem.ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog()==DialogResult.OK)
            {
                PathofArchieve.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void pathtow_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                PathofEmployees.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void paththree_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Pathofcars.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void btnSavePathes_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PathOfArchieves = PathofArchieve.Text;
            Properties.Settings.Default.PathOfEmployees = PathofEmployees.Text;
            Properties.Settings.Default.PathOfCars = Pathofcars.Text;
            Properties.Settings.Default.pathofFuel = pathofFuel.Text;
            Properties.Settings.Default.pathofDocument = pathdocument.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ");
        }

        private void pathfour_Click(object sender, EventArgs e)
        {

        }

        private void pathfive_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                pathofFuel.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCDloaddatabase_Click(object sender, EventArgs e)
        {
            try
            {
                lsb1database.Items.Clear();

                SqlConnection sqlcon = new SqlConnection(@"Data Source=" + cmb1serverip.Text + ";initial Catalog=master; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName1.ToString() + ";password=" + Properties.Settings.Default.DBpassword1.ToString() + "");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("select Name from sys.databases", sqlcon);
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    lsb1database.Items.Add(Dr[0].ToString());

                }
                sqlcon.Close();
            }catch (Exception ee) { MessageBox.Show(ee.ToString()); }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void cmbCDservername_Click(object sender, EventArgs e)
        {
            
        }

        private void pathdoc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                pathdocument.Text = Path.GetFullPath(fbd.SelectedPath);
            }
        }

        private void btnCDsavesetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName1 = txt1servername.Text;
            Properties.Settings.Default.ServerIp1 = cmb1serverip.Text;
            Properties.Settings.Default.DBName1 = cmb1database.Text;
            Properties.Settings.Default.DBuserName1 = txt1username.Text;
            Properties.Settings.Default.DBpassword1 = txt1password.Text;
            Properties.Settings.Default.Archieves1 = txt1Archive.Text;
            Properties.Settings.Default.EmployeeArchieves1 = txt1EmployeeArchive.Text;
            Properties.Settings.Default.EmpDoc1 = txt1EmpDoc.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ");
        }

        private void btnGDsavesetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName2 = txt2servername.Text;
            Properties.Settings.Default.ServerIp2 = cmb2serverip.Text;
            Properties.Settings.Default.DBName2 = cmb2database.Text;
            Properties.Settings.Default.DBuserName2 = txt2username.Text;
            Properties.Settings.Default.DBpassword2 = txt2password.Text;
            Properties.Settings.Default.Archieves2 = txt2Archive.Text;
            Properties.Settings.Default.EmployeeArchieves2 = txt2EmployeeArchive.Text;
            Properties.Settings.Default.EmpDoc2 = txt2EmpDoc.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ");
        }

        private void btnTDsavesetting_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ServerName3 = txt3servername.Text;
            Properties.Settings.Default.ServerIp3 = cmb3serverip.Text;
            Properties.Settings.Default.DBName3 = cmb3database.Text;
            Properties.Settings.Default.DBuserName3 = txt3username.Text;
            Properties.Settings.Default.DBpassword3 = txt3password.Text;
            Properties.Settings.Default.Archieves3 = txt3Archive.Text;
            Properties.Settings.Default.EmployeeArchieves3 = txt3EmployeeArchive.Text;
            Properties.Settings.Default.EmpDoc3 = txt3EmpDoc.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("تم الحفظ");
        }

        private void btnCDcancelsetting_Click(object sender, EventArgs e)
        {
            txt1servername.Text = null;
            cmb1serverip.Text = null;
            cmb1database.Text = null;
            txt1username.Text = null;
            txt1password.Text = null;
            txt1Archive.Text = null;
            txt1EmployeeArchive.Text = null;
        }

        private void btnGDcancelsetting_Click(object sender, EventArgs e)
        {
            txt2servername.Text = null;
            cmb2serverip.Text = null;
            cmb2database.Text = null;
            txt2username.Text = null;
            txt2password.Text = null;
            txt2Archive.Text = null;
            txt2EmployeeArchive.Text = null;
        }

        private void btnTDcancelsetting_Click(object sender, EventArgs e)
        {
            txt3servername.Text = null;
            cmb3serverip.Text = null;
            cmb3database.Text = null;
            txt3username.Text = null;
            txt3password.Text = null;
            txt3Archive.Text = null;
            txt3EmployeeArchive.Text = null;
        }

        private void lsbCDdatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb1database.Text = lsb1database.SelectedItem.ToString();
        }

        private void lsbGDdatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb2database.Text = lsb2database.SelectedItem.ToString();
        }

        private void lsbTDdatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb3database.Text = lsb3database.SelectedItem.ToString();
        }

        private void btnGDloaddatabase_Click(object sender, EventArgs e)
        {
            try
            {
                lsb2database.Items.Clear();
                //MessageBox.Show(cmb2serverip.Text+" "+ Properties.Settings.Default.DBName2.ToString()+" "+ Properties.Settings.Default.DBpassword2.ToString());
                SqlConnection sqlcon = new SqlConnection(@"Data Source=" + cmb2serverip.Text + ";initial Catalog=master; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName2.ToString() + ";password=" + Properties.Settings.Default.DBpassword2.ToString() + "");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("select Name from sys.databases", sqlcon);
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    lsb2database.Items.Add(Dr[0].ToString());

                }
                sqlcon.Close();
            }catch(Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }

        private void btnTDloaddatabase_Click(object sender, EventArgs e)
        {
            try
            {
                lsb3database.Items.Clear();

                SqlConnection sqlcon = new SqlConnection(@"Data Source=" + cmb3serverip.Text + ";initial Catalog=master; persist Security info=True; user id=" + Properties.Settings.Default.DBuserName3.ToString() + ";password=" + Properties.Settings.Default.DBpassword3.ToString() + "");
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("select Name from sys.databases", sqlcon);
                SqlDataReader Dr = cmd.ExecuteReader();
                while (Dr.Read())
                {
                    lsb3database.Items.Add(Dr[0].ToString());

                }
                sqlcon.Close();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }
}

            