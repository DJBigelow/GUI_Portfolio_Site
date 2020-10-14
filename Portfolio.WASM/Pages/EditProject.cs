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

            ProjectSlug = ProjectViewModel.Title.ToSlug();

            await ProjectDataService.UpdateProjectAsync(ProjectViewModel);
            NavigationManager.NavigateTo($"projects/detail/{ProjectSlug}");
        }

        public void DiscardChanges()
        {
            NavigationManager.NavigateTo($"projects/detail/{ProjectSlug}");
        }

    }
}
