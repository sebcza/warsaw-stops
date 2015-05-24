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
using WebGrease.Css.Extensions;
using WebService.Models;

namespace WebService.Controllers
{
	public class BusStopController : ApiController
	{
		private BusContext db = new BusContext();

		// GET: api/BusStop
		public IQueryable<BusStopEntity> GetBusStops()
		{
			return db.BusStops;
		}

		// GET: api/BusStop/5
		[ResponseType(typeof(BusStopEntity))]
		public IHttpActionResult GetBusStopEntity(int id)
		{
			BusStopEntity busStopEntity = db.BusStops.Find(id);
			if (busStopEntity == null)
			{
				return NotFound();
			}

			return Ok(busStopEntity);
		}

		[ResponseType(typeof(IEnumerable<BusStopListItem>))]
		public IHttpActionResult GetBusStopEntity(string name)
		{
			IEnumerable<BusStopEntity> busStopEntities = db.BusStops.
				Where(x => x.Name.Contains(name))
				.Take(10);
			if (busStopEntities == null)
			{
				return NotFound();
			}

			var listToReturn = new List<BusStopListItem>();
			busStopEntities.ForEach(x=>listToReturn.Add(new BusStopListItem()
			{
				Id= x.Id,
				Name = x.Name,
				Direction = x.Direction,
				Number = x.Number
			}));

			return Ok(listToReturn);
		}

		// PUT: api/BusStop/5
		[ResponseType(typeof(void))]
		public IHttpActionResult PutBusStopEntity(int id, BusStopEntity busStopEntity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			if (id != busStopEntity.Id)
			{
				return BadRequest();
			}

			db.Entry(busStopEntity).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!BusStopEntityExists(id))
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

		// POST: api/BusStop
		[ResponseType(typeof(BusStopEntity))]
		public IHttpActionResult PostBusStopEntity(BusStopEntity busStopEntity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			db.BusStops.Add(busStopEntity);
			db.SaveChanges();

			return CreatedAtRoute("DefaultApi", new { id = busStopEntity.Id }, busStopEntity);
		}

		// DELETE: api/BusStop/5
		[ResponseType(typeof(BusStopEntity))]
		public IHttpActionResult DeleteBusStopEntity(int id)
		{
			BusStopEntity busStopEntity = db.BusStops.Find(id);
			if (busStopEntity == null)
			{
				return NotFound();
			}

			db.BusStops.Remove(busStopEntity);
			db.SaveChanges();

			return Ok(busStopEntity);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}

		private bool BusStopEntityExists(int id)
		{
			return db.BusStops.Count(e => e.Id == id) > 0;
		}
	}
}