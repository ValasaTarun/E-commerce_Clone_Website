using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BussinessLogic
    {
        private readonly DataOperations operations;
        public BussinessLogic()
        {
            operations = new DataOperations();
        }
        public List<CustomerAddressModel> GetAllCustomers()
        {
            return operations.GetAllCustomers();
        }
        public CustomerAddressModel GetCustomerById(int id)
        {
            return operations.GetCustomerById(id);
        }
        public CustomerAddressModel GetCustomerByIdInString(int id)
        {
            return operations.GetCustomerByIdInString(id);
        }
        public string DeleteCustomerById(int id)
        {
            return operations.DeleteCustomerById(id);
        }
        public string ManageCustomer(CustomerAddressModel customer)
        {
            return operations.ManageCustomer(customer);
        }
        public List<Models.City> GetCities(int id)
        {
            return operations.GetCities(id);
        }
        public List<Models.Area> GetAreas(int id)
        {
            return operations.GetAreas(id);
        }

        public List<Models.Gender> GetGenders()
        {

            return operations.GetGenders();

        }
        public List<Models.Department> GetDepartments()
        {

            return operations.GetDepartments();

        }
        public List<Models.State> GetStates()
        {

            return operations.GetStates();

        }
        public List<Models.Type> GetTypes()
        {
            return operations.GetTypes();
        }
        public List<Models.Product> GetProducts()
        {
            return operations.GetProducts();
        }
        public List<Models.Orders> GetOrders()
        {
            return operations.GetOrders();
        }
        public string InsertUser(Models.Users data)
        {
            return operations.InsertUser(data);
        }
        public string InsertOrder(Models.Orders data)
        {
            return operations.InsertOrder(data);
        }
        public string ValidateUser(Models.Users data)
        {
            return operations.ValidateUser(data);
        }
        public List<Models.Orders> GetOrdersReport(string startDate, string endData)
        {
            return operations.GetOrdersReport( startDate,  endData);
        }
        public List<Models.Users> GetUsers()
        {
            return operations.GetUsers();
        }
    }
}
