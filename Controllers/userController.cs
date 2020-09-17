using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HMS.Models;
using Microsoft.EntityFrameworkCore;
using HMS.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        Iuserrep db;
        public userController(Iuserrep _db)
        {
            db = _db;
             _log4net = log4net.LogManager.GetLogger(typeof(userController));
        }
        // GET: api/<userController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = db.GetDetails();
                if (obj == null)
                    return NotFound();
                return Ok(obj);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<userController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            user data = new user();
            try
            {
                data = db.GetDetail(id);
                if (data == null)
                {
                    return BadRequest(data);
                }
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest(data);
            }
        }

        // POST api/<userController>
        [HttpPost]
        public IActionResult Post([FromBody] user obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != null)
                        return Ok(res);
                    return NotFound();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] user boarder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = db.UpdateDetail(id, boarder);
                    if (result != 1)
                        return BadRequest(result);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        /*private bool BoardersExists(string id)
        {
        throw new NotImplementedException();
        }*/

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest(id);
            }
        }

    }
}