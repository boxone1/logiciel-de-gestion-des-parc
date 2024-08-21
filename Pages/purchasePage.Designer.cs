namespace gestionDesParc.Pages
{
    partial class purchasePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(purchasePage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_search = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_print = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_delete = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_add = new Bunifu.Framework.UI.BunifuThinButton2();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.tBCLIENTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBGPEntities2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_bill = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_edit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCLIENTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGPEntities2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 611);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 15);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btn_bill);
            this.panel2.Controls.Add(this.btn_edit);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.btn_search);
            this.panel2.Controls.Add(this.btn_print);
            this.panel2.Controls.Add(this.txt_search);
            this.panel2.Controls.Add(this.btn_delete);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 89);
            this.panel2.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("LBC", 10F, System.Drawing.FontStyle.Bold);
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 58);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 25);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // btn_search
            // 
            this.btn_search.ActiveBorderThickness = 1;
            this.btn_search.ActiveCornerRadius = 20;
            this.btn_search.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_search.ActiveForecolor = System.Drawing.Color.White;
            this.btn_search.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_search.BackColor = System.Drawing.Color.Transparent;
            this.btn_search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_search.BackgroundImage")));
            this.btn_search.ButtonText = "بحث";
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.IdleBorderThickness = 1;
            this.btn_search.IdleCornerRadius = 20;
            this.btn_search.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_search.IdleForecolor = System.Drawing.Color.White;
            this.btn_search.IdleLineColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(245, 1);
            this.btn_search.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(72, 51);
            this.btn_search.TabIndex = 11;
            this.btn_search.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_print
            // 
            this.btn_print.ActiveBorderThickness = 1;
            this.btn_print.ActiveCornerRadius = 20;
            this.btn_print.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_print.ActiveForecolor = System.Drawing.Color.White;
            this.btn_print.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_print.BackColor = System.Drawing.Color.Transparent;
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
            this.btn_print.Location = new System.Drawing.Point(329, 0);
            this.btn_print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(72, 51);
            this.btn_print.TabIndex = 11;
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("LBC", 18F, System.Drawing.FontStyle.Bold);
            this.txt_search.Location = new System.Drawing.Point(10, 6);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(226, 38);
            this.txt_search.TabIndex = 1;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.ActiveBorderThickness = 1;
            this.btn_delete.ActiveCornerRadius = 20;
            this.btn_delete.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_delete.ActiveForecolor = System.Drawing.Color.White;
            this.btn_delete.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_delete.BackgroundImage")));
            this.btn_delete.ButtonText = "حذف";
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.IdleBorderThickness = 1;
            this.btn_delete.IdleCornerRadius = 20;
            this.btn_delete.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_delete.IdleForecolor = System.Drawing.Color.White;
            this.btn_delete.IdleLineColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(633, 4);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(72, 51);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.ActiveBorderThickness = 1;
            this.btn_add.ActiveCornerRadius = 20;
            this.btn_add.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_add.ActiveForecolor = System.Drawing.Color.White;
            this.btn_add.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add.BackgroundImage")));
            this.btn_add.ButtonText = "اضافة";
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.IdleBorderThickness = 1;
            this.btn_add.IdleCornerRadius = 20;
            this.btn_add.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_add.IdleForecolor = System.Drawing.Color.White;
            this.btn_add.IdleLineColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(717, 5);
            this.btn_add.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(71, 50);
            this.btn_add.TabIndex = 14;
            this.btn_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // dBGPEntities2BindingSource
            // 
            this.dBGPEntities2BindingSource.DataSource = typeof(gestionDesParc.DBGPEntities4);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("LBC", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(794, 522);
            this.dataGridView1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(794, 522);
            this.panel3.TabIndex = 7;
            // 
            // btn_bill
            // 
            this.btn_bill.ActiveBorderThickness = 1;
            this.btn_bill.ActiveCornerRadius = 20;
            this.btn_bill.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_bill.ActiveForecolor = System.Drawing.Color.White;
            this.btn_bill.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_bill.BackColor = System.Drawing.Color.Transparent;
            this.btn_bill.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_bill.BackgroundImage")));
            this.btn_bill.ButtonText = "فاتورة";
            this.btn_bill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_bill.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bill.ForeColor = System.Drawing.Color.White;
            this.btn_bill.IdleBorderThickness = 1;
            this.btn_bill.IdleCornerRadius = 20;
            this.btn_bill.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_bill.IdleForecolor = System.Drawing.Color.White;
            this.btn_bill.IdleLineColor = System.Drawing.Color.White;
            this.btn_bill.Location = new System.Drawing.Point(447, 4);
            this.btn_bill.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_bill.Name = "btn_bill";
            this.btn_bill.Size = new System.Drawing.Size(90, 51);
            this.btn_bill.TabIndex = 16;
            this.btn_bill.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_bill.Click += new System.EventHandler(this.btn_bill_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.ActiveBorderThickness = 1;
            this.btn_edit.ActiveCornerRadius = 20;
            this.btn_edit.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_edit.ActiveForecolor = System.Drawing.Color.White;
            this.btn_edit.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_edit.BackgroundImage")));
            this.btn_edit.ButtonText = "تعديل";
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.IdleBorderThickness = 1;
            this.btn_edit.IdleCornerRadius = 20;
            this.btn_edit.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_edit.IdleForecolor = System.Drawing.Color.White;
            this.btn_edit.IdleLineColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(549, 4);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(72, 51);
            this.btn_edit.TabIndex = 17;
            this.btn_edit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // purchasePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "purchasePage";
            this.Size = new System.Drawing.Size(794, 626);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBCLIENTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBGPEntities2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource tBCLIENTBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_search;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_delete;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_add;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_print;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_search;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.BindingSource dBGPEntities2BindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_bill;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_edit;
    }
}
