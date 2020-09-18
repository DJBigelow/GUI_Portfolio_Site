using Portfolio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        

        public IQueryable<Project> GetProjects()
        {
            return context.Projects;
        }

        public async Task SaveProject(Project project)
        {
            await context.AddAsync(project);
            await context.SaveChangesAsync();
        }
    }
}
