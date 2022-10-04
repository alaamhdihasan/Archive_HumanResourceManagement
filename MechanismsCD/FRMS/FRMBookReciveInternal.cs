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
using System.Diagnostics;

namespace MechanismsCD.FRMS
{
    public partial class FRMBookReciveInternal : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt;
        CurrencyManager cm;
        string div;
        string num;
        public FRMBookReciveInternal()
        {
            InitializeComponent();
        }
        public FRMBookReciveInternal(string div, string num)
        {
            InitializeComponent();
            this.div = div;
            this.num = num;
        }
        private void FRMBookReciveInternal_Load(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_UsersAndPermissions user = new CLS_FRMS.CLS_UsersAndPermissions();
                DataTable dtuser = user.PerThree(Properties.Settings.Default.UserNameLogin, Properties.Settings.Default.PasswordLogin, "وارد الشعب");
                if (dtuser.Rows[0][7].ToString() == null || dtuser.Rows[0][7].ToString() == "" || dtuser.Rows[0][7].ToString() == "False")
                    btndelete.Enabled = false;
                else btndelete.Enabled = true;
                if (dtuser.Rows[0][8].ToString() == null || dtuser.Rows[0][8].ToString() == "" || dtuser.Rows[0][8].ToString() == "False")
                    btnprint.Enabled = false;
                else btnprint.Enabled = true;


                lblUserName.Text = Properties.Settings.Default.UserNameLogin;
                dt = null;
                CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                dt = GetData.Book_Receive(Dgv, txtReciveNum, txtReciveDate, txtReciveTime, txtBookNum, txtBookDate, txtFrom, txtRegisterName, txtAddTime, txtAddDate, txtBookTitle);
                cm = (CurrencyManager)this.BindingContext[dt];
                Dgv.Visible = false;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    int j = 0;
                    while (j < TrvSender.Nodes.Count && TrvSender.Nodes[j].Text != dt.Rows[i][2].ToString())
                    {
                        j++;
                    }
                    if (j == TrvSender.Nodes.Count)
                    {
                        TreeNode node = TrvSender.Nodes.Add("NodeName", dt.Rows[i][2].ToString(), 0, 0);
                        for (int z = 0; z < dt.Rows.Count; z++)
                        {
                            if (dt.Rows[i][2].ToString() == dt.Rows[z][2].ToString())
                            {
                                var yaer = DateTime.Parse(dt.Rows[z][4].ToString()).Year;


                                int x = 0;
                                while (x < node.Nodes.Count && node.Nodes[x].Text != DateTime.Parse(dt.Rows[z][4].ToString()).Year.ToString())
                                {
                                    x++;
                                }
                                if (x == node.Nodes.Count)
                                {
                                    node.Nodes.Add("NodeName", yaer.ToString(), 1, 1);
                                }
                            }
                        }
                    }
                }
                if (div != null)
                {
                    foreach (TreeNode n in TrvSender.Nodes)
                    {
                        if (n.Text == div)
                        {
                            TrvSender.SelectedNode = n;
                            n.TreeView.SelectedNode = n.LastNode;
                        }
                            
                    }

                    foreach (DataGridViewRow row in Dgv.Rows)
                    {
                        
                        if (row.Cells[0].Value.ToString().Equals(num))
                        {
                            row.Selected = true;
                            Dgv.CurrentCell = row.Cells[0];
                            xtraTabPage1.Show();
                            CLS_FRMS.CLS_BookReciveInternal GetDataUpdate = new CLS_FRMS.CLS_BookReciveInternal();
                            GetDataUpdate.updateReciveBook(int.Parse(txtReciveNum.Text), int.Parse(txtBookNum.Text), txtFrom.Text, txtBookDate.Text);
                            break;
                        }
                    }
                }
            }catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا المستند!", "تأكييد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    
                    CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                    GetData.DeletingReciveBook(int.Parse(txtReciveNum.Text));

                    dt = null;
                    dt = GetData.Book_Receive(Dgv, txtReciveNum, txtReciveDate, txtReciveTime, txtBookNum, txtBookDate, txtFrom, txtRegisterName, txtAddTime, txtAddDate, txtBookTitle);
                    cm = (CurrencyManager)this.BindingContext[dt];
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReciveNum != null && txtReciveNum.Text != "")
                {
                    CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                    DataTable Dt = GetData.selectBookreciveArchive(int.Parse(txtReciveNum.Text), idArch, lsv);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lsv_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (chk_showbook.Checked == true)
                {
                    if (lsv.HitTest(e.X, e.Y).Item != null)
                    {
                        picload.Image = null;
                        GC.Collect();
                        picload.Image = Image.FromFile(lsv.HitTest(e.X, e.Y).Item.Text);
                        picload.Visible = true;
                    }
                    else
                    {
                        picload.Image = null;
                        GC.Collect();
                        picload.Visible = false;
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                (Dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Sender] like '%{0}%' or [BookTitle] like '%{0}%'", txtSearch.Text, txtSearch.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cm.Position = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            cm.Position -= 1;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cm.Position += 1;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cm.Position = dt.Rows.Count;
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrvSender_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            {
                (Dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Sender] like '%{0}%' and [DateSend] like '%{1}%'", TrvSender.SelectedNode.Parent.Text, TrvSender.SelectedNode.Text);
                Dgv.Visible = true;
            }
        }

        private void lsv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void idArch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtReciveNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReciveNum != null && txtReciveNum.Text != "")
                {
                    CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                    DataTable Dt = GetData.selectBookreciveArchive(int.Parse(txtReciveNum.Text), idArch, lsv);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsv.SelectedIndices.Count <= 0)
                {
                    return;
                }
                int intselectedindex = lsv.SelectedIndices[0];
                if (intselectedindex >= 0)
                {
                    String text = lsv.Items[intselectedindex].Text;
                    Process p = new Process();
                    p.StartInfo.FileName = text;
                    p.StartInfo.Verb = "Print";
                    p.Start();
                }
                
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                GetData.updateReciveBook(int.Parse(txtReciveNum.Text), int.Parse(txtBookNum.Text), txtFrom.Text, txtBookDate.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void xtraTabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void xtraTabPage1_Enter(object sender, EventArgs e)
        {
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("هل تريد ايقاف تنبيه هذا المستند؟", "تأكييد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CLS_FRMS.CLS_BookReciveInternal GetData = new CLS_FRMS.CLS_BookReciveInternal();
                    GetData.updateReciveBook(int.Parse(txtReciveNum.Text), int.Parse(txtBookNum.Text), txtFrom.Text, txtBookDate.Text);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}