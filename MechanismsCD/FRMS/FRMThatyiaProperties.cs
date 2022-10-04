using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
namespace MechanismsCD.FRMS
{
    public partial class FRMThatyiaProperties : DevExpress.XtraEditors.XtraForm
    {
        public FRMThatyiaProperties()
        {
            InitializeComponent();
        }

        private void FRMThatyiaProperties_Load(object sender, EventArgs e)
        {
            CLS_FRMS.WorkingProperties GettingData = new CLS_FRMS.WorkingProperties();
            DataTable Dt = GettingData.ThatyiaPropertiesSelecting();
            for(int i=0;i<Dt.Rows.Count;i++)
            {
                TrProperties.Nodes.Add( "NodeName",Dt.Rows[i][2].ToString(),0,0);
            }
        }

        private void TrProperties_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CLS_FRMS.WorkingProperties Getdata = new CLS_FRMS.WorkingProperties();
            
            DataTable Dt = Getdata.ThatyiaPropertiesSelectingByGuid(TrProperties.SelectedNode.Text, Lst,tbindexofvalue,tbidproperties,tbguidname );

        }

     

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for(int i=0;i<Lst.Items.Count;i++)
            {
                Lst.Items[i].CheckState = CheckState.Unchecked;
            }
        }

        private void btnsavebar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            bool[] b = new bool[Lst.Items.Count];
            
            for (int i = 0; i < Lst.Items.Count; i++)
            {
                if (Lst.Items[i].CheckState == CheckState.Checked)
                {
                    b[i] = true;
                }
                else if(Lst.Items[i].CheckState==CheckState.Unchecked)
                {
                    b[i] = false;
                }
            }
            CLS_FRMS.WorkingProperties UpdateData = new CLS_FRMS.WorkingProperties();
            UpdateData.ThatyiaPropertiesUpdatting(int.Parse(tbindexofvalue.Text), tbguidname.Text, b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7], b[8], b[9],
                b[10], b[11], b[12], b[13], b[14], b[15], b[16], b[17], b[18], b[19], int.Parse(tbidproperties.Text));
            MessageBox.Show("تم الحفظ بنجاح", "حفظ", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void btnSelectAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for(int i=0;i<Lst.Items.Count;i++)
            {
                Lst.Items[i].CheckState = CheckState.Checked;
            }
        }
    }
}
