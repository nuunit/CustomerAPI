using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerInquiry.Models;
using CustomerInquiry.Requests;
using CustomerInquiry.Helper;

namespace CustomerInquiry.Controllers
{
    public class CustomersController : ApiController
    {

        private ICustomerInquiry db = new CustomerInquiryContext();
        public CustomersController()
        {

        }

        public CustomersController(ICustomerInquiry context)
        {
            db = context;
        }


        // GET: api/Customers
        public IQueryable<Customer> GetCustomers()
        {
            return db.Customers;
        }



        [ResponseType(typeof(Customer))]
        public IHttpActionResult SearchCustomer(CustomerRequest customerRequest)
        {

            if (customerRequest == null)
            {
                return BadRequest("No inquiry criteria");
            }
            if (customerRequest.Id.ToString().Length > 10)
            {
                return BadRequest("Invalid Customer ID");
            }
            if (!Utilities.IsValidEmail(customerRequest.Email))
            {
                return BadRequest("Invalid Email");
            }
            Customer customer = null;
            if (string.IsNullOrEmpty(customerRequest.Id.ToString()) && string.IsNullOrEmpty(customerRequest.Email))
            {
                customer = db.Customers.Include(x => x.Transactions).Where(x => x.Id == customerRequest.Id && x.Email == customerRequest.Email).SingleOrDefault();

            }
            else
            {
                customer = db.Customers.Include(x => x.Transactions).Where(x => x.Id == customerRequest.Id | x.Email == customerRequest.Email).SingleOrDefault();

            }

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.Id == id) > 0;
        }
    }
}