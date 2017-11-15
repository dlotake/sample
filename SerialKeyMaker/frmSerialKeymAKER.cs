using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialKeyMaker
{
    public partial class frmSerialKeyMaker : Form
    {
        public frmSerialKeyMaker()
        {
            InitializeComponent();
            string str = GetMACAddress2();
        }

        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                 textBox2.Text =  EnCryptDecrypt.CryptorEngine.Encrypt(textBox1.Text,true);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
