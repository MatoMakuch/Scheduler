namespace CyberFab.Attributes.Net8
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluralFormAttribute(string pluralForm) : Attribute
    {
        public string PluralForm { get; set; } = pluralForm;
    }
}
