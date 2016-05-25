using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using customerDLL;

namespace TestDrivers
{
    class Program
    {
        static void Main(string[] args)
        {

            CSV csv = new CSV(@"..\..\..\daten.csv");       //später CSV-Pfad mit Dialog abfragen??            

            csv.WriteCSV();
            
            #region Neuen Kunden anlegen
            Customer cNew = null;
            Error error;

            //while (cNew == null)
            //{
                try
                {
                    cNew = new Customer(csv.Customers.Count, "TestTestTest", "Test", "asdf", out error);
                    cNew.Addamount(1000.0);
                    csv.Customers.Add(cNew);
                    csv.WriteCSV();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            //}
            #endregion
            //#region test1
            //    List<Customer> customers = new List<Customer>();

            //    //Neuen Kunden erstellen
            //    Customer c1 = null;

            //    while (c1 == null)
            //    {
            //        try
            //        {
            //            c1 = new Customer(csv.Customers.Count,
            //            "Johannes",
            //            "Hirsch",
            //            "johannes.hirsch@aon.at");

            //            csv.Customers.Add(c1);

            //            //Console.WriteLine(customers[0].FirstName);
            //            //Console.WriteLine(customers[0].ID);
            //        }
            //        catch (InvalidOperationException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //    }

            //    //Neuen Kunden erstellen
            //    Customer c2 = null;

            //    while (c2 == null)
            //    {
            //        try
            //        {
            //            c2 = new Customer(csv.Customers.Count,
            //            "Matthias",
            //            "Hirsch",
            //            "matthias.hirsch@aon.at");

            //            csv.Customers.Add(c2);
            //            csv.WriteCSV();

            //            //Console.WriteLine(customers[1].FirstName);
            //            //Console.WriteLine(customers[1].ID);
            //        }
            //        catch (InvalidOperationException e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //    }
            //#endregion
        }

    }
}
