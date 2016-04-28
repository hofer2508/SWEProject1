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

namespace CustomerManager
{
    public partial class frmAdd : frmUser
    {
        #region MemberVariables
        private int id;
        private Customer cNew = null;
        private List<Customer> customers;
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
                try
                {
                    cNew = new Customer(this.id, this.tbxFirstName.Text, this.tbxLastName.Text, this.tbxEmail.Text);

                if (!(Customer.IsEmailUnique(CNew, this.customers)))
                {
                    throw new InvalidOperationException("Email is not unique!");
                }
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
