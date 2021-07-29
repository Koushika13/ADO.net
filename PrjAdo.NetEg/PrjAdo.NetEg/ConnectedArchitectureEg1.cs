using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //1.Install the package

namespace PrjAdo.NetEg
{
    class Shipper
    {
        public int ShipperId { get; set; }
        public string Companyname { get; set; }
        public string phone { get; set; }

        #region GetShipper

        public void GetShipper()
        {
            Console.WriteLine("Enter the Shippername or CompanyName");
            Companyname = Console.ReadLine();
            Console.WriteLine("Enter the Phone number");
            phone = Console.ReadLine();
        }
        #endregion

        public void LooseShipper()
        {
            Console.WriteLine("Enter the Shippername or CompanyName");
            Companyname = Console.ReadLine();
        }

        public void EditShipper()
        {
            Console.WriteLine("Enter the Shipper Id");
            ShipperId = Convert.ToInt32(Console.ReadLine());
            
            GetShipper();
        }
    }
    class ConnectedArchitectureEg1
    {
        static void Main()
        {
            //2.create sqlconnection object
            SqlConnection con = null;

            //creating command object
            SqlCommand cmd = null;

            try
            {
                //3.Windows Authentication
                con = new SqlConnection(
                    "Data Source = DESKTOP-IM16U2B;Initial Catalog = Northwind; Integrated Security = true ");

                /*con = new SqlConnection(
                "Data Source = DESKTOP-U8J1M3C\\MSSQLSERVER01; Initial Catalog = Northwind; Integrated Security = true");*/

                //Sql server authentication
                // con = new SqlConnection(
                // "Data Source= DESKTOP-U8J1M3C\\MSSQLSERVER01;Initial Catalog=Northwind;User ID=sa;Password=newuser123#");

                //4
                con.Open();
                
                //creating object of shipper class
               Shipper shipper = new Shipper();


                //Insertion

                //calling getshipper method

                /*  shipper.GetShipper();
                  cmd = new SqlCommand("insert into Shippers(CompanyName,Phone) values (@cname,@phone)", con);
                  cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                  cmd.Parameters.AddWithValue("@phone", shipper.phone);
                  int j = cmd.ExecuteNonQuery(); //returns int
                  Console.WriteLine("No of Rows Affected :{0}", j);*/

                //Deletion
                //Calling Loose ShipperMethod
                shipper.LooseShipper();
                cmd = new SqlCommand("delete from Shippers where CompanyName = @cname", con);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                int k = cmd.ExecuteNonQuery(); //returns int
                Console.WriteLine("No of Rows deleted:{0}", k);
                cmd.Parameters.Clear(); 

                //Select

               /* SqlDataReader dr;

                cmd = new SqlCommand("select * from Shippers", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2]);
                    Console.WriteLine(dr["CompanyName"] + " " + dr["Phone"]);


                }*/

                //update
                
               /* #region ShipperUpdate

                shipper.EditShipper();

                cmd = new SqlCommand("update Shippers set CompanyName = @cname, phone = @phone where ShipperId = @id",con);
                cmd.Parameters.AddWithValue("@id", shipper.ShipperId);
                cmd.Parameters.AddWithValue("@cname", shipper.Companyname);
                cmd.Parameters.AddWithValue("@phone", shipper.phone);

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No of rows updated is {0}", i);
                #endregion
               */

                //update in Region table from NorthwindDatabase
                //Scalar value

                //cmd = new SqlCommand("select count(ShipperId) from Shippers", con);
                //Console.WriteLine("Total shipper : {0}", Convert.ToInt32(cmd.ExecuteScalar()));
                

                
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }

            }
        }

    }

