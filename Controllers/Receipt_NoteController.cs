using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QL_DT.DAL;
using QL_DT.Models;

namespace QL_DT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Receipt_NoteController : Controller
    {
        private readonly _QL_DTContext _DTContext;
        public Receipt_NoteController(_QL_DTContext DTContext)
        {
            _DTContext = DTContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _DTContext.Receipt_Notes.ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetReceipt_Note(int Receipt_ID)
        {
            var model = _DTContext.Receipt_Notes.Where(c => c.Receipt_ID == Receipt_ID).FirstOrDefault();
            return Ok(model);
        }

        public bool CreateReceipt(Receipt_Note index)
        {

                _DTContext.Receipt_Notes.Add(index);
                _DTContext.SaveChanges();

            try{
            foreach (var item in index.Detail_Receipts)
            {
                Product _current =_DTContext.Products.Where(c=>c.ProductID==item.Product_ID).FirstOrDefault();
                Product _toUpdate =_DTContext.Products.Where(c=>c.ProductID==item.Product_ID).FirstOrDefault();
                _toUpdate.Quantity+=item.Quantity;
                _DTContext.Entry(_current).CurrentValues.SetValues(_toUpdate);
                _DTContext.SaveChanges();
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8081");
                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    var obj = new
                    {
                        Id = item.Product_ID,
                        Quality = _toUpdate.Quantity,
                    };
                    string stringData = JsonConvert.SerializeObject(obj);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync("/api/product/" + obj.Id, contentData).Result;
                }
            }
            }catch{
                return false;
            }
            return true;
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]Receipt_Note model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if(CreateReceipt(model))
                return Ok("Thanh cong");
            return Ok("Fail");
        }
        [HttpPut]
        public IActionResult Update(int Receipt_ID, [FromBody]Receipt_Note model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var receipt_note = _DTContext.Receipt_Notes.Find(Receipt_ID);
            if (receipt_note == null)
                return NotFound();

            _DTContext.Entry(receipt_note).CurrentValues.SetValues(model);
            _DTContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int Receipt_ID)
        {
            var receipt_note = _DTContext.Detail_Receipts.Find(Receipt_ID);
            if (receipt_note == null)
                return NotFound();

            _DTContext.Remove(receipt_note);
            _DTContext.SaveChanges();

            return Ok(receipt_note);
        }
    }
}