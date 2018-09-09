using BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessServices
{
    public class EnvironmentService : IEnvironmentService
    {
        public IList<Repository.Models.Environment> GetAllEnvironments()
        {
            var context = new EnvironmentContext();
            var test = context.Environments.Include(b => b.user).ToList();
            return test;
        }

        public void AddEnvironment(Repository.Models.Environment environment)
        {
            using (var context = new EnvironmentContext())
            {
                context.Environments.Add(environment);
                context.SaveChanges();
            }
        }

        public Repository.Models.Environment ChangeEnvironmentName(int id, string newName)
        {
            using (var context = new EnvironmentContext())
            {
                var env = context.Environments.SingleOrDefault(e => e.EnvironmentId == id);
                env.EnvironmentName = newName;
                context.SaveChanges();
                return env;
            }
        }
    }
}
