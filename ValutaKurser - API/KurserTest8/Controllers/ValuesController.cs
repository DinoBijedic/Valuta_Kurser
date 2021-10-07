using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KurserTest8.Models;

namespace KurserTest8.Controllers
{
    public class ValuesController : ApiController
    {
        db_access_layer.db dblayer = new db_access_layer.db();
        Kurser kurs = new Kurser();

        [HttpPost]
        public IHttpActionResult AddKurs([FromBody] Kurser kurser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.AddKurs(kurs);
                return Ok("Success");

            }
            catch (Exception)
            {
                return Ok("Something went wrong.");
            }
        }
    }
}
