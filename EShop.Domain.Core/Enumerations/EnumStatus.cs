namespace EShop.Domain.Core.Enumerations
{
    public class EnumStatus : Enumeration
    {
        public static EnumStatus Passive = new EnumStatus(0, "Pasif");
        public static EnumStatus Active = new EnumStatus(1, "Aktif");

        public EnumStatus(int id, string name) : base(id, name)
        {
        }
    }
}