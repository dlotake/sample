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

    public partial class frmProduct : Form
    {
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        public frmProduct()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductAdd ProductAdd = new frmProductAdd();
                ProductAdd.ShowDialog();
                LoadProducts();
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
                if (dtgridproductlist.SelectedCells.Count == 0 && dtgridproductlist.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select the product first");
                }
                else
                {
                    int index = dtgridproductlist.CurrentCell.RowIndex;
                    int ProductId = Convert.ToInt32(dtgridproductlist.Rows[index].Cells[6].Value.ToString());
                    frmProductAdd ProductAdd = new frmProductAdd(ProductId);
                    ProductAdd.ShowDialog();
                    LoadProducts();
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

        private void frmProduct_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProducts();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadProducts()
        {
            try
            {
                source = new AutoCompleteStringCollection();
                var products = BusinessModel.ProductOperations.LoadProducts();
                dtgridproductlist.Rows.Clear();
                foreach (Models.Product product in products)
                {
                    source.Add(product.Name);
                    dtgridproductlist.Rows.Add(product.Name, product.material, product.Rate, product.CGST, product.SGST, product.IGST, product.ProductId);
                }
                txtsearchmaterial.AutoCompleteCustomSource = source;
                txtsearchmaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtsearchmaterial.AutoCompleteSource = AutoCompleteSource.CustomSource;
                dtgridproductlist.ClearSelection();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void txtsearchmaterial_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtsearchmaterial_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int index = source.Cast<string>().ToList().IndexOf(txtsearchmaterial.Text);
                    if (index <= dtgridproductlist.Rows.Count)
                    {
                        dtgridproductlist.ClearSelection();
                        dtgridproductlist.Rows[index].Selected = true;
                    }
                }

                if (string.IsNullOrEmpty((sender as TextBox).Text))
                    dtgridproductlist.ClearSelection();


            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgridproductlist.SelectedCells.Count == 0 && dtgridproductlist.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select the product first");
                }
                else
                {
                    int index = dtgridproductlist.CurrentCell.RowIndex;
                    int ProductId = Convert.ToInt32(dtgridproductlist.Rows[index].Cells[6].Value.ToString());
                    bool Status = BusinessModel.ProductOperations.DeleteProduct(ProductId);
                    if (Status)
                        MessageBox.Show("Product Deleted", "OK");
                    else
                        MessageBox.Show("Product is not Deleted", "OK");
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnRestoreDelete_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeletedProduct obj = new frmDeletedProduct();
                obj.ShowDialog();
                LoadProducts();
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }
    }
}
