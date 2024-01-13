using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using Models;


namespace DAL
{
    public class DataOperations
    {
        private readonly AlohaTrainingEntities1 dbContext;
        private readonly Orders_helper orders_helper;
        public DataOperations()
        {
            dbContext = new AlohaTrainingEntities1();
            orders_helper = new Orders_helper();
        }
        public List<CustomerAddressModel> GetAllCustomers()
        {
            var Customers_List = (from customer in dbContext.Customers
                                  join address in dbContext.Addresses on customer.Id equals address.CustomerId
                                  join type in dbContext.Types on customer.Type equals type.Id
                                  join gender in dbContext.Genders on customer.Gender equals gender.Id
                                  join department in dbContext.Departments on customer.Department equals department.Id
                                  join state in dbContext.States on address.StateId equals state.Id
                                  join city in dbContext.Cities on address.CityId equals city.Id
                                  join area in dbContext.Areas on address.AreaId equals area.Id

                                  select new CustomerAddressModel
                                  {
                                      Id = customer.Id,
                                      Name = customer.Name,
                                      Type = type.Name,
                                      Gender = gender.Name,
                                      Department = department.Name,
                                      State = state.Name,
                                      City = city.Name,
                                      Area = area.Name,
                                      ZipCode = address.ZipCode

                                  }).ToList();
            return Customers_List;
        }
        public CustomerAddressModel GetCustomerByIdInString(int id)
        {
            var result = (from customer in dbContext.Customers
                          join address in dbContext.Addresses on customer.Id equals address.CustomerId
                          join type in dbContext.Types on customer.Type equals type.Id
                          join gender in dbContext.Genders on customer.Gender equals gender.Id
                          join department in dbContext.Departments on customer.Department equals department.Id
                          join state in dbContext.States on address.StateId equals state.Id
                          join city in dbContext.Cities on address.CityId equals city.Id
                          join area in dbContext.Areas on address.AreaId equals area.Id
                          where customer.Id == id
                          select new CustomerAddressModel
                          {
                              Id = customer.Id,
                              Name = customer.Name,
                              Type = type.Name,
                              Gender = gender.Name,
                              Department = department.Name,
                              State = state.Name,
                              City = city.Name,
                              Area = area.Name,
                              ZipCode = address.ZipCode

                          }).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return new CustomerAddressModel();
            }
        }
        public CustomerAddressModel GetCustomerById(int id)
        {

            var result = (from customer in dbContext.Customers
                          join address in dbContext.Addresses on customer.Id equals address.CustomerId
                          join type in dbContext.Types on customer.Type equals type.Id
                          join gender in dbContext.Genders on customer.Gender equals gender.Id
                          join department in dbContext.Departments on customer.Department equals department.Id
                          join state in dbContext.States on address.StateId equals state.Id
                          join city in dbContext.Cities on address.CityId equals city.Id
                          join area in dbContext.Areas on address.AreaId equals area.Id
                          where customer.Id == id
                          select new CustomerAddressModel
                          {
                              Id = customer.Id,
                              Name = customer.Name,
                              Type = type.Id.ToString(),
                              Gender = gender.Id.ToString(),
                              Department = department.Id.ToString(),
                              State = state.Id.ToString(),
                              City = city.Id.ToString(),
                              Area = area.Id.ToString(),
                              ZipCode = address.ZipCode

                          }).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return new CustomerAddressModel();
            }
        }
        public string DeleteCustomerById(int id)
        {
            var address = dbContext.Addresses.Where(x => x.CustomerId == id).FirstOrDefault();
            var cusomter = dbContext.Customers.Find(address.CustomerId);
            dbContext.Addresses.Remove(address);
            dbContext.Customers.Remove(cusomter);
            dbContext.SaveChanges();
            return "Deleted Successfully";
        }

        public string ManageCustomer(CustomerAddressModel CustomerAddress)
        {

            if (CustomerAddress.Id == 0)
            {
                //insert
                Customer customer = new Customer()
                {
                    Name = CustomerAddress.Name,
                    Type = Convert.ToInt32(CustomerAddress.Type),
                    Gender = Convert.ToInt32(CustomerAddress.Gender),
                    Department = Convert.ToInt32(CustomerAddress.Department),
                };
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                Address address = new Address()
                {
                    StateId = Convert.ToInt32(CustomerAddress.State),
                    CityId = Convert.ToInt32(CustomerAddress.City),
                    AreaId = Convert.ToInt32(CustomerAddress.Area),
                    ZipCode = CustomerAddress.ZipCode,
                    CustomerId = customer.Id
                };
                dbContext.Addresses.Add(address);
                dbContext.SaveChanges();

                return "Insert Successfull";
            }
            else
            {
                //update
                Customer existingCustomer = dbContext.Customers.Find(CustomerAddress.Id);

                if (existingCustomer != null)
                {
                    existingCustomer.Name = CustomerAddress.Name;
                    existingCustomer.Type = Convert.ToInt32(CustomerAddress.Type);
                    existingCustomer.Gender = Convert.ToInt32(CustomerAddress.Gender);
                    existingCustomer.Department = Convert.ToInt32(CustomerAddress.Department);

                    dbContext.Entry(existingCustomer).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }

                var existingAddress = dbContext.Addresses.Where(x => x.CustomerId == CustomerAddress.Id).FirstOrDefault();

                if (existingAddress != null)
                {
                    existingAddress.StateId = Convert.ToInt32(CustomerAddress.State);
                    existingAddress.CityId = Convert.ToInt32(CustomerAddress.City);
                    existingAddress.AreaId = Convert.ToInt32(CustomerAddress.Area);
                    existingAddress.ZipCode = CustomerAddress.ZipCode;

                    dbContext.Entry(existingAddress).State = EntityState.Modified;
                    dbContext.SaveChanges();
                }

                return "Update Successfull";
            }
        }

        public List<Models.City> GetCities(int id)
        {
            List<Models.City> result = (from c in dbContext.Cities
            where c.StateId == id
                                        select new Models.City
                                        {
                                            Id = c.Id,
                                            Name = c.Name,
                                            StateId = c.StateId,
                                        }).ToList();

            return result;
        }
        public List<Models.Area> GetAreas(int id)
        {
            List<Models.Area> result = (from a in dbContext.Areas
                                        where a.CityId == id
            select new Models.Area
                                        {
                                            Id = a.Id,
                                            Name = a.Name,
                                        }).ToList();


            return result;
        }

        public List<Models.State> GetStates()
        {
            List<Models.State> result = (from state in dbContext.States
            select new Models.State
                                         {
                                             Id = state.Id,
                                             Name = state.Name,

                                         }).ToList();

            return result;
        }
        public List<Models.Gender> GetGenders()
        {
            List<Models.Gender> result = (from gender in dbContext.Genders
                                          select new Models.Gender
                                          {
                                              Id = gender.Id,
                                              Name = gender.Name,
                                          }).ToList();

            return result;
        }
        public List<Models.Department> GetDepartments()
        {
            List<Models.Department> result = (from department in dbContext.Departments
                                              select new Models.Department
                                              {
                                                  Id = department.Id,
                                                  Name = department.Name,
                                              }).ToList();

            return result;
        }
        public List<Models.Type> GetTypes()
        {
            List<Models.Type> result = (from type in dbContext.Types
                                        select new Models.Type
                                        {
                                            Id = type.Id,
                                            Name = type.Name,
                                        }).ToList();

            return result;
        }
        public List<Models.Product> GetProducts()
        {
            List<Models.Product> result = (from product in dbContext.products
                                        select new Models.Product
                                        {
                                            Id = product.Id,
                                            Name = product.Name,
                                            price = (int)product.price
                                        }).ToList();

            return result;
        }

        public List<Models.Users> GetUsers()
        {
            List<Models.Users> result = (from user in dbContext.users
                                           select new Models.Users
                                           {
                                               Id= user.Id,
                                               Email = user.Email,
                                               Password = user.Password,
                                               PhoneNumber  = user.PhoneNumber,
                                               UserName = user.UserName
                                               
                                           }).ToList();

            return result;
        }

        public List<Models.Orders> GetOrders()
        {
            List<Models.Orders> result = (from order in dbContext.Orders
                                          join pr in dbContext.products on order.ProductId equals pr.Id
                                          join customer in dbContext.Customers on order.CustomerId equals customer.Id
                                          select new Models.Orders
                                          {
                                             Id = order.Id,
                                             CustomerName = customer.Name,
                                             OrderDate = order.OrderDate,
                                             ProductName = pr.Name,
                                             Quantity = order.Quantity,
                                             Price = order.Price,
                                             Total = order.Total,
                                          }).ToList();

            return result;
        }
        public string InsertUser(Models.Users data)
        {

                //insert
                user newUser = new user()
                {
                   UserName = data.UserName,
                   Email = data.Email,
                   Password = data.Password,
                  PhoneNumber = data.PhoneNumber

                };
                dbContext.users.Add(newUser);
                dbContext.SaveChanges();

             

                return "User Insert Successfull";
            
        }
        public string InsertOrder(Models.Orders data)
        {

            //insert
            Order newOrder = new Order()
            {
                OrderDate = data.OrderDate,
                Price= data.Price,
                Quantity = data.Quantity,
                Total = data.Total,
                ProductId = Convert.ToInt32(data.ProductName),
                CustomerId = Convert.ToInt32(data.CustomerName)

            };
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();



            return "Order Insertion Successfull";

        }
        public string ValidateUser(Models.Users data)
        {
            var result = (from userrr in dbContext.users
                          
                          where userrr.UserName == data.UserName && userrr.Password == data.Password
                          select userrr
                          ).FirstOrDefault();

            if(result == null)
            {
                return "not valid";
            }

            return "valid";
        }
        public List<Models.Orders> GetOrdersReport(string startDate, string endData)
        {
            return orders_helper.select_with_procedure( startDate,  endData);
        }
    }
}
