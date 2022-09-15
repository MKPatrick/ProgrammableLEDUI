namespace ProgrammableLEDUI.Models
{
    public class SceneModel
    {
        public int ID { get; set; }
        public ProjectModel Project { get; set; }
        public int ProjectID { get; set; }

        public List<LEDPixelModel> NewPixels { get; set; }

        public byte? NewBrightness { get; set; }

        public uint? DelayBetweenPixels { get; set; }


        public uint? DelayToNextScene { get; set; }

    }
}
