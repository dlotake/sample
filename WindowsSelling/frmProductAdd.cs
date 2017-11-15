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
    public partial class frmProductAdd : Form
    {
        int ProductId = -1;
        public frmProductAdd()
        {
            InitializeComponent();
        }
        public frmProductAdd(int ProductId)
        {
            InitializeComponent();
            this.ProductId = ProductId;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    Product product = new Product() { CGST = Convert.ToDouble(txtcgst.Text), IGST = Convert.ToDouble(txtIGST.Text), Name = txtname.Text, Rate = Convert.ToDouble(txtrate.Text), SGST = Convert.ToDouble(txtSGST.Text) };
                    // Material material = new Material();
                    //material.Name = txtmaterialtype.Text;
                    product.material = txtmaterialtype.Text;
                    product.ProductId = ProductId;
                    bool status = ProductOperations.SaveProduct(product);
                    if (status)
                        MessageBox.Show("Product Saved", "OK");
                    else
                        MessageBox.Show("Product is not saved", "Warning");
                    if (ProductId == -1)
                        Clear();
                    else
                        this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter all the fields", "Validation");
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);

            }
        }

        private void frmProductAdd_Load(object sender, EventArgs e)
        {
            try
            {
                AutoCompleteStringCollection source = new AutoCompleteStringCollection();
                txtmaterialtype.AutoCompleteCustomSource = source;
                txtmaterialtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtmaterialtype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (ProductId != -1)
                {
                    using (SellingContext obj = new SellingContext())
                    {
                        List<Product> products = obj.Products.Where(n => n.ProductId == ProductId).ToList();
                        txtcgst.Text = products[0].CGST.ToString();
                        txtSGST.Text = products[0].SGST.ToString();
                        txtIGST.Text = products[0].IGST.ToString();
                        txtmaterialtype.Text = products[0].material;
                        txtname.Text = products[0].Name;
                        txtrate.Text = products[0].Rate.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void Clear()
        {
            txtcgst.Text = "0.00";
            txtIGST.Text = "0.00";
            txtmaterialtype.Text = "";
            txtname.Text = "";
            txtrate.Text = "0.00";
            txtSGST.Text = "0.00";
            txtname.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Amount(sender, e);
        }

        private void txtcgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Amount(sender, e);
        }

        private void txtSGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Amount(sender, e);
        }

        private void txtIGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validations.Amount(sender, e);
        }

        public bool Validate()
        {
            try
            {

                if (string.IsNullOrEmpty(txtname.Text) || string.IsNullOrEmpty(txtmaterialtype.Text) || string.IsNullOrEmpty(txtrate.Text) || string.IsNullOrEmpty(txtcgst.Text) || string.IsNullOrEmpty(txtSGST.Text) || string.IsNullOrEmpty(txtIGST.Text))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
        }

        private void txtcgst_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
