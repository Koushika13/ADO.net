using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace PrjAdo.NetEg
{
    class DAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public SqlConnection GetConnection()
        {
            con = new SqlConnection(
                    "Data Source = DESKTOP-IM16U2B;Initial Catalog = Northwind; Integrated Security = true ");
            con.Open();
            return con;
        }

        public void DisplayRegion()
        {
            con = GetConnection();

            SqlDataAdapter da; //connects sql server database to our database
            da = new SqlDataAdapter(" select * from Region", con);
            DataSet ds = new DataSet(); //collection of tables

            //putting the table inside the dataset
            da.Fill(ds, "NWREGION");


            //reading the table info from dataset

            DataTable dt;
            dt = ds.Tables["NWREGION"];

            foreach(DataRow row in dt.Rows)
            {
                foreach(DataColumn col in dt.Columns)
                {
                    Console.Write(row[col]);
                    Console.Write(" ");

                }


            }

            //adding one more table to dataset: shipper

           /* Console.WriteLine("----------------------------");
            Console.WriteLine("------Shipper Table--------");
            da = new SqlDataAdapter("Select * from Shippers", con);
            da.Fill(ds, "NWSHIPPER");

            DataTable dt1 = ds.Tables["NWSHIPPER"];

            foreach(DataRow row in dt1.Rows)
            {
                foreach(DataColumn col in dt1.Columns)
                {
                    Console.Write(row[col]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
           */
            //Inserting new row in region table in dataset

            //Insert Delete update operation
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            da.Fill(ds);

            //Inserting or adding a new row
            //creating a new row in NWREGION in dataset

            DataRow row1 = ds.Tables["NWREGION"].NewRow();
            row1["RegionID"] = 15;
            row1["RegionDescription"] = "BBBBBBB";
            //Adding row to datatable in dataset
            ds.Tables["NWREGION"].Rows.Add(row1);

            da.Update(ds, "NWREGION"); // updates in sql server also 
            
            Console.WriteLine("----------------------");

            dt = ds.Tables["NWREGION"];
            foreach (DataRow datarow in dt.Rows)
            {
                foreach (DataColumn datacol in dt.Columns)
                {
                    Console.Write(datarow[datacol]);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }


        }
        
    }
    class DisconnectedArchitecture
    {
        static void Main()
        {
            DAL dalobj = new DAL();
            dalobj.DisplayRegion();
        }
    }
}
