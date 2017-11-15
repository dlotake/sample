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
    public partial class frmDatabaseRestore : Form
    {
        public frmDatabaseRestore()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialog1.ShowDialog();
                txtFileLocation.Text = openFileDialog1.FileName;
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
                    string dbname = "KetanShahaDatabase";
                    string sqlCommand = @"USE master; RESTORE DATABASE " + dbname + " FROM DISK='"+txtFileLocation.Text+"'";
                    obj.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, "", ""));
                }
                MessageBox.Show("Database restored successfully.");
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                MessageBox.Show("Error while restoring database");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
