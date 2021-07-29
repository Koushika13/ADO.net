using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PrjAdo.NetEg
{

    class DataAccessLayer
    {
        SqlConnection con = null;
    SqlCommand cmd = null;

    public SqlConnection GetConnection()
    {
        con = new SqlConnection("Data Source = DESKTOP-IM16U2B; Initial Catalog = Northwind; Integrated Security = true");
        con.Open();
        return con;
    }

    // Stored Procedure without Parameter
    internal void CallTenMostExpensiveProduct()
    {
        try
        {
            con = GetConnection();
            //Procedure name is sql server
            cmd = new SqlCommand("Ten Most Expensive Product", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr[0] + " " + dr[1]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            con.Close();
        }
    }

    internal void CallCustOrderOrders(string cid)
    {
        try
        {
            con = GetConnection();
            cmd = new SqlCommand("CustOrdersOrders", con);
            cmd.CommandType = CommandType.StoredProcedure; //to identify that cmd is a stored procedure
            cmd.Parameters.AddWithValue("@CustomerID", cid);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine(dr["OrderID"] + " " + dr["OrderDate"] + " " + dr["ShippedDate"]);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            con.Close();
        }
    }
}

class StoredProcedure_Example
{
    //static void Main()
    //{
    //    DataAccessLayer data = new DataAccessLayer();
    //    data.CallTenMostExpensiveProduct();
    //    Console.WriteLine("----------------------------------");
    //    Console.WriteLine("Enter customer id");
    //    string Cid = Console.ReadLine();
    //    Console.WriteLine("----------------------------------");
    //    data.CallCustOrderOrders(Cid);
    //}
}
}

