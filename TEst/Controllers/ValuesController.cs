using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices;
using Microsoft.AspNetCore.Mvc;
using TEst.QueryObject;

namespace TEst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IList<Repository.Models.Environment> Get()
        {
            var bl = new EnvironmentService();
            return bl.GetAllEnvironments();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post(Repository.Models.Environment value)
        {
            var bl = new EnvironmentService();
            bl.AddEnvironment(value);
        }
        [Route("changeEnvName")]
        [HttpPost]
        public Repository.Models.Environment ChangeEnvironmentName(changeEnvNameCommand command)
        {
            if(string.IsNullOrWhiteSpace(command.EnvironmentName))
            {
                throw new Exception("Name cant be null or empty");
            }
            var bl = new EnvironmentService();
            return bl.ChangeEnvironmentName(command.EnvironmentId, command.EnvironmentName);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
