namespace ProgrammableLEDUI.Models
{
    public class LEDStripeModel
    {
        public int ID { get; set; }
        public LEDPixelModel[] LEDPixels { get; set; }

        public int AmountOfPixels
        {
            get { return LEDPixels != null ? LEDPixels.Length : 0; }
        }

        public byte Brighntess { get; set; }

    }
}
