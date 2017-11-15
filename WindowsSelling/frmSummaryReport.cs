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
    public partial class frmSummaryReport : Form
    {
        List<SaleDetail> saledetails = new List<SaleDetail>();
        public frmSummaryReport()
        {
            InitializeComponent();
        }

        private void frmSummaryReport_Load(object sender, EventArgs e)
        {
            try
            {
                radioButton1.Checked = true;
                LoadMaterialName();
                datestartdate.Value = datestartdate.Value.AddDays(-7);
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void LoadMaterialName()
        {
            try
            {
                List<string> Materials = BusinessModel.ProductOperations.GetMaterials().Distinct().ToList();
                cmbmaterialname.DataSource = Materials;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void AllMaterialReport()
        {
            try
            {

            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void MaterialReport()
        {
            try
            {
                if (chkMaterialwise.Checked)
                    saledetails = BusinessModel.SaleOperations.MaterialWise(cmbmaterialname.Text, datestartdate.Value, dateendate.Value);
                else
                    saledetails = BusinessModel.SaleOperations.AllMaterialWise(datestartdate.Value, dateendate.Value);

            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        public void GenerateReport()
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (radioButton1.Checked)
                {
                    foreach (SaleDetail salede in saledetails)
                    {
                        dataGridView1.Rows.Add(BusinessModel.ProductOperations.GetProductDetails(salede.ProductId).material, salede.CGSTAmount.ToString("n"), salede.SGSTAmount.ToString("n"), salede.IGSTAmount.ToString("n"));
                    }
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows.Add("Total", Math.Round(saledetails.Sum(n => n.CGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.SGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.IGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.IGSTAmount), 2).ToString("n"));
                    if (chkMaterialwise.Checked)
                        dataGridView1.Columns[0].Visible = false;
                    else
                        dataGridView1.Columns[0].Visible = true;
                }
                else if(radioButton2.Checked)
                {
                    var result = saledetails.GroupBy(n => BusinessModel.ProductOperations.GetProductDetails(n.ProductId).material).Select(n => n.ToList()).ToList();
                    double cgsttotal = 0, sgsttotal = 0, igsttotal = 0;
                    foreach (var temp in result)
                    {
                        cgsttotal += temp.Sum(n => n.CGSTAmount);
                        sgsttotal += temp.Sum(n => n.SGSTAmount);
                        igsttotal += temp.Sum(n => n.IGSTAmount);
                        dataGridView1.Rows.Add(BusinessModel.ProductOperations.GetProductDetails(temp[0].ProductId).material, temp.Sum(n=>n.CGSTAmount).ToString("n"), temp.Sum(n => n.SGSTAmount).ToString("n"), temp.Sum(n => n.IGSTAmount).ToString("n"));
                    }
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows.Add("Total", Math.Round(saledetails.Sum(n => n.CGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.SGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.IGSTAmount), 2).ToString("n"), Math.Round(saledetails.Sum(n => n.IGSTAmount), 2).ToString("n"));

                }
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            MaterialReport();
            GenerateReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            BusinessModel.PrintingOperations.PrintSummaryReport(dataGridView1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
