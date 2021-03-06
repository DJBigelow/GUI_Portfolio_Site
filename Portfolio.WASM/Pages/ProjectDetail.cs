﻿using Microsoft.AspNetCore.Components;
using Portfolio.WASM.Services;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared;
using Markdig;
using Markdig.Extensions;
using Markdig.SyntaxHighlighting;

namespace Portfolio.WASM.Pages
{
    public partial class ProjectDetail : ComponentBase
    {
        [Parameter]
        public string ProjectSlug { get; set; }


        //For some reason beyond my understanding, this property needs to be initialized before it's assigned anything, otherwise you get a null reference exception
        public ProjectViewModel ProjectViewModel { get; set; } = new ProjectViewModel();

        public IEnumerable<Category> Frameworks { get; set; } = new List<Category>();
        public IEnumerable<Category> Languages { get; set; } = new List<Category>();
        public IEnumerable<Category> Platforms { get; set; } = new List<Category>();

        public string RequirementHTMLString { get; set; }
        public string DesignHTMLString { get; set; }

        //public string RequirementHTMLString { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        IProjectDataService ProjectDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            ProjectViewModel = await ProjectDataService.GetProjectAsync(ProjectSlug);

            Frameworks = ProjectViewModel.Categories.Where(c => c.Type == CategoryTypes.FRAMEWORK);
            Languages = ProjectViewModel.Categories.Where(c => c.Type == CategoryTypes.LANGUAGE);
            Platforms = ProjectViewModel.Categories.Where(c => c.Type == CategoryTypes.PLATFORM);

            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().UseSyntaxHighlighting().Build();

            //RequirementHTMLString = Markdig.Markdown.ToHtml(ProjectViewModel.Requirement);
            DesignHTMLString = Markdig.Markdown.ToHtml(ProjectViewModel.Design, pipeline);
        }

        public async void DeleteProject()
        {
            await ProjectDataService.DeleteProjectAsync(ProjectViewModel.ID);

            NavigationManager.NavigateTo("/projects");
        }
    }
}
