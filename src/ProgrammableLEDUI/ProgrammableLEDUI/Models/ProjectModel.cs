namespace ProgrammableLEDUI.Models
{
    [Serializable]
    public class ProjectModel
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public int AmountOfPixels { get; set; }

        public List<SceneModel> Scenes { get; set; }

    }
}
