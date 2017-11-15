using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSelling.Models;

namespace WindowsSelling
{
    public partial class frmSaleMaster : Form
    {
        public frmSaleMaster()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmSale sale = new frmSale();
            sale.ShowDialog();
            LoadSaleMaster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell != null)
                {
                    int SaleId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    frmSale sale = new frmSale(SaleId);
                    sale.ShowDialog();
                    LoadSaleMaster();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void frmSaleMaster_Load(object sender, EventArgs e)
        {
            LoadCustomername();
            LoadSaleMaster();
        }

        public void LoadCustomername()
        {
            try
            {
                txtcustomername.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtcustomername.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
                DataCollection.AddRange(BusinessModel.CustomerOperations.LoadCustomers().Select(n => n.Name).ToArray());
                txtcustomername.AutoCompleteCustomSource = DataCollection;

            }
            catch (Exception ex)
            {

                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadSaleMaster()
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<Sale> sales = BusinessModel.SaleOperations.LoadSaleRecords();
                foreach (Sale s in sales)
                {
                    dataGridView1.Rows.Add(s.SaleId,s.Invoicenumber, s.Date.ToString("dd/MMM/yyyy"), s.customer.Name, s.CGST, s.SGST, s.IGST, s.FinalTotal, s.PaymentMode, s.RemainingAmount);
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadSaleMaster(string customername, bool _customername, DateTime start, bool _start, DateTime end, bool _end)
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<Sale> sales = BusinessModel.SaleOperations.LoadSaleRecords(customername, _customername, start, _start, end, _end);
                foreach (Sale s in sales)
                {
                    dataGridView1.Rows.Add(s.SaleId, s.Date.ToString("dd/MMM/yyyy"), s.customer.Name, s.CGST, s.SGST, s.IGST, s.FinalTotal, s.PaymentMode, s.RemainingAmount);
                }
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string customername = txtcustomername.Text;
                bool _customername = chkcusstomername.Checked;
                DateTime start = dateTimePicker1.Value;
                bool _start = chkdate.Checked;
                DateTime end = dateTimePicker2.Value;
                bool _end = chkdate.Checked;
                LoadSaleMaster(customername, _customername, start, _start, end, _end);
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedCells.Count > 0)
                {
                    int SaleId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    bool status = BusinessModel.SaleOperations.SaleDelete(SaleId);
                    if (status)
                        MessageBox.Show("Record is deleted");
                    else
                        MessageBox.Show("Record is not deleted");
                    LoadSaleMaster();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmDeleteSale obj = new frmDeleteSale();
            obj.ShowDialog();
            LoadSaleMaster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int saleid = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                BusinessModel.PrintingOperations.SalePrint(saleid);
            }
            catch (Exception ex)
            {

                BusinessModel.Log.Logger(ex);
            }
        }

        private void chkPendingAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPendingAmount.Checked)
            {
                dataGridView1.Rows.Clear();
                List<Sale> sales = BusinessModel.SaleOperations.LoadPendingSaleRecords();
                foreach (Sale s in sales)
                {
                    dataGridView1.Rows.Add(s.SaleId, s.Date.ToString("dd/MMM/yyyy"), s.customer.Name, s.CGST, s.SGST, s.IGST, s.FinalTotal, s.PaymentMode, s.RemainingAmount);
                }
                dataGridView1.ClearSelection();
            }
            else
            {
                LoadSaleMaster();
            }
        }
    }
}
