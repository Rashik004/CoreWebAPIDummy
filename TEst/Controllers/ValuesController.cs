using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices;
using BusinessServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using TEst.QueryObject;

namespace TEst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEnvironmentService environmentService;

        public ValuesController(IEnvironmentService environmentService)
        {
            this.environmentService = environmentService;
        }
        // GET api/values
        [HttpGet]
        public IList<Repository.Models.Environment> Get()
        {
            return this.environmentService.GetAllEnvironments();
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
            environmentService.AddEnvironment(value);
        }
        [Route("changeEnvName")]
        [HttpPost]
        public Repository.Models.Environment ChangeEnvironmentName(changeEnvNameCommand command)
        {
            if(string.IsNullOrWhiteSpace(command.EnvironmentName))
            {
                throw new Exception("Name cant be null or empty");
            }
            return this.environmentService.ChangeEnvironmentName(command.EnvironmentId, command.EnvironmentName);
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
