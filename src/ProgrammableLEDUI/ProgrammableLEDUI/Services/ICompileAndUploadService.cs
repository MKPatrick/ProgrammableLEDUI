using ProgrammableLEDUI.Models;

namespace ProgrammableLEDUI.Services;

public interface ICompileAndUploadService
{
    /// <summary>
    /// For init project, make config ready...
    /// </summary>
    void Init();


    /// <summary>
    /// Create an Empty Project
    /// </summary>
    void CreateProject(ProjectModel project);


    /// <summary>
    /// Use the generated source-code from scenes and compile it
    /// </summary>
    /// <param name="target">Where it should be compiled</param>
    /// <returns>False if compile Failed, True if done</returns>
    bool CompileAndUpload(string target);

    /// <summary>
    /// Gets all available targets
    /// </summary>
    /// <returns></returns>
    IEnumerable<string> GetTargets();

}
