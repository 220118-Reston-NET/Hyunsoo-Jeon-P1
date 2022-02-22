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
        private IOrderBL _orderBL;
        public CustomerController(ICustomerBL p_customerBL, IOrderBL p_orderBL)
        {
            _customerBL = p_customerBL;
            _orderBL = p_orderBL;
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
        [HttpGet]
        public IActionResult SearchCustomerByName([FromQuery] string customerName)
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

        // GET: api/Customer/5
        // [HttpGet("{id}")]
        // public IActionResult SearchCustomerById(int p_customerID)
        // {
        //     try
        //     {
        //         return Ok(_customerBL.GetCustomerByCustomerID(p_customerID));
        //     }
        //     catch (System.Exception)
        //     {

        //         return NotFound();
        //     }
        // }


        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            try
            {
                return Created("Successfully added", _customerBL.AddCustomer(customer));
            }
            catch (System.Exception ex)
            {
                
                return Conflict(ex.Message);
            }
        }

        // PUT: api/Customer/5
        [HttpPut("Update/{id}")]
        public void Update(int id, [FromBody] string customer)
        {

        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST: api/Order
        // [HttpPost("AddOrder")]
        // public IActionResult AddOrder([FromBody] Order p_order)
        // {
        //     try
        //     {
        //         return Created("Successfully added Order", _orderBL.PlaceOrder(p_order));
        //     }
        //     catch (System.Exception ex)
        //     {

        //         return Conflict(ex.Message);
        //     }
        // }

        [HttpGet("Order/{id}")]
        public IActionResult SearchCustomerOrderByCustomerId(int p_customerID)
        {
            try
            {
                return Ok(_orderBL.GetAllOrdersByID(p_customerID));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }
    }
}
