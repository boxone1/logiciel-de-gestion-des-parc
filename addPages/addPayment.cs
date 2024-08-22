﻿using gestionDesParc.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionDesParc.addPages
{
    public partial class addPayment : Form
    {
        public int id;
        public string state;
        paymentLog log = new paymentLog();
        TB_CLIENT client;
        TB_PAYMENT tbPayment;
        DBGPEntities4 db;
        public int clientID;
        public double oldPayment;
        public addPayment()
        {
            InitializeComponent();
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                makePayment();
                log.LoadData();

            }
            else if (state == "update")
            {
                editPayment();

                client = db.TB_CLIENT.Where(x => x.ID == clientID).FirstOrDefault();
                client.Debt = Convert.ToInt64(client.Debt) - Convert.ToInt64(txt_paymentAmount.Text);
                log.LoadData();

            }
            else { makePayment();
                log.LoadData(); }

            this.Close();

        }
        /*
        private void makePayment()
        {
            db = new DBGPEntities4 ();

            var paymentAmout = Convert.ToInt64(txt_paymentAmount.Text);
            var date = DateTime.Now;
            BL.ClsPymentLog BlPayment = new BL.ClsPymentLog();
            BlPayment.addPayment(clientID,paymentAmout, date);
            log.LoadData();

            
            client = db.TB_CLIENT.Where(x => x.ID == clientID).FirstOrDefault();
            client.Debt=Convert.ToInt64(client.Debt)-Convert.ToInt64(txt_paymentAmount.Text);
            db.SaveChanges();
        }*/
        
        private void makePayment()
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من قيمة الدفعة؟", "عملية دفع", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4 ();
            var paymentAmout = Convert.ToInt64(txt_paymentAmount.Text);
            var payment = new TB_PAYMENT
            {
                ID_Client = id,
                Payment = paymentAmout,
                Date = DateTime.Now,
            };
            db.TB_PAYMENT.Add(payment);


            
            client = db.TB_CLIENT.Where(x => x.ID == clientID).FirstOrDefault();
            client.Debt = Convert.ToInt64(client.Debt) - Convert.ToInt64(txt_paymentAmount.Text);

            db.SaveChanges();
            log.LoadData();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم الدفع");
            }



        }


        /*
        private void editPayment()
        {
            DialogResult dialogResult = MessageBox.Show("هل تريد التعديل؟", "عملية تعديل", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var paymentAmout =oldPayment - Convert.ToDouble(txt_paymentAmount.Text);
            
            BL.ClsPymentLog BlPyment = new BL.ClsPymentLog();
            BlPyment.editPayment(paymentAmout, id);
            this.Close();
            log.LoadData();

            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم التعديل");
            }


        }
        */

        private void editPayment()
        {
            DialogResult dialogResult = MessageBox.Show("هل انت متاكد من قيمة الدفعة؟", "عملية دفع", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                db = new DBGPEntities4();
                var paymentAmout = oldPayment - Convert.ToDouble(txt_paymentAmount.Text);
                tbPayment = db.TB_PAYMENT.Where(x=>x.ID==id).FirstOrDefault();
                tbPayment.Payment=paymentAmout;
                tbPayment.Date=DateTime.Now;

                db.Entry(tbPayment).State = EntityState.Modified;


                client = db.TB_CLIENT.Where(x => x.ID == clientID).FirstOrDefault();
                client.Debt = Convert.ToInt64(client.Debt) -( Convert.ToDouble(oldPayment)- Convert.ToInt64(txt_paymentAmount.Text));

                db.Entry(client).State = EntityState.Modified;


                db.SaveChanges();
                log.LoadData();
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("لم يتم الدفع");
            }



        }



    }
}
