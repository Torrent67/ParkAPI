using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMain.Models;

namespace ApiMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private ApiMainContext _db = new ApiMainContext();

        // GET api/states
        [HttpGet]
        public ActionResult<IEnumerable<State>> Get()
        {
            
            return _db.States
                .Include(states => states.Reviews)
                .ToList();
        }

        //POST api/state
        [HttpPost]
        public void Post([FromBody] State state)
        {
            _db.States.Add(state);  
            _db.SaveChanges();
        }

        // GET api/state/1
        [HttpGet("{id}")]
        public ActionResult<State> Get(int id)
        {
            return _db.States
            .Include(states => states.Reviews)
            .FirstOrDefault(x => x.StateId == id);
        }

        // PUT api/states/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] State state)
        {
            state.StateId = id;
            _db.Entry(state).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/states/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisState = _db.States.FirstOrDefault(x => x.StateId == id);
            _db.Destinations.Remove(thisState);
            _db.SaveChanges();
        }
        
        //GET park by state
        [HttpGet("state/{state}")]
        public ActionResult<IEnumerable<State>> Get (string country)
        {
            return _db.States.Where(x => x.Country == country).ToList();
        }
    }
}