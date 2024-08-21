using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace gestionDesParc.addPages
{
    
    public partial class clientAdd : UserControl
    {
        public string state;
        Main main = new Main();
        public clientAdd()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            MessageBox.Show("click1");
            /*if (state == "add")
              {
                  addClient();
              }
              else if (state=="update"){ updateClient(); }
              */
            addClient();
            MessageBox.Show("click");
            
        }
        private void addClient()
        { 
            var date = DateTime.Now;
            BL.ClsClient BlClient = new BL.ClsClient();
            BlClient.addClient(txt_name.Text, txt_phone.Text, txt_adress.Text, date);
        }
        private void updateClient() {
            var date = DateTime.Now;
            BL.ClsClient BlClient = new BL.ClsClient();
            BlClient.addClient(txt_name.Text, txt_phone.Text, txt_adress.Text, DateTime.Now);
        
        }
    }
}
