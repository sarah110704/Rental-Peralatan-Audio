namespace UAS_PBO.view
{
    partial class FormCustomerDashboard
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgCart = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSewa = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dtpSewa = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpKembali = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCart)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 69);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1180, 569);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dgCart
            // 
            this.dgCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCart.Location = new System.Drawing.Point(18, 708);
            this.dgCart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgCart.Name = "dgCart";
            this.dgCart.RowHeadersWidth = 62;
            this.dgCart.Size = new System.Drawing.Size(786, 246);
            this.dgCart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 660);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "List Barang Yang Dipilih";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 34);
            this.label2.TabIndex = 3;
            this.label2.Text = "Daftar Barang";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(906, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(290, 26);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(825, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search";
            // 
            // btnSewa
            // 
            this.btnSewa.Location = new System.Drawing.Point(836, 879);
            this.btnSewa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSewa.Name = "btnSewa";
            this.btnSewa.Size = new System.Drawing.Size(369, 75);
            this.btnSewa.TabIndex = 6;
            this.btnSewa.Text = "Sewa";
            this.btnSewa.UseVisualStyleBackColor = true;
            this.btnSewa.Click += new System.EventHandler(this.btnSewa_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(836, 800);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(369, 69);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // dtpSewa
            // 
            this.dtpSewa.Location = new System.Drawing.Point(836, 740);
            this.dtpSewa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSewa.Name = "dtpSewa";
            this.dtpSewa.Size = new System.Drawing.Size(172, 26);
            this.dtpSewa.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(831, 708);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tanggal Penyewaan";
            // 
            // dtpKembali
            // 
            this.dtpKembali.Location = new System.Drawing.Point(1038, 740);
            this.dtpKembali.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpKembali.Name = "dtpKembali";
            this.dtpKembali.Size = new System.Drawing.Size(164, 26);
            this.dtpKembali.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1034, 708);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tanggal Pengembalian";
            // 
            // FormCustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 975);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpKembali);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpSewa);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSewa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgCart);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormCustomerDashboard";
            this.Text = "Customer Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.dgCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSewa;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DateTimePicker dtpSewa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpKembali;
        private System.Windows.Forms.Label label5;
    }
}