using Microsoft.AspNetCore.Components;
using Portfolio.Shared.Models;
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
        public HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }

        public IEnumerable<Project> Projectlist { get; set; }

    }
}
