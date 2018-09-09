using BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using Repository.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BusinessServices
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly EnvironmentContext _context;
        public EnvironmentService(EnvironmentContext environmentContext)
        {
            _context = environmentContext;
        }
        public IList<Repository.Models.Environment> GetAllEnvironments()
        {
            var test = _context.Environments.Include(b => b.user).ToList();
            return test;
        }

        public void AddEnvironment(Repository.Models.Environment environment)
        {
            _context.Environments.Add(environment);
            _context.SaveChanges();
        }

        public Repository.Models.Environment ChangeEnvironmentName(int id, string newName)
        {
            var env = _context.Environments.SingleOrDefault(e => e.EnvironmentId == id);
            env.EnvironmentName = newName;
            _context.SaveChanges();
            return env;
        }
    }
}
