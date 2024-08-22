
using gestionDesParc.addPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace gestionDesParc.Pages
{
    public partial class Purchase : UserControl
    {


        DBGPEntities4 db;
       
        TB_STOCK stock;
        TB_SUPPLIER supplier;

        addClient addSupplier;
        

        string state ="add";
        public int IDSupplier=0;
        public int Id;
        double total=0;
        
        public double quantityBarre;
        public double quantityQuintale;
       
        public Purchase()
        {
            InitializeComponent();
            
            articleAutoco();
            txt_barrePrice.Enabled = false;
        }

      

      


        private void btn_add_Click(object sender, EventArgs e)
        {
            addItem();
        }


        // add item to the datagridview
        private void addItem()
        {
            try
            {
                
                if (txt_article.Text != "" || upDownQuantity.Value != 0)
                {
                    //var stockquantity = Convert.ToDouble(quanitity) + Convert.ToDouble(lbl_quantity.Text);
                    stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();
                    var unity = stock.Unity;

                    if (state == "add")
                    {
                        bool found = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["articleName"].Value?.ToString() == txt_article.Text)
                            {
                                if (stock.Type == "fer")
                                {
                                    
                                        row.Cells["quantity"].Value = Convert.ToDouble(upDownQuantity.Value) + Convert.ToDouble(row.Cells["quantity"].Value);
                                    
                                }
                                else
                                {
                                    row.Cells["quantity"].Value = Convert.ToDouble(upDownQuantity.Value) + Convert.ToDouble(row.Cells["quantity"].Value);
                                }

                                //row.Cells["total"].Value = Convert.ToDouble(txt_totalPurchasePrice.Text) + Convert.ToDouble(row.Cells["total"].Value);
                                found = true;
                                break;
                            }
                             total += Convert.ToDouble(row.Cells["purchasePrice"].Value);
                        }

                        if (!found)
                        {
                            dataGridView1.Rows.Add(txt_article.Text, upDownQuantity.Value, lbl_unity.Text, txt_purchasePrice.Text, txt_transportation.Text, txt_unload.Text, txt_sellingPrice.Text, txt_barrePrice.Text, txt_loadPrice.Text);
                         //   getTotal();
                            txt_supplierName.Enabled = false;
                            txt_barrePrice.Text = "0";
                        }

                        txt_total.Text = total.ToString();
                    }
                    else if (state == "edit")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["articleName"].Value?.ToString() == txt_article.Text)
                            {
                                //row.Cells["quantity"].Value = Convert.ToDouble(upDownQuantity.Value);
                               // row.Cells["total"].Value = Convert.ToDouble(txt_purchasePrice.Text);

                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("يرجى ادخال البيانات كاملة و بشكل صحيح");
                }

                state = "add";
                getArticleInfos();
                upDownQuantity.Value = 0;
                
                // Reset UI elements if needed
            }
            catch (Exception ex)
            {
                MessageBox.Show("تاكد من ادخال المعلومات كاملة و بشكل صحيح. Error: " + ex.Message);
            }

        }
       
        public void articleAutoco()
        {

            try
            {
                db = new DBGPEntities4();
                stock = new TB_STOCK();
                var listData = db.TB_STOCK.Select(x => x.ArticleName).ToList();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(listData.ToArray());

                txt_article.AutoCompleteCustomSource = collection;
                txt_article.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_article.AutoCompleteMode = AutoCompleteMode.Suggest;
                if (txt_article.Text != "")
                {
                    

                    if (collection.Contains(txt_article.Text))
                    {
                        
                        getArticleInfos();
                        txt_article.MaxLength = txt_article.Text.Length;


                    }
                    else
                    {

                        txt_article.MaxLength = 50;
                    }
                }
                else
                {

                    txt_sellingPrice.Text = "0";
                }
            }
            catch{}

        }

        private void txt_article_TextChanged(object sender, EventArgs e)
        {
            articleAutoco();
            
            

        }

      
       

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }


      

       

      
       
        private void getArticleInfos()
        {
            try
            {

                stock = new TB_STOCK();
                db = new DBGPEntities4();
                stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();
                lbl_unity.Text = stock.Unity.ToString();

                if (stock.Type == "fer")
                {
                    txt_barrePrice.Enabled = true;
                  
                    txt_sellingPrice.Text = stock.Price.ToString();
                    txt_barrePrice.Text = stock.Price2.ToString();
                    txt_barrePrice.Enabled = true;
                    txt_loadPrice.Text = stock.loadingPrice.ToString();

                }
                else
                {
                    txt_barrePrice.Enabled = false;
                  
                    txt_sellingPrice.Text = stock.Price.ToString();
                    txt_barrePrice.Text = "0";
                    txt_barrePrice.Enabled = false;
                    txt_loadPrice.Text = stock.loadingPrice.ToString();

                }




            }
            catch
            {
              
                lbl_unity.Text = "##";
            }
        }

        // calculat the price when a textfield changed
        private void calculatePrice()
        {
            try
            {
                txt_totalPurchasePrice.Text=(Convert.ToDouble(txt_purchasePrice.Text)+ Convert.ToDouble(txt_transportation.Text)+ Convert.ToDouble(txt_unload.Text)).ToString();

                txt_unityPurchasePrice.Text=(Convert.ToDouble(txt_totalPurchasePrice.Text)/Convert.ToDouble(upDownQuantity.Value)).ToString();

                txt_profit.Text= (Convert.ToDouble(txt_sellingPrice.Text)* Convert.ToDouble(upDownQuantity.Value) - Convert.ToDouble(txt_totalPurchasePrice.Text)).ToString();

            }
            catch { }

        }


 
        //updqating total price
        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_loadPrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

      
     



        private void btn_delete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                try
                {
                    if (oneCell.Selected)
                        dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
                    else
                    {
                        MessageBox.Show("لا توجد مشتريات لحذفها");

                    }
                }
                catch { MessageBox.Show("لا توجد مشتريات لحذفها"); }
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            state = "edit";
            txt_article.Text = dataGridView1.CurrentRow.Cells["articleName"].Value.ToString();
            upDownQuantity.Value = Convert.ToInt64(dataGridView1.CurrentRow.Cells["quantity"].Value);
        }

        /// save the sale and make a bill (save)
        private int InsertSellRecord()
        {
            int sellId = 0;
            try
            {
                using (var context = new DBGPEntities4())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var supplierName = txt_supplierName.Text;

                            if (supplierName == "fournisseur")
                            {
                                IDSupplier = 0;
                            }
                            else
                            {
                                supplier = context.TB_SUPPLIER.FirstOrDefault(x => x.SupplierName == supplierName);
                                IDSupplier = supplier?.ID ?? 0;
                            }

                            state = txt_rest.Text == "0" ? "غير مدان" : "مدان";

                            // Update the stock
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var name = row.Cells["articleName"].Value.ToString();
                                stock = context.TB_STOCK.FirstOrDefault(x => x.ArticleName == name);

                                if (stock != null)
                                {
                                    stock.Quantity += Convert.ToDouble(row.Cells["quantity"].Value);
                                    stock.Price = Convert.ToDouble(row.Cells["price1"].Value);
                                    stock.Price2 = Convert.ToDouble(row.Cells["price2"].Value);
                                    stock.loadingPrice = Convert.ToDouble(row.Cells["loadingPrice"].Value);
                                }
                            }

                            // Save stock changes
                            context.SaveChanges();

                            // Insert a new purchase record
                            var purchase = new TB_PURCHASE
                            {
                                Date = DateTime.Now,
                                SupplierName = supplierName,
                                Supplier_ID = IDSupplier,
                                PaymentState = state,
                                Payment = Convert.ToDouble(txt_paidAmount.Text),
                                Debt = Convert.ToDouble(txt_rest.Text)
                            };
                            context.TB_PURCHASE.Add(purchase);
                            context.SaveChanges();

                            // Update supplier's debt
                            if (IDSupplier != 0)
                            {
                                supplier.Debt = Convert.ToDouble(txt_rest.Text);
                                context.SaveChanges();
                            }

                            // Insert each item from the DataGridView into TB_ARTICLE
                            var billItems = new List<TB_ARTICLE>();
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var billItem = new TB_ARTICLE
                                {
                                    Supplier_ID = IDSupplier,
                                    ID_Purchase = purchase.ID, // Use the purchase ID
                                    Name = row.Cells["articleName"].Value.ToString(),
                                    SupplierName = supplierName,
                                    Description = "",
                                    Type = "",
                                    Unity = row.Cells["unity"].Value.ToString(),
                                    Quantity = Convert.ToDouble(row.Cells["quantity"].Value),
                                    PurchasePrice = Convert.ToDouble(row.Cells["purchasePrice"].Value),
                                    SellingPrice = Convert.ToDouble(row.Cells["price1"].Value),
                                    SellingPrice2 = Convert.ToDouble(row.Cells["price2"].Value),
                                    Transport = Convert.ToDouble(row.Cells["transportationPrice"].Value),
                                    Unload = Convert.ToDouble(row.Cells["unloadPrice"].Value),
                                    Date = DateTime.Now
                                };

                                billItems.Add(billItem);
                            }

                            context.TB_ARTICLE.AddRange(billItems);
                            context.SaveChanges();

                            // Commit the transaction
                            transaction.Commit();

                            sellId = purchase.ID;
                            MessageBox.Show("تمت عملية الحفظ بنجاح");
                        }
                        catch (DbEntityValidationException ex)
                        {
                            // Rollback transaction if any error occurs
                            transaction.Rollback();
                            foreach (var validationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction if any error occurs
                            transaction.Rollback();
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected Error: {ex.Message}");
            }

            return sellId;
        }

        private void link_addClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addSupplier= new addClient();
            addSupplier.Show();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
          

        }


        private void upDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void updown_barQuantity_ValueChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_transportation_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_unload_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_sellingPrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_purchasePrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_barrePrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_loadPrice_TextChanged_1(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_totalPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_unityPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void link_addSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addClient addsupplier= new addClient();
            addsupplier.personState = "supplier";
            addsupplier.Show();
        }

        private void txt_supplierName_TextChanged(object sender, EventArgs e)
        {
            supplierAutoco();
        }

        private void txt_unload_TextChanged_1(object sender, EventArgs e)
        {
            calculatePrice();
        }

        private void txt_description_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txt_paidAmount_TextChanged(object sender, EventArgs e)
        {
                try
                {
                    txt_rest.Text = (Convert.ToDouble(txt_total.Text) - Convert.ToDouble(txt_paidAmount.Text)).ToString();
                }
                catch { txt_rest.Text = txt_total.Text; }

            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            InsertSellRecord();
        }

        public void supplierAutoco()
        {

            try
            {
                db = new DBGPEntities4();
                supplier = new TB_SUPPLIER();
                var listData = db.TB_SUPPLIER.Select(x => x.SupplierName).ToList();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(listData.ToArray());
                txt_supplierName.AutoCompleteCustomSource = collection;
                if (collection.Contains(txt_supplierName.Text))

                {
                  
                        
                        supplier = db.TB_SUPPLIER.Where(x => x.SupplierName == txt_supplierName.Text).FirstOrDefault();
                        lbl_supplierDebt.Text = supplier.Debt.ToString();
                    
                }
                else

                {
                    lbl_supplierDebt.Text = "0.0";
                    
                }

            }
            catch
            {
                txt_supplierName.Text = "client";
            }
        }


    }

}