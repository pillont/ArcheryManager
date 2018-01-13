namespace ArcheryGlobalResult.Upjv
{
    public class JsonRegistered
    {
        public string Category { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Licence { get; set; }

        public string Name { get; set; }

        public JsonRegistered()
        {
        }

        public override string ToString()
        {
            return $"{Name} {FirstName}";
        }
    }
}
