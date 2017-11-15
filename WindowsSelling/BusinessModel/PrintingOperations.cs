using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling.BusinessModel
{
    class PrintingOperations
    {
        public static DataGridView datagridview1;
        public static int HeaderFlag = 0;
        public static Sale sale = null;
        public static string Location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static BaseFont customfont = null;
        public static Font font8 = new Font();
        public static Font fontBold8 = new Font();
        public static Font font9 = new Font();
        public static Font fontBold9 = new Font();
        public static Font font10 = new Font();
        public static Font font11 = new Font();
        public static Font font12 = new Font();
        public static bool SalePrint(int SaleId)
        {
            try
            {
                HeaderFlag = 1;
                Location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Location = System.IO.Path.GetDirectoryName(Location);
                customfont = BaseFont.CreateFont(Location + "\\ufonts.com_century-gothic.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
                sale = BusinessModel.SaleOperations.GetSaleRecord(SaleId);
                if (sale == null)
                {
                    MessageBox.Show("Bill Not Found !!!!", "Error");
                    return false;
                }

                font8 = new Font(customfont, 8);
                fontBold8 = new Font(customfont, 8, Font.BOLD);
                font9 = new Font(customfont, 9);
                fontBold9 = new Font(customfont, 9, Font.BOLD);
                font10 = new Font(customfont, 10);
                font11 = new Font(customfont, 11);
                font12 = new Font(customfont, 12);

                Location = Location + "\\Sales";
                if (!Directory.Exists(Location))
                    Directory.CreateDirectory(Location);
                string FileName = Location + "\\Sale_" + SaleId + "_" + DateTime.Now.ToString("dd-MMM-yyyy") + ".pdf";
                using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                using (Document doc = new Document(new Rectangle(595f, 421f)))
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    writer.PageEvent = new _events();
                    doc.Open();
                    PdfPTable tbl2 = new PdfPTable(new float[] { 8, 35, 10, 8, 8, 8, 8, 15 });
                    tbl2.WidthPercentage = 100;
                    PdfPCell c1 = new PdfPCell(new Phrase("Sr.No", font8));
                    PdfPCell c2 = new PdfPCell(new Phrase("Name of Item", font8));
                    PdfPCell c3 = new PdfPCell(new Phrase("Qty", font8));
                    PdfPCell c4 = new PdfPCell(new Phrase("Rate", font8));
                    PdfPCell c5 = new PdfPCell(new Phrase("CGST", font8));
                    PdfPCell c6 = new PdfPCell(new Phrase("SGST", font8));
                    PdfPCell c7 = new PdfPCell(new Phrase("IGST", font8));
                    PdfPCell c8 = new PdfPCell(new Phrase("Amount", font8));
                    tbl2.AddCell(c1); tbl2.AddCell(c2); tbl2.AddCell(c3); tbl2.AddCell(c4);
                    tbl2.AddCell(c5); tbl2.AddCell(c6); tbl2.AddCell(c7); tbl2.AddCell(c8);
                    for (int i = 0; i < sale.saledetails.Count; i++)
                    {
                        c1 = new PdfPCell(new Phrase((i + 1).ToString(), font8));
                        c1.HorizontalAlignment = 1;
                        c2 = new PdfPCell(new Phrase(BusinessModel.ProductOperations.GetProductDetails(sale.saledetails[i].ProductId).Name, font8));
                        c3 = new PdfPCell(new Phrase(sale.saledetails[i].Quantity.ToString(), font8));
                        c3.HorizontalAlignment = 2;
                        c4 = new PdfPCell(new Phrase(sale.saledetails[i].Rate.ToString("n"), font8));
                        c4.HorizontalAlignment = 2;
                        c5 = new PdfPCell(new Phrase(sale.saledetails[i].CGST.ToString("n"), font8));
                        c5.HorizontalAlignment = 2;
                        c6 = new PdfPCell(new Phrase(sale.saledetails[i].SGST.ToString("n"), font8));
                        c6.HorizontalAlignment = 2;
                        c7 = new PdfPCell(new Phrase(sale.saledetails[i].IGST.ToString("n"), font8));
                        c7.HorizontalAlignment = 2;
                        c8 = new PdfPCell(new Phrase(sale.saledetails[i].TotalAmount.ToString("n"), font8));
                        c8.HorizontalAlignment = 2;
                        tbl2.AddCell(c1); tbl2.AddCell(c2); tbl2.AddCell(c3); tbl2.AddCell(c4);
                        tbl2.AddCell(c5); tbl2.AddCell(c6); tbl2.AddCell(c7); tbl2.AddCell(c8);
                    }
                    if (sale.saledetails.Count < 10)
                    {
                        int remaincount = 10 - sale.saledetails.Count;
                        for (int i = 1; i < remaincount + 1; i++)
                        {
                            c1 = new PdfPCell(new Phrase((i + sale.saledetails.Count).ToString(), font8));
                            c1.HorizontalAlignment = 1;
                            c2 = new PdfPCell(new Phrase("", font8));
                            c3 = new PdfPCell(new Phrase("", font8));
                            c3.HorizontalAlignment = 2;
                            c4 = new PdfPCell(new Phrase("", font8));
                            c4.HorizontalAlignment = 2;
                            c5 = new PdfPCell(new Phrase("", font8));
                            c5.HorizontalAlignment = 2;
                            c6 = new PdfPCell(new Phrase("", font8));
                            c6.HorizontalAlignment = 2;
                            c7 = new PdfPCell(new Phrase("", font8));
                            c7.HorizontalAlignment = 2;
                            c8 = new PdfPCell(new Phrase("", font8));
                            c8.HorizontalAlignment = 2;
                            tbl2.AddCell(c1); tbl2.AddCell(c2); tbl2.AddCell(c3); tbl2.AddCell(c4);
                            tbl2.AddCell(c5); tbl2.AddCell(c6); tbl2.AddCell(c7); tbl2.AddCell(c8);
                        }
                    }
                    doc.Add(tbl2);
                    PdfPTable tbl3 = new PdfPTable(new float[] { 70, 15, 15 });
                    tbl3.WidthPercentage = 100;
                    string _amountinword = ConvertNumbertoWords(Math.Round(sale.saledetails.Sum(n => n.FinalAmount)));
                    PdfPCell amountinword = new PdfPCell(new Phrase("Amount in word : " + _amountinword, font8));
                    amountinword.Rowspan = 4;
                    PdfPCell empty = new PdfPCell(new Phrase("", font8));
                    PdfPCell _CGST = new PdfPCell(new Phrase("CGST", fontBold8));
                    PdfPCell _SGST = new PdfPCell(new Phrase("SGST", fontBold8));
                    PdfPCell _IGST = new PdfPCell(new Phrase("IGST", fontBold8));
                    PdfPCell _total = new PdfPCell(new Phrase("Total", fontBold8));
                    PdfPCell CGST = new PdfPCell(new Phrase(Math.Round(sale.saledetails.Sum(n => n.CGSTAmount)).ToString("n"), font8));
                    PdfPCell SGST = new PdfPCell(new Phrase(Math.Round(sale.saledetails.Sum(n => n.SGSTAmount)).ToString("n"), font8));
                    PdfPCell IGST = new PdfPCell(new Phrase(Math.Round(sale.saledetails.Sum(n => n.IGSTAmount)).ToString("n"), font8));
                    PdfPCell total = new PdfPCell(new Phrase(Math.Round(sale.saledetails.Sum(n => n.FinalAmount)).ToString("n"), font8));
                    CGST.HorizontalAlignment = 2;
                    SGST.HorizontalAlignment = 2;
                    IGST.HorizontalAlignment = 2;
                    total.HorizontalAlignment = 2;

                    tbl3.AddCell(amountinword);
                    tbl3.AddCell(_CGST);
                    tbl3.AddCell(CGST);
                    tbl3.AddCell(_SGST);
                    tbl3.AddCell(SGST);
                    tbl3.AddCell(_IGST);
                    tbl3.AddCell(IGST);
                    tbl3.AddCell(_total);
                    tbl3.AddCell(total);
                    doc.Add(tbl3);

                    PdfPTable tbl4 = new PdfPTable(1);
                    tbl4.WidthPercentage = 100;
                    PdfPCell signature = new PdfPCell(new Phrase("\n[Gundesha Metal Mart]", fontBold8));
                    signature.Border = Rectangle.NO_BORDER;
                    signature.HorizontalAlignment = 2;
                    tbl4.AddCell(signature);

                    doc.Add(tbl4);



                    doc.Close();
                }
                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                MessageBox.Show("Unable to print...", "Error");
            }
            return false;
        }

        public static bool PrintSummaryReport(DataGridView gridview1)
        {
            try
            {
                datagridview1 = gridview1;
                HeaderFlag = 2;
                string Location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Location = System.IO.Path.GetDirectoryName(Location);
                BaseFont customfont = BaseFont.CreateFont(Location + "\\ufonts.com_century-gothic.ttf", BaseFont.CP1252, BaseFont.EMBEDDED);
                font8 = new Font(customfont, 8);
                fontBold8 = new Font(customfont, 8, Font.BOLD);
                font9 = new Font(customfont, 9);
                fontBold9 = new Font(customfont, 9, Font.BOLD);
                font10 = new Font(customfont, 10);
                font11 = new Font(customfont, 11);
                font12 = new Font(customfont, 12);
                if (!Directory.Exists(Location))
                    Directory.CreateDirectory(Location);
                string FileName = Location + "\\SummaryReport.pdf";
                using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                using (Document doc = new Document(PageSize.A4, 25, 25, 25, 25))
                using (PdfWriter writer = PdfWriter.GetInstance(doc, fs))
                {
                    writer.PageEvent = new _events();
                    doc.Open();
                    PdfPTable tbl2 = new PdfPTable(PrintingOperations.datagridview1.Columns.Count);
                    tbl2.WidthPercentage = 100;
                    foreach (DataGridViewRow row in PrintingOperations.datagridview1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            PdfPCell tblhead = new PdfPCell(new Phrase(cell.Value == null ? " " : cell.Value.ToString(), PrintingOperations.font8));
                            tbl2.AddCell(tblhead);
                        }
                    }
                    doc.Add(tbl2);
                    doc.Close();
                }
                Process.Start(FileName);
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
            return true;
        }

        public static string ConvertNumbertoWords(double number)
        {
            try
            {
                var result = number.ToString().Split('.');
                string value1 = ConvertNumbertoWords(Convert.ToInt64(result[0]));
                string value2 = string.Empty;
                if (result.Count() == 2)
                {
                    value1 = ConvertNumbertoWords(Convert.ToInt64(result[1]));
                    return value1 + " and " + value2 + " only";
                }
                return value1 + " only";
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return "";
            }
        }

        public static string ConvertNumbertoWords(long number)
        {
            try
            {
                if (number == 0) return "ZERO";
                if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
                string words = "";
                if ((number / 1000000) > 0)
                {
                    words += ConvertNumbertoWords(number / 100000) + " LAKES ";
                    number %= 1000000;
                }
                if ((number / 1000) > 0)
                {
                    words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
                    number %= 1000;
                }
                if ((number / 100) > 0)
                {
                    words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
                    number %= 100;
                }
                //if ((number / 10) > 0)  
                //{  
                // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
                // number %= 10;  
                //}  
                if (number > 0)
                {
                    if (words != "") words += "AND ";
                    var unitsMap = new[]
                    {
                "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
            };
                    var tensMap = new[]
                    {
                "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
            };
                    if (number < 20) words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                    }
                }
                return words;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return "";
            }
        }
    }

    class _events : PdfPageEventHelper
    {
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            try
            {
                if (PrintingOperations.HeaderFlag == 1)
                {

                    Paragraph gst = new Paragraph("GST NO: 29AAAPO3846L12A", PrintingOperations.font8);
                    document.Add(gst);
                    Paragraph head1 = new Paragraph("M/s. Gundesha Metal Mart", PrintingOperations.fontBold9);
                    head1.Alignment = 1;
                    Paragraph head2 = new Paragraph("Ashok Nagar Nipani", PrintingOperations.fontBold9);
                    head2.Alignment = 1;
                    Paragraph head3 = new Paragraph("Wholesaler in Copper,Brans,Aluminiumum,Stainless SteelCooker,Mixer and Copper wires", PrintingOperations.font8);
                    head3.Alignment = 1;
                    PdfPTable tble = new PdfPTable(new float[] { 70, 30 });
                    tble.WidthPercentage = 100;

                    PdfPCell cell1 = new PdfPCell(new Phrase("Payment Mode  : " + PrintingOperations.sale.PaymentMode, PrintingOperations.font8));
                    PdfPCell cell2 = new PdfPCell(new Phrase("Date          : " + PrintingOperations.sale.Date.ToString("dd-MMM-yyyy"), PrintingOperations.font8));
                    PdfPCell cell3 = new PdfPCell(new Phrase("Invoice No    : " + PrintingOperations.sale.Invoicenumber, PrintingOperations.font8));
                    PdfPCell cell4 = new PdfPCell(new Phrase("Customer Name : " + PrintingOperations.sale.customer.Name, PrintingOperations.font8));
                    PdfPCell cell5 = new PdfPCell(new Phrase("Mobile Number : " + PrintingOperations.sale.customer.MobileNumber, PrintingOperations.font8));
                    PdfPCell cell6 = new PdfPCell(new Phrase("GST Number    : " + PrintingOperations.sale.customer.GSTNumber, PrintingOperations.font8));
                    cell1.Border = Rectangle.NO_BORDER;
                    cell2.Border = Rectangle.NO_BORDER;
                    cell6.Colspan = 2;
                    cell2.HorizontalAlignment = 2;
                    cell3.Colspan = 2;
                    cell4.Colspan = 2;
                    cell3.Border = Rectangle.NO_BORDER;
                    cell4.Border = Rectangle.NO_BORDER;
                    cell5.Border = Rectangle.NO_BORDER;
                    cell6.Border = Rectangle.NO_BORDER;
                    cell5.Colspan = 2;

                    tble.AddCell(cell3);
                    tble.AddCell(cell1);
                    tble.AddCell(cell2);
                   
                    tble.AddCell(cell4);
                    //tble.AddCell(cell5);
                    if(!string.IsNullOrEmpty(PrintingOperations.sale.customer.GSTNumber))
                        tble.AddCell(cell6);
                    document.Add(head1);
                    document.Add(head2);
                    document.Add(head3);
                    tble.SpacingAfter = 5;
                    document.Add(tble);
                }
                else if (PrintingOperations.HeaderFlag == 2)
                {
                    Paragraph head1 = new Paragraph("M/s. Gundesha Metal Mart", PrintingOperations.fontBold9);
                    head1.Alignment = 1;
                    Paragraph head2 = new Paragraph("Ashok Nagar Nipani", PrintingOperations.fontBold9);
                    head2.Alignment = 1;
                    Paragraph head3 = new Paragraph("Wholesaler in Copper,Brans,Aluminiumum,Stainless SteelCooker,Mixer and Copper wires", PrintingOperations.font8);
                    head3.Alignment = 1;
                    Paragraph head4 = new Paragraph("\n", PrintingOperations.font8);
                    head4.Alignment = 1;
                    document.Add(head1); document.Add(head2); document.Add(head3); document.Add(head4);
                    PdfPTable tble = new PdfPTable(new float[] { 70, 30 });
                    tble.WidthPercentage = 100;
                    document.Add(tble);

                    PdfPTable tbl2 = new PdfPTable(PrintingOperations.datagridview1.Columns.Count);
                    tbl2.WidthPercentage = 100;
                    foreach (DataGridViewColumn col in PrintingOperations.datagridview1.Columns)
                    {
                        // if (col.Visible)
                        {
                            PdfPCell tblhead = new PdfPCell(new Phrase(col.HeaderText, PrintingOperations.fontBold8));
                            tbl2.AddCell(tblhead);
                        }
                    }
                    document.Add(tbl2);
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Paragraph p = new Paragraph("hiii");
            // document.Add(p);            
        }
    }
}
