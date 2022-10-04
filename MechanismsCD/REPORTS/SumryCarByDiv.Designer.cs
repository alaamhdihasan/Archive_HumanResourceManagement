namespace MechanismsCD.REPORTS
{
    partial class SumryCarByDiv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SumryCarByDiv));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.CarTypeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.RigName = new DevExpress.XtraReports.UI.XRLabel();
            this.LbDateNow = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.RpType = new DevExpress.XtraReports.Parameters.Parameter();
            this.UserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.dataSetMechanisms1 = new MechanismsCD.DS.DataSetMechanisms();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.typereport = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCrossBandBox2 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox4 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrCrossBandBox3 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMechanisms1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 45.12355F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Font = new System.Drawing.Font("mylotus", 14F, System.Drawing.FontStyle.Bold);
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(25.72244F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(741.6535F, 44.99999F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell5,
            this.CarTypeCell});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[id]")});
            this.xrTableCell10.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "xrTableCell4";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.TextFormatString = "{0:#,#}";
            this.xrTableCell10.Weight = 0.18270386054222818D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CarType]")});
            this.xrTableCell5.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseFont = false;
            this.xrTableCell5.Text = "xrTableCell5";
            this.xrTableCell5.Weight = 1.3402514956423508D;
            // 
            // CarTypeCell
            // 
            this.CarTypeCell.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Count]")});
            this.CarTypeCell.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarTypeCell.Name = "CarTypeCell";
            this.CarTypeCell.StylePriority.UseFont = false;
            this.CarTypeCell.Text = "CarTypeCell";
            this.CarTypeCell.Weight = 1.1376756080643613D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 15F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 5.021159F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(9.999974F, 24.3728F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(499.374F, 23.39749F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "العتبة العباسية المقدسة // قسم الاليات __ البيانات الالكترونية_ هاتف 1793 // الها" +
    "تف الارضي ( البدالة) 1159// موبايل 07602363277";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(509.3741F, 24.3728F);
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(67.19427F, 23.39752F);
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "اسم المستخدم: ";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // RigName
            // 
            this.RigName.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[UserName]")});
            this.RigName.Font = new System.Drawing.Font("mylotus", 7F, System.Drawing.FontStyle.Bold);
            this.RigName.ForeColor = System.Drawing.Color.Red;
            this.RigName.LocationFloat = new DevExpress.Utils.PointFloat(576.5681F, 24.3728F);
            this.RigName.Name = "RigName";
            this.RigName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RigName.SizeF = new System.Drawing.SizeF(75.93542F, 23.39749F);
            this.RigName.StylePriority.UseFont = false;
            this.RigName.StylePriority.UseForeColor = false;
            this.RigName.StylePriority.UseTextAlignment = false;
            this.RigName.Text = "UserName";
            this.RigName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // LbDateNow
            // 
            this.LbDateNow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDateNow.ForeColor = System.Drawing.Color.Red;
            this.LbDateNow.LocationFloat = new DevExpress.Utils.PointFloat(652.5035F, 25.18342F);
            this.LbDateNow.Name = "LbDateNow";
            this.LbDateNow.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.LbDateNow.SizeF = new System.Drawing.SizeF(79.29785F, 22.58681F);
            this.LbDateNow.StylePriority.UseFont = false;
            this.LbDateNow.StylePriority.UseForeColor = false;
            this.LbDateNow.StylePriority.UseTextAlignment = false;
            this.LbDateNow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(732.7365F, 27.17584F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(56.25018F, 23.9117F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // RpType
            // 
            this.RpType.Name = "RpType";
            // 
            // UserName
            // 
            this.UserName.Name = "UserName";
            // 
            // dataSetMechanisms1
            // 
            this.dataSetMechanisms1.DataSetName = "DataSetMechanisms";
            this.dataSetMechanisms1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            this.ReportHeader.HeightF = 164.6186F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(12.08334F, 13.28502F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(768.0016F, 141.3336F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.typereport});
            this.PageHeader.HeightF = 159.8365F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable1
            // 
            this.xrTable1.AnchorVertical = DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom;
            this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("mylotus", 10F, System.Drawing.FontStyle.Bold);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(25.72244F, 121.1907F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(742.4813F, 38.64581F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell2});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.CanGrow = false;
            this.xrTableCell3.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "ت";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell3.Weight = 0.20028210890615139D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.CanGrow = false;
            this.xrTableCell4.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.Text = "نوع العجلة";
            this.xrTableCell4.Weight = 1.4716070222691227D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.CanGrow = false;
            this.xrTableCell2.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.Text = "العدد";
            this.xrTableCell2.Weight = 1.252765597048588D;
            // 
            // typereport
            // 
            this.typereport.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[RpType]")});
            this.typereport.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typereport.ForeColor = System.Drawing.Color.Red;
            this.typereport.LocationFloat = new DevExpress.Utils.PointFloat(26.7368F, 12.08334F);
            this.typereport.Multiline = true;
            this.typereport.Name = "typereport";
            this.typereport.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.typereport.SizeF = new System.Drawing.SizeF(741.3055F, 109.1073F);
            this.typereport.StylePriority.UseFont = false;
            this.typereport.StylePriority.UseForeColor = false;
            this.typereport.StylePriority.UseTextAlignment = false;
            this.typereport.Text = "typereport";
            this.typereport.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.typereport.TextFormatString = "{0:#,#}";
            // 
            // xrCrossBandBox2
            // 
            this.xrCrossBandBox2.BorderWidth = 2F;
            this.xrCrossBandBox2.EndBand = this.ReportHeader;
            this.xrCrossBandBox2.EndPointFloat = new DevExpress.Utils.PointFloat(10F, 156.7373F);
            this.xrCrossBandBox2.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.xrCrossBandBox2.Name = "xrCrossBandBox2";
            this.xrCrossBandBox2.StartBand = this.ReportHeader;
            this.xrCrossBandBox2.StartPointFloat = new DevExpress.Utils.PointFloat(10F, 10F);
            this.xrCrossBandBox2.WidthF = 771.9486F;
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.BorderWidth = 2F;
            this.xrCrossBandBox1.EndBand = this.ReportHeader;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(0.4971822F, 163.4695F);
            this.xrCrossBandBox1.LocationFloat = new DevExpress.Utils.PointFloat(0.4971822F, 1.149146F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.ReportHeader;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(0.4971822F, 1.149146F);
            this.xrCrossBandBox1.WidthF = 788.4896F;
            // 
            // xrCrossBandBox4
            // 
            this.xrCrossBandBox4.BorderWidth = 2F;
            this.xrCrossBandBox4.EndBand = this.PageFooter;
            this.xrCrossBandBox4.EndPointFloat = new DevExpress.Utils.PointFloat(10.41387F, 11.66095F);
            this.xrCrossBandBox4.LocationFloat = new DevExpress.Utils.PointFloat(10.41387F, 10.00001F);
            this.xrCrossBandBox4.Name = "xrCrossBandBox4";
            this.xrCrossBandBox4.StartBand = this.PageHeader;
            this.xrCrossBandBox4.StartPointFloat = new DevExpress.Utils.PointFloat(10.41387F, 10.00001F);
            this.xrCrossBandBox4.WidthF = 770.1959F;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.xrLabel11,
            this.RigName,
            this.LbDateNow,
            this.xrLabel5});
            this.PageFooter.HeightF = 63.54167F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrCrossBandBox3
            // 
            this.xrCrossBandBox3.BorderWidth = 2F;
            this.xrCrossBandBox3.EndBand = this.PageFooter;
            this.xrCrossBandBox3.EndPointFloat = new DevExpress.Utils.PointFloat(3.572337F, 24.37283F);
            this.xrCrossBandBox3.LocationFloat = new DevExpress.Utils.PointFloat(3.572337F, 0F);
            this.xrCrossBandBox3.Name = "xrCrossBandBox3";
            this.xrCrossBandBox3.StartBand = this.PageHeader;
            this.xrCrossBandBox3.StartPointFloat = new DevExpress.Utils.PointFloat(3.572337F, 0F);
            this.xrCrossBandBox3.WidthF = 785.3444F;
            // 
            // SumryCarByDiv
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.PageFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSetMechanisms1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox2,
            this.xrCrossBandBox1,
            this.xrCrossBandBox4,
            this.xrCrossBandBox3});
            this.DataMember = "SummryCarByDivision";
            this.DataSource = this.dataSetMechanisms1;
            this.Margins = new System.Drawing.Printing.Margins(17, 18, 15, 5);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.RpType,
            this.UserName});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMechanisms1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.Parameters.Parameter RpType;
        private DevExpress.XtraReports.Parameters.Parameter UserName;
        private DS.DataSetMechanisms dataSetMechanisms1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox2;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox4;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox3;
        public DevExpress.XtraReports.UI.XRLabel typereport;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        public DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell CarTypeCell;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRLabel RigName;
        public DevExpress.XtraReports.UI.XRLabel LbDateNow;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
    }
}
