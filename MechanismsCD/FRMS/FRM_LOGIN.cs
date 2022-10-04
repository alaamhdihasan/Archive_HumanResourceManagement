using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanismsCD.FRMS
{
    public partial class FRM_LOGIN : Form
    {
        DataTable DtMain;
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLS_UsersAndPermissions Login = new CLS_FRMS.CLS_UsersAndPermissions();

            Properties.Settings.Default.UserNameLogin =Login.DeleteEndSpace(UserNametxt.Text);
            Properties.Settings.Default.PasswordLogin = Passwordtxt.Text;
            Properties.Settings.Default.Save();
            
            if(UserNametxt.Text=="alaa" && Passwordtxt.Text=="aala")
            {
                FRMS.FRM_SETTING frm = new FRM_SETTING();
                frm.Show();
                
            }
            else
            {
                //CLS_FRMS.CLS_UsersAndPermissions Login = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable Dt = Login.Login_Users(UserNametxt.Text, Passwordtxt.Text);
                DtMain = Dt;

                if (Dt.Rows.Count>0)
                {
                    FRMS.MAINFRM frm = new MAINFRM();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("هذا المستخدم او كلمة المرور خطأ يرجى التحقق مرة اخرى", "خطأ اسم المستخدم او كلمة المرور", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UserNametxt.Focus();
                }
            }

            

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FRM_LOGIN_Load(object sender, EventArgs e)
        {
            UserNametxt.Focus();
        }
    }
}
