using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsSelling.BusinessModel
{
    class Log
    {
        public static string Location = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static void Logger(Exception ExceptionSource)
        {
            try
            {
                Location = System.Reflection.Assembly.GetExecutingAssembly().Location;
                Location = System.IO.Path.GetDirectoryName(Location);
                if(!File.Exists(Location+"\\Log"))
                {
                    File.CreateText(Location + "\\Log");
                }
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(Location + "\\Log"))
                {
                    sw.WriteLine("Message : "+ ExceptionSource.Message);
                    sw.WriteLine("Error : "+ExceptionSource.StackTrace);                    
                }
                MessageBox.Show("Error Generated");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
