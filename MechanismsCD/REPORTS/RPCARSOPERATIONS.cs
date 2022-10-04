using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using System.Data;
using System.Data.SqlClient;



namespace MechanismsCD.REPORTS
{
    public partial class RPCARSOPERATIONS : Form
    {
        public RPCARSOPERATIONS()
        {
            InitializeComponent();
          
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RPCARSOPERATIONS_Load(object sender, EventArgs e)
        {
          
       
        }

        private void btnpreview_Click(object sender, EventArgs e)
        {
            if (btntitle.ButtonText == "حركة العجلات")
            {

                        if (rpcmsearching1.Text == "رقم عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmCarNo(DgvRpCars, rpcm1.Text, rpcm2.Text, rpcm8.Text, rpcm9.Text);

                        }
                        else if (rpcmsearching1.Text == "حركة بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmBetweenTowDate(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "نوع العجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmCarType(DgvRpCars, rpcm2.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "الجهة المقصودة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmDistenation(DgvRpCars, rpcm5.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "اسم السائق")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmDriverName(DgvRpCars, rpcm3.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "الجهة المستفيدة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmBeneficiary(DgvRpCars, rpcm6.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "الحالة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RpcmTheType(DgvRpCars, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "حالة وجهة مستفيدة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmTheTypeAndBeneficiary(DgvRpCars, rpcm6.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "حالة وجهة مقصودة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmTheTypeAndDistenation(DgvRpCars, rpcm5.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "حالة واسم سائق")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RpcmTheTypeAndDrivername(DgvRpCars, rpcm3.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "حالة ورقم عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RpcmTheTypeAndCar(DgvRpCars, rpcm1.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "خلاصة الجهات المستفيدة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmSummaryBeneficiary(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "خلاصة الجهات المقصودة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmSummarydistenation(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "خلاصة التناكر")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmSummaryTankers(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "ساعات عمل عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmCarHour(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "ساعات عمل سائق")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmDriverHours(DgvRpCars, rpcm3.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "ساعات عمل العجلات")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RpcmSummaryCarsHours(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "ساعات عمل السواق")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.RpcmSummaryDriversHours(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
            }
            else if (btntitle.ButtonText == "الوقود")
            {
                        if (rpcmsearching1.Text == "عجلة بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.rpcfCarNoBetweentowDate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.rpcfbetweentowdate(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if(rpcmsearching1.Text=="اجمالي عجلات")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.rpcfSummaryFuel(DgvRpCars, rpcm8.Text, rpcm9.Text);
                        }
                        else if(rpcmsearching1.Text=="اجمالي عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetData.rpcfSummaryCarNo(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
            }
            else if(btntitle.ButtonText=="حوادث العجلات")
            {
                        if (rpcmsearching1.Text=="بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetDate = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetDate.rpcabetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if(rpcmsearching1.Text=="عجلة بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.rpcaCarNO(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
            }
            else if(btntitle.ButtonText=="موقف العجلات")
            {
                        if (rpcmsearching1.Text == "بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS GetDate = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = GetDate.rpcsbetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "عجلة بين تاريخين")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.rpcsCarNObetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
            }
            else if (btntitle.ButtonText == "العدادات")
            {
                        if(rpcmsearching1.Text=="عدادات عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RPCCcCarNoBetween(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if(rpcmsearching1.Text=="مسافة عجلة")
                        {
                         CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                         DataTable Dt = Getdata.RPCCcCarDistance(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "مسافة عجلات")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RPCCcCarsDistance(DgvRpCars,rpcm8.Text, rpcm9.Text);
                        }
                        else if (rpcmsearching1.Text == "مراقب زيت محرك عجلة")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RPCCcCarAdvisor(DgvRpCars,rpcm1.Text);
                        }
                        else if (rpcmsearching1.Text == "مراقب زيت عجلات")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RPCCcCarAdvisor2(DgvRpCars);
                        }
                        else if (rpcmsearching1.Text == "بحث في مراقب زيت العجلات")
                        {
                            CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                            DataTable Dt = Getdata.RPCCCaradvisor4(DgvRpCars, rpcm3.Text, rpcm4.Text, rpcm5.Text);
                        }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (btntitle.ButtonText == "حركة العجلات")
            {

                CLS_FRMS.CLSRPCARSOPERATIONS getform = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    getform.ContentCarNoBetween(DgvRpCars, rpcm1, rpcm2, rpcm3, rpcm4, rpcm5, rpcm6, rpcm7, rpcm8, rpcm9, rpcmsearching1, rpcmsearching2
                    , lb1, lb2, lb3, lb4, lb5, lb6, lb7, lb8, lb9, btnpreview, btnprint);
            }
            else if (btntitle.ButtonText == "الوقود")
            {
                CLS_FRMS.CLSRPCARSOPERATIONS Getform = new CLS_FRMS.CLSRPCARSOPERATIONS();
                Getform.ContentCarFuels(DgvRpCars,rpcm1, rpcm2, rpcm8, rpcm9,rpcmsearching1,rpcmsearching2,lb1,lb2,lb8,lb9,btnpreview,btnprint);
            }
            else if (btntitle.ButtonText=="حوادث العجلات")
            {
                CLS_FRMS.CLSRPCARSOPERATIONS GetForm = new CLS_FRMS.CLSRPCARSOPERATIONS();
                GetForm.ContentCarAccident(DgvRpCars, rpcm1, rpcm2, rpcm8, rpcm9, rpcmsearching1, rpcmsearching2, lb1, lb2, lb8, lb9, btnpreview, btnprint);
            }
            else if (btntitle.ButtonText=="موقف العجلات")
            {
                CLS_FRMS.CLSRPCARSOPERATIONS Getform = new CLS_FRMS.CLSRPCARSOPERATIONS();
                Getform.ContentCarSituation(DgvRpCars, rpcm1, rpcm2, rpcm8, rpcm9, rpcmsearching1, rpcmsearching2, lb1, lb2, lb8, lb9, btnpreview, btnprint);
            }
            else if (btntitle.ButtonText == "العدادات")
            {
                CLS_FRMS.CLSRPCARSOPERATIONS GetForm = new CLS_FRMS.CLSRPCARSOPERATIONS();
                GetForm.ContentCarsCounters(DgvRpCars, rpcm1, rpcm2, rpcm3, rpcm4, rpcm5, rpcm8, rpcm9, rpcmsearching1, rpcmsearching2, lb1, lb2, lb3, lb4, lb5, lb8, lb9
                    , btnpreview, btnprint);
            }
           
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (btntitle.ButtonText == "حركة العجلات")
            {

                if (rpcmsearching1.Text == "رقم عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    if(rpcm2.Text=="تنكر استرا" || rpcm2.Text=="تنكر مان" || rpcm2.Text=="ساحبة مان" || rpcm2.Text == "ساحبة استرا" || rpcm2.Text == "تنكر هونداي"
                         || rpcm2.Text=="ساحبة هونداي" || rpcm2.Text=="تنكر هينو")
                    {
                        DataTable Dt = new DataTable();
                        Dt=GetData.RpcmCarNo(DgvRpCars, rpcm1.Text, rpcm2.Text, rpcm8.Text, rpcm9.Text);
                        DS.DataSetCars dscar = new DS.DataSetCars();
                        dscar.Tables["CarNoBetween"].Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dscar.Tables["CarNoBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                                Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10],Dt.Rows[i][11]
                                ,Dt.Rows[i][12]);
                        }

                        REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                        M_CarNoBetween rpt = new M_CarNoBetween();

                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt.Parameters["UserName"].Value = "RegisterName";
                        rpt.Parameters["Date1"].Value = rpcm8.Value;
                        rpt.Parameters["Date2"].Value = rpcm9.Value;
                        int sum = 0;
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                        }
                        
                        rpt.Parameters["TotalTrans"].Value = sum;
                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }

                        rpt.DataSource = dscar;
                        rpt.RequestParameters = false;
                        rfrm.documentViewer1.DocumentSource = rpt;
                        rfrm.ShowDialog();
                    }
                    else
                    {
                        DataTable Dt = new DataTable();
                        Dt = GetData.RpcmCarNo(DgvRpCars, rpcm1.Text, rpcm2.Text, rpcm8.Text, rpcm9.Text);
                        DS.DataSetCars dscar = new DS.DataSetCars();
                        dscar.Tables["CarNoBetween1"].Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dscar.Tables["CarNoBetween1"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                                Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10]
                                );
                        }

                        REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                        M_CarNoBetween1 rpt = new M_CarNoBetween1();

                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt.Parameters["UserName"].Value = "RegisterName";
                        rpt.Parameters["Date1"].Value = rpcm8.Value;
                        rpt.Parameters["Date2"].Value = rpcm9.Value;
                        rpt.Parameters["TotalTrans"].Value = Dt.Rows.Count ;
                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }

                        rpt.DataSource = dscar;
                        rpt.RequestParameters = false;
                        rfrm.documentViewer1.DocumentSource = rpt;
                        rfrm.ShowDialog();
                    }
                   
                }
                else if (rpcmsearching1.Text == "حركة بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmBetweenTowDate(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10],Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_MovementBetween rpt = new M_MovementBetween();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                
                }
                else if (rpcmsearching1.Text == "نوع العجلة")
                {

                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    if (rpcm2.Text == "تنكر استرا" || rpcm2.Text == "تنكر مان" || rpcm2.Text == "ساحبة مان" || rpcm2.Text == "ساحبة استرا" || rpcm2.Text == "تنكر هونداي"
                         || rpcm2.Text == "ساحبة هونداي" || rpcm2.Text == "تنكر هينو")
                    {


                        DataTable Dt = new DataTable();
                        Dt = GetData.RpcmCarType(DgvRpCars, rpcm2.Text, rpcm8.Text, rpcm9.Text);
                        DS.DataSetCars dscar = new DS.DataSetCars();
                        dscar.Tables["MovementBetween"].Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                                Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                                Dt.Rows[i][12]
                                );
                        }

                        REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                        M_CarType rpt = new M_CarType();

                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt.Parameters["UserName"].Value = "RegisterName";
                        rpt.Parameters["Date1"].Value = rpcm8.Value;
                        rpt.Parameters["Date2"].Value = rpcm9.Value;
                        rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                        int sum = 0;
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                        }
                        rpt.Parameters["TotalTrans"].Value = sum;

                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }

                        rpt.DataSource = dscar;
                        rpt.RequestParameters = false;
                        rfrm.documentViewer1.DocumentSource = rpt;
                        rfrm.ShowDialog();
                    }
                    else
                    {
                        DataTable Dt = new DataTable();
                        Dt = GetData.RpcmCarType(DgvRpCars, rpcm2.Text, rpcm8.Text, rpcm9.Text);
                        DS.DataSetCars dscar = new DS.DataSetCars();
                        dscar.Tables["MovementBetween"].Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                                Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10]
                                );
                        }

                        REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                        M_CarType2 rpt = new M_CarType2();

                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt.Parameters["UserName"].Value = "RegisterName";
                        rpt.Parameters["Date1"].Value = rpcm8.Value;
                        rpt.Parameters["Date2"].Value = rpcm9.Value;
                        rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                        
                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }

