using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MechanismsCD.FRMS
{
    public partial class FRM_USERS_PERMISSIONS : DevExpress.XtraEditors.XtraForm
    {
        DataTable Dtmain;
        CurrencyManager cm;
        public FRM_USERS_PERMISSIONS()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pn_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRM_USERS_PERMISSIONS_Load(object sender, EventArgs e)
        {
            CLS_FRMS.CLS_UsersAndPermissions GetData = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = GetData.UsersGettingData(ID_users, UserName_users, Password_users,Permission_users
                ,RegisterName_users,AddingTime_users,AddingDate_users, Pn_1, Pn_2);
            Dtmain = null;
            Dtmain = Dt;
            cm = (CurrencyManager)this.BindingContext[Dtmain];

            CLS_FRMS.CLS_UsersAndPermissions GetData2 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt2 = GetData2.Users2Selection2(Control_1,Users2_ID,Users2_IDcon,Users2_Username,int.Parse(ID_users.Text),Users2_PassWord);

            if (Dt2.Rows.Count == 1) btnuserpermission.Enabled = false;
            else if(Dt2.Rows.Count==0) btnuserpermission.Enabled = true;



            //== Getting Data of Users3Table.....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable DtUsres3 = GetDatauser3.Users3Selecting2(Dgv, int.Parse(ID_users.Text));

            //== Getting Data of Users4Table....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser4 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dtuser4 = GetDatauser4.Users4Selection2(Control_3, int.Parse(ID_users.Text), ID_user4);

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CLS_FRMS.CLS_UsersAndPermissions InsertData = new CLS_FRMS.CLS_UsersAndPermissions();
            InsertData.UsersInserting(UserName_users.Text, Password_users.Text, Permission_users.Text
                , RegisterName_users.Text, AddingTime_users.Text, AddingDate_users.Text);

            MessageBox.Show("تمة عملة الاضافة");
            // Refresh Data
            DataTable Dt= InsertData.UsersGettingData(ID_users, UserName_users, Password_users, Permission_users
                , RegisterName_users, AddingTime_users, AddingDate_users, Pn_1, Pn_2);
            Dtmain = null;
            Dtmain = Dt;


            CLS_FRMS.CLS_UsersAndPermissions GetData2 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt2 = GetData2.Users2Selection2(Control_1, Users2_ID, Users2_IDcon, Users2_Username, int.Parse(ID_users.Text),Users2_PassWord);

            if (Dt2.Rows.Count == 1) btnuserpermission.Enabled = false;
            else if (Dt2.Rows.Count == 0) btnuserpermission.Enabled = true;


        }

        private void btnnew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Control item in tableLayoutPanel1.Controls)
            {
                if (item is TextBox || item is System.Windows.Forms.ComboBox)
                {
                    item.DataBindings.Clear();
                    item.Text = "";
                    
                }
             
            }
            RegisterName_users.Text = Properties.Settings.Default.UserNameLogin.ToString();
            AddingTime_users.Text = DateTime.Now.ToString("hh:mm tt");
            AddingDate_users.Text = DateTime.Now.ToString("yyyy/MM/dd");

        }

        private void btnuserpermission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool[] AddPer = new bool[Control_1.Items.Count];
            for (int i = 0; i < Control_1.Items.Count; i++)
            {
                if (Control_1.Items[i].CheckState == CheckState.Checked)
                {
                    AddPer[i] = true;
                }
                else if (Control_1.Items[i].CheckState == CheckState.Unchecked)
                {
                    AddPer[i] = false;
                }
            }
            Users2_IDcon.Text = ID_users.Text;

            CLS_FRMS.CLS_UsersAndPermissions AddPermissions = new CLS_FRMS.CLS_UsersAndPermissions();
            AddPermissions.Users2Inserting(int.Parse(Users2_IDcon.Text), UserName_users.Text, Password_users.Text, AddPer[0], AddPer[1]
                , AddPer[2], AddPer[3], AddPer[4], AddPer[5], AddPer[6], AddPer[7], AddPer[8], AddPer[9], AddPer[10], AddPer[11]
                , AddPer[12], AddPer[13], AddPer[14], AddPer[15], AddPer[16], AddPer[17], AddPer[18], AddPer[19], AddPer[20]
                , AddPer[21], AddPer[22], AddPer[23], AddPer[24], AddPer[32], AddPer[25], AddPer[26], AddPer[27], AddPer[28],
                 AddPer[29], AddPer[30], AddPer[31], AddPer[33], AddPer[34], AddPer[35]);

            CLS_FRMS.CLS_UsersAndPermissions GetData2 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt2 = GetData2.Users2Selection2(Control_1, Users2_ID, Users2_IDcon, Users2_Username, int.Parse(ID_users.Text),Users2_PassWord);

            if (Dt2.Rows.Count == 1) btnuserpermission.Enabled = false;
            else if (Dt2.Rows.Count == 0) btnuserpermission.Enabled = true;

            //== Add Data to Users3Table......
            CLS_FRMS.CLS_UsersAndPermissions InsertUsers3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dtfill = InsertUsers3.Frm_NameGettingData();
            for (int i = 0; i < Dtfill.Rows.Count; i++)
            {
                InsertUsers3.Users3InsertingData(int.Parse(ID_users.Text), UserName_users.Text,
                   Password_users.Text ,Dtfill.Rows[i][0].ToString(), false, false, false, false);
            }
            
            //== Getting Data of Users3Table.....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable DtUsres3 = GetDatauser3.Users3Selecting2(Dgv, int.Parse(ID_users.Text));


            //== Adding Data to user4Table .....

            bool[] AddPer2 = new bool[Control_3.Items.Count];
            for (int i = 0; i < Control_3.Items.Count; i++)
            {
                if (Control_3.Items[i].CheckState == CheckState.Checked)
                {
                    AddPer2[i] = true;
                }
                else if (Control_3.Items[i].CheckState == CheckState.Unchecked)
                {
                    AddPer2[i] = false;
                }
            }

            CLS_FRMS.CLS_UsersAndPermissions insertdatauser4 = new CLS_FRMS.CLS_UsersAndPermissions();
            insertdatauser4.Users4InsertingData(int.Parse(ID_users.Text), UserName_users.Text, AddPer2[0], AddPer2[1]
                , AddPer2[2], AddPer2[3], AddPer2[4], AddPer2[5],AddPer2[6], AddPer2[7], Password_users.Text);
            insertdatauser4.Users4Selection2(Control_3, int.Parse(ID_users.Text), ID_user4);

        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position += 1;
            CLS_FRMS.CLS_UsersAndPermissions GetData2 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt2 = GetData2.Users2Selection2(Control_1, Users2_ID, Users2_IDcon, Users2_Username, int.Parse(ID_users.Text),Users2_PassWord);

            if (Dt2.Rows.Count == 1) btnuserpermission.Enabled = false;
            else if (Dt2.Rows.Count == 0) btnuserpermission.Enabled = true;

            //== Getting Data of Users3Table.....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable DtUsres3 = GetDatauser3.Users3Selecting2(Dgv, int.Parse(ID_users.Text));

            //== Getting Data of Users4Table....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser4 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dtuser4 = GetDatauser4.Users4Selection2(Control_3, int.Parse(ID_users.Text), ID_user4);



        }

        private void btnPrevieus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cm.Position -= 1;
            CLS_FRMS.CLS_UsersAndPermissions GetData2 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt2 = GetData2.Users2Selection2(Control_1, Users2_ID, Users2_IDcon, Users2_Username, int.Parse(ID_users.Text),Users2_PassWord);

            if (Dt2.Rows.Count == 1) btnuserpermission.Enabled = false;
            else if (Dt2.Rows.Count == 0) btnuserpermission.Enabled = true;

            //== Getting Data of Users3Table.....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable DtUsres3 = GetDatauser3.Users3Selecting2(Dgv, int.Parse(ID_users.Text));

            //== Getting Data of Users4Table....
            CLS_FRMS.CLS_UsersAndPermissions GetDatauser4 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dtuser4 = GetDatauser4.Users4Selection2(Control_3, int.Parse(ID_users.Text),ID_user4);

        }

        private void btnuserpermissionsave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool[] AddPer = new bool[Control_1.Items.Count];
            for (int i = 0; i < Control_1.Items.Count; i++)
            {
                if (Control_1.Items[i].CheckState == CheckState.Checked)
                {
                    AddPer[i] = true;
                }
                else if (Control_1.Items[i].CheckState == CheckState.Unchecked)
                {
                    AddPer[i] = false;
                }
            }

            CLS_FRMS.CLS_UsersAndPermissions UpdatingData = new CLS_FRMS.CLS_UsersAndPermissions();
            UpdatingData.Users2Updating(int.Parse(Users2_IDcon.Text), Users2_Username.Text, AddPer[0], AddPer[1]
                , AddPer[2], AddPer[3], AddPer[4], AddPer[5], AddPer[6], AddPer[7], AddPer[8], AddPer[9], AddPer[10], AddPer[11]
                , AddPer[12], AddPer[13], AddPer[14], AddPer[15], AddPer[16], AddPer[17], AddPer[18], AddPer[19], AddPer[20]
                , AddPer[21], AddPer[22], AddPer[23], AddPer[24], AddPer[32], int.Parse(Users2_ID.Text), Password_users.Text, AddPer[25], AddPer[26], AddPer[27], AddPer[28],
                 AddPer[29], AddPer[30], AddPer[31], AddPer[33], AddPer[34], AddPer[35]);


            CLS_FRMS.CLS_UsersAndPermissions UpdateUsers3table = new CLS_FRMS.CLS_UsersAndPermissions();
          
                for (int i = 0; i < Dgv.Rows.Count; i++)
                {
            

                    UpdateUsers3table.Users3UpdatingData(int.Parse(Dgv.Rows[i].Cells[1].Value.ToString()), Dgv.Rows[i].Cells[2].Value.ToString(),
                    Dgv.Rows[i].Cells[3].Value.ToString(),Dgv.Rows[i].Cells[4].Value.ToString(), Convert.ToBoolean(Dgv.Rows[i].Cells[5].Value.ToString()),
                    Convert.ToBoolean(Dgv.Rows[i].Cells[6].Value.ToString()), Convert.ToBoolean(Dgv.Rows[i].Cells[7].Value.ToString())
                    , Convert.ToBoolean(Dgv.Rows[i].Cells[8].Value.ToString()));
                }

                //== Updating Data to user4Table .....

                bool[] AddPer2 = new bool[Control_3.Items.Count];
                for (int i = 0; i < Control_3.Items.Count; i++)
                {
                    if (Control_3.Items[i].CheckState == CheckState.Checked)
                    {
                        AddPer2[i] = true;
                    }
                    else if (Control_3.Items[i].CheckState == CheckState.Unchecked)
                    {
                        AddPer2[i] = false;
                    }
                }

            CLS_FRMS.CLS_UsersAndPermissions Updatinguser4 = new CLS_FRMS.CLS_UsersAndPermissions();
            Updatinguser4.Users4UpdatingData(int.Parse(ID_users.Text), UserName_users.Text, AddPer2[0], AddPer2[1]
                , AddPer2[2], AddPer2[3], AddPer2[4], AddPer2[5], AddPer2[6], AddPer2[7],int.Parse(ID_user4.Text),Password_users.Text);
            Updatinguser4.Users4Selection2(Control_3, int.Parse(ID_users.Text),ID_user4);





        }

        private void Control_3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < Control_1.Items.Count; i++)
            {
                Control_1.Items[i].CheckState = CheckState.Checked;
            }
            for (int i = 0; i < Control_3.Items.Count; i++)
            {
                Control_3.Items[i].CheckState = CheckState.Checked;
            }
        }

        private void btnDeSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < Control_1.Items.Count; i++)
            {
                Control_1.Items[i].CheckState = CheckState.Unchecked;
            }
            for (int i = 0; i < Control_3.Items.Count; i++)
            {
                Control_3.Items[i].CheckState = CheckState.Unchecked;
            }

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}