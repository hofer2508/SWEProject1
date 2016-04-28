using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerDLL
{
    public class Customer
    {
        #region Membervariables
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private double balance;
        private DateTime lastChange;
        #endregion

        /// <summary>
        /// Creates a new Customer with no balance and the last change is now.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        #region Konstruktoren
        public Customer(int id,
            string firstName,
            string lastName,
            string email)
        {
            if (IsNameValid(firstName))
            {
                this.firstName = firstName;
            }
            else
            {
                throw new InvalidOperationException("First Name is not Valid!");
            }

            if (IsNameValid(lastName))
            {
                this.lastName = lastName;
            }
            else
            {
                throw new InvalidOperationException("Last Name is not Valid!");
            }

            if (IsEmailValid(email))
            {
                this.email = email;
            }
            else
            {
                throw new InvalidOperationException("Email is not Valid!");
            }

            this.id = id;
            this.balance = 0;
            this.lastChange = DateTime.Now;
        }

        /// <summary>
        /// Creates customers when reading the database. The customers have a balance and a last change that is not now.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="balance"></param>
        /// <param name="lastChange"></param>
        public Customer(int id,
            string firstName,
            string lastName,
            string email,
            double balance,
            DateTime lastChange)
        {
            if (IsNameValid(firstName))
            {
                this.firstName = firstName;
            }
            else
            {
                throw new InvalidOperationException("First Name is not Valid!");
            }

            if (IsNameValid(lastName))
            {
                this.lastName = lastName;
            }
            else
            {
                throw new InvalidOperationException("Last Name is not Valid!");
            }

            if (IsEmailValid(email))
            {
                this.email = email;
            }
            else
            {
                throw new InvalidOperationException("Email is not Valid!");
            }

            this.id = id;
            this.balance = balance;
            this.lastChange = lastChange;
        }

        #endregion

        #region Eigenschaften

        public int ID
        {
            get { return this.id; }
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public double Balance
        {
            get { return this.balance; }
            private set { this.balance = value; }
        }

        public DateTime LastChange
        {
            get { return this.lastChange; }
            set { this.lastChange = value; }
        }
        #endregion

        #region Membermethoden
        /// <summary>
        /// Adds an amount the balance of the customer.
        /// </summary>
        /// <param name="newAmount"></param>
        public void Addamount(double newAmount)
        {
            this.Balance += newAmount;
        }
        
        /// <summary>
        /// Checks wether the email adress is valid.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsEmailValid(string email)          //statisch oder dynamisch??
        {
            bool valid = true;

            try
            {

                //exakt 1 @
                string[] tempStr = email.Split('@');
                int cnt = tempStr.Length;
                if (cnt != 2)
                {
                    valid = false;
                }
                //mindestend einen . nach dem @
                else if (!tempStr[1].Contains("."))
                {
                    valid = false;
                }
                // mindestens ein Zeichen vor @
                else if (tempStr[0] == "") 
                {
                    valid = false;
                }
                //nach letztem Punkt 2-4 Zeichen
                else
                {
                    string[] tempStr2 = tempStr[1].Split('.');
                    if (tempStr2[tempStr2.Length - 1].Length > 4 || tempStr2[tempStr2.Length - 1].Length < 2)
                    {
                        valid = false;
                    }
                }
                //Kein Punkt am Anfang oder bevor/nach @
                if (valid)
                {
                    if (email[0] == '.' || email[email.Length-1] == '.')
                    {
                        valid = false;
                    }
                    string teil1 = tempStr[0];
                    string teil2 = tempStr[1];
                    if (teil1[teil1.Length-1] == '.' || teil2[0] == '.')
                    {
                        valid = false;
                    }


                    // Nur Buchstaben Zahlen oder .
                    bool result = email.All(c => Char.IsLetterOrDigit(c) || c == '.' || c == '@');
                    if (!result)
                    {
                        valid = false;
                    }
                }

                }
            catch (Exception)
            {
            }


            return valid;
        }

        /// <summary>
        /// Checks wether the name (both first and fast) is valid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsNameValid(string name)            //statisch oder dynamisch??
        {
            bool valid = true;

            if (Char.IsLower(name[0]))    { valid = false; }
            if (name.Length < 2 || name.Length >50) { valid = false; }
            foreach (char item in name)
            {
                if(Char.IsDigit(item)) { valid = false; }
                if(!(Char.IsLetterOrDigit(item) || item =='-')) { valid = false; }
            }

            return valid;
        }
        
        public override string ToString()
        {
            string output = String.Format("{0:3} {1:15} {2:15} {3:20} {4} {5}", this.ID, this.FirstName, this.LastName, this.Email, this.Balance, this.LastChange);
            return output;
        }

        #endregion

        #region statische Methoden
        public static bool IsEmailUnique(Customer c, List<Customer> customers)
        {
            bool unique = true;

            foreach (Customer i in customers)
            {
                if (c.Email == i.Email && c.ID != i.ID)
                {
                    unique = false;
                }
            }

            return unique;
        }
        #endregion
    }
}
