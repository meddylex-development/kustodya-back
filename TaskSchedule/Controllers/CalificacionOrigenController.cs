using LogicaTareas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TaskSchedule.Controllers
{
    public class CalificacionOrigenController : ApiController
    {
        // GET: api/CalificacionOrigen
        public string Get()
        {
            try
            {
                LCalificacionOrigen lCalificacionOrigen = new LCalificacionOrigen();
                lCalificacionOrigen.kustodyaco();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : "");
            }
        }
        // GET: api/CalificacionOrigen/5
        public string Get(int id)
        {
            LCalificacionOrigen lCalificacionOrigen = new LCalificacionOrigen();
            lCalificacionOrigen.EjecutarOCR();
            return "ok";
        }

        // POST: api/CalificacionOrigen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CalificacionOrigen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CalificacionOrigen/5
        public void Delete(int id)
        {
        }
    }
}
