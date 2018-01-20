namespace Beveiliging
{
    public struct HueLampHelderheid
    {
        public static HueLampHelderheid Maximum => new HueLampHelderheid(254);
        public static HueLampHelderheid Minimum => new HueLampHelderheid(0);

        public HueLampHelderheid(uint waarde)
        {
            Waarde = waarde;
        }

        public uint Waarde { get; }
    }
}