﻿using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Data
{
    public interface IRepository 
    {
        public IEnumerable<Project> GetProjects();
       
        public Task<Project> GetProjectAsync(int projectID);
        
        public Task AddProjectAsync(Project project);

        public Task DeleteProjectAsync(Project project);

        public Task UpdateProjectAsync(Project project);

    }
}
