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
        

        

        [HttpGet("OrderHistory")]
        public IActionResult GetAllOrdersByCustomerID([FromQuery] int customerID)
        {
            try
            {
                return Ok(_orderBL.GetAllOrdersByCustomerID(customerID));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                return Created("Successfully added", _orderBL.AddOrder(order));
            }
            catch (System.Exception ex)
            {

                return Conflict(ex.Message);
            }
        }
    }
}

