using Microsoft.AspNetCore.Components;
using Portfolio.WASM.Services;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class EditProject
    {
        [Inject]
        IProjectDataService ProjectDataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public Project Project { get; set; } = new Project();

        [Parameter]
        public int ProjectID { get; set; }

        public string Title { get; set; }
        public string Requirement { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Project = await ProjectDataService.GetProjectAsync(ProjectID);

            Title = Project.Title;
            Requirement = Project.Requirement;
            Design = Project.Design;
            CompletionDate = Project.CompletionDate;
        }

        public async Task SubmitChanges()
        {
            Project.Title = Title;
            Project.Requirement = Requirement;
            Project.Design = Design;
            Project.CompletionDate = CompletionDate;

            await ProjectDataService.UpdateProjectAsync(Project);
            NavigationManager.NavigateTo($"/projects/detail/{Project.ID}");
        }

        public void DiscardChanges()
        {
            NavigationManager.NavigateTo($"/projects/detail/{Project.ID}");
        }


    }
}
