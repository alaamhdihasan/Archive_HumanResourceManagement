namespace MechanismsCD.FRMS
{
    partial class FRMRPEMPEMPLOYEES
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pn1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnexitapp = new ns1.BunifuImageButton();
            this.Pn2 = new System.Windows.Forms.Panel();
            this.Pn4 = new System.Windows.Forms.Panel();
            this.prog = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lb1 = new System.Windows.Forms.Label();
            this.Pn3 = new System.Windows.Forms.Panel();
            this.Pn5 = new System.Windows.Forms.Panel();
            this.btnpreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnsearch = new DevExpress.XtraEditors.SimpleButton();
            this.cb5 = new System.Windows.Forms.ComboBox();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.cb4 = new System.Windows.Forms.ComboBox();
            this.cb3 = new System.Windows.Forms.ComboBox();
            this.cb2 = new System.Windows.Forms.ComboBox();
            this.cb1 = new System.Windows.Forms.ComboBox();
            this.Pn6 = new System.Windows.Forms.Panel();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.Pnv = new System.Windows.Forms.Panel();
            this.bgwork = new System.ComponentModel.BackgroundWorker();
            this.Pn1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexitapp)).BeginInit();
            this.Pn4.SuspendLayout();
            this.Pn5.SuspendLayout();
            this.Pn6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Pn1
            // 
            this.Pn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pn1.Controls.Add(this.lblUserName);
            this.Pn1.Controls.Add(this.btnexitapp);
            this.Pn1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pn1.Location = new System.Drawing.Point(0, 0);
            this.Pn1.Name = "Pn1";
            this.Pn1.Size = new System.Drawing.Size(1264, 38);
            this.Pn1.TabIndex = 1;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUserName.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(31, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(70, 28);
            this.lblUserName.TabIndex = 30;
            this.lblUserName.Text = "label25";
            // 
            // btnexitapp
            // 
            this.btnexitapp.BackColor = System.Drawing.Color.Transparent;
            this.btnexitapp.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnexitapp.Image = global::MechanismsCD.Properties.Resources.Cancel_64px;
            this.btnexitapp.ImageActive = null;
            this.btnexitapp.Location = new System.Drawing.Point(0, 0);
            this.btnexitapp.Name = "btnexitapp";
            this.btnexitapp.Size = new System.Drawing.Size(31, 38);
            this.btnexitapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnexitapp.TabIndex = 29;
            this.btnexitapp.TabStop = false;
            this.btnexitapp.Zoom = 10;
            this.btnexitapp.Click += new System.EventHandler(this.btnexitapp_Click);
            // 
            // Pn2
            // 
            this.Pn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pn2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pn2.Location = new System.Drawing.Point(0, 38);
            this.Pn2.Name = "Pn2";
            this.Pn2.Size = new System.Drawing.Size(35, 634);
            this.Pn2.TabIndex = 2;
            // 
            // Pn4
            // 
            this.Pn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pn4.Controls.Add(this.prog);
            this.Pn4.Controls.Add(this.label1);
            this.Pn4.Controls.Add(this.lb1);
            this.Pn4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pn4.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Pn4.Location = new System.Drawing.Point(0, 672);
            this.Pn4.Name = "Pn4";
            this.Pn4.Size = new System.Drawing.Size(1264, 39);
            this.Pn4.TabIndex = 3;
            // 
            // prog
            // 
            this.prog.Location = new System.Drawing.Point(31, 6);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(795, 22);
            this.prog.TabIndex = 3;
            this.prog.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1142, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = ".....Working";
            this.label1.Visible = false;
            // 
            // lb1
            // 
            this.lb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lb1.ForeColor = System.Drawing.Color.White;
            this.lb1.Location = new System.Drawing.Point(946, 8);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(18, 23);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "0";
            this.lb1.Visible = false;
            // 
            // Pn3
            // 
            this.Pn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pn3.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pn3.Location = new System.Drawing.Point(1233, 38);
            this.Pn3.Name = "Pn3";
            this.Pn3.Size = new System.Drawing.Size(31, 634);
            this.Pn3.TabIndex = 4;
            // 
            // Pn5
            // 
            this.Pn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Pn5.Controls.Add(this.btnpreview);
            this.Pn5.Controls.Add(this.btnPrint);
            this.Pn5.Controls.Add(this.btnsearch);
            this.Pn5.Controls.Add(this.cb5);
            this.Pn5.Controls.Add(this.dt2);
            this.Pn5.Controls.Add(this.dt1);
            this.Pn5.Controls.Add(this.cb4);
            this.Pn5.Controls.Add(this.cb3);
            this.Pn5.Controls.Add(this.cb2);
            this.Pn5.Controls.Add(this.cb1);
            this.Pn5.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pn5.Location = new System.Drawing.Point(35, 38);
            this.Pn5.Name = "Pn5";
            this.Pn5.Size = new System.Drawing.Size(268, 634);
            this.Pn5.TabIndex = 5;
            // 
            // btnpreview
            // 
            this.btnpreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnpreview.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnpreview.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnpreview.Appearance.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnpreview.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnpreview.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnpreview.Appearance.Options.UseBackColor = true;
            this.btnpreview.Appearance.Options.UseFont = true;
            this.btnpreview.Appearance.Options.UseForeColor = true;
            this.btnpreview.AppearanceHovered.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnpreview.AppearanceHovered.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnpreview.AppearanceHovered.Font = new System.Drawing.Font("Jaridah", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnpreview.AppearanceHovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnpreview.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnpreview.AppearanceHovered.Options.UseBackColor = true;
            this.btnpreview.AppearanceHovered.Options.UseFont = true;
            this.btnpreview.AppearanceHovered.Options.UseForeColor = true;
            this.btnpreview.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnpreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnpreview.Location = new System.Drawing.Point(46, 552);
            this.btnpreview.Name = "btnpreview";
            this.btnpreview.Size = new System.Drawing.Size(216, 39);
            this.btnpreview.TabIndex = 15;
            this.btnpreview.Text = "تحميل المعاينة";
            this.btnpreview.Click += new System.EventHandler(this.btnpreview_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnPrint.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnPrint.Appearance.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrint.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Appearance.Options.UseBackColor = true;
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.AppearanceHovered.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnPrint.AppearanceHovered.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnPrint.AppearanceHovered.Font = new System.Drawing.Font("Jaridah", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPrint.AppearanceHovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnPrint.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.AppearanceHovered.Options.UseBackColor = true;
            this.btnPrint.AppearanceHovered.Options.UseFont = true;
            this.btnPrint.AppearanceHovered.Options.UseForeColor = true;
            this.btnPrint.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.Location = new System.Drawing.Point(46, 592);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 39);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "طباعة ";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnsearch.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnsearch.Appearance.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnsearch.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnsearch.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Appearance.Options.UseBackColor = true;
            this.btnsearch.Appearance.Options.UseFont = true;
            this.btnsearch.Appearance.Options.UseForeColor = true;
            this.btnsearch.AppearanceHovered.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnsearch.AppearanceHovered.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnsearch.AppearanceHovered.Font = new System.Drawing.Font("Jaridah", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnsearch.AppearanceHovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnsearch.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnsearch.AppearanceHovered.Options.UseBackColor = true;
            this.btnsearch.AppearanceHovered.Options.UseFont = true;
            this.btnsearch.AppearanceHovered.Options.UseForeColor = true;
            this.btnsearch.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.Location = new System.Drawing.Point(157, 592);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(105, 39);
            this.btnsearch.TabIndex = 13;
            this.btnsearch.Text = "بحث";
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // cb5
            // 
            this.cb5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cb5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb5.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cb5.FormattingEnabled = true;
            this.cb5.Location = new System.Drawing.Point(6, 511);
            this.cb5.Name = "cb5";
            this.cb5.Size = new System.Drawing.Size(256, 31);
            this.cb5.TabIndex = 12;
            this.cb5.SelectedIndexChanged += new System.EventHandler(this.cb5_SelectedIndexChanged);
            // 
            // dt2
            // 
            this.dt2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dt2.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dt2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt2.Location = new System.Drawing.Point(6, 424);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(256, 30);
            this.dt2.TabIndex = 11;
            // 
            // dt1
            // 
            this.dt1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dt1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt1.Location = new System.Drawing.Point(6, 387);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(256, 30);
            this.dt1.TabIndex = 10;
            // 
            // cb4
            // 
            this.cb4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb4.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cb4.FormattingEnabled = true;
            this.cb4.Location = new System.Drawing.Point(6, 171);
            this.cb4.Name = "cb4";
            this.cb4.Size = new System.Drawing.Size(256, 31);
            this.cb4.TabIndex = 3;
            // 
            // cb3
            // 
            this.cb3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb3.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cb3.FormattingEnabled = true;
            this.cb3.Location = new System.Drawing.Point(6, 130);
            this.cb3.Name = "cb3";
            this.cb3.Size = new System.Drawing.Size(256, 31);
            this.cb3.TabIndex = 2;
            // 
            // cb2
            // 
            this.cb2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb2.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cb2.FormattingEnabled = true;
            this.cb2.Location = new System.Drawing.Point(6, 89);
            this.cb2.Name = "cb2";
            this.cb2.Size = new System.Drawing.Size(256, 31);
            this.cb2.TabIndex = 1;
            // 
            // cb1
            // 
            this.cb1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cb1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cb1.FormattingEnabled = true;
            this.cb1.Location = new System.Drawing.Point(6, 48);
            this.cb1.Name = "cb1";
            this.cb1.Size = new System.Drawing.Size(256, 31);
            this.cb1.TabIndex = 0;
            // 
            // Pn6
            // 
            this.Pn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pn6.Controls.Add(this.Dgv);
            this.Pn6.Controls.Add(this.Pnv);
            this.Pn6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn6.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Pn6.Location = new System.Drawing.Point(303, 38);
            this.Pn6.Name = "Pn6";
            this.Pn6.Size = new System.Drawing.Size(930, 634);
            this.Pn6.TabIndex = 6;
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.Dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(75)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.ColumnHeadersHeight = 50;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv.EnableHeadersVisualStyles = false;
            this.Dgv.Location = new System.Drawing.Point(0, 0);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            this.Dgv.RowHeadersVisible = false;
            this.Dgv.RowHeadersWidth = 5;
            this.Dgv.RowTemplate.Height = 45;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(894, 634);
            this.Dgv.TabIndex = 2;
            // 
            // Pnv
            // 
            this.Pnv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Pnv.Dock = System.Windows.Forms.DockStyle.Right;
            this.Pnv.Location = new System.Drawing.Point(894, 0);
            this.Pnv.Name = "Pnv";
            this.Pnv.Size = new System.Drawing.Size(36, 634);
            this.Pnv.TabIndex = 3;
            // 
            // bgwork
            // 
            this.bgwork.WorkerReportsProgress = true;
            this.bgwork.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwork_DoWork);
            this.bgwork.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwork_ProgressChanged);
            // 
            // FRMRPEMPEMPLOYEES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 711);
            this.Controls.Add(this.Pn6);
            this.Controls.Add(this.Pn5);
            this.Controls.Add(this.Pn3);
            this.Controls.Add(this.Pn2);
            this.Controls.Add(this.Pn1);
            this.Controls.Add(this.Pn4);
            this.Font = new System.Drawing.Font("Jaridah", 12F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FRMRPEMPEMPLOYEES";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMRPEMPEMPLOYEES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMRPEMPEMPLOYEES_Load);
            this.Pn1.ResumeLayout(false);
            this.Pn1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexitapp)).EndInit();
            this.Pn4.ResumeLayout(false);
            this.Pn4.PerformLayout();
            this.Pn5.ResumeLayout(false);
            this.Pn6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel Pn1;
        private ns1.BunifuImageButton btnexitapp;
        public System.Windows.Forms.Panel Pn2;
        public System.Windows.Forms.Panel Pn4;
        public System.Windows.Forms.Panel Pn3;
        public System.Windows.Forms.Panel Pn5;
        public System.Windows.Forms.Panel Pn6;
        private System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.ComboBox cb4;
        private System.Windows.Forms.ComboBox cb3;
        private System.Windows.Forms.ComboBox cb2;
        private System.Windows.Forms.ComboBox cb1;
        private System.Windows.Forms.ComboBox cb5;
        public DevExpress.XtraEditors.SimpleButton btnsearch;
        public DevExpress.XtraEditors.SimpleButton btnPrint;
        public DevExpress.XtraEditors.SimpleButton btnpreview;
        public System.ComponentModel.BackgroundWorker bgwork;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lb1;
        public System.Windows.Forms.ProgressBar prog;
        private System.Windows.Forms.Panel Pnv;
        private System.Windows.Forms.Label lblUserName;
    }
}