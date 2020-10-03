using Microsoft.AspNetCore.Components;
using Portfolio.Shared;
using Portfolio.Shared.Models;
using Portfolio.WASM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class AddProject
    {
        [Inject]
        public IProjectDataService ProjectDataService { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Parameter]
        public ProjectViewModel ProjectViewModel { get; set; } = new ProjectViewModel();

        public AddProject()
        {

        }

        public async void PostProject()
        {
            await ProjectDataService.AddProjectAsync(ProjectViewModel);

            NavigationManager.NavigateTo("");
        }
    }
}
