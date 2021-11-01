using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using API1.Models;

namespace API1.Controllers
{
    public class UsuariosController : ApiController
    {
        private Api1Entities_1 db = new Api1Entities_1();

        // GET: api/Usuarios
        public IQueryable<dbUsuario> GetdbUsuario()
        {
            return db.dbUsuario;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(dbUsuario))]
        public IHttpActionResult GetdbUsuario(int id)
        {
            dbUsuario dbUsuario = db.dbUsuario.Find(id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            return Ok(dbUsuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutdbUsuario(int id, dbUsuario dbUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dbUsuario.Id)
            {
                return BadRequest();
            }

            db.Entry(dbUsuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbUsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(dbUsuario))]
        public IHttpActionResult PostdbUsuario(dbUsuario dbUsuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.dbUsuario.Add(dbUsuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dbUsuario.Id }, dbUsuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(dbUsuario))]
        public IHttpActionResult DeletedbUsuario(int id)
        {
            dbUsuario dbUsuario = db.dbUsuario.Find(id);
            if (dbUsuario == null)
            {
                return NotFound();
            }

            db.dbUsuario.Remove(dbUsuario);
            db.SaveChanges();

            return Ok(dbUsuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool dbUsuarioExists(int id)
        {
            return db.dbUsuario.Count(e => e.Id == id) > 0;
        }
    }
}