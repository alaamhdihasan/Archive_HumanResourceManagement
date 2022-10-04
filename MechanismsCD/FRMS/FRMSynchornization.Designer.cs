namespace MechanismsCD.FRMS
{
    partial class FRMSynchornization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMSynchornization));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnexitapp = new ns1.BunifuImageButton();
            this.lbtitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Dgv = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbxSyncType = new System.Windows.Forms.ComboBox();
            this.cbxFrom = new System.Windows.Forms.ComboBox();
            this.cbxTo = new System.Windows.Forms.ComboBox();
            this.btnSync = new DevExpress.XtraEditors.SimpleButton();
            this.bgwork = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexitapp)).BeginInit();
            this.panel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.btnexitapp);
            this.panel1.Controls.Add(this.lbtitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 43);
            this.panel1.TabIndex = 6;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("JF Flat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(43, 7);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(70, 28);
            this.lblUserName.TabIndex = 67;
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
            this.btnexitapp.Size = new System.Drawing.Size(30, 43);
            this.btnexitapp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnexitapp.TabIndex = 66;
            this.btnexitapp.TabStop = false;
            this.btnexitapp.Zoom = 10;
            this.btnexitapp.Click += new System.EventHandler(this.btnexitapp_Click_1);
            // 
            // lbtitle
            // 
            this.lbtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("JF Flat", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.ForeColor = System.Drawing.Color.White;
            this.lbtitle.Location = new System.Drawing.Point(1113, 7);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(144, 33);
            this.lbtitle.TabIndex = 65;
            this.lbtitle.Text = "مزامنة البيانات";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(43, 706);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1252, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 706);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(43, 706);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1209, 43);
            this.panel4.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tableLayoutPanel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(43, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1209, 663);
            this.panel5.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.Dgv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1209, 663);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Dgv
            // 
            this.Dgv.AllowUserToAddRows = false;
            this.Dgv.AllowUserToDeleteRows = false;
            this.Dgv.AllowUserToResizeColumns = false;
            this.Dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.Dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(75)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv.ColumnHeadersHeight = 70;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv.EnableHeadersVisualStyles = false;
            this.Dgv.Location = new System.Drawing.Point(3, 3);
            this.Dgv.MultiSelect = false;
            this.Dgv.Name = "Dgv";
            this.Dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Dgv.RowHeadersVisible = false;
            this.Dgv.RowHeadersWidth = 5;
            this.Dgv.RowTemplate.Height = 40;
            this.Dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv.Size = new System.Drawing.Size(720, 657);
            this.Dgv.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbxSyncType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxFrom, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbxTo, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnSync, 1, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(729, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(477, 657);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("JF Flat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Appearance.Options.UseImageAlign = true;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(290, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelControl2.Size = new System.Drawing.Size(184, 39);
            this.labelControl2.TabIndex = 53;
            this.labelControl2.Text = "نوع المزامنة";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("JF Flat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseImageAlign = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(290, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelControl1.Size = new System.Drawing.Size(184, 39);
            this.labelControl1.TabIndex = 54;
            this.labelControl1.Text = "من";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl4.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("JF Flat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Appearance.Options.UseImageAlign = true;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.Location = new System.Drawing.Point(290, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.labelControl4.Size = new System.Drawing.Size(184, 39);
            this.labelControl4.TabIndex = 56;
            this.labelControl4.Text = "الى";
            // 
            // cbxSyncType
            // 
            this.cbxSyncType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSyncType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSyncType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSyncType.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSyncType.FormattingEnabled = true;
            this.cbxSyncType.Items.AddRange(new object[] {
            "مزامنة بيانات المنتسبين",
            "مزامنة المتغيرات",
            "مزامنة المستحقات الاعتيادية",
            "مزامنة المستحقات الطارئة",
            "مزامنة المستحقات المرضية",
            "مزامنة الاوامر الادارية",
            "مزامنة العقود",
            "مزامنة زمنيات",
            "مزامنة الايفادات",
            "مزامنة بيانات الاولاد",
            "مزامنة الاستضافة و التنسيب",
            "مزامنة ارشيف الاضبارة",
            "تحديث بيانات المنتسبين"});
            this.cbxSyncType.Location = new System.Drawing.Point(3, 3);
            this.cbxSyncType.Name = "cbxSyncType";
            this.cbxSyncType.Size = new System.Drawing.Size(281, 31);
            this.cbxSyncType.TabIndex = 63;
            this.cbxSyncType.SelectedIndexChanged += new System.EventHandler(this.cbxSyncType_SelectedIndexChanged);
            // 
            // cbxFrom
            // 
            this.cbxFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxFrom.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFrom.FormattingEnabled = true;
            this.cbxFrom.Location = new System.Drawing.Point(3, 48);
            this.cbxFrom.Name = "cbxFrom";
            this.cbxFrom.Size = new System.Drawing.Size(281, 31);
            this.cbxFrom.TabIndex = 64;
            // 
            // cbxTo
            // 
            this.cbxTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTo.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTo.FormattingEnabled = true;
            this.cbxTo.Location = new System.Drawing.Point(3, 93);
            this.cbxTo.Name = "cbxTo";
            this.cbxTo.Size = new System.Drawing.Size(281, 31);
            this.cbxTo.TabIndex = 65;
            // 
            // btnSync
            // 
            this.btnSync.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnSync.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(47)))));
            this.btnSync.Appearance.Font = new System.Drawing.Font("JF Flat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSync.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSync.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSync.Appearance.Options.UseBackColor = true;
            this.btnSync.Appearance.Options.UseFont = true;
            this.btnSync.Appearance.Options.UseForeColor = true;
            this.btnSync.AppearanceHovered.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSync.AppearanceHovered.BackColor2 = System.Drawing.Color.DeepSkyBlue;
            this.btnSync.AppearanceHovered.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSync.AppearanceHovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnSync.AppearanceHovered.ForeColor = System.Drawing.Color.Black;
            this.btnSync.AppearanceHovered.Options.UseBackColor = true;
            this.btnSync.AppearanceHovered.Options.UseFont = true;
            this.btnSync.AppearanceHovered.Options.UseForeColor = true;
            this.btnSync.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSync.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSync.ImageOptions.Image")));
            this.btnSync.Location = new System.Drawing.Point(3, 609);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(281, 45);
            this.btnSync.TabIndex = 68;
            this.btnSync.Text = "مزامنة";
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // bgwork
            // 
            this.bgwork.WorkerReportsProgress = true;
            // 
            // FRMSynchornization
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 749);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("JF Flat", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRMSynchornization";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "FRMSynchornization";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRMSynchornization_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexitapp)).EndInit();
            this.panel5.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView Dgv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cbxSyncType;
        private System.Windows.Forms.ComboBox cbxFrom;
        private System.Windows.Forms.ComboBox cbxTo;
        public DevExpress.XtraEditors.SimpleButton btnSync;
        private ns1.BunifuImageButton btnexitapp;
        private System.Windows.Forms.Label lblUserName;
        public System.ComponentModel.BackgroundWorker bgwork;
    }
}