﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Models;
using HMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roomController : ControllerBase
    {
        readonly log4net.ILog _log4net;
        //public readonly hotelDBContext _context;
        Iroomrep db;
        public roomController(Iroomrep _db)
        {
            _log4net = log4net.LogManager.GetLogger(typeof(roomController));
            //_context = context;
            db = _db;
        }
        // GET: api/<roomController>
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

        // GET api/<roomController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            room data = new room();
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

        // POST api/<roomController>
        [HttpPost]
        public IActionResult Post([FromBody] room obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = db.AddDetail(obj);
                    if (res != 0)
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

        // PUT api/<roomController>/5
        /*[HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<roomController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = db.Delete(id);
                if (result == 0)
                {
                    return NotFound(result);
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
