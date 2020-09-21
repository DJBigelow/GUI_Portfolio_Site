using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;
using Portfolio.WASM.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portfolio.WASM.Client.Pages
{
    public partial class Projects
    {
        [Inject]
        public IProjectDataService ProjectDataService{ get; set; }

        protected override async Task OnInitializedAsync()
        {
            ProjectList = await ProjectDataService.GetProjectsAsync();
             
        }

        [Parameter]
        public IEnumerable<Project> ProjectList { get; set; }

    }
}
