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
    public partial class FRMFUELPRICE : DevExpress.XtraEditors.XtraForm
    {
        int id;
        public FRMFUELPRICE(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FRMFUELPRICE_Load(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_FUEL price = new CLS_FRMS.CLS_FUEL();
                DataTable dt= price.GetDataPrice(id);
                txtPrice.Text = dt.Rows[0][2].ToString();
                txtPercentageAdd.Text = dt.Rows[0][3].ToString();
                txtpricetrans.Text = dt.Rows[0][4].ToString();
                txtpricetransinvest.Text = dt.Rows[0][5].ToString();
            }
            catch(Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void btnPrintExitBill_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_FUEL price = new CLS_FRMS.CLS_FUEL();
                price.UpdatePrice(id, double.Parse(txtPrice.Text), double.Parse(txtPercentageAdd.Text), double.Parse(txtpricetrans.Text), double.Parse(txtpricetransinvest.Text), Properties.Settings.Default.UserNameLogin.ToString(), DateTime.Now.ToString("HH:MM tt"), DateTime.Now.ToString("yyyy/MM/dd"));
                this.Close();
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}