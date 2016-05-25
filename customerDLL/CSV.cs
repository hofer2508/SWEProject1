using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace customerDLL
{
    public class CSV
    {
        #region MemberVariables
        StreamReader strReader;
        StreamWriter strWriter;
        string path;
        byte[] key = new byte[32] {1,255,15,26,23,59,155,251,1,1,78,98,198,200,2,1,9,8,7,6,5,55,2,33,44,56,89,100,123,211,89,1};
        byte[] iv = new byte[16] { 58, 100, 1, 255, 123, 5, 89, 99, 65, 78, 123, 189, 208, 210, 9, 55 };
        List<Customer> customers;

        #endregion

        #region Construktor
        /// <summary>
        /// Creates a new CSV object, with the CSV file stored at "path".
        /// </summary>
        /// <param name="path"></param>
        public CSV(string path)
        {
            this.path = path;
            try
            {
                customers = ReadCSV();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                WriteCSV();
                customers = ReadCSV();
            }
        }
        #endregion

        #region Properties 

        public List<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; }
        }
        #endregion

        #region Membermethods
        /// <summary>
        /// Writes the list of sustomers to the CSV file.
        /// </summary>
        public void WriteCSV()
        {
            this.strWriter = new StreamWriter(this.path, false, Encoding.Default);

            try
            {
                for (int i = 0; i < customers.Count; i++)
                {


                    this.strWriter.WriteLine("{0};{1};{2};{3};{4};{5}4", EncryptString(Convert.ToString(this.customers[i].ID)),
                                                        EncryptString(this.customers[i].FirstName),
                                                        EncryptString(this.customers[i].LastName),
                                                        EncryptString(this.customers[i].Email),
                                                        EncryptString(Convert.ToString(this.customers[i].Balance)),
                                                        EncryptString(Convert.ToString(this.customers[i].LastChange)));
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }

            strWriter.Close();
        }

        /// <summary>
        /// Reads the CSV file and creates a new list of customers.
        /// </summary>
        /// <returns></returns>
        List<Customer> ReadCSV()
        {
            List<Customer> customers = new List<Customer>();
            strReader = new StreamReader(this.path);
            string line;
            string[] parts;
            Error error;
            while (strReader.Peek() >= 0)
            {
                line = strReader.ReadLine();
                parts = line.Split(';');
                customers.Add(new Customer(Convert.ToInt32(DecryptString(parts[0])), DecryptString(parts[1]), DecryptString(parts[2]), DecryptString(parts[3]), Convert.ToDouble(DecryptString(parts[4])), Convert.ToDateTime(DecryptString(parts[5])), out error));   //??????
                //Neuer Konstruktor bei dem New amount und Datum eingebbar??????????????????????????????
            }
            strReader.Close();

            return customers;
        }

        /// <summary>
        /// Encrypts the string.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        string EncryptString(string original)
        {
            byte[] encrypted;
            string encrString = "";
         
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = this.key;
                aesAlg.IV = this.iv;
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            swEncrypt.Write(original);
                        }
                        encrypted = msEncrypt.ToArray();

                        foreach (var value in encrypted)
                        {
                            encrString += value.ToString();
                            encrString += " ";
                        }
                    }
                }
            }
            return encrString;
        }

        /// <summary>
        /// Decrypts the string.
        /// </summary>
        /// <param name="decrypted"></param>
        /// <returns></returns>
        string DecryptString(string decrypted)
        {
            string plaintext = null;
            
            string[] number = decrypted.Split(' ');
            byte[] bnumber = new byte[number.Length - 1];

            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] != " ")
                {
                    bnumber[i] = Convert.ToByte(number[i]);
                }
            }


            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = this.key;
                aesAlg.IV = this.iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(bnumber))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
        #endregion

        #region staticMethods
        #endregion
    }
}
