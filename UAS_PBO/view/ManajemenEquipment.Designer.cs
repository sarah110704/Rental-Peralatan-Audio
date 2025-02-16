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
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
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
            this.panel2.Location = new System.Drawing.Point(137, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 49);
            this.panel2.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(67, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Manajemen Equipment ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
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
            this.panel3.Location = new System.Drawing.Point(137, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 401);
            this.panel3.TabIndex = 5;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Speaker",
            "Microphone",
            "Mixer",
            "Instrument"});
            this.cbCategory.Location = new System.Drawing.Point(205, 26);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(172, 21);
            this.cbCategory.TabIndex = 26;
            // 
            // btnDirectory
            // 
            this.btnDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDirectory.Location = new System.Drawing.Point(354, 122);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(23, 27);
            this.btnDirectory.TabIndex = 25;
            this.btnDirectory.Text = "...";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(31, 173);
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(152, 20);
            this.numStock.TabIndex = 24;
            // 
            // tbImage
            // 
            this.tbImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbImage.Location = new System.Drawing.Point(205, 122);
            this.tbImage.Margin = new System.Windows.Forms.Padding(2);
            this.tbImage.Multiline = true;
            this.tbImage.Name = "tbImage";
            this.tbImage.Size = new System.Drawing.Size(144, 27);
            this.tbImage.TabIndex = 23;
            this.tbImage.Text = "Image Path";
            // 
            // tbDescription
            // 
            this.tbDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbDescription.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbDescription.Location = new System.Drawing.Point(389, 26);
            this.tbDescription.Margin = new System.Windows.Forms.Padding(2);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(172, 142);
            this.tbDescription.TabIndex = 22;
            this.tbDescription.Text = "Deskripsi Alat";
            // 
            // dgEquipment
            // 
            this.dgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEquipment.Location = new System.Drawing.Point(29, 206);
            this.dgEquipment.Name = "dgEquipment";
            this.dgEquipment.Size = new System.Drawing.Size(608, 169);
            this.dgEquipment.TabIndex = 20;
            this.dgEquipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEquipment_CellClick);
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbPrice.Location = new System.Drawing.Point(31, 122);
            this.tbPrice.Margin = new System.Windows.Forms.Padding(2);
            this.tbPrice.Multiline = true;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(152, 27);
            this.tbPrice.TabIndex = 19;
            this.tbPrice.Text = "Harga Rental";
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbSearch.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.tbSearch.Location = new System.Drawing.Point(389, 173);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(2);
            this.tbSearch.Multiline = true;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(248, 28);
            this.tbSearch.TabIndex = 18;
            this.tbSearch.Text = "Search";
            // 
            // tbEquipmentName
            // 
            this.tbEquipmentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbEquipmentName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbEquipmentName.Location = new System.Drawing.Point(31, 25);
            this.tbEquipmentName.Margin = new System.Windows.Forms.Padding(2);
            this.tbEquipmentName.Multiline = true;
            this.tbEquipmentName.Name = "tbEquipmentName";
            this.tbEquipmentName.Size = new System.Drawing.Size(152, 27);
            this.tbEquipmentName.TabIndex = 16;
            this.tbEquipmentName.Text = "Nama Barang";
            // 
            // btnhapus
            // 
            this.btnhapus.BackColor = System.Drawing.Color.Brown;
            this.btnhapus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhapus.Location = new System.Drawing.Point(575, 63);
            this.btnhapus.Name = "btnhapus";
            this.btnhapus.Size = new System.Drawing.Size(62, 31);
            this.btnhapus.TabIndex = 13;
            this.btnhapus.Text = "Hapus";
            this.btnhapus.UseVisualStyleBackColor = false;
            this.btnhapus.Click += new System.EventHandler(this.btnhapus_Click);
            // 
            // buttnrfresh
            // 
            this.buttnrfresh.Location = new System.Drawing.Point(575, 137);
            this.buttnrfresh.Name = "buttnrfresh";
            this.buttnrfresh.Size = new System.Drawing.Size(62, 31);
            this.buttnrfresh.TabIndex = 12;
            this.buttnrfresh.Text = "Refresh";
            this.buttnrfresh.UseVisualStyleBackColor = true;
            this.buttnrfresh.Click += new System.EventHandler(this.buttnrfresh_Click);
            // 
            // bttnedit
            // 
            this.bttnedit.BackColor = System.Drawing.Color.MediumTurquoise;
            this.bttnedit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.bttnedit.Location = new System.Drawing.Point(575, 100);
            this.bttnedit.Name = "bttnedit";
            this.bttnedit.Size = new System.Drawing.Size(62, 31);
            this.bttnedit.TabIndex = 11;
            this.bttnedit.Text = "Edit";
            this.bttnedit.UseVisualStyleBackColor = false;
            this.bttnedit.Click += new System.EventHandler(this.bttnedit_Click);
            // 
            // btnsimpan
            // 
            this.btnsimpan.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnsimpan.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnsimpan.Location = new System.Drawing.Point(575, 25);
            this.btnsimpan.Name = "btnsimpan";
            this.btnsimpan.Size = new System.Drawing.Size(62, 32);
            this.btnsimpan.TabIndex = 10;
            this.btnsimpan.Text = "Simpan";
            this.btnsimpan.UseVisualStyleBackColor = false;
            this.btnsimpan.Click += new System.EventHandler(this.btnsimpan_Click);
            // 
            // tbBrand
            // 
            this.tbBrand.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbBrand.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tbBrand.Location = new System.Drawing.Point(31, 75);
            this.tbBrand.Margin = new System.Windows.Forms.Padding(2);
            this.tbBrand.Multiline = true;
            this.tbBrand.Name = "tbBrand";
            this.tbBrand.Size = new System.Drawing.Size(152, 27);
            this.tbBrand.TabIndex = 9;
            this.tbBrand.Text = "Brand";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // buttonDashboardAdmin
            // 
            this.buttonDashboardAdmin.FlatAppearance.BorderSize = 0;
            this.buttonDashboardAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDashboardAdmin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDashboardAdmin.ForeColor = System.Drawing.Color.White;
            this.buttonDashboardAdmin.Location = new System.Drawing.Point(-10, 49);
            this.buttonDashboardAdmin.Name = "buttonDashboardAdmin";
            this.buttonDashboardAdmin.Size = new System.Drawing.Size(156, 27);
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
            this.buttonManajemenUser.Location = new System.Drawing.Point(-10, 89);
            this.buttonManajemenUser.Name = "buttonManajemenUser";
            this.buttonManajemenUser.Size = new System.Drawing.Size(156, 27);
            this.buttonManajemenUser.TabIndex = 1;
            this.buttonManajemenUser.Text = "Manajemen User";
            this.buttonManajemenUser.UseVisualStyleBackColor = true;
            // 
            // buttonManajemenEquipment
            // 
            this.buttonManajemenEquipment.FlatAppearance.BorderSize = 0;
            this.buttonManajemenEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManajemenEquipment.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManajemenEquipment.ForeColor = System.Drawing.Color.White;
            this.buttonManajemenEquipment.Location = new System.Drawing.Point(-10, 171);
            this.buttonManajemenEquipment.Name = "buttonManajemenEquipment";
            this.buttonManajemenEquipment.Size = new System.Drawing.Size(156, 27);
            this.buttonManajemenEquipment.TabIndex = 2;
            this.buttonManajemenEquipment.Text = "Manajemen Equipment";
            this.buttonManajemenEquipment.UseVisualStyleBackColor = true;
            // 
            // buttonManajemenRental
            // 
            this.buttonManajemenRental.FlatAppearance.BorderSize = 0;
            this.buttonManajemenRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManajemenRental.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonManajemenRental.ForeColor = System.Drawing.Color.White;
            this.buttonManajemenRental.Location = new System.Drawing.Point(-10, 131);
            this.buttonManajemenRental.Name = "buttonManajemenRental";
            this.buttonManajemenRental.Size = new System.Drawing.Size(156, 27);
            this.buttonManajemenRental.TabIndex = 3;
            this.buttonManajemenRental.Text = "Manajemen Rental";
            this.buttonManajemenRental.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(0, 396);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 54);
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 450);
            this.panel1.TabIndex = 3;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Tersedia",
            "Tidak Tersedia",
            "Perawatan"});
            this.cbStatus.Location = new System.Drawing.Point(205, 75);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(172, 21);
            this.cbStatus.TabIndex = 28;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // ManajemenEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
    }
}