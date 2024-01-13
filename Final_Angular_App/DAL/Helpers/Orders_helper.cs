using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.Helpers
{
    public class Orders_helper
    {

        public List<Models.Orders> select_with_procedure(string startDate, string endData)
        {
            List<Models.Orders> orders_list = new List<Models.Orders>();
            SqlConnection con = General_helper.GetSqlConnection();
            SqlCommand command = new SqlCommand("USP_OrdersReport", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@startDate", startDate);
            command.Parameters.AddWithValue("@endDate", endData);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            foreach (var item in table.AsEnumerable())
            {
                Models.Orders dept_temp = new Models.Orders()
                {
                    Id = item.Field<int>("OrderId"),
                    CustomerName = item.Field<string>("CustomerName"),
                    OrderDate = item.Field<string>("OrderDate"),
                    ProductName = item.Field<string>("ProductName"),
                    Quantity = item.Field<int>("Quantity"),
                    Price = item.Field<int>("Price"),
                    Total = item.Field<int>("Total"),
                };
                orders_list.Add(dept_temp);
            }

            return orders_list;

        }
     
    }
}
