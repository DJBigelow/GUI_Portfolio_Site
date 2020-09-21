using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;
using Portfolio.WASM.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WASM.Client.Pages
{
    public partial class ProjectDetail
    {
        [Inject]
        public IProjectDataService ProjectDataService { get; set; }

        public int ProjectID { get; set; }

        public Project Project { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Project = await ProjectDataService.GetProjectAsync(ProjectID);
        }
    }
}
