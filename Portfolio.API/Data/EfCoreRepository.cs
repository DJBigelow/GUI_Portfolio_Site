using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Portfolio.Shared.Utilities;

namespace Portfolio.Shared.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;

        public IEnumerable<Project> Projects => context.Projects;

        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public IEnumerable<Project> GetProjects() => context.Projects.Include(p => p.ProjectCategories).ThenInclude(pc => pc.Category);
                                                                   

        public async Task<Project> GetProjectAsync(int projectID)
        {
            var project = await context.Projects
                .Include(p => p.ProjectCategories).ThenInclude(pc => pc.Category)
                .FirstOrDefaultAsync(p => p.ID == projectID);
           
            return project;
        }


        public async Task AddProjectAsync(Project project)
        {
            project.Slug = project.Title.ToSlug();
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
            //Instead of simply calling context.Update(project) from the get-go, we  have to manually copy the data from project to existingProject because they aren't the same object. 
            //This is because project is a new Project object converted from a ProjectViewModel object received from the front-end
            var existingProject = await GetProjectAsync(project.ID);

            existingProject.Title = project.Title;
            existingProject.Slug = existingProject.Title.ToSlug();
            existingProject.Requirement = project.Requirement;
            existingProject.Design = project.Design;
            existingProject.CompletionDate = project.CompletionDate;

            context.Update(existingProject);
            await context.SaveChangesAsync();
        }

        public async Task AssociateProjectAndCategory(AssociationRequest associationRequest)
        {
            Category category = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Categories, c => c.Type == associationRequest.CategoryType && 
                                                                                                                      c.Name == associationRequest.CategoryName);
            if (category == null)
            {
                category = new Category() { Type = associationRequest.CategoryType, Name = associationRequest.CategoryName };
                context.Categories.Add(category);
                await context.SaveChangesAsync();
            }

            Project project = await GetProjectAsync(associationRequest.ProjectID);

            ProjectCategory pc = new ProjectCategory() { Project = project, Category = category };
            context.ProjectCategories.Add(pc);
            await context.SaveChangesAsync();

        }

        
        //public async Task AssociateProjectAndFramework(int projectID, string frameworkName)
        //{
        //    Framework framework = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(context.Frameworks, f => f.Name == frameworkName);

        //    if (framework == null)
        //    {
        //        framework = new Framework() { Name = frameworkName };
        //        context.Frameworks.Add(framework);
        //        await context.SaveChangesAsync();           
        //    }

        //    Project project = await GetProjectAsync(projectID);
        //    ProjectFramework pf = new ProjectFramework() { Framework = framework, Project = project };

        //    context.ProjectFrameworks.Add(pf);
        //    await context.SaveChangesAsync();
        //}



    }
}
