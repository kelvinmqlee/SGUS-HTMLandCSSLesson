using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DbContextCustomer;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        CustomerDbContext custDbContext = null;
        public CustomerAPIController(CustomerDbContext _custDbContext,
                                  IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }

        // GET: api/<CustomerAPIController>
        [HttpGet]
        public IActionResult Get() // load all customers
        {
            List<Customer> custs = custDbContext.Customers
                                                .Include(p => p.products)
                                                .ToList<Customer>();
            return Ok(custs);
        }

        // GET api/<CustomerAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer obj)
        {
            // we would need to check validation
            var context = new ValidationContext(obj);
            var errorResult = new List<ValidationResult>();

            // check only happens in the controller
            var check = Validator.TryValidateObject(obj,
                                                    context,
                                                    errorResult, true);

            //if (ModelState.IsValid) // not recommended to use ModelState.IsValid
            // as it fails under complex situations
            if (check)
            {
                // adding data record
                custDbContext.Customers.Add(obj);
                custDbContext.SaveChanges();

                // get all the data records from table and load to the list
                // select call to the table
                List<Customer> custs = custDbContext.Customers
                                                    .Include(p => p.products)
                                                    .ToList<Customer>();
                //return View("DisplayCustomer", custs);
                return Ok(custs);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, errorResult);
            }
        }

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