                        rpt.DataSource = dscar;
                        rpt.RequestParameters = false;
                        rfrm.documentViewer1.DocumentSource = rpt;
                        rfrm.ShowDialog();
                    }
                }
                else if (rpcmsearching1.Text == "الجهة المقصودة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmDistenation(DgvRpCars, rpcm5.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_Distenation rpt = new M_Distenation();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "اسم السائق")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmDriverName(DgvRpCars, rpcm3.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_DriverName rpt = new M_DriverName();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                   
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "الجهة المستفيدة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmBeneficiary(DgvRpCars, rpcm6.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TheBeneficiary rpt = new M_TheBeneficiary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                else if (rpcmsearching1.Text == "الحالة")
                {
                       CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                        DataTable Dt = new DataTable();
                        Dt = Getdata.RpcmTheType(DgvRpCars, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                        DS.DataSetCars dscar = new DS.DataSetCars();
                        dscar.Tables["MovementBetween"].Clear();
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                                Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                                Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                                Dt.Rows[i][12]
                                );
                        }

                        REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                        M_TheType rpt = new M_TheType();

                        rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                        rpt.Parameters["UserName"].Value = "RegisterName";
                        rpt.Parameters["Date1"].Value = rpcm8.Value;
                        rpt.Parameters["Date2"].Value = rpcm9.Value;
                        rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                        int sum = 0;
                        for (int i = 0; i < Dt.Rows.Count; i++)
                        {
                            sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                        }
                        rpt.Parameters["TotalTrans"].Value = sum;

                        for (int i = 0; i < rpt.Parameters.Count; i++)
                        {
                            rpt.Parameters[i].Visible = false;
                        }
                        rpt.DataSource = dscar;
                        rpt.RequestParameters = false;
                        rfrm.documentViewer1.DocumentSource = rpt;
                        rfrm.ShowDialog();
                   
                                    

                }
                else if (rpcmsearching1.Text == "حالة وجهة مستفيدة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmTheTypeAndBeneficiary(DgvRpCars, rpcm6.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TheTypeAndBeneficiary rpt = new M_TheTypeAndBeneficiary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                else if (rpcmsearching1.Text == "حالة وجهة مقصودة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmTheTypeAndDistenation(DgvRpCars, rpcm5.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TheTypeAndDistenation rpt = new M_TheTypeAndDistenation();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "حالة واسم سائق")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RpcmTheTypeAndDrivername(DgvRpCars, rpcm3.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TheTypeAndDriverName rpt = new M_TheTypeAndDriverName();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MovementCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                else if (rpcmsearching1.Text == "حالة ورقم عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RpcmTheTypeAndCar(DgvRpCars, rpcm1.Text, rpcm4.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["MovementBetween"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["MovementBetween"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9], Dt.Rows[i][10], Dt.Rows[i][11],
                            Dt.Rows[i][12]
                            );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TheTypeAndCar rpt = new M_TheTypeAndCar();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["MoveCounts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][11].ToString());
                    }
                    rpt.Parameters["TotalTrans"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "خلاصة الجهات المستفيدة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmSummaryBeneficiary(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["M_BeneficiarySummary"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["M_BeneficiarySummary"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1] );
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_BeneficiarySummary rpt = new M_BeneficiarySummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["Counts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][1].ToString());
                    }
                    rpt.Parameters["TotalMovements"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "خلاصة الجهات المقصودة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmSummarydistenation(DgvRpCars, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["M_BeneficiarySummary"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["M_BeneficiarySummary"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_DistenationSummary rpt = new M_DistenationSummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["Counts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][1].ToString());
                    }
                    rpt.Parameters["TotalMovements"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "خلاصة التناكر")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmSummaryTankers(DgvRpCars, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["TankerSummary"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["TankerSummary"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]
                            ,Dt.Rows[i][2]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_TankerSummary rpt = new M_TankerSummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    rpt.Parameters["Counts"].Value = Dt.Rows.Count;
                    int sum = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][2].ToString());
                    }
                    rpt.Parameters["TotalMovements"].Value = sum;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "ساعات عمل عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmCarHour(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarHours"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarHours"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]
                            , Dt.Rows[i][2],Dt.Rows[i][3],Dt.Rows[i][4],Dt.Rows[i][5]
                            ,Dt.Rows[i][6]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_CarHours rpt = new M_CarHours();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                   

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                else if (rpcmsearching1.Text == "ساعات عمل سائق")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmDriverHours(DgvRpCars, rpcm3.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["DriverHours"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["DriverHours"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]
                            , Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5]
                            , Dt.Rows[i][6]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_DriverHours rpt = new M_DriverHours();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;


                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "ساعات عمل العجلات")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= Getdata.RpcmSummaryCarsHours(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["SummaryCarHours"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["SummaryCarHours"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]
                            , Dt.Rows[i][2], Dt.Rows[i][3]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_CarHoursSummary rpt = new M_CarHoursSummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;


                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                else if (rpcmsearching1.Text == "ساعات عمل السواق")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=GetData.RpcmSummaryDriversHours(DgvRpCars, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["SummaryDriverHours"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["SummaryDriverHours"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1]
                            , Dt.Rows[i][2]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    M_DriverHoursSummary rpt = new M_DriverHoursSummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;


                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }
                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
            }
            //==============================
            //===== Start of Fuel Reporting......
          

            else if (btntitle.ButtonText == "الوقود")
            {
                //======Report one
                if (rpcmsearching1.Text == "عجلة بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt = GetData.rpcfCarNoBetweentowDate(DgvRpCars,rpcm1.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["FuelBetweenTowDate"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["FuelBetweenTowDate"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    FuelCarBetweenTowDate rpt = new FuelCarBetweenTowDate();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["BillCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    int sum = 0, sum2 = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][7].ToString());
                        sum2 = sum2 + int.Parse(Dt.Rows[i][6].ToString());
                    }
                    rpt.Parameters["BillsNumbers"].Value = int.Parse(Dt.Rows.Count.ToString());
                    rpt.Parameters["QuantityTotal"].Value = sum2;
                    rpt.Parameters["TotalMoney"].Value = sum;
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                //====== Report Tow
                else if (rpcmsearching1.Text == "بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= GetData.rpcfbetweentowdate(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["FuelBetweenTowDate"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["FuelBetweenTowDate"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6],
                            Dt.Rows[i][7], Dt.Rows[i][8], Dt.Rows[i][9]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    FuelBetweenTowDate rpt = new FuelBetweenTowDate();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["BillCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    int sum = 0,sum2=0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][7].ToString());
                        sum2 = sum2 + int.Parse(Dt.Rows[i][6].ToString());
                    }
                    rpt.Parameters["BillsNumbers"].Value =int.Parse( Dt.Rows.Count.ToString()) ;
                    rpt.Parameters["QuantityTotal"].Value =sum2;
                    rpt.Parameters["TotalMoney"].Value = sum;
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                //========= Report Three ..
                else if (rpcmsearching1.Text == "اجمالي عجلات")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                     Dt= GetData.rpcfSummaryFuel(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["FuelSummary"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["FuelSummary"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    FuelSummary rpt = new FuelSummary();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["BillCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                    int sum = 0, sum2 = 0;
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        sum = sum + int.Parse(Dt.Rows[i][3].ToString());
                        sum2 = sum2 + int.Parse(Dt.Rows[i][2].ToString());
                    }
                    rpt.Parameters["BillsNumbers"].Value = int.Parse(Dt.Rows.Count.ToString());
                    rpt.Parameters["QuantityTotal"].Value = sum2;
                    rpt.Parameters["TotalMoney"].Value = sum;
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                //================ Report Four...
                else if (rpcmsearching1.Text == "اجمالي عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetData = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = GetData.rpcfSummaryCarNo(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["FuelSummary"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["FuelSummary"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    FuelSummaryCarNo rpt = new FuelSummaryCarNo();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["BillCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                   
                  
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                // ==== =========
            }
            // ===== End of Fuel Reporting........
            //====================================
            //===== Start Report of CarAccidents.....
            else if (btntitle.ButtonText == "حوادث العجلات")
            {
                //==== Report one..
                if (rpcmsearching1.Text == "بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetDate = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= GetDate.rpcabetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarAccidents"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarAccidents"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarAccident1 rpt = new CarAccident1();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["AccidentCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;
                  
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                else if (rpcmsearching1.Text == "عجلة بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= Getdata.rpcaCarNO(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarAccidents"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarAccidents"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarAccident2 rpt = new CarAccident2();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["AccidentCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                } //  
                // End Report of Accident......
            }  
            //= Start Report of Car Situations.......
            else if (btntitle.ButtonText == "موقف العجلات")
            {
                if (rpcmsearching1.Text == "بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS GetDate = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable(); 
                    Dt = GetDate.rpcsbetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarSituations"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarSituations"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6]
                            ,Dt.Rows[i][7]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarSituations1 rpt = new CarSituations1();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["CarCounts"].Value = Dt.Rows.Count;
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();


                }
                else if (rpcmsearching1.Text == "عجلة بين تاريخين")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= Getdata.rpcsCarNObetweentowdate(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);

                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarSituations"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarSituations"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4], Dt.Rows[i][5], Dt.Rows[i][6]
                            , Dt.Rows[i][7]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarSituations2 rpt = new CarSituations2();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Value;
                    rpt.Parameters["Date2"].Value = rpcm9.Value;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
            }
            //  End Report of Car Situations ....

            //  Start Report of Counters of Cars............
            else if (btntitle.ButtonText == "العدادات")
            {
                if (rpcmsearching1.Text == "عدادات عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RPCCcCarNoBetween(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarCounters"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarCounters"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarCounters rpt = new CarCounters();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Text;
                    rpt.Parameters["Date2"].Value = rpcm9.Text;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                else if (rpcmsearching1.Text == "مسافة عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RPCCcCarDistance(DgvRpCars, rpcm1.Text, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarDistance"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarDistance"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarDistance rpt = new CarDistance();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Text;
                    rpt.Parameters["Date2"].Value = rpcm9.Text;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();



                }
                else if (rpcmsearching1.Text == "مسافة عجلات")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RPCCcCarsDistance(DgvRpCars, rpcm8.Text, rpcm9.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarDistance1"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarDistance1"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarDistance2 rpt = new CarDistance2();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["Date1"].Value = rpcm8.Text;
                    rpt.Parameters["Date2"].Value = rpcm9.Text;
                    rpt.Parameters["CarCounts"].Value = Dt.Rows.Count;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();



                }
                else if (rpcmsearching1.Text == "مراقب زيت محرك عجلة")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt= Getdata.RPCCcCarAdvisor(DgvRpCars, rpcm1.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarAdvisor"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarAdvisor"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarAdvisor1 rpt = new CarAdvisor1();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    
                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();

                }
                else if (rpcmsearching1.Text == "مراقب زيت عجلات")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RPCCcCarAdvisor2(DgvRpCars);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarAdvisor"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarAdvisor"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarAdvisor2 rpt = new CarAdvisor2();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["CarCounts"].Value = Dt.Rows.Count;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
                else if (rpcmsearching1.Text == "بحث في مراقب زيت العجلات")
                {
                    CLS_FRMS.CLSRPCARSOPERATIONS Getdata = new CLS_FRMS.CLSRPCARSOPERATIONS();
                    DataTable Dt = new DataTable();
                    Dt=Getdata.RPCCCaradvisor4(DgvRpCars, rpcm3.Text, rpcm4.Text, rpcm5.Text);
                    DS.DataSetCars dscar = new DS.DataSetCars();
                    dscar.Tables["CarAdvisor"].Clear();
                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        dscar.Tables["CarAdvisor"].Rows.Add(Dt.Rows[i][0], Dt.Rows[i][1],
                            Dt.Rows[i][2], Dt.Rows[i][3], Dt.Rows[i][4]);
                    }

                    REPORTS.ReportsViewer rfrm = new REPORTS.ReportsViewer();
                    CarAdvisor4 rpt = new CarAdvisor4();

                    rpt.Parameters["DateToDay"].Value = DateTime.Now.ToString("yyyy/MM/dd");
                    rpt.Parameters["UserName"].Value = "RegisterName";
                    rpt.Parameters["CarCounts"].Value = Dt.Rows.Count;

                    for (int i = 0; i < rpt.Parameters.Count; i++)
                    {
                        rpt.Parameters[i].Visible = false;
                    }

                    rpt.DataSource = dscar;
                    rpt.RequestParameters = false;
                    rfrm.documentViewer1.DocumentSource = rpt;
                    rfrm.ShowDialog();
                }
            }//  Rnd the Report of Counters.......
        }
    }
}
