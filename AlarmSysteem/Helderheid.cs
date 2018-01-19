namespace Beveiliging
{
    public struct Helderheid
    {
        public static Helderheid Maximum => new Helderheid(254);
        public static Helderheid Minimum => new Helderheid(0);

        public Helderheid(uint waarde)
        {
            Waarde = waarde;
        }

        public uint Waarde { get; }
    }
}