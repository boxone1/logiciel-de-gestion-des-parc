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
    public partial class addSupplier : Form
    {
        public string state;
        Main main = new Main();
        clientPage clientPage = new clientPage();
        public int id;
        public addSupplier()
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
                    clientPage.LoadData();
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("لم يتم التعديل");
                }


            }
            else {
                addclient();
                clientPage.LoadData();
            }
            
            this.Close();



        }
        private void addclient()
        {
            var date = DateTime.Now;
            BL.ClsClient BlClient = new BL.ClsClient();
            BlClient.addClient(txt_name.Text, txt_phone.Text, txt_adress.Text, date);
            

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
