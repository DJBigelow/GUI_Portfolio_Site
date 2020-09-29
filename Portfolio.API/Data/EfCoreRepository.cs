using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Shared.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        

        public IEnumerable<Project> GetProjects()
        {
            return context.Projects;
        }

        public async Task<Project> GetProjectAsync(int projectID)
        {
            var project = await context.Projects.FirstOrDefaultAsync(p => p.ID == projectID);
            //return await context.Projects.FirstOrDefaultAsync(p => p.ID == projectID);
            return project;
        }

        public async Task AddProjectAsync(Project project)
        {
            await context.AddAsync(project);
            await context.SaveChangesAsync();
        }
        public async Task DeleteProjectAsync(int projectID)
        {            

            context.Remove(await GetProjectAsync(projectID));
            await context.SaveChangesAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            context.Update(project);
            await context.SaveChangesAsync();
        }



        public async Task AssociateProjectAndFramework(int projectID, string frameworkName)
        {
            Framework framework = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Frameworks, f => f.Name == frameworkName);

            if (framework == null)
            {
                framework = new Framework() { Name = frameworkName };
                context.Frameworks.Add(framework);
                await context.SaveChangesAsync();           
            }

            Project project = await GetProjectAsync(projectID);
            ProjectFramework pf = new ProjectFramework() { Framework = framework, Project = project };

            context.ProjectFrameworks.Add(pf);
            await context.SaveChangesAsync();
        }

        public async Task AssociateProjectAndLanguage(int projectID, string languageName)
        {
            Language language = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Languages, f => f.Name == languageName);

            if (language == null)
            {
                language = new Language() { Name = languageName };
                context.Languages.Add(language);
                await context.SaveChangesAsync();
            }

            Project project = await GetProjectAsync(projectID);
            ProjectLanguage pl = new ProjectLanguage() { Language = language, Project = project };

            context.ProjectLanguages.Add(pl);
            await context.SaveChangesAsync();

        }

        public async Task AssociateProjectAndPlatform(int projectID, string platformName)
        {
            Platform platform = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Platforms, f => f.Name == platformName);

            if (platform == null)
            {
                platform = new Platform() { Name = platformName };
                context.Platforms.Add(platform);
                await context.SaveChangesAsync();
            }

            Project project = await GetProjectAsync(projectID);
            ProjectPlatform pp = new ProjectPlatform() { Platform = platform, Project = project };

            context.ProjectPlatforms.Add(pp);
            await context.SaveChangesAsync();
        }
    }
}
