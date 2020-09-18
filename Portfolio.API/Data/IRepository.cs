using Portfolio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public interface IRepository 
    {
        public IQueryable<Project> GetProjects();
        public Task SaveProject(Project project);
    }
}
