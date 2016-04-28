using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using customerDLL;

namespace CustomerManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                frmLogin login = new frmLogin();

                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmTop());
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
                      
        }
    }
}
