using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Data
{
    public interface IRepository 
    {
        public IEnumerable<Project> GetProjects();

        public IEnumerable<Project> Projects { get; }
       
        public Task<Project> GetProjectAsync(int projectID);
        
        public Task AddProjectAsync(Project project);

        public Task DeleteProjectAsync(int projectID);

        public Task UpdateProjectAsync(Project project);


        public Task AssociateProjectAndCategory(AssociationRequest associationRequest);

    }
}
