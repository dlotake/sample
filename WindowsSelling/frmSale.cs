using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.BusinessModel;
using WindowsSelling.Models;

namespace WindowsSelling
{
    public partial class frmSale : Form
    {
        List<Product> Products = new List<Product>();
        int SaleId = 0;
        public frmSale()
        {
            InitializeComponent();
        }

        public frmSale(int SaleId)
        {
            InitializeComponent();
            this.SaleId = SaleId;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmSale_Load(object sender, EventArgs e)
        {
            try
            {

                cmbcustomer.DataSource = BusinessModel.CustomerOperations.LoadCustomers();
                cmbcustomer.DisplayMember = "Name";
                cmbpaymentmode.SelectedIndex = 0;
                Products = BusinessModel.ProductOperations.LoadProducts();
                if (SaleId != 0)
                {
                    Sale sale = BusinessModel.SaleOperations.GetSaleRecord(SaleId);
                    cmbcustomer.Text = sale.customer.Name;
                    txtaddress.Text = sale.customer.Address;
                    txtmobilenumber.Text = sale.customer.MobileNumber;
                    dateTimePicker1.Value = sale.Date;
                    txtInvoiceNo.Text = sale.Invoicenumber.ToString();
                    txttotalitemcount.Text = sale.saledetails.Count.ToString("n");
                    txttotalCGSTAmount.Text = sale.saledetails.Sum(n => n.CGSTAmount).ToString("n");
                    txttotalSGSTAmount.Text = sale.saledetails.Sum(n => n.SGSTAmount).ToString("n");
                    txttotalIGSTAmount.Text = sale.saledetails.Sum(n => n.IGSTAmount).ToString("n");
                    txtdiscountamount.Text = sale.saledetails.Sum(n => n.DiscountAmount).ToString("n");
                    txtTotalTaxAmount.Text = sale.saledetails.Sum(n => n.CGSTAmount + n.SGSTAmount + n.IGSTAmount).ToString("n");
                    txtfinalAmount.Text = sale.saledetails.Sum(n => n.FinalAmount).ToString("n");
                    txtpaidamount.Text = sale.PaidAmount.ToString("n");
                    txtRemaining.Text = sale.RemainingAmount.ToString("n");
                    cmbpaymentmode.Text = sale.PaymentMode;
                    txtPaymentModeDetails.Text = sale.PaymentModeDetails;

                    foreach (SaleDetail s in sale.saledetails)
                    {
                        dataGridView1.Rows.Add(BusinessModel.ProductOperations.GetProductDetails(s.ProductId).Name, s.Rate, s.Quantity, s.TotalAmount, s.Discount,
                            s.DiscountAmount, s.CGST, s.CGSTAmount, s.SGST, s.SGSTAmount, s.IGST, s.IGSTAmount,
                            (s.CGSTAmount + s.SGSTAmount + s.IGSTAmount), s.FinalAmount, s.SaleDetailId);
                    }
                }
                else
                    Clear();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Customer customer = cmbcustomer.SelectedValue as Customer;
                if (customer != null)
                {
                    txtaddress.Text = customer.Address;
                    txtmobilenumber.Text = customer.MobileNumber;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

                BusinessModel.Log.Logger(ex);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string ProductName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    Product product = BusinessModel.ProductOperations.GetProductDetails(ProductName);
                    if (product != null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = product.Rate;
                        dataGridView1.Rows[e.RowIndex].Cells[6].Value = product.CGST;
                        dataGridView1.Rows[e.RowIndex].Cells[8].Value = product.SGST;
                        dataGridView1.Rows[e.RowIndex].Cells[10].Value = product.IGST;

                        dataGridView1.Rows[e.RowIndex].Cells[4].Value = "0.00";
                        dataGridView1.Rows[e.RowIndex].Cells[5].Value = "0.00";
                    }
                    else
                    {
                        MessageBox.Show("Please select product valid");
                        return;
                    }
                    //if (e.RowIndex > 0)
                    //    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex - 1].Cells[2];
                    //else
                    //    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[2];
                    UpdateCGST(e.RowIndex);
                    UpdateSGST(e.RowIndex);
                    UpdateIGST(e.RowIndex);
                }
                else if (e.ColumnIndex == 2)
                {
                    double Quantity = 0;
                    bool _Quantity = false;
                    _Quantity = double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value), out Quantity);
                    if (!_Quantity)
                    {
                        MessageBox.Show("Please enter valid Quantity");
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = 0;
                        return;
                    }
                    double Rate = 0;
                    bool _Rate = false;
                    _Rate = double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value), out Rate);
                    if (!_Rate)
                    {
                        MessageBox.Show("Please enter valid Rate");
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = 0;
                        return;
                    }
                    double Total = Math.Round(Quantity * Rate, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = Total.ToString("n");

                    double CSGT = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                    double CSGTAmount = Math.Round((CSGT * Total) / 100, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[7].Value = CSGTAmount.ToString("n");

                    double SSGT = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                    double SSGTAmount = Math.Round((SSGT * Total) / 100, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[9].Value = SSGTAmount.ToString("n");

                    double ISGT = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                    double ISGTAmount = Math.Round((ISGT * Total) / 100, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[11].Value = ISGTAmount.ToString("n"); ;
                }
                else if (e.ColumnIndex == 3)
                {
                    double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    double Quantity = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
                    double Rate = Math.Round(Total / Quantity, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = Rate;
                }
                else if (e.ColumnIndex == 4)
                {
                    double Discount = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                    double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    double DiscountAmount = Math.Round((Discount * Total) / 100, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[5].Value = DiscountAmount;
                }
                else if (e.ColumnIndex == 5)
                {
                    double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    double DiscountAmount = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                    double Discount = Math.Round((DiscountAmount / Total) * 100, 2);
                    dataGridView1.Rows[e.RowIndex].Cells[4].Value = Discount;
                }
                else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)//CGST
                {
                    //double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    //double Tax = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                    //double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                    //dataGridView1.Rows[e.RowIndex].Cells[7].Value = TaxAmount;
                    UpdateCGST(e.RowIndex);
                }
                else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)//SGST
                {
                    //double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    //double Tax = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                    //double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                    //dataGridView1.Rows[e.RowIndex].Cells[9].Value = TaxAmount;
                    UpdateSGST(e.RowIndex);
                }
                else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)//IGST
                {
                    //double Total = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    //double Tax = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                    //double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                    //dataGridView1.Rows[e.RowIndex].Cells[11].Value = TaxAmount;
                    UpdateIGST(e.RowIndex);
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[7].Value != null)
                {
                    double temptax = 0;
                    double totaltax = 0;
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(), out temptax);
                    totaltax += temptax;
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(), out temptax);
                    totaltax += temptax;
                    double.TryParse(dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString(), out temptax);
                    totaltax += temptax;
                    dataGridView1.Rows[e.RowIndex].Cells[12].Value = Math.Round(totaltax, 2);

                    double FinaLAmount = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    FinaLAmount -= Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                    FinaLAmount += totaltax;
                    dataGridView1.Rows[e.RowIndex].Cells[13].Value = Math.Round(FinaLAmount, 2).ToString("n");
                }
                LoadFinals();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void UpdateCGST(int RowIndex)
        {
            try
            {
                double Total = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[3].Value);
                double Tax = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[6].Value);
                double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                dataGridView1.Rows[RowIndex].Cells[7].Value = TaxAmount;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void UpdateSGST(int RowIndex)
        {
            try
            {
                double Total = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[3].Value);
                double Tax = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[8].Value);
                double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                dataGridView1.Rows[RowIndex].Cells[9].Value = TaxAmount;
            }
            catch (Exception ex)
            {

                BusinessModel.Log.Logger(ex);
            }
        }

        public void UpdateIGST(int RowIndex)
        {
            try
            {
                double Total = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[3].Value);
                double Tax = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[10].Value);
                double TaxAmount = Math.Round((Tax * Total) / 100, 2);
                dataGridView1.Rows[RowIndex].Cells[11].Value = TaxAmount;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadFinals()
        {
            try
            {
                txttotalitemcount.Text = (dataGridView1.Rows.Count - 1).ToString();
                double TotalCGST = 0, TotalIGST = 0, TotalSGST = 0, TotalDiscount = 0, TotalTax = 0, FinalTotal = 0;
                double _TotalCGST = 0, _TotalIGST = 0, _TotalSGST = 0, _TotalDiscount = 0, _TotalTax = 0, _FinalAmount = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[7].Value != null)
                    {
                        double.TryParse(row.Cells[7].Value.ToString(), out _TotalCGST);
                        TotalCGST += _TotalCGST;
                    }
                    if (row.Cells[9].Value != null)
                    {
                        double.TryParse(row.Cells[9].Value.ToString(), out _TotalSGST);
                        TotalSGST += _TotalSGST;
                    }
                    if (row.Cells[11].Value != null)
                    {
                        double.TryParse(row.Cells[11].Value.ToString(), out _TotalIGST);
                        TotalIGST += _TotalIGST;
                    }
                    if (row.Cells[5].Value != null)
                    {
                        double.TryParse(row.Cells[5].Value.ToString(), out _TotalDiscount);
                        TotalDiscount += _TotalCGST;
                    }
                    if (row.Cells[12].Value != null)
                    {
                        double.TryParse(row.Cells[12].Value.ToString(), out _TotalTax);
                        TotalTax += _TotalTax;
                    }
                    if (row.Cells[13].Value != null)
                    {
                        double.TryParse(row.Cells[13].Value.ToString(), out _FinalAmount);
                        FinalTotal += _FinalAmount;
                    }
                }

                txttotalCGSTAmount.Text = TotalCGST.ToString("n");
                txttotalSGSTAmount.Text = TotalSGST.ToString("n");
                txttotalIGSTAmount.Text = TotalIGST.ToString("n");
                txtdiscountamount.Text = TotalDiscount.ToString("n");
                txtTotalTaxAmount.Text = TotalTax.ToString("n");
                txtfinalAmount.Text = FinalTotal.ToString("n");
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Save()
        {
            try
            {
                if (string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    MessageBox.Show("PLease enter invoice number");
                    return false;
                }
                if (!ValidateGrid())
                {
                    MessageBox.Show("Please enter valid data into product cart.");
                    return false;
                }
                Sale sale = new Sale();
                sale.SaleId = SaleId;
                List<SaleDetail> saledetails = new List<SaleDetail>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null)
                        continue;
                    if (Products.Count(n => n.Name == row.Cells[0].Value.ToString()) == 0)
                        continue;
                    SaleDetail saledetail = new SaleDetail();
                    if (row.Cells[14].Value != null)
                        saledetail.SaleDetailId = Convert.ToInt32(row.Cells[14].Value.ToString());
                    saledetail.ProductId = BusinessModel.ProductOperations.GetProductDetails((row.Cells[0]).FormattedValue.ToString()).ProductId;
                    saledetail.Discount = Convert.ToDouble(row.Cells[4].Value.ToString());
                    saledetail.DiscountAmount = Convert.ToDouble(row.Cells[5].Value.ToString());
                    saledetail.CGST = Convert.ToDouble(row.Cells[6].Value.ToString());
                    saledetail.CGSTAmount = Convert.ToDouble(row.Cells[7].Value.ToString());
                    saledetail.Date = dateTimePicker1.Value;
                    saledetail.FinalAmount = Convert.ToDouble(row.Cells[13].Value.ToString());
                    saledetail.SGST = Convert.ToDouble(row.Cells[8].Value.ToString());
                    saledetail.SGSTAmount = Convert.ToDouble(row.Cells[9].Value.ToString());
                    saledetail.IGST = Convert.ToDouble(row.Cells[10].Value.ToString());
                    saledetail.IGSTAmount = Convert.ToDouble(row.Cells[11].Value.ToString());
                    saledetail.Quantity = Convert.ToDouble(row.Cells[2].Value.ToString());
                    saledetail.Rate = Convert.ToDouble(row.Cells[1].Value.ToString());
                    saledetail.TotalAmount = Convert.ToDouble(row.Cells[3].Value.ToString());
                    saledetail.SaleId = sale;
                    saledetails.Add(saledetail);
                }
                if (saledetails.Count > 0)
                {
                    sale.Invoicenumber = Convert.ToInt64(txtInvoiceNo.Text);
                    sale.saledetails = saledetails;
                    sale.customer = cmbcustomer.SelectedValue as Customer;
                    sale.Date = dateTimePicker1.Value;
                    sale.FinalTotal = saledetails.Sum(n => n.FinalAmount);
                    sale.IGST = saledetails.Sum(n => n.IGSTAmount);
                    sale.SGST = saledetails.Sum(n => n.SGSTAmount);
                    sale.CGST = saledetails.Sum(n => n.CGSTAmount);
                    sale.Total = saledetails.Sum(n => n.TotalAmount);
                    sale.TotalTax = saledetails.Sum(n => n.TotalAmount);
                    sale.PaidAmount = Convert.ToDouble(txtpaidamount.Text);
                    sale.RemainingAmount = Convert.ToDouble(txtRemaining.Text);
                    sale.PaymentModeDetails = txtPaymentModeDetails.Text;
                    sale.PaymentMode = cmbpaymentmode.Text;
                    bool Status = false;
                    if (SaleId == 0)
                        Status = BusinessModel.SaleOperations.SaveSaleRecord(sale, out SaleId);
                    else
                        Status = BusinessModel.SaleOperations.UpdateSaleRecord(sale);
                    if (Status)
                        MessageBox.Show("Record Saved", "OK");
                    else
                        MessageBox.Show("Record not Saved", "Error");
                    return Status;
                }
                else
                {
                    MessageBox.Show("No product found", "Error");
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
            return false;
        }

        public void Clear()
        {
            txtInvoiceNo.Text = "";
            cmbcustomer.SelectedIndex = 0;
            cmbpaymentmode.SelectedIndex = 0;
            dataGridView1.Rows.Clear();
            txtdiscountamount.Text = "0.00";
            txtfinalAmount.Text = "0.00";
            txtpaidamount.Text = "0.00";
            txtPaymentModeDetails.Text = "";
            txtRemaining.Text = "0.00";
            txttotalCGSTAmount.Text = "0.00";
            txttotalIGSTAmount.Text = "0.00";
            txttotalitemcount.Text = "0.00";
            txttotalSGSTAmount.Text = "0.00";
            txtTotalTaxAmount.Text = "0.00";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Save();
            SaleId = 0;
            Clear();
        }

        private void txtfinalAmount_TextChanged(object sender, EventArgs e)
        {
            txtpaidamount.Text = txtfinalAmount.Text;
        }

        private void txtpaidamount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double FinalAmount = Convert.ToDouble(txtfinalAmount.Text);
                double PaidAmount = Convert.ToDouble(txtpaidamount.Text);
                if (PaidAmount > FinalAmount)
                {
                    txtRemaining.Text = "0.00";
                    txtpaidamount.Text = txtfinalAmount.Text;
                }
                else
                {
                    txtRemaining.Text = Math.Round(FinalAmount - PaidAmount, 2).ToString("n");
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnsaveprint_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                BusinessModel.PrintingOperations.SalePrint(SaleId);
                SaleId = 0;
                Clear();
            }           
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 0)
                {
                    TextBox autoText = e.Control as TextBox;
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                    DataCollection.AddRange(Products.Select(n => n.Name).ToArray());
                    autoText.AutoCompleteCustomSource = DataCollection;
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        int index = dataGridView1.CurrentCell.RowIndex;
                        if (dataGridView1.CurrentCell.ColumnIndex <= 13)
                            dataGridView1.CurrentCell = dataGridView1.Rows[(index - 1)].Cells[dataGridView1.CurrentCell.ColumnIndex + 1];
                        else
                            dataGridView1.CurrentCell = dataGridView1.Rows[(index - 1)].Cells[0];
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            LoadFinals();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerAdd CustomerAdd = new frmCustomerAdd();
                CustomerAdd.ShowDialog();
                List<Customer> customers = BusinessModel.CustomerOperations.LoadCustomers();
                cmbcustomer.DataSource = customers;
                cmbcustomer.DisplayMember = "Name";
                cmbcustomer.SelectedIndex = customers.Count - 1;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductAdd ProductAdd = new frmProductAdd();
                ProductAdd.ShowDialog();
                Products = BusinessModel.ProductOperations.LoadProducts();

            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public bool ValidateGrid()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    for (int j = 1; j < dataGridView1.Rows[i].Cells.Count - 1; j++)
                    {
                        double value = 0;
                        bool _value = false;
                        _value = double.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[j].Value), out value);
                        if (!_value)
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
            return true;
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Number(sender, e);
        }
    }
}
