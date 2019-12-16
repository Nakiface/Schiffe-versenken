namespace Schiffe_Versenken
{
    class Field
    {
        public bool Ship { get; set; } = false;
        public bool Water { get; set; } = true;
        public bool Hit { get; set; } = false;
        public bool Miss { get; set; } = false;
        public bool Placing { get; set; } = true;
    }
}
