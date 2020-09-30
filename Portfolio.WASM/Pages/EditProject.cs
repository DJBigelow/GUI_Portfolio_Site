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


        public string Framework { get; set; }
        public string Language{ get; set; }
        public string Platform { get; set; }

      


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
            NavigationManager.NavigateTo($"projects/detail/{Project.ID}");
        }

        public void DiscardChanges()
        {
            NavigationManager.NavigateTo($"projects/detail/{Project.ID}");
        }



        public async Task AddFramework()
        {
            var associationRequest = new AssociationRequest() { CategoryType = Categories.FRAMEWORK, Category = Framework, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }

        public async Task AddLanguage()
        {
            var associationRequest = new AssociationRequest() { CategoryType = Categories.LANGUAGE, Category = Language, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }

        public async Task AddPlatform()
        {
            var associationRequest = new AssociationRequest() { CategoryType = Categories.PLATFORM, Category = Platform, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }
    }
}
