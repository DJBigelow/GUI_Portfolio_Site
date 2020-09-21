using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Portfolio.Shared.Models;

namespace Portfolio.WASM.Client.Services
{
    public class APIProjectDataService : IProjectDataService
    {
        private readonly HttpClient httpClient;

        public APIProjectDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Project>>(
                 await httpClient.GetStreamAsync($"api/GetProjects"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Project> GetProjectAsync(int projectID)
        {
            return await JsonSerializer.DeserializeAsync<Project>(
                await httpClient.GetStreamAsync($"api/GetProject/{projectID}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task AddProjectAsync(Project project)
        {
             await JsonSerializer.SerializeAsync(
                await httpClient.GetStreamAsync($"api/AddProject/{project}"), project);
        }

        public async Task DeleteProjectAsync(Project project)
        {
            await JsonSerializer.SerializeAsync(
                await httpClient.GetStreamAsync($"api/DeleteProject/{project}"), project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            await JsonSerializer.SerializeAsync(
               await httpClient.GetStreamAsync($"api/UpdateProject/{project}"), project);
        }
    }
}
