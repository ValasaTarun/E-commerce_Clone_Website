using BL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_Layer_Final.Controllers
{
    [RoutePrefix("Api/Customers")]
    public class WebApiController : ApiController
    {
        private readonly BussinessLogic customerBl;
        public WebApiController()
        {
            customerBl = new BussinessLogic();
        }
        [Route("GetAllCustomers")]
        public List<CustomerAddressModel> GetAllCustomers()
        {
            return customerBl.GetAllCustomers();
        }
        [Route("GetCustomerById/{id}")]
        public CustomerAddressModel GetCustomerById(int id)
        {
            return customerBl.GetCustomerById(id);
        }
        [Route("GetCustomerByIdInString/{id}")]
        public CustomerAddressModel GetCustomerByIdInString(int id)
        {
            return customerBl.GetCustomerByIdInString(id);
        }
        [HttpGet]
        [Route("DeleteCustomer/{id}")]
        public string Delete(int id)
        {
            return customerBl.DeleteCustomerById(id);
        }
        [HttpPost]
        [Route("ManageCustomers")]
        public string ManageCustomer(CustomerAddressModel customer)
        {
            return customerBl.ManageCustomer(customer);
        }
        [Route("GetAllStates")]
        public List<Models.State> GetAllStates()
        {
            return customerBl.GetStates();
        }
        [Route("GetCityById")]
        public List<Models.City> GetCities(int id)
        {
            return customerBl.GetCities(id);
        }
        [Route("GetAreaById")]
        public List<Models.Area> GetAreas(int id)
        {
            return customerBl.GetAreas(id);
        }
        [Route("GetAllGenders")]
        public List<Models.Gender> GetGenders()
        {

            return customerBl.GetGenders();

        }
        [Route("GetAllDepartments")]
        public List<Models.Department> GetDepartments()
        {

            return customerBl.GetDepartments();

        }
        [Route("GetAllTypes")]
        public List<Models.Type> GetTypes()
        {
            return customerBl.GetTypes();
        }
        [Route("GetAllProducts")]
        public List<Models.Product> GetProducts()
        {
            return customerBl.GetProducts();
        }
        [Route("GetAllOrders")]
        public List<Models.Orders> GetOrders()
        {
            return customerBl.GetOrders();
        }
        [HttpPost]
        [Route("InsertUser")]
        public string InsertUser(Models.Users data)
        {
            return customerBl.InsertUser(data);
        }
        [HttpPost]
        [Route("InsertOrder")]
        public string InsertOrder(Models.Orders data)
        {
            return customerBl.InsertOrder(data);
        }
        //[Route("TestForPost")]
        //public string Test(Models.State state)
        //{
        //    return state.Id + " -- " + state.Name;
        //}
        [Route("ValidateUser")]
        public string ValidateUser(Models.Users data)
        {
            return customerBl.ValidateUser(data);
        }
        [Route("GetOrdersReport")]
        public List<Models.Orders> GetOrdersReport(string startDate , string endData)
        {
            return customerBl.GetOrdersReport( startDate,  endData);
        }
        [Route("GetAllUsers")]
        public List<Models.Users> GetUsers()
        {
            return customerBl.GetUsers();
        }

    }
}
