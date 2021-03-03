using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DbContextCustomer;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;

namespace WebApplication1.Controllers
{
    // CORS - Cross-Origin Resource Sharing
    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {
        CustomerDbContext custDbContext = null;
        public CustomerController(CustomerDbContext _custDbContext,
                                  IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }

        int i = 0;
        public IActionResult AddScreen() // Displays the Add Screen
        {
            // get the current value
            if (HttpContext.Session.GetInt32("variableI") != null)
            {
                i = (int) HttpContext.Session.GetInt32("variableI");
            }
            // do your operation
            i++;
            // send to the browser to store it in cookies
            HttpContext.Session.SetInt32("variableI", i);

            return View("CustomerAdd", new CustomerViewModel()); // CustomerViewModel is null
        }

        public IActionResult SearchScreen() // Displays the Search Screen
        {
            return View("DisplayCustomer");
        }

        public IActionResult Search(string customerName) // Executes the Search Query
        {
            // we are using the 'new' keyword to create the object
            List<Customer> custs = (from temp in custDbContext.Customers
                                    where temp.customerName == customerName 
                                    select temp).ToList<Customer>();
            return View("DisplayCustomer", custs);
        }

        //public IActionResult Add([FromBody] Customer obj) // Adds to Db using EF Core
        //{
        //    //Customer obj = new Customer();
        //    //obj.customerName = Request.Form["txtcustomerName"];
        //    //obj.address = Request.Form["txtaddress"];

        //    // we would need to check validation
        //    var context = new ValidationContext(obj);
        //    var errorResult = new List<ValidationResult>();

        //    // check only happens in the controller
        //    var check = Validator.TryValidateObject(obj,
        //                                            context,
        //                                            errorResult, true);

        //    //if (ModelState.IsValid) // not recommended to use ModelState.IsValid
        //                              // as it fails under complex situations
        //    if (check)
        //    {
        //        // adding data record
        //        custDbContext.Customers.Add(obj);
        //        custDbContext.SaveChanges();

        //        // get all the data records from table and load to the list
        //        // select call to the table
        //        List<Customer> custs = custDbContext.Customers.ToList<Customer>();
        //        //return View("DisplayCustomer", custs);
        //        return StatusCode(StatusCodes.Status200OK, custs);
        //    }
        //    else
        //    {
        //        CustomerViewModel custvm = new CustomerViewModel();
        //        custvm.customer = obj;
        //        custvm.errors = errorResult;
        //        //return View("CustomerAdd", custvm);
        //        return StatusCode(StatusCodes.Status500InternalServerError, errorResult);
        //    }
        //}
    }
}
