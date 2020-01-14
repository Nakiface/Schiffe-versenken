namespace Schiffe_Versenken
{
    public class Field
    {
        public bool Ship { get; set; } = false;
        public bool Hit { get; set; } = false;
        public bool Miss { get; set; } = false;
        public bool Placing { get; set; } = true;
        public bool sunk { get; set; } = false;
    }
}
