using System;
using System.Windows.Forms;


namespace MechanismsCD.FRMS
{
    public partial class FRMCARSOPERATIONS : Form
    {
        public FRMCARSOPERATIONS()
        {
            InitializeComponent();
            CarsOperationsOpen();

        }
        // =========== This Function Below open CarsOperations using (CarAccident Table, CarsFuel Table, CarsCounter Table
        // and CarsSitution Table=============================================================================================
        public void CarsOperationsOpen()
        {


            if (lbtitle.Text == "الوقود")
            {
               
                pnarchivefuel.Height = 400;

                CLS_FRMS.CLSCARSOPERATIONS Hidecontent = new CLS_FRMS.CLSCARSOPERATIONS();
                Hidecontent.HideContentForm(DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
                    , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13);
                btnopenew.Visible = false;
                btnopeadd.Visible = false;
                btnopeupdate.Visible = false;
                btnopedelete.Visible = false;
                btnopeScanner.Visible = false;
                btnopeprint.Visible = false;
                btnopeimagedelete.Visible = false;
                PnCarsituation.Visible = true;
                PnDGVCarsOperations.Visible = true;
               
            }
            else
            {
                               
                pnarchivefuel.Visible = false;

                CLS_FRMS.CLSCARSOPERATIONS Hidecontent = new CLS_FRMS.CLSCARSOPERATIONS();
                Hidecontent.HideContentForm(DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
                , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13);
                btnopenew.Visible = false;
                btnopeadd.Visible = false;
                btnopeupdate.Visible = false;
                btnopedelete.Visible = false;
               
                PnCarsituation.Visible = true;
                PnDGVCarsOperations.Visible = true;
               
            }

        }


        private void btnexitapp_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        //--- Get Data From Divisioncars and Carsituation (CarsituationOperation procedure ) ===============================================
        public void CarsituationOperationsGetdata()
        {

            CLS_FRMS.CLSCARSOPERATIONS GetData = new CLS_FRMS.CLSCARSOPERATIONS();
            GetData.CarsSituationGetData(tbsearchingcarsitu.Text, DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
               , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13);
        }
        //=========================================================================================================================
        //--  Function For Get Data From CarsAccidentGetData Proceduer-----------------------------------------------------------------------
        public void CarsAccidentGetData()
        {

            CLS_FRMS.CLSCARSOPERATIONS GetData = new CLS_FRMS.CLSCARSOPERATIONS();
            GetData.CarsAccidentGetData(tbsearchingcarsitu.Text, DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
             , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13);
        }
        //-----------------------------------------------------------------------------------------------------------------------------------
        //--- Function Of Get data From CarsCounter Procedure------------------------------------------------------------------------------
        public void CarsCounterGetData()
        {

            CLS_FRMS.CLSCARSOPERATIONS GetData = new CLS_FRMS.CLSCARSOPERATIONS();
            GetData.CarsCounterGetData(tbsearchingcarsitu.Text, DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
             , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13);

        }
        //----------------------------------------------------------------------------------------------------------------------------------
        //---- Function fo Get Data From CarsFuel Tabel used CarsFuelSelectiong Procedure-----------------------------------------------------
        public void CarsFuelGetDate()
        {
            CLS_FRMS.CLSCARSOPERATIONS GetData = new CLS_FRMS.CLSCARSOPERATIONS();
            GetData.CarsFuelGettingData(tbsearchingcarsitu.Text, DGVCarsOperations, ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12
             , ope13, lbope1, lbope2, lbope3, lbope4, lbope5, lbope6, lbope7, lbope8, lbope9, lbope10, lbope11, lbope12, lbope13, picFuel);
        }

