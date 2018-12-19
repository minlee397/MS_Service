using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QL_DT.DAL;
using QL_DT.Models;

namespace QL_DT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Detail_ReceiptController : Controller
    {
        private readonly _QL_DTContext _DTContext;
        public Detail_ReceiptController(_QL_DTContext DTContext){
            _DTContext = DTContext;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var model = _DTContext.Detail_Receipts.ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetail_Receipt(int ID){
            var model = _DTContext.Detail_Receipts.Where(c=>c.ID==ID).FirstOrDefault();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Detail_Receipt model){
            var product_update = _DTContext.Products.Find(model.Product_ID);
            if(product_update !=null){
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _DTContext.Detail_Receipts.Add(model);
                _DTContext.SaveChanges();
                
                // Dong thoi cap nhat so luong trong bang product                        
                product_update.Quantity += model.Quantity;
                _DTContext.SaveChanges();
            }

            return Ok(model);
        }

        [HttpPut]
        public IActionResult Update(int ID, [FromBody]Detail_Receipt model){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var detail_receipt = _DTContext.Detail_Receipts.Find(ID);
            if(detail_receipt == null)
                return NotFound();

            _DTContext.Entry(detail_receipt).CurrentValues.SetValues(model);
            _DTContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int ID)
        {
            var detail_receipt = _DTContext.Detail_Receipts.Find(ID);
            if(detail_receipt == null)
                return NotFound();

            _DTContext.Remove(detail_receipt);
            _DTContext.SaveChanges();

            return Ok(detail_receipt);
        }
    }
}