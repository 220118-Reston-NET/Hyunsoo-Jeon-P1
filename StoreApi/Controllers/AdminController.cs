using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL;
using DL;
using Models;

namespace StoreApi.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private IInventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        private ICustomerBL _customerBL;
        public AdminController(IInventoryBL p_inventoryBL, IOrderBL p_orderBL, ICustomerBL p_customerBL)
        {
            _inventoryBL = p_inventoryBL;
            _orderBL = p_orderBL;
            _customerBL = p_customerBL;
        }

        // GET: api/Customer
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomerAsync()
        {

            try
            {
                Log.Information("Get All customers");

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
                Log.Information("Search by customer name " + customerName);
                return Ok(_customerBL.SearchCustomerByName(customerName));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("OrderHistoryByStore")]
        public IActionResult GetAllOrdersByStoreId([FromQuery] int storeId)
        {
            try
            {
                Log.Information("Get All orders by store Id");
                return Ok(_orderBL.GetAllOrdersByStoreID(storeId));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("OrderDetails")]
        public IActionResult GetOrderByorderID([FromQuery] int orderID)
        {
            try
            {
                Log.Information("Get all orders by order id");
                return Ok(_orderBL.GetAllOrder().Find(p => p.OrderID == orderID));
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
                Log.Information("Get All inventory detail in store by id " + storeId);
                return Ok(_inventoryBL.GetAllInventoryDetailInStoreByID(storeId));
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }


        [HttpPut("ReplenishInventory")]
        public IActionResult ReplenishInventory(int p_inventoryId, int p_qty)
        {   
            try
            {
                Log.Information("Replenish invetory");
                _inventoryBL.ReplenishInventory(p_inventoryId, p_qty);
                return Ok();
            }
            catch (System.Exception)
            {

                return NotFound();
            }
        }

        }
    }
