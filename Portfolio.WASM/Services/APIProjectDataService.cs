using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Portfolio.Shared.Models;
using System.Text;
using Portfolio.Shared;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Net.Http.Headers;

namespace Portfolio.WASM.Services
{
    public class APIProjectDataService : IProjectDataService
    {
        private readonly HttpClient httpClient;
        private readonly IAccessTokenProvider tokenProvider;

        public APIProjectDataService(HttpClient httpClient, IAccessTokenProvider tokenProvider)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.tokenProvider = tokenProvider;
        }


        public async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync()
        {
            var response = await httpClient.GetStreamAsync("api/project/getprojects");

            var projectVMs = await JsonSerializer.DeserializeAsync<IEnumerable<ProjectViewModel>>(
                response, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return projectVMs;
        }


        public async Task<ProjectViewModel> GetProjectAsync(int projectID)
        {
            ProjectViewModel projectVM = await JsonSerializer.DeserializeAsync<ProjectViewModel>(
                await httpClient.GetStreamAsync($"api/project/getproject/{projectID}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return projectVM;
        }


        public async Task<ProjectViewModel> GetProjectAsync(string projectSlug)
        {
            ProjectViewModel projectVM = await JsonSerializer.DeserializeAsync<ProjectViewModel>(
                await httpClient.GetStreamAsync($"api/project/getproject/{projectSlug}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return projectVM;
        }


        public async Task AddProjectAsync(ProjectViewModel projectVM)
        {
            var token = await TryGetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            Project project = new Project(projectVM);

            var projectJson = new StringContent(JsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            await httpClient.PostAsync("api/project/addproject", projectJson);
        }

        public async Task DeleteProjectAsync(int projectID)
        {
            var token = await TryGetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            await httpClient.DeleteAsync($"api/project/deleteproject/{projectID}");
           
        }

        public async Task UpdateProjectAsync(ProjectViewModel projectVM)
        {
            var token = await TryGetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            Project project = new Project(projectVM);

            var projectJson = new StringContent(JsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            await httpClient.PutAsync("api/project/updateproject", projectJson);
         
        }


        public async Task AssociateProjectWithCategory(AssociationRequest associationRequest)
        {
            var token = await TryGetAccessToken();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);

            var json = new StringContent(JsonSerializer.Serialize(associationRequest), Encoding.UTF8, "application/json");

            await httpClient.PostAsync("api/project/associate", json);
            
        }


        private async Task<AccessToken> TryGetAccessToken()
        {
            var tokenResult = await tokenProvider.RequestAccessToken();
            if (tokenResult.TryGetToken(out var token))
            {
                return token;
            }
            else
            {
                throw new Exception("API access not granted");
            }
        }
    }
}
