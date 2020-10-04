using Microsoft.AspNetCore.Components;
using Portfolio.Shared;
using Portfolio.Shared.Models;
using Portfolio.WASM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class Platforms
    {
        [Parameter]
        public string CategoryName { get; set; }

        [Inject]
        public IProjectDataService ProjectDataService { get; set; }

        public IList<Platform> PlatformList { get; set; } = new List<Platform>();

        public IEnumerable<ProjectViewModel> ProjectViewModels { get; set; } = new List<ProjectViewModel>();

        protected async override Task OnInitializedAsync()
        {

            ProjectViewModels = (await ProjectDataService.GetProjectsAsync());

            foreach (ProjectViewModel vm in ProjectViewModels)
            {
                foreach (Platform platform in vm.Platforms)
                {
                    if (!PlatformList.Contains(platform))
                    {
                        PlatformList.Add(platform);
                    }
                }
            }

        }
    }
}
