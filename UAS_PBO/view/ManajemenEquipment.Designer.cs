namespace UAS_PBO.view
{
    partial class ManajemenEquipment
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.tbImage = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dgEquipment = new System.Windows.Forms.DataGridView();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.tbEquipmentName = new System.Windows.Forms.TextBox();
            this.btnhapus = new System.Windows.Forms.Button();
            this.buttnrfresh = new System.Windows.Forms.Button();
            this.bttnedit = new System.Windows.Forms.Button();
            this.btnsimpan = new System.Windows.Forms.Button();
            this.tbBrand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDashboardAdmin = new System.Windows.Forms.Button();
            this.buttonManajemenUser = new System.Windows.Forms.Button();
            this.buttonManajemenEquipment = new System.Windows.Forms.Button();
            this.buttonManajemenRental = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipment)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(206, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 75);
            this.panel2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(18, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "Manajemen Equipment ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cbStatus);
            this.panel3.Controls.Add(this.cbCategory);
            this.panel3.Controls.Add(this.btnDirectory);
            this.panel3.Controls.Add(this.numStock);
            this.panel3.Controls.Add(this.tbImage);
            this.panel3.Controls.Add(this.tbDescription);
            this.panel3.Controls.Add(this.dgEquipment);
            this.panel3.Controls.Add(this.tbPrice);
            this.panel3.Controls.Add(this.tbSearch);
            this.panel3.Controls.Add(this.tbEquipmentName);
            this.panel3.Controls.Add(this.btnhapus);
            this.panel3.Controls.Add(this.buttnrfresh);
            this.panel3.Controls.Add(this.bttnedit);
            this.panel3.Controls.Add(this.btnsimpan);
            this.panel3.Controls.Add(this.tbBrand);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(206, 75);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(994, 617);
            this.panel3.TabIndex = 5;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Tersedia",
            "Tidak Tersedia",
            "Perawatan"});
            this.cbStatus.Location = new System.Drawing.Point(308, 115);
            this.cbStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(256, 28);
            this.cbStatus.TabIndex = 28;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Speaker",
            "Microphone",
            "Mixer",
            "Instrument"});
            this.cbCategory.Location = new System.Drawing.Point(308, 40);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(256, 28);
            this.cbCategory.TabIndex = 26;
            // 
            // btnDirectory
            // 
            this.btnDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectory.Location = new System.Drawing.Point(531, 188);
            this.btnDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(34, 42);
            this.btnDirectory.TabIndex = 25;
            this.btnDirectory.Text = "...";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(44, 267);
            this.numStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(228, 26);
            this.numStock.TabIndex = 24;
            // 
            // tbImage
            // 
            this.tbImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbImage.Location = new System.Drawing.Point(308, 188);
            this.tbImage.Multiline = true;
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(214, 39);
            this.tbImage.TabIndex = 23;
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbDescription.Location = new System.Drawing.Point(584, 45);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(256, 211);
            this.tbDescription.TabIndex = 22;
            // 
            // dgEquipment
            // 
            this.dgEquipment.BackgroundColor = System.Drawing.Color.Silver;
            this.dgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipment.Location = new System.Drawing.Point(44, 317);
            this.dgEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgEquipment.Name = "dgEquipment";
            this.dgEquipment.RowHeadersWidth = 62;
            this.dgEquipment.Size = new System.Drawing.Size(912, 260);
            this.dgEquipment.TabIndex = 20;
            this.dgEquipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEquipment_CellClick);
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbPrice.Location = new System.Drawing.Point(44, 189);
            this.tbPrice.Multiline = true;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(226, 39);
            this.tbPrice.TabIndex = 19;
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbSearch.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tbSearch.Location = new System.Drawing.Point(584, 266);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(370, 41);
            this.tbSearch.TabIndex = 18;
            this.tbSearch.Text = "Search";
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // tbEquipmentName
            // 
            this.tbEquipmentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbEquipmentName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbEquipmentName.Location = new System.Drawing.Point(44, 39);
            this.tbEquipmentName.Multiline = true;
            this.tbEquipmentName.Name = "tbEquipmentName";
            this.tbEquipmentName.Size = new System.Drawing.Size(226, 39);
            this.tbEquipmentName.TabIndex = 16;
            // 
            // btnhapus
            // 
            this.btnhapus.BackColor = System.Drawing.Color.Brown;
            this.btnhapus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhapus.Location = new System.Drawing.Point(862, 97);
            this.btnhapus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnhapus.Name = "btnhapus";
            this.btnhapus.Size = new System.Drawing.Size(93, 48);
            this.btnhapus.TabIndex = 13;
            this.btnhapus.Text = "Hapus";
            this.btnhapus.UseVisualStyleBackColor = false;
            this.btnhapus.Click += new System.EventHandler(this.btnhapus_Click);
            // 
            // buttnrfresh
            // 
            this.buttnrfresh.Location = new System.Drawing.Point(862, 211);
            this.buttnrfresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttnrfresh.Name = "buttnrfresh";
            this.buttnrfresh.Size = new System.Drawing.Size(93, 48);
            this.buttnrfresh.TabIndex = 12;
            this.buttnrfresh.Text = "Refresh";
            this.buttnrfresh.UseVisualStyleBackColor = true;
            this.buttnrfresh.Click += new System.EventHandler(this.buttnrfresh_Click);
            // 
            // bttnedit
            // 
            this.bttnedit.BackColor = System.Drawing.Color.MediumTurquoise;
            this.bttnedit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bttnedit.Location = new System.Drawing.Point(862, 154);
            this.bttnedit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bttnedit.Name = "bttnedit";
            this.bttnedit.Size = new System.Drawing.Size(93, 48);
            this.bttnedit.TabIndex = 11;
            this.bttnedit.Text = "Edit";
            this.bttnedit.UseVisualStyleBackColor = false;
            this.bttnedit.Click += new System.EventHandler(this.bttnedit_Click);
            // 
            // btnsimpan
            // 
            this.btnsimpan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnsimpan.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnsimpan.Location = new System.Drawing.Point(862, 38);
            this.btnsimpan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsimpan.Name = "btnsimpan";
            this.btnsimpan.Size = new System.Drawing.Size(93, 49);
            this.btnsimpan.TabIndex = 10;
            this.btnsimpan.Text = "Simpan";
            this.btnsimpan.UseVisualStyleBackColor = false;
            this.btnsimpan.Click += new System.EventHandler(this.btnsimpan_Click);
            // 
            // tbBrand
            // 
            this.tbBrand.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbBrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbBrand.Location = new System.Drawing.Point(44, 116);
            this.tbBrand.Multiline = true;
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(226, 39);
            this.tbBrand.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // buttonDashboardAdmin
            // 
            this.buttonDashboardAdmin.FlatAppearance.BorderSize = 0;
            this.buttonDashboardAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboardAdmin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboardAdmin.ForeColor = System.Drawing.Color.White;
            this.buttonDashboardAdmin.Location = new System.Drawing.Point(-15, 0);
            this.buttonDashboardAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonDashboardAdmin.Name = "buttonDashboardAdmin";
            this.buttonDashboardAdmin.Size = new System.Drawing.Size(234, 42);
            this.buttonDashboardAdmin.TabIndex = 0;
            this.buttonDashboardAdmin.Text = "Dashboard Admin";
            this.buttonDashboardAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonManajemenUser
            // 
            this.buttonManajemenUser.FlatAppearance.BorderSize = 0;
            this.buttonManajemenUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManajemenUser.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManajemenUser.ForeColor = System.Drawing.Color.White;
            this.buttonManajemenUser.Location = new System.Drawing.Point(-15, 61);
            this.buttonManajemenUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonManajemenUser.Name = "buttonManajemenUser";
            this.buttonManajemenUser.Size = new System.Drawing.Size(234, 42);
            this.buttonManajemenUser.TabIndex = 1;
            this.buttonManajemenUser.Text = "Manajemen User";
            this.buttonManajemenUser.UseVisualStyleBackColor = true;
            // 
            // buttonManajemenEquipment
            // 
            this.buttonManajemenEquipment.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonManajemenEquipment.FlatAppearance.BorderSize = 0;
            this.buttonManajemenEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManajemenEquipment.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManajemenEquipment.ForeColor = System.Drawing.Color.White;
            this.buttonManajemenEquipment.Location = new System.Drawing.Point(-15, 172);
            this.buttonManajemenEquipment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonManajemenEquipment.Name = "buttonManajemenEquipment";
            this.buttonManajemenEquipment.Size = new System.Drawing.Size(234, 42);
            this.buttonManajemenEquipment.TabIndex = 2;
            this.buttonManajemenEquipment.Text = "Manajemen Equipment";
            this.buttonManajemenEquipment.UseVisualStyleBackColor = false;
            // 
            // buttonManajemenRental
            // 
            this.buttonManajemenRental.FlatAppearance.BorderSize = 0;
            this.buttonManajemenRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManajemenRental.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManajemenRental.ForeColor = System.Drawing.Color.White;
            this.buttonManajemenRental.Location = new System.Drawing.Point(-15, 120);
            this.buttonManajemenRental.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonManajemenRental.Name = "buttonManajemenRental";
            this.buttonManajemenRental.Size = new System.Drawing.Size(234, 42);
            this.buttonManajemenRental.TabIndex = 3;
            this.buttonManajemenRental.Text = "Manajemen Rental";
            this.buttonManajemenRental.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 609);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(207, 83);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.buttonManajemenRental);
            this.panel1.Controls.Add(this.buttonManajemenEquipment);
            this.panel1.Controls.Add(this.buttonManajemenUser);
            this.panel1.Controls.Add(this.buttonDashboardAdmin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 692);
            this.panel1.TabIndex = 3;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Nama Barang";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Brand";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 30);
            this.label4.TabIndex = 31;
            this.label4.Text = "Harga";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 33;
            this.label6.Text = "Category";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(182, 30);
            this.label7.TabIndex = 34;
            this.label7.Text = "Image Directory";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 20);
            this.label8.TabIndex = 35;
            this.label8.Text = "Status";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(580, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 30);
            this.label9.TabIndex = 36;
            this.label9.Text = "Description";
            // 
            // ManajemenEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManajemenEquipment";
            this.Text = "ManajemenEquipment";
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgEquipment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgEquipment;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.TextBox tbEquipmentName;
        private System.Windows.Forms.Button btnhapus;
        private System.Windows.Forms.Button buttnrfresh;
        private System.Windows.Forms.Button bttnedit;
        private System.Windows.Forms.Button btnsimpan;
        private System.Windows.Forms.TextBox tbBrand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDashboardAdmin;
        private System.Windows.Forms.Button buttonManajemenUser;
        private System.Windows.Forms.Button buttonManajemenEquipment;
        private System.Windows.Forms.Button buttonManajemenRental;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.TextBox tbImage;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.ComboBox cbStatus;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}