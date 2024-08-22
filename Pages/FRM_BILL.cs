using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace gestionDesParc.Pages
{
    public partial class FRM_BILL : Form
    {
        public FRM_BILL()
        {
            InitializeComponent();
           // StretchDataGridViewToFitContent(dataGridView1);

        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            BillPrinter billPrinter = new BillPrinter(
      printDocument1,
      dataGridView1,
      lbl_billCompanyName.Text,
      lbl_phone1.Text,
      lbl_phone2.Text,
      lbl_fax.Text,
      lbl_email.Text,
      lbl_billId.Text,
      lbl_clientName.Text,
      lbl_billDate.Text,
      lbl_printDate.Text,
      lbl_totalPrice.Text,
      lbl_rest.Text
  );
            billPrinter.PrintBill();
        }
      

        private void StretchDataGridViewToFitContent(DataGridView dataGridView)
        {
            int totalRowHeight = 0;

            
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalRowHeight += row.Height;
            }

    
            totalRowHeight += dataGridView.ColumnHeadersHeight;

            int maxHeight = Screen.PrimaryScreen.WorkingArea.Height;

            if (totalRowHeight < maxHeight)
            {
                dataGridView.Height = totalRowHeight;
            }
            else
            {

                dataGridView.Height = maxHeight;
            }
        }




        public class BillPrinter
    {
        private PrintDocument printDocument1;
        private DataGridView dataGridView1;
        private string companyName;
        private string phone1;
        private string phone2;
        private string fax;
        private string email;
        private string billId;
        private string clientName;
        private string dateAdded;
        private string printDate;
        private string totalPrice;
        private string restOfPayments;

        private int margin = 20; 


        public BillPrinter(PrintDocument printDoc, DataGridView dgv, string compName, string ph1, string ph2, string faxNum, string mail, string billIdNum, string client, string dateAdd, string printDt, string total, string rest)
        {
            printDocument1 = printDoc;
            dataGridView1 = dgv;
            companyName = compName;
            phone1 = ph1;
            phone2 = ph2;
            fax = faxNum;
            email = mail;
            billId = billIdNum;
            clientName = client;
            dateAdded = dateAdd;
            printDate = printDt;
            totalPrice = total;
            restOfPayments = rest;

            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument1_PrintPage);
        }

        public void PrintBill()
        {
            
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
            {
                Document = printDocument1
            };
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int startX = margin;
            int startY = margin;
            int offset = 40;
            int pageWidth = e.PageBounds.Width - (2 * margin)+150;
            int midX = startX + (pageWidth / 2);

            
            g.DrawString(companyName, new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new RectangleF(startX, startY, pageWidth, 30), new StringFormat { Alignment = StringAlignment.Center });
            offset += 30;
            g.DrawString($"هاتف1: {phone1}", new Font("Arial", 12), Brushes.Black, startX, startY + offset);
            g.DrawString($"هاتف 2: {phone2}", new Font("Arial", 12), Brushes.Black, midX, startY + offset);
            offset += 20;
            g.DrawString($"فاكس: {fax}", new Font("Arial", 12), Brushes.Black, startX, startY + offset);
            g.DrawString($"بريد: {email}", new Font("Arial", 12), Brushes.Black, midX, startY + offset);
            offset += 40;

           
            offset += 30;

           
            g.DrawString($"رقم الفاتورة: {billId}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, startX, startY + offset);
            g.DrawString($"اسم الزبون: {clientName}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, midX, startY + offset);
            offset += 20;
            g.DrawString($"تاريخ الفاتورة: {dateAdded}", new Font("Arial", 12), Brushes.Black, startX, startY + offset);
            g.DrawString($"تاريخ الطباعة: {printDate}", new Font("Arial", 12), Brushes.Black, midX, startY + offset);
            offset += 40;

            
            offset += 20;

            Pen thickPen = new Pen(Color.Black, 2);
            Pen thinPen = new Pen(Color.Black, 1);
            int columnOffset = startX;

            g.DrawLine(thickPen, startX, startY + offset - 10, startX + pageWidth, startY + offset - 10);
                
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                g.DrawString(column.HeaderText, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, columnOffset, startY + offset);
                columnOffset += column.Width + 10;
            }
            offset += 20;
            columnOffset = startX; 

           
            g.DrawLine(thickPen, startX, startY + offset, startX + pageWidth, startY + offset);
            offset += 10;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        g.DrawString(cell.Value?.ToString(), new Font("Arial", 10), Brushes.Black, columnOffset, startY + offset);
                        columnOffset += dataGridView1.Columns[cell.ColumnIndex].Width + 10;
                    }
                    g.DrawLine(thinPen, startX, startY + offset + 20, startX + pageWidth, startY + offset + 20); 
                    offset += 20;
                    columnOffset = startX;
                }
            }

            offset += 30;
            g.DrawString($"المبلغ الاجمالي: {totalPrice}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(startX, startY + offset, pageWidth, 20), new StringFormat { Alignment = StringAlignment.Far });
            offset += 20;
            g.DrawString($"الباقي: {restOfPayments}", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new RectangleF(startX, startY + offset, pageWidth, 20), new StringFormat { Alignment = StringAlignment.Far });
        }
    }



}
}

