using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WindowsSelling.Models
{
    class Security
    {
        public static string GetMACAddress2()
        {
            try
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
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return "";
            }
        }

        public static bool CheckSerialKey()
        {
            try
            {
                Microsoft.Win32.RegistryKey key;
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Selling_Application_Serial_Key");
                var Value = key.GetValue("Selling_Application_Serial_Key");
                key.Close();
                return Value == null ? false : true;                                
            }
            catch (Exception ex)
            {
                BusinessModel.Log.Logger(ex);
                return false;
            }
        }



    }
}
