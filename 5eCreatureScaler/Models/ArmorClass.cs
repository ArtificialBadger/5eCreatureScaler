namespace CreatureScaler.Models
{
    public sealed class ArmorClass
    {
        public ArmorClass()
        {

        }

        public ArmorClass(int value, string description = "")
        {
            this.Value = value;
            this.Description = description;
        }
        
        public int Value
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}