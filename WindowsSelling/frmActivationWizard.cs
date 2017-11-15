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
    public partial class frmActivationWizard : Form
    {
        public frmActivationWizard()
        {
            InitializeComponent();
        }

        private void btnactivation_Click(object sender, EventArgs e)
        {
            try
            {
                string Mac = Security.GetMACAddress2();
                string ActivationCose = EnCryptDecrypt.CryptorEngine.Decrypt(txtActivateCode.Text, true);
                if(Mac.Equals(ActivationCose))
                {
                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Selling_Application_Serial_Key");
                    key.SetValue("Selling_Application_Serial_Key",Mac);                    
                    MessageBox.Show("Product Activated");
                    this.Close();
                    new MDI().Show();                  
                }
                else
                {
                    MessageBox.Show("Please enter valid key");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid key");
            }
        }

        private void frmActivationWizard_Load(object sender, EventArgs e)
        {
            try
            {
                string Mac = Security.GetMACAddress2();
                txtMachineCode.Text = Mac;
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
