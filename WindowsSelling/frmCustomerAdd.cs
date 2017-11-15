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
    public partial class frmCustomerAdd : Form
    {
        int customerId = -1;
        public frmCustomerAdd()
        {
            InitializeComponent();
        }

        public frmCustomerAdd(int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidate())
                {
                    Customer customer = new Customer() { Address = txtaddress.Text, MobileNumber = txtmobilenumber.Text, Name = txtname.Text,GSTNumber = txtGSTNumber.Text };
                    customer.CustomerId = customerId;
                    bool status = CustomerOperations.SaveCustomer(customer);
                    if (status)
                        MessageBox.Show("Customer Saved", "OK");
                    else
                        MessageBox.Show("Customer is not saved", "Warning");
                    if (customerId == -1)
                        Clear();
                    else
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter all the details","Warning");
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void Clear()
        {
            txtname.Text = "";
            txtmobilenumber.Text = "";
            txtaddress.Text = "";
            txtGSTNumber.Text = "";
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerAdd_Load(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();                                     
                if (customerId != -1)
                {
                    using (SellingContext obj = new SellingContext())
                    {
                        List<Customer> Customers = obj.Customers.Where(n => n.CustomerId == customerId).ToList();
                        txtaddress.Text = Customers[0].Address.ToString();
                        txtmobilenumber.Text = Customers[0].MobileNumber.ToString();
                        txtname.Text = Customers[0].Name.ToString();    
                        txtGSTNumber.Text = Customers[0].GSTNumber.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public bool IsValidate()
        {            
            return !string.IsNullOrEmpty(txtaddress.Text) && !string.IsNullOrEmpty(txtname.Text) && !string.IsNullOrEmpty(txtmobilenumber.Text);
        }

        private void txtmobilenumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmobilenumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Number(sender, e);
        }
    }
}
