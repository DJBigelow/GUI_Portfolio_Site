using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared.Models;

namespace Portfolio.WASM.Services

{
    public interface IProjectDataService
    {
        public Task<IEnumerable<Project>> GetProjectsAsync();

        public Task<Project> GetProjectAsync(int projectID);

        public Task AddProjectAsync(Project project);

        public Task DeleteProjectAsync(int projectID);

        public Task UpdateProjectAsync(Project project);

        public Task AssociateProjectWithCategory(AssociationRequest associationRequest);
    }
}
