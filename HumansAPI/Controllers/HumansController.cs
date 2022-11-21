using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HumansAPI.Models;
using HumansAPI.Entities;

namespace HumansAPI.Controllers
{
    public class HumansController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/Humans
        [ResponseType(typeof(List<HumanModel>))]
        public IHttpActionResult GetHumans()
        {
            return Ok(db.Humans.ToList().ConvertAll(x => new HumanModel(x)));
        }

        // GET: api/Humans/5
        [ResponseType(typeof(Humans))]
        public IHttpActionResult GetHumans(int id)
        {
            Humans humans = db.Humans.Find(id);
            if (humans == null)
            {
                return NotFound();
            }

            return Ok(humans);
        }

        // PUT: api/Humans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHumans(int id, Humans humans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != humans.Id)
            {
                return BadRequest();
            }

            db.Entry(humans).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumansExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Humans
        [ResponseType(typeof(Humans))]
        public IHttpActionResult PostHumans(Humans humans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Humans.Add(humans);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HumansExists(humans.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = humans.Id }, humans);
        }

        // DELETE: api/Humans/5
        [ResponseType(typeof(Humans))]
        public IHttpActionResult DeleteHumans(int id)
        {
            Humans humans = db.Humans.Find(id);
            if (humans == null)
            {
                return NotFound();
            }

            db.Humans.Remove(humans);
            db.SaveChanges();

            return Ok(humans);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HumansExists(int id)
        {
            return db.Humans.Count(e => e.Id == id) > 0;
        }
    }
}