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
    public partial class FRMSynchornization : DevExpress.XtraEditors.XtraForm
    {
        public FRMSynchornization()
        {
            InitializeComponent();
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRMSynchornization_Load(object sender, EventArgs e)
        {
            try
            {
                lblUserName.Text = Properties.Settings.Default.UserNameLogin;

                cbxTo.Items.Clear();
                cbxTo.Items.Add(Properties.Settings.Default.ServerName.ToString());
                cbxTo.Items.Add(Properties.Settings.Default.ServerName1.ToString());
                cbxTo.Items.Add(Properties.Settings.Default.ServerName2.ToString());
                cbxTo.Items.Add(Properties.Settings.Default.ServerName3.ToString());

                cbxFrom.Items.Clear();
                cbxFrom.Items.Add(Properties.Settings.Default.ServerName.ToString());
                cbxFrom.Items.Add(Properties.Settings.Default.ServerName1.ToString());
                cbxFrom.Items.Add(Properties.Settings.Default.ServerName2.ToString());
                cbxFrom.Items.Add(Properties.Settings.Default.ServerName3.ToString());

                if(Properties.Settings.Default.ServerName.ToString()!="الشعبة الادارية والمالية")
                {
                    cbxSyncType.Items.Add("حذف بيانات المنتسبين المنقولين");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnexitapp_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
          
            CLS_FRMS.CLS_Synchornization sync = new CLS_FRMS.CLS_Synchornization();
            switch (cbxSyncType.Text)
            {
                case "مزامنة بيانات المنتسبين":
                    sync.EmpDocSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "تحديث بيانات المنتسبين":
                    sync.EmpDocUpdate(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة المتغيرات":
                    sync.EmpVariableSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة المستحقات الاعتيادية":
                    sync.EmpDeserveSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة المستحقات الطارئة":
                    sync.EmpDeservePressingSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة المستحقات المرضية":
                    sync.EmpDeserveSatisfyingSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة الاوامر الادارية":
                    sync.EmpAdminOrderSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة العقود":
                    sync.EmpConsSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة زمنيات":
                    sync.EmpZamaniatSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة الايفادات":
                    sync.EmpDispatchesSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة بيانات الاولاد":
                    sync.EmpChildSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة الاستضافة و التنسيب":
                    sync.EmpTanseebSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "مزامنة ارشيف الاضبارة":
                    sync.EmpArchieveSync(cbxFrom.Text, cbxTo.Text, Dgv);
                    break;
                case "حذف بيانات المنتسبين المنقولين":
                    sync.EmpDeleteSync(cbxTo.Text, Dgv);
                    break;
                   
            }
        }

        private void cbxSyncType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.ServerName != "الشعبة الادارية والمالية")
            if (cbxSyncType.Text == "مزامنة بيانات المنتسبين" || cbxSyncType.Text == "مزامنة الاوامر الادارية" ||
               cbxSyncType.Text == "مزامنة العقود" || cbxSyncType.Text == "مزامنة بيانات الاولاد" ||
               cbxSyncType.Text == "مزامنة الاستضافة و التنسيب" || cbxSyncType.Text == "مزامنة ارشيف الاضبارة" || cbxSyncType.Text== "حذف بيانات المنتسبين المنقولين")
            {
                cbxTo.Text = Properties.Settings.Default.ServerName;
                cbxTo.Enabled = false;
            }
            else
            {
                cbxTo.Text = null;
                cbxTo.Enabled = true;
            }
        }

       
    }
}