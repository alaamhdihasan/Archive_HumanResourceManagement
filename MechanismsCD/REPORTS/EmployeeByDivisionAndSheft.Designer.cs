namespace MechanismsCD.REPORTS
{
    partial class EmployeeByDivisionAndSheft
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeByDivisionAndSheft));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.CarNoCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.RigName = new DevExpress.XtraReports.UI.XRLabel();
            this.LbDateNow = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrCrossBandBox2 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox1 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.typereport = new DevExpress.XtraReports.UI.XRLabel();
            this.xrCrossBandBox3 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.xrCrossBandBox4 = new DevExpress.XtraReports.UI.XRCrossBandBox();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.countrow = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.RpType = new DevExpress.XtraReports.Parameters.Parameter();
            this.EmpCount = new DevExpress.XtraReports.Parameters.Parameter();
            this.UserName = new DevExpress.XtraReports.Parameters.Parameter();
            this.dataSetMechanisms1 = new MechanismsCD.DS.DataSetMechanisms();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMechanisms1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail.HeightF = 44.99999F;
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
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(17.51404F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(741.1389F, 44.99999F);
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.CarNoCell});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[id]")});
            this.xrTableCell10.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBorders = false;
            this.xrTableCell10.StylePriority.UseFont = false;
            this.xrTableCell10.StylePriority.UsePadding = false;
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.Text = "xrTableCell4";
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.TextFormatString = "{0:#,#}";
            this.xrTableCell10.Weight = 0.039498678579198546D;
            // 
            // CarNoCell
            // 
            this.CarNoCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.CarNoCell.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmpName]")});
            this.CarNoCell.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNoCell.Name = "CarNoCell";
            this.CarNoCell.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.CarNoCell.StylePriority.UseBorders = false;
            this.CarNoCell.StylePriority.UseFont = false;
            this.CarNoCell.StylePriority.UsePadding = false;
            this.CarNoCell.StylePriority.UseTextAlignment = false;
            this.CarNoCell.Text = "CarNo";
            this.CarNoCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.CarNoCell.Weight = 0.523306031072882D;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 24F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel11,
            this.RigName,
            this.LbDateNow,
            this.xrPageInfo1});
            this.BottomMargin.HeightF = 39.39421F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(1.506622F, 12.64741F);
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
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(500.8806F, 12.64741F);
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
            this.RigName.LocationFloat = new DevExpress.Utils.PointFloat(568.0745F, 12.64741F);
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
            this.LbDateNow.LocationFloat = new DevExpress.Utils.PointFloat(644.0098F, 13.45805F);
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
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(724.2432F, 15.45045F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(56.25018F, 23.9117F);
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            this.xrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            this.ReportHeader.HeightF = 159.0419F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(2.083333F, 7.708327F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(768.0016F, 141.3336F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.AutoSize;
            // 
            // xrCrossBandBox2
            // 
            this.xrCrossBandBox2.BorderWidth = 2F;
            this.xrCrossBandBox2.EndBand = this.ReportHeader;
            this.xrCrossBandBox2.EndPointFloat = new DevExpress.Utils.PointFloat(8.125401F, 149.1667F);
            this.xrCrossBandBox2.LocationFloat = new DevExpress.Utils.PointFloat(8.125401F, 6.25F);
            this.xrCrossBandBox2.Name = "xrCrossBandBox2";
            this.xrCrossBandBox2.StartBand = this.ReportHeader;
            this.xrCrossBandBox2.StartPointFloat = new DevExpress.Utils.PointFloat(8.125401F, 6.25F);
            this.xrCrossBandBox2.WidthF = 765.4045F;
            // 
            // xrCrossBandBox1
            // 
            this.xrCrossBandBox1.BorderWidth = 2F;
            this.xrCrossBandBox1.EndBand = this.ReportHeader;
            this.xrCrossBandBox1.EndPointFloat = new DevExpress.Utils.PointFloat(0F, 158.417F);
            this.xrCrossBandBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandBox1.Name = "xrCrossBandBox1";
            this.xrCrossBandBox1.StartBand = this.ReportHeader;
            this.xrCrossBandBox1.StartPointFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrCrossBandBox1.WidthF = 780.1254F;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.typereport});
            this.PageHeader.HeightF = 121F;
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
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(17.43056F, 82.35419F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(741.2224F, 38.64581F);
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
            this.xrTableCell1});
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
            this.xrTableCell3.Weight = 0.023022612419138777D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.CanGrow = false;
            this.xrTableCell1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 6, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UsePadding = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "الاسم";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 0.30348675603563863D;
            // 
            // typereport
            // 
            this.typereport.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[RpType]")});
            this.typereport.Font = new System.Drawing.Font("JF Flat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.typereport.ForeColor = System.Drawing.Color.Red;
            this.typereport.LocationFloat = new DevExpress.Utils.PointFloat(17.34714F, 34.33333F);
            this.typereport.Name = "typereport";
            this.typereport.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.typereport.SizeF = new System.Drawing.SizeF(741.3057F, 31.33334F);
            this.typereport.StylePriority.UseFont = false;
            this.typereport.StylePriority.UseForeColor = false;
            this.typereport.StylePriority.UseTextAlignment = false;
            this.typereport.Text = "typereport";
            this.typereport.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.typereport.TextFormatString = "{0:#,#}";
            // 
            // xrCrossBandBox3
            // 
            this.xrCrossBandBox3.BorderWidth = 2F;
            this.xrCrossBandBox3.EndBand = this.BottomMargin;
            this.xrCrossBandBox3.EndPointFloat = new DevExpress.Utils.PointFloat(0.1667659F, 13.45807F);
            this.xrCrossBandBox3.LocationFloat = new DevExpress.Utils.PointFloat(0.1667659F, 0F);
            this.xrCrossBandBox3.Name = "xrCrossBandBox3";
            this.xrCrossBandBox3.StartBand = this.PageHeader;
            this.xrCrossBandBox3.StartPointFloat = new DevExpress.Utils.PointFloat(0.1667659F, 0F);
            this.xrCrossBandBox3.WidthF = 779.512F;
            // 
            // xrCrossBandBox4
            // 
            this.xrCrossBandBox4.BorderWidth = 2F;
            this.xrCrossBandBox4.EndBand = this.BottomMargin;
            this.xrCrossBandBox4.EndPointFloat = new DevExpress.Utils.PointFloat(9.421921F, 5.461304F);
            this.xrCrossBandBox4.LocationFloat = new DevExpress.Utils.PointFloat(9.421921F, 13.30506F);
            this.xrCrossBandBox4.Name = "xrCrossBandBox4";
            this.xrCrossBandBox4.StartBand = this.PageHeader;
            this.xrCrossBandBox4.StartPointFloat = new DevExpress.Utils.PointFloat(9.421921F, 13.30506F);
            this.xrCrossBandBox4.WidthF = 764.2747F;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.countrow,
            this.xrLabel3});
            this.ReportFooter.HeightF = 83.33334F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // countrow
            // 
            this.countrow.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[EmpCount]")});
            this.countrow.Font = new System.Drawing.Font("Jaridah", 9.75F, System.Drawing.FontStyle.Bold);
            this.countrow.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.countrow.LocationFloat = new DevExpress.Utils.PointFloat(150.0392F, 9.999974F);
            this.countrow.Name = "countrow";
            this.countrow.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.countrow.SizeF = new System.Drawing.SizeF(60.3452F, 31.33334F);
            this.countrow.StylePriority.UseFont = false;
            this.countrow.StylePriority.UseForeColor = false;
            this.countrow.StylePriority.UseTextAlignment = false;
            this.countrow.Text = "countrow";
            this.countrow.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.countrow.TextFormatString = "{0:#,#}";
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("JF Flat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(17.43046F, 9.999974F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(132.6087F, 31.33336F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "العدد الكلي :";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // RpType
            // 
            this.RpType.Name = "RpType";
            // 
            // EmpCount
            // 
            this.EmpCount.Name = "EmpCount";
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
            // EmployeeByDivisionAndSheft
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dataSetMechanisms1});
            this.CrossBandControls.AddRange(new DevExpress.XtraReports.UI.XRCrossBandControl[] {
            this.xrCrossBandBox2,
            this.xrCrossBandBox1,
            this.xrCrossBandBox3,
            this.xrCrossBandBox4});
            this.DataMember = "EmployeeByDivisionAndSheft";
            this.DataSource = this.dataSetMechanisms1;
            this.Margins = new System.Drawing.Printing.Margins(19, 26, 24, 39);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.RpType,
            this.EmpCount,
            this.UserName});
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.RightToLeftLayout = DevExpress.XtraReports.UI.RightToLeftLayout.Yes;
            this.Version = "17.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMechanisms1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox2;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        public DevExpress.XtraReports.UI.XRLabel typereport;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox3;
        private DevExpress.XtraReports.UI.XRCrossBandBox xrCrossBandBox4;
        public DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        public DevExpress.XtraReports.UI.XRTableCell CarNoCell;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        public DevExpress.XtraReports.UI.XRLabel countrow;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel xrLabel11;
        public DevExpress.XtraReports.UI.XRLabel RigName;
        public DevExpress.XtraReports.UI.XRLabel LbDateNow;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.Parameters.Parameter RpType;
        private DevExpress.XtraReports.Parameters.Parameter EmpCount;
        private DevExpress.XtraReports.Parameters.Parameter UserName;
        private DS.DataSetMechanisms dataSetMechanisms1;
    }
}
