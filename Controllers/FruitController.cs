using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class FruitsController : ControllerBase
    {
        fruitsservice fs = new fruitsservice();
        //fruitsservice fs;
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(this.fs.GetFruits());
            //return Ok();
        }
        [HttpPost]
        public ActionResult Post(fruits f)
        {
            fs.AddFruits(f);
            return Ok();
        }
        [HttpPut]
        public ActionResult Put(fruits f)
        {
            fs.UpdateFruits(f);
            return Ok();
        }
        [HttpDelete]
        public ActionResult Delete(fruits f)
        {
            fs.DeleteFruits(f);
            return Ok();
        }
    }
}