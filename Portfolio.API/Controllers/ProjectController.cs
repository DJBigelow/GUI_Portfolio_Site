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

        [HttpPost("[action]")]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            await repository.AddProjectAsync(project);

            return NoContent();
        }

        [HttpDelete("[action]/{projectID}")]
        public async Task<IActionResult> DeleteProject(int projectID)
        {
            await repository.DeleteProjectAsync(projectID);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            await repository.UpdateProjectAsync(project);

            return NoContent();
        }

        [HttpGet("[action]")]
        public IActionResult GetProjects()
        {
            return Ok(repository.GetProjects());
        }

        [HttpGet("[action]/{projectID}")]
        public async Task<IActionResult> GetProject(int projectID)
        {
            return Ok(await repository.GetProjectAsync(projectID));
        }



        [HttpPost("[action]/{projectID}/{framework}")]
        public async Task<IActionResult> AddFramework(int projectID, string framework)
        {
            await repository.AssociateProjectAndFramework(projectID, framework);
            return NoContent();
        }

        [HttpPost("[action]/{projectID}/{language}")]
        public async Task<IActionResult> AddLanguage(int projectID, string language)
        {
            await repository.AssociateProjectAndLanguage(projectID, language);
            return NoContent();
        }

        [HttpPost("[action]/{projectID}/{platform}")]
        public async Task<IActionResult> AddPlatform(int projectID, string platform)
        {
            await repository.AssociateProjectAndPlatform(projectID, platform);
            return NoContent();
        }
    }
}
