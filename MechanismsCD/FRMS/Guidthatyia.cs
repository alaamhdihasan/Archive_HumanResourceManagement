using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Imaging;
using System.ComponentModel;
//using TwainScanning;
using WIA;
using asprise_imaging_api;
using System.IO;
using TwainLib;
using System.Text.RegularExpressions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.Diagnostics;
//using System.Diagnostics;


namespace MechanismsCD.FRMS
{
    public partial class Guidthatyia : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public string newpath;
        public string pathimage;
        public string nameimage;
        string info;
        CurrencyManager cm;
        DataTable Dtcm = new DataTable();
        int nRow;
        MAINFRM frm;
        private Guidthatyia frm1;

        public Guidthatyia(MAINFRM frm)
        {
            InitializeComponent();
         
            this.lsv.DragEnter += new DragEventHandler(this.lsv_DragEnter);
            this.frm = frm;

        }

        public Guidthatyia(string info, MAINFRM frm)
        {
            InitializeComponent();
            this.info = info;
            this.lsv.DragEnter += new DragEventHandler(this.lsv_DragEnter);
            this.frm = frm;
        }

       

        private void Guidthatyia_Load(object sender, EventArgs e)
        {
            try {
                lblUserName.Caption = Properties.Settings.Default.UserNameLogin;

                this.Text = "الارشيف";
            CLS_FRMS.CLS_UsersAndPermissions Per3 = new CLS_FRMS.CLS_UsersAndPermissions();
            DataTable Dt = Per3.PerThree(Properties.Settings.Default.UserNameLogin.ToString(),
                Properties.Settings.Default.PasswordLogin.ToString(), this.Text);
            Per3.PerThree2(Dt, btnAdd, btnsave, btndelete, btnprint, btnPrintBook);



            LoadData.Start();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Treeone_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
            {

                CLS_FRMS.Treeandthatyia chtree = new CLS_FRMS.Treeandthatyia();
                DataTable Dtch = chtree.TreeforFill(e.Node.Parent.Text);
                Lbparent.Text = Treeone.SelectedNode.Parent.Text;

               

                CLS_FRMS.WorkingProperties Thpro = new CLS_FRMS.WorkingProperties();
                DataTable Dtthpro = Thpro.ThatyiaPropertiesExecute(Lbparent.Text, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12, tb13, tb24, tb17, tb18, tb19, tb21
                , tb20, tb22, tb23, tb14, tb15, tb16, btnprint,lb5,lb6,lb7,lb8,lb9,lb10,lb11,lb12,Lb24,lb17,lb18,lb19,lb21,lb20,lb22,lb23,lb14,lb15,lb16 ,tbnode11,tbnode22,sin);

                if (Dtch.Rows.Count>0)
                {
                    tbnode1.Text = Dtch.Rows[0][1].ToString();
                    tbnode2.Text = Dtch.Rows[0][0].ToString();
                      
    
                }
                else
                {

                }

              
            }
            tbnode1.Text = Treeone.SelectedNode.Text;

            

            int outParse;
            // Check if the point entered is numeric or not
            if (int.TryParse(tbnode1.Text, out outParse) == true)
            {
                CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                Datanode.DesignGrid(Dgv, Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn,tbnode11,tbnode22, DgvSearch);
                Dtcm = Dt;
                cm = (CurrencyManager)this.BindingContext[Dtcm];
                   

                    string[] str = new string[12];
                str[0] = "محرم";str[1] = "صفر";str[2] = "ربيع الاول";str[3] = "ربيع الثاني";str[4] = "جمادى الاولى";str[5] = "جمادى الاخر";
                str[6] = "رجب"; str[7] = "شعبان"; str[8] = "رمضان"; str[9] = "شوال"; str[10] = "ذي القعدة"; str[11] = "ذي الحجة";
                tb10.Items.Clear();
                tb10.Items.AddRange(str);


               
                cmbSendTo.Items.Clear();
                cmbSendTo.Items.Add("السيد رئيس القسم");
                cmbSendTo.Items.Add("السيد المعاون الاداري");
                cmbSendTo.Items.Add("السيد المعاون الفني");
                cmbSendTo.Items.Add("كافة الشعب");
                cmbSendTo.Items.Add(Properties.Settings.Default.ServerName1.ToString());
                cmbSendTo.Items.Add(Properties.Settings.Default.ServerName2.ToString());
                cmbSendTo.Items.Add(Properties.Settings.Default.ServerName3.ToString());

                tb18.Items.Clear();
                tb19.Items.Clear();
                CLS_FRMS.CLSCONSTENTRY GetDepartments = new CLS_FRMS.CLSCONSTENTRY();
                DataTable Dtdepartment = GetDepartments.GetDataDepartment();
                for (int i = 0; i < Dtdepartment.Rows.Count; i++)
                {
                    tb18.Items.Add(Dtdepartment.Rows[i][1].ToString());
                    tb19.Items.Add(Dtdepartment.Rows[i][1].ToString());
                }
                tb19.Items.Add("السيد نائب الأمين العام (دام تأييده)");
                

                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة كتاب جديد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (tb5.Visible == false && tb7.Visible == true)
                    {
                     
                        CLS_FRMS.Treeandthatyia GetID = new CLS_FRMS.Treeandthatyia();
                        DataTable Dt = GetID.thatyiaAddingID(int.Parse(tb4.Text), int.Parse(tb2.Text));
                        
                        CLS_FRMS.Treeandthatyia btn = new CLS_FRMS.Treeandthatyia();
                        btn.btnNew(Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                                , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb24);

                        // after new we will insert data to database for saving the new number 

                        FRM_LOGIN FL = new FRM_LOGIN();
                        CultureInfo cultures = new CultureInfo("en-us");
                        tb14.Text = Properties.Settings.Default.UserNameLogin.ToString();
                        tb15.Text = DateTime.Now.ToString(cultures);
                        tb16.Text = DateTime.Now.ToString("yyyy/MM/dd");
                        tb8.Value = DateTime.Now;
                        CLS_FRMS.Treeandthatyia AddData = new CLS_FRMS.Treeandthatyia();
                        AddData.ThatyiaAdding(int.Parse(tb2.Text), tb3.Text, int.Parse(tb4.Text), tb5.Text, tb6.Text, tb7.Text
                            , tb8.Text, tb9.Text, tb10.Text, tb11.Text, tb17.Text, tb18.Text, tb19.Text, tb21.Text, tb20.Text
                            , tb12.Text, tb13.Text, tb14.Text, tb15.Text, tb16.Text, tb22.Text, tb23.Text, tb24.Text);

                        CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                        DataTable Dtt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                        Datanode.DesignGrid(Dgv, Dtt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                           , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn, tbnode11, tbnode22, DgvSearch);
                        Dtcm = Dtt;
                        cm = (CurrencyManager)this.BindingContext[Dtcm];
                    }
                    else if (tb5.Visible == true && tb7.Visible == false)
                    {
                    
                        CLS_FRMS.Treeandthatyia GetID = new CLS_FRMS.Treeandthatyia();
                        DataTable Dt = GetID.thatyiaAddingID2(int.Parse(tb4.Text), int.Parse(tb2.Text));
                        CLS_FRMS.Treeandthatyia btn = new CLS_FRMS.Treeandthatyia();
                        btn.btnNew(Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                                , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb24);

                        // after new we will insert data to database for saving the new number 
                        FRM_LOGIN FL = new FRM_LOGIN();
                        CultureInfo cultures = new CultureInfo("en-us");
                        tb14.Text = Properties.Settings.Default.UserNameLogin.ToString();
                        tb15.Text = DateTime.Now.ToString(cultures);
                        tb16.Text = DateTime.Now.ToString("yyyy/MM/dd");
                        tb6.Value = DateTime.Now;
                        tb23.Value = DateTime.Now;
                        tb22.Text = null;
                        CLS_FRMS.Treeandthatyia AddData = new CLS_FRMS.Treeandthatyia();
                        AddData.ThatyiaAdding(int.Parse(tb2.Text), tb3.Text, int.Parse(tb4.Text), tb5.Text, tb6.Text, tb7.Text
                            , tb8.Text, tb9.Text, tb10.Text, tb11.Text, tb17.Text, tb18.Text, tb19.Text, tb21.Text, tb20.Text
                            , tb12.Text, tb13.Text, tb14.Text, tb15.Text, tb16.Text, tb22.Text, tb23.Text, tb24.Text);


                        CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                        DataTable Dttt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                        Datanode.DesignGrid(Dgv, Dttt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                           , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn, tbnode11, tbnode22, DgvSearch);
                        Dtcm = Dttt;
                        cm = (CurrencyManager)this.BindingContext[Dtcm];
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try { 
            if (Properties.Settings.Default.UserNameLogin.ToString() == tb14.Text)
            {

                DialogResult dialogResult = MessageBox.Show("هل تريد حفظ هذا الكتاب!", "تأكييد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    CultureInfo cultures = new CultureInfo("en-us");
                    tb14.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    tb15.Text = DateTime.Now.ToString(cultures);
                    tb16.Text = DateTime.Now.ToString("yyyy/MM/dd");

                    CLS_FRMS.Treeandthatyia btn = new CLS_FRMS.Treeandthatyia();
                    btn.ThatyiaUpdate(int.Parse(tb2.Text), tb3.Text, int.Parse(tb4.Text), tb5.Text, tb6.Text, tb7.Text
                        , tb8.Text, tb9.Text, tb10.Text, tb11.Text, tb17.Text, tb18.Text, tb19.Text, tb21.Text, tb20.Text
                        , tb12.Text, tb13.Text, tb14.Text, tb15.Text, tb16.Text, int.Parse(tb1.Text), tb22.Text, tb23.Text, tb24.Text);

                    CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                    Datanode.DesignGrid(Dgv, Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                        , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn, tbnode11, tbnode22, DgvSearch);
                    Dtcm = Dt;
                    cm = (CurrencyManager)this.BindingContext[Dtcm];
                }


            }
            else
            {
                MessageBox.Show("هذا القيد انشأ من قبل مستخدم آخر، لايمكنك التعديل عليه", "تعديل قيد", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {


            try { 

                DialogResult dialogResult = MessageBox.Show("هل تريد حفظ هذا الكتاب!", "تأكييد", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    CultureInfo cultures = new CultureInfo("en-us");
                    tb14.Text = tb14.Text + " + " + Properties.Settings.Default.UserNameLogin.ToString();
                    tb15.Text = DateTime.Now.ToString(cultures);
                    tb16.Text = DateTime.Now.ToString("yyyy/MM/dd");

                    CLS_FRMS.Treeandthatyia btn = new CLS_FRMS.Treeandthatyia();
                    btn.ThatyiaUpdate(int.Parse(tb2.Text), tb3.Text, int.Parse(tb4.Text), tb5.Text, tb6.Text, tb7.Text
                        , tb8.Text, tb9.Text, tb10.Text, tb11.Text, tb17.Text, tb18.Text, tb19.Text, tb21.Text, tb20.Text
                        , tb12.Text, tb13.Text, tb14.Text, tb15.Text, tb16.Text, int.Parse(tb1.Text), tb22.Text, tb23.Text, tb24.Text);

                    CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                    Datanode.DesignGrid(Dgv, Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                        , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn, tbnode11, tbnode22, DgvSearch);
                    Dtcm = Dt;
                    cm = (CurrencyManager)this.BindingContext[Dtcm];
                }




            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult dialogResult = MessageBox.Show("هل تريد حذف هذا الكتاب!", "تأكييد", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CLS_FRMS.Treeandthatyia btn = new CLS_FRMS.Treeandthatyia();
                btn.ThatyiaDelete(int.Parse(tb1.Text));

                CLS_FRMS.Treeandthatyia Datanode = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = Datanode.GetDatanode(tbnode2.Text, tbnode1.Text);
                Datanode.DesignGrid(Dgv, Dt, tb1, tb2, tb3, tb4, tb5, tb6, tb7, tb8, tb9, tb10, tb11, tb12
                    , tb13, tb14, tb15, tb16, tb17, tb18, tb19, tb20, tb21, tb22, tb23, tb24, tbl2, Pnbtn, tbnode11, tbnode22, DgvSearch);
                Dtcm = Dt;
                cm = (CurrencyManager)this.BindingContext[Dtcm];
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

      
        private void btnemployeeinterface_Click(object sender, EventArgs e)
        {
            xtraTabPage1.Show();
        }
               
        private void حاسبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "select an file|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string file_type = Path.GetExtension(ofd.FileName);
               
                if (file_type == ".jpg" || file_type == ".bmp" || file_type == ".png" )
                {
                    pathimage = ofd.FileName;
                    nameimage = System.IO.Path.GetFileName(pathimage);
                    Random x = new Random();
                    newpath = Properties.Settings.Default.PathOfArchieves + x.Next().ToString() + Path.GetExtension(nameimage);
                    picsave.Load(pathimage);
                    picsave.Image.Save(newpath);

                    
                    archtb6.Text = newpath;
                    lsv.Items.Add(archtb6.Text);

                    archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                    archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    archtb3.Text = Treeone.SelectedNode.Parent.Text;
                    archtb4.Text = tbnode1.Text;
                    archtb2.Text = tb1.Text;
                    CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                    archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                        archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);
                }
                else
                {
                    string filename = System.IO.Path.GetFileName(ofd.FileName);
                    newpath = Properties.Settings.Default.pathofDocument + filename;
                    File.Copy(ofd.FileName, newpath);

                    Random x = new Random();
                    filename = Properties.Settings.Default.pathofDocument + x.Next().ToString() + Path.GetExtension(ofd.FileName);

                    File.Move(newpath, filename);

                    archtb6.Text = filename;
                    lsv.Items.Add(archtb6.Text);

                    archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                    archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    archtb3.Text = Treeone.SelectedNode.Parent.Text;


                    archtb4.Text = tbnode1.Text;
                    archtb2.Text = tb1.Text;
                    CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                    archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                        archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);

                }
                CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                    archtb7, archtb8, archtb9, pnarch1, lsv);

            }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        //======================================================================================
        //==== This code below for run scanner and scan one image .......
        private void فرديToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            try { 
            var b = TwainOperations.ScanImages();
            foreach (var Itm in b)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfArchieves + nameimage;
                picsave.Load(Itm);
                picsave.Image.Save(newpath);
                archtb6.Text = newpath;
                lsv.Items.Add(archtb6.Text);

                archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                archtb3.Text = Treeone.SelectedNode.Parent.Text;
               // archtb5.Text = tb7.Text;


                archtb4.Text = tbnode1.Text;
                archtb2.Text = tb1.Text;

                CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                    archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);

            }
            CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                archtb7, archtb8, archtb9, pnarch1, lsv);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        //=================================================================================================
        //====== This code below for displaying image in pbimage.....
        private void archtb6_TextChanged(object sender, EventArgs e)
        {
          
        }
        //================================================================================================
        // this Action below from Print A document.......
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.Treeandthatyia Prdoc = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = new DataTable();
                Dt = Prdoc.PrintDoc(int.Parse(tb1.Text));
                DS.DataSetThatyia Dst = new DS.DataSetThatyia();
                Dst.Tables["PrintDocument"].Clear();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Dst.Tables["PrintDocument"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                        Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5],
                        Dt.Rows[i][6], Dt.Rows[i][7], Dt.Rows[i][8]);
                }
                REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                if (Properties.Settings.Default.ServerName.ToString() == "الشعبة الادارية والمالية")
                {
                    if (Treeone.SelectedNode.Parent.Text == "صادر لجنة المشتريات")
                    {
                        REPORTS.Purchases_Print rpt = new REPORTS.Purchases_Print();
                        rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");


                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }


                        rpt.DataSource = Dst;
                        rpt.RequestParameters = false;
                        frm.documentViewer1.DocumentSource = rpt;
                    }
                    else
                    {
                        REPORTS.PrintDocumentTest rpt = new REPORTS.PrintDocumentTest();
                        rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");


                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }


                        rpt.DataSource = Dst;
                        rpt.RequestParameters = false;
                        frm.documentViewer1.DocumentSource = rpt;
                    }
                    
                }
                else
                {
                    REPORTSCAR.DivBook rpt = new REPORTSCAR.DivBook();
                    rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    rpt.Parameters["Div"].Value = Properties.Settings.Default.ServerName.ToString();

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }


