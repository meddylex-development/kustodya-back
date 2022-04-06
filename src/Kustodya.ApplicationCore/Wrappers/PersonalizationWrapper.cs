namespace Kustodya.Shared.Wrappers
{
    public class PersonalizationWrapper
    {
        public string subject { get; set; }
        public SendgridEmailTo[] to { get; set; }
    }
}