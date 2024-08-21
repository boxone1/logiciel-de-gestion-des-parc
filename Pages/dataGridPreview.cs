using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestionDesParc.Pages
{
    public partial class dataGridPreview : Form
    {
        clientPage cp;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;
        public string state;
        string title;
        public dataGridPreview()
        {
            InitializeComponent();



        }
        //الصفحات مايخرجوش ملاح في الطباة لهذا نبعتهم هنا و نظمهم و نطبعهم


        public void LoadData(string page)
        {

            if (page == "sellsLog")
            {
                try
                {

                    title = "قائمة المبيعات\n" +
                "طبعت بتاريخ :" + DateTime.Now + "\n" +
                "\n";
                    con = new SqlConnection();
                    dt = new DataTable();
                    con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                    var sql = "SELECT ID,ClientName ,Payment ,Debt ,Date  From TB_SELL";
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["ID"].Width = 40;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (page == "clientPage")
            {
                try
                {
                    // title = "قائمة الزبائن";
                    title = "قائمة الزبائن\n" +
                "طبعت بتاريخ :" + DateTime.Now + "\n" +
                "\n";
                    con = new SqlConnection();
                    dt = new DataTable();
                    con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                    var sql = "SELECT ID,ClientName AS الاسم,Phone AS الهاتف,Adress AS العنوان,Debt AS الديون,Date AS التاريخ  From TB_CLIENT";
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //dataGridView1.Width += 150;
                    dataGridView1.Columns["ID"].Width = 40;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (page == "supplierPage")
            {
                try
                {
                    // title = "قائمة الزبائن";
                    title = "قائمة الموردين\n" +
                "طبعت بتاريخ :" + DateTime.Now + "\n" +
                "\n";
                    con = new SqlConnection();
                    dt = new DataTable();
                    con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                    var sql = "SELECT ID,SupplierName AS الاسم,Phone AS الهاتف,Adress AS العنوان,Debt AS الديون,Date AS التاريخ  From TB_SUPPLIER";
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //dataGridView1.Width += 150;
                    dataGridView1.Columns["ID"].Width = 40;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (page == "purchasePage")
            {
                try
                {
                    // title = "قائمة الزبائن";
                    title = "قائمة المشتريات\n" +
                "طبعت بتاريخ :" + DateTime.Now + "\n" +
                "\n";
                    con = new SqlConnection();
                    dt = new DataTable();
                    con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                    var sql = "SELECT ID,Name ,Quantity,Purchaseprice,Transport,Unload,Date  From TB_ARTICLE";
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //dataGridView1.Width += 150;

                    dataGridView1.Columns["ID"].HeaderText = "التسلسل";
                    dataGridView1.Columns["Name"].HeaderText = "المادة";
                    dataGridView1.Columns["Quantity"].HeaderText = "الكمية";
                    dataGridView1.Columns["PurchasePrice"].HeaderText = "ثمن الشراء";
                    dataGridView1.Columns["Transport"].HeaderText = "ثمن النقل";
                    dataGridView1.Columns["Unload"].HeaderText = "ثمن التفريغ";
                    dataGridView1.Columns["Date"].HeaderText = "تاريخ الشراء";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (page == "stockPage")
            {
                try
                {
                    // title = "قائمة الزبائن";
                    title = " محتويات المخزن\n" +
                "طبعت بتاريخ :" + DateTime.Now + "\n" +
                "\n";
                    con = new SqlConnection();
                    dt = new DataTable();
                    con.ConnectionString = (@"Data Source=DESKTOP-VDJQ28O\SQLEXPRESS;Initial Catalog=DBGP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");
                    var sql = "SELECT ID,ArticleName ,Quantity,Type ,Unity,Price,Unity2,Price2,loadingPrice  From TB_STOCK";
                    da = new SqlDataAdapter(sql, con);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["ID"].Width = 50;
                    dataGridView1.Columns["loadingPrice"].Width = 50;
                    dataGridView1.Columns["Unity"].Width = 50;
                    dataGridView1.Columns["Unity2"].Width = 50;
                    dataGridView1.Columns["Quantity"].Width = 60;
                    dataGridView1.Columns["Type"].Width = 60;
                    dataGridView1.Columns["Price"].Width = 80;
                    dataGridView1.Columns["Price2"].Width = 80;
                    dataGridView1.Columns["ArticleName"].Width += 20;






                    //dataGridView1.Width += 150;

                    dataGridView1.Columns["ID"].HeaderText = "التسلسل";
                    dataGridView1.Columns["ArticleName"].HeaderText = "المادة";
                    dataGridView1.Columns["Quantity"].HeaderText = "الكمية";
                    dataGridView1.Columns["Type"].HeaderText = "النوع";
                    dataGridView1.Columns["Unity"].HeaderText = "الوحدة الرئيسية";
                    dataGridView1.Columns["Price"].HeaderText = "سعر البيع";
                    dataGridView1.Columns["Unity2"].HeaderText = " الوحدة الثانوية";
                    dataGridView1.Columns["Price2"].HeaderText = "سعر البيع";
                    dataGridView1.Columns["loadingPrice"].HeaderText = "سعر الشحن ";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("3");
            }

        }
    
   
        private void setSubtitles()
        {
            String subtitles = "first  one" +
                "second one" +
                "third one";
        }

        
        private void btn_print_Click(object sender, EventArgs e)
        {
            printFunction();
        }

        // print function
        public void printFunction()
        {
            DGVPrinter printer = new DGVPrinter();

            // Set the title and its alignment
            printer.Title = "اسم الشركة" + "\n" +
                "\n"; ;
            printer.TitleAlignment = StringAlignment.Center;

            // Set the subtitle and its alignment
            printer.SubTitle = title;
            printer.SubTitleColor = Color.Black;
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            
            // Enable page numbers and other settings
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;

            // Set margins to zero for no margins
            printer.PrintMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            printer.PrintMargins.Top = 0;
            // Ensure columns adjust to fit the page
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            printer.FooterSpacing = 15;

            // Set the PrintDocument object
            printer.printDocument = printDocument1;

            // Attach the PrintPage event handler
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintDocument1_PrintPage);

            // Print the DataGridView
            printer.PrintPreviewDataGridView(dataGridView1);
        }

        // Event handler to adjust column widths during the print process
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            dataGridView1.Dock = DockStyle.None;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
               // column.Width = 200; // Adjust the value as needed to widen the columns
            }
        }


    }
}
