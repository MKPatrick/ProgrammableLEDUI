using ProgrammableLEDUI.Models;
using ProgrammableLEDUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammableLEDUI.Platforms.Windows
{
    public class TranspileToArduinoService : ITranspileService
    {
        public string TranspileScenesToCode(IEnumerable<SceneModel> scenes)
        {
            StringBuilder stringBuilder = new();
            foreach (var scene in scenes)
            {
                stringBuilder.AppendLine(TranspileSceneToCode(scene));
            }
            return stringBuilder.ToString();
        }

        public string TranspileSceneToCode(SceneModel scene)
        {
            StringBuilder stringBuilder = new();


            foreach (var pixel in scene.NewPixels)
            {
                stringBuilder.AppendLine(SetPixelColor(pixel));
                if (scene.DelayBetweenPixels != null)
                {
                    stringBuilder.AppendLine(MakeDelay(scene.DelayBetweenPixels.Value));
                    stringBuilder.AppendLine(ShowPixels());
                }
            }


            stringBuilder.AppendLine(ShowPixels());
            //makes the end delay
            if (scene.DelayToNextScene != null)
            {
                stringBuilder.AppendLine(MakeDelay(scene.DelayToNextScene.Value));
            }

            return stringBuilder.ToString();

        }




        private string ShowPixels()
        {
            return "pixels.show();";
        }
        private string MakeDelay(uint delay)
        {
            return $"delay({delay});";
        }

        private string SetBrightness(byte brightness)
        {
            return $"pixels.setBrightness({brightness});";
        }


        private string SetPixelColor(LEDPixelModel pixel)
        {
            return $"pixels.setPixelColor({pixel.PixelIndex}, pixels.Color({pixel.PixelColor.Red}, {pixel.PixelColor.Green}, {pixel.PixelColor.Blue}));";
        }

    }
}