                    rpt.DataSource = Dst;
                    rpt.RequestParameters = false;
                    frm.documentViewer1.DocumentSource = rpt;
                }

               
                frm.ShowDialog();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

            
           

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            try
            {

                CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                    archtb7, archtb8, archtb9, pnarch1, lsv);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void xtraTabPage2_Click(object sender, EventArgs e)
        {
            try {
                
            CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                archtb7, archtb8, archtb9,  pnarch1,lsv);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {

            try
            {

                if (Dgv.RowCount>0 && (Dgv.Rows[Dgv.CurrentCell.RowIndex].Cells[0].Value.ToString()!=null && Dgv.Rows[Dgv.CurrentCell.RowIndex].Cells[0].Value.ToString() !=""))
            {
                tb1.Text = Dgv.Rows[Dgv.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                   
                    CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                archtb7, archtb8, archtb9,  pnarch1,lsv);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void اضافةسنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LbTree.Text = اضافةسنةToolStripMenuItem.Text;
            
            CLS_FRMS.Treeandthatyia cht = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = cht.TreeCheckChild(int.Parse(tbnode2.Text));

            if (this.Treeone.SelectedNode != null)
            {

                this.Treeone.SelectedNode.Expand();
                TreeNode newNode = this.Treeone.Nodes[Treeone.Nodes.IndexOf(Treeone.SelectedNode.Parent)].Nodes.Add("NewNode", "New Folder", 1, 1);
                if (newNode != null)
                {
                    this.Treeone.SelectedNode = newNode;
                    Treeone.LabelEdit = true;
                    newNode.BeginEdit();
                    
                      
                }

            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Treeone_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void SetLabel(object sender)
        {
            try { 
            ToolStripMenuItem item = sender as ToolStripMenuItem;

            if (item != null)
            {
                Treeone.SelectedNode.Text = item.Text;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

       
        /*==========================================================================================================
         * This event below keydown for Adding New ChildNode To the TreeView Which Name is TreeOne.......
         * User must be doing tow click Key Enter for Apply this function...
        */
        private void Treeone_KeyDown(object sender, KeyEventArgs e)
        {
            try { 
            if(e.KeyCode==Keys.Enter)
            {
                tbnode1.Text = Treeone.SelectedNode.Text;
               
            }
            CLS_FRMS.Treeandthatyia ev = new CLS_FRMS.Treeandthatyia();
            ev.EventKeyDown(LbTree,Lbrename,Lbindex, tbnode1, tbnode2, Treeone,LoadData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //==========================================================================================================

        private void tbnode1_TextChanged(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.Treeandthatyia ch = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = ch.TreeforFill(tbnode1.Text);
            if(Dt.Rows.Count>0)
            {
                tbnode2.Text = Dt.Rows[0][0].ToString();
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //============================================================================================================

        private void اضفاةشجرةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            LbTree.Text = اضفاةشجرةToolStripMenuItem.Text;
            TreeNode newnode= Treeone.Nodes.Add("MainNode", "New Folder", 0, 0);
            this.Treeone.SelectedNode = newnode;
            Treeone.LabelEdit = true;
            newnode.BeginEdit();

               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); } 
        }
        //==============================================================================================================
        private void اعادةتسميةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            LbTree.Text = اعادةتسميةToolStripMenuItem.Text;
            TreeNode newnode = Treeone.SelectedNode;
            this.Treeone.SelectedNode = newnode;
            Treeone.LabelEdit = true;
            Lbrename.Text = newnode.Text;
            Lbindex.Text = tbnode2.Text;
            newnode.BeginEdit();
                
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void فتحالادلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Treeone.ExpandAll();
        }

        private void فلقالادلةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Treeone.CollapseAll();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            LbTree.Text = حذفToolStripMenuItem.Text;
            TreeNode newnode = Treeone.SelectedNode;
            this.Treeone.SelectedNode = newnode;
            Lbrename.Text = newnode.Text;
            Lbindex.Text = tbnode2.Text;
            CLS_FRMS.Treeandthatyia clikenter = new CLS_FRMS.Treeandthatyia();
            clikenter.EventKeyDown(LbTree, Lbrename, Lbindex, tbnode1, tbnode2, Treeone, LoadData);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //==============================================================================================================
        //=== Loading Data of TreeView ..................
        private void LoadData_Tick(object sender, EventArgs e)
        {
            try { 
            Treeone.Nodes.Clear();
            CLS_FRMS.Treeandthatyia GuidT = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = GuidT.Getmainlynodd();
            int i, j;
            for (i = 0; i < Dt.Rows.Count; i++)
            {
                Treeone.Nodes.Add("Dtnode", Dt.Rows[i][0].ToString(), 0, 0);

               CLS_FRMS.Treeandthatyia GuidT2 = new CLS_FRMS.Treeandthatyia();
                DataTable Dt2 = GuidT2.GetSecondarynodd(int.Parse(Dt.Rows[i][1].ToString()));
                for (j = 0; j < Dt2.Rows.Count; j++)
                {
                    Treeone.Nodes[i].Nodes.Add("Dt2node", Dt2.Rows[j][2].ToString(), 1, 1);
                }
            }


            xtraTabPage4.PageVisible = false;
            xtraTabPage3.Show();


            LoadData.Stop();
            if (info != null)
            {
                string[] bookinfo = info.Split(' ');
                string a = bookinfo[0]+" "+bookinfo[1];
                              
                foreach (TreeNode n in Treeone.Nodes)
                {
                    foreach (TreeNode n1 in n.Nodes)
                    {
                        if (n.Text == a && n1.Text == bookinfo[2])
                        {                            
                            Treeone.SelectedNode = n1;
                            textBox1.Text = bookinfo[3].ToString();
                        }
                    }
                }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //===============================================================================================================

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FRMS.FRMThatyiaProperties frm = new FRMThatyiaProperties();
            frm.Show();
        }

        private void خصائصالدليلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMS.FRMThatyiaProperties frm = new FRMThatyiaProperties();
            frm.Show();
        }
        //==================================================================================================
        // ===Load image to the imagebox from listview .......
        private void lsv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try{ 
            if (lsv.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = lsv.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = lsv.Items[intselectedindex].Text;
                
                CLS_FRMS.Treeandthatyia GetData = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = GetData.thatyia2selectbylistview(text, archtb1, archtb2, archtb3, archtb4, archtb5
                    , archtb6, archtb7, archtb8, archtb9, pnarch1);
                
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void lsv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { 
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
        //===============================================================================================================
        //=== 
        private void btnNewAttention_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة تنبيه جديد؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    foreach (Control item in GbAttention.Controls)
                    {
                        if (item is TextBox || item is DevExpress.XtraEditors.ComboBox || item is DateTimePicker || item is RichTextBox)
                        {
                            item.Text = "";
                        }
                    }

                    TbAttenIDcon.Text = tb1.Text;
                    TbTypeAttention.Text = Treeone.SelectedNode.Parent.Text;
                    if (tb7.Text != null && tb7.Text != "") { TbTypeNumber.Text = tb7.Text; tbbookyear.Text = Convert.ToDateTime(tb8.Text).Year.ToString(); }
                    else if (tb5.Text != null && tb5.Text != "") { TbTypeNumber.Text = tb5.Text; MessageBox.Show(tb5.Text); tbbookyear.Text = Convert.ToDateTime(tb6.Text).Year.ToString(); }


                    TbAttenRegisterName.Text = Properties.Settings.Default.UserNameLogin.ToString();
                    TbAttenAddingTime.Text = DateTime.Now.ToString("HH:mm tt");
                    TbAttenAddingDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //===============================================================================================================
        // This function below for laoding Data of ThatyiaAttention........
        private void xtraTabPage4_Click(object sender, EventArgs e)
        {
           
        }
        //===============================================================================================================
        // === This code below for Adding Data to the thatyiaAttention table .....
        private void BtnAddAttention_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة هذا التنبيه؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.Treeandthatyia AddingData = new CLS_FRMS.Treeandthatyia();
                    AddingData.ThatyiaAttentionInsertingData(int.Parse(TbAttenIDcon.Text), TbTypeAttention.Text, TbTypeNumber.Text,
                        TbAttentionDate.Text, Convert.ToBoolean(TbAfterAttentionDate.EditValue), Convert.ToBoolean(TbBeforeAttentionDate.EditValue),
                        Convert.ToInt32(TbAttentionPeriod.Value),
                        TbAttentionNotice.Text, Convert.ToBoolean(TbAttentionFinishing.EditValue), TbAttenRegisterName.Text, TbAttenAddingTime.Text,
                        TbAttenAddingDate.Text, int.Parse(tbbookyear.Text));

                    CLS_FRMS.Treeandthatyia LoadDataofAttention = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = LoadDataofAttention.ThatyiaAttentionSelectionData(int.Parse(tb1.Text), TbAttenID, TbAttenIDcon, TbTypeAttention,
                        TbTypeNumber, TbAttentionDate, TbAfterAttentionDate, TbBeforeAttentionDate, TbAttentionPeriod, TbAttentionFinishing,
                        TbAttenRegisterName, TbAttenAddingTime, TbAttenAddingDate, TbAttentionNotice, GbAttention, tbbookyear);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAttention_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            xtraTabPage4.PageVisible = true;
            xtraTabPage4.Show();
            CLS_FRMS.Treeandthatyia LoadDataofAttention = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = LoadDataofAttention.ThatyiaAttentionSelectionData(int.Parse(tb1.Text), TbAttenID, TbAttenIDcon, TbTypeAttention,
                TbTypeNumber, TbAttentionDate, TbAfterAttentionDate, TbBeforeAttentionDate, TbAttentionPeriod, TbAttentionFinishing,
                TbAttenRegisterName, TbAttenAddingTime, TbAttenAddingDate, TbAttentionNotice, GbAttention,tbbookyear);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        //============================================================================================================
        //=== this code below for Updatting data of thatyiaAttention........
        private void btnSaveAttention_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("هل تريد اضافة تعديل هذا التنبيه؟", "عملية حفظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    CLS_FRMS.Treeandthatyia UpdattingData = new CLS_FRMS.Treeandthatyia();
                    UpdattingData.ThatyiaAttentionUpdattingDate(int.Parse(TbAttenIDcon.Text), TbTypeAttention.Text, TbTypeNumber.Text,
                        TbAttentionDate.Text, Convert.ToBoolean(TbAfterAttentionDate.EditValue), Convert.ToBoolean(TbBeforeAttentionDate.EditValue)
                        , Convert.ToInt32(TbAttentionPeriod.Value), TbAttentionNotice.Text, Convert.ToBoolean(TbAttentionFinishing.EditValue)
                        , TbAttenRegisterName.Text, TbAttenAddingTime.Text, TbAttenAddingDate.Text, int.Parse(TbAttenID.Text), int.Parse(tbbookyear.Text));

                    CLS_FRMS.Treeandthatyia LoadDataofAttention = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = LoadDataofAttention.ThatyiaAttentionSelectionData(int.Parse(tb1.Text), TbAttenID, TbAttenIDcon, TbTypeAttention,
                        TbTypeNumber, TbAttentionDate, TbAfterAttentionDate, TbBeforeAttentionDate, TbAttentionPeriod, TbAttentionFinishing,
                        TbAttenRegisterName, TbAttenAddingTime, TbAttenAddingDate, TbAttentionNotice, GbAttention, tbbookyear);
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.Message); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            xtraTabPage4.PageVisible = false;
        }

        private void btnDeleteAttention_Click(object sender, EventArgs e)
        {
            try { 
            DialogResult Resualt = MessageBox.Show("هل تريد بالتاكيد عملية الحذف , لا يمكن التراجع عن عملية الحذف عند الموافقة", "Deleting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(Resualt ==DialogResult.Yes)
            {
                CLS_FRMS.Treeandthatyia DeleteData = new CLS_FRMS.Treeandthatyia();
                DeleteData.ThatyiaAttentionDelettingData(int.Parse(TbAttenID.Text));
                MessageBox.Show("تمت عملية الحذف", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.None);
            }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barEditItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnBold_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnPrintBook_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
            FRM_LOGIN FL = new FRM_LOGIN();
            if(ScalePaper.EditValue=="A4")
            {
                    CLS_FRMS.Treeandthatyia Prdoc = new CLS_FRMS.Treeandthatyia();
                    DataTable Dt = new DataTable();
                    Dt = Prdoc.PrintDoc(int.Parse(tb1.Text));
                    DS.DataSetThatyia Dst = new DS.DataSetThatyia();
                    Dst.Tables["PrintDocument"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        Dst.Tables["PrintDocument"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5],
                            Dt.Rows[i][6], Dt.Rows[i][7], Dt.Rows[i][8]);
                    }
                    REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                    if (Properties.Settings.Default.ServerName.ToString() == "الشعبة الادارية والمالية")
                    {
                        if (Treeone.SelectedNode.Parent.Text == "صادر لجنة المشتريات")
                        {
                            REPORTS.Purchases_Print rpt = new REPORTS.Purchases_Print();
                            rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                            rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");


                            for (int i = 0; i < rpt.Parameters.Count; i++)
                            {
                                rpt.Parameters[i].Visible = false;
                            }


                            rpt.DataSource = Dst;
                            rpt.RequestParameters = false;
                            frm.documentViewer1.DocumentSource = rpt;
                        }
                        else
                        {
                            REPORTS.PrintDocumentTest rpt = new REPORTS.PrintDocumentTest();
                            rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                            rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");


                            for (int i = 0; i < rpt.Parameters.Count; i++)
                            {
                                rpt.Parameters[i].Visible = false;
                            }


                            rpt.DataSource = Dst;
                            rpt.RequestParameters = false;
                            frm.documentViewer1.DocumentSource = rpt;
                        }

                    }
                    else
                    {
                        REPORTSCAR.DivBook rpt = new REPORTSCAR.DivBook();
                        rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        rpt.Parameters["Div"].Value = Properties.Settings.Default.ServerName.ToString();

                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }


                        rpt.DataSource = Dst;
                        rpt.RequestParameters = false;
                        frm.documentViewer1.DocumentSource = rpt;
                    }


                    frm.ShowDialog();
             
            }
            else if(ScalePaper.EditValue=="A5")
            {
                CLS_FRMS.Treeandthatyia Prdoc = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = new DataTable();
                Dt = Prdoc.PrintDoc(int.Parse(tb1.Text));
                DS.DataSetThatyia Dst = new DS.DataSetThatyia();
                Dst.Tables["PrintDocument"].Clear();
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    Dst.Tables["PrintDocument"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                        Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5],
                        Dt.Rows[i][6], Dt.Rows[i][7], Dt.Rows[i][8]);
                }
                REPORTS.ReportsViewer frm = new REPORTS.ReportsViewer();
                REPORTS.PrintDocument2Test2 rpt = new REPORTS.PrintDocument2Test2();

                rpt.Parameters["UserName"].Value = Properties.Settings.Default.UserNameLogin.ToString();
                rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");


                for (int i = 0; i < rpt.Parameters.Count; i++)
                {
                    rpt.Parameters[i].Visible = false;
                }


                rpt.DataSource = Dst;
                rpt.RequestParameters = false;
                frm.documentViewer1.DocumentSource = rpt;
                frm.ShowDialog();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void WrittingType_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void WrittingColor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void btnFontColor_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        //============================================================================================================
        //=== This function below for scanning manay images........
        private void مرافقاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            var b = TwainOperations.ScanImages();
            foreach (var Itm in b)
            {
                pathimage = Itm;
                nameimage = System.IO.Path.GetFileName(pathimage);
                newpath = Properties.Settings.Default.PathOfArchieves + nameimage;
                picsave.Load(Itm);
                picsave.Image.Save(newpath);
                archtb6.Text = newpath;
                lsv.Items.Add(archtb6.Text);

                archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                archtb3.Text = Treeone.SelectedNode.Parent.Text;
                // archtb5.Text = tb7.Text;


                archtb4.Text = tbnode1.Text;
                archtb2.Text = tb1.Text;

                CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                    archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);

            }
            CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                archtb7, archtb8, archtb9, pnarch1, lsv);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void حذفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try { 
            CLS_FRMS.Treeandthatyia archdelete = new CLS_FRMS.Treeandthatyia();
            archdelete.Thatyia2Delete(int.Parse(archtb1.Text));

            CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
            DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                archtb7, archtb8, archtb9, pnarch1, lsv);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void تسلسليToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void archbtnadd_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { 
            (Dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("[ImportNo] like '%{0}%' OR [BookNO] like '%{1}%' " +
                "OR [BookTitle] like '%{2}%' OR [FromDe] like '%{3}%' OR [ToDe] like '%{4}%' OR [BookDetails] like '%{5}%' " +
                "OR [BookNo2] like '%{6}%'", textBox1.Text,textBox1.Text,textBox1.Text,textBox1.Text,textBox1.Text,textBox1.Text
                ,textBox1.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lsv_MouseMove(object sender, MouseEventArgs e)
        {
            try { 
            if (chk_showbook.Checked == true)
            {
                if (lsv.HitTest(e.X, e.Y).Item != null && Path.GetExtension(lsv.HitTest(e.X, e.Y).Item.Text) != ".docx" && Path.GetExtension(lsv.HitTest(e.X, e.Y).Item.Text) != ".pdf" && Path.GetExtension(lsv.HitTest(e.X, e.Y).Item.Text) != ".xlsx")
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
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

      
        private void chk_showbook_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (chk_showbook.Checked == false)
                picload.Visible = false;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
            
        }

        private void lsv_DragDrop(object sender, DragEventArgs e)
        {
            try { 
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
           
            for (i = 0; i < s.Length; i++)
            {


                string file_type = Path.GetExtension(s[i]);

                if (file_type == ".jpg" || file_type == ".bmp" || file_type == ".png")
                {
                    pathimage = s[i];
                    nameimage = System.IO.Path.GetFileName(pathimage);
                    newpath = Properties.Settings.Default.PathOfArchieves + nameimage;
                    picsave.Load(pathimage);
                    picsave.Image.Save(newpath);


                    archtb6.Text = newpath;
                    lsv.Items.Add(archtb6.Text);

                    archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                    archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    archtb3.Text = Treeone.SelectedNode.Parent.Text;
                    archtb4.Text = tbnode1.Text;
                    archtb2.Text = tb1.Text;
                    CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                    archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                        archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);
                }
                else
                {
                    string filename = Path.GetFileName(s[i]);
                    newpath = Properties.Settings.Default.pathofDocument + filename;
                    File.Copy(s[i], newpath);

                    Random x = new Random();
                    filename = Properties.Settings.Default.pathofDocument + x.Next().ToString() + Path.GetExtension(s[i]);

                    File.Move(newpath, filename);

                    archtb6.Text = filename;
                    lsv.Items.Add(archtb6.Text);

                    archtb8.Text = DateTime.Now.ToString("HH:MM tt");
                    archtb9.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    archtb3.Text = Treeone.SelectedNode.Parent.Text;


                    archtb4.Text = tbnode1.Text;
                    archtb2.Text = tb1.Text;
                    CLS_FRMS.Treeandthatyia archadding = new CLS_FRMS.Treeandthatyia();
                    archadding.Thatyia2Adding(int.Parse(archtb2.Text), archtb3.Text, int.Parse(archtb4.Text), archtb5.Text,
                        archtb6.Text, archtb7.Text, archtb8.Text, archtb9.Text);

                }
                CLS_FRMS.Treeandthatyia Getarchive = new CLS_FRMS.Treeandthatyia();
                DataTable Dt = Getarchive.thatyia2select(int.Parse(tb1.Text), archtb1, archtb2, archtb3, archtb4, archtb5, archtb6,
                    archtb7, archtb8, archtb9, pnarch1, lsv);
            }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void lsv_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Guidthatyia_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.WindowState = FormWindowState.Maximized;
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            cm.Position = Dtcm.Rows.Count;
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            cm.Position += 1;
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            cm.Position -= 1;
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            cm.Position = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                CLS_FRMS.CLS_BookReciveInternal sendbook = new CLS_FRMS.CLS_BookReciveInternal();
                if (tb5.Visible == false && tb7.Visible == true)
                    sendbook.SendBook(int.Parse(tb1.Text),int.Parse(tb7.Text), tb8.Text, tb14.Text, tb15.Text, tb16.Text, cmbSendTo.Text, tb17.Text);
                else
                    sendbook.SendBook(int.Parse(tb1.Text),int.Parse(tb5.Text), tb6.Text, tb14.Text, tb15.Text, tb16.Text, cmbSendTo.Text, tb17.Text);
                MessageBox.Show("تم الارسال الى "+ cmbSendTo.Text);
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }

        private void lb21_Click(object sender, EventArgs e)
        {

        }

        private void طباعةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
            Process p = new Process();
            p.StartInfo.FileName = archtb6.Text;
            p.StartInfo.Verb = "Print";
            p.Start();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }

        }

        private void lsv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnPrintPurch_Click(object sender, EventArgs e)
        {
           
        }



        //===============================================================================================================

    }

}
