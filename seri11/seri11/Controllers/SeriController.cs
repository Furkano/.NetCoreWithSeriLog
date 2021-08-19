using Microsoft.AspNetCore.Mvc;
using seri11.Entity;
using seri11.Logging.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace seri11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeriController : Controller
    {
        [HttpPost]

        public ActionResult Serileme(User user)
        {
            LoggerFactory.MongoLogManager().Information("{@user}", user);
            return Ok("data ekelendi");
        }

        [HttpPost("warning")]

        public ActionResult Serileme2(User user)
        {
            LoggerFactory.MongoLogManager().Warning("{@user}", user);
            return Ok("data ekelend2");
        }

    }
}
