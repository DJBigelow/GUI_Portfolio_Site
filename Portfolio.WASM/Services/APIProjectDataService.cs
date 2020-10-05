﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Portfolio.Shared.Models;
using System.Text;
using Portfolio.Shared;

namespace Portfolio.WASM.Services
{
    public class APIProjectDataService : IProjectDataService
    {
        private readonly HttpClient httpClient;

        public APIProjectDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        

        public async Task<IEnumerable<ProjectViewModel>> GetProjectsAsync()
        {
             var projectVMs = await JsonSerializer.DeserializeAsync<IEnumerable<ProjectViewModel>>(
                 await httpClient.GetStreamAsync("api/project/getprojects"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return projectVMs;
        }

        public async Task<ProjectViewModel> GetProjectAsync(int projectID)
        {
            ProjectViewModel projectVM = await JsonSerializer.DeserializeAsync<ProjectViewModel>(
                await httpClient.GetStreamAsync($"api/project/getproject/{projectID}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return projectVM;
        }

        public async Task AddProjectAsync(ProjectViewModel projectVM)
        {
            Project project = new Project(projectVM);

            var projectJson = new StringContent(JsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            await httpClient.PostAsync("api/project/addproject", projectJson);
        }

        public async Task DeleteProjectAsync(int projectID)
        {
            await httpClient.DeleteAsync($"api/project/deleteproject/{projectID}");
        }

        public async Task UpdateProjectAsync(ProjectViewModel projectVM)
        {
            Project project = new Project(projectVM);

            var projectJson = new StringContent(JsonSerializer.Serialize(project), Encoding.UTF8, "application/json");

            await httpClient.PutAsync("api/project/updateproject", projectJson);
        }


        public async Task AssociateProjectWithCategory(AssociationRequest associationRequest)
        {
            var json = new StringContent(JsonSerializer.Serialize(associationRequest), Encoding.UTF8, "application/json");

            await httpClient.PostAsync("api/project/associate", json);
        }
    }
}