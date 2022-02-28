using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;
using Models;

namespace StoreApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private IInventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        private ICustomerBL _customerBL;
        public AdminController(IInventoryBL p_inventoryBL, IOrderBL p_orderBL, CustomerBL p_customerBL)
        {
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
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
        [HttpGet("SearchCustomerByName")]
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

        // POST: api/Customer
        [HttpPost("AddCustomer")]
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

        // GET: api/Admin
        [HttpGet("OrderHistoryByStore")]
        public IActionResult GetAllOrdersByStoreId([FromQuery] int storeId)
        {
            try
            {
                return Ok(_orderBL.GetAllOrdersByStoreID(storeId));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("StoreInventory")]
        public IActionResult GetAllInventoryByStoreId([FromQuery] int storeId)
        {
            try
            {
                return Ok(_inventoryBL.GetAllInventoryDetailInStoreByID(storeId));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

            // GET: api/Admin/5
            // [HttpGet("{id}", Name = "Get")]
            // public string Get(int id)
            // {
            //     return "value";
            // }

            // POST: api/Admin
            // [HttpPost]
            // public void Post([FromBody] string value)
            // {
            // }

            // PUT: api/Admin/5
            // [HttpPut("{id}")]
            // public void Put(int id, [FromBody] string value)
            // {
            // }

            // DELETE: api/Admin/5
            // [HttpDelete("{id}")]
            // public void Delete(int id)
            // {
            // }
        }
    }
