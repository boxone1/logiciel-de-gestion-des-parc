using DevExpress.XtraEditors.Popup;
using gestionDesParc.BL;
using gestionDesParc.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionDesParc.addPages
{
    public partial class addClient : Form
    {
        DBGPEntities4 db;
        TB_SUPPLIER supplier;
        TB_CLIENT client;
        public string state="add";
        public string personState;
        Main main = new Main();
        clientPage clientPage = new clientPage();
        public int id;
        public addClient()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if (state == "add")
            {
               
                addclient();
                clientPage.LoadData();
            }

            else if (state == "update") {
                DialogResult dialogResult = MessageBox.Show("هل تعديل بيانات هذا الزبون؟", "عملية تعديل", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    updateClient();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("لم يتم التعديل");
                }
                clientPage.LoadData();

            }
            else {
                addclient();
                clientPage.LoadData();
            }
            
            this.Close();



        }
        private void addclient()
        {
            db = new DBGPEntities4();
            if (personState == "client")
            {
                client = new TB_CLIENT
                {
                    ClientName = txt_name.Text,
                    Phone = txt_phone.Text,
                    Adress = txt_adress.Text,
                    Debt = 0,
                    Date = DateTime.Now


                };
                db.TB_CLIENT.Add(client);
                db.SaveChanges();
            }
            else if (personState == "supplier")
            {
                supplier = new TB_SUPPLIER
                {
                    SupplierName = txt_name.Text,
                    Phone = txt_phone.Text,
                    Adress = txt_adress.Text,
                    Debt = 0,
                    Date= DateTime.Now


                };
                db.TB_SUPPLIER.Add(supplier);
                db.SaveChanges();

            }


        }
        private void updateClient()
        {

            var date = DateTime.Now;
            BL.ClsClient BlClient = new BL.ClsClient();
            BlClient.updateClient(txt_name.Text, txt_phone.Text, txt_adress.Text,id);
            this.Close();
            

        }
        
    }
}
