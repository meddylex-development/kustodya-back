namespace Kustodya.ApplicationCore.Dtos.Incapacidades
{
    public class MembershipModel
    {
        public byte? Id { get; set; }
        public string Name { get; set; }

        public enum Status
        {
            Active = 1,
        }
    }
}