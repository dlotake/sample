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
    public partial class frmDatabaseBackup : Form
    {
        public frmDatabaseBackup()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                txtFileLocation.Text = folderBrowserDialog1.SelectedPath.ToString() + "\\KetanShaha_Database_Backup_" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak";
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                using (SellingContext obj = new SellingContext())
                {
                    string dbname = obj.Database.Connection.Database;
                    string sqlCommand = @"BACKUP DATABASE " + dbname + " TO DISK='"+txtFileLocation.Text+"'";
                    obj.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, "", ""));
                }
                MessageBox.Show("Database backup successfully.");
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
    }
}
