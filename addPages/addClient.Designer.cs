﻿namespace gestionDesParc.addPages
{
    partial class addClient
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_adress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_save);
            this.panel6.Controls.Add(this.txt_adress);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.txt_phone);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.txt_name);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(594, 528);
            this.panel6.TabIndex = 1;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Teal;
            this.btn_save.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(153, 341);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(289, 48);
            this.btn_save.TabIndex = 30;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_adress
            // 
            this.txt_adress.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_adress.Location = new System.Drawing.Point(153, 264);
            this.txt_adress.Name = "txt_adress";
            this.txt_adress.Size = new System.Drawing.Size(289, 34);
            this.txt_adress.TabIndex = 27;
            this.txt_adress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(259, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 27);
            this.label3.TabIndex = 24;
            this.label3.Text = "العنوان";
            // 
            // txt_phone
            // 
            this.txt_phone.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_phone.Location = new System.Drawing.Point(153, 184);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(289, 34);
            this.txt_phone.TabIndex = 28;
            this.txt_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 27);
            this.label2.TabIndex = 25;
            this.label2.Text = "رقم الهاتف";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(153, 105);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(289, 34);
            this.txt_name.TabIndex = 29;
            this.txt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("LBC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(234, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 27);
            this.label1.TabIndex = 26;
            this.label1.Text = "الاسم الكامل";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 528);
            this.panel1.TabIndex = 1;
            // 
            // addClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 528);
            this.Controls.Add(this.panel1);
            this.Name = "addClient";
            this.Text = "addClient";
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.Button btn_save;
        public System.Windows.Forms.TextBox txt_adress;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_phone;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_name;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}