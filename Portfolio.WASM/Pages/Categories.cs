using Microsoft.AspNetCore.Components;
using Portfolio.Shared;
using Portfolio.Shared.Models;
using Portfolio.WASM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.WASM.Pages
{
    public partial class Categories
    {
        [Parameter]
        public string CategoryTypeFilter { get; set; }

        [Inject]
        public IProjectDataService ProjectDataService { get; set; }

        //Consult Clean Code on how this name can be improved
        public IList<Category> CategoryList { get; set; } = new List<Category>();

        public IEnumerable<ProjectViewModel> ProjectViewModels { get; set; } = new List<ProjectViewModel>();

        protected override async Task OnInitializedAsync()
        {
            ProjectViewModels = await ProjectDataService.GetProjectsAsync();


            //Not a fan of this nested logic
            //What I'm trying to do is collect every distinct category of a given type of CategoryTypeFilter
            foreach(ProjectViewModel projectVM in ProjectViewModels)
            {
                foreach(Category category in projectVM.Categories)
                {
                    if (!CategoryList.Contains<Category>(category) && category.Type == CategoryTypeFilter)
                    {
                        CategoryList.Add(category);
                    }
                }
            }

        }

    }
}
