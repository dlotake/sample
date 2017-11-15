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
    public partial class MDI : Form
    {
        private int childFormNumber = 0;

        public MDI()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmSaleMaster obj = new frmSaleMaster();
            obj.MdiParent = this.MdiParent;
            obj.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer obj = new frmCustomer();
            obj.ShowDialog();
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProduct obj = new frmProduct();
            obj.ShowDialog();
        }

        private void productAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductAdd obj = new frmProductAdd();
            obj.ShowDialog();
        }

        private void customerAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerAdd obj = new frmCustomerAdd();           
            obj.ShowDialog();
        }

        private void itemSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSale obj = new frmSale();           
            obj.ShowDialog();
        }

        private void databaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup DatabaseBackup = new frmDatabaseBackup();
            DatabaseBackup.ShowDialog();
        }

        private void databaseRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDatabaseRestore DatabaseRestore = new frmDatabaseRestore();
            DatabaseRestore.ShowDialog();
        }

        private void btnbackup_Click(object sender, EventArgs e)
        {
            frmDatabaseBackup DatabaseBackup = new frmDatabaseBackup();
            DatabaseBackup.ShowDialog();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            frmDatabaseRestore DatabaseRestore = new frmDatabaseRestore();
            DatabaseRestore.ShowDialog();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmProduct Product = new frmProduct();
            Product.ShowDialog();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer Customer = new frmCustomer();
            Customer.ShowDialog();
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            frmSale Sale = new frmSale();
            Sale.ShowDialog();
        }

        private void saleSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSummaryReport SummaryReport = new frmSummaryReport();
            SummaryReport.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSummaryReport SummaryReport = new frmSummaryReport();
            SummaryReport.ShowDialog();
        }

        private void MDI_Load(object sender, EventArgs e)
        {
            btnSale.Focus();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void btnsalemaster_Click(object sender, EventArgs e)
        {
            frmSaleMaster sale = new frmSaleMaster();
            sale.ShowDialog();
        }
    }
}
