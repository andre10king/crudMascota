using CRUDdatosmascota.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDdatosmascota.Controllers
{
    public class MascotaController : ApiController
    {

        private Aviatur70Entities db = new Aviatur70Entities();

        //metodo get o listar
        public  IQueryable<Mascota> GetMascotas()
        {
            return db.Mascota;
        }

        //metodod agregar
        [ResponseType(typeof(Mascota))]
        public IHttpActionResult PostMascota(Mascota mascota)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Mascota.Add(mascota);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = mascota.id_mascota }, mascota);

        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReservaandresExists(int id)
        {
            return db.Mascota.Count(e => e.id_mascota == id) > 0;
        }

    }
}
