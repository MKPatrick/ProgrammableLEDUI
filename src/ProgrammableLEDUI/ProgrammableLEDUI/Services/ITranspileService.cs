using ProgrammableLEDUI.Models;

namespace ProgrammableLEDUI.Services;

public interface ITranspileService
{
    string TranspileScenesToCode(IEnumerable<SceneModel> scenes);
    string TranspileSceneToCode(SceneModel scene);
}
