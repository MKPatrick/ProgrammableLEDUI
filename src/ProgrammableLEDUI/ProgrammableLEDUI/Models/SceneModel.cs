namespace ProgrammableLEDUI.Models
{
    [Serializable]
    public class SceneModel
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public ProjectModel Project { get; set; }

        public List<LEDPixelModel> NewPixels { get; set; }

        public byte? NewBrightness { get; set; }

        public uint? DelayBetweenPixels { get; set; }


        public uint? DelayToNextScene { get; set; }

    }
}
