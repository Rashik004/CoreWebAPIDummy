using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessServices;
using BusinessServices.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DummyWeb.QueryObject;

namespace DummyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEnvironmentService environmentService;
        private readonly ILogger _logger;
        public ValuesController(IEnvironmentService environmentService,
            ILogger<ValuesController> logger)
        {
            this.environmentService = environmentService;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public IList<Repository.Models.Environment> Get()
        {
            _logger.Log(LogLevel.Warning, "HIIIIIIIIII");
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
