using Microsoft.AspNetCore.Components;
using Portfolio.Shared;
using Portfolio.Shared.Models;
using Portfolio.WASM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class Frameworks
    {
        [Parameter]
        public string CategoryName { get; set; }

        [Inject]
        public IProjectDataService ProjectDataService { get; set; }

        public IList<Framework> FrameworkList { get; set; } = new List<Framework>();

        public IEnumerable<ProjectViewModel> ProjectViewModels { get; set; } = new List<ProjectViewModel>();

        protected async override Task OnInitializedAsync()
        {

            ProjectViewModels = (await ProjectDataService.GetProjectsAsync());

            foreach(ProjectViewModel vm in ProjectViewModels)
            {
                foreach(Framework framework in vm.Frameworks)
                {
                    if (!FrameworkList.Contains(framework))
                    {
                        FrameworkList.Add(framework);
                    }
                }
            }

        }
    }
}
