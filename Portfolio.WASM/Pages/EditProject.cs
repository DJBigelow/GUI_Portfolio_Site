using Microsoft.AspNetCore.Components;
using Portfolio.WASM.Services;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared;
using Portfolio.Shared.Utilities;

namespace Portfolio.WASM.Pages
{
    public partial class EditProject : ComponentBase
    {
        [Inject]
        IProjectDataService ProjectDataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        public ProjectViewModel ProjectViewModel { get; set; } = new ProjectViewModel();
      
        [Parameter]
        public string ProjectSlug { get; set; }

        public string Title { get; set; }
        public string Requirement { get; set; }
        public string Design { get; set; }
        public DateTime CompletionDate { get; set; }


        public string Framework { get; set; }
        public string Language{ get; set; }
        public string Platform { get; set; }

      


        protected override async Task OnInitializedAsync()
        {
            ProjectViewModel = await ProjectDataService.GetProjectAsync(ProjectSlug);

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
            ProjectSlug = ProjectViewModel.Title.ToSlug();
            NavigationManager.NavigateTo($"projects/detail/{ProjectSlug}");
        }

        public void DiscardChanges()
        {
            NavigationManager.NavigateTo($"projects/detail/{ProjectSlug}");
        }



        public async Task AddFramework()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.FRAMEWORK, CategoryName = Framework, ProjectID = ProjectViewModel.ID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
            Framework = "";
        }

        public async Task AddLanguage()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.LANGUAGE, CategoryName = Language, ProjectID = ProjectViewModel.ID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
            Language = "";
        }

        public async Task AddPlatform()
        {
            var associationRequest = new AssociationRequest() { CategoryType = CategoryTypes.PLATFORM, CategoryName = Platform, ProjectID = ProjectViewModel.ID };
            await ProjectDataService.AssociateProjectWithCategory(associationRequest);
            Platform = "";
        }
    }
}
