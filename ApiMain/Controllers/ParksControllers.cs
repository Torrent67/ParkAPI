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
    public class ParksController : ControllerBase
    {
        private ApiMainContext _db = new ApiMainContext();

        // GET api/parks
        [HttpGet]
        public ActionResult<IEnumerable<Park>> Get()
        {
            return _db.Parks
                // .Include(parks => parks.Destination)
                .ToList();
        }

        // POST api/parkss
        [HttpPost]
        public void Post([FromBody] Park Park)
        {
            _db.Parks.Add(Park);
            var thisState = _db.States
                .Include(state => state.Parks)
                .FirstOrDefault(x => x.StateId == Park.StateId);
            _db.SaveChanges();
        }

        // GET api/park/1
        [HttpGet("{id}")]
        public ActionResult<Park> Get(int id)
        {
            return _db.Parks.FirstOrDefault(x => x.ParkId == id);
        }

        // PUT api/parks/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Park park)
        {
            park.ParkId = id;
            _db.Entry(park).State = EntityState.Modified;
            _db.SaveChanges();
            var thisState = _db.States
                .Include(state => state.Parks)
                .FirstOrDefault(x=> x.StateId == park.StateId);
            _db.SaveChanges();
        }

        // DELETE api/park/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var thisPark = _db.Parks.FirstOrDefault(x => x.ParkId == id);
            _db.Parks.Remove(thisPark);
            _db.SaveChanges();
            var thisState = _db.States
                .Include(state => state.Parks)
                .FirstOrDefault(x=> x.StateId == thisPark.StateId);
            _db.SaveChanges();
        }
    }
}