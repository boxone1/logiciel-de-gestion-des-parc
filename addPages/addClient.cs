using gestionDesParc.Pages;
using System;
using System.Data;
using System.Linq;
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
        supplierPage supplierpage = new supplierPage();
        public int id;
        public addClient()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
            if (state == "add")
            {
                DialogResult dialogResult = MessageBox.Show("هل انت متاكد من المعلومات المدخلة؟", "عملية اضافة", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    update();

                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("لم يتم الاضافة");
                }


            }

            else if (state == "update") {
                DialogResult dialogResult = MessageBox.Show("هل تعديل بيانات هذا الزبون؟", "عملية تعديل", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    update();
                    
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("لم يتم التعديل");
                }

            }
            
            
            



        }
        private void add()
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
                clientPage.LoadData();
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
                supplierpage.LoadData();
            }

            

        }


        private void update()
        {
            if(personState== "client")
            {
                db = new DBGPEntities4();
                client = new TB_CLIENT();
                client = db.TB_CLIENT.Where(x => x.ID == id).FirstOrDefault();
                if (client != null)
                {
                    client.ClientName = txt_name.Text;
                    client.Adress = txt_adress.Text;
                    client.Phone = txt_phone.Text;

                }

                clientPage.LoadData();
            }
            else if (personState == "supplier")
            {

                db = new DBGPEntities4();
                supplier = new TB_SUPPLIER();
                supplier = db.TB_SUPPLIER.Where(x => x.ID == id).FirstOrDefault();
                if (supplier != null)
                {
                    supplier.SupplierName = txt_name.Text;
                    supplier.Adress = txt_adress.Text;
                    supplier.Phone = txt_phone.Text;

                }
                supplierpage.LoadData();
               

            }

            db.SaveChanges();
            this.Close();
        }

       
        
    }
}
