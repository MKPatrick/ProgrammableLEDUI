namespace ProgrammableLEDUI.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public LEDStripeModel LEDStripe { get; set; }

        public List<SceneModel> Scenes { get; set; }

    }
}
