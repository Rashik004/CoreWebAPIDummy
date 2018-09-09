using System;
using System.Collections.Generic;
using System.Text;
using Repository.Models;
namespace BusinessServices.Contracts
{
    public interface IEnvironmentService
    {
        IList<Repository.Models.Environment> GetAllEnvironments();

        void AddEnvironment(Repository.Models.Environment environment);

        Repository.Models.Environment ChangeEnvironmentName(int id, string newName);
    }
}
