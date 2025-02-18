namespace UAS_PBO.view
{
    partial class ParentCustomerDahsboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.rentalSekarangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onGoingRentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onGoingRentToolStripMenuItem,
            this.rentalSekarangToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 1016);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rentalSekarangToolStripMenuItem
            // 
            this.rentalSekarangToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rentalSekarangToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rentalSekarangToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.rentalSekarangToolStripMenuItem.Name = "rentalSekarangToolStripMenuItem";
            this.rentalSekarangToolStripMenuItem.Size = new System.Drawing.Size(223, 42);
            this.rentalSekarangToolStripMenuItem.Text = "Rent Equipment";
            this.rentalSekarangToolStripMenuItem.Click += new System.EventHandler(this.rentalSekarangToolStripMenuItem_Click);
            // 
            // onGoingRentToolStripMenuItem
            // 
            this.onGoingRentToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onGoingRentToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.onGoingRentToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.onGoingRentToolStripMenuItem.Name = "onGoingRentToolStripMenuItem";
            this.onGoingRentToolStripMenuItem.Size = new System.Drawing.Size(223, 42);
            this.onGoingRentToolStripMenuItem.Text = "On Going Rent";
            this.onGoingRentToolStripMenuItem.Click += new System.EventHandler(this.onGoingRentToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exitToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 42);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ParentCustomerDahsboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 1016);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ParentCustomerDahsboard";
            this.Text = "ParentCustomerDahsboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rentalSekarangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onGoingRentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}