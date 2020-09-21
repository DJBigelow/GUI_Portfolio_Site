using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portfolio.WASM.Client.Pages
{
    public partial class AddProject
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        public AddProject()
        {

        }
    }
}
