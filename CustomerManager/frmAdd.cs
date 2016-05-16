using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using customerDLL;
using System.Diagnostics;

namespace CustomerManager
{
    public partial class frmAdd : frmUser
    {
        #region MemberVariables
        private int id;
        private Customer cNew = null;
        private List<Customer> customers;
        private Stopwatch timer;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new frmAdd form.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customers"></param>
        public frmAdd(int id, List<Customer> customers)
        {
            InitializeComponent();
            this.id = id;
            this.customers = customers;
            this.cNew = null;         
            this.timer = new Stopwatch();
        }
        #endregion

        #region Properties
        public Customer CNew
        {
            get { return this.cNew; }
        }
        #endregion

        #region Events
        private void btnOK_Click(object sender, EventArgs e)
        {
            timer.Start();
                try
                {
                    cNew = new Customer(this.id, this.tbxFirstName.Text, this.tbxLastName.Text, this.tbxEmail.Text);

                if (!(Customer.IsEmailUnique(CNew, this.customers)))
                {
                    throw new InvalidOperationException("Email is not unique!");
                }
                timer.Stop();
                MessageBox.Show(timer.Elapsed.ToString());
                    DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                        
        }
        #endregion
    }
}
