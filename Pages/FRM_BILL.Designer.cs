namespace gestionDesParc.Pages
{
    partial class FRM_BILL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_BILL));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_rest = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_totalPrice = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_printDate = new System.Windows.Forms.Label();
            this.lbl_clientName = new System.Windows.Forms.Label();
            this.lbl_billDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_billId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_phone2 = new System.Windows.Forms.Label();
            this.lbl_fax = new System.Windows.Forms.Label();
            this.lbl_phone1 = new System.Windows.Forms.Label();
            this.lbl_billCompanyName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_print = new Bunifu.Framework.UI.BunifuThinButton2();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 588);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 262);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(843, 160);
            this.panel4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(843, 160);
            this.dataGridView1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lbl_rest);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lbl_totalPrice);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 422);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(843, 166);
            this.panel3.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(104, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 21);
            this.label14.TabIndex = 0;
            this.label14.Text = "الختم";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(774, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "الباقي";
            // 
            // lbl_rest
            // 
            this.lbl_rest.AutoSize = true;
            this.lbl_rest.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_rest.Location = new System.Drawing.Point(616, 79);
            this.lbl_rest.Name = "lbl_rest";
            this.lbl_rest.Size = new System.Drawing.Size(96, 21);
            this.lbl_rest.TabIndex = 0;
            this.lbl_rest.Text = "اسم الشركة";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(718, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "الثمن الاجمالي";
            // 
            // lbl_totalPrice
            // 
            this.lbl_totalPrice.AutoSize = true;
            this.lbl_totalPrice.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalPrice.Location = new System.Drawing.Point(616, 47);
            this.lbl_totalPrice.Name = "lbl_totalPrice";
            this.lbl_totalPrice.Size = new System.Drawing.Size(96, 21);
            this.lbl_totalPrice.TabIndex = 0;
            this.lbl_totalPrice.Text = "اسم الشركة";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_printDate);
            this.panel5.Controls.Add(this.lbl_clientName);
            this.panel5.Controls.Add(this.lbl_billDate);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.lbl_billId);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(843, 130);
            this.panel5.TabIndex = 3;
            // 
            // lbl_printDate
            // 
            this.lbl_printDate.AutoSize = true;
            this.lbl_printDate.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_printDate.Location = new System.Drawing.Point(55, 63);
            this.lbl_printDate.Name = "lbl_printDate";
            this.lbl_printDate.Size = new System.Drawing.Size(96, 21);
            this.lbl_printDate.TabIndex = 0;
            this.lbl_printDate.Text = "اسم الشركة";
            this.lbl_printDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_clientName
            // 
            this.lbl_clientName.AutoSize = true;
            this.lbl_clientName.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_clientName.Location = new System.Drawing.Point(566, 63);
            this.lbl_clientName.Name = "lbl_clientName";
            this.lbl_clientName.Size = new System.Drawing.Size(96, 21);
            this.lbl_clientName.TabIndex = 0;
            this.lbl_clientName.Text = "اسم الشركة";
            this.lbl_clientName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_billDate
            // 
            this.lbl_billDate.AutoSize = true;
            this.lbl_billDate.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_billDate.Location = new System.Drawing.Point(55, 25);
            this.lbl_billDate.Name = "lbl_billDate";
            this.lbl_billDate.Size = new System.Drawing.Size(96, 21);
            this.lbl_billDate.TabIndex = 0;
            this.lbl_billDate.Text = "اسم الشركة";
            this.lbl_billDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("LBC", 12F);
            this.label10.Location = new System.Drawing.Point(237, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "طبعت يوم";
            // 
            // lbl_billId
            // 
            this.lbl_billId.AutoSize = true;
            this.lbl_billId.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_billId.Location = new System.Drawing.Point(566, 25);
            this.lbl_billId.Name = "lbl_billId";
            this.lbl_billId.Size = new System.Drawing.Size(96, 21);
            this.lbl_billId.TabIndex = 0;
            this.lbl_billId.Text = "اسم الشركة";
            this.lbl_billId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("LBC", 12F);
            this.label9.Location = new System.Drawing.Point(237, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "تاريخ الفاتورة";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("LBC", 12F);
            this.label6.Location = new System.Drawing.Point(726, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "اسم الزبون";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("LBC", 12F);
            this.label5.Location = new System.Drawing.Point(726, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "رقم الفاتورة";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbl_email);
            this.panel6.Controls.Add(this.lbl_phone2);
            this.panel6.Controls.Add(this.lbl_fax);
            this.panel6.Controls.Add(this.lbl_phone1);
            this.panel6.Controls.Add(this.lbl_billCompanyName);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(843, 132);
            this.panel6.TabIndex = 4;
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(394, 88);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(218, 21);
            this.lbl_email.TabIndex = 0;
            this.lbl_email.Text = "EMAIL:example@gmail.com";
            // 
            // lbl_phone2
            // 
            this.lbl_phone2.AutoSize = true;
            this.lbl_phone2.Location = new System.Drawing.Point(394, 67);
            this.lbl_phone2.Name = "lbl_phone2";
            this.lbl_phone2.Size = new System.Drawing.Size(161, 21);
            this.lbl_phone2.TabIndex = 0;
            this.lbl_phone2.Text = "TEL: 05-98-64-25-31";
            // 
            // lbl_fax
            // 
            this.lbl_fax.AutoSize = true;
            this.lbl_fax.Location = new System.Drawing.Point(231, 88);
            this.lbl_fax.Name = "lbl_fax";
            this.lbl_fax.Size = new System.Drawing.Size(142, 21);
            this.lbl_fax.TabIndex = 0;
            this.lbl_fax.Text = "FAX:036-88-45-21";
            // 
            // lbl_phone1
            // 
            this.lbl_phone1.AutoSize = true;
            this.lbl_phone1.Location = new System.Drawing.Point(231, 67);
            this.lbl_phone1.Name = "lbl_phone1";
            this.lbl_phone1.Size = new System.Drawing.Size(157, 21);
            this.lbl_phone1.TabIndex = 0;
            this.lbl_phone1.Text = "TEL:06-98-25-44-75";
            // 
            // lbl_billCompanyName
            // 
            this.lbl_billCompanyName.AutoSize = true;
            this.lbl_billCompanyName.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_billCompanyName.Location = new System.Drawing.Point(373, 20);
            this.lbl_billCompanyName.Name = "lbl_billCompanyName";
            this.lbl_billCompanyName.Size = new System.Drawing.Size(96, 21);
            this.lbl_billCompanyName.TabIndex = 0;
            this.lbl_billCompanyName.Text = "اسم الشركة";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_print);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 588);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(843, 100);
            this.panel2.TabIndex = 1;
            // 
            // btn_print
            // 
            this.btn_print.ActiveBorderThickness = 1;
            this.btn_print.ActiveCornerRadius = 20;
            this.btn_print.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_print.ActiveForecolor = System.Drawing.Color.White;
            this.btn_print.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print.BackgroundImage")));
            this.btn_print.ButtonText = "طباعة";
            this.btn_print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_print.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.IdleBorderThickness = 1;
            this.btn_print.IdleCornerRadius = 20;
            this.btn_print.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_print.IdleForecolor = System.Drawing.Color.White;
            this.btn_print.IdleLineColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(756, 35);
            this.btn_print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(72, 51);
            this.btn_print.TabIndex = 11;
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // FRM_BILL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(843, 688);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FRM_BILL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فاتورة";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lbl_totalPrice;
        private System.Windows.Forms.Panel panel5;
        public System.Windows.Forms.Label lbl_printDate;
        public System.Windows.Forms.Label lbl_clientName;
        public System.Windows.Forms.Label lbl_billDate;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lbl_billId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_phone2;
        private System.Windows.Forms.Label lbl_fax;
        private System.Windows.Forms.Label lbl_phone1;
        private System.Windows.Forms.Label lbl_billCompanyName;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_print;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lbl_rest;
    }
}