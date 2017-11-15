using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsSelling
{
    public partial class frmCustomer : Form
    {
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmCustomerAdd CustomerAdd = new frmCustomerAdd();
                CustomerAdd.ShowDialog();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCustomers();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadCustomers()
        {
            try
            {
                source = new AutoCompleteStringCollection();
                var Customers = BusinessModel.CustomerOperations.LoadCustomers();
                dataGridView1.Rows.Clear();
                foreach (Models.Customer customer in Customers)
                {
                    source.Add(customer.Name);
                    dataGridView1.Rows.Add(customer.CustomerId, customer.Name, customer.Address, customer.MobileNumber, customer.GSTNumber);
                }
                txtcustomersearch.AutoCompleteCustomSource = source;
                txtcustomersearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtcustomersearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int index = source.Cast<string>().ToList().IndexOf(txtcustomersearch.Text);
                    if (index <= dataGridView1.Rows.Count)
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[index].Selected = true;
                    }
                }

                if (string.IsNullOrEmpty((sender as TextBox).Text))
                    dataGridView1.ClearSelection();


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
                if (dataGridView1.SelectedCells.Count == 0 && dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select the customer first");
                }
                else
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    int CustomerId = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());
                    frmCustomerAdd CustomerAdd = new frmCustomerAdd(CustomerId);
                    CustomerAdd.ShowDialog();
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedCells.Count == 0 && dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select the customer first");
                }
                else
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    int CustomerId = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value.ToString());
                    bool Status = BusinessModel.CustomerOperations.DeleteCustomer(CustomerId);
                    if (Status)
                        MessageBox.Show("Customer Deleted", "OK");
                    else
                        MessageBox.Show("Customer is not Deleted", "OK");
                    LoadCustomers();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnRestoreDeleted_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeletedCustomer obj = new frmDeletedCustomer();
                obj.ShowDialog();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }
    }
}
