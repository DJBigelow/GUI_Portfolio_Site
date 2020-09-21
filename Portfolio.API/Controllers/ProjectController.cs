using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Shared.Data;
using Portfolio.Shared.Models;

namespace Portfolio.Shared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IRepository repository;

        public ProjectController(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpPost]
        public async Task AddProject(Project project)
        {
            await repository.AddProjectAsync(project);
        }

        [HttpDelete]
        public async Task DeleteProject(Project project)
        {
            await repository.DeleteProjectAsync(project);
        }

        [HttpPut]
        public async Task UpdateProject(Project project)
        {
            await repository.UpdateProjectAsync(project);
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return repository.GetProjects();
        }

        [HttpGet]
        public async Task<Project> GetProject(int projectID)
        {
            return await repository.GetProjectAsync(projectID);
        }

    }
}
