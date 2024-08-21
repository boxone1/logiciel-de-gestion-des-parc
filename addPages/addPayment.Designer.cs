namespace gestionDesParc.addPages
{
    partial class addPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addPayment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_pay = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_paymentAmount = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_pay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_paymentAmount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 183);
            this.panel1.TabIndex = 0;
            // 
            // btn_pay
            // 
            this.btn_pay.ActiveBorderThickness = 1;
            this.btn_pay.ActiveCornerRadius = 20;
            this.btn_pay.ActiveFillColor = System.Drawing.Color.Teal;
            this.btn_pay.ActiveForecolor = System.Drawing.Color.White;
            this.btn_pay.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btn_pay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_pay.BackColor = System.Drawing.SystemColors.Control;
            this.btn_pay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_pay.BackgroundImage")));
            this.btn_pay.ButtonText = "دفع";
            this.btn_pay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pay.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.ForeColor = System.Drawing.Color.White;
            this.btn_pay.IdleBorderThickness = 1;
            this.btn_pay.IdleCornerRadius = 20;
            this.btn_pay.IdleFillColor = System.Drawing.Color.DarkSlateGray;
            this.btn_pay.IdleForecolor = System.Drawing.Color.White;
            this.btn_pay.IdleLineColor = System.Drawing.Color.White;
            this.btn_pay.Location = new System.Drawing.Point(161, 105);
            this.btn_pay.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(71, 50);
            this.btn_pay.TabIndex = 11;
            this.btn_pay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(111, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "ادخل المبلغ المراد دفعه";
            // 
            // txt_paymentAmount
            // 
            this.txt_paymentAmount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_paymentAmount.Location = new System.Drawing.Point(115, 58);
            this.txt_paymentAmount.Name = "txt_paymentAmount";
            this.txt_paymentAmount.Size = new System.Drawing.Size(178, 28);
            this.txt_paymentAmount.TabIndex = 0;
            // 
            // addPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 183);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("LBC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "addPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addPayment";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_pay;
        public System.Windows.Forms.TextBox txt_paymentAmount;
    }
}