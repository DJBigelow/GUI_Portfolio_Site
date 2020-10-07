using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared;
using Portfolio.Shared.Models;

namespace Portfolio.WASM.Services

{
    public interface IProjectDataService
    {
        public Task<IEnumerable<ProjectViewModel>> GetProjectsAsync();

        public Task<ProjectViewModel> GetProjectAsync(int projectID);

        public Task<ProjectViewModel> GetProjectAsync(string projectSlug);

        public Task AddProjectAsync(ProjectViewModel project);

        public Task DeleteProjectAsync(int projectID);

        public Task UpdateProjectAsync(ProjectViewModel project);

        public Task AssociateProjectWithCategory(AssociationRequest associationRequest);
    }
}
