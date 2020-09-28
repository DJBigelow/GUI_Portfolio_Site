using Microsoft.AspNetCore.Components;
using Portfolio.WASM.Services;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class ProjectDetail
    {
        [Parameter]
        public int ProjectID { get; set; }


        //For some reason beyond my understanding, this property needs to be initialized before it's assigned anything, otherwise you get a null reference exception
        public Project Project { get; set; } = new Project();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        IProjectDataService ProjectDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Project = await ProjectDataService.GetProjectAsync(ProjectID);

            base.OnInitialized();
        }

        public async void DeleteProject()
        {
            await ProjectDataService.DeleteProjectAsync(Project.ID);

            NavigationManager.NavigateTo("~/");
        }
    }
}
