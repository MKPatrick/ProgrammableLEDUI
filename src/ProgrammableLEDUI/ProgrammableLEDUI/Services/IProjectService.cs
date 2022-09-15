using ProgrammableLEDUI.Models;

namespace ProgrammableLEDUI.Services
{
    public interface IProjectService
    {
        public List<ProjectModel> GetProjects();
        public void CreateNewProject(ProjectModel project);
        public void DeleteProjectByID(int ID);
        public void SaveProject(ProjectModel project);
    }
}
