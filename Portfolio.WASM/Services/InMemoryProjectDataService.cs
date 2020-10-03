//using Portfolio.Shared.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Portfolio.WASM.Services
//{
//    public class InMemoryProjectDataService : IProjectDataService
//    {
//        private List<Project> projects = new List<Project>();

//        public async Task AddProjectAsync(Project project)
//        {
//            project.ID = projects.Count();
//            await Task.Run(() => projects.Add(project));
//        }

//        public Task AssociateProjectWithCategory(AssociationRequest associationRequest)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task DeleteProjectAsync(int projectID)
//        {
//            var project = projects[projectID];
//            await Task.Run(() => projects.Remove(project));

//        }

//        public async Task<Project> GetProjectAsync(int projectID)
//        {
//            return await Task.Run(() => projects[projectID]);
//        }

//        public async Task<IEnumerable<Project>> GetProjectsAsync()
//        {
//            return await Task.Run(() => projects);
//        }

//        public async Task UpdateProjectAsync(Project project)
//        {
//            await Task.Run(() => projects[project.ID] = project);
//        }
//    }
//}
