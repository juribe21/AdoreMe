using com.ams.pistola.models.DTO;
using com.ams.pistola.data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using com.ams.pistola.models;
using com.ams.pistola.api.Classes;
using EFCore.BulkExtensions;

namespace com.ams.pistola.api.Controllers {

 [HttpPost]
        [Route("api/returns/item")]
        public AmTReturnedItem returnItem([FromBody] ReturnedItemDTO item) 
        {

            var ri = new AmTReturnedItem() {
                OrderNumber = item.orderNumber,
                RmaNumber = item.rmaNumber,
                Condition = item.condition,
                ItemNumber = item.itemNumber,
                EmployeeId = item.employeeId,
                Quantity = item.quantity,
                Rts = (item.rts == true) ? "Y" : "N",
                ReturnDate = DateTime.Now,
                RtsReason = item.rtsReason
            };
            _context.AmTReturnedItem.Add(ri);
            _context.SaveChanges();
            return _context.AmTReturnedItem.Where(w => w.Id == ri.Id).FirstOrDefault();
        }
}