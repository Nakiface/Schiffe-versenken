namespace Schiffe_Versenken
{
    public class Field
    {
        //Ein "Field" hat folgende infos :
        //Ist auf dem Feld ein Schiff
        //Ist auf dem Feld ein Treffer
        //Ist auf dem Feld daneben geschossen wurden
        //Darf auf dem Feld ein Schiff plaziert werden

        public bool Ship { get; set; } = false;
        public bool Hit { get; set; } = false;
        public bool Miss { get; set; } = false;
        public bool Placing { get; set; } = true;
    }
}
