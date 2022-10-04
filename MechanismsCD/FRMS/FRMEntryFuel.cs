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
using DevExpress.Utils.Drawing;
using System.Diagnostics;
using System.IO;
using TwainLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MechanismsCD.FRMS
{
    public partial class FRMEntryFuel : DevExpress.XtraEditors.XtraForm
    {
        public string newpath;
        public string pathimage;
        public string nameimage;
        string Name;
        DataTable dt;
        DataTable dt1;
        CurrencyManager cm;
        public FRMEntryFuel(string Name)
        {
            InitializeComponent();
            this.Name = Name;           
        }


        private void FRMEntryFuel_Load(object sender, EventArgs e)
        {
            try
            {
                lbtitle.Text = Name;
                CLS_FRMS.CLS_FUEL store = new CLS_FRMS.CLS_FUEL();
               
                if (Name == "ادخال وقود")
                {
                    tabExitFuel.PageVisible = false;
                    tabStores.PageVisible = false;                    
                    store.StoreInfo(cmbStoreName);
                    store.caarInfo(cmbcarno,cmbCarType);
                    dt1 = null;
                    dt1= store.showFuelEntrayData(DgvFuelEntry, txtID, txtBillNo, DateBill, cmbFuelType, cmbStoreName, txtQuantity,
                       cmbcarno, cmbCarType, txtRegisterName, txtRegisterTime, txtRegisterDate);                    
                    store.ShowStores(StoresLayout,Name);
                    cm = (CurrencyManager)this.BindingContext[dt1];
                    if (txtID.Text != null && txtID.Text != "")
                    {
                      CLS_FRMS.CLS_FUEL Getarchive = new CLS_FRMS.CLS_FUEL();
                      DataTable Dt = Getarchive.selectFuelArchive(int.Parse(txtID.Text), txtArchiveID, txtImagePath, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate, lsv);
                    }

                  //  btnNew_Click_1(sender,e);
                }
                else if (Name == "اخراج وقود")
                {
                    tabEntrayScanner.PageVisible = false;
                    tabEntryFuel.PageVisible = false;
                    tabStores.PageVisible = false;
                    store.caarInfo(cmbExitCarNO,cmbExitCarType);
                    store.BeneficiaryInfo(cmbExitTheBeneficiary);
                    store.StoreInfo(cmbExitStoreName);
                    dt1 = null;
                    dt1= store.showFuelExitData(DgvExitFuel, txtExitID, txtBillExitNo, dteExitBill, cmbExitCarNO, cmbExitCarType, txtExitQuantity,
                        txtDriveName, cmbExitTheBeneficiary,DeptInvest, cmbExitStoreName, txtExitRegisterName, txtExitRegisterTime, txtExitRegisterDate,txtprice,txttotalprice);                    
                   
                    store.ShowStores(StoresExitLayout,Name);
                    dt = store.GetDataPrice(int.Parse(cmbExitStoreName.SelectedValue.ToString()));
                    cm = (CurrencyManager)this.BindingContext[dt1];
                  //  btnExitNew.PerformClick();
                }
                else if (Name == "مخازن الوقود")
                {
                    tabEntrayScanner.PageVisible = false;
                    tabEntryFuel.PageVisible = false;
                    tabExitFuel.PageVisible = false;
                    DataTable dt = store.SelectStores();
                    cmbExitStoreName.DataSource = dt;
                    store.ShowStores(StorestableLayoutPanel5,Name);                  
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (DgvFuelEntry.DataSource as DataTable).DefaultView.RowFilter = string.Format("[BillNo] like '%{0}%'", txtSearch.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
   

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void txtBillNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (user_Num1.Enabled == false)
                    user_Num1.Enabled = true;
                user_Num1.text(txtBillNo);
               
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void txtQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                if (user_Num1.Enabled == false)
                    user_Num1.Enabled = true;
                user_Num1.text(txtQuantity);
                
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void txtCarNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (user_Num1.Enabled == false)
                    user_Num1.Enabled = true;
                user_Num1.cmb(cmbcarno);              
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void btnExitNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtExitID.DataBindings.Clear();
                txtBillExitNo.DataBindings.Clear();
                dteExitBill.DataBindings.Clear();
                cmbExitCarNO.DataBindings.Clear();
                cmbExitCarType.DataBindings.Clear();
                txtExitQuantity.DataBindings.Clear();
                txtDriveName.DataBindings.Clear();
                cmbExitTheBeneficiary.DataBindings.Clear();
                txtExitRegisterName.DataBindings.Clear();
                txtExitRegisterTime.DataBindings.Clear();
                txtExitRegisterDate.DataBindings.Clear();

                txtExitID.Text = null;
                txtBillExitNo.Text = null;
                txtExitQuantity.Text = null;
                cmbExitCarNO.Text = "";
                cmbExitCarType.Text = "";
                cmbExitTheBeneficiary.Text = "";
                txtDriveName.Text = null;
              

                txtExitRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();
                txtExitRegisterTime.Text = DateTime.Now.ToString("hh:mm tt");
                txtExitRegisterDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

                DataTable dtfuel = (DataTable)DgvExitFuel.DataSource;
                if (dtfuel.Rows.Count > 0)
                {
                    int billno = Convert.ToInt32(dtfuel.Rows[(dtfuel.Rows.Count) - 1][1]);
                    txtBillExitNo.Text = (billno + 1).ToString();
                }
                else
                    txtBillExitNo.Text = "1";
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

       

        private void btnExitDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل تريد تأكيد الحذف؟", "تأكيد", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CLS_FRMS.CLS_FUEL DeleteDataFuel = new CLS_FRMS.CLS_FUEL();
                    DeleteDataFuel.DeleteFuelExit(int.Parse(txtExitID.Text), int.Parse(cmbExitStoreName.SelectedValue.ToString()), cmbExitStoreName.Text, Convert.ToDouble(txtExitQuantity.Text));
                    dt1 = null;
                    dt1= DeleteDataFuel.showFuelExitData(DgvExitFuel, txtExitID, txtBillExitNo, dteExitBill, cmbExitCarNO, cmbExitCarType, txtExitQuantity,
                           txtDriveName, cmbExitTheBeneficiary, DeptInvest, cmbExitStoreName, txtExitRegisterName, txtExitRegisterTime, txtExitRegisterDate,txtprice,txttotalprice);
                    cm = (CurrencyManager)this.BindingContext[dt1];
                    DeleteDataFuel.ShowStores(StoresExitLayout,Name);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnExitAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                CLS_FRMS.CLS_FUEL AddDataFuel = new CLS_FRMS.CLS_FUEL();
                AddDataFuel.InsertFuelExit(int.Parse(cmbExitStoreName.SelectedValue.ToString()), txtBillExitNo.Text,
                    dteExitBill.Value, cmbExitCarNO.Text, cmbExitCarType.Text, double.Parse(txtExitQuantity.Text),
                    txtDriveName.Text, cmbExitTheBeneficiary.Text, cmbExitStoreName.Text, txtExitRegisterName.Text,
                    txtExitRegisterTime.Text, txtExitRegisterDate.Text,DeptInvest.Checked,double.Parse(txtprice.Text),double.Parse(txttotalprice.Text));
                dt1 = null;
                dt1= AddDataFuel.showFuelExitData(DgvExitFuel, txtExitID, txtBillExitNo, dteExitBill, cmbExitCarNO, cmbExitCarType, txtExitQuantity,
                      txtDriveName, cmbExitTheBeneficiary,DeptInvest, cmbExitStoreName, txtExitRegisterName, txtExitRegisterTime, txtExitRegisterDate,txtprice,txttotalprice);
                cm = (CurrencyManager)this.BindingContext[dt1];
                AddDataFuel.ShowStores(StoresExitLayout,Name);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnExitEdit_Click_1(object sender, EventArgs e)
        {
             try
            {
                double Quantity = Convert.ToDouble(txtExitQuantity.Text) - Convert.ToDouble(DgvExitFuel.SelectedRows[0].Cells[5].Value);
                Quantity *= -1;
                CLS_FRMS.CLS_FUEL UpdateDataFuel = new CLS_FRMS.CLS_FUEL();
                UpdateDataFuel.UpdateFuelExit(int.Parse(cmbExitStoreName.SelectedValue.ToString()), int.Parse(txtExitID.Text), txtBillExitNo.Text, dteExitBill.Value, cmbExitCarNO.Text, cmbExitCarType.Text, double.Parse(txtExitQuantity.Text),
                    txtDriveName.Text, cmbExitTheBeneficiary.Text, cmbExitStoreName.Text, txtExitRegisterName.Text, txtExitRegisterTime.Text, txtExitRegisterDate.Text, Quantity,DeptInvest.Checked, double.Parse(txtprice.Text), double.Parse(txttotalprice.Text));
                dt1 = null;
                dt1= UpdateDataFuel.showFuelExitData(DgvExitFuel, txtExitID, txtBillExitNo, dteExitBill, cmbExitCarNO, cmbExitCarType, txtExitQuantity,
                   txtDriveName, cmbExitTheBeneficiary,DeptInvest, cmbExitStoreName, txtExitRegisterName, txtExitRegisterTime, txtExitRegisterDate,txtprice,txttotalprice);
                cm = (CurrencyManager)this.BindingContext[dt1];
                UpdateDataFuel.ShowStores(StoresExitLayout,Name);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtBillExitNo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (user_Num2.Enabled == false)
                    user_Num2.Enabled = true;
                user_Num2.text(txtBillExitNo);

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

     
        private void txtExitQuantity_Enter(object sender, EventArgs e)
        {
            try
            {
                if (user_Num2.Enabled == false)
                    user_Num2.Enabled = true;
                user_Num2.text(txtExitQuantity);

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                txtID.DataBindings.Clear();
                txtBillNo.DataBindings.Clear();
                cmbFuelType.DataBindings.Clear();
                txtQuantity.DataBindings.Clear();
                cmbcarno.DataBindings.Clear();
                cmbCarType.DataBindings.Clear();
                txtRegisterName.DataBindings.Clear();
                txtRegisterTime.DataBindings.Clear();
                txtRegisterDate.DataBindings.Clear();
                cmbStoreName.DataBindings.Clear();
                DateBill.DataBindings.Clear();

                txtID.Text = null;
                txtBillNo.Text = null;
                txtQuantity.Text = null;
                cmbCarType.Text = "";
                cmbcarno.Text = "";

                txtRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();
                txtRegisterTime.Text = DateTime.Now.ToString("hh:mm tt");
                txtRegisterDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_FUEL AddDataFuel = new CLS_FRMS.CLS_FUEL();
                AddDataFuel.InsertFuelEntry(int.Parse(cmbStoreName.SelectedValue.ToString()), txtBillNo.Text, DateBill.Value,
                    cmbFuelType.SelectedItem.ToString(), cmbStoreName.Text, double.Parse(txtQuantity.Text), cmbcarno.Text,
                    cmbCarType.Text, txtRegisterName.Text, txtRegisterTime.Text, txtRegisterDate.Text);
                dt1 = null;
                dt1= AddDataFuel.showFuelEntrayData(DgvFuelEntry, txtID, txtBillNo, DateBill, cmbFuelType, cmbStoreName, txtQuantity,
                      cmbcarno, cmbCarType, txtRegisterName, txtRegisterTime, txtRegisterDate);
                cm = (CurrencyManager)this.BindingContext[dt1];
                CLS_FRMS.CLS_FUEL store = new CLS_FRMS.CLS_FUEL();
                DataTable dt = store.SelectStores();
                AddDataFuel.ShowStores(StoresLayout,Name);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                double Quantity = Convert.ToDouble(txtQuantity.Text) - Convert.ToDouble(DgvFuelEntry.SelectedRows[0].Cells[5].Value);
                CLS_FRMS.CLS_FUEL UpdateDataFuel = new CLS_FRMS.CLS_FUEL();
                UpdateDataFuel.UpdateFuelEntray(int.Parse(cmbStoreName.SelectedValue.ToString()), int.Parse(txtID.Text), txtBillNo.Text, DateBill.Value, cmbFuelType.SelectedItem.ToString(), cmbStoreName.Text,
                  double.Parse(txtQuantity.Text), cmbcarno.Text, cmbCarType.Text, txtRegisterName.Text, txtRegisterTime.Text, txtRegisterDate.Text, Quantity);
                dt1 = null;
                dt1= UpdateDataFuel.showFuelEntrayData(DgvFuelEntry, txtID, txtBillNo, DateBill, cmbFuelType, cmbStoreName, txtQuantity,
                  cmbcarno, cmbCarType, txtRegisterName, txtRegisterTime, txtRegisterDate);
                cm = (CurrencyManager)this.BindingContext[dt1];
                UpdateDataFuel.ShowStores(StoresLayout,Name);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل تريد تأكيد الحذف؟", "تأكيد", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    CLS_FRMS.CLS_FUEL DeleteDataFuel = new CLS_FRMS.CLS_FUEL();
                    DeleteDataFuel.DeleteFuelEntry(int.Parse(txtID.Text), int.Parse(cmbStoreName.SelectedValue.ToString()), cmbStoreName.Text, double.Parse(txtQuantity.Text));
                    dt1 = null;
                    dt1= DeleteDataFuel.showFuelEntrayData(DgvFuelEntry, txtID, txtBillNo, DateBill, cmbFuelType, cmbStoreName, txtQuantity,
                          cmbcarno, cmbCarType, txtRegisterName, txtRegisterTime, txtRegisterDate);
                    cm = (CurrencyManager)this.BindingContext[dt1];
                    DeleteDataFuel.ShowStores(StoresLayout,Name);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void txtExitSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (DgvExitFuel.DataSource as DataTable).DefaultView.RowFilter = string.Format("[BillNo] like '%{0}%'", txtExitSearch.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void DgvFuelEntry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbStoreName.SelectedIndex = cmbStoreName.FindStringExact(DgvFuelEntry.SelectedRows[0].Cells[4].Value.ToString());  
        }

        private void DgvExitFuel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbExitStoreName.SelectedIndex = cmbExitStoreName.FindStringExact(DgvExitFuel.SelectedRows[0].Cells[8].Value.ToString());
        }

        private void circleButtons1_Click(object sender, EventArgs e)
        {
            keyboard f = new keyboard(txtDriveName,null);
            f.ShowDialog();
        }

     

        private void cmbcarno_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCarType.Text = cmbcarno.SelectedValue.ToString();
        }

        private void cmbcarno_Click(object sender, EventArgs e)
        {
            try
            {
                if (user_Num1.Enabled == false)
                    user_Num1.Enabled = true;
                user_Num1.cmb(cmbcarno);

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void cmbExitCarNO_Click(object sender, EventArgs e)
        {
            try
            {
                if (user_Num2.Enabled == false)
                    user_Num2.Enabled = true;
                user_Num2.cmb(cmbExitCarNO);

            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void cmbExitCarNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbExitCarType.Text = cmbExitCarNO.SelectedValue.ToString();
        }

        private void DgvFuelEntry_SelectionChanged(object sender, EventArgs e)
        {
          
            if (txtID.Text != null && txtID.Text != "")
            {
                CLS_FRMS.CLS_FUEL Getarchive = new CLS_FRMS.CLS_FUEL();
                DataTable Dt = Getarchive.selectFuelArchive(int.Parse(txtID.Text),txtArchiveID, txtImagePath, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate, lsv);
            }
        }

        private void lsv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsv.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = lsv.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = lsv.Items[intselectedindex].Text;

                CLS_FRMS.CLS_FUEL GetData = new CLS_FRMS.CLS_FUEL();
                DataTable Dt = GetData.GetDataByListView(text, txtArchiveID, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate);
            }
        }

        private void lsv_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (lsv.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = lsv.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = lsv.Items[intselectedindex].Text;
                System.Diagnostics.Process.Start(text);
            }
        }

        private void مرفقاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var b = TwainOperations.ScanImages();
            foreach (var Itm in b)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.pathofFuel + nameimage;
                picsave.Load(Itm);
                picsave.Image.Save(newpath);
                txtImagePath.Text = newpath;
                lsv.Items.Add(txtImagePath.Text);

                txtArchiveAddingTime.Text = DateTime.Now.ToString("HH:MM tt");
                txtArchiveAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtArchiveRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();

                CLS_FRMS.CLS_FUEL archadding = new CLS_FRMS.CLS_FUEL();
                archadding.addArchiveFuel(int.Parse(txtID.Text), int.Parse(txtBillNo.Text), txtImagePath.Text,  txtArchiveRegisterName.Text, txtArchiveAddingTime.Text, txtArchiveAddingDate.Text);                    

            }
            CLS_FRMS.CLS_FUEL Getarchive = new CLS_FRMS.CLS_FUEL();
            DataTable Dt = Getarchive.selectFuelArchive(int.Parse(txtID.Text), txtArchiveID, txtImagePath, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate, lsv);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLS_FUEL archdelete = new CLS_FRMS.CLS_FUEL();
            archdelete.deleteArchiveFuel(int.Parse(txtArchiveID.Text));

            CLS_FRMS.CLS_FUEL Getarchive = new CLS_FRMS.CLS_FUEL();
            DataTable Dt = Getarchive.selectFuelArchive(int.Parse(txtID.Text), txtArchiveID, txtImagePath, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate, lsv);
        }

        private void حاسبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select an images|*.jpg;*.bmp;*.png;*.Docx;*.Xlsx;*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filetype= Path.GetExtension(ofd.FileName);
                if (filetype==".jpg" || filetype == ".png" || filetype == ".bmp")
                {
                    pathimage = ofd.FileName;
                    nameimage = System.IO.Path.GetFileName(pathimage);
                    newpath = Properties.Settings.Default.pathofFuel + nameimage;
                    picsave.Load(ofd.FileName);
                    picsave.Image.Save(newpath);
                    txtImagePath.Text = newpath;
                    lsv.Items.Add(txtImagePath.Text);                 
                }
                else if (filetype == ".Docx")
                {
                    //pathimage = ofd.FileName;
                    //nameimage = System.IO.Path.GetFileName(pathimage);
                    //newpath = Properties.Settings.Default.pathofFuel + nameimage;
                    //picsave.Load(ofd.FileName);
                    //picsave.Image.Save(newpath);
                    //txtImagePath.Text = newpath;
                    //lsv.Items.Add(txtImagePath.Text);
                }

                txtArchiveAddingTime.Text = DateTime.Now.ToString("HH:MM tt");
                txtArchiveAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                txtArchiveRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();

                CLS_FRMS.CLS_FUEL archadding = new CLS_FRMS.CLS_FUEL();
                archadding.addArchiveFuel(int.Parse(txtID.Text), int.Parse(txtBillNo.Text), txtImagePath.Text, txtArchiveRegisterName.Text, txtArchiveAddingTime.Text, txtArchiveAddingDate.Text);

                CLS_FRMS.CLS_FUEL Getarchive = new CLS_FRMS.CLS_FUEL();
                DataTable Dt = Getarchive.selectFuelArchive(int.Parse(txtID.Text), txtArchiveID, txtImagePath, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate, lsv);
            }
        }

        private void cmbExitTheBeneficiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbExitTheBeneficiary.SelectedValue.ToString() == "True")
                {
                    DeptInvest.Checked = true;
                }
                else
                {
                    DeptInvest.Checked = false;
                   
                }
            }
            catch (Exception ee) { }
        }

        private void circleButtons2_Click(object sender, EventArgs e)
        {

            keyboard f = new keyboard(null, cmbExitTheBeneficiary);
            f.ShowDialog();
        }

        private void DeptInvest_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tb = new System.Windows.Forms.ToolTip();
            tb.Show( "جهة استثمارية",DeptInvest);
        }

        private void txtExitQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtExitQuantity.Text != null && txtExitQuantity.Text != "")
                {
                    txtprice.Text = (double.Parse(txtExitQuantity.Text) * double.Parse(dt.Rows[0][2].ToString())).ToString();
                    if (DeptInvest.Checked == true)
                    {
                        double x = double.Parse(txtprice.Text) * (Convert.ToDouble(dt.Rows[0][3]) / 100);
                        txttotalprice.Text = (double.Parse(txtprice.Text) + x).ToString();
                        x = double.Parse(txtExitQuantity.Text) * int.Parse(dt.Rows[0][5].ToString());
                        txttotalprice.Text = (double.Parse(txttotalprice.Text) + x).ToString();
                    }
                    else
                        txttotalprice.Text = txtprice.Text;
                }

            }
            catch (Exception ee) { }
        }

        private void cmbExitStoreName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_FUEL price = new CLS_FRMS.CLS_FUEL();
                dt = price.GetDataPrice(int.Parse(cmbExitStoreName.SelectedValue.ToString()));
            }
            catch (Exception ee) { }
        }

       

        private void lsv_MouseMove(object sender, MouseEventArgs e)
        {            
            if (lsv.HitTest(e.X, e.Y).Item != null )
            {
                picload.Image = null;
                GC.Collect();
                picload.Image = Image.FromFile(lsv.HitTest(e.X, e.Y).Item.Text);
                picload.Visible = true;
                CLS_FRMS.CLS_FUEL GetData = new CLS_FRMS.CLS_FUEL();
                DataTable Dt = GetData.GetDataByListView(lsv.HitTest(e.X, e.Y).Item.Text, txtArchiveID, txtArchiveRegisterName, txtArchiveAddingTime, txtArchiveAddingDate);
            }
            else 
            {
                picload.Image = null;
                GC.Collect();
                picload.Visible = false;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            cm.Position -= 1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cm.Position += 1;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            cm.Position = dt1.Rows.Count;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            cm.Position -= 1;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            cm.Position += 1;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            cm.Position = dt1.Rows.Count;
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}