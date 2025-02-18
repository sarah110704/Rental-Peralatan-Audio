namespace UAS_PBO.view
{
    partial class ManajemenRental
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
            this.History = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgRental = new System.Windows.Forms.DataGridView();
            this.SearchRentals = new System.Windows.Forms.TextBox();
            this.buttnrfrsh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRental)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1033, 92);
            this.panel2.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(-14, 8);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(278, 57);
            this.button2.TabIndex = 1;
            this.button2.Text = "Manajemen Rental";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.History);
            this.panel3.Controls.Add(this.btnHapus);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dgRental);
            this.panel3.Controls.Add(this.SearchRentals);
            this.panel3.Controls.Add(this.buttnrfrsh);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 92);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 625);
            this.panel3.TabIndex = 4;
            // 
            // History
            // 
            this.History.Location = new System.Drawing.Point(847, 298);
            this.History.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(144, 42);
            this.History.TabIndex = 24;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            this.History.Click += new System.EventHandler(this.History_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.Location = new System.Drawing.Point(847, 230);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(144, 42);
            this.btnHapus.TabIndex = 23;
            this.btnHapus.Text = "Hapus";
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(847, 162);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(144, 42);
            this.btnEdit.TabIndex = 22;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 37);
            this.label2.TabIndex = 21;
            this.label2.Text = "Daftar Penyewaan";
            // 
            // dgRental
            // 
            this.dgRental.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRental.Location = new System.Drawing.Point(42, 162);
            this.dgRental.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgRental.Name = "dgRental";
            this.dgRental.RowHeadersWidth = 62;
            this.dgRental.Size = new System.Drawing.Size(776, 403);
            this.dgRental.TabIndex = 20;
            this.dgRental.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgRental_CellClick);
            // 
            // SearchRentals
            // 
            this.SearchRentals.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchRentals.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.SearchRentals.Location = new System.Drawing.Point(44, 55);
            this.SearchRentals.Multiline = true;
            this.SearchRentals.Name = "SearchRentals";
            this.SearchRentals.Size = new System.Drawing.Size(778, 44);
            this.SearchRentals.TabIndex = 18;
            this.SearchRentals.Text = "Search";
            // 
            // buttnrfrsh
            // 
            this.buttnrfrsh.Location = new System.Drawing.Point(847, 57);
            this.buttnrfrsh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttnrfrsh.Name = "buttnrfrsh";
            this.buttnrfrsh.Size = new System.Drawing.Size(144, 42);
            this.buttnrfrsh.TabIndex = 12;
            this.buttnrfrsh.Text = "Refresh";
            this.buttnrfrsh.UseVisualStyleBackColor = true;
            this.buttnrfrsh.Click += new System.EventHandler(this.buttnrfrsh_Click);
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
            // ManajemenRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 717);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManajemenRental";
            this.Text = "ManajemenRental";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRental)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgRental;
        private System.Windows.Forms.TextBox SearchRentals;
        private System.Windows.Forms.Button buttnrfrsh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button History;
    }
}