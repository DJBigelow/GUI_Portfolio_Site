using Microsoft.AspNetCore.Components;
using Portfolio.WASM.Services;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared;

namespace Portfolio.WASM.Pages
{
    public partial class EditProject
    {
        [Inject]
        IProjectDataService ProjectDataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public ProjectViewModel ProjectViewModel { get; set; } = new ProjectViewModel();
      
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
            ProjectViewModel = await ProjectDataService.GetProjectAsync(ProjectID);

            Title = ProjectViewModel.Title;
            Requirement = ProjectViewModel.Requirement;
            Design = ProjectViewModel.Design;
            CompletionDate = ProjectViewModel.CompletionDate;
        }

        public async Task SubmitChanges()
        {
            ProjectViewModel.Title = Title;
            ProjectViewModel.Requirement = Requirement;
            ProjectViewModel.Design = Design;
            ProjectViewModel.CompletionDate = CompletionDate;

            await ProjectDataService.UpdateProjectAsync(ProjectViewModel);
            NavigationManager.NavigateTo($"projects/detail/{ProjectViewModel.ID}");
        }

        public void DiscardChanges()
        {
            NavigationManager.NavigateTo($"projects/detail/{ProjectViewModel.ID}");
        }



        public async Task AddFramework()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.FRAMEWORK, CategoryName = Framework, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }

        public async Task AddLanguage()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.LANGUAGE, CategoryName = Language, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }

        public async Task AddPlatform()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.PLATFORM, CategoryName = Platform, ProjectID = ProjectID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
        }
    }
}
