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
    public class AccountController : Controller
    {
        private readonly _QL_DTContext _DTContext;
        public AccountController(_QL_DTContext DTContext){
            _DTContext = DTContext;    
        }

        [HttpGet]
        public IActionResult GetAll(){
            var model = _DTContext.Accounts.ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int AccountID){
            var model = _DTContext.Accounts.Where(c=>c.AccountID==AccountID).FirstOrDefault();
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Account model){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _DTContext.Accounts.Add(model);
            _DTContext.SaveChanges();
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Update(int AccountID, [FromBody]Account model){
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var account = _DTContext.Accounts.Find(AccountID);
            if(account == null)
                return NotFound();

            _DTContext.Entry(account).CurrentValues.SetValues(model);
            _DTContext.SaveChanges();
            return Ok(model);
        }

        [HttpDelete]
        public IActionResult Delete(int AccountID)
        {
            var account = _DTContext.Accounts.Find(AccountID);
            if(account == null)
                return NotFound();

            _DTContext.Remove(account);
            _DTContext.SaveChanges();

            return Ok(account);
        }
    }
}