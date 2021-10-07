using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KurserTest6.Models;


namespace KurserTest6.Controllers
{
    public class ValuesController : ApiController
    {
        db_access_layer.db dblayer = new db_access_layer.db();

        [HttpPost]

        public IHttpActionResult AddCustomer([FromBody] KurserModel cs)

        {

            try

            {

                if (!ModelState.IsValid)

                {

                    return BadRequest(ModelState);

                }
                dblayer.Add_Rate(cs);

                return Ok("Success");
            }

            catch (Exception)

            {
                return Ok("Something went wrong, try later");

            }

        }

    }
}
