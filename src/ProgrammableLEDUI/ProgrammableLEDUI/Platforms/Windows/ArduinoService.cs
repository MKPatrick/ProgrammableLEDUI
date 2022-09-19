using ProgrammableLEDUI.Models;
using ProgrammableLEDUI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const string BOILERPLATE = "#include <Adafruit_NeoPixel.h>\n#ifdef __AVR__\n #include <avr/power.h> // Required for 16 MHz Adafruit Trinket\n#endif\n\nAdafruit_NeoPixel pixels(NUMPIXELS, PIN, NEO_GRB + NEO_KHZ800);\nvoid setup() {\n  pixels.begin();\n  pixels.clear(); \n}\nvoid loop() {\n\n}\n";


        public ArduinoService(ITranspileService transpileService)
        {
            this._transpileService = transpileService;
        }

        public bool CompileAndUpload(string target)
        {
            var source = _transpileService.TranspileScenesToCode(_projectModel.Scenes);
            MergeBoilerPlateWithSource(source);
            var path = Path.GetDirectoryName(Consts.ARDUINOCLIPATH);
            ExecuteCommand($"upload -p {target} --fqbn esp8266:esp8266:nodemcuv2 {path}\\{_projectModel.Name}");
            return true;
        }

        public void CreateProject(ProjectModel project)
        {
            _projectModel = project;
            var path = Path.GetDirectoryName(Consts.ARDUINOCLIPATH);
            Directory.CreateDirectory($"{path}\\{project.Name}");
            File.WriteAllText($"{path}\\{project.Name}\\{project.Name}.ino", BOILERPLATE);
        }

        public void Init()
        {
            ExecuteCommand("config init");
            ExecuteCommand("core update-index");
            ExecuteCommand("lib install \"Adafruit Neopixel\"");
        }


        public IEnumerable<string> GetTargets()
        {
            List<string> targets = new();
            //todo: tbc
            targets.Add(ExecuteCommand("board list"));
            return targets;
        }

        private void MergeBoilerPlateWithSource(string newSource)
        {

        }




        private string ExecuteCommand(string command)
        {
            var process = new Process
            {
                StartInfo =
              {
                  FileName = Consts.ARDUINOCLIPATH,
                  Arguments = command
              }
            };
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.EnableRaisingEvents = true;
            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();
            return output + error;

        }


    }
}
