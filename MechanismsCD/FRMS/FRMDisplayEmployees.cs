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
    public partial class FRMDisplayEmployees : DevExpress.XtraEditors.XtraForm
    {
        public FRMDisplayEmployees()
        {
            InitializeComponent();
        }

        private void FRMDisplayEmployees_Load(object sender, EventArgs e)
        {
            //CLS_FRMS.CLSEMPLOYEES EmpRootNode = new CLS_FRMS.CLSEMPLOYEES();
            //DataTable DtrootNode = EmpRootNode.Emp_RootNode(Tr_Doc);

            Tr_Doc.Nodes.Add("NodeName", "فعلي", 0, 0);
            Tr_Doc.Nodes.Add("NodeName", "منتهي", 0, 0);
        }

        private void Tr_Doc_AfterSelect(object sender, TreeViewEventArgs e)
        {

            CLS_FRMS.CLSEMPLOYEES EmpDoc = new CLS_FRMS.CLSEMPLOYEES();
            DataTable Dt = EmpDoc.EmployeesDocuments(Tr_Doc.SelectedNode.Text, DgvDoc,DgvDoc1);


            
        }

        private void Searchingtxt_TextChanged(object sender, EventArgs e)
        {
           (DgvDoc1.DataSource as DataTable).DefaultView.RowFilter = string.Format("[Emp_EmployeeName] like '%{0}%' ", Searchingtxt.Text);
        }
    }
}
