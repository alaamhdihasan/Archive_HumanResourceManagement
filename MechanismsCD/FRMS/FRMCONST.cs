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

namespace MechanismsCD.FRMS
{
    public partial class FRMCONST : Form
    {
        CurrencyManager cm;
        SqlCommandBuilder cb;
        public FRMCONST()
        {
            InitializeComponent();
            CLS_FRMS.CLSCONSTENTRY getdata = new CLS_FRMS.CLSCONSTENTRY();
           
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {

            CLS_FRMS.CLSCONSTENTRY getdata = new CLS_FRMS.CLSCONSTENTRY();


            if (DgvDepartments.Visible == true)
            {
                 DataTable Dt = getdata.GetDataDepartment();
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();
                DgvDepartments.DataSource = Dt;
                this.DgvDepartments.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                tbidtxt.DataBindings.Add("text", Dt, "iddepart");
                DeptInvest.DataBindings.Add("bit", Dt, "الجهات الاستثمارية");

            }
            else if (dgvthetype.Visible == true)
            {
                DataTable Dt = getdata.TheTypeselection();
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();
                dgvthetype.DataSource = Dt;
                dgvthetype.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الحالة");
                tbidtxt.DataBindings.Add("text", Dt, "IDType");
                                           

            }
            else if (dgvdestination.Visible == true)
            {
                DataTable Dt = getdata.DistenationSelecting();
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();
                dgvdestination.DataSource = Dt;
                dgvdestination.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                tbidtxt.DataBindings.Add("text", Dt, "IDdis");

            }
            else if (dgvthecustomer.Visible == true)
            {
                DataTable Dt = getdata.TheCustomerSelection();



                idcustomertxt.DataBindings.Clear();
                customernametxt.DataBindings.Clear();
                distenationtxt.DataBindings.Clear();
                beneficiarytxt.DataBindings.Clear();
                transporttypetxt.DataBindings.Clear();
                customerjobtxt.DataBindings.Clear();
                registernametxt.DataBindings.Clear();

                dgvthecustomer.DataSource = Dt;
                dgvthecustomer.Columns[0].Visible = false;
                idcustomertxt.DataBindings.Add("text", Dt, "idcustomer");
                customernametxt.DataBindings.Add("text", Dt, "اسم المستفيد");
                distenationtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                beneficiarytxt.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                transporttypetxt.DataBindings.Add("text", Dt, "نوع الحالة");
                customerjobtxt.DataBindings.Add("text", Dt, "الوظيفة");
                registernametxt.DataBindings.Add("text", Dt, "مدخل البيانات");

               
                DataTable dtdis= getdata.DistenationSelecting();
                distenationtxt.DataSource = dtdis;
                distenationtxt.DisplayMember = "الجهة المقصودة";
                distenationtxt.ValueMember = "IDdis";


                DataTable dtben = getdata.GetDataDepartment();
               beneficiarytxt.DataSource = dtben;
                beneficiarytxt.DisplayMember = "الاقسام والمواقع";
                beneficiarytxt.ValueMember = "iddepart";


                DataTable dttran = getdata.TheTypeselection();
                transporttypetxt.DataSource = dttran;
                transporttypetxt.DisplayMember = "الحالة";
                transporttypetxt.ValueMember = "idtype";

            }


        }

        private void btnloadserver_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSCONSTENTRY insertdata = new CLS_FRMS.CLSCONSTENTRY();


            if (DgvDepartments.Visible == true)
            {
                insertdata.insertintoDepartments(tbtxt.Text,DeptInvest.Checked);

                DataTable Dt = insertdata.GetDataDepartment();
                this.DgvDepartments.DataSource = Dt;
                this.DgvDepartments.Columns[0].Visible = false;

            }
            else if (dgvthetype.Visible == true)
            {
                insertdata.TheTypeInsertinto(tbtxt.Text);

                DataTable Dt = insertdata.TheTypeselection();
                this.dgvthetype.DataSource = Dt;
                this.dgvthetype.Columns[0].Visible = false;

            }
            else if (dgvdestination.Visible == true)
            {
                insertdata.DistenationInsertinto(tbtxt.Text);
                DataTable Dt = insertdata.DistenationSelecting();
                dgvdestination.DataSource = Dt;
                dgvdestination.Columns[0].Visible = false;

            }
            else if (dgvthecustomer.Visible == true)
            {
                insertdata.TheCustomerInsertInto(customernametxt.Text, distenationtxt.Text, beneficiarytxt.Text
                    , transporttypetxt.Text, customerjobtxt.Text, registernametxt.Text);

                DataTable Dt = insertdata.TheCustomerSelection();
                dgvthecustomer.DataSource = Dt;
                dgvthecustomer.Columns[0].Visible = false;
                customernametxt.Clear();
                distenationtxt.Text = "";
                beneficiarytxt.Text = "";
                transporttypetxt.Text  = "";
                customerjobtxt.Clear();


                customernametxt.Focus();


            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSCONSTENTRY insertdata = new CLS_FRMS.CLSCONSTENTRY();


            if (DgvDepartments.Visible == true)
            {

                insertdata.DepartmentsUpdatedata(Convert.ToInt32(tbidtxt.Text), tbtxt.Text,DeptInvest.Checked);

                DataTable Dt = insertdata.GetDataDepartment();
                tbtxt.Focus();
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();

                this.DgvDepartments.DataSource = Dt;
                this.DgvDepartments.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                tbidtxt.DataBindings.Add("text", Dt, "iddepart");
                DeptInvest.DataBindings.Add("bit",Dt,"الجهات الاستثمارية");
            }
            else if (dgvthetype.Visible == true)
            {
                insertdata.TheTypeUpdate(Convert.ToInt32(tbidtxt.Text), tbtxt.Text);
                DataTable Dt = insertdata.TheTypeselection();
                tbtxt.Focus();
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();
                dgvthetype.DataSource = Dt;
                dgvthetype.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الحالة");
                tbidtxt.DataBindings.Add("text", Dt, "IDType");

            }
            else if (dgvdestination.Visible == true)
            {
                insertdata.DistenationUpdate(Convert.ToInt32(tbidtxt.Text),tbtxt.Text);
                tbtxt.DataBindings.Clear();
                tbidtxt.DataBindings.Clear();
                DataTable Dt = insertdata.DistenationSelecting();
                dgvdestination.DataSource = Dt;
                dgvdestination.Columns[0].Visible = false;
                tbtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                tbidtxt.DataBindings.Add("text", Dt, "IDdis");
            }

            else if (dgvthecustomer.Visible == true)
            {
                insertdata.TheCustomerUpdate(Convert.ToInt32(idcustomertxt.Text),customernametxt.Text, distenationtxt.Text, beneficiarytxt.Text
                    , transporttypetxt.Text, customerjobtxt.Text, registernametxt.Text);
                idcustomertxt.DataBindings.Clear();
                customernametxt.DataBindings.Clear();
                distenationtxt.DataBindings.Clear();
                beneficiarytxt.DataBindings.Clear();
                transporttypetxt.DataBindings.Clear();
                customerjobtxt.DataBindings.Clear();
                registernametxt.DataBindings.Clear();
                DataTable Dt = insertdata.TheCustomerSelection();
                dgvthecustomer.DataSource = Dt;
                dgvthecustomer.Columns[0].Visible = false;
                idcustomertxt.DataBindings.Add("text", Dt, "idcustomer");
                customernametxt.DataBindings.Add("text", Dt, "اسم المستفيد");
                distenationtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                beneficiarytxt.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                transporttypetxt.DataBindings.Add("text", Dt, "نوع الحالة");
                customerjobtxt.DataBindings.Add("text", Dt, "الوظيفة");
                registernametxt.DataBindings.Add("text", Dt, "مدخل البيانات");

            }


        }

        private void btndeletedb_Click(object sender, EventArgs e)
        {
            CLS_FRMS.CLSCONSTENTRY insertdata = new CLS_FRMS.CLSCONSTENTRY();


            if (DgvDepartments.Visible == true)
            {
                DialogResult str = MessageBox.Show("هل تريد بالتـأكيد عملية الحذف", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (str == DialogResult.Yes)
                {
                    insertdata.DepartmentsDeleting(Convert.ToInt32(tbidtxt.Text));

                    DataTable Dt = insertdata.GetDataDepartment();
                    tbtxt.Focus();
                    tbtxt.DataBindings.Clear();
                    tbidtxt.DataBindings.Clear();

                    this.DgvDepartments.DataSource = Dt;
                    this.DgvDepartments.Columns[0].Visible = false;
                    tbtxt.DataBindings.Add("text", Dt, "الاقسام والمواقع");
                    tbidtxt.DataBindings.Add("text", Dt, "iddepart");
                    DeptInvest.DataBindings.Add("bit", Dt, "الجهات الاستثمارية");
                }
                else
                {
                    MessageBox.Show("لم تتم عملية الحذف");
                }

            }
            else if (dgvthetype.Visible == true)
            {
                DialogResult str = MessageBox.Show("هل تريد بالتـأكيد عملية الحذف", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (str == DialogResult.Yes)
                {
                    insertdata.TheTypeDeleting(Convert.ToInt32(tbidtxt.Text));
                    DataTable Dt = insertdata.TheTypeselection();
                    tbtxt.DataBindings.Clear();
                    tbidtxt.DataBindings.Clear();
                    dgvthetype.DataSource = Dt;
                    dgvthetype.Columns[0].Visible = false;
                    tbtxt.DataBindings.Add("text", Dt, "الحالة");
                    tbidtxt.DataBindings.Add("text", Dt, "IDType");
                }
                else
                {
                    MessageBox.Show("لم تتم عملية الحذف");
                }

            }
            else if (dgvdestination.Visible == true)
            {
                DialogResult str = MessageBox.Show("هل تريد بالتـأكيد عملية الحذف", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (str == DialogResult.Yes)
                {
                    insertdata.DistenationDeleting(Convert.ToInt32(tbidtxt.Text));
                    tbtxt.DataBindings.Clear();
                    tbidtxt.DataBindings.Clear();
                    DataTable Dt = insertdata.DistenationSelecting();
                    dgvdestination.DataSource = Dt;
                    dgvdestination.Columns[0].Visible = false;
                    tbtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                    tbidtxt.DataBindings.Add("text", Dt, "IDdis");
                }
                else
                {
                    MessageBox.Show("لم تتم عملية الحذف");
                }
            }
            else if (dgvthecustomer.Visible == true)
            {
                DialogResult str = MessageBox.Show("هل تريد بالتـأكيد عملية الحذف", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (str == DialogResult.Yes)
                {
                    
                        insertdata.ThecustomerDeleting(Convert.ToInt32(idcustomertxt.Text));
                        idcustomertxt.DataBindings.Clear();
                        customernametxt.DataBindings.Clear();
                        distenationtxt.DataBindings.Clear();
                        beneficiarytxt.DataBindings.Clear();
                        transporttypetxt.DataBindings.Clear();
                        customerjobtxt.DataBindings.Clear();
                        registernametxt.DataBindings.Clear();
                        DataTable Dt = insertdata.TheCustomerSelection();
                        dgvthecustomer.DataSource = Dt;
                        dgvthecustomer.Columns[0].Visible = false;
                        idcustomertxt.DataBindings.Add("text", Dt, "idcustomer");
                        customernametxt.DataBindings.Add("text", Dt, "اسم المستفيد");
                        distenationtxt.DataBindings.Add("text", Dt, "الجهة المقصودة");
                        beneficiarytxt.DataBindings.Add("text", Dt, "الجهة المستفيدة");
                        transporttypetxt.DataBindings.Add("text", Dt, "نوع الحالة");
                        customerjobtxt.DataBindings.Add("text", Dt, "الوظيفة");
                        registernametxt.DataBindings.Add("text", Dt, "مدخل البيانات");
                    customernametxt.Focus();

                   
                }
                else
                {
                    MessageBox.Show("لم تتم عملية الحذف");
                }
            }
        }

        private void distenationtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            CLS_FRMS.CLSCONSTENTRY cbo = new CLS_FRMS.CLSCONSTENTRY();
             DataTable Dt = new DataTable();
            Dt = cbo.DistenationSelecting();
            distenationtxt.DataSource = Dt;
            distenationtxt.DisplayMember = "الجهة المقصودة";
            
        }

        private void searchtxt_TextChanged(object sender, EventArgs e)
        {
            
         (dgvthecustomer.DataSource as DataTable).DefaultView.RowFilter = string.Format("[اسم المستفيد] LIKE '%{0}%'", searchtxt.Text);
         
        }
    }
}
