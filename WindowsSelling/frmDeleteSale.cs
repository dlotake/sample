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
    public partial class frmDeleteSale : Form
    {
        public frmDeleteSale()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmSale sale = new frmSale();
                sale.ShowDialog();
                LoadDeletedSaleMaster();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
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
                    LoadDeletedSaleMaster();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void frmSaleMaster_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCustomername();
                LoadDeletedSaleMaster();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
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

        public void LoadDeletedSaleMaster()
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<Sale> sales = BusinessModel.SaleOperations.LoadDeletedSaleRecords();
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

        public void LoadDeletedSaleMaster(string customername, bool _customername, DateTime start, bool _start, DateTime end, bool _end)
        {
            try
            {
                dataGridView1.Rows.Clear();
                List<Sale> sales = BusinessModel.SaleOperations.LoadDeletedSaleRecords(customername, _customername, start, _start, end, _end);
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
                LoadDeletedSaleMaster(customername, _customername, start, _start, end, _end);
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int SaleId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                bool status = BusinessModel.SaleOperations.SaleUndoDelete(SaleId);
                if (status)
                    MessageBox.Show("Record restored!!!", "OK");
                else
                    MessageBox.Show("Record is not restored", "Error");
                LoadDeletedSaleMaster();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }
    }
}
