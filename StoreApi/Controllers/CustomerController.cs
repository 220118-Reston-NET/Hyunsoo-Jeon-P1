using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerBL _customerBL;
        public CustomerController(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        

        // GET: api/Customer
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {

            try
            {
                return Ok(await _customerBL.GetAllCustomerAsync());

            }
            catch (System.Exception)
            {
                
                return NotFound();
            }
        }

        // GET: api/Customer/5
        [HttpGet("{customerName}")]
        public async Task<IActionResult> SearchCustomerByName(string customerName)
        {
            try
            {
                return Ok(_customerBL.SearchCustomerByName(customerName));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromBody] Customer p_customer)
        {
            try
            {
                return Created("Successfully added", _customerBL.AddCustomer(p_customer));
            }
            catch (System.Exception ex)
            {
                
                return Conflict(ex.Message);
            }
        }

        // PUT: api/Customer/5
        [HttpPut("Update/{id}")]
        public void Update(int id, [FromBody] string p_customer)
        {

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
