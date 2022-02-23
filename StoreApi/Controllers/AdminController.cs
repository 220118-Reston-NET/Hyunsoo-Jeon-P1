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
        public AdminController(IInventoryBL p_inventoryBL, IOrderBL p_orderBL)
        {
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
        }

        // GET: api/Admin
        [HttpGet("OrderHistory")]
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
