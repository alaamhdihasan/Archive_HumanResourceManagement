using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using System.Globalization;


namespace MechanismsCD.FRMS
{
    public partial class FRMBARCODESYSTEM : Form
    {
        public FRMBARCODESYSTEM()
        {
            InitializeComponent();
            btnrefreshBarcodesys.Visible = false;
            btngoingbarcodesys.Visible = false;
            btncommingbarcodesys.Visible = false;
        }

        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BarcodeSearching_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ControlButtonsGetdata();
               

            }
        }
        //------ This Function For Control of Buttons Going and Comming  And Gettind Data From CarsMovemets Table----------------------------
        //---------Barcode System InterFace--------------------------------------------------
        public void ControlButtonsGetdata()
        {
            CLS_FRMS.CLSBARCODESYSTEM getdata = new CLS_FRMS.CLSBARCODESYSTEM();
            CLS_FRMS.CLSCARS GetData2 = new CLS_FRMS.CLSCARS();

            DataTable Dt = getdata.BarcodesystemGetdata(BarcodeSearching.Text, DgvBarcodesystem, BarcodeCarNO, BarcodeCarType, BarcodeCarBrand, BarcodeCarBarcode
            , BarcodeCarLine, BarcodeCarDistenation, BarcodeCarBeneficiary, BarcodeCarTheType, CarNOtxt, CarTypetxt, tbtimego
            , tbdrivergo, tbtimeback, tbdriverback, cbothetype2, cbonamecustomer, cbodistenation2, cbobeneficiary2, tbnotice2
            , tbregistername2,tbregistername3, nowdatetxt, tbseqbarcode, Barcodetranscount, cbowatertype);

            DataTable Dt2 = GetData2.CarsDivisionByCarNo(BarcodeSearching.Text);


            if (Dt.Rows.Count == 0)
            {
                if(Dt2.Rows.Count == 0 || Dt2.Rows.Count.ToString() is null)
                {
                    MessageBox.Show("لا توجد هكذا عجلة ", "خطأ مدخل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    btngoingbarcodesys.Visible = true;
                }
                   

            }


            else if (Dt.Rows[0][10].ToString() != "" && Dt.Rows[0][12].ToString() == "")
            {
                btngoingbarcodesys.Visible = false;
                btncommingbarcodesys.Visible = true;
                btnrefreshBarcodesys.ButtonText = "حفظ التعويد";

            }
            else if (Dt.Rows[0][10].ToString() != "" && Dt.Rows[0][12].ToString() != "")
            {
                btngoingbarcodesys.Visible = true;
                btncommingbarcodesys.Visible = false;
                btnrefreshBarcodesys.ButtonText = "حفظ التخريج";

            }
            else if (Dt.Rows[0][10].ToString() == "" && Dt.Rows[0][12].ToString() == "")
            {
                btngoingbarcodesys.Visible = true;
                btncommingbarcodesys.Visible = false;
                btnrefreshBarcodesys.ButtonText = "حفظ التخريج";
            }

        }

        //----------- Event Of Going Operation-------------------Barcode System InterFace-----------------------------------------------
        private void btngoingbarcodesys_Click(object sender, EventArgs e)
        {
            tmDgvCarmovement.Start();
            FRM_LOGIN fL = new FRM_LOGIN();
            if (tbtimego.Text != "" && tbtimeback.Text != "" || tbtimego.Text == "" && tbtimeback.Text == "")
            {
                CLS_FRMS.CLSBARCODESYSTEM clscon = new CLS_FRMS.CLSBARCODESYSTEM();
                clscon.FillCboDate(cbothetype2, cbonamecustomer, cbodistenation2, cbobeneficiary2);

                CarNOtxt.Text = BarcodeCarNO.Text;
                CarTypetxt.Text = BarcodeCarType.Text;
                CultureInfo cultures = new CultureInfo("en-us");


                tbtimego.Text = DateTime.Now.ToString(cultures);
                tbdrivergo.Text = "";
                tbdriverback.Text = "";
                tbtimeback.Text = "";
                tbdriverback.Text = "";
                driver1.Focus();
                cbothetype2.Text = BarcodeCarTheType.Text;
                cbodistenation2.Text = BarcodeCarDistenation.Text;
                cbobeneficiary2.Text = BarcodeCarBeneficiary.Text;
                cbonamecustomer.Text = BarcodeCarLine.Text;
                Barcodetranscount.Text = "0";
                cbowatertype.Text = "";
                tbregistername2.Text = fL.UserNametxt.Text ;
                tbregistername3.Text = "";
                nowdatetxt.Text = DateTime.Now.ToString(cultures);
                btnrefreshBarcodesys.Visible = true;
            }
            else if (tbtimego.Text != "" && tbtimeback.Text == "")
            {
                MessageBox.Show("يحب تعويد العجلة أولاً ", "رسالة تحذيرية", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //-------- Button of fill the tbtimeback for record the comming Car -----------Barcode System InterFace
        private void btncommingbarcodesys_Click(object sender, EventArgs e)
        {
            FRM_LOGIN fL = new FRM_LOGIN();
            CultureInfo cultures = new CultureInfo("en-us");
            tbtimeback.Text = DateTime.Now.ToString(cultures);
            nowdatetxt.Text = DateTime.Now.ToString(cultures);
            tbdriverback.Text = "";
            tbregistername3.Text =fL.UserNametxt.Text;
            driver2.Focus();
            btnrefreshBarcodesys.Visible = true;
        }
        //================= Events Of Saving Buttons======================================================================================================
        private void btnrefreshBarcodesys_Click(object sender, EventArgs e)
        {
            if (btngoingbarcodesys.Visible == true && btncommingbarcodesys.Visible == false)
            {
                //---------- Insert Date In To The CarsMovements Table--------------------Barcode System InterFace
                CLS_FRMS.CLSBARCODESYSTEM insertData = new CLS_FRMS.CLSBARCODESYSTEM();
                insertData.CarsmovementsInsertData(CarNOtxt.Text, CarTypetxt.Text, tbtimego.Text, tbdrivergo.Text, tbtimeback.Text, tbdriverback.Text
                , cbothetype2.Text, cbonamecustomer.Text, cbodistenation2.Text, cbobeneficiary2.Text, tbnotice2.Text, tbregistername2.Text,tbregistername3.Text
                , nowdatetxt.Text, Convert.ToDouble(Barcodetranscount.Text), cbowatertype.Text);
                

                insertData.BarcodesystemGetdata(BarcodeSearching.Text, DgvBarcodesystem, BarcodeCarNO, BarcodeCarType, BarcodeCarBrand, BarcodeCarBarcode
                , BarcodeCarLine, BarcodeCarDistenation, BarcodeCarBeneficiary, BarcodeCarTheType, CarNOtxt, CarTypetxt, tbtimego
                , tbdrivergo, tbtimeback, tbdriverback, cbothetype2, cbonamecustomer, cbodistenation2, cbobeneficiary2, tbnotice2
                , tbregistername2,tbregistername3, nowdatetxt, tbseqbarcode, Barcodetranscount, cbowatertype);

                ControlButtonsGetdata();
                btnrefreshBarcodesys.Visible = false;

            }

            else if (btngoingbarcodesys.Visible == false && btncommingbarcodesys.Visible == true)
            {
                // -------- UpdateData In To The CarsMovements Table-----------------Barcode System InterFace
                CLS_FRMS.CLSBARCODESYSTEM updatedata = new CLS_FRMS.CLSBARCODESYSTEM();
                updatedata.CarsMovementsUpdateDate(Convert.ToInt32(tbseqbarcode.Text), CarNOtxt.Text, CarTypetxt.Text, tbtimego.Text, tbdrivergo.Text, tbtimeback.Text, tbdriverback.Text
               , cbothetype2.Text, cbonamecustomer.Text, cbodistenation2.Text, cbobeneficiary2.Text, tbnotice2.Text, tbregistername2.Text,tbregistername3.Text
               , nowdatetxt.Text, Convert.ToDouble(Barcodetranscount.Text), cbowatertype.Text);
               
              updatedata.BarcodesystemGetdata(BarcodeSearching.Text, DgvBarcodesystem, BarcodeCarNO, BarcodeCarType, BarcodeCarBrand, BarcodeCarBarcode
            , BarcodeCarLine, BarcodeCarDistenation, BarcodeCarBeneficiary, BarcodeCarTheType, CarNOtxt, CarTypetxt, tbtimego
            , tbdrivergo, tbtimeback, tbdriverback, cbothetype2, cbonamecustomer, cbodistenation2, cbobeneficiary2, tbnotice2
            , tbregistername2,tbregistername3, nowdatetxt, tbseqbarcode, Barcodetranscount, cbowatertype);

                ControlButtonsGetdata();
                btnrefreshBarcodesys.Visible = false;
            }

        }

        private void DgvBarcodesystem_SelectionChanged(object sender, EventArgs e)
        {
            tmDgvCarmovement.Start();
        }
        //-------Function OF Security of TextBoxes Barcode System InterFace-----------================================================================
        private void tmDgvCarmovement_Tick(object sender, EventArgs e)
        {
            if (tbtimego.Text != "" && tbtimeback.Text == "")
            {
                CarNOtxt.Enabled = false;
                CarTypetxt.Enabled = false;

                cbothetype2.Enabled = true;
                cbonamecustomer.Enabled = true;
                cbodistenation2.Enabled = true;
                cbobeneficiary2.Enabled = true;
                tbnotice2.Enabled = true;


            }
            if (tbtimeback.Text != "" && tbtimego.Text != "")
            {

                cbothetype2.Enabled = false;
                cbonamecustomer.Enabled = false;
                cbodistenation2.Enabled = false;
                cbobeneficiary2.Enabled = false;
                tbnotice2.Enabled = false;


            }
            tmDgvCarmovement.Stop();
        }
        //------ This Function For Combobox's Tankers------------------Barcode System InterFace============================================================
        private void cbothetype2_TextChanged(object sender, EventArgs e)
        {
            if (cbothetype2.Text == "حوضيات")
            {
                Barcodetranscount.Enabled = true;
                cbowatertype.Enabled = true;
                label38.Enabled = true;
                label39.Enabled = true;
            }
            else
            {
                Barcodetranscount.Enabled = false;
                cbowatertype.Enabled = false;
                label38.Enabled = false;
                label39.Enabled = false;
            }
        }

        //------- This Timer for Getting data from Carsmovements Table---------------Barcode System InterFace
       
        private void tmbarcodedata_Tick_1(object sender, EventArgs e)
        {
            CLS_FRMS.CLSBARCODESYSTEM getdata = new CLS_FRMS.CLSBARCODESYSTEM();

            DataTable Dt = getdata.BarcodesystemGetdata(BarcodeSearching.Text, DgvBarcodesystem, BarcodeCarNO, BarcodeCarType, BarcodeCarBrand, BarcodeCarBarcode
            , BarcodeCarLine, BarcodeCarDistenation, BarcodeCarBeneficiary, BarcodeCarTheType, CarNOtxt, CarTypetxt, tbtimego
            , tbdrivergo, tbtimeback, tbdriverback, cbothetype2, cbonamecustomer, cbodistenation2, cbobeneficiary2, tbnotice2
            , tbregistername2,tbregistername3, nowdatetxt, tbseqbarcode, Barcodetranscount, cbowatertype);

            tmbarcodedata.Stop();
        }

       
    }
}
