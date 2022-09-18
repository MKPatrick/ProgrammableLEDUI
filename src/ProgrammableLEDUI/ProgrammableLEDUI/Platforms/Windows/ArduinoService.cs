using ProgrammableLEDUI.Models;
using ProgrammableLEDUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammableLEDUI.Platforms.Windows
{
    public class ArduinoService : ICompileAndUploadService
    {
        private readonly ITranspileService _transpileService;
        private ProjectModel _projectModel;
        private string _sketchName;
        private string _sketchPath;


        public ArduinoService(ITranspileService transpileService)
        {
            this._transpileService = transpileService;
        }

        public bool CompileAndUpload(string target)
        {
            var source = _transpileService.TranspileScenesToCode(_projectModel.Scenes);
            source = MergeBoilerPlateWithSource(source);
            return true;
        }

        public void CreateProject(ProjectModel project)
        {
            _projectModel = project;

            //creates boiler plate
            //todo: tbc
        }

        public void Init()
        {

        }


        private string MergeBoilerPlateWithSource(string newSource)
        {
            return "";
        }


        //commands
        public string UploadSketchCommand(string target)
        {
            return $"UPLOAD {_sketchName} --port {target}";
        }

    }
}
