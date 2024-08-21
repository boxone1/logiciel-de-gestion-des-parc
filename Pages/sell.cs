using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Helpers;
using DevExpress.Drawing.Internal.Fonts;
using DevExpress.Utils.Behaviors;
using DevExpress.Utils.Extensions;
using DevExpress.XtraPrinting.Shape.Native;
using gestionDesParc.addPages;
using gestionDesParc.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionDesParc.Pages
{
    public partial class sell : UserControl
    {

        ClsSell clsSell;

        DBGPEntities4 db, context;
        TB_ARTICLE tbArticle;
        TB_STOCK stock, article;
        TB_CLIENT client;
        TB_BILL bill;
        TB_SELL tbsell;
        addClient addClient;
        double totalprice;
        public string state = "add";
        public int IDClient = 0;
        public int Id;
        string Unity;
        public double quantityBarre;
        public double quantityQuintale;
        double quanitity;
        public int sellId = 0;
        Array articlesNames;

        public sell()
        {
            InitializeComponent();
            clientAutoco();
            articleAutoco();
            txt_clientName.Text = "client";
            panel_fer.Visible = false;

        }


        //set the quantity labels
        private void setQuantity()
        {
            db = new DBGPEntities4();

            stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();
            if (rb_barre.Checked == true)
            {
                quanitity = Convert.ToDouble(updown_barQuantity.Value);
                //txt_quantity.Text = updown_barQuantity.Value.ToString() ;

                Setquantity(quanitity);
                updown_barQuantity.Enabled = true;
                upDownQuantity.Enabled = false;
                upDownQuantity.Value = 0;
                Unity = "barre";
                decimal value = updown_barQuantity.Value;
                if (value % 0.5m != 0)
                {
                    updown_barQuantity.Value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
                }
                //  lbl_barreQuantity.Text = stock.QuantityBarre.ToString();
                lbl_unity2.Text = stock.Unity2.ToString();
                txt_price.Text = stock.Price2.ToString();
                txt_loadPrice.Text = (Convert.ToDouble(stock.loadingPrice) * ((Convert.ToDouble(upDownQuantity.Value) / Convert.ToDouble(stock.BarreInQuintale)))).ToString();

            }
            else if (rb_quintale.Checked == true)
            {
                //txt_quantity.Text = upDownQuantity.Value.ToString();
                quanitity = Convert.ToDouble(upDownQuantity.Value);
                Setquantity(quanitity);
                updown_barQuantity.Enabled = false;
                updown_barQuantity.Value = 0;
                upDownQuantity.Enabled = true;
                Unity = lbl_unity.Text;
                decimal value = upDownQuantity.Value;
                lbl_unity.Text = stock.Unity.ToString();
                txt_price.Text = stock.Price.ToString();
                txt_loadPrice.Text = (Convert.ToDouble(stock.loadingPrice) * Convert.ToDouble(upDownQuantity.Value)).ToString();

            }


        }


        // تحديد نسبة الزيادة في الكمية عند الضغط على الزر الزيادة
        //  لازم نعوظها بفونكسيو خير
        private void updownManag()
        {
            try
            {
                db = new DBGPEntities4();
                article = new TB_STOCK();
                upDownQuantity.Value = 0;
                upDownQuantity.Maximum = Convert.ToDecimal(lbl_quantity.Text);
                upDownQuantity.Minimum = 0;
                updown_barQuantity.Value = 0;
                updown_barQuantity.Maximum = Convert.ToDecimal(lbl_barreQuantity.Text);
                updown_barQuantity.Minimum = 0;
                article = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();

                if (article.Type == "fer")
                {
                    panel_fer.Visible = true;
                }
                else
                {
                    panel_fer.Visible = false;
                }


                if (article.Type == "sg")
                {
                    upDownQuantity.Increment = 0.25m;
                    upDownQuantity.DecimalPlaces = 2;

                }
                else if (article.Type == "fer")
                {
                    upDownQuantity.DecimalPlaces = 2;
                    updown_barQuantity.DecimalPlaces = 2;
                    updown_barQuantity.Increment = 1;

                    if (txt_article.Text == "fer6")
                    {
                        upDownQuantity.Increment = 1 / 60m;
                    }
                    else if (txt_article.Text == "fer8")
                    {
                        upDownQuantity.Increment = 1 / 21m;
                    }
                    else if (txt_article.Text == "fer10")
                    {
                        upDownQuantity.Increment = 1 / 13m;
                    }
                    else if (txt_article.Text == "fer12")
                    {
                        upDownQuantity.Increment = 1 / 9m;
                    }
                    else if (txt_article.Text == "fer14")
                    {
                        upDownQuantity.Increment = 1 / 6m;
                    }
                    else if (txt_article.Text == "fer16")
                    {
                        upDownQuantity.Increment = 1 / 5m;
                    }
                }
                else if (article.Type == "brique")
                {
                    upDownQuantity.Increment = 1;
                    upDownQuantity.DecimalPlaces = 0;

                }
                else if (article.Type == "ciment")
                {
                    upDownQuantity.Increment = 0.5m;
                    upDownQuantity.DecimalPlaces = 1;
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }




        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_article.Text != "" || quanitity != 0)
                {
                    var stockquantity = Convert.ToDouble(quanitity) + Convert.ToDouble(lbl_quantity.Text);
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
                                    if (rb_quintale.Checked)
                                    {
                                        row.Cells["quantity"].Value = Convert.ToDouble(upDownQuantity.Value) + Convert.ToDouble(row.Cells["quantity"].Value);
                                    }
                                    else if (rb_barre.Checked)
                                    {
                                        row.Cells["quantity"].Value = Math.Round((Convert.ToDouble(updown_barQuantity.Value) / Convert.ToDouble(stock.BarreInQuintale)) + Convert.ToDouble(row.Cells["quantity"].Value), 2);
                                    }
                                }
                                else
                                {
                                    row.Cells["quantity"].Value = Convert.ToDouble(quanitity) + Convert.ToDouble(row.Cells["quantity"].Value);
                                }

                                row.Cells["total"].Value = Convert.ToDouble(txt_totalPrice.Text) + Convert.ToDouble(row.Cells["total"].Value);
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            dataGridView1.Rows.Add(txt_article.Text, quanitity, unity, txt_price.Text, txt_discount.Text, txt_price.Text, txt_totalPrice.Text);
                            getTotal();
                            txt_clientName.Enabled = false;
                            txt_discount.Text = "0";
                        }
                    }
                    else if (state == "edit")
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["articleName"].Value?.ToString() == txt_article.Text)
                            {
                                row.Cells["quantity"].Value = Convert.ToDouble(quanitity);
                                row.Cells["total"].Value = Convert.ToDouble(txt_totalPrice.Text);
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
                updown_barQuantity.Value = 0;
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
                var listData = db.TB_STOCK.Select(x => x.ArticleName).ToList();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(listData.ToArray());

                txt_article.AutoCompleteCustomSource = collection;
                txt_article.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_article.AutoCompleteMode = AutoCompleteMode.Suggest;
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
            catch {
                txt_price.Text = "0";
                txt_article.Text = "";


            }
        }
        // client name autocomplete
        public void clientAutoco()
        {

            try
            {
                db = new DBGPEntities4();
                client = new TB_CLIENT();
                var listData = db.TB_CLIENT.Select(x => x.ClientName).ToList();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(listData.ToArray());
                txt_clientName.AutoCompleteCustomSource = collection;
                if (collection.Contains(txt_clientName.Text))

                {
                    getCleintDebt();
                    rb_cash.Checked = true;
                    rb_cash.Enabled = true;
                    rb_delay.Enabled = true;
                }
                else

                {
                    lbl_clientDebt.Text = "0.0";
                    rb_cash.Checked = true;
                    rb_cash.Enabled = false;
                    rb_delay.Enabled = false;


                }

            }
            catch {
                txt_clientName.Text = "client";
            }
        }

        private void txt_article_TextChanged(object sender, EventArgs e)
        {
            articleAutoco();



        }

        private void txt_clientName_TextChanged(object sender, EventArgs e)
        {
            clientAutoco();
        }

        // show or hide the secondary quantity textbox when clicked
        private void radioClick()
        {
            try
            {
                db = new DBGPEntities4();
                stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();

                if (stock != null)
                {
                    txt_price.Text = stock.Price.ToString();
                    if (rb_cash.Checked == true)
                    {
                        rb_delay.Checked = false;
                        txt_price.Text = stock.Price.ToString();
                    }
                    else if (rb_delay.Checked == true)
                    {
                        rb_cash.Checked = false;
                        txt_price.Text = stock.Price2.ToString();
                    }
                }
                else { txt_price.Text = "0"; }
                txt_totalPrice.Text = (Convert.ToDouble(txt_price.Text) * Convert.ToDouble(quanitity)).ToString();
            }
            catch { txt_price.Text = "0"; }
        }

        private void rb_cash_CheckedChanged(object sender, EventArgs e)
        {
            radioClick();
        }
        private void rb_delay_CheckedChanged(object sender, EventArgs e)
        {
            radioClick();
        }

        private void cb_delivery_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_delivery.Checked == true)
            {
                txt_deliverPrice.Text = "700";
            }
            else { txt_deliverPrice.Text = "0"; }
        }
        private void cb_loading_CheckedChanged(object sender, EventArgs e)
        {/*
            try
            {
                if (cb_loading.Checked == true)
                {
                    db = new DBGPEntities4();
                    stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();
                    var loadingPrice = stock.loadingPrice;

                    txt_loadPrice.Text = (Convert.ToDouble(quanitity) * Convert.ToDouble(loadingPrice)).ToString();
                }
                else {
                    cb_loading.Checked = false;
                    txt_loadPrice.Text = "0"; }
            }
            catch { MessageBox.Show("املئ الحقول السابقة اولا"); }
            */
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_disPrice.Text = (Convert.ToDouble(txt_price.Text) - (Convert.ToDouble(txt_price.Text) * Convert.ToDouble(txt_discount.Text) / 100)).ToString();
            }
            catch { txt_disPrice.Text = txt_price.Text; }
            getTotalPrice();
        }

        // calculate the total price price * quantity
        private void getTotalPrice()
        {
            try
            {
                if (txt_discount.Text != "0")
                {
                    txt_totalPrice.Text = (Convert.ToDouble(txt_disPrice.Text) * Convert.ToDouble(quanitity) + Convert.ToDouble(txt_loadPrice.Text) * Convert.ToDouble(quanitity) + Convert.ToDouble(txt_deliverPrice.Text)).ToString();
                }
                else
                {
                    txt_totalPrice.Text = (Convert.ToDouble(txt_price.Text) * Convert.ToDouble(quanitity) + Convert.ToDouble(txt_deliverPrice.Text) + Convert.ToDouble(txt_loadPrice.Text) * Convert.ToDouble(quanitity)).ToString();
                }
            }
            catch { txt_totalPrice.Text = "0"; }
        }

        // calculate the total of all item : the sum of all the total prices
        private void getTotal()
        {
            totalprice = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                totalprice += Convert.ToDouble(row.Cells["total"].Value);
            }
            txt_total.Text = totalprice.ToString();
            txt_rest.Text = txt_total.Text;
        }

        private void txt_paidAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_rest.Text = (Convert.ToDouble(txt_total.Text) - Convert.ToDouble(txt_paidAmount.Text)).ToString();
            }
            catch { txt_rest.Text = txt_total.Text; }

        }

        // get and set the article  information (quanityt )
        private void getArticleInfos()
        {
            try
            {
                stock = new TB_STOCK();
                db = new DBGPEntities4();
                stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();
                //var type = stock.Type.ToString();
                //MessageBox.Show(""+stock.Quantity);

                if (dataGridView1.Rows.Count == 0)
                {

                    lbl_quantity.Text = stock.Quantity.ToString();
                    lbl_barreQuantity.Text = (Convert.ToDouble(stock.Quantity) * Convert.ToDouble(stock.BarreInQuintale)).ToString();

                }
                else
                {

                    if (stock.Type == "fer")
                    {


                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["articleName"].Value.ToString() == txt_article.Text)
                            {
                                // Calculate and set the quantity and barre quantity only once
                                lbl_quantity.Text = (Convert.ToDouble(stock.Quantity) - Convert.ToDouble(row.Cells["quantity"].Value)).ToString();
                                lbl_barreQuantity.Text = ((Convert.ToDouble(stock.Quantity) - Convert.ToDouble(row.Cells["quantity"].Value)) * Convert.ToDouble(stock.BarreInQuintale)).ToString();
                                //break;  // Exit the loop after finding the match
                            }
                            else
                            {
                                // Calculate and set the quantity and barre quantity only once
                                lbl_quantity.Text = (Convert.ToDouble(stock.Quantity)).ToString();
                                lbl_barreQuantity.Text = (Convert.ToDouble(stock.Quantity) * Convert.ToDouble(stock.BarreInQuintale)).ToString();
                                //break;  // Exit the loop after finding the match
                            }
                        }
                    }
                    else // Handling for other types
                    {

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["articleName"].Value.ToString() == txt_article.Text)
                            {
                                MessageBox.Show(stock.Quantity.ToString());
                                // Calculate and set the quantity only once
                                lbl_quantity.Text = (Convert.ToDouble(stock.Quantity) - Convert.ToDouble(row.Cells["quantity"].Value)).ToString();
                                lbl_barreQuantity.Text = "0";
                                //lbl_barreQuantity.Text = ((Convert.ToDouble(stock.Quantity) - Convert.ToDouble(row.Cells["quantity"].Value)) * Convert.ToDouble(stock.BarreInQuintale)).ToString();
                                //break;  // Exit the loop after finding the match
                            }
                            else
                            {
                                lbl_quantity.Text = (Convert.ToDouble(stock.Quantity)).ToString();
                                lbl_barreQuantity.Text = "0";
                                //lbl_barreQuantity.Text = (Convert.ToDouble(stock.Quantity) * Convert.ToDouble(stock.BarreInQuintale)).ToString();
                            }
                        }
                    }

                }

                if (rb_quintale.Checked == true)
                {
                    //   lbl_quantity.Text = stock.Quantity.ToString();
                    lbl_unity.Text = stock.Unity.ToString();
                    txt_price.Text = stock.Price.ToString();
                }
                else if (rb_barre.Checked == true)
                {
                    //  lbl_barreQuantity.Text = stock.QuantityBarre.ToString();
                    lbl_unity2.Text = stock.Unity2.ToString();
                    txt_price.Text = stock.Price2.ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                lbl_quantity.Text = "0";
                lbl_unity.Text = "##";
            }
        }
        private void getCleintDebt()
        {
            db = new DBGPEntities4();
            client = new TB_CLIENT();
            client = db.TB_CLIENT.Where(x => x.ClientName == txt_clientName.Text).FirstOrDefault();
            lbl_clientDebt.Text = client.Debt.ToString();
        }

        //updqating total price
        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private void txt_loadPrice_TextChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }

        private void txt_deliverPrice_TextChanged(object sender, EventArgs e)
        {
            getTotalPrice();
        }
        private void Setquantity(double quantity)
        {

            try
            {
                if (upDownQuantity.Enabled == true)
                {


                    if (quantity > Convert.ToDouble(lbl_quantity.Text) || quantity < 0)
                    {

                        MessageBox.Show("لا توجد هذه الكمية في المخزن,يرجى اعادة تحديد الكمية او وضع طلب مسبق لهذه المادة!");
                        // quanitity = quanitity.Remove(lbl_quantity.Text.Length - 1);
                    }
                    else
                    {

                        getTotalPrice();
                    }

                }
                else if (updown_barQuantity.Enabled == true)
                {
                    if (Convert.ToDouble(updown_barQuantity.Value) > Convert.ToDouble(lbl_barreQuantity.Text))
                    {
                        MessageBox.Show("لا توجد هذه الكمية في المخزن,يرجى اعادة تحديد الكمية او وضع طلب مسبق لهذه المادة!");
                        updown_barQuantity.Value = Convert.ToDecimal(lbl_barreQuantity.Text);

                        // quanitity = quanitity.Remove(lbl_quantity.Text.Length - 1);
                    }

                }


                else if (quantity > Convert.ToDouble(lbl_quantity.Text) || quantity < 0)
                {

                    MessageBox.Show("لا توجد هذه الكمية في المخزن,يرجى اعادة تحديد الكمية او وضع طلب مسبق لهذه المادة!");
                    // quanitity = quanitity.Remove(lbl_quantity.Text.Length - 1);
                }
                else
                {

                    getTotalPrice();
                }

                if (cb_loading.Checked == true)
                {
                    db = new DBGPEntities4();
                    stock = db.TB_STOCK.Where(x => x.ArticleName == txt_article.Text).FirstOrDefault();

                    if (tbArticle != null)
                    {
                        txt_loadPrice.Text = (Convert.ToDouble(quantity) * Convert.ToDouble(stock.loadingPrice)).ToString();
                    }
                }
                else
                {
                    cb_loading.Checked = false;
                    txt_loadPrice.Text = "0";
                }
            }
            catch
            {
                quanitity = 0;
            }


        }

        private void txt_disPrice_TextChanged(object sender, EventArgs e)
        {
            getTotalPrice();
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
            edit();
        }

        private void edit()
        {
            txt_article.Text = dataGridView1.CurrentRow.Cells["articleName"].Value.ToString();
            quanitity = Convert.ToDouble(dataGridView1.CurrentRow.Cells["quantity"].Value);

        }

        // insert the sale recod to the database and make the bill 
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
                            txt_clientName.Enabled = true;
                            client = new TB_CLIENT();
                            var clientName = txt_clientName.Text;

                            if (clientName == "client")
                            {
                                IDClient = 0;
                            }
                            else
                            {
                                client = context.TB_CLIENT.FirstOrDefault(x => x.ClientName == clientName);
                                if (client != null)
                                {
                                    IDClient = client.ID;
                                }
                                else
                                {
                                    MessageBox.Show("Client not found.");
                                    return 0;
                                }
                            }

                            state = txt_rest.Text == "0" ? "غير مدان" : "مدان";

                            if (dataGridView1.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow row in dataGridView1.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    var name = row.Cells["articleName"].Value.ToString();
                                    var stock = context.TB_STOCK.FirstOrDefault(x => x.ArticleName == name);

                                    if (stock != null)
                                    {
                                        stock.Quantity -= Convert.ToDouble(row.Cells["quantity"].Value);
                                        context.Entry(stock).State = EntityState.Modified; // Mark as modified
                                    }
                                    else
                                    {
                                        MessageBox.Show($"لا يوجد هذا العنصر في المخزن: {name}");
                                        return 0;
                                    }
                                }

                                context.SaveChanges(); // Save stock updates
                            }

                            // Step 1: Insert a new sell record into TB_SELL
                            var sell = new TB_SELL
                            {
                                Date = DateTime.Now,
                                ClientName = clientName,
                                IDClient = IDClient,
                                PaymentState = state,
                                Payment = Convert.ToDouble(txt_paidAmount.Text),
                                Debt = Convert.ToDouble(txt_rest.Text)
                            };

                            context.TB_SELL.Add(sell);
                            context.SaveChanges();

                            sellId = sell.ID;

                            if (clientName != "client")
                            {
                                client = context.TB_CLIENT.FirstOrDefault(x => x.ID == IDClient);
                                if (client != null)
                                {
                                    client.Debt = Convert.ToDouble(txt_rest.Text);
                                    context.Entry(client).State = EntityState.Modified;
                                    context.SaveChanges();
                                }
                            }

                            // Step 2: Insert each item from the DataGridView into TB_BILL with the foreign key IDSell
                            var billItems = new List<TB_BILL>();

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var billItem = new TB_BILL
                                {
                                    IDSell = sellId,
                                    Article = row.Cells["articleName"].Value.ToString(),
                                    ClientName = clientName,
                                    Discount = Convert.ToDouble(row.Cells["discount"].Value),
                                    PriceAfterDiscount = Convert.ToDouble(row.Cells["afterDiscount"].Value),
                                    TotalPrice = Convert.ToDouble(row.Cells["total"].Value),
                                    Quantity = Convert.ToDouble(row.Cells["quantity"].Value),
                                    IDClient = IDClient,
                                    Unity = row.Cells["unity"].Value.ToString(),
                                    Price = Convert.ToDouble(row.Cells["price"].Value),
                                    Date = DateTime.Now
                                };

                                billItems.Add(billItem);
                            }

                            context.TB_BILL.AddRange(billItems);
                            context.SaveChanges();

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("تمت عملية البيع بنجاح.");
                        }
                        catch (DbEntityValidationException ex)
                        {
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
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}");
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return sellId;
        }

        // update sell operation
        // and it not working yet
        private int UpdateSale(int saleId)
        {
            try
            {
                using (var context = new DBGPEntities4())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            // Step 1: Retrieve the existing sale record
                            var sale = context.TB_SELL.SingleOrDefault(s => s.ID == saleId);
                            if (sale == null)
                            {
                                MessageBox.Show("Sale record not found.");
                                return 0;
                            }

                            // Step 2: Update sale record properties
                            sale.ClientName = txt_clientName.Text;
                            sale.PaymentState = txt_rest.Text == "0" ? "غير مدان" : "مدان";
                            sale.Payment = Convert.ToDouble(txt_paidAmount.Text);
                            sale.Debt = Convert.ToDouble(txt_rest.Text);
                            sale.Date = DateTime.Now;

                            // Step 3: Retrieve existing bill items and stock records
                            var existingBillItems = context.TB_BILL.Where(b => b.IDSell == saleId).ToList();
                            var stockRecords = context.TB_STOCK.ToList();

                            // Step 4: Adjust stock quantities for removed or modified items
                            foreach (var billItem in existingBillItems)
                            {
                                var stock = stockRecords.SingleOrDefault(s => s.ArticleName == billItem.Article);
                                if (stock != null)
                                {
                                    stock.Quantity += billItem.Quantity; // Revert the quantity
                                    context.Entry(stock).State = EntityState.Modified;
                                }
                            }

                            context.TB_BILL.RemoveRange(existingBillItems); // Remove existing bill items
                            context.SaveChanges(); // Save stock adjustments and bill item removals

                            // Step 5: Add or update bill items based on DataGridView data
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.IsNewRow) continue;

                                var articleName = row.Cells["articleName"].Value.ToString();
                                var quantity = Convert.ToDouble(row.Cells["quantity"].Value);

                                var newBillItem = new TB_BILL
                                {
                                    IDSell = saleId,
                                    Article = articleName,
                                    Quantity = quantity,
                                    Discount = Convert.ToDouble(row.Cells["discount"].Value),
                                    PriceAfterDiscount = Convert.ToDouble(row.Cells["afterDiscount"].Value),
                                    TotalPrice = Convert.ToDouble(row.Cells["total"].Value),
                                    Unity = row.Cells["unity"].Value.ToString(),
                                    Price = Convert.ToDouble(row.Cells["price"].Value),
                                    Date = DateTime.Now
                                };

                                // Adjust stock quantities for new items
                                var stock = stockRecords.SingleOrDefault(s => s.ArticleName == articleName);
                                if (stock != null)
                                {
                                    if (stock.Quantity < quantity)
                                    {
                                        throw new Exception($"Insufficient stock for article {newBillItem.Article}.");
                                    }
                                    stock.Quantity -= quantity;
                                    context.Entry(stock).State = EntityState.Modified;
                                }
                                else
                                {
                                    throw new Exception($"Article {newBillItem.Article} not found in stock.");
                                }

                                context.TB_BILL.Add(newBillItem);
                            }

                            context.SaveChanges(); // Save the updated bill items and stock changes

                            // Step 6: Update sale record in the database
                            context.Entry(sale).State = EntityState.Modified;
                            context.SaveChanges(); // Save the updated sale record

                            transaction.Commit();
                            MessageBox.Show("Sale record updated successfully.");
                            return saleId;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}");
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return 0;
            }
        }

        // a second update method 
        public int UpdateSellRecord(int sellId)
        {
            try
            {
                using (var context = new DBGPEntities4())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            txt_clientName.Enabled = true;

                            // Retrieve the existing sell record
                            var sell = context.TB_SELL.FirstOrDefault(x => x.ID == sellId);
                            if (sell == null)
                            {
                                MessageBox.Show("Sell record not found.");
                                return -1;
                            }

                            // Update the client information
                            client = context.TB_CLIENT.FirstOrDefault(x => x.ClientName == txt_clientName.Text);
                            IDClient = client != null ? client.ID : 0;

                            // Update payment state
                            state = txt_rest.Text == "0" ? "غير مدان" : "مدان";

                            // Update the sell record fields
                            sell.ClientName = txt_clientName.Text;
                            sell.IDClient = IDClient;
                            sell.PaymentState = state;
                            sell.Payment = Convert.ToDouble(txt_paidAmount.Text);
                            sell.Debt = Convert.ToDouble(txt_rest.Text);
                            sell.Date = DateTime.Now; // Update the date

                            context.Entry(sell).State = EntityState.Modified; // Mark the sell record as modified

                            // Update client debt if applicable
                            if (client != null)
                            {
                                client.Debt = sell.Debt;
                                context.Entry(client).State = EntityState.Modified; // Mark as modified
                            }

                            // Update existing bill items and adjust stock quantities accordingly
                            var previousBillItems = context.TB_BILL.Where(x => x.IDSell == sellId).ToList();
                            foreach (var row in dataGridView1.Rows.Cast<DataGridViewRow>())
                            {
                                if (row.IsNewRow) continue;

                                var articleName = row.Cells["articleName"].Value.ToString();
                                var quantity = Convert.ToDouble(row.Cells["quantity"].Value);
                                var previousBillItem = previousBillItems.FirstOrDefault(x => x.Article == articleName);

                                var stock = context.TB_STOCK.FirstOrDefault(x => x.ArticleName == articleName);
                                if (stock != null)
                                {
                                    if (previousBillItem != null)
                                    {
                                        // Adjust stock for the difference in quantities
                                        stock.Quantity += previousBillItem.Quantity - quantity;

                                        // Update the existing bill item
                                        previousBillItem.Quantity = quantity;
                                        previousBillItem.Discount = Convert.ToDouble(row.Cells["discount"].Value);
                                        previousBillItem.PriceAfterDiscount = Convert.ToDouble(row.Cells["afterDiscount"].Value);
                                        previousBillItem.TotalPrice = Convert.ToDouble(row.Cells["total"].Value);
                                        previousBillItem.Unity = row.Cells["unity"].Value.ToString();
                                        previousBillItem.Price = Convert.ToDouble(row.Cells["price"].Value);
                                        previousBillItem.Date = DateTime.Now;

                                        context.Entry(previousBillItem).State = EntityState.Modified; // Mark as modified
                                    }
                                    else
                                    {
                                        // Add a new bill item if it doesn't exist
                                        var newBillItem = new TB_BILL
                                        {
                                            IDSell = sellId,
                                            Article = articleName,
                                            ClientName = txt_clientName.Text,
                                            Discount = Convert.ToDouble(row.Cells["discount"].Value),
                                            PriceAfterDiscount = Convert.ToDouble(row.Cells["afterDiscount"].Value),
                                            TotalPrice = Convert.ToDouble(row.Cells["total"].Value),
                                            Quantity = quantity,
                                            IDClient = IDClient,
                                            Unity = row.Cells["unity"].Value.ToString(),
                                            Price = Convert.ToDouble(row.Cells["price"].Value),
                                            Date = DateTime.Now
                                        };

                                        stock.Quantity -= quantity; // Adjust stock
                                        context.TB_BILL.Add(newBillItem); // Add the new bill item
                                    }

                                    context.Entry(stock).State = EntityState.Modified; // Mark stock as modified
                                }
                            }

                            context.SaveChanges(); // Save all changes

                            // Commit the transaction
                            transaction.Commit();

                            MessageBox.Show("Sell operation updated successfully.");
                        }
                        catch (DbEntityValidationException ex)
                        {
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
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}");
                        }
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
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
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            return sellId;
        }








        private void link_addClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            addClient = new addClient();
            addClient.personState = "client";
            addClient.Show();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            txt_clientName.Enabled = true;
            sell sell = new sell();

        }

        private void txt_clientName_Leave(object sender, EventArgs e)
        {

        }

        private void txt_clientName_Enter(object sender, EventArgs e)
        {

        }

        private void txt_clientName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {


        }

        private void txt_article_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_article_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {



                try
                {
                    updownManag();
                }
                catch { }

            }
        }

        private void rb_quintale_CheckedChanged(object sender, EventArgs e)
        {
            setQuantity();
        }

        private void rb_barre_CheckedChanged(object sender, EventArgs e)
        {
            setQuantity();
        }

        private void upDownQuantity_ValueChanged(object sender, EventArgs e)
        {
            setQuantity();
        }

        private void updown_barQuantity_ValueChanged(object sender, EventArgs e)
        {
            setQuantity();
            getTotalPrice();

        }

        private void txt_article_Leave(object sender, EventArgs e)
        {
            //updownManag();
        }

        private void lbl_unity_TextChanged(object sender, EventArgs e)
        {
            updownManag();
        }

        private void txt_clientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {



                try
                {
                    db = new DBGPEntities4();
                    client = new TB_CLIENT();
                    var listData = db.TB_CLIENT.Select(x => x.ClientName).ToList();
                    AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                    collection.AddRange(listData.ToArray());
                    txt_clientName.AutoCompleteCustomSource = collection;
                    if (collection.Contains(txt_clientName.Text))
                    {
                        getCleintDebt();
                        rb_cash.Checked = true;
                        rb_cash.Enabled = true;
                    }
                    else if (!collection.Contains(txt_clientName.Text) && txt_clientName.Text != "client")
                    {
                        MessageBox.Show("لا يوجد اي زبون يحمل هذا الاسم , اضف هذا الزبون او لا");
                        txt_clientName.Text = "client";
                    }

                    else if (txt_clientName.Text == "client")
                    {
                        lbl_clientDebt.Text = "0.0";

                        txt_clientName.Text = "client";
                        rb_cash.Checked = true;
                        rb_cash.Enabled = false;
                        txt_paidAmount.Text = txt_total.Text;
                        txt_rest.Enabled = false;
                        txt_paidAmount.Enabled = false;
                        txt_total.Enabled = false;
                    }
                }
                catch { }

            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                InsertSellRecord();
            }
            else if (state == "edit")
            {

                UpdateSale(sellId);
            };

        }




    }

}