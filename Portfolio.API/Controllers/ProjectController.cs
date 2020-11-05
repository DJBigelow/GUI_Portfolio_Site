using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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

        //[Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            await repository.AddProjectAsync(project);

            return NoContent();
        }


        //[Authorize]
        [HttpDelete("[action]/{projectID}")]
        public async Task<IActionResult> DeleteProject(int projectID)
        {
            await repository.DeleteProjectAsync(projectID);

            return NoContent();
        }


        //[Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProject(Project project)
        {
            await repository.UpdateProjectAsync(project);

            return NoContent();
        }


        //[Authorize]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Associate(AssociationRequest associationRequest)
        {
            await repository.AssociateProjectAndCategory(associationRequest);

            return NoContent();
        }





        [HttpGet("[action]")]
        public IActionResult GetProjects()
        {
            return Ok(repository.GetProjects().Select(p => new ProjectViewModel(p)).ToList());
        }



        [HttpGet("[action]/{slug}")]
        public IActionResult GetProject(string slug)
        {
            var project = repository.GetProjects().FirstOrDefault(p => p.Slug == slug);
            
            var projectVM = new ProjectViewModel(project);
            return Ok(projectVM);
        }



    }
}
