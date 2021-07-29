using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjAdo.NetEg
{
    class ClientProcedure
    {
        static void Main()
        {
            DataAccessLayer data = new DataAccessLayer();

            Console.WriteLine("\nChoose one of the option:\n" +
                    "1. Display Ten Most Expensive Product\n" +
                    "2. Display Order Date\n");
            int response = Convert.ToInt32(Console.ReadLine());
            switch (response)
            {
                case 1:
                    data.CallTenMostExpensiveProduct();
                    break;
                case 2:
                    Console.WriteLine("Enter customer id");
                    string Cid = Console.ReadLine();
                    Console.WriteLine("----------------------------------");
                    data.CallCustOrderOrders(Cid);
                    break;
                default:
                    Console.WriteLine("Please enter either 1 or 2");
                    break;
            }
        }
    }
}