        private void tbsearchingcarsitu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbtitle.Text == "موقف العجلات")
                {

                    CarsituationOperationsGetdata();
                    btnopenew.Visible = true;
                    btnopeadd.Visible = true;
                    btnopeupdate.Visible = true;
                    btnopedelete.Visible = true;

                }
                else if (lbtitle.Text == "الحوادث")
                {
                    CarsAccidentGetData();
                    btnopenew.Visible = true;
                    btnopeadd.Visible = true;
                    btnopeupdate.Visible = true;
                    btnopedelete.Visible = true;
                }
                else if (lbtitle.Text == "العدادات")
                {
                    CarsCounterGetData();
                    btnopenew.Visible = true;
                    btnopeadd.Visible = true;
                    btnopeupdate.Visible = true;
                    btnopedelete.Visible = true;
                }
                else if (lbtitle.Text == "الوقود")
                {
                    CarsFuelGetDate();
                    btnopenew.Visible = true;
                    btnopeadd.Visible = true;
                    btnopeupdate.Visible = true;
                    btnopedelete.Visible = true;
                    pnarchivefuel.Visible = true;
                    btnopeScanner.Visible = true;
                    btnopeimagedelete.Visible = true;
                    btnopeprint.Visible = true;
                }
            }
        }

        private void btnopenew_Click(object sender, EventArgs e)
        {
            if (lbtitle.Text == "موقف العجلات")
            {
                CLS_FRMS.CLSCARSOPERATIONS cleardata = new CLS_FRMS.CLSCARSOPERATIONS();
                cleardata.CarsituationClearData(ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12);

            }
            else if (lbtitle.Text == "الحوادث")
            {
                CLS_FRMS.CLSCARSOPERATIONS Cleardata = new CLS_FRMS.CLSCARSOPERATIONS();
                Cleardata.CarAccidentClearData(ope1, ope2, ope3, ope5, ope7, ope8, ope9, ope10, ope11);

            }
            else if (lbtitle.Text == "العدادات")
            {
                CLS_FRMS.CLSCARSOPERATIONS ClearData = new CLS_FRMS.CLSCARSOPERATIONS();
                ClearData.CarsCountersClearData(ope1, ope2, ope3, ope5, ope7, ope8, ope9, ope10, ope11, ope4);

            }
            else if (lbtitle.Text == "الوقود")
            {
                CLS_FRMS.CLSCARSOPERATIONS ClearData = new CLS_FRMS.CLSCARSOPERATIONS();
                ClearData.CarsFuelClearData(ope1, ope2, ope3, ope4, ope5, ope6, ope7, ope8, ope9, ope10, ope11, ope12, ope13, picFuel);

            }




          
        }

        private void btnopeupdate_Click(object sender, EventArgs e)
        {
            if (lbtitle.Text == "موقف العجلات")
            {
                CLS_FRMS.CLSCARSOPERATIONS Updatedata = new CLS_FRMS.CLSCARSOPERATIONS();
                Updatedata.CarsituationUpdateDate(ope1.Text, ope2.Text, ope3.Text, ope4.Text, ope5.Text, ope6.Text, ope7.Text, ope8.Text, ope9.Text
                , Convert.ToInt32(ope10.Text));
                CarsituationOperationsGetdata();
            }
            else if (lbtitle.Text == "الحوادث")
            {
                CLS_FRMS.CLSCARSOPERATIONS Updatedata = new CLS_FRMS.CLSCARSOPERATIONS();
                Updatedata.CarsAccidentUpdateDate(Convert.ToInt16(ope10.Text), ope1.Text, ope2.Text, ope3.Text, ope5.Text
                , ope7.Text, ope8.Text, ope9.Text, ope11.Text);
                CarsAccidentGetData();
            }
            else if (lbtitle.Text == "العدادات")
            {
                CLS_FRMS.CLSCARSOPERATIONS Updatedata = new CLS_FRMS.CLSCARSOPERATIONS();
                Updatedata.CarsCounterUpdateDate(ope1.Text, ope2.Text, ope3.Text, ope5.Text, Convert.ToDouble(ope7.Text)
                , ope9.Text, ope10.Text, ope11.Text, Convert.ToInt32(ope8.Text),ope4.Text);
                CarsCounterGetData();
            }
            else if (lbtitle.Text == "الوقود")
            {
                CLS_FRMS.CLSCARSOPERATIONS Updatedata = new CLS_FRMS.CLSCARSOPERATIONS();
                Updatedata.CarsFuelUpdateData(ope1.Text, ope2.Text, ope3.Text, ope5.Text, ope6.Text, Convert.ToInt32(ope4.Text),
                    Convert.ToDouble(ope7.Text), Convert.ToInt32(ope8.Text), Convert.ToDouble(ope9.Text), ope10.Text, ope11.Text
                    , ope12.Text, ope13.Text);
                CarsFuelGetDate();
            }
        }

        private void btnopedelete_Click(object sender, EventArgs e)
        {
            if (lbtitle.Text == "موقف العجلات")
            {
                CLS_FRMS.CLSCARSOPERATIONS DeleteData = new CLS_FRMS.CLSCARSOPERATIONS();
                DeleteData.CarsituationDeleteData(Convert.ToInt32(ope10.Text));
                CarsituationOperationsGetdata();
            }
            else if (lbtitle.Text == "الحوادث")
            {
                CLS_FRMS.CLSCARSOPERATIONS DeleteData = new CLS_FRMS.CLSCARSOPERATIONS();
                DeleteData.CarsAccidentDeleting(Convert.ToInt32(ope10.Text));
                CarsAccidentGetData();
            }
            else if (lbtitle.Text == "العدادات")
            {
                CLS_FRMS.CLSCARSOPERATIONS DeleteData = new CLS_FRMS.CLSCARSOPERATIONS();
                DeleteData.CarsCounterDeleteData(Convert.ToInt32(ope8.Text));
                CarsCounterGetData();
            }
            else if (lbtitle.Text == "الوقود")
            {
                CLS_FRMS.CLSCARSOPERATIONS DeleteData = new CLS_FRMS.CLSCARSOPERATIONS();
                DeleteData.CarsFuelDeletingData(Convert.ToInt32(ope4.Text));
                CarsFuelGetDate();
            }
        }

        private void btnopeadd_Click(object sender, EventArgs e)
        {
            if (lbtitle.Text == "موقف العجلات")
            {
                CLS_FRMS.CLSCARSOPERATIONS Insertdata = new CLS_FRMS.CLSCARSOPERATIONS();
                Insertdata.CarsituationInsertData(ope1.Text, ope2.Text, ope3.Text, ope4.Text, ope5.Text, ope6.Text, ope7.Text, ope8.Text, ope9.Text);
                CarsituationOperationsGetdata();
            }
            else if (lbtitle.Text == "الحوادث")
            {
                CLS_FRMS.CLSCARSOPERATIONS InsertData = new CLS_FRMS.CLSCARSOPERATIONS();
                InsertData.CarsAccidentInsertData(ope1.Text, ope2.Text, ope3.Text, ope5.Text, ope7.Text, ope8.Text, ope9.Text, ope11.Text);
                CarsAccidentGetData();
            }
            else if (lbtitle.Text == "العدادات")
            {
                CLS_FRMS.CLSCARSOPERATIONS InsertData = new CLS_FRMS.CLSCARSOPERATIONS();
                InsertData.CarsCounterinsertData(ope1.Text, ope2.Text, ope3.Text, ope5.Text, Convert.ToDouble(ope7.Text), ope9.Text, ope10.Text, ope11.Text,ope4.Text);
                CarsCounterGetData();
            }
            else if (lbtitle.Text == "الوقود")
            {
                CLS_FRMS.CLSCARSOPERATIONS InsertData = new CLS_FRMS.CLSCARSOPERATIONS();
                InsertData.CarFuelInsertData(ope1.Text, ope2.Text, ope3.Text, ope5.Text, ope6.Text, Convert.ToDouble(ope7.Text), Convert.ToInt32(ope8.Text)
                , Convert.ToDouble(ope9.Text), ope10.Text, ope11.Text, ope12.Text, ope13.Text);
                CarsFuelGetDate();
            }
        }

        private void btnopeScanner_Click(object sender, EventArgs e)
        {

        }

        
    }
}
