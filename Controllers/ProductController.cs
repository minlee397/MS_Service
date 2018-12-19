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
    public class ProductController : ControllerBase
    {
        private readonly _QL_DTContext _DTContext;        
        public ProductController (_QL_DTContext DTContext){
            _DTContext = DTContext;

            /* Tu dong khoi tao du lieu khi trong database chua co du lieu gi ca
            _DT_init.SeedData(DTContext);   */         
        }

        [HttpGet]
        public IActionResult GetAll(){
            var model = _DTContext.Products.ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int ProductId){
            var model = _DTContext.Products.Where(c=>c.ProductID==ProductId).FirstOrDefault();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Product model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _DTContext.Products.Add(model);
            _DTContext.SaveChanges();
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product model){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = _DTContext.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }            
            _DTContext.Entry(product).CurrentValues.SetValues(model);
            _DTContext.SaveChanges();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var product = _DTContext.Products.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            else
            {
                _DTContext.Remove(product);
                _DTContext.SaveChanges();
                return Ok(product);
            }
        }
    }
}